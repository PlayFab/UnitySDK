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

        private static Thread _RequestQueueThread;
        private static readonly object _ThreadLock = new object();
        private static TimeSpan _threadKillTimeout = TimeSpan.FromSeconds(60);
        private static DateTime _threadKillTime = DateTime.UtcNow + _threadKillTimeout; // Kill the thread after 1 minute of inactivity
        private static bool _isApplicationPlaying;
        private static int _activeCallCount;

        private static string _UnityVersion;

        private static string _authKey;
        private static string _devKey;
        private static bool _sessionStarted;
        public bool SessionStarted { get { return _sessionStarted; } set { _sessionStarted = value; } }
        public string AuthKey { get { return _authKey; } set { _authKey = value; } }
        public string DevKey { get { return _devKey; } set { _devKey = value; } }

        public void InitializeHttp()
        {
            SetupCertificates();
            _isApplicationPlaying = true;
            _UnityVersion = Application.unityVersion;
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
                _RequestQueueThread = null;
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
                if (_RequestQueueThread != null)
                {
                    return;
                }
                _RequestQueueThread = new Thread(WorkerThreadMainLoop);
                _RequestQueueThread.Start();
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
                    _threadKillTime = DateTime.UtcNow + _threadKillTimeout;
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
                    for (var i = activeCalls - 1; i >= 0; i--)
                    {
                        //Debug.Log(localActiveRequests[i].State);

                        if (localActiveRequests[i].HttpState == HttpRequestState.Error)
                        {
                            localActiveRequests.RemoveAt(i);
                            continue;
                        }

                        if (localActiveRequests[i].HttpState == HttpRequestState.Idle)
                        {
                            Post(localActiveRequests[i]);
                        }

                        //Skipping Becuase we have sent the request but do not have a response yet.
                        if (localActiveRequests[i].HttpState == HttpRequestState.Sent &&
                            !localActiveRequests[i].HttpRequest.HaveResponse)
                        {
                            continue;
                        }

                        //We have a response to the request, and now we will process the response.
                        if (localActiveRequests[i].HttpState == HttpRequestState.Sent &&
                            localActiveRequests[i].HttpRequest.HaveResponse)
                        {
                            ProcessHttpResponse(localActiveRequests[i]);
                        }

                        //If we have received the response and processed it, now process the json message.
                        if (localActiveRequests[i].HttpState != HttpRequestState.Received)
                        {
                            continue;
                        }

                        //Debug.Log("Process Json Action.");
                        ProcessJsonResponse(localActiveRequests[i]);
                        localActiveRequests.RemoveAt(i);
                    }

                    #region Expire Thread.
                    // Check if we've been inactive
                    lock (_ThreadLock)
                    {
                        var now = DateTime.UtcNow;
                        if (activeCalls > 0 && _isApplicationPlaying)
                        {
                            // Still active, reset the _threadKillTime
                            _threadKillTime = now + _threadKillTimeout;
                        }
                        // Kill the thread after 1 minute of inactivity
                        active = now <= _threadKillTime;
                        if (!active)
                        {
                            _RequestQueueThread = null;
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
                _RequestQueueThread = null;
            }
        }

        private static void Post(CallRequestContainer reqContainer)
        {
            try
            {
                reqContainer.HttpRequest = (HttpWebRequest)WebRequest.Create(reqContainer.FullUrl);
                reqContainer.HttpRequest.UserAgent = "UnityEngine-Unity; Version: " + _UnityVersion;
                reqContainer.HttpRequest.SendChunked = false;
                reqContainer.HttpRequest.Proxy = null;
                // Prevents hitting a proxy if no proxy is available. TODO: Add support for proxy's.
                reqContainer.HttpRequest.Headers.Add("X-ReportErrorAsSuccess", "true");
                // Without this, we have to catch WebException instead, and manually decode the result
                reqContainer.HttpRequest.Headers.Add("X-PlayFabSDK", PlayFabSettings.VersionString);

                if (reqContainer.AuthKey == AuthType.DevSecretKey)
                {
                    reqContainer.HttpRequest.Headers.Add("X-SecretKey", _devKey);
                }
                else if (reqContainer.AuthKey == AuthType.LoginSession)
                {
                    reqContainer.HttpRequest.Headers.Add("X-Authorization", _authKey);
                }

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
                using (Stream stream = reqContainer.HttpRequest.GetRequestStream())
                {
                    //Debug.Log("Post Stream");
                    stream.Write(reqContainer.Payload, 0, reqContainer.Payload.Length);
                    //Debug.Log("After Post stream");
                }

                reqContainer.HttpState = HttpRequestState.Sent;
            }
            catch (WebException e)
            {
                if (reqContainer.RetryTimeoutCounter == 0 && e.Status == WebExceptionStatus.Timeout)
                {
                    reqContainer.RetryTimeoutCounter++;
                }
                else
                {
                    var enhancedError = new WebException("Exception making http request to :" + reqContainer.FullUrl, e);
                    Debug.LogException(enhancedError);
                    reqContainer.RetryTimeoutCounter = 0;
                    reqContainer.HttpState = HttpRequestState.Error;
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                reqContainer.HttpState = HttpRequestState.Error;
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
                HttpWebResponse httpResponse = (HttpWebResponse)reqContainer.HttpRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    reqContainer.JsonResponse = ResponseToString(httpResponse);
                }

                if (httpResponse.StatusCode != HttpStatusCode.OK || string.IsNullOrEmpty(reqContainer.JsonResponse))
                {
                    var message = string.IsNullOrEmpty(reqContainer.JsonResponse)
                        ? "Internal Server Error"
                        : reqContainer.JsonResponse;
                    reqContainer.Error = PlayFabHttp.GeneratePlayFabError(message, reqContainer.CustomData);
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
                Debug.LogException(e);
                reqContainer.HttpState = HttpRequestState.Error;
            }
        }

        private static void ProcessJsonResponse(CallRequestContainer reqContainer)
        {
            try
            {
                var httpResult = JsonWrapper.DeserializeObject<HttpResponseObject>(reqContainer.JsonResponse,
                    PlayFabUtil.ApiSerializerStrategy);

#if PLAYFAB_REQUEST_TIMING
                reqContainer.Timing.WorkerRequestMs = (int)reqContainer.Stopwatch.ElapsedMilliseconds;
#endif

                //This would happen if playfab returned a 500 internal server error or a bad json response.
                if (httpResult == null)
                {
                    reqContainer.Error = PlayFabHttp.GeneratePlayFabErrorGeneric(reqContainer.JsonResponse, null, reqContainer.CustomData);
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
                    return;
                }

                if (httpResult.code != 200)
                {
                    reqContainer.Error = PlayFabHttp.GeneratePlayFabError(reqContainer.JsonResponse, reqContainer.CustomData);
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
                    return;
                }

                reqContainer.JsonResponse = JsonWrapper.SerializeObject(httpResult.data, PlayFabUtil.ApiSerializerStrategy);
                reqContainer.DeserializeResultJson(); // Assigns Result with a properly typed object
                reqContainer.ApiResult.Request = reqContainer.ApiRequest;
                reqContainer.ApiResult.CustomData = reqContainer.CustomData;

#if !DISABLE_PLAYFABCLIENT_API
                UserSettings userSettings = null;
                var res = reqContainer.ApiResult as LoginResult;
                var regRes = reqContainer.ApiResult as RegisterPlayFabUserResult;
                if (res != null)
                {
                    userSettings = res.SettingsForUser;
                    _authKey = res.SessionTicket;
                }
                else if (regRes != null)
                {
                    userSettings = res.SettingsForUser;
                    _authKey = regRes.SessionTicket;
                }

                if (userSettings != null && _authKey != null && userSettings.NeedsAttribution)
                {
                    lock (ResultQueue)
                    {
                        ResultQueue.Enqueue(PlayFabIdfa.OnPlayFabLogin);
                    }
                }

                var cloudScriptUrl = reqContainer.ApiResult as GetCloudScriptUrlResult;
                if (cloudScriptUrl != null)
                {
                    PlayFabSettings.LogicServerUrl = cloudScriptUrl.Url;
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
                            PlayFabHttp.SendEvent(reqContainer.ApiRequest, reqContainer.ApiResult, ApiProcessingEventType.Post);
                            reqContainer.InvokeSuccessCallback();
                        }
                        catch (Exception e)
                        {
                            Debug.LogException(e);
                        }
                    });
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                reqContainer.HttpState = HttpRequestState.Error;
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

        private static string ResponseToString(HttpWebResponse webResponse)
        {
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
            int count = 0;
            lock (ActiveRequests)
                count += ActiveRequests.Count + _activeCallCount;
            lock (ResultQueue)
                count += ResultQueue.Count;
            return count;
        }
    }
}

#endif
