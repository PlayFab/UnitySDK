using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PlayFab.AuthenticationModels;
using PlayFab.ClientModels;
using PlayFab.Json;
using PlayFab.Public;
using PlayFab.SharedModels;
using UnityEngine;

namespace PlayFab.Internal
{
    /// <summary>
    /// This is a wrapper for Http So we can better separate the functionaity of Http Requests delegated to WWW or HttpWebRequest
    /// </summary>
    public class PlayFabHttp : SingletonMonoBehaviour<PlayFabHttp>
    {
        private static List<CallRequestContainer> _apiCallQueue = new List<CallRequestContainer>(); // Starts initialized, and is nulled when it's flushed

        public delegate void ApiProcessingEvent<in TEventArgs>(TEventArgs e);
        public delegate void ApiProcessErrorEvent(PlayFabRequestCommon request, PlayFabError error);
        public static event ApiProcessingEvent<ApiProcessingEventArgs> ApiProcessingEventHandler;
        public static event ApiProcessErrorEvent ApiProcessingErrorEventHandler;
        public static readonly Dictionary<string, string> GlobalHeaderInjection = new Dictionary<string, string>();

#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
        private static IPlayFabSignalR _internalSignalR;
#endif

        private static IPlayFabLogger _logger;
#if !DISABLE_PLAYFABENTITY_API && !DISABLE_PLAYFABCLIENT_API
        private static IScreenTimeTracker screenTimeTracker = new ScreenTimeTracker();
        private const float delayBetweenBatches = 5.0f;
#endif

#if PLAYFAB_REQUEST_TIMING
        public struct RequestTiming
        {
            public DateTime StartTimeUtc;
            public string ApiEndpoint;
            public int WorkerRequestMs;
            public int MainThreadRequestMs;
        }

        public delegate void ApiRequestTimingEvent(RequestTiming time);
        public static event ApiRequestTimingEvent ApiRequestTimingEventHandler;
#endif

        /// <summary>
        /// Return the number of api calls that are waiting for results from the server
        /// </summary>
        /// <returns></returns>
        public static int GetPendingMessages()
        {
            var transport = PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport);
            return transport.IsInitialized ? transport.GetPendingMessages() : 0;
        }

        /// <summary>
        /// Optional redirect to allow mocking of transport calls, or use a custom transport utility
        /// </summary>
        [Obsolete("This method is deprecated, please use PlayFab.PluginManager.SetPlugin(..) instead.", false)]
        public static void SetHttp<THttpObject>(THttpObject httpObj) where THttpObject : ITransportPlugin
        {
            PluginManager.SetPlugin(httpObj, PluginContract.PlayFab_Transport);
        }

        /// <summary>
        /// Optional redirect to allow mocking of AuthKey
        /// </summary>
        /// <param name="authKey"></param>
        [Obsolete("This method is deprecated, please use PlayFab.IPlayFabTransportPlugin.AuthKey property instead.", false)]
        public static void SetAuthKey(string authKey)
        {
            PluginManager.GetPlugin<IPlayFabTransportPlugin>(PluginContract.PlayFab_Transport).AuthKey = authKey;
        }

        /// <summary>
        /// This initializes the GameObject and ensures it is in the scene.
        /// </summary>
        public static void InitializeHttp()
        {
            if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
                throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "You must set PlayFabSettings.TitleId before making API Calls.");
            var transport = PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport);
            if (transport.IsInitialized)
                return;

            Application.runInBackground = true; // Http requests respond even if you lose focus

            transport.Initialize();
            CreateInstance(); // Invoke the SingletonMonoBehaviour
        }

        /// <summary>
        /// This initializes the GameObject and ensures it is in the scene.
        /// </summary>
        public static void InitializeLogger(IPlayFabLogger setLogger = null)
        {
            if (_logger != null)
                throw new InvalidOperationException("Once initialized, the logger cannot be reset.");
            if (setLogger == null)
                setLogger = new PlayFabLogger();
            _logger = setLogger;
        }

#if !DISABLE_PLAYFABENTITY_API && !DISABLE_PLAYFABCLIENT_API
        /// <summary>
        /// This initializes ScreenTimeTracker object and notifying it to start sending info.
        /// </summary>
        /// <param name="playFabUserId">Result of the user's login, represent user ID</param>
        public static void InitializeScreenTimeTracker(string entityId, string entityType, string playFabUserId)
        {
            screenTimeTracker.ClientSessionStart(entityId, entityType, playFabUserId);
            instance.StartCoroutine(SendScreenTimeEvents(delayBetweenBatches));
        }

        /// <summary>
        /// This function will send Screen Time events on a periodic basis.
        /// </summary>
        /// <param name="secondsBetweenBatches">Delay between batches, in seconds</param>
        private static IEnumerator SendScreenTimeEvents(float secondsBetweenBatches)
        {
            WaitForSeconds delay = new WaitForSeconds(secondsBetweenBatches);

            while (!PlayFabSettings.DisableFocusTimeCollection)
            {
                screenTimeTracker.Send();
                yield return delay;
            }
        }
#endif

#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
        public static void InitializeSignalR(string baseUrl, string hubName, Action onConnected, Action<string>onReceived, Action onReconnected, Action onDisconnected, Action<Exception> onError)
        {
            CreateInstance();
            if (_internalSignalR != null) return;
            _internalSignalR = new PlayFabSignalR (onConnected);
            _internalSignalR.OnReceived += onReceived;
            _internalSignalR.OnReconnected += onReconnected;
            _internalSignalR.OnDisconnected += onDisconnected;
            _internalSignalR.OnError += onError;

            _internalSignalR.Start(baseUrl, hubName);
        }

        public static void SubscribeSignalR(string onInvoked, Action<object[]> callbacks)
        {
            _internalSignalR.Subscribe(onInvoked, callbacks);
        }

        public static void InvokeSignalR(string methodName, Action callback, params object[] args)
        {
            _internalSignalR.Invoke(methodName, callback, args);
        }

        public static void StopSignalR()
        {
            _internalSignalR.Stop();
        }
#endif

        public static void SimpleGetCall(string fullUrl, Action<byte[]> successCallback, Action<string> errorCallback)
        {
            InitializeHttp();
            PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport).SimpleGetCall(fullUrl, successCallback, errorCallback);
        }


        public static void SimplePutCall(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
        {
            InitializeHttp();
            PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport).SimplePutCall(fullUrl, payload, successCallback, errorCallback);
        }

        public static void SimplePostCall(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
        {
            InitializeHttp();
            PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport).SimplePostCall(fullUrl, payload, successCallback, errorCallback);
        }

        protected internal static void MakeApiCall<TResult>(string apiEndpoint,
            PlayFabRequestCommon request, AuthType authType, Action<TResult> resultCallback,
            Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null, bool allowQueueing = false, PlayFabAuthenticationContext authenticationContext = null, PlayFabApiSettings apiSettings = null)
            where TResult : PlayFabResultCommon
        {
            var fullUrl = apiSettings == null ?  PlayFabSettings.GetFullUrl(apiEndpoint, PlayFabSettings.RequestGetParams) : apiSettings.GetFullUrl(apiEndpoint, apiSettings.RequestGetParams);
            _MakeApiCall(apiEndpoint, fullUrl, request, authType, resultCallback, errorCallback, customData, extraHeaders, allowQueueing, authenticationContext, apiSettings);
        }

        protected internal static void MakeApiCallWithFullUri<TResult>(string fullUri,
            PlayFabRequestCommon request, AuthType authType, Action<TResult> resultCallback,
            Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null, bool allowQueueing = false, PlayFabAuthenticationContext authenticationContext = null, PlayFabApiSettings apiSettings = null)
            where TResult : PlayFabResultCommon
        {
            // This will not be called if environment file does not exist or does not contain property the debugging URI
            _MakeApiCall(null, fullUri, request, authType, resultCallback, errorCallback, customData, extraHeaders, allowQueueing, authenticationContext, apiSettings);
        }

        /// <summary>
        /// Internal method for Make API Calls
        /// </summary>
        private static void _MakeApiCall<TResult>(string apiEndpoint, string fullUrl,
            PlayFabRequestCommon request, AuthType authType, Action<TResult> resultCallback,
            Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null, bool allowQueueing = false, PlayFabAuthenticationContext authenticationContext = null, PlayFabApiSettings apiSettings = null)
            where TResult : PlayFabResultCommon
        {
            InitializeHttp();
            SendEvent(apiEndpoint, request, null, ApiProcessingEventType.Pre);

            string developerSecretKey = null;
            #if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API
                if(request.AuthenticationContext != null && !string.IsNullOrEmpty(request.AuthenticationContext.DeveloperSecretKey))
                {
                    developerSecretKey = request.AuthenticationContext.DeveloperSecretKey;
                }
                if(developerSecretKey == null && authenticationContext != null && !string.IsNullOrEmpty(authenticationContext.DeveloperSecretKey))
                {
                    developerSecretKey = authenticationContext.DeveloperSecretKey;
                }
                if(developerSecretKey == null)
                {
                    developerSecretKey = PlayFabSettings.DeveloperSecretKey;
                }

                if (developerSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet,"DeveloperSecretKey is not found in Request, Server Instance or PlayFabSettings");
            #endif

            var serializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
            var reqContainer = new CallRequestContainer
            {
                ApiEndpoint = apiEndpoint,
                FullUrl = fullUrl,
                CustomData = customData,
                Payload = Encoding.UTF8.GetBytes(serializer.SerializeObject(request)),
                ApiRequest = request,
                ErrorCallback = errorCallback,
                RequestHeaders = extraHeaders ?? new Dictionary<string, string>() // Use any headers provided by the customer
            };
            // Append any additional headers
            foreach (var pair in GlobalHeaderInjection)
                if (!reqContainer.RequestHeaders.ContainsKey(pair.Key))
                    reqContainer.RequestHeaders[pair.Key] = pair.Value;

#if PLAYFAB_REQUEST_TIMING
            reqContainer.Timing.StartTimeUtc = DateTime.UtcNow;
            reqContainer.Timing.ApiEndpoint = apiEndpoint;
#endif

            // Add PlayFab Headers
            var transport = PluginManager.GetPlugin<IPlayFabTransportPlugin>(PluginContract.PlayFab_Transport);
            reqContainer.RequestHeaders["X-ReportErrorAsSuccess"] = "true"; // Makes processing PlayFab errors a little easier
            reqContainer.RequestHeaders["X-PlayFabSDK"] = PlayFabSettings.VersionString; // Tell PlayFab which SDK this is
            switch (authType)
            {
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || UNITY_EDITOR
                case AuthType.DevSecretKey: reqContainer.RequestHeaders["X-SecretKey"] = developerSecretKey;  break;
#endif
                case AuthType.LoginSession:
#if !DISABLE_PLAYFABCLIENT_API
                    var clientSessionTicket = request.AuthenticationContext != null && request.AuthenticationContext.ClientSessionTicket != null
                        ? request.AuthenticationContext.ClientSessionTicket : (authenticationContext != null && authenticationContext.ClientSessionTicket != null ? authenticationContext.ClientSessionTicket : transport.AuthKey);
                    reqContainer.RequestHeaders["X-Authorization"] = clientSessionTicket;
#else
                    reqContainer.RequestHeaders["X-Authorization"] = transport.AuthKey;
#endif
                    break;
                case AuthType.EntityToken:
#if !DISABLE_PLAYFABENTITY_API
                    var entityToken = request.AuthenticationContext != null && request.AuthenticationContext.EntityToken != null
                        ? request.AuthenticationContext.EntityToken : (authenticationContext != null && authenticationContext.EntityToken != null ? authenticationContext.EntityToken : transport.EntityToken);
                    reqContainer.RequestHeaders["X-EntityToken"] = entityToken;
#else
                    reqContainer.RequestHeaders["X-EntityToken"] = transport.EntityToken;
#endif
                    break;
            }

            // These closures preserve the TResult generic information in a way that's safe for all the devices
            reqContainer.DeserializeResultJson = () =>
            {
                reqContainer.ApiResult = serializer.DeserializeObject<TResult>(reqContainer.JsonResponse);
            };
            reqContainer.InvokeSuccessCallback = () =>
            {
                if (resultCallback != null)
                {
                    resultCallback((TResult)reqContainer.ApiResult);
                }
            };

            if (allowQueueing && _apiCallQueue != null)
            {
                for (var i = _apiCallQueue.Count - 1; i >= 0; i--)
                    if (_apiCallQueue[i].ApiEndpoint == apiEndpoint)
                        _apiCallQueue.RemoveAt(i);
                _apiCallQueue.Add(reqContainer);
            }
            else
            {
                transport.MakeApiCall(reqContainer);
            }
        }

        /// <summary>
        /// Internal code shared by IPlayFabHTTP implementations
        /// </summary>
        internal void OnPlayFabApiResult(PlayFabResultCommon result)
        {
#if !DISABLE_PLAYFABENTITY_API
            var entRes = result as AuthenticationModels.GetEntityTokenResponse;
            if (entRes != null)
            {
                var transport = PluginManager.GetPlugin<IPlayFabTransportPlugin>(PluginContract.PlayFab_Transport);
                transport.EntityToken = entRes.EntityToken;
            }
#endif
#if !DISABLE_PLAYFABCLIENT_API
            var logRes = result as ClientModels.LoginResult;
            var regRes = result as ClientModels.RegisterPlayFabUserResult;
            if (logRes != null)
            {
                var transport = PluginManager.GetPlugin<IPlayFabTransportPlugin>(PluginContract.PlayFab_Transport);
                transport.AuthKey = logRes.SessionTicket;
                if (logRes.EntityToken != null)
                    transport.EntityToken = logRes.EntityToken.EntityToken;
                logRes.AuthenticationContext = new PlayFabAuthenticationContext(transport.AuthKey, transport.EntityToken, logRes.PlayFabId);
            }
            else if (regRes != null)
            {
                var transport = PluginManager.GetPlugin<IPlayFabTransportPlugin>(PluginContract.PlayFab_Transport);
                transport.AuthKey = regRes.SessionTicket;
                if (regRes.EntityToken != null)
                    transport.EntityToken = regRes.EntityToken.EntityToken;
                regRes.AuthenticationContext = new PlayFabAuthenticationContext(transport.AuthKey, transport.EntityToken, regRes.PlayFabId);
            }
#endif
        }

        /// <summary>
        /// MonoBehaviour OnEnable Method
        /// </summary>
        private void OnEnable()
        {
            if (_logger != null)
            {
                _logger.OnEnable();
            }

#if !DISABLE_PLAYFABENTITY_API && !DISABLE_PLAYFABCLIENT_API
            if ((screenTimeTracker != null) && !PlayFabSettings.DisableFocusTimeCollection)
            {
                screenTimeTracker.OnEnable();
            }
#endif
        }

        /// <summary>
        /// MonoBehaviour OnDisable
        /// </summary>
        private void OnDisable()
        {
            if (_logger != null)
            {
                _logger.OnDisable();
            }

#if !DISABLE_PLAYFABENTITY_API && !DISABLE_PLAYFABCLIENT_API
            if ((screenTimeTracker != null) && !PlayFabSettings.DisableFocusTimeCollection)
            {
                screenTimeTracker.OnDisable();
            }
#endif
        }

        /// <summary>
        /// MonoBehaviour OnDestroy
        /// </summary>
        private void OnDestroy()
        {
            var transport = PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport);
            if (transport.IsInitialized)
            {
                transport.OnDestroy();
            }
#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
            if (_internalSignalR != null)
            {
                _internalSignalR.Stop();
            }
#endif
            if (_logger != null)
            {
                _logger.OnDestroy();
            }

#if !DISABLE_PLAYFABENTITY_API && !DISABLE_PLAYFABCLIENT_API
            if ((screenTimeTracker != null) && !PlayFabSettings.DisableFocusTimeCollection)
            {
                screenTimeTracker.OnDestroy();
            }
#endif
        }

        /// <summary>
        /// MonoBehaviour OnApplicationFocus
        /// </summary>
        public void OnApplicationFocus(bool isFocused)
        {
#if !DISABLE_PLAYFABENTITY_API && !DISABLE_PLAYFABCLIENT_API
            if ((screenTimeTracker != null) && !PlayFabSettings.DisableFocusTimeCollection)
            {
                screenTimeTracker.OnApplicationFocus(isFocused);
            }
#endif
        }

        /// <summary>
        /// MonoBehaviour OnApplicationQuit
        /// </summary>
        public void OnApplicationQuit()
        {
#if !DISABLE_PLAYFABENTITY_API && !DISABLE_PLAYFABCLIENT_API
            if ((screenTimeTracker != null) && !PlayFabSettings.DisableFocusTimeCollection)
            {
                screenTimeTracker.OnApplicationQuit();
            }
#endif
        }

        /// <summary>
        /// MonoBehaviour Update
        /// </summary>
        private void Update()
        {
            var transport = PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport);
            if (transport.IsInitialized)
            {
                if (_apiCallQueue != null)
                {
                    foreach (var eachRequest in _apiCallQueue)
                        transport.MakeApiCall(eachRequest); // Flush the queue
                    _apiCallQueue = null; // null this after it's flushed
                }
                transport.Update();
            }

#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
            if (_internalSignalR != null)
            {
                _internalSignalR.Update();
            }
#endif
#if NET_4_6
            while (_injectedCoroutines.Count > 0)
                StartCoroutine(_injectedCoroutines.Dequeue());

            while (_injectedAction.Count > 0)
                _injectedAction.Dequeue()?.Invoke();
#endif
        }

        #region Helpers
        public static bool IsClientLoggedIn()
        {
            var transport = PluginManager.GetPlugin<IPlayFabTransportPlugin>(PluginContract.PlayFab_Transport);
            return transport.IsInitialized && !string.IsNullOrEmpty(transport.AuthKey);
        }

        public static void ForgetAllCredentials()
        {
            var transport = PluginManager.GetPlugin<IPlayFabTransportPlugin>(PluginContract.PlayFab_Transport);
            if (transport.IsInitialized)
            {
                transport.AuthKey = null;
                transport.EntityToken = null;
            }
        }

        protected internal static PlayFabError GeneratePlayFabError(string apiEndpoint, string json, object customData)
        {
            JsonObject errorDict = null;
            Dictionary<string, List<string>> errorDetails = null;
            var serializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
            try
            {
                // Deserialize the error
                errorDict = serializer.DeserializeObject<JsonObject>(json);
            }
            catch (Exception) { /* Unusual, but shouldn't actually matter */ }
            try
            {
                object errorDetailsString;
                if (errorDict != null && errorDict.TryGetValue("errorDetails", out errorDetailsString))
                    errorDetails = serializer.DeserializeObject<Dictionary<string, List<string>>>(errorDetailsString.ToString());
            }
            catch (Exception) { /* Unusual, but shouldn't actually matter */ }

            return new PlayFabError
            {
                ApiEndpoint = apiEndpoint,
                HttpCode = errorDict != null && errorDict.ContainsKey("code") ? Convert.ToInt32(errorDict["code"]) : 400,
                HttpStatus = errorDict != null && errorDict.ContainsKey("status") ? (string)errorDict["status"] : "BadRequest",
                Error = errorDict != null && errorDict.ContainsKey("errorCode") ? (PlayFabErrorCode)Convert.ToInt32(errorDict["errorCode"]) : PlayFabErrorCode.ServiceUnavailable,
                ErrorMessage = errorDict != null && errorDict.ContainsKey("errorMessage") ? (string)errorDict["errorMessage"] : json,
                ErrorDetails = errorDetails,
                CustomData = customData
            };
        }

        protected internal static void SendErrorEvent(PlayFabRequestCommon request, PlayFabError error)
        {
            if (ApiProcessingErrorEventHandler == null)
                return;

            try
            {
                ApiProcessingErrorEventHandler(request, error);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        protected internal static void SendEvent(string apiEndpoint, PlayFabRequestCommon request, PlayFabResultCommon result, ApiProcessingEventType eventType)
        {
            if (ApiProcessingEventHandler == null)
                return;
            try
            {
                ApiProcessingEventHandler(new ApiProcessingEventArgs
                {
                    ApiEndpoint = apiEndpoint,
                    EventType = eventType,
                    Request = request,
                    Result = result
                });
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        protected internal static void ClearAllEvents()
        {
            ApiProcessingEventHandler = null;
            ApiProcessingErrorEventHandler = null;
        }

#if PLAYFAB_REQUEST_TIMING
        protected internal static void SendRequestTiming(RequestTiming rt) {
            if (ApiRequestTimingEventHandler != null) {
                ApiRequestTimingEventHandler(rt);
            }
        }
#endif
        #endregion
#if NET_4_6
        private readonly Queue<IEnumerator> _injectedCoroutines = new Queue<IEnumerator>();
        private readonly Queue<Action> _injectedAction = new Queue<Action>();

        public void InjectInUnityThread(IEnumerator x) => _injectedCoroutines.Enqueue(x);
        public void InjectInUnityThread(Action action) => _injectedAction.Enqueue(action);
#endif
	}

    #region Event Classes
    public enum ApiProcessingEventType
    {
        Pre,
        Post
    }

    public class ApiProcessingEventArgs
    {
        public string ApiEndpoint;
        public ApiProcessingEventType EventType;
        public PlayFabRequestCommon Request;
        public PlayFabResultCommon Result;

        public TRequest GetRequest<TRequest>() where TRequest : PlayFabRequestCommon
        {
            return Request as TRequest;
        }
    }
    #endregion
}
