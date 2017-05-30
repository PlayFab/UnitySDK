using PlayFab.Json;
using PlayFab.Public;
using PlayFab.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PlayFab.Internal
{
    /// <summary>
    /// This is a wrapper for Http So we can better separate the functionaity of Http Requests delegated to WWW or HttpWebRequest
    /// </summary>
    public class PlayFabHttp : SingletonMonoBehaviour<PlayFabHttp>
    {
        private static IPlayFabHttp _internalHttp; //This is the default;
        private static List<CallRequestContainer> _apiCallQueue = new List<CallRequestContainer>(); // Starts initialized, and is nulled when it's flushed

        public delegate void ApiProcessingEvent<in TEventArgs>(TEventArgs e);
        public delegate void ApiProcessErrorEvent(PlayFabRequestCommon request, PlayFabError error);
        public static event ApiProcessingEvent<ApiProcessingEventArgs> ApiProcessingEventHandler;
        public static event ApiProcessErrorEvent ApiProcessingErrorEventHandler;

#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
        private static IPlayFabSignalR _internalSignalR;
#endif

        private static IPlayFabLogger _logger;

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
            return _internalHttp == null ? 0 : _internalHttp.GetPendingMessages();
        }

        /// <summary>
        /// Optional redirect to allow mocking of _internalHttp calls, or use a custom _internalHttp utility
        /// </summary>
        public static void SetHttp<THttpObject>(THttpObject httpObj) where THttpObject : IPlayFabHttp
        {
            _internalHttp = httpObj;
        }

        /// <summary>
        /// Optional redirect to allow mocking of AuthKey
        /// </summary>
        /// <param name="authKey"></param>
        public static void SetAuthKey(string authKey)
        {
            _internalHttp.AuthKey = authKey;
        }

        /// <summary>
        /// This initializes the GameObject and ensures it is in the scene.
        /// </summary>
        public static void InitializeHttp()
        {
            if (_internalHttp != null)
                return;

            Application.runInBackground = true; // Http requests respond even if you lose focus
#if !UNITY_WSA && !UNITY_WP8
            if (PlayFabSettings.RequestType == WebRequestType.HttpWebRequest)
                _internalHttp = new PlayFabWebRequest();
#endif
            if (_internalHttp == null)
                _internalHttp = new PlayFabWww();

            _internalHttp.InitializeHttp();
            CreateInstance(); // Invoke the SingletonMonoBehaviour
        }

        /// <summary>
        /// This initializes the GameObject and ensures it is in the scene.
        /// </summary>
        public static void InitializeLogger(IPlayFabLogger setLogger = null)
        {
            if (_logger != null)
                throw new Exception("Once initialized, the logger cannot be reset.");
            if (setLogger == null)
                setLogger = new PlayFabLogger();
            _logger = setLogger;
        }

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

        /// <summary>
        /// Internal method for Make API Calls
        /// </summary>
        protected internal static void MakeApiCall<TResult>(string apiEndpoint,
            PlayFabRequestCommon request, AuthType authType, Action<TResult> resultCallback,
            Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null, bool allowQueueing = false)
            where TResult : PlayFabResultCommon
        {
            InitializeHttp();
            SendEvent(apiEndpoint, request, null, ApiProcessingEventType.Pre);

            var reqContainer = new CallRequestContainer
            {
                ApiEndpoint = apiEndpoint,
                FullUrl = PlayFabSettings.GetFullUrl(apiEndpoint),
                CustomData = customData,
                Payload = Encoding.UTF8.GetBytes(JsonWrapper.SerializeObject(request)),
                ApiRequest = request,
                ErrorCallback = errorCallback,
                RequestHeaders = extraHeaders ?? new Dictionary<string, string>() // Use any headers provided by the customer
            };
#if PLAYFAB_REQUEST_TIMING
            reqContainer.Timing.StartTimeUtc = DateTime.UtcNow;
            reqContainer.Timing.ApiEndpoint = apiEndpoint;
#endif

            // Add PlayFab Headers
            reqContainer.RequestHeaders["X-ReportErrorAsSuccess"] = "true"; // Makes processing PlayFab errors a little easier
            reqContainer.RequestHeaders["X-PlayFabSDK"] = PlayFabSettings.VersionString; // Tell PlayFab which SDK this is
            switch (authType)
            {
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API
                case AuthType.DevSecretKey: reqContainer.RequestHeaders["X-SecretKey"] = PlayFabSettings.DeveloperSecretKey; break;
#endif
                case AuthType.LoginSession: reqContainer.RequestHeaders["X-Authorization"] = _internalHttp.AuthKey; break;
            }

            // These closures preserve the TResult generic information in a way that's safe for all the devices
            reqContainer.DeserializeResultJson = () =>
            {
                reqContainer.ApiResult = JsonWrapper.DeserializeObject<TResult>(reqContainer.JsonResponse);
            };
            reqContainer.InvokeSuccessCallback = () =>
            {
                if (resultCallback != null)
                    resultCallback((TResult)reqContainer.ApiResult);
            };

            if (allowQueueing && _apiCallQueue != null && !_internalHttp.SessionStarted)
            {
                for (var i = _apiCallQueue.Count - 1; i >= 0; i--)
                    if (_apiCallQueue[i].ApiEndpoint == apiEndpoint)
                        _apiCallQueue.RemoveAt(i);
                _apiCallQueue.Add(reqContainer);
            }
            else
            {
                _internalHttp.MakeApiCall(reqContainer);
            }
        }

        /// <summary>
        /// MonoBehaviour OnEnable Method
        /// </summary>
        public void OnEnable()
        {
            if (_logger != null)
            {
                _logger.OnEnable();
            }
        }

        /// <summary>
        /// MonoBehaviour OnDisable
        /// </summary>
        public void OnDisable()
        {
            if (_logger != null)
            {
                _logger.OnDisable();
            }
        }

        /// <summary>
        /// MonoBehaviour OnDestroy
        /// </summary>
        public void OnDestroy()
        {
            if (_internalHttp != null)
            {
                _internalHttp.OnDestroy();
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
        }

        /// <summary>
        /// MonoBehaviour Update
        /// </summary>
        public void Update()
        {
            if (_internalHttp != null)
            {
                if (!_internalHttp.SessionStarted && _apiCallQueue != null)
                {
                    foreach (var eachRequest in _apiCallQueue)
                        _internalHttp.MakeApiCall(eachRequest); // Flush the queue
                    _apiCallQueue = null; // null this after it's flushed
                }
                _internalHttp.Update();
            }

#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
            if (_internalSignalR != null)
            {
                _internalSignalR.Update();
            }
#endif
        }

        #region Helpers
        public static bool IsClientLoggedIn()
        {
            return _internalHttp != null && !string.IsNullOrEmpty(_internalHttp.AuthKey);
        }

        public static void ForgetClientCredentials()
        {
            if (_internalHttp != null)
                _internalHttp.AuthKey = null;
        }

        protected internal static PlayFabError GeneratePlayFabError(string json, object customData)
        {
            JsonObject errorDict = null;
            Dictionary<string, List<string>> errorDetails = null;
            try
            {
                // Deserialize the error
                errorDict = JsonWrapper.DeserializeObject<JsonObject>(json);
            }
            catch (Exception) { /* Unusual, but shouldn't actually matter */ }
            try
            {
                if (errorDict != null && errorDict.ContainsKey("errorDetails"))
                    errorDetails = JsonWrapper.DeserializeObject<Dictionary<string, List<string>>>(errorDict["errorDetails"].ToString());
            }
            catch (Exception) { /* Unusual, but shouldn't actually matter */ }

            return new PlayFabError
            {
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
