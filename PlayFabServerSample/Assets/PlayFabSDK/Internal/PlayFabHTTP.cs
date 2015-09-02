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
using System.Threading;
using System.Text;
using System.IO;

namespace PlayFab.Internal
{
    public class PlayFabHTTP : SingletonMonoBehaviour<PlayFabHTTP>
    {
        //Queue for making thread safe Callbacks back to the Main Thread in unity.
        private Queue<CallBackContainer> _RunOnMainThreadQueue = new Queue<CallBackContainer>();
        private int pendingMessages = 0;

        public void Awake()
        {

#if !UNITY_WP8
            //These are performance Optimizations for HttpWebRequests.
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
        public static void Post(string url, string data, string authType, string authKey, Action<string, PlayFabError> callback)
        {
#if PLAYFAB_IOS_PLUGIN
			PlayFabiOSPlugin.Post(url, data, authType, authKey, PlayFabVersion.getVersionString(), callback);
#else
            PlayFabHTTP.instance.InstPost(url, data, authType, authKey, callback);
#endif
        }

        /// <summary>
        /// Sends a POST HTTP request
        /// </summary>
        public static void Post(string url, string data, string authType, string authKey, Action<string, PlayFabError> callback, bool IsBlocking)
        {
            if (IsBlocking)
            {
                PlayFabHTTP.instance.MakeRequestViaWebRequestSyncronous(url, data, authType, authKey, callback);
            }
            else
            {
#if PLAYFAB_IOS_PLUGIN
			    PlayFabiOSPlugin.Post(url, data, authType, authKey, PlayFabVersion.getVersionString(), callback);
#else
                PlayFabHTTP.instance.InstPost(url, data, authType, authKey, callback);
#endif
            }
        }
        #endregion

        #region Web Request Methods based on PlayFabSettings.WebRequestTypes
        private void InstPost(string url, string data, string authType, string authKey, Action<string, PlayFabError> callback)
        {
            pendingMessages += 1;
#if !UNITY_WP8
            if (PlayFabSettings.RequestType == WebRequestType.HttpWebRequest)
            {
                MakeRequestViaWebRequest(url, data, authType, authKey, callback);
                return;
            }
#endif
            StartCoroutine(MakeRequestViaUnity(url, data, authType, authKey, callback));
        }

        private void MakeRequestViaWebRequest(string url, string data, string authType, string authKey, Action<string, PlayFabError> callback)
        {
            byte[] payload = System.Text.Encoding.UTF8.GetBytes(data);
            //TODO: make closure it's own method.
            Thread workerThread = new Thread(() =>
            {
                HttpWebRequest request = null;
                HttpWebResponse response = null;
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    //Prevents hitting a proxy is no proxy is available.
                    request.Proxy = null; //TODO: Add support for proxy's.
                    request.Headers.Add("X-ReportErrorAsSuccess", "true"); // Without this, we have to catch WebException instead, and manually decode the result
                    request.Headers.Add("X-PlayFabSDK", PlayFabVersion.getVersionString());
                    if (authType != null)
                    {
                        request.Headers.Add(authType, authKey);
                    }
                    request.ContentType = "application/json";
                    request.Method = "POST";
                    request.KeepAlive = PlayFabSettings.RequestKeepAlive;
                    request.Timeout = PlayFabSettings.RequestTimeout;

                    //Get Request Stream and send data in the body.
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(payload, 0, payload.Length);
                    }

                    response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (var stream = new System.IO.StreamReader(response.GetResponseStream()))
                        {
                            var result = stream.ReadToEnd();
                            //Lock for protection of simultaneous API calls.
                            lock (_RunOnMainThreadQueue)
                            {
                                var cbc = new CallBackContainer() { action = callback, result = result, error = null };
                                _RunOnMainThreadQueue.Enqueue(cbc);
                            }
                        }
                    }
                    else
                    {
                        var error = GeneratePfError(response.StatusCode, PlayFabErrorCode.ServiceUnavailable, "Failed to connect to PlayFab server", null);
                        //Lock for protection of simultaneous API calls.
                        lock (_RunOnMainThreadQueue)
                        {
                            var cbc = new CallBackContainer() { action = callback, result = null, error = error };
                            _RunOnMainThreadQueue.Enqueue(cbc);
                        }
                    }
                }
                catch (WebException e)
                {
                    HttpStatusCode httpCode = response == null ? HttpStatusCode.ServiceUnavailable : response.StatusCode;
                    var error = GeneratePfError(httpCode, PlayFabErrorCode.ServiceUnavailable, e.ToString(), null);
                    //Lock for protection of simultaneous API calls.
                    lock (_RunOnMainThreadQueue)
                    {
                        var cbc = new CallBackContainer() { action = callback, result = null, error = error };
                        _RunOnMainThreadQueue.Enqueue(cbc);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e); // If it's an unexpected exception, we should log it noisily

                    HttpStatusCode httpCode = response == null ? HttpStatusCode.ServiceUnavailable : response.StatusCode;
                    var error = GeneratePfError(httpCode, PlayFabErrorCode.ServiceUnavailable, e.ToString(), null);
                    //Lock for protection of simultaneous API calls.
                    lock (_RunOnMainThreadQueue)
                    {
                        var cbc = new CallBackContainer() { action = callback, result = null, error = error };
                        _RunOnMainThreadQueue.Enqueue(cbc);
                    }
                }
                pendingMessages -= 1;
            });
            workerThread.Start();
        }

        private void MakeRequestViaWebRequestSyncronous(string url, string data, string authType, string authKey, Action<string, PlayFabError> callback)
        {
            HttpWebResponse response = null;
            try
            {
                byte[] payload = System.Text.Encoding.UTF8.GetBytes(data);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //Prevents hitting a proxy is no proxy is available.
                request.Proxy = null; //TODO: Add support for proxy's.
                request.Headers.Add("X-ReportErrorAsSuccess", "true");
                request.Headers.Add("X-PlayFabSDK", PlayFabVersion.getVersionString());
                if (authType != null)
                {
                    request.Headers.Add(authType, authKey);
                }
                request.ContentType = "application/json";
                request.Method = "POST";
                request.KeepAlive = PlayFabSettings.RequestKeepAlive;
                request.Timeout = PlayFabSettings.RequestTimeout;

                //Get Request Stream and send data in the body.
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(payload, 0, payload.Length);
                }

                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var stream = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        var result = stream.ReadToEnd();
                        callback(result, null);
                    }
                }
                else
                {
                    HttpStatusCode httpCode = response == null ? HttpStatusCode.ServiceUnavailable : response.StatusCode;
                    var error = GeneratePfError(httpCode, PlayFabErrorCode.ServiceUnavailable, "Failed to connect to PlayFab server", null);
                    callback(null, error);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);

                HttpStatusCode httpCode = response == null ? HttpStatusCode.ServiceUnavailable : response.StatusCode;
                var error = GeneratePfError(httpCode, PlayFabErrorCode.ServiceUnavailable, e.ToString(), null);
                //Lock for protection of simultaneous API calls.
                callback(null, error);
            }
            pendingMessages -= 1;
        }

        //This is the old Unity WWW class call.
        private IEnumerator MakeRequestViaUnity(string url, string data, string authType, string authKey, Action<string, PlayFabError> callback)
        {
            byte[] bData = System.Text.Encoding.UTF8.GetBytes(data);

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
            WWW www = new WWW(url, bData, headers);
            yield return www;

            if (!String.IsNullOrEmpty(www.error))
            {
                var error = GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, www.error, null);
                callback(null, error);
            }
            else
            {
                string response = www.text;
                callback(response, null);
            }

        }
        #endregion

        #region Helper Classes for new HttpWebReqeust
        private string GetResonseCodeResult(HttpStatusCode code)
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

        private PlayFabError GeneratePfError(HttpStatusCode httpCode, PlayFabErrorCode pfErrorCode, string errorMessage, string errorDetails)
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

        #region Thread Safety for HttpWebRequests
        readonly Queue<CallBackContainer> _tempActions = new Queue<CallBackContainer>();
        public void Update()
        {
            //Lock for protection of simultaneous API calls.
            lock (_RunOnMainThreadQueue)
            {
                while (_RunOnMainThreadQueue.Count > 0)
                {
                    var actionToQueue = _RunOnMainThreadQueue.Dequeue();
                    _tempActions.Enqueue(actionToQueue);
                }
            }

            while (_tempActions.Count > 0)
            {
                var eachaction = _tempActions.Dequeue();
                eachaction.action.Invoke(eachaction.result, eachaction.error);
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
        public int GetPendingMessages()
        {
            return pendingMessages;
        }
        #endregion
    }

    /// <summary>
    /// This is a callback class for use with HttpWebRequest.
    /// </summary>
    public struct CallBackContainer
    {
        public Action<string, PlayFabError> action;
        public string result;
        public PlayFabError error;
    }
}
