#if !UNITY_WSA && !UNITY_WP8
using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using PlayFab.SharedModels;
#if !DISABLE_PLAYFABCLIENT_API
using PlayFab.ClientModels;
#endif
using PlayFab.Json;

namespace PlayFab.Internal
{
    public class PlayFabWebRequest : IPlayFabHttp
    {
        private static readonly Queue<Action> ResultQueue = new Queue<Action>();
        private static readonly Queue<Action> _tempActions = new Queue<Action>();
        private static readonly List<CallRequestContainer> ActiveRequests = new List<CallRequestContainer>();

        private static Thread _requestQueueThread;
        private static readonly object _ThreadLock = new object();
        private static readonly TimeSpan ThreadKillTimeout = TimeSpan.FromSeconds(60);
        private static DateTime _threadKillTime = DateTime.UtcNow + ThreadKillTimeout; // Kill the thread after 1 minute of inactivity
        private static bool _isApplicationPlaying;
        private static int _activeCallCount;

        private static string _unityVersion;

        private static string _authKey;
        private static bool _sessionStarted;
        public bool SessionStarted { get { return _sessionStarted; } set { _sessionStarted = value; } }
        public string AuthKey { get { return _authKey; } set { _authKey = value; } }

        public void InitializeHttp()
        {
            SetupCertificates();
            _isApplicationPlaying = true;
            _unityVersion = Application.unityVersion;
        }

        public void OnDestroy()
        {
            _isApplicationPlaying = false;
            lock (ResultQueue)
            {
                ResultQueue.Clear();
            }
            lock (ActiveRequests)
            {
                ActiveRequests.Clear();
            }
            lock (_ThreadLock)
            {
                _requestQueueThread = null;
            }
        }

        private void SetupCertificates()
        {
            // These are performance Optimizations for HttpWebRequests.
            ServicePointManager.DefaultConnectionLimit = 10;
            ServicePointManager.Expect100Continue = false;

            //Support for SSL
            var rcvc = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications); //(sender, cert, chain, ssl) => true
            ServicePointManager.ServerCertificateValidationCallback = rcvc;
        }

        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public void MakeApiCall(CallRequestContainer reqContainer)
        {
            reqContainer.HttpState = HttpRequestState.Idle;

            lock (ActiveRequests)
            {
                ActiveRequests.Insert(0, reqContainer);
            }

            ActivateThreadWorker();
        }

        private static void ActivateThreadWorker()
        {
            lock (_ThreadLock)
            {
                if (_requestQueueThread != null)
                {
                    return;
                }
                _requestQueueThread = new Thread(WorkerThreadMainLoop);
                _requestQueueThread.Start();
            }
        }

        private static void WorkerThreadMainLoop()
        {
            try
            {
                bool active;
                lock (_ThreadLock)
                {
                    // Kill the thread after 1 minute of inactivity
                    _threadKillTime = DateTime.UtcNow + ThreadKillTimeout;
                }

                List<CallRequestContainer> localActiveRequests = new List<CallRequestContainer>();
                do
                {
                    //process active requests
                    lock (ActiveRequests)
                    {
                        localActiveRequests.AddRange(ActiveRequests);
                        ActiveRequests.Clear();
                        _activeCallCount = localActiveRequests.Count;
                    }

                    var activeCalls = localActiveRequests.Count;
                    for (var i = activeCalls - 1; i >= 0; i--) // We must iterate backwards, because we remove at index i in some cases
                    {
                        switch (localActiveRequests[i].HttpState)
                        {
                            case HttpRequestState.Error:
                                localActiveRequests.RemoveAt(i); break;
                            case HttpRequestState.Idle:
                                Post(localActiveRequests[i]); break;
                            case HttpRequestState.Sent:
                                if (localActiveRequests[i].HttpRequest.HaveResponse) // Else we'll try again next tick
                                    ProcessHttpResponse(localActiveRequests[i]);
                                break;
                            case HttpRequestState.Received:
                                ProcessJsonResponse(localActiveRequests[i]);
                                localActiveRequests.RemoveAt(i);
                                break;
                        }
                    }

                    #region Expire Thread.
                    // Check if we've been inactive
                    lock (_ThreadLock)
                    {
                        var now = DateTime.UtcNow;
                        if (activeCalls > 0 && _isApplicationPlaying)
                        {
                            // Still active, reset the _threadKillTime
                            _threadKillTime = now + ThreadKillTimeout;
                        }
                        // Kill the thread after 1 minute of inactivity
                        active = now <= _threadKillTime;
                        if (!active)
                        {
                            _requestQueueThread = null;
                        }
                        // This thread will be stopped, so null this now, inside lock (_threadLock)
                    }
                    #endregion

                    Thread.Sleep(1);
                } while (active);

            }
            catch (Exception e)
            {
                Debug.LogException(e);
                _requestQueueThread = null;
            }
        }

        private static void Post(CallRequestContainer reqContainer)
        {
            try
            {
                reqContainer.HttpRequest = (HttpWebRequest)WebRequest.Create(reqContainer.FullUrl);
                reqContainer.HttpRequest.UserAgent = "UnityEngine-Unity; Version: " + _unityVersion;
                reqContainer.HttpRequest.SendChunked = false;
                // Prevents hitting a proxy if no proxy is available. TODO: Add support for proxy's.
                reqContainer.HttpRequest.Proxy = null;

                foreach (var pair in reqContainer.RequestHeaders)
                    reqContainer.HttpRequest.Headers.Add(pair.Key, pair.Value);

                reqContainer.HttpRequest.ContentType = "application/json";
                reqContainer.HttpRequest.Method = "POST";
                reqContainer.HttpRequest.KeepAlive = PlayFabSettings.RequestKeepAlive;
                reqContainer.HttpRequest.Timeout = PlayFabSettings.RequestTimeout;
                reqContainer.HttpRequest.AllowWriteStreamBuffering = false;
                reqContainer.HttpRequest.Proxy = null;
                reqContainer.HttpRequest.ContentLength = reqContainer.Payload.LongLength;
                reqContainer.HttpRequest.ReadWriteTimeout = PlayFabSettings.RequestTimeout;

                //Debug.Log("Get Stream");
                // Get Request Stream and send data in the body.
                using (var stream = reqContainer.HttpRequest.GetRequestStream())
                {
                    //Debug.Log("Post Stream");
                    stream.Write(reqContainer.Payload, 0, reqContainer.Payload.Length);
                    //Debug.Log("After Post stream");
                }

                reqContainer.HttpState = HttpRequestState.Sent;
            }
            catch (WebException e)
            {
                reqContainer.JsonResponse = ResponseToString(e.Response) ?? e.Status + ": WebException making http request to: " + reqContainer.FullUrl;
                var enhancedError = new WebException(reqContainer.JsonResponse, e);
                Debug.LogException(enhancedError);
                QueueRequestError(reqContainer);
            }
            catch (Exception e)
            {
                reqContainer.JsonResponse = "Unhandled exception in Post : " + reqContainer.FullUrl;
                var enhancedError = new Exception(reqContainer.JsonResponse, e);
                Debug.LogException(enhancedError);
                QueueRequestError(reqContainer);
            }
        }

        private static void ProcessHttpResponse(CallRequestContainer reqContainer)
        {
            try
            {
#if PLAYFAB_REQUEST_TIMING
                reqContainer.Timing.WorkerRequestMs = (int)reqContainer.Stopwatch.ElapsedMilliseconds;
#endif
                // Get and check the response
                var httpResponse = (HttpWebResponse)reqContainer.HttpRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    reqContainer.JsonResponse = ResponseToString(httpResponse);
                }

                if (httpResponse.StatusCode != HttpStatusCode.OK || string.IsNullOrEmpty(reqContainer.JsonResponse))
                {
                    reqContainer.JsonResponse = reqContainer.JsonResponse ?? "No response from server";
                    QueueRequestError(reqContainer);
                    return;
                }
                else
                {
                    // Response Recieved Successfully, now process.
                }

                reqContainer.HttpState = HttpRequestState.Received;
            }
            catch (Exception e)
            {
                var msg = "Unhandled exception in ProcessHttpResponse : " + reqContainer.FullUrl;
                reqContainer.JsonResponse = reqContainer.JsonResponse ?? msg;
                var enhancedError = new Exception(msg, e);
                Debug.LogException(enhancedError);
                QueueRequestError(reqContainer);
            }
        }

        /// <summary>
        /// Set the reqContainer into an error state, and queue it to invoke the ErrorCallback for that request
        /// </summary>
        private static void QueueRequestError(CallRequestContainer reqContainer)
        {
            reqContainer.Error = PlayFabHttp.GeneratePlayFabError(reqContainer.JsonResponse, reqContainer.CustomData); // Decode the server-json error
            reqContainer.HttpState = HttpRequestState.Error;
            lock (ResultQueue)
            {
                //Queue The result callbacks to run on the main thread.
                ResultQueue.Enqueue(() =>
                {
                    PlayFabHttp.SendErrorEvent(reqContainer.ApiRequest, reqContainer.Error);
                    if (reqContainer.ErrorCallback != null)
                        reqContainer.ErrorCallback(reqContainer.Error);
                });
            }
        }

        private static void ProcessJsonResponse(CallRequestContainer reqContainer)
        {
            try
            {
                var httpResult = JsonWrapper.DeserializeObject<HttpResponseObject>(reqContainer.JsonResponse);

#if PLAYFAB_REQUEST_TIMING
                reqContainer.Timing.WorkerRequestMs = (int)reqContainer.Stopwatch.ElapsedMilliseconds;
#endif

                //This would happen if playfab returned a 500 internal server error or a bad json response.
                if (httpResult == null || httpResult.code != 200)
                {
                    QueueRequestError(reqContainer);
                    return;
                }

                reqContainer.JsonResponse = JsonWrapper.SerializeObject(httpResult.data);
                reqContainer.DeserializeResultJson(); // Assigns Result with a properly typed object
                reqContainer.ApiResult.Request = reqContainer.ApiRequest;
                reqContainer.ApiResult.CustomData = reqContainer.CustomData;

#if !DISABLE_PLAYFABCLIENT_API
                ClientModels.UserSettings userSettings = null;
                var res = reqContainer.ApiResult as ClientModels.LoginResult;
                var regRes = reqContainer.ApiResult as ClientModels.RegisterPlayFabUserResult;
                if (res != null)
                {
                    userSettings = res.SettingsForUser;
                    _authKey = res.SessionTicket;
                }
                else if (regRes != null)
                {
                    userSettings = regRes.SettingsForUser;
                    _authKey = regRes.SessionTicket;
                }

                if (userSettings != null && _authKey != null && userSettings.NeedsAttribution)
                {
                    lock (ResultQueue)
                    {
                        ResultQueue.Enqueue(PlayFabIdfa.OnPlayFabLogin);
                    }
                }
#endif
                lock (ResultQueue)
                {
                    //Queue The result callbacks to run on the main thread.
                    ResultQueue.Enqueue(() =>
                    {
#if PLAYFAB_REQUEST_TIMING
                        reqContainer.Stopwatch.Stop();
                        reqContainer.Timing.MainThreadRequestMs = (int)reqContainer.Stopwatch.ElapsedMilliseconds;
                        PlayFabHttp.SendRequestTiming(reqContainer.Timing);
#endif
                        try
                        {
                            PlayFabHttp.SendEvent(reqContainer.ApiEndpoint, reqContainer.ApiRequest, reqContainer.ApiResult, ApiProcessingEventType.Post);
                            reqContainer.InvokeSuccessCallback();
                        }
                        catch (Exception e)
                        {
                            Debug.LogException(e); // Log the user's callback exception back to them without halting PlayFabHttp
                        }
                    });
                }
            }
            catch (Exception e)
            {
                var msg = "Unhandled exception in ProcessJsonResponse : " + reqContainer.FullUrl;
                reqContainer.JsonResponse = reqContainer.JsonResponse ?? msg;
                var enhancedError = new Exception(msg, e);
                Debug.LogException(enhancedError);
                QueueRequestError(reqContainer);
            }
        }

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
                finishedRequest();
            }
        }

        private static string ResponseToString(WebResponse webResponse)
        {
            if (webResponse == null)
                return null;

            try
            {
                using (var responseStream = webResponse.GetResponseStream())
                {
                    if (responseStream == null)
                        return null;
                    using (var stream = new StreamReader(responseStream))
                    {
                        return stream.ReadToEnd();
                    }
                }
            }
            catch (WebException webException)
            {
                try
                {
                    using (var responseStream = webException.Response.GetResponseStream())
                    {
                        if (responseStream == null)
                            return null;
                        using (var stream = new StreamReader(responseStream))
                        {
                            return stream.ReadToEnd();
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return null;
            }
        }

        public int GetPendingMessages()
        {
            var count = 0;
            lock (ActiveRequests)
                count += ActiveRequests.Count + _activeCallCount;
            lock (ResultQueue)
                count += ResultQueue.Count;
            return count;
        }
    }
}

#endif
