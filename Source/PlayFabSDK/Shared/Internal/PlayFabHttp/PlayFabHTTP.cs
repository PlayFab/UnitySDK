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
        private static readonly StringBuilder Sb = new StringBuilder();

        private static IPlayFabHttp _internalHttp; //This is the default;
        public delegate void ApiProcessingEvent<in TEventArgs>(TEventArgs e);
        public delegate void ApiProcessErrorEvent(PlayFabRequestCommon request, PlayFabError error);
        public static event ApiProcessingEvent<ApiProcessingEventArgs> ApiProcessingEventHandler;
        public static event ApiProcessErrorEvent ApiProcessingErrorEventHandler;

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
                _internalHttp = new PlayFabWWW();

#if ENABLE_PLAYFABADMIN_API || ENABLE_PLAYFABSERVER_API
            _internalHttp.DevKey = PlayFabSettings.DeveloperSecretKey;
#endif
            _internalHttp.InitializeHttp();
            CreateInstance(); // Invoke the SingletonMonoBehaviour
        }

        /// <summary>
        /// This initializes the GameObject and ensures it is in the scene.
        /// TODO: Allow redirecting to a custom logger.
        /// </summary>
        public static void InitializeLogger()
        {
            if (_logger != null)
                return;

            _logger = new PlayFabLogger();
        }

        /// <summary>
        /// Internal method for Make API Calls
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="api"></param>
        /// <param name="apiEndpoint"></param>
        /// <param name="request"></param>
        /// <param name="authType"></param>
        /// <param name="resultCallback"></param>
        /// <param name="errorCallback"></param>
        /// <param name="customData"></param>
        protected internal static void MakeApiCall<TRequest, TResult>(string api, string apiEndpoint,
            TRequest request, string authType, Action<TResult> resultCallback,
            Action<PlayFabError> errorCallback, object customData = null)
            where TRequest : PlayFabRequestCommon where TResult : PlayFabResultCommon
        {
            InitializeHttp();
            SendEvent(request, null, ApiProcessingEventType.Pre);
            _internalHttp.MakeApiCall(api, apiEndpoint, request, authType, resultCallback, errorCallback, customData);
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
            if (_logger != null)
            {
                _logger.OnDestroy();
            }
        }

        /// <summary>
        /// MonoBehaviour Update method, logs System info data if gathered.
        /// </summary>
        public void Update()
        {
            if (_internalHttp != null)
            {
                _internalHttp.Update();
            }
        }

        #region Helpers
        public static bool IsClientLoggedIn()
        {
            return _internalHttp != null && !string.IsNullOrEmpty(_internalHttp.AuthKey);
        }

        protected internal static PlayFabError GeneratePlayFabErrorGeneric(string message, string stacktrace, object customData = null)
        {
            var errorDetails = new Dictionary<string, List<string>>();
            Sb.Length = 0;
            Sb.Append(message);
            if (!string.IsNullOrEmpty(stacktrace))
            {
                Sb.Append(" | See stack trace in errorDetails");
                errorDetails.Add("stacktrace", new List<string>() { stacktrace });
            }
            return new PlayFabError()
            {
                Error = PlayFabErrorCode.InternalServerError,
                ErrorMessage = Sb.ToString(),
                ErrorDetails = errorDetails,
                CustomData = customData ?? new object()
            };
        }

        protected internal static PlayFabError GeneratePlayFabError(string json, object customData = null)
        {
            //deserialize the error
            var errorDict = JsonWrapper.DeserializeObject<JsonObject>(json, PlayFabUtil.ApiSerializerStrategy);

            Dictionary<string, List<string>> errorDetails = null;
            if (errorDict.ContainsKey("errorDetails"))
            {
                var ed =
                    JsonWrapper.DeserializeObject<Dictionary<string, List<string>>>(
                        errorDict["errorDetails"].ToString());
                errorDetails = ed;
            }
            //create new error object
            return new PlayFabError
            {
                HttpCode = errorDict.ContainsKey("code") ? Convert.ToInt32(errorDict["code"]) : 400,
                HttpStatus = errorDict.ContainsKey("status")
                    ? (string)errorDict["status"]
                    : "BadRequest",
                Error = errorDict.ContainsKey("errorCode")
                    ? (PlayFabErrorCode)Convert.ToInt32(errorDict["errorCode"])
                    : PlayFabErrorCode.ServiceUnavailable,
                ErrorMessage = errorDict.ContainsKey("errorMessage")
                    ? (string)errorDict["errorMessage"]
                    : string.Empty,
                ErrorDetails = errorDetails,
                CustomData = customData ?? new object()
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

        protected internal static void SendEvent(PlayFabRequestCommon request, PlayFabResultCommon result, ApiProcessingEventType eventType)
        {
            if (ApiProcessingEventHandler == null)
                return;
            try
            {
                ApiProcessingEventHandler(new ApiProcessingEventArgs
                {
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

    public class ApiProcessingEventArgs : EventArgs
    {
        public ApiProcessingEventType EventType { get; set; }
        public PlayFabRequestCommon Request { get; set; }
        public PlayFabResultCommon Result { get; set; }

        public TRequest GetRequest<TRequest>() where TRequest : PlayFabRequestCommon
        {
            return Request as TRequest;
        }
    }
    #endregion
}
