using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PlayFab
{
    public enum WebRequestType
    {
#if !UNITY_2018_2_OR_NEWER // Unity has deprecated Www
        UnityWww, // High compatability Unity api calls
#endif
        UnityWebRequest, // Modern unity HTTP component
        HttpWebRequest, // High performance multi-threaded api calls
        CustomHttp //If this is used, you must set the Http to an IPlayFabHttp object.
    }

    [Flags]
    public enum PlayFabLogLevel
    {
        None = 0,
        Debug = 1 << 0,
        Info = 1 << 1,
        Warning = 1 << 2,
        Error = 1 << 3,
        All = Debug | Info | Warning | Error,
    }

    public static class PlayFabSettings
    {
        static PlayFabSettings() { }

        private static PlayFabSharedSettings _playFabShared = null;
        private static PlayFabSharedSettings PlayFabSharedPrivate { get { if (_playFabShared == null) _playFabShared = GetSharedSettingsObjectPrivate(); return _playFabShared; } }

        /// <summary>
        /// Global settings used by all static API classes, and as the default for all instance API classes
        /// </summary>
        public static readonly PlayFabApiSettings staticSettings = new PlayFabSettingsRedirect(() => { return PlayFabSharedPrivate; });
        /// <summary>
        /// Global user for all static API classes
        /// </summary>
        public static readonly PlayFabAuthenticationContext staticPlayer = new PlayFabAuthenticationContext();

        public const string SdkVersion = "2.136.220523";
        public const string BuildIdentifier = "adobuild_unitysdk_167";
        public const string VersionString = "UnitySDK-2.136.220523";

        public const string DefaultPlayFabApiUrl = "playfabapi.com";

        private static PlayFabSharedSettings GetSharedSettingsObjectPrivate()
        {
            var settingsList = Resources.LoadAll<PlayFabSharedSettings>("PlayFabSharedSettings");
            if (settingsList.Length != 1)
            {
                Debug.LogWarning("The number of PlayFabSharedSettings objects should be 1: " + settingsList.Length);
                Debug.LogWarning("If you are upgrading your SDK, you can ignore this warning as PlayFabSharedSettings will be imported soon. If you are not upgrading your SDK and you see this message, you should re-download the latest PlayFab source code.");
            }
            return settingsList[0];
        }

        public static string DeviceUniqueIdentifier
        {
            get
            {
                var deviceId = "";
#if UNITY_ANDROID && !UNITY_EDITOR
                AndroidJavaClass up = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject> ("currentActivity");
                AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject> ("getContentResolver");
                AndroidJavaClass secure = new AndroidJavaClass ("android.provider.Settings$Secure");
                deviceId = secure.CallStatic<string> ("getString", contentResolver, "android_id");
#else
                deviceId = SystemInfo.deviceUniqueIdentifier;
#endif
                return deviceId;
            }
        }

        /// <summary>
        /// These are variables which can differ from one PlayFab API Instance to another
        /// </summary>
        #region staticSettings Redirects
        // You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website)
        public static string TitleId { get { return staticSettings.TitleId; } set { staticSettings.TitleId = value; } }

        // Set this value to override specific title connection point
        public static string ConnectionString { get {return staticSettings.ConnectionString; } set { staticSettings.ConnectionString = value; } }
        /// <summary> The name of a customer vertical. This is only for customers running a private cluster.  Generally you shouldn't touch this </summary>
        internal static string VerticalName { get { return staticSettings.VerticalName; } set { staticSettings.VerticalName = value; } }
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || UNITY_EDITOR
        public static string DeveloperSecretKey { get { return staticSettings.DeveloperSecretKey; } set { staticSettings.DeveloperSecretKey = value; } }
#endif
        /// <summary> Set this to true to prevent hardware information from leaving the device </summary>
        public static bool DisableDeviceInfo { get { return staticSettings.DisableDeviceInfo; } set { staticSettings.DisableDeviceInfo = value; } }
        /// <summary> Set this to true to prevent focus change information from leaving the device </summary>
        public static bool DisableFocusTimeCollection { get { return staticSettings.DisableFocusTimeCollection; } set { staticSettings.DisableFocusTimeCollection = value; } }
        #endregion staticSettings Redirects

        /// <summary>
        /// These are variables which are always singleton global
        /// </summary>
        #region PlayFabSharedSettings Redirects
        [ObsoleteAttribute("LogLevel has been deprecated, please use UnityEngine.Debug.Log for your logging needs.")]
        public static PlayFabLogLevel LogLevel { get { return PlayFabSharedPrivate.LogLevel; } set { PlayFabSharedPrivate.LogLevel = value; } }
        public static WebRequestType RequestType { get { return PlayFabSharedPrivate.RequestType; } set { PlayFabSharedPrivate.RequestType = value; } }
        public static int RequestTimeout { get { return PlayFabSharedPrivate.RequestTimeout; } set { PlayFabSharedPrivate.RequestTimeout = value; } }
        public static bool RequestKeepAlive { get { return PlayFabSharedPrivate.RequestKeepAlive; } set { PlayFabSharedPrivate.RequestKeepAlive = value; } }
        public static string LoggerHost { get { return PlayFabSharedPrivate.LoggerHost; } set { PlayFabSharedPrivate.LoggerHost = value; } }
        public static int LoggerPort { get { return PlayFabSharedPrivate.LoggerPort; } set { PlayFabSharedPrivate.LoggerPort = value; } }
        public static bool EnableRealTimeLogging { get { return PlayFabSharedPrivate.EnableRealTimeLogging; } set { PlayFabSharedPrivate.EnableRealTimeLogging = value; } }
        public static int LogCapLimit { get { return PlayFabSharedPrivate.LogCapLimit; } set { PlayFabSharedPrivate.LogCapLimit = value; } }
        #endregion PlayFabSharedSettings Redirects

        private static string _localApiServer;
        public static string LocalApiServer
        {
            get
            {
#if UNITY_2017_1_OR_NEWER
                return _localApiServer ?? PlayFabUtil.GetLocalSettingsFileProperty("LocalApiServer");
#else
                return _localApiServer;
#endif
            }

            set
            {
                _localApiServer = value;
            }
        }

        public static string GetFullUrl(string apiCall, Dictionary<string, string> getParams, PlayFabApiSettings apiSettings = null)
        {
            StringBuilder sb = new StringBuilder(1000);

            string productionEnvironmentUrl = null, verticalName = null, titleId = null;
            if (apiSettings != null)
            {
                if(apiSettings.ConnectionString != "")
                {
                    productionEnvironmentUrl = apiSettings.ConnectionString;
                }
                else
                {
                    if (!string.IsNullOrEmpty(apiSettings.ProductionEnvironmentUrl))
                    {
                        productionEnvironmentUrl = apiSettings.ProductionEnvironmentUrl;
                    }
                    if (!string.IsNullOrEmpty(apiSettings.VerticalName))
                    {
                        verticalName = apiSettings.VerticalName;
                    }
                    if (!string.IsNullOrEmpty(apiSettings.TitleId))
                    {
                        titleId = apiSettings.TitleId;
                    }
                }
            }
            else if(ConnectionString != "")
            {
                productionEnvironmentUrl = ConnectionString;
            }


            if (productionEnvironmentUrl == null)
            {
                productionEnvironmentUrl = !string.IsNullOrEmpty(PlayFabSharedPrivate.ProductionEnvironmentUrl) ? PlayFabSharedPrivate.ProductionEnvironmentUrl : DefaultPlayFabApiUrl;
            }
            if (verticalName == null && apiSettings != null && !string.IsNullOrEmpty(apiSettings.VerticalName))
            {
                verticalName = apiSettings.VerticalName;
            }
            if (titleId == null)
            {
                titleId = PlayFabSharedPrivate.TitleId;
            }

            var baseUrl = productionEnvironmentUrl;
            if (!baseUrl.StartsWith("http"))
            {
                sb.Append("https://");
                if (!string.IsNullOrEmpty(titleId))
                {
                    sb.Append(titleId).Append(".");
                }
                if (!string.IsNullOrEmpty(verticalName))
                {
                    sb.Append(verticalName).Append(".");
                }
            }

            sb.Append(baseUrl).Append(apiCall);

            if (getParams != null)
            {
                bool firstParam = true;
                foreach (var paramPair in getParams)
                {
                    if (firstParam)
                    {
                        sb.Append("?");
                        firstParam = false;
                    }
                    else
                    {
                        sb.Append("&");
                    }
                    sb.Append(paramPair.Key).Append("=").Append(paramPair.Value);
                }
            }

            return sb.ToString();
        }
    }
}
