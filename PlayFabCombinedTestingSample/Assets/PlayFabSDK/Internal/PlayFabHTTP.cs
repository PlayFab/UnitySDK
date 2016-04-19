#if UNITY_EDITOR

#elif UNITY_ANDROID
#define PLAYFAB_ANDROID
#elif UNITY_IOS
#define PLAYFAB_IOS
#elif UNITY_WP8
#define PLAYFAB_WP8
#endif

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine;

namespace PlayFab.Internal
{
    public class PlayFabHTTP : SingletonMonoBehaviour<PlayFabHTTP>
    {
        private static int callIdGen = 1;
        private static Thread _requestQueueThread = null;
        private static DateTime _threadKillTime = DateTime.UtcNow + TimeSpan.FromMinutes(1); // Kill the thread after 1 minute of inactivity
        private static readonly object ThreadLock = new object(); // Lock for modifying _requestQueueThread and/or _threadKillTime
        // Queue for making thread safe Callbacks back to the Main Thread in unity.
        private static readonly List<CallRequestContainer> ActiveRequests = new List<CallRequestContainer>();
        private static readonly Queue<CallRequestContainer> ResultQueue = new Queue<CallRequestContainer>();
        private static int _pendingWwwMessages = 0;

        public void Awake()
        {
#if !UNITY_WP8
            // These are performance Optimizations for HttpWebRequests.
            ServicePointManager.DefaultConnectionLimit = 10;
            ServicePointManager.Expect100Continue = false;

            //Support for SSL
            var rcvc = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            ServicePointManager.ServerCertificateValidationCallback = rcvc;
#endif
        }

        #region Public API to call PlayFab API Calls.
        /// <summary>
        /// Sends a POST HTTP request
        /// </summary>
        public static void Post(string urlPath, string data, string authType, string authKey, Action<CallRequestContainer> callback, object request, object customData)
        {
            var requestContainer = new CallRequestContainer { RequestType = PlayFabSettings.RequestType, CallId = callIdGen++, AuthKey = authKey, AuthType = authType, Callback = callback, Data = data, Url = urlPath, Request = request, CustomData = customData };
#if PLAYFAB_WP8
            instance.StartCoroutine(instance.MakeRequestViaUnity(requestContainer));
#else
            if (PlayFabSettings.RequestType == WebRequestType.HttpWebRequest)
            {

                lock (ActiveRequests)
                    ActiveRequests.Insert(0, requestContainer);
                // Parsing on this container is done backwards, so insert at 0 to make calls process in roughly queue order (but still not actually guaranteed)
                PlayFabSettings.InvokeRequest(urlPath, requestContainer.CallId, request, customData);
                _ActivateWorkerThread();
            }
            else
            {
                instance.StartCoroutine(instance.MakeRequestViaUnity(requestContainer));
            }
#endif
        }
        #endregion

        #region Web Request Methods based on PlayFabSettings.WebRequestTypes
#if !PLAYFAB_WP8
        /// <summary>
        /// If the worker thread is not running, start it
        /// </summary>
        private static void _ActivateWorkerThread()
        {
            lock (ThreadLock)
            {
                if (_requestQueueThread == null)
                {
                    _requestQueueThread = new Thread(_WorkerThreadMainLoop);
                    _requestQueueThread.Start();
                }
            }
        }

        private static void _WorkerThreadMainLoop()
        {
            try
            {
                bool active;
                int activeCalls;
                DateTime now;
                lock (ThreadLock)
                    _threadKillTime = DateTime.UtcNow + TimeSpan.FromMinutes(1); // Kill the thread after 1 minute of inactivity

                do
                {
                    // Process active requests
                    lock (ActiveRequests)
                    {
                        activeCalls = ActiveRequests.Count;
                        for (int i = activeCalls - 1; i >= 0; i--)
                        {
                            if (ActiveRequests[i].State == CallRequestContainer.RequestState.RequestSent && !ProcessHttpWebResult(ActiveRequests[i]))
                                continue; // Waiting for request to return, skip it

                            if (ActiveRequests[i].State == CallRequestContainer.RequestState.Unstarted)
                                StartHttpWebRequest(ActiveRequests[i]);
                            else
                            {
                                if (ActiveRequests[i].RequestType == WebRequestType.HttpWebRequest) // Threaded, push back to main thread
                                    lock (ResultQueue)
                                        ResultQueue.Enqueue(ActiveRequests[i]);
                                else
                                    ActiveRequests[i].InvokeCallback();
                                ActiveRequests.RemoveAt(i);
                            }
                        }
                    }

                    // Check if we've been inactive
                    lock (ThreadLock)
                    {
                        now = DateTime.UtcNow;
                        if (activeCalls > 0)
                            // Still active, reset the _threadKillTime
                            _threadKillTime = now + TimeSpan.FromMinutes(1);
                        // Kill the thread after 1 minute of inactivity
                        active = now <= _threadKillTime;
                        if (!active)
                            _requestQueueThread = null;
                        // This thread will be stopped, so null this now, inside lock (_threadLock)
                    }

                    Thread.Sleep(1);
                } while (active);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                _requestQueueThread = null;
            }
        }

        private static void StartHttpWebRequest(CallRequestContainer request)
        {
            try
            {
                string fullUrl = PlayFabSettings.GetFullUrl(request.Url);
                var payload = Encoding.UTF8.GetBytes(request.Data);
                request.HttpRequest = (HttpWebRequest)WebRequest.Create(fullUrl);

                request.HttpRequest.Proxy = null; // Prevents hitting a proxy if no proxy is available. TODO: Add support for proxy's.
                request.HttpRequest.Headers.Add("X-ReportErrorAsSuccess", "true"); // Without this, we have to catch WebException instead, and manually decode the result
                request.HttpRequest.Headers.Add("X-PlayFabSDK", PlayFabVersion.getVersionString());
                if (request.AuthType != null)
                    request.HttpRequest.Headers.Add(request.AuthType, request.AuthKey);
                request.HttpRequest.ContentType = "application/json";
                request.HttpRequest.Method = "POST";
                request.HttpRequest.KeepAlive = PlayFabSettings.RequestKeepAlive;
                request.HttpRequest.Timeout = PlayFabSettings.RequestTimeout;
                using (var stream = request.HttpRequest.GetRequestStream()) // Get Request Stream and send data in the body.
                    stream.Write(payload, 0, payload.Length);
                request.State = CallRequestContainer.RequestState.RequestSent;
            }
            catch (WebException e)
            {
                Debug.LogException(e); // If it's an unexpected exception, we should log it noisily
                var errorMessage = ResponseToString(e.Response);
                if (string.IsNullOrEmpty(errorMessage))
                    errorMessage = e.ToString();
                request.Error = GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, errorMessage);
                request.State = CallRequestContainer.RequestState.Error;
            }
            catch (Exception e)
            {
                Debug.LogException(e); // If it's an unexpected exception, we should log it noisily
                request.Error = GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, e.ToString());
                request.State = CallRequestContainer.RequestState.Error;
            }
        }

        private static bool ProcessHttpWebResult(CallRequestContainer request, bool syncronous = false)
        {
            try
            {
                if (!syncronous && !request.HttpRequest.HaveResponse)
                    return false;

                HttpWebResponse response = (HttpWebResponse)request.HttpRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    request.ResultStr = ResponseToString(response);
                }
                if (response.StatusCode != HttpStatusCode.OK || string.IsNullOrEmpty(request.ResultStr))
                {
                    request.Error = GeneratePfError(response.StatusCode, PlayFabErrorCode.ServiceUnavailable, "Failed to connect to PlayFab server");
                }
                request.State = CallRequestContainer.RequestState.RequestReceived;
            }
            catch (WebException e)
            {
                Debug.LogException(e); // If it's an unexpected exception, we should log it noisily
                request.Error = GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, e.ToString());
                request.State = CallRequestContainer.RequestState.Error;
            }
            catch (Exception e)
            {
                Debug.LogException(e); // If it's an unexpected exception, we should log it noisily
                request.Error = GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, e.ToString());
                request.State = CallRequestContainer.RequestState.Error;
            }
            return true;
        }

        /// <summary>
        /// Extract the text-response from a webResponse, if possible
        /// Returns null if there is some kind of connection failure
        /// </summary>
        private static string ResponseToString(WebResponse webResponse)
        {
            try
            {
                var responseStream = webResponse.GetResponseStream();
                if (responseStream == null)
                    return null;
                using (var stream = new System.IO.StreamReader(responseStream))
                    return stream.ReadToEnd();
            }
            catch (Exception)
            {
                return null;
            }
        }
#endif

        // This is the old Unity WWW class call.
        private IEnumerator MakeRequestViaUnity(CallRequestContainer requestContainer)
        {
            _pendingWwwMessages += 1;
            string fullUrl = PlayFabSettings.GetFullUrl(requestContainer.Url);
            byte[] bData = Encoding.UTF8.GetBytes(requestContainer.Data);

#if UNITY_4_4 || UNITY_4_3 || UNITY_4_2 || UNITY_4_2 || UNITY_4_0 || UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5
            // Using hashtable for compatibility with Unity < 4.5
            Hashtable headers = new Hashtable ();
#else
            Dictionary<string, string> headers = new Dictionary<string, string>();
#endif
            headers.Add("Content-Type", "application/json");
            if (requestContainer.AuthType != null)
                headers.Add(requestContainer.AuthType, requestContainer.AuthKey);
            headers.Add("X-ReportErrorAsSuccess", "true");
            headers.Add("X-PlayFabSDK", PlayFabVersion.getVersionString());
            WWW www = new WWW(fullUrl, bData, headers);

            PlayFabSettings.InvokeRequest(requestContainer.Url, requestContainer.CallId, requestContainer.Request, requestContainer.CustomData);

            yield return www;

            requestContainer.ResultStr = null;
            requestContainer.Error = null;
            if (!String.IsNullOrEmpty(www.error))
                requestContainer.Error = GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, www.error);
            else
                requestContainer.ResultStr = www.text;

            requestContainer.InvokeCallback();

            _pendingWwwMessages -= 1;
        }
        #endregion

        #region Helper Classes for new HttpWebReqeust
        private static string GetResonseCodeResult(HttpStatusCode code)
        {
            switch (code)
            {
                //TODO: Handle more specific cases as needed.
                case HttpStatusCode.OK:
                    return string.Format("Success: {0}", code);
                case HttpStatusCode.RequestTimeout:
                    return string.Format("Request Timeout: {0}", code);
                case HttpStatusCode.BadRequest:
                    return string.Format("BadRequest: {0}", code);
                default:
                    return string.Format("Service Unavailable: {0}", code);
            }
        }

        private static PlayFabError GeneratePfError(HttpStatusCode httpCode, PlayFabErrorCode pfErrorCode, string errorMessage)
        {
            return new PlayFabError()
            {
                HttpCode = (int)httpCode,
                HttpStatus = GetResonseCodeResult(httpCode),
                Error = pfErrorCode,
                ErrorMessage = errorMessage,
                ErrorDetails = null
            };
        }
        #endregion

        #region Unity main-thread requirement for HttpWebRequest callbacks
        private readonly Queue<CallRequestContainer> _tempActions = new Queue<CallRequestContainer>();
        public void Update()
        {
            lock (ResultQueue)
            {
                while (ResultQueue.Count > 0)
                {
                    var actionToQueue = ResultQueue.Dequeue();
                    _tempActions.Enqueue(actionToQueue);
                }
            }

            while (_tempActions.Count > 0)
            {
                var finishedRequest = _tempActions.Dequeue();
                finishedRequest.InvokeCallback();
            }
        }
        #endregion

        #region Support for SSL
#if !UNITY_WP8
        private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
#endif
        #endregion

        #region Support for Unit Testing
        public static int GetPendingMessages()
        {
            int count = _pendingWwwMessages;
            lock (ActiveRequests)
                count += ActiveRequests.Count;
            lock (ResultQueue)
                count += ResultQueue.Count;
            return count;
        }
        #endregion
    }
}
