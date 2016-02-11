// #define DISABLE_IDFA // If you need to disable IDFA for your game, uncomment this

using System;
using PlayFab.Internal;
using System.Runtime.InteropServices;

namespace PlayFab
{
    public static class PlayFabiOSPlugin
    {
        public delegate void InvokeRequestDelegate(string url, int callId, object request, object customData);

#if UNITY_IOS && !DISABLE_IDFA
        [DllImport("__Internal")]
        public static extern string getIdfa();
        [DllImport("__Internal")]
        public static extern bool getAdvertisingDisabled();
#elif UNITY_IOS
        public static string getIdfa() { return "invalid"; }

        public static bool getAdvertisingDisabled() { return true; }
#endif

#if UNITY_IOS
        [DllImport("__Internal")]
        private static extern void pf_make_http_request(string url, string method, int numHeaders, string[] headers, string[] headerValues, string body, int requestId);

        public static bool isAvailable() { return true; }
#else
        public static bool isAvailable() { return false; }
#endif

        public static void Init(string senderId)
        {
            PlayFabPluginEventHandler.Init();
        }

#if UNITY_IOS
        public static void Post(string fullUrl, string sdkVersion, CallRequestContainer requestContainer, InvokeRequestDelegate invokeRequest)
        {
            string[] headers = new string[4];
            string[] headerValues = new string[4];

            int h = 0;
            headers[h] = "Content-Type"; headerValues[h++] = "application/json";
            if (requestContainer.AuthType != null)
            {
                headers[h] = requestContainer.AuthType; headerValues[h++] = requestContainer.AuthKey;
            }
            headers[h] = "X-ReportErrorAsSuccess"; headerValues[h++] = "true";
            headers[h] = "X-PlayFabSDK"; headerValues[h++] = sdkVersion;

            PlayFabPluginEventHandler.AddHttpDelegate(requestContainer);

            invokeRequest(requestContainer.Url, requestContainer.CallId, requestContainer.Request, requestContainer.CustomData);

            pf_make_http_request(fullUrl, "POST", h, headers, headerValues, requestContainer.Data, requestContainer.CallId);
#else
        //This will never get used and is to prevent editor compile errors.
        public static void Post(string url, int callId, string data, string authType, string authKey, string sdkVersion, Action<string, string> callback)
        {
            callback(null, "This method only works on iOS");
#endif
        }
    }
}
