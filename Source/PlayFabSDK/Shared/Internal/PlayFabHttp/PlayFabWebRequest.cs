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
    public class PlayFabWebRequest : ITransportPlugin
    {
        /// <summary>
        /// Disable encryption certificate validation within PlayFabWebRequest using this request.
        /// This is not generally recommended.
        /// As of early 2018:
        ///   None of the built-in Unity mechanisms validate the certificate, using .Net 3.5 equivalent runtime
        ///   It is also not currently feasible to provide a single cross platform solution that will correctly validate a certificate.
        /// The Risk:
        ///   All Unity HTTPS mechanisms are vulnerable to Man-In-The-Middle attacks.
        ///   The only more-secure option is to define a custom CustomCertValidationHook, specifically tailored to the platforms you support,
        ///   which validate the cert based on a list of trusted certificate providers. This list of providers must be able to update itself, as the
        ///   base certificates for those providers will also expire and need updating on a regular basis.
        /// </summary>
        public static void SkipCertificateValidation()
        {
            var rcvc = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications); //(sender, cert, chain, ssl) => true
            ServicePointManager.ServerCertificateValidationCallback = rcvc;
            certValidationSet = true;
        }

        /// <summary>
        /// Provide PlayFabWebRequest with a custom ServerCertificateValidationCallback which can be used to validate the PlayFab encryption certificate.
        /// Please do not:
        ///   - Hard code the current PlayFab certificate information - The PlayFab certificate updates itself on a regular schedule, and your game will fail and require a republish to fix
        ///   - Hard code a list of static certificate authorities - Any single exported list of certificate authorities will become out of date, and have the same problem when the CA cert expires
        /// Real solution:
        ///   - A mechanism where a valid certificate authority list can be securely downloaded and updated without republishing the client when existing certificates expire.
        /// </summary>
        public static System.Net.Security.RemoteCertificateValidationCallback CustomCertValidationHook
        {
            set
            {
                ServicePointManager.ServerCertificateValidationCallback = value;
                certValidationSet = true;
            }
        }

        private static readonly Queue<Action> ResultQueueTransferThread = new Queue<Action>();
        private static readonly Queue<Action> ResultQueueMainThread = new Queue<Action>();
        private static readonly List<CallRequestContainer> ActiveRequests = new List<CallRequestContainer>();

        private static bool certValidationSet = false;
        private static Thread _requestQueueThread;
        private static readonly object _ThreadLock = new object();
        private static readonly TimeSpan ThreadKillTimeout = TimeSpan.FromSeconds(60);
        private static DateTime _threadKillTime = DateTime.UtcNow + ThreadKillTimeout; // Kill the thread after 1 minute of inactivity
        private static bool _isApplicationPlaying;
        private static int _activeCallCount;

        private static string _unityVersion;

        private bool _isInitialized = false;

        public bool IsInitialized { get { return _isInitialized; } }

        public void Initialize()
        {
            SetupCertificates();
            _isApplicationPlaying = true;
            _unityVersion = Application.unityVersion;
            _isInitialized = true;
        }

        public void OnDestroy()
        {
            _isApplicationPlaying = false;
            lock (ResultQueueTransferThread)
            {
                ResultQueueTransferThread.Clear();
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

            if (!certValidationSet)
            {
                Debug.LogWarning("PlayFab API calls will likely fail because you have not set up a HttpWebRequest certificate validation mechanism");
                Debug.LogWarning("Please set a validation callback into PlayFab.Internal.PlayFabWebRequest.CustomCertValidationHook, or set PlayFab.Internal.PlayFabWebRequest.SkipCertificateValidation()");
            }
        }

        /// <summary>
        /// This disables certificate validation, if it's been activated by a customer via SkipCertificateValidation()
        /// </summary>
        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public void SimpleGetCall(string fullUrl, Action<byte[]> successCallback, Action<string> errorCallback)
        {
            // This needs to be improved to use a decent thread-pool, but it can be improved invisibly later
            var newThread = new Thread(() => SimpleHttpsWorker("GET", fullUrl, null, successCallback, errorCallback));
            newThread.Start();
        }

        public void SimplePutCall(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
        {
            // This needs to be improved to use a decent thread-pool, but it can be improved invisibly later
            var newThread = new Thread(() => SimpleHttpsWorker("PUT", fullUrl, payload, successCallback, errorCallback));
            newThread.Start();
        }

        public void SimplePostCall(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
        {
            // This needs to be improved to use a decent thread-pool, but it can be improved invisibly later
            var newThread = new Thread(() => SimpleHttpsWorker("POST", fullUrl, payload, successCallback, errorCallback));
            newThread.Start();
        }


        private void SimpleHttpsWorker(string httpMethod, string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
        {
            // This should also use a pooled HttpWebRequest object, but that too can be improved invisibly later
            var httpRequest = (HttpWebRequest)WebRequest.Create(fullUrl);
            httpRequest.UserAgent = "UnityEngine-Unity; Version: " + _unityVersion;
            httpRequest.Method = httpMethod;
            httpRequest.KeepAlive = PlayFabSettings.RequestKeepAlive;
            httpRequest.Timeout = PlayFabSettings.RequestTimeout;
            httpRequest.AllowWriteStreamBuffering = false;
            httpRequest.ReadWriteTimeout = PlayFabSettings.RequestTimeout;

            if (payload != null)
            {
                httpRequest.ContentLength = payload.LongLength;
                using (var stream = httpRequest.GetRequestStream())
                {
                    stream.Write(payload, 0, payload.Length);
                }
            }

            try
            {
                var response = httpRequest.GetResponse();
                byte[] output = null;
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        output = new byte[response.ContentLength];
                        responseStream.Read(output, 0, output.Length);
                    }
                }
                successCallback(output);
            }
            catch (WebException webException)
            {
                try
                {
                    using (var responseStream = webException.Response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var stream = new StreamReader(responseStream))
                                errorCallback(stream.ReadToEnd());
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void MakeApiCall(object reqContainerObj)
        {
            CallRequestContainer reqContainer = (CallRequestContainer)reqContainerObj;
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
            reqContainer.Error = PlayFabHttp.GeneratePlayFabError(reqContainer.ApiEndpoint, reqContainer.JsonResponse, reqContainer.CustomData); // Decode the server-json error
            reqContainer.HttpState = HttpRequestState.Error;
            lock (ResultQueueTransferThread)
            {
                //Queue The result callbacks to run on the main thread.
                ResultQueueTransferThread.Enqueue(() =>
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
                var serializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
                var httpResult = serializer.DeserializeObject<HttpResponseObject>(reqContainer.JsonResponse);

#if PLAYFAB_REQUEST_TIMING
                reqContainer.Timing.WorkerRequestMs = (int)reqContainer.Stopwatch.ElapsedMilliseconds;
#endif

                //This would happen if playfab returned a 500 internal server error or a bad json response.
                if (httpResult == null || httpResult.code != 200)
                {
                    QueueRequestError(reqContainer);
                    return;
                }

                reqContainer.JsonResponse = serializer.SerializeObject(httpResult.data);
                reqContainer.DeserializeResultJson(); // Assigns Result with a properly typed object
                reqContainer.ApiResult.Request = reqContainer.ApiRequest;
                reqContainer.ApiResult.CustomData = reqContainer.CustomData;

                PlayFabHttp.instance.OnPlayFabApiResult(reqContainer);

#if !DISABLE_PLAYFABCLIENT_API
                lock (ResultQueueTransferThread)
                {
                    ResultQueueTransferThread.Enqueue(() => { PlayFabDeviceUtil.OnPlayFabLogin(reqContainer.ApiResult, reqContainer.settings, reqContainer.instanceApi); });
                }
#endif
                lock (ResultQueueTransferThread)
                {
                    //Queue The result callbacks to run on the main thread.
                    ResultQueueTransferThread.Enqueue(() =>
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
            lock (ResultQueueTransferThread)
            {
                while (ResultQueueTransferThread.Count > 0)
                {
                    var actionToQueue = ResultQueueTransferThread.Dequeue();
                    ResultQueueMainThread.Enqueue(actionToQueue);
                }
            }

            while (ResultQueueMainThread.Count > 0)
            {
                var finishedRequest = ResultQueueMainThread.Dequeue();
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
            lock (ResultQueueTransferThread)
                count += ResultQueueTransferThread.Count;
            return count;
        }
    }
}

#endif
