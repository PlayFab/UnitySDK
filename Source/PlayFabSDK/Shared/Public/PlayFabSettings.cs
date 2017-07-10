using System;
using UnityEngine;

namespace PlayFab
{
    public enum WebRequestType
    {
        UnityWww, // High compatability Unity api calls
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

    public static partial class PlayFabSettings
    {
        static PlayFabSettings() { }

        private static PlayFabSharedSettings _playFabShared = null;
        private static PlayFabSharedSettings PlayFabSharedPrivate { get { if (_playFabShared == null) _playFabShared = GetSharedSettingsObjectPrivate(); return _playFabShared; } }
        [Obsolete("This field will become private after Mar 1, 2017", false)]
        public static PlayFabSharedSettings PlayFabShared { get { if (_playFabShared == null) _playFabShared = GetSharedSettingsObjectPrivate(); return _playFabShared; } }
        public const string SdkVersion = "2.24.170710";
        public const string BuildIdentifier = "jbuild_unitysdk_11_0";
        public const string VersionString = "UnitySDK-2.24.170710";
        private const string DefaultPlayFabApiUrlPrivate = ".playfabapi.com";
        [Obsolete("This field will become private after Mar 1, 2017", false)]
        public static string DefaultPlayFabApiUrl { get { return DefaultPlayFabApiUrlPrivate; } }

        private static PlayFabSharedSettings GetSharedSettingsObjectPrivate()
        {
            var settingsList = Resources.LoadAll<PlayFabSharedSettings>("PlayFabSharedSettings");
            if (settingsList.Length != 1)
            {
                throw new Exception("The number of PlayFabSharedSettings objects should be 1: " + settingsList.Length);
            }
            return settingsList[0];
        }
        [Obsolete("This field will become private after Mar 1, 2017", false)]
        public static PlayFabSharedSettings GetSharedSettingsObject()
        {
            return GetSharedSettingsObjectPrivate();
        } 


#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API
        public static string DeveloperSecretKey
        {
            set { PlayFabSharedPrivate.DeveloperSecretKey = value;}
            internal get { return PlayFabSharedPrivate.DeveloperSecretKey; }
        }
#endif

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


        private static string ProductionEnvironmentUrlPrivate
        {
            get { return !string.IsNullOrEmpty(PlayFabSharedPrivate.ProductionEnvironmentUrl) ? PlayFabSharedPrivate.ProductionEnvironmentUrl : DefaultPlayFabApiUrlPrivate; }
            set { PlayFabSharedPrivate.ProductionEnvironmentUrl = value; }
        }
        [Obsolete("This field will become private after Mar 1, 2017", false)]
        public static string ProductionEnvironmentUrl
        {
            get { return ProductionEnvironmentUrlPrivate; }
            set { ProductionEnvironmentUrlPrivate = value; }
        }

        // You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website)
        public static string TitleId
        {
            get { return PlayFabSharedPrivate.TitleId; }
            set { PlayFabSharedPrivate.TitleId = value; }
        }

        public static PlayFabLogLevel LogLevel
        {
            get { return PlayFabSharedPrivate.LogLevel; }
            set { PlayFabSharedPrivate.LogLevel = value; }
        }

        public static WebRequestType RequestType
        {
            get { return PlayFabSharedPrivate.RequestType; }
            set { PlayFabSharedPrivate.RequestType = value; }
        }

        public static int RequestTimeout
        {
            get { return PlayFabSharedPrivate.RequestTimeout; }
            set { PlayFabSharedPrivate.RequestTimeout = value; }

        }

        public static bool RequestKeepAlive
        {
            get { return PlayFabSharedPrivate.RequestKeepAlive; }
            set { PlayFabSharedPrivate.RequestKeepAlive = value; }
        }

        public static bool CompressApiData
        {
            get { return PlayFabSharedPrivate.CompressApiData; }
            set { PlayFabSharedPrivate.CompressApiData = value; }
        }

        public static string LoggerHost
        {
            get { return PlayFabSharedPrivate.LoggerHost; }
            set { PlayFabSharedPrivate.LoggerHost = value; }

        }

        public static int LoggerPort
        {
            get { return PlayFabSharedPrivate.LoggerPort; }
            set { PlayFabSharedPrivate.LoggerPort = value; }
        }

        public static bool EnableRealTimeLogging
        {
            get { return PlayFabSharedPrivate.EnableRealTimeLogging; }
            set { PlayFabSharedPrivate.EnableRealTimeLogging = value; }
        }

        public static int LogCapLimit
        {
            get { return PlayFabSharedPrivate.LogCapLimit; }
            set { PlayFabSharedPrivate.LogCapLimit = value; }
        }

        public static string GetFullUrl(string apiCall)
        {
            string output;
            var baseUrl = ProductionEnvironmentUrlPrivate;
            if (baseUrl.StartsWith("http"))
                output = baseUrl + apiCall;
            else
                output = "https://" + TitleId + baseUrl + apiCall;
            return output;
        }
    }
}
