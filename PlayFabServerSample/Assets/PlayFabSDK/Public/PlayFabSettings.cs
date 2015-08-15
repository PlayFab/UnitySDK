
namespace PlayFab
{
	public enum PlayFabLogLevel
	{
		None    = 0,
		Debug   = 1,
		Info    = 2,
		Warning = 4,
		Error   = 8,
		All     = Debug | Info | Warning | Error,
	}

    public enum WebRequestType
    {
        UnityWWW,
        HttpWebRequest
    }

	public class PlayFabSettings
	{
		public static string ProductionEnvironmentURL = ".playfabapi.com";
		public static string LogicServerURL = null;
		public static string TitleId = null;
		public static PlayFabLogLevel LogLevel = PlayFabLogLevel.Warning | PlayFabLogLevel.Error;
        public static bool IsTesting = false;
        public static WebRequestType RequestType = WebRequestType.UnityWWW;
        public static int RequestTimeout = 2000;
        public static bool RequestKeepAlive = true;
        public static string DeveloperSecretKey = null;

		public static ErrorCallback GlobalErrorHandler  { get; set; }

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
		
		public static string GetLogicURL()
		{
			return LogicServerURL;
		}
	}
}
