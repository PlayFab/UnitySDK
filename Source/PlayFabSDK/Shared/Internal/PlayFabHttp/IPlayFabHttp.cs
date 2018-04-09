using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.Internal
{
    public interface IPlayFabHttp
    {
        bool SessionStarted { get; set; }
        string AuthKey { get; set; }
        string EntityToken { get; set; }
        void InitializeHttp();

        // Mirroring MonoBehaviour - Relayed from PlayFabHTTP
        void Update();
        void OnDestroy();

        void SimpleGetCall(string fullUrl, Action<byte[]> successCallback, Action<string> errorCallback);
        void SimplePutCall(string fullUrl, byte[] payload, Action successCallback, Action<string> errorCallback);
        void MakeApiCall(CallRequestContainer reqContainer);

        int GetPendingMessages();
    }

    public enum AuthType
    {
        None,
        PreLoginSession, // Not yet defined
        LoginSession, // "X-Authorization"
        DevSecretKey, // "X-SecretKey"
        EntityToken, // "X-EntityToken"
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
#if !UNITY_WSA && !UNITY_WP8
        public HttpRequestState HttpState = HttpRequestState.Idle;
        public System.Net.HttpWebRequest HttpRequest = null;
#endif
#if PLAYFAB_REQUEST_TIMING
        public PlayFabHttp.RequestTiming Timing;
        public System.Diagnostics.Stopwatch Stopwatch;
#endif

        // This class stores the state of the request and all associated data
        public string ApiEndpoint = null;
        public string FullUrl = null;
        public byte[] Payload = null;
        public string JsonResponse = null;
        public PlayFabRequestCommon ApiRequest;
        public Dictionary<string, string> RequestHeaders;
        public PlayFabResultCommon ApiResult;
        public PlayFabError Error;
        public Action DeserializeResultJson;
        public Action InvokeSuccessCallback;
        public Action<PlayFabError> ErrorCallback;
        public object CustomData = null;

        public CallRequestContainer()
        {
#if PLAYFAB_REQUEST_TIMING
            Stopwatch = System.Diagnostics.Stopwatch.StartNew();
#endif
        }
    }
}
