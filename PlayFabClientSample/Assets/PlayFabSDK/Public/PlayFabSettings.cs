
namespace PlayFab
{
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
        UnityWWW,
        HttpWebRequest
    }

    public class PlayFabSettings
    {
        public static ErrorCallback GlobalErrorHandler { get; set; }

        public static string ProductionEnvironmentURL = ".playfabapi.com";
        public static string TitleId = null; // You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website)
        public static PlayFabLogLevel LogLevel = PlayFabLogLevel.Warning | PlayFabLogLevel.Error;
        public static bool IsTesting = false;
        public static WebRequestType RequestType = WebRequestType.UnityWWW;
        public static int RequestTimeout = 2000;
        public static bool RequestKeepAlive = true;
        internal static string LogicServerURL = null; // Assigned by GetCloudScriptUrl, used by RunCloudScript
        public static string AdvertisingIdType = null; // Set this to the appropriate AD_TYPE_X constant below
        public static string AdvertisingIdValue = null; // Set this to corresponding device value

        // DisableAdvertising is provided for completeness, but changing it is not suggested
        // Disabling this may prevent your advertising-related PlayFab marketplace partners from working correctly
        public static bool DisableAdvertising = false;
        public static readonly string AD_TYPE_IDFA = "Idfa";
        public static readonly string AD_TYPE_ANDROID_ID = "Android_Id";

        public static string GetLogicURL()
        {
            return LogicServerURL;
        }

        public static string GetURL()
        {
            if (!IsTesting)
            {
                string baseUrl = ProductionEnvironmentURL;
                if (baseUrl.StartsWith("http"))
                    return baseUrl;
                return "https://" + TitleId + baseUrl;
            }
            else
            {
                return "http://localhost:11289/";
            }
        }
    }
}
