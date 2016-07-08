#if !UNITY_WSA && !UNITY_WP8
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine;

namespace PlayFab.Internal
{
    internal class PlayFabWebRequest : IPlayFabHttp
    {
        private static Thread _requestQueueThread = null;
        private static TimeSpan _threadKillTimeout = TimeSpan.FromMinutes(1);
        private static DateTime _threadKillTime = DateTime.UtcNow + _threadKillTimeout; // Kill the thread after 1 minute of inactivity
        private static readonly object ThreadLock = new object(); // Lock for modifying _requestQueueThread and/or _threadKillTime
        private static readonly List<CallRequestContainer> PendingRequests = new List<CallRequestContainer>();
        private static readonly Queue<CallRequestContainer> ResultQueue = new Queue<CallRequestContainer>();
        private static int activeCallCount = 0;

        public void Awake()
        {
            SetupCertificates();
        }

        private static void SetupCertificates()
        {
            // These are performance Optimizations for HttpWebRequests.
            ServicePointManager.DefaultConnectionLimit = 10;
            ServicePointManager.Expect100Continue = false;

            //Support for SSL
            var rcvc = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            ServicePointManager.ServerCertificateValidationCallback = rcvc;
        }

        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public int GetPendingMessages()
        {
            int count = 0;
            lock (PendingRequests)
                count += PendingRequests.Count + activeCallCount;
            lock (ResultQueue)
                count += ResultQueue.Count;
            return count;
        }

        public void Post(CallRequestContainer requestContainer)
        {
            lock (PendingRequests)
                PendingRequests.Insert(0, requestContainer);
            // Parsing on this container is done backwards, so insert at 0 to make calls process in roughly queue order (but still not actually guaranteed)
            PlayFabSettings.InvokeRequest(requestContainer.UrlPath, requestContainer.CallId, requestContainer.Request, requestContainer.CustomData);
            _ActivateWorkerThread();
        }

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
                DateTime now = DateTime.UtcNow;
                lock (ThreadLock)
                    _threadKillTime = now + _threadKillTimeout; // Kill the thread after 1 minute of inactivity

                List<CallRequestContainer> localActiveRequests = new List<CallRequestContainer>();
                do
                {
                    // Process active requests
                    lock (PendingRequests)
                    {
                        localActiveRequests.AddRange(PendingRequests);
                        PendingRequests.Clear();
                        activeCallCount = localActiveRequests.Count;
                    }

                    for (int i = activeCallCount - 1; i >= 0; i--)
                    {
                        if (localActiveRequests[i].State == CallRequestContainer.RequestState.RequestSent && !ProcessHttpWebResult(localActiveRequests[i]))
                            continue; // Waiting for request to return, skip it

                        if (localActiveRequests[i].State == CallRequestContainer.RequestState.Unstarted)
                            StartHttpWebRequest(localActiveRequests[i]);
                        else
                        {
                            lock (ResultQueue)
                                ResultQueue.Enqueue(localActiveRequests[i]);
                            localActiveRequests.RemoveAt(i);
                        }
                    }

                    // Check if we've been inactive
                    lock (ThreadLock)
                    {
                        now = DateTime.UtcNow;
                        if (activeCallCount > 0)
                            // Still active, reset the _threadKillTime
                            _threadKillTime = now + _threadKillTimeout;
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
                lock (ThreadLock)
                {
                    _requestQueueThread = null;
                }
            }
        }

        private static void StartHttpWebRequest(CallRequestContainer request)
        {
            try
            {
                string fullUrl = PlayFabSettings.GetFullUrl(request.UrlPath);
                var payload = Encoding.UTF8.GetBytes(request.Data);
                request.HttpRequest = (HttpWebRequest)WebRequest.Create(fullUrl);

                request.HttpRequest.Proxy = null; // Prevents hitting a proxy if no proxy is available. TODO: Add support for proxy's.
                request.HttpRequest.Headers.Add("X-ReportErrorAsSuccess", "true"); // Without this, we have to catch WebException instead, and manually decode the result
                request.HttpRequest.Headers.Add("X-PlayFabSDK", PlayFabSettings.VersionString);
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
                request.Error = PlayFabHttp.GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, errorMessage, request.CustomData);
                request.State = CallRequestContainer.RequestState.Error;
            }
            catch (Exception e)
            {
                Debug.LogException(e); // If it's an unexpected exception, we should log it noisily
                request.Error = PlayFabHttp.GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, e.ToString(), request.CustomData);
                request.State = CallRequestContainer.RequestState.Error;
            }
        }

        private static bool ProcessHttpWebResult(CallRequestContainer request)
        {
            try
            {
                if (!request.HttpRequest.HaveResponse)
                    return false;

                using (HttpWebResponse response = (HttpWebResponse)request.HttpRequest.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        request.ResultStr = ResponseToString(response);
                    }
                    if (response.StatusCode != HttpStatusCode.OK || string.IsNullOrEmpty(request.ResultStr))
                    {
                        request.Error = PlayFabHttp.GeneratePfError(response.StatusCode, PlayFabErrorCode.ServiceUnavailable, "Failed to connect to PlayFab server", request.CustomData);
                    }
                    request.State = CallRequestContainer.RequestState.RequestReceived;
                }
            }
            catch (WebException e)
            {
                Debug.LogException(e); // If it's an unexpected exception, we should log it noisily
                request.Error = PlayFabHttp.GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, e.ToString(), request.CustomData);
                request.State = CallRequestContainer.RequestState.Error;
            }
            catch (Exception e)
            {
                Debug.LogException(e); // If it's an unexpected exception, we should log it noisily
                request.Error = PlayFabHttp.GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, e.ToString(), request.CustomData);
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

        /// <summary>
        /// Unity main-thread requirement for HttpWebRequest callbacks
        /// </summary>
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
    }
}

#endif
