using System;
using System.Net;
using UnityEngine;

namespace PlayFab.Internal
{
    public enum WebRequestType
    {
        UnityWww, // High compatability Unity api calls
        HttpWebRequest // High performance multi-threaded api calls
    }

    public class PlayFabHttp : SingletonMonoBehaviour<PlayFabHttp>
    {
        private static int _callIdGen = 1;
        private static IPlayFabHttp _internalHttp = null;

        /// <summary>
        /// Return the number of api calls that are waiting for results from the server
        /// </summary>
        /// <returns></returns>
        public static int GetPendingMessages()
        {
            return _internalHttp == null ? 0 : _internalHttp.GetPendingMessages();
        }

        /// <summary>
        /// Optional redirect to allow mocking of http calls, or use a custom http utility
        /// </summary>
        public void SetHttp<THttpObject>(THttpObject httpObj) where THttpObject : IPlayFabHttp
        {
            _internalHttp = httpObj;
        }

        /// <summary>
        /// Based on PlayFabSettings.RequestType
        /// </summary>
        private static void InitializeHttp()
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
                _internalHttp = new PlayFabWww();
            _internalHttp.Awake();
        }

        /// <summary>
        /// Sends a POST HTTP request
        /// </summary>
        public static void Post(string urlPath, string data, string authType, string authKey, Action<CallRequestContainer> callback, object request, object customData)
        {
            var requestContainer = new CallRequestContainer { CallId = _callIdGen++, AuthKey = authKey, AuthType = authType, Callback = callback, Data = data, UrlPath = urlPath, Request = request, CustomData = customData };
            InitializeHttp();
            _internalHttp.Post(requestContainer);
        }

        public void Update()
        {
            if (_internalHttp != null)
                _internalHttp.Update();
        }

        internal static PlayFabError GeneratePfError(HttpStatusCode httpCode, PlayFabErrorCode pfErrorCode, string errorMessage, object customData)
        {
            string httpCodeStr;
            switch (httpCode)
            {
                //TODO: Handle more specific cases as needed.
                case HttpStatusCode.OK:
                    httpCodeStr = string.Format("Success: {0}", httpCode); break;
                case HttpStatusCode.RequestTimeout:
                    httpCodeStr = string.Format("Request Timeout: {0}", httpCode); break;
                case HttpStatusCode.BadRequest:
                    httpCodeStr = string.Format("BadRequest: {0}", httpCode); break;
                default:
                    httpCodeStr = string.Format("Service Unavailable: {0}", httpCode); break;
            }

            return new PlayFabError()
            {
                HttpCode = (int)httpCode,
                HttpStatus = httpCodeStr,
                Error = pfErrorCode,
                ErrorMessage = errorMessage,
                ErrorDetails = null,
                CustomData = customData
            };
        }
    }

    public interface IPlayFabHttp
    {
        void Awake();
        int GetPendingMessages();
        void Post(CallRequestContainer requestContainer);
        void Update();
    }

    /// <summary>
    /// This is a callback class for use with HttpWebRequest.
    /// </summary>
    public class CallRequestContainer
    {
        public enum RequestState { Unstarted, RequestSent, RequestReceived, Error };

        public RequestState State = RequestState.Unstarted;
        public string UrlPath;
        public int CallId;
        public string Data;
        public string AuthType;
        public string AuthKey;
        public object Request;
        public string ResultStr;
        public object CustomData;
        public HttpWebRequest HttpRequest;
        public PlayFabError Error;
        public Action<CallRequestContainer> Callback;

        public void InvokeCallback()
        {
            // It is expected that the specific callback needs to process the change before the less specific global callback
            if (Callback != null)
                Callback(this); // Do the specific callback
        }
    }
}
