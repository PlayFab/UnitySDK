using System;
using System.Reflection;
using PlayFab.Internal;
using System.Runtime.InteropServices;

namespace PlayFab
{
    public static class PlayFabiOSPlugin
    {
        public delegate void InvokeRequestDelegate(string url, int callId, object request, object customData);
        public delegate void InvokeResponseDelegate(string url, int callId, object request, object result, PlayFabError error, object customData);
        public static InvokeRequestDelegate InvokeRequest;
        public static InvokeResponseDelegate InvokeResponse;

#if UNITY_IOS
        [DllImport("__Internal")]
        private static extern void pf_make_http_request(string url, string method, int numHeaders, string[] headers, string[] headerValues, string body, int requestId);
        [DllImport("__Internal")]
        public static extern string getIdfa();
        [DllImport("__Internal")]
        public static extern bool getAdvertisingDisabled();

        public static bool isAvailable() { return true; }

#else

        public static bool isAvailable() { return false; }
#endif

        public static void Init(string senderId)
        {
            PlayFabPluginEventHandler.Init();
        }

#if UNITY_IOS
        public static void Post(string fullUrl, string url, int callId, string data, string authType, string authKey, string sdkVersion, object request, object customData, Action<string, PlayFabError> callback)
        {
            string[] headers = new string[4];
            string[] headerValues = new string[4];

            int h = 0;
            headers[h] = "Content-Type"; headerValues[h++] = "application/json";
            if (authType != null)
            {
                headers[h] = authType; headerValues[h++] = authKey;
            }
            headers[h] = "X-ReportErrorAsSuccess"; headerValues[h++] = "true";
            headers[h] = "X-PlayFabSDK"; headerValues[h++] = sdkVersion;

            PlayFabPluginEventHandler.AddHttpDelegate(url, callId, request, customData, callback);

            InvokeRequest(url, callId, request, customData);

            pf_make_http_request(fullUrl, "POST", h, headers, headerValues, data, callId);
#else
        //This will never get used and is to prevent editor compile errors.
        public static void Post(string url, int callId, string data, string authType, string authKey, string sdkVersion, Action<string, string> callback)
        {
            callback(null, "This method only works on iOS");
#endif
        }
    }
}
