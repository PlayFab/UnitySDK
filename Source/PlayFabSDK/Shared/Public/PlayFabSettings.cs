using System;
using PlayFab.Public;
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
        public static PlayFabSharedSettings PlayFabShared = GetSharedSettingsObject();
        public const string SdkVersion = "2.8.160912";
        public const string BuildIdentifier = "jbuild_unitysdk_1";
        public const string VersionString = "UnitySDK-2.8.160912";

        public static PlayFabSharedSettings GetSharedSettingsObject()
        {
            var settingsList = Resources.LoadAll<PlayFabSharedSettings>("PlayFabSharedSettings");
            if (settingsList.Length != 1)
            {
                throw new Exception("Either Missing PlayFabSharedSettings data file or multiple data files exist.");
            }
            return settingsList[0];
        } 


#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API
        public static string DeveloperSecretKey
        {
            set { PlayFabShared.DeveloperSecretKey = value;}
            internal get { return PlayFabShared.DeveloperSecretKey; }
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


        public static string ProductionEnvironmentUrl
        {
            get { return !string.IsNullOrEmpty(PlayFabShared.ProductionEnvironmentUrl) ? PlayFabShared.ProductionEnvironmentUrl : ".playfabapi.com"; }
            set { PlayFabShared.ProductionEnvironmentUrl = value; }
        }

        // You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website)
        public static string TitleId
        {
            get { return PlayFabShared.TitleId; }
            set { PlayFabShared.TitleId = value; }
        }

        public static PlayFabLogLevel LogLevel
        {
            get { return PlayFabShared.LogLevel; }
            set { PlayFabShared.LogLevel = value; }
        }

        public static WebRequestType RequestType
        {
            get { return PlayFabShared.RequestType; }
            set { PlayFabShared.RequestType = value; }
        }

        public static int RequestTimeout
        {
            get { return PlayFabShared.RequestTimeout; }
            set { PlayFabShared.RequestTimeout = value; }

        }

        public static bool RequestKeepAlive
        {
            get { return PlayFabShared.RequestKeepAlive; }
            set { PlayFabShared.RequestKeepAlive = value; }
        }

        public static bool CompressApiData
        {
            get { return PlayFabShared.CompressApiData; }
            set { PlayFabShared.CompressApiData = value; }
        }

        public static bool IsTesting
        {
            get { return PlayFabShared.IsTesting; }
            set { PlayFabShared.IsTesting = value; }
        }

        public static string LoggerHost
        {
            get { return PlayFabShared.LoggerHost; }
            set { PlayFabShared.LoggerHost = value; }

        }

        public static int LoggerPort
        {
            get { return PlayFabShared.LoggerPort; }
            set { PlayFabShared.LoggerPort = value; }
        }

        public static bool EnableRealTimeLogging
        {
            get { return PlayFabShared.EnableRealTimeLogging; }
            set { PlayFabShared.EnableRealTimeLogging = value; }
        }

        public static int LogCapLimit
        {
            get { return PlayFabShared.LogCapLimit; }
            set { PlayFabShared.LogCapLimit = value; }
        }

        public static string GetFullUrl(string apiCall)
        {
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
    }
}
