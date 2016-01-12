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
        private const string GLOBAL_KEY = "GLOBAL";
        public static ErrorCallback GlobalErrorHandler;
        private static readonly Dictionary<string, HashSet<MethodInfo>> GlobalApiRequestHandlers = new Dictionary<string, HashSet<MethodInfo>>();
        private static readonly Dictionary<string, HashSet<MethodInfo>> GlobalApiResponseHandlers = new Dictionary<string, HashSet<MethodInfo>>();
        private static readonly Dictionary<MethodInfo, HashSet<object>> GlobalApiInstances = new Dictionary<MethodInfo, HashSet<object>>();

        public static string ProductionEnvironmentUrl = ".playfabapi.com";
        public static string TitleId = null; // You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website)
        public static PlayFabLogLevel LogLevel = PlayFabLogLevel.Warning | PlayFabLogLevel.Error;
        public static bool IsTesting = false;
        public static WebRequestType RequestType = WebRequestType.UnityWww;
        public static int RequestTimeout = 2000;
        public static bool RequestKeepAlive = true;
        public static string DeveloperSecretKey = null; // You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website)
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

        public static void RegisterForRequests(string url, MethodInfo methodInfo, object instance = null)
        {
            if (methodInfo.IsStatic && (instance != null))
                throw new Exception("methodInfo is static, instance must be null");
            else if (!methodInfo.IsStatic && (instance == null))
                throw new Exception("methodInfo is not static, instance must be provided");

            if (url == null)
                url = GLOBAL_KEY;
            HashSet<MethodInfo> methodInfos;
            if (!GlobalApiRequestHandlers.TryGetValue(url, out methodInfos))
                GlobalApiRequestHandlers[url] = methodInfos = new HashSet<MethodInfo>();
            methodInfos.Add(methodInfo);
            if (instance != null)
            {
                HashSet<object> instances;
                if (!GlobalApiInstances.TryGetValue(methodInfo, out instances))
                    GlobalApiInstances[methodInfo] = instances = new HashSet<object>();
                instances.Add(instance);
            }
        }

        public static void RegisterForResponses(string url, MethodInfo methodInfo, object instance = null)
        {
            if (methodInfo.IsStatic && (instance != null))
                throw new Exception("methodInfo is static, instance must be null");
            else if (!methodInfo.IsStatic && (instance == null))
                throw new Exception("methodInfo is not static, instance must be provided");

            if (url == null)
                url = GLOBAL_KEY;
            HashSet<MethodInfo> methodInfos;
            if (!GlobalApiResponseHandlers.TryGetValue(url, out methodInfos))
                GlobalApiResponseHandlers[url] = methodInfos = new HashSet<MethodInfo>();
            methodInfos.Add(methodInfo);
            if (instance != null)
            {
                HashSet<object> instances;
                if (!GlobalApiInstances.TryGetValue(methodInfo, out instances))
                    GlobalApiInstances[methodInfo] = instances = new HashSet<object>();
                instances.Add(instance);
            }
        }

        private static readonly object[] RequestParams = new object[4];
        public static void InvokeRequest(string url, int callId, object request, object customData)
        {
            HashSet<object> instances;
            RequestParams[0] = url;
            RequestParams[1] = callId; // Boxing :(
            RequestParams[2] = request;
            RequestParams[3] = customData;
            HashSet<MethodInfo> methodInfos;
            if (GlobalApiRequestHandlers.TryGetValue(url, out methodInfos))
            {
                foreach (var methodInfo in methodInfos)
                {
                    GlobalApiInstances.TryGetValue(methodInfo, out instances);
                    if (instances == null)
                        methodInfo.Invoke(null, RequestParams);
                    else
                        foreach (object instance in instances)
                            methodInfo.Invoke(instance, RequestParams);
                }
            }
            if (GlobalApiRequestHandlers.TryGetValue(GLOBAL_KEY, out methodInfos))
            {
                foreach (var methodInfo in methodInfos)
                {
                    GlobalApiInstances.TryGetValue(methodInfo, out instances);
                    if (instances == null)
                        methodInfo.Invoke(null, RequestParams);
                    else
                        foreach (object instance in instances)
                            methodInfo.Invoke(instance, RequestParams);
                }
            }
        }

        private static readonly object[] ResponseParams = new object[6];
        public static void InvokeResponse(string url, int callId, object request, object result, PlayFabError error, object customData)
        {
            HashSet<object> instances;
            ResponseParams[0] = url;
            ResponseParams[1] = callId; // Boxing :(
            ResponseParams[2] = request;
            ResponseParams[3] = result;
            ResponseParams[4] = error;
            ResponseParams[5] = customData;
            HashSet<MethodInfo> methodInfos;
            if (GlobalApiResponseHandlers.TryGetValue(url, out methodInfos))
            {
                foreach (var methodInfo in methodInfos)
                {
                    GlobalApiInstances.TryGetValue(methodInfo, out instances);
                    if (instances == null)
                        methodInfo.Invoke(null, ResponseParams);
                    else
                        foreach (object instance in instances)
                            methodInfo.Invoke(instance, ResponseParams);
                }
            }
            if (GlobalApiResponseHandlers.TryGetValue(GLOBAL_KEY, out methodInfos))
            {
                foreach (var methodInfo in methodInfos)
                {
                    GlobalApiInstances.TryGetValue(methodInfo, out instances);
                    if (instances == null)
                        methodInfo.Invoke(null, ResponseParams);
                    else
                        foreach (object instance in instances)
                            methodInfo.Invoke(instance, ResponseParams);
                }
            }
        }
    }
}
