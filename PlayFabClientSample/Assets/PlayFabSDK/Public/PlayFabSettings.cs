using PlayFab.Internal;
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

    public static class PlayFabSettings
    {
        internal static bool HideCallbackErrors = false; // This should only be used by unit-tests that test deliberately throwing errors
        private const string GLOBAL_KEY = "GLOBAL";
        public static ErrorCallback GlobalErrorHandler;
        private static readonly Dictionary<string, HashSet<MethodInfo>> ApiRequestHandlers = new Dictionary<string, HashSet<MethodInfo>>();
        private static readonly Dictionary<string, HashSet<MethodInfo>> ApiResponseHandlers = new Dictionary<string, HashSet<MethodInfo>>();
        private static readonly Dictionary<MethodInfo, HashSet<object>> CallbackInstances = new Dictionary<MethodInfo, HashSet<object>>();

        public delegate void RequestCallback<in TRequest>(string urlPath, int callId, TRequest request, object customData) where TRequest : class;
        public delegate void ResponseCallback<in TRequest, in TResult>(string urlPath, int callId, TRequest request, TResult result, PlayFabError error, object customData)
            where TRequest : class
            where TResult : PlayFabResultCommon;

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
            else
            if (!IsTesting)
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

        #region Public Api Callback Registration
        /// <summary>
        /// When registered, the methodInfo callback function will be invoked whenever the indicated api call is made.
        /// </summary>
        /// <param name="urlPath">Use null to bind to every api call.  Uniquely identifies the api-call.  Formatted as "/api/function".  Corresponds to the url path, as described by:  https://developer.mozilla.org/en-US/Learn/Understanding_URLs </param>
        /// <param name="methodInfo">methodInfo object for the callback that should be invoked when the api call is requested.</param>
        /// <param name="instance">optional: if methodInfo is an instance method, provide the instance associated with that call.  Use null for static method</param>
        public static void RegisterForRequests(string urlPath, MethodInfo methodInfo, object instance = null) // Set as private to temporarilly disable this system until a cleaner interface is developed next week
        {
            CheckMethod(ref urlPath, methodInfo, instance);
            HashSet<MethodInfo> methodInfos;
            if (!ApiRequestHandlers.TryGetValue(urlPath, out methodInfos))
                ApiRequestHandlers[urlPath] = methodInfos = new HashSet<MethodInfo>();
            methodInfos.Add(methodInfo);
            if (instance != null)
            {
                HashSet<object> instances;
                if (!CallbackInstances.TryGetValue(methodInfo, out instances))
                    CallbackInstances[methodInfo] = instances = new HashSet<object>();
                instances.Add(instance);
            }
        }

        /// <summary>
        /// When registered, the methodInfo callback function will be invoked whenever the indicated api call is made.
        /// The function signature of the provided callback should match the RequestCallback delegate.
        /// Because APIs share request and result objects, you must additionally specify which API-call you wish to register for.
        /// </summary>
        public static void RegisterForRequests(string urlPath, Delegate callback)
        {
            RegisterForRequests(urlPath, callback.Method, callback.Target);
        }

        /// <summary>
        /// When registered, the methodInfo callback function will be invoked whenever the indicated api call is completed.
        /// </summary>
        /// <param name="urlPath">Use null to bind to every api call.  Uniquely identifies the api-call.  Formatted as "/api/function".  Corresponds to the url path, as described by:  https://developer.mozilla.org/en-US/Learn/Understanding_URLs </param>
        /// <param name="methodInfo">methodInfo object for the callback that should be invoked when the api call is requested.</param>
        /// <param name="instance">optional: if methodInfo is an instance method, provide the instance associated with that call.  Use null for static method</param>
        public static void RegisterForResponses(string urlPath, MethodInfo methodInfo, object instance = null) // Set as private to temporarilly disable this system until a cleaner interface is developed next week
        {
            CheckMethod(ref urlPath, methodInfo, instance);
            HashSet<MethodInfo> methodInfos;
            if (!ApiResponseHandlers.TryGetValue(urlPath, out methodInfos))
                ApiResponseHandlers[urlPath] = methodInfos = new HashSet<MethodInfo>();
            methodInfos.Add(methodInfo);
            if (instance != null)
            {
                HashSet<object> instances;
                if (!CallbackInstances.TryGetValue(methodInfo, out instances))
                    CallbackInstances[methodInfo] = instances = new HashSet<object>();
                instances.Add(instance);
            }
        }

        /// <summary>
        /// When registered, the methodInfo callback function will be invoked whenever the indicated api call is made.
        /// The function signature of the provided callback should match the RequestCallback delegate.
        /// Because APIs share request and result objects, you must additionally specify which API-call you wish to register for.
        /// </summary>
        public static void RegisterForResponses(string urlPath, Delegate callback)
        {
            RegisterForResponses(urlPath, callback.Method, callback.Target);
        }
        #endregion Public Api Registration

        #region Public Api Callback Un-registration
        /// <summary>
        /// Remove a callback associated with an api call
        /// Parameters used to register the call must be provided here to un-register that call.
        /// </summary>
        public static void UnregisterForRequests(string urlPath, MethodInfo methodInfo, object instance = null)
        {
            CheckMethod(ref urlPath, methodInfo, instance);
            HashSet<MethodInfo> methodInfos;
            if (!ApiRequestHandlers.TryGetValue(urlPath, out methodInfos))
                ApiRequestHandlers[urlPath] = methodInfos = new HashSet<MethodInfo>();
            methodInfos.Remove(methodInfo);
            if (methodInfos.Count == 0)
                ApiRequestHandlers.Remove(urlPath);
            if (instance != null)
            {
                HashSet<object> instances;
                if (!CallbackInstances.TryGetValue(methodInfo, out instances))
                    CallbackInstances[methodInfo] = instances = new HashSet<object>();
                instances.Remove(instance);
                if (instances.Count == 0)
                    CallbackInstances.Remove(methodInfo);
            }
        }

        /// <summary>
        /// Remove a callback associated with an api call
        /// Parameters used to register the call must be provided here to un-register that call.
        /// </summary>
        public static void UnregisterForRequests(string urlPath, Delegate callback)
        {
            UnregisterForRequests(urlPath, callback.Method, callback.Target);
        }

        /// <summary>
        /// Remove a callback associated with an api call
        /// Parameters used to register the call must be provided here to un-register that call.
        /// </summary>
        public static void UnregisterForResponses(string urlPath, MethodInfo methodInfo, object instance = null)
        {
            CheckMethod(ref urlPath, methodInfo, instance);
            HashSet<MethodInfo> methodInfos;
            if (!ApiResponseHandlers.TryGetValue(urlPath, out methodInfos))
                ApiResponseHandlers[urlPath] = methodInfos = new HashSet<MethodInfo>();
            methodInfos.Remove(methodInfo);
            if (methodInfos.Count == 0)
                ApiResponseHandlers.Remove(urlPath);
            if (instance != null)
            {
                HashSet<object> instances;
                if (!CallbackInstances.TryGetValue(methodInfo, out instances))
                    CallbackInstances[methodInfo] = instances = new HashSet<object>();
                instances.Remove(instance);
                if (instances.Count == 0)
                    CallbackInstances.Remove(methodInfo);
            }
        }

        /// <summary>
        /// Remove a callback associated with an api call
        /// Parameters used to register the call must be provided here to un-register that call.
        /// </summary>
        public static void UnregisterForResponses(string urlPath, Delegate callback)
        {
            UnregisterForResponses(urlPath, callback.Method, callback.Target);
        }

        private static readonly HashSet<MethodInfo> tempMI = new HashSet<MethodInfo>();
        private static readonly HashSet<string> tempUrl = new HashSet<string>();
        /// <summary>
        /// Unregister all callbacks associated with an instance
        /// </summary>
        public static void UnregisterInstance(object instance)
        {
            tempMI.Clear();
            foreach (var instancePair in CallbackInstances)
                if (instancePair.Value.Remove(instance) && instancePair.Value.Count == 0)
                    tempMI.Add(instancePair.Key);
            foreach (var mInfo in tempMI)
            {
                CallbackInstances.Remove(mInfo);

                tempUrl.Clear();
                foreach (var requestPair in ApiRequestHandlers)
                    if (requestPair.Value.Remove(mInfo) && requestPair.Value.Count == 0)
                        tempUrl.Add(requestPair.Key);
                foreach (var urlPath in tempUrl)
                    ApiRequestHandlers.Remove(urlPath);
                tempUrl.Clear();
                foreach (var responsePair in ApiResponseHandlers)
                    if (responsePair.Value.Remove(mInfo) && responsePair.Value.Count == 0)
                        tempUrl.Add(responsePair.Key);
                foreach (var urlPath in tempUrl)
                    ApiRequestHandlers.Remove(urlPath);
            }
        }

        /// <summary>
        /// Forcefully unregister all listeners
        /// Used for testing or shutdown
        /// </summary>
        public static void ForceUnregisterAll()
        {
            ApiRequestHandlers.Clear();
            ApiResponseHandlers.Clear();
            CallbackInstances.Clear();
            GlobalErrorHandler = null;
        }
        #endregion Public Api Un-registration

        #region Internal Api Callback functionality
        private static void CheckMethod(ref string urlPath, MethodInfo methodInfo, object instance = null)
        {
            if (methodInfo.IsStatic && (instance != null))
                throw new Exception("methodInfo is static, instance must be null");
            else if (!methodInfo.IsStatic && (instance == null))
                throw new Exception("methodInfo is not static, instance must be provided");
            if (string.IsNullOrEmpty(urlPath))
                urlPath = GLOBAL_KEY;
        }

        private static bool CheckInstance(object instance)
        {
            if (!(instance is UnityEngine.Object))
                return true; // non-unity objects don't support magic de-registration
            bool destroyed = ((UnityEngine.Object)instance).Equals(null); // Slightly special magic to detect when a UnityEngine object has been destroyed
            if (destroyed)
                UnregisterInstance(instance);
            return !destroyed;
        }

        private static readonly object[] RequestParams = new object[4];
        public static void InvokeRequest(string urlPath, int callId, object request, object customData)
        {
            RequestParams[0] = urlPath;
            RequestParams[1] = callId; // Boxing :(
            RequestParams[2] = request;
            RequestParams[3] = customData;

            InvokeHelper(ApiRequestHandlers, urlPath, RequestParams);
            InvokeHelper(ApiRequestHandlers, GLOBAL_KEY, RequestParams);
        }

        private static readonly object[] ResponseParams = new object[6];
        public static void InvokeResponse(string urlPath, int callId, object request, object result, PlayFabError error, object customData)
        {
            ResponseParams[0] = urlPath;
            ResponseParams[1] = callId; // Boxing :(
            ResponseParams[2] = request;
            ResponseParams[3] = result;
            ResponseParams[4] = error;
            ResponseParams[5] = customData;

            InvokeHelper(ApiResponseHandlers, urlPath, ResponseParams);
            InvokeHelper(ApiResponseHandlers, GLOBAL_KEY, ResponseParams);
        }

        private static void InvokeHelper(Dictionary<string, HashSet<MethodInfo>> handlers, string urlPath, object[] prams)
        {
            HashSet<object> instances;
            HashSet<MethodInfo> methodInfos;
            if (handlers.TryGetValue(urlPath, out methodInfos))
            {
                foreach (var methodInfo in methodInfos)
                {
                    CallbackInstances.TryGetValue(methodInfo, out instances);
                    if (instances == null)
                        SafeInvoke(methodInfo, null, prams);
                    else
                        foreach (object instance in instances)
                            if (CheckInstance(instance))
                                SafeInvoke(methodInfo, instance, prams);
                }
            }
        }

        private static void SafeInvoke(MethodInfo methodInfo, object instance, object[] prams)
        {
            try
            {
                methodInfo.Invoke(instance, prams);
            }
            catch (Exception e)
            {
                // If the callback itself throws an exception, log it and continue.
                // Exceptions by customers should not halt the PlayFab SDK
                if (!PlayFabSettings.HideCallbackErrors)
                    UnityEngine.Debug.LogException(e);
            }
        }
        #endregion Internal Api Callback functionality
    }
}
