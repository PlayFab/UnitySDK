using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
            Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null, PlayFabAuthenticationContext authenticationContext = null, PlayFabApiSettings apiSettings = null, IPlayFabInstanceApi instanceApi = null)
            where TResult : PlayFabResultCommon
        {
            apiSettings = apiSettings ?? PlayFabSettings.staticSettings;
            var fullUrl = apiSettings.GetFullUrl(apiEndpoint, apiSettings.RequestGetParams);
            _MakeApiCall(apiEndpoint, fullUrl, request, authType, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, apiSettings, instanceApi);
        }

        protected internal static void MakeApiCallWithFullUri<TResult>(string fullUri,
            PlayFabRequestCommon request, AuthType authType, Action<TResult> resultCallback,
            Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null, PlayFabAuthenticationContext authenticationContext = null, PlayFabApiSettings apiSettings = null, IPlayFabInstanceApi instanceApi = null)
            where TResult : PlayFabResultCommon
        {
            apiSettings = apiSettings ?? PlayFabSettings.staticSettings;
            // This will not be called if environment file does not exist or does not contain property the debugging URI
            _MakeApiCall(null, fullUri, request, authType, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, apiSettings, instanceApi);
        }

        /// <summary>
        /// Internal method for Make API Calls
        /// </summary>
        private static void _MakeApiCall<TResult>(string apiEndpoint, string fullUrl,
            PlayFabRequestCommon request, AuthType authType, Action<TResult> resultCallback,
            Action<PlayFabError> errorCallback, object customData, Dictionary<string, string> extraHeaders, bool allowQueueing, PlayFabAuthenticationContext authenticationContext, PlayFabApiSettings apiSettings, IPlayFabInstanceApi instanceApi)
            where TResult : PlayFabResultCommon
        {
            InitializeHttp();
            SendEvent(apiEndpoint, request, null, ApiProcessingEventType.Pre);

            var serializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
            var reqContainer = new CallRequestContainer
            {
                ApiEndpoint = apiEndpoint,
                FullUrl = fullUrl,
                settings = apiSettings,
                context = authenticationContext,
                CustomData = customData,
                Payload = Encoding.UTF8.GetBytes(serializer.SerializeObject(request)),
                ApiRequest = request,
                ErrorCallback = errorCallback,
                RequestHeaders = extraHeaders ?? new Dictionary<string, string>(), // Use any headers provided by the customer
                instanceApi = instanceApi
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
            var transport = PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport);
            reqContainer.RequestHeaders["X-ReportErrorAsSuccess"] = "true"; // Makes processing PlayFab errors a little easier
            reqContainer.RequestHeaders["X-PlayFabSDK"] = PlayFabSettings.VersionString; // Tell PlayFab which SDK this is
            switch (authType)
            {
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || UNITY_EDITOR
                case AuthType.DevSecretKey:
                    if (apiSettings.DeveloperSecretKey == null) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "DeveloperSecretKey is not found in Request, Server Instance or PlayFabSettings");
                    reqContainer.RequestHeaders["X-SecretKey"] = apiSettings.DeveloperSecretKey; break;
#endif
#if !DISABLE_PLAYFABCLIENT_API
                case AuthType.LoginSession:
                    if (authenticationContext != null)
                        reqContainer.RequestHeaders["X-Authorization"] = authenticationContext.ClientSessionTicket;
                    break;
#endif
#if !DISABLE_PLAYFABENTITY_API
                case AuthType.EntityToken:
                    if (authenticationContext != null)
                        reqContainer.RequestHeaders["X-EntityToken"] = authenticationContext.EntityToken;
                    break;
#endif
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
        internal void OnPlayFabApiResult(CallRequestContainer reqContainer)
        {
            var result = reqContainer.ApiResult;

#if !DISABLE_PLAYFABENTITY_API
            var entRes = result as AuthenticationModels.GetEntityTokenResponse;
            if (entRes != null)
            {
                PlayFabSettings.staticPlayer.EntityToken = entRes.EntityToken;
            }
#endif
#if !DISABLE_PLAYFABCLIENT_API
            var logRes = result as ClientModels.LoginResult;
            var regRes = result as ClientModels.RegisterPlayFabUserResult;
            if (logRes != null)
            {
                logRes.AuthenticationContext = new PlayFabAuthenticationContext(logRes.SessionTicket, logRes.EntityToken.EntityToken, logRes.PlayFabId);
                if (reqContainer.context != null)
                {
                    reqContainer.context.ClientSessionTicket = logRes.SessionTicket;
                    reqContainer.context.EntityToken = logRes.EntityToken.EntityToken;
                }
            }
            else if (regRes != null)
            {
                regRes.AuthenticationContext = new PlayFabAuthenticationContext(regRes.SessionTicket, regRes.EntityToken.EntityToken, regRes.PlayFabId);
                if (reqContainer.context != null)
                {
                    reqContainer.context.ClientSessionTicket = regRes.SessionTicket;
                    reqContainer.context.EntityToken = regRes.EntityToken.EntityToken;
                }
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

            while (_injectedCoroutines.Count > 0)
                StartCoroutine(_injectedCoroutines.Dequeue());

            while (_injectedAction.Count > 0)
            {
                var action = _injectedAction.Dequeue();
                if (action != null)
                {
                    action.Invoke();
                }
            }
        }

        #region Helpers
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
        protected internal static void SendRequestTiming(RequestTiming rt)
        {
            if (ApiRequestTimingEventHandler != null)
            {
                ApiRequestTimingEventHandler(rt);
            }
        }
#endif
#endregion
        private readonly Queue<IEnumerator> _injectedCoroutines = new Queue<IEnumerator>();
        private readonly Queue<Action> _injectedAction = new Queue<Action>();

        public void InjectInUnityThread(IEnumerator x)
        {
            _injectedCoroutines.Enqueue(x);
        }

        public void InjectInUnityThread(Action action)
        {
            _injectedAction.Enqueue(action);
        }
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
