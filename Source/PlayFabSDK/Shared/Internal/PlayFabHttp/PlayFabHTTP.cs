using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PlayFab.Json;

namespace PlayFab.Internal
{
    /// <summary>
    /// This is a wrapper for Http So we can better separate the functionaity of Http Requests delegated to WWW or HttpWebRequest
    /// </summary>
    public class PlayFabHttp : SingletonMonoBehaviour<PlayFabHttp>
    {
        private static IPlayFabHttp _internalHttp; //This is the default;
        public delegate void ApiProcessingEvent<in TEventArgs>(TEventArgs e);
        public delegate void ApiProcessErrorEvent(object request, PlayFabError error);
        public static event ApiProcessingEvent<ApiProcessingEventArgs> ApiProcessingEventHandler;
        public static event ApiProcessErrorEvent ApiProcessingErrorEventHandler;

        private IPlayFabTailLogger _logger; //Removed PaperTrail ( UdpPaperTrailLogger )
        private static PlayFabDataGatherer _gatherer = new PlayFabDataGatherer();

        private readonly object _logMessageLock = new object();
        private readonly Queue<string> _logMessageQueue = new Queue<string>();
        private bool _systemInfoLogged = false;

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
        /// <param name="AuthKey"></param>
        public static void SetAuthKey(string AuthKey)
        {
            _internalHttp.AuthKey = AuthKey;
        }

        /// <summary>
        /// This initializes the GameObject and ensures it is in the scene.
        /// </summary>
        public static void InitializeHttp()
        {
            if (_internalHttp != null)
                return;

            CreateInstance(); // Invoke the SingletonMonoBehaviour
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
            _internalHttp.Awake();
        }

        /// <summary>
        /// Internal method for Make API Calls
        /// </summary>
        /// <typeparam name="TRequestType"></typeparam>
        /// <typeparam name="TResultType"></typeparam>
        /// <param name="api"></param>
        /// <param name="apiEndpoint"></param>
        /// <param name="request"></param>
        /// <param name="authType"></param>
        /// <param name="resultCallback"></param>
        /// <param name="errorCallback"></param>
        /// <param name="customData"></param>
        protected internal static void MakeApiCall<TRequestType, TResultType>(string api, string apiEndpoint,
            TRequestType request, string authType, Action<TResultType> resultCallback,
            Action<PlayFabError> errorCallback, object customData = null)
        {
            InitializeHttp();
            SendEvent(request, null, ApiProcessingEventType.Pre);
            _internalHttp.MakeApiCall(api, apiEndpoint, request, authType, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Monobehaviour Awake Method, gathers system data
        /// </summary>
        public override void Awake()
        {
#if ENABLE_PLAYFABADMIN_API || ENABLE_PLAYFABSERVER_API
            _internalHttp.DevKey = PlayFabSettings.DeveloperSecretKey ?? _internalHttp.DevKey;
#endif
            _gatherer.GatherData();
            base.Awake();
        }

        /// <summary>
        /// Monobehaviour OnEnable Method, registers logger
        /// </summary>
        public void OnEnable()
        {
            StartCoroutine(RegisterLogger());
        }

        /// <summary>
        /// Monobehaviour OnDisable method, performs cleanup of Logger and bindings to Log Messages
        /// </summary>
        public void OnDisable()
        {
            if (!string.IsNullOrEmpty(PlayFabSettings.LoggerHost))
            {
                _logger = null;
#if UNITY_5
                UnityEngine.Application.logMessageReceivedThreaded -= HandleLogOutput;
#else
                UniytEngine.Application.RegisterLogCallback(null);
#endif
            }
        }

        /// <summary>
        /// Monobehaviour Update method, logs System info data if gathered.
        /// </summary>
        public void Update()
        {
            if (_internalHttp != null)
            {
                _internalHttp.Update();
            }
        }

        /// <summary>
        /// Monobehaviour FixedUpdate, logs messages when enabled.
        /// </summary>
        void FixedUpdate()
        {
            if (!_systemInfoLogged && PlayFabSettings.EnableRealTimeLogging)
            {
                _gatherer.EnqueueToLogger(_logMessageQueue);
                _systemInfoLogged = true;
            }

            lock (_logMessageLock)
            {
                if (_logMessageQueue.Count > 0 && PlayFabSettings.EnableRealTimeLogging)
                {
                    if (_logger == null)
                    {
                        return;
                    }
                    _logger.Open();
                    while (_logMessageQueue.Count > 0)
                    {
                        _logger.Log(_logMessageQueue.Dequeue());
                    }
                    _logger.Close();
                }
                else if (_logMessageQueue.Count > 0 && _logMessageQueue.Count > PlayFabSettings.LogCapLimit)
                {
                    while (_logMessageQueue.Count > PlayFabSettings.LogCapLimit)
                    {
                        _logMessageQueue.Dequeue();
                    }
                }

            }
        }

        #region Helpers
        /// <summary>
        /// helper class to register the logger.
        /// </summary>
        /// <returns></returns>
        IEnumerator RegisterLogger()
        {
            yield return new WaitForEndOfFrame();
            if (!string.IsNullOrEmpty(PlayFabSettings.LoggerHost))
            {
                //_logger = new UdpPaperTrailLogger(PlayFabSettings.LoggerHost, PlayFabSettings.LoggerPort);
                _logger = PlayFabSettings.Logger ?? new PlayFabLogger(PlayFabSettings.LoggerHost, PlayFabSettings.LoggerPort);
#if UNITY_5
                UnityEngine.Application.logMessageReceivedThreaded += HandleLogOutput;
#else
                UniytEngine.Application.RegisterLogCallback(HandleLogOutput);
#endif
            }
        }

        /// <summary>
        /// Handler to enqueue log messages
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="stacktrace"></param>
        /// <param name="type"></param>
        private void HandleLogOutput(string condition, string stacktrace, LogType type)
        {
            var message = condition;
            if (type == LogType.Log || type == LogType.Warning)
            {
                //logger.Log(string.Format("{0}: {1}", type.ToString(), message));
                _logMessageQueue.Enqueue(string.Format("{0}: {1}", type.ToString(), message));
            }
            else if (type == LogType.Error || type == LogType.Exception)
            {
                message = condition + "\n" + stacktrace + UnityEngine.StackTraceUtility.ExtractStackTrace();
                //logger.Log(message);
                _logMessageQueue.Enqueue(message);
            }
        }

        public static bool IsClientLoggedIn()
        {
            return _internalHttp != null && !string.IsNullOrEmpty(_internalHttp.AuthKey);
        }

        [Serializable]
        protected internal class HttpResponseObject
        {
            public int code;
            public string status;
            public object data;
        }

        protected internal static PlayFabError GeneratePlayFabErrorGeneric(string message, string stacktrace, object customData = null)
        {
            var errorDetails = new Dictionary<string, List<string>>();
            var sb = new StringBuilder();
            sb.Append(message);
            if (!string.IsNullOrEmpty(stacktrace))
            {
                sb.Append(" | See stack trace in errorDetails");
                errorDetails.Add("stacktrace", new List<string>() { stacktrace });
            }
            return new PlayFabError()
            {
                Error = PlayFabErrorCode.InternalServerError,
                ErrorMessage = sb.ToString(),
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

        protected internal static void SendErrorEvent(object request, PlayFabError error)
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

        protected internal static void SendEvent(object request, object result, ApiProcessingEventType eventType)
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
        public object Request { get; set; }
        public object Result { get; set; }

        public T GetRequest<T>()
        {
            if (typeof(T) == Request.GetType())
            {
                return (T)Request;
            }
            return default(T);
        }
    }
    #endregion
}
