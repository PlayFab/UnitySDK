using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PlayFab
{
    public enum WebRequestType
    {
        UnityWww, // High compatability Unity api calls
        HttpWebRequest, // High performance multi-threaded api calls
        UnityWebRequest, // Modern unity HTTP component
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
        public const string SdkVersion = "2.58.181218";
        public const string BuildIdentifier = "jbuild_unitysdk__sdk-unity-5-slave_0";
        public const string VersionString = "UnitySDK-2.58.181218";

        public static readonly Dictionary<string, string> RequestGetParams = new Dictionary<string, string> {
            { "sdk", VersionString }
        };

        private const string DefaultPlayFabApiUrlPrivate = ".playfabapi.com";

        private static PlayFabSharedSettings GetSharedSettingsObjectPrivate()
        {
            var settingsList = Resources.LoadAll<PlayFabSharedSettings>("PlayFabSharedSettings");
            if (settingsList.Length != 1)
            {
                throw new Exception("The number of PlayFabSharedSettings objects should be 1: " + settingsList.Length);
            }
            return settingsList[0];
        }

#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || UNITY_EDITOR
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

        // You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website)
        public static string TitleId
        {
            get { return PlayFabSharedPrivate.TitleId; }
            set { PlayFabSharedPrivate.TitleId = value; }
        }
        
        public static string VerticalName
        {
            get { return PlayFabSharedPrivate.VerticalName; }
            set { PlayFabSharedPrivate.VerticalName = value; }
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

        public static string GetFullUrl(string apiCall, Dictionary<string, string> getParams)
        {
            StringBuilder sb = new StringBuilder(1000);
        
            var baseUrl = ProductionEnvironmentUrlPrivate;
            if (!baseUrl.StartsWith("http"))
            {
                if (!string.IsNullOrEmpty(VerticalName))
                {
                    sb.Append("https://").Append(VerticalName);
                }
                else
                {
                    sb.Append("https://").Append(TitleId);
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
