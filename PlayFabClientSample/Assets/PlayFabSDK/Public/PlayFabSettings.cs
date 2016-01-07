using System;
using System.Collections.Generic;
using System.Reflection;

namespace PlayFab
{
    [Flags]
    public enum PlayFabLogLevel
    {
        None = 0,
        Debug = 1,
        Info = 2,
        Warning = 4,
        Error = 8,
        All = Debug | Info | Warning | Error,
    }

    public enum WebRequestType
    {
        UnityWww, // High compatability Unity api calls
        HttpWebRequest // High performance multi-threaded api calls
    }

    public static class PlayFabSettings
    {
        public static ErrorCallback GlobalErrorHandler;
        //private static readonly Dictionary<string, MethodInfo> GlobalApiRequestHandlers = new Dictionary<string, MethodInfo>(); /* string:url, object:request, object:customData  */
        //private static readonly Dictionary<string, MethodInfo> GlobalApiResponseHandlers = new Dictionary<string, MethodInfo>(); /* string:url, object:request, object:result, object:customData  */

        public static string ProductionEnvironmentUrl = ".playfabapi.com";
        public static string TitleId = null; // You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website)
        public static PlayFabLogLevel LogLevel = PlayFabLogLevel.Warning | PlayFabLogLevel.Error;
        public static bool IsTesting = false;
        public static WebRequestType RequestType = WebRequestType.UnityWww;
        public static int RequestTimeout = 2000;
        public static bool RequestKeepAlive = true;
        internal static string LogicServerUrl = null; // Assigned by GetCloudScriptUrl, used by RunCloudScript
        public static string AdvertisingIdType = null; // Set this to the appropriate AD_TYPE_X constant below
        public static string AdvertisingIdValue = null; // Set this to corresponding device value

        // DisableAdvertising is provided for completeness, but changing it is not suggested
        // Disabling this may prevent your advertising-related PlayFab marketplace partners from working correctly
        public static bool DisableAdvertising = false;
        public const string AD_TYPE_IDFA = "Idfa";
        public const string AD_TYPE_ANDROID_ID = "Android_Id";

        private static string GetLogicUrl(string apiCall)
        {
            return LogicServerUrl + apiCall;
        }

        public static string GetFullUrl(string apiCall)
        {
            if (apiCall == "/Client/RunCloudScript")
            {
                return GetLogicUrl(apiCall);
            }
            else if (!IsTesting)
            {
                string baseUrl = ProductionEnvironmentUrl;
                if (baseUrl.StartsWith("http"))
                    return baseUrl;
                return "https://" + TitleId + baseUrl + apiCall;
            }
            else
            {
                return "http://localhost:11289/" + apiCall;
            }
        }
    }
}
