
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

	public class PlayFabSettings
	{
		public static bool UseDevelopmentEnvironment = false;
		public static string DevelopmentEnvironmentURL = "https://api.playfabdev.com";
		public static string ProductionEnvironmentURL = "https://api.playfab.com";
		public static string TitleId = null;
		public static PlayFabLogLevel LogLevel = PlayFabLogLevel.Warning | PlayFabLogLevel.Error;
		public static ErrorCallback GlobalErrorHandler  { get; set; }

		public static string GetURL()
		{
			return UseDevelopmentEnvironment ? DevelopmentEnvironmentURL : ProductionEnvironmentURL;
		}
	}
}