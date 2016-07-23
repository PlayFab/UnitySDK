#if !UNITY_WSA && !UNITY_WP8
using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
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
        private static TimeSpan _threadKillTimeout = TimeSpan.FromSeconds(5);
        private static DateTime _threadKillTime = DateTime.UtcNow + _threadKillTimeout; // Kill the thread after 1 minute of inactivity
        private static bool _isApplicationPlaying;
        private static int _activeCallCount;

        private static string _UnityVersion;
        public string AuthKey { get; set; }
        public string DevKey { get; set; }

        public void Awake()
        {
            SetupCertificates();
            _isApplicationPlaying = true;
            _UnityVersion = Application.unityVersion;
        }

        void OnDestroy()
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

        public void SetupCertificates()
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

        public void MakeApiCall<TRequest, TResult>(string api, string apiEndpoint, TRequest request,
            string authType,
            Action<TResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
            where TRequest : PlayFabRequestCommon where TResult : PlayFabResultCommon
        {

            //Build Endpoint
            var url = PlayFabSettings.GetFullUrl(apiEndpoint);

            var reqContainer = new CallRequestContainer();
#if PLAYFAB_REQUEST_TIMING
            reqContainer.Timing.StartTimeUtc = DateTime.UtcNow;
            reqContainer.Timing.ApiEndpoint = apiEndpoint;
#endif
            reqContainer.State = HttpRequestState.Idle;
            reqContainer.CustomData = customData;
            reqContainer.ProcessPostAction = () =>
            {
                //serialize the request;
                var req = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
                Post(reqContainer, url, req, authType, AuthKey, request, resultCallback, errorCallback);
            };

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

                        if (localActiveRequests[i].State == HttpRequestState.Error)
                        {
                            localActiveRequests.RemoveAt(i);
                            continue;
                        }

                        if (localActiveRequests[i].State == HttpRequestState.Idle)
                        {
                            localActiveRequests[i].ProcessPostAction.Invoke();
                        }

                        //Skipping Becuase we have sent the request but do not have a response yet.
                        if (localActiveRequests[i].State == HttpRequestState.Sent &&
                            !localActiveRequests[i].Request.HaveResponse)
                        {
                            continue;
                        }

                        //We have a response to the request, and now we will process the response.
                        if (localActiveRequests[i].State == HttpRequestState.Sent &&
                            localActiveRequests[i].Request.HaveResponse)
                        {
                            localActiveRequests[i].ProcessResponseAction.Invoke();
                        }

                        //If we have received the response and processed it, now process the json message.
                        if (localActiveRequests[i].State != HttpRequestState.Received)
                        {
                            continue;
                        }

                        //Debug.Log("Process Json Action.");
                        localActiveRequests[i].ProcessJsonAction.Invoke();
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

        public void Post<TRequest, TResult>(CallRequestContainer reqContainer, string urlPath, string data, string authType, string authKey,
            TRequest request, Action<TResult> callBack, Action<PlayFabError> errorCallback)
            where TRequest : PlayFabRequestCommon where TResult : PlayFabResultCommon
        {

            try
            {
                var payload = Encoding.UTF8.GetBytes(data);

                reqContainer.Request = (HttpWebRequest)WebRequest.Create(urlPath);
                reqContainer.Request.UserAgent = "UnityEngine-Unity; Version: " + _UnityVersion;
                reqContainer.Request.SendChunked = false;
                reqContainer.Request.Proxy = null;
                // Prevents hitting a proxy if no proxy is available. TODO: Add support for proxy's.
                reqContainer.Request.Headers.Add("X-ReportErrorAsSuccess", "true");
                // Without this, we have to catch WebException instead, and manually decode the result
                reqContainer.Request.Headers.Add("X-PlayFabSDK", PlayFabSettings.VersionString);

                if (authType != null)
                {
                    if (authType == "X-SecretKey")
                    {
                        reqContainer.Request.Headers.Add("X-SecretKey", DevKey);
                    }
                    else
                    {
                        reqContainer.Request.Headers.Add(authType, AuthKey);
                    }
                }

                reqContainer.Request.ContentType = "application/json";
                reqContainer.Request.Method = "POST";
                reqContainer.Request.KeepAlive = PlayFabSettings.RequestKeepAlive;
                reqContainer.Request.Timeout = PlayFabSettings.RequestTimeout;
                reqContainer.Request.AllowWriteStreamBuffering = false;
                reqContainer.Request.Proxy = null;
                reqContainer.Request.ContentLength = payload.LongLength;
                reqContainer.Request.ReadWriteTimeout = PlayFabSettings.RequestTimeout;

                //Debug.Log("Get Stream");
                // Get Request Stream and send data in the body.
                using (Stream stream = reqContainer.Request.GetRequestStream())
                {
                    //Debug.Log("Post Stream");
                    stream.Write(payload, 0, payload.Length);
                    //Debug.Log("After Post stream");
                }

                reqContainer.ProcessResponseAction = () =>
                {
                    ProcessHttpResponse(reqContainer, request, callBack, errorCallback);
                };

                reqContainer.State = HttpRequestState.Sent;
            }
            catch (WebException e)
            {
                if (reqContainer.RetryTimeoutCounter == 0 && e.Status == WebExceptionStatus.Timeout)
                {
                    reqContainer.RetryTimeoutCounter++;
                }
                else
                {
                    var enhancedError = new WebException("Exception making http request to :" + urlPath, e);
                    Debug.LogException(enhancedError);
                    reqContainer.RetryTimeoutCounter = 0;
                    reqContainer.State = HttpRequestState.Error;
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                reqContainer.State = HttpRequestState.Error;
            }

        }

        public void ProcessHttpResponse<TRequest, TResult>(CallRequestContainer reqContainer, TRequest request,
            Action<TResult> callBack, Action<PlayFabError> errorCallback)
            where TRequest : PlayFabRequestCommon where TResult : PlayFabResultCommon
        {
            try
            {
#if PLAYFAB_REQUEST_TIMING
                reqContainer.Timing.WorkerRequestMs = (int)reqContainer.Stopwatch.ElapsedMilliseconds;
#endif

                if (reqContainer.Response == null)
                {
                    reqContainer.Response = (HttpWebResponse)reqContainer.Request.GetResponse();
                }

                //Check for an Okay Response.
                if (reqContainer.Response.StatusCode == HttpStatusCode.OK)
                {
                    reqContainer.JsonResponse = ResponseToString(reqContainer.Response);
                }

                if (reqContainer.Response.StatusCode != HttpStatusCode.OK || string.IsNullOrEmpty(reqContainer.JsonResponse))
                {
                    //Throw Friendly PF Error.
                    if (errorCallback != null)
                    {
                        var message = string.IsNullOrEmpty(reqContainer.JsonResponse)
                            ? "Internal Server Error"
                            : reqContainer.JsonResponse;
                        var playFabError = PlayFabHttp.GeneratePlayFabError(message, reqContainer.CustomData);
                        lock (ResultQueue)
                        {
                            //Queue The result callbacks to run on the main thread.
                            ResultQueue.Enqueue(() =>
                            {
                                PlayFabHttp.SendErrorEvent(request, playFabError);
                                errorCallback(playFabError);
                            });
                        }
                        reqContainer.State = HttpRequestState.Error;
                        return;
                    }
                }
                else
                {
                    //Response Recieved Successfully, now process.
                    reqContainer.ProcessJsonAction = () =>
                    {
                        ProcessJsonResponse(reqContainer, request, callBack, errorCallback);
                    };
                }

                reqContainer.State = HttpRequestState.Received;

            }
            catch (Exception e)
            {
                Debug.LogException(e);
                reqContainer.State = HttpRequestState.Error;
            }
        }

        public void ProcessJsonResponse<TRequest, TResult>(CallRequestContainer reqContainer, TRequest request,
            Action<TResult> callBack, Action<PlayFabError> errorCallback)
            where TRequest : PlayFabRequestCommon where TResult : PlayFabResultCommon
        {
            try
            {
                var httpResult = JsonWrapper.DeserializeObject<PlayFabHttp.HttpResponseObject>(reqContainer.JsonResponse,
                    PlayFabUtil.ApiSerializerStrategy);


#if PLAYFAB_REQUEST_TIMING
                reqContainer.Timing.WorkerRequestMs = (int)reqContainer.Stopwatch.ElapsedMilliseconds;
#endif

                //This would happen if playfab returned a 500 internal server error or a bad json response.
                if (httpResult == null)
                {
                    if (errorCallback != null)
                    {
                        //TODO: this may need to be adjusted if the response is ugly.
                        var playFabError = PlayFabHttp.GeneratePlayFabErrorGeneric(reqContainer.JsonResponse, null, reqContainer.CustomData);
                        //Queue The result callbacks to run on the main thread.
                        lock (ResultQueue)
                        {
                            ResultQueue.Enqueue(() =>
                            {
                                PlayFabHttp.SendErrorEvent(request, playFabError);
                                errorCallback(playFabError);
                            });
                        }
                        reqContainer.State = HttpRequestState.Error;
                    }
                    return;
                }

                if (httpResult.code != 200)
                {
                    if (errorCallback != null)
                    {
                        var playFabError = PlayFabHttp.GeneratePlayFabError(reqContainer.JsonResponse, reqContainer.CustomData);
                        //Queue The result callbacks to run on the main thread.
                        lock (ResultQueue)
                        {
                            ResultQueue.Enqueue(() =>
                            {
                                PlayFabHttp.SendErrorEvent(request, playFabError);
                                errorCallback(playFabError);
                            });
                        }
                        reqContainer.State = HttpRequestState.Error;
                    }
                    return;
                }

                var dataJson = JsonWrapper.SerializeObject(httpResult.data, PlayFabUtil.ApiSerializerStrategy);
                var result = JsonWrapper.DeserializeObject<TResult>(dataJson, PlayFabUtil.ApiSerializerStrategy);

                result.Request = request;
                result.CustomData = reqContainer.CustomData;

#if !DISABLE_PLAYFABCLIENT_API
                UserSettings userSettings = null;
                var res = result as LoginResult;
                var regRes = result as RegisterPlayFabUserResult;
                if (res != null)
                {
                    userSettings = res.SettingsForUser;
                    AuthKey = res.SessionTicket;
                }
                else if (regRes != null)
                {
                    userSettings = res.SettingsForUser;
                    AuthKey = regRes.SessionTicket;
                }

                if (userSettings != null)
                {
                    AuthKey = res.SessionTicket;
                    #region Track IDFA

#if !DISABLE_IDFA
#if UNITY_IOS || UNITY_ANDROID
                    if (userSettings.NeedsAttribution)
                    {
                        ResultQueue.Enqueue(() =>
                        {
                            Application.RequestAdvertisingIdentifierAsync(
                                (advertisingId, trackingEnabled, error) =>
                                {
                                    if (trackingEnabled)
                                    {
                                        var attribRequest = new AttributeInstallRequest();
#if UNITY_ANDROID
                                        attribRequest.Android_Id = advertisingId;
#elif UNITY_IOS
                                        attribRequest.Idfa = advertisingId;
#endif
                                        PlayFabClientAPI.AttributeInstall(attribRequest, (attribResult) =>
                                        {
                                            //This is for internal testing tools.
                                            PlayFabSettings.AdvertisingIdType += "_Successful";
                                        }, null);
                                    }
                                });
                        });
                    }
#endif
#endif

                    #endregion
                }

                var cloudScriptUrl = result as GetCloudScriptUrlResult;
                if (cloudScriptUrl != null)
                {
                    PlayFabSettings.LogicServerUrl = cloudScriptUrl.Url;
                }
#endif
                if (callBack != null)
                {
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
                                PlayFabHttp.SendEvent(request, result, ApiProcessingEventType.Post);
                                callBack(result);
                            }
                            catch (Exception e)
                            {
                                Debug.LogException(e);
                            }
                        });
                    }
                }

            }
            catch (Exception e)
            {
                Debug.LogException(e);
                reqContainer.State = HttpRequestState.Error;
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
                finishedRequest.Invoke();
            }
        }

        public static string ResponseToString(HttpWebResponse webResponse)
        {
            try
            {
                using (var responseStream = webResponse.GetResponseStream())
                {
                    if (responseStream == null)
                        return null;
                    using (var stream = new System.IO.StreamReader(responseStream))
                    {
                        return stream.ReadToEnd();
                    }
                }

            }
            catch (WebException e)
            {
                using (var responseStream = e.Response.GetResponseStream())
                {
                    if (responseStream == null)
                        return null;
                    using (var stream = new System.IO.StreamReader(responseStream))
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

        public int GetPendingMessages()
        {
            int count = 0;
            lock (ActiveRequests)
                count += ActiveRequests.Count + _activeCallCount;
            lock (ResultQueue)
                count += ResultQueue.Count;
            return count;
        }

        public enum HttpRequestState
        {
            Sent,
            Received,
            Idle,
            Error
        }

        public class CallRequestContainer
        {
            // This class stores the State of the request.
            public HttpRequestState State;
            public HttpWebRequest Request;
            public HttpWebResponse Response;
            public string Payload;
            public string JsonResponse;
            public Action ProcessPostAction;
            public Action ProcessResponseAction;
            public Action ProcessJsonAction;
            public int RetryTimeoutCounter = 0;
            public object CustomData;

#if PLAYFAB_REQUEST_TIMING
            public PlayFabHttp.RequestTiming Timing;
            public System.Diagnostics.Stopwatch Stopwatch;
#endif

            public CallRequestContainer()
            {
                State = HttpRequestState.Idle;
                Request = null;
                Response = null;
                Payload = string.Empty;
                JsonResponse = string.Empty;
                CustomData = new object();
#if PLAYFAB_REQUEST_TIMING
                Stopwatch = System.Diagnostics.Stopwatch.StartNew();
#endif
            }
        }
    }
}

#endif
