#if UNITY_EDITOR

#elif UNITY_ANDROID
#define PLAYFAB_ANDROID_PLUGIN
#elif UNITY_IOS
#define PLAYFAB_IOS_PLUGIN
#endif


using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace PlayFab.Internal
{
    public class PlayFabHTTP : SingletonMonoBehaviour<PlayFabHTTP>
    {
        private static Thread _requestQueueThread = null;
        private static DateTime _threadKillTime = DateTime.UtcNow + TimeSpan.FromMinutes(1); // Kill the thread after 1 minute of inactivity
        private static readonly object ThreadLock = new object(); // Lock for modifying _requestQueueThread and/or _threadKillTime
        // Queue for making thread safe Callbacks back to the Main Thread in unity.
        private static readonly List<CallRequestContainer> ActiveRequests = new List<CallRequestContainer>();
        private static readonly Queue<CallResultContainer> ResultQueue = new Queue<CallResultContainer>();
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
        public static void Post(string url, string data, string authType, string authKey, Action<string, PlayFabError> callback, bool isBlocking = false)
        {
            if (!isBlocking)
            {
#if PLAYFAB_IOS_PLUGIN
                PlayFabiOSPlugin.Post(PlayFabSettings.GetFullUrl(url), data, authType, authKey, PlayFabVersion.getVersionString(), callback);
#elif UNITY_WP8
                instance.StartCoroutine(instance.MakeRequestViaUnity(url, data, authType, authKey, callback));
#else
                if (PlayFabSettings.RequestType == WebRequestType.HttpWebRequest)
                {
                    Action<string, PlayFabError> internalCallback = (result, error) =>
                    {
                        lock (ResultQueue) // Lock for protection of simultaneous API calls.
                            ResultQueue.Enqueue(new CallResultContainer() { Action = callback, Result = result, Error = error });
                    };

                    lock (ActiveRequests)
                        ActiveRequests.Insert(0, new CallRequestContainer { AuthKey = authKey, AuthType = authType, Callback = internalCallback, Data = data, Url = url });
                    _ActivateWorkerThread();
                }
                else
                    instance.StartCoroutine(instance.MakeRequestViaUnity(url, data, authType, authKey, callback));
#endif
            }
            else
            {
                var request = new CallRequestContainer { AuthKey = authKey, AuthType = authType, Callback = callback, Data = data, Url = url };
                StartHttpWebRequest(request);
                ProcessHttpWebResult(request, true);
                request.Callback(request.Result, request.Error);
            }
        }
        #endregion

        #region Web Request Methods based on PlayFabSettings.WebRequestTypes
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
                            if (ActiveRequests[i].state == CallRequestContainer.RequestState.REQUEST_SENT && !ProcessHttpWebResult(ActiveRequests[i]))
                                continue; // Waiting for request to return, skip it

                            if (ActiveRequests[i].state == CallRequestContainer.RequestState.UNSTARTED)
                                StartHttpWebRequest(ActiveRequests[i]);
                            else
                            {
                                ActiveRequests[i].Callback(ActiveRequests[i].Result, ActiveRequests[i].Error);
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

                request.HttpRequest.Proxy = null; // Prevents hitting a proxy is no proxy is available. TODO: Add support for proxy's.
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
                request.state = CallRequestContainer.RequestState.REQUEST_SENT;
            }
            catch (WebException e)
            {
                Debug.LogException(e); // If it's an unexpected exception, we should log it noisily
                request.Error = GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, e.ToString());
                request.state = CallRequestContainer.RequestState.ERROR;
            }
            catch (Exception e)
            {
                Debug.LogException(e); // If it's an unexpected exception, we should log it noisily
                request.Error = GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, e.ToString());
                request.state = CallRequestContainer.RequestState.ERROR;
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
                    using (var stream = new System.IO.StreamReader(response.GetResponseStream()))
                        request.Result = stream.ReadToEnd();
                }
                else
                {
                    request.Error = GeneratePfError(response.StatusCode, PlayFabErrorCode.ServiceUnavailable, "Failed to connect to PlayFab server");
                }
                request.state = CallRequestContainer.RequestState.REQUEST_RECEIVED;
            }
            catch (WebException e)
            {
                Debug.LogException(e); // If it's an unexpected exception, we should log it noisily
                request.Error = GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, e.ToString());
                request.state = CallRequestContainer.RequestState.ERROR;
            }
            catch (Exception e)
            {
                Debug.LogException(e); // If it's an unexpected exception, we should log it noisily
                request.Error = GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, e.ToString());
                request.state = CallRequestContainer.RequestState.ERROR;
            }
            return true;
        }

        // This is the old Unity WWW class call.
        private IEnumerator MakeRequestViaUnity(string url, string data, string authType, string authKey, Action<string, PlayFabError> callback)
        {
            _pendingWwwMessages += 1;
            string fullUrl = PlayFabSettings.GetFullUrl(url);
            byte[] bData = Encoding.UTF8.GetBytes(data);

#if UNITY_4_4 || UNITY_4_3 || UNITY_4_2 || UNITY_4_2 || UNITY_4_0 || UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5
            // Using hashtable for compatibility with Unity < 4.5
            Hashtable headers = new Hashtable ();
#else
            Dictionary<string, string> headers = new Dictionary<string, string>();
#endif
            headers.Add("Content-Type", "application/json");
            if (authType != null)
                headers.Add(authType, authKey);
            headers.Add("X-ReportErrorAsSuccess", "true");
            headers.Add("X-PlayFabSDK", PlayFabVersion.getVersionString());
            WWW www = new WWW(fullUrl, bData, headers);
            yield return www;

            if (!String.IsNullOrEmpty(www.error))
            {
                var error = GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, www.error);
                callback(null, error);
            }
            else
            {
                string response = www.text;
                callback(response, null);
            }
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
        private readonly Queue<CallResultContainer> _tempActions = new Queue<CallResultContainer>();
        public void Update()
        {
            //Lock for protection of simultaneous API calls.
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
                var eachaction = _tempActions.Dequeue();
                eachaction.Action.Invoke(eachaction.Result, eachaction.Error);
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

    /// <summary>
    /// This is a callback class for use with HttpWebRequest.
    /// </summary>
    internal class CallRequestContainer
    {
        public enum RequestState { UNSTARTED, REQUEST_SENT, REQUEST_RECEIVED, FINISHED, ERROR };

        public RequestState state = RequestState.UNSTARTED;
        public string Url;
        public string Data;
        public string AuthType;
        public string AuthKey;
        public string Result;
        public HttpWebRequest HttpRequest;
        public PlayFabError Error;
        public Action<string, PlayFabError> Callback;
    }

    /// <summary>
    /// This is a callback class for use with HttpWebRequest.
    /// </summary>
    internal struct CallResultContainer
    {
        public Action<string, PlayFabError> Action;
        public string Result;
        public PlayFabError Error;
    }
}
