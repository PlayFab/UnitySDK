
namespace PlayFab.Internal
{
	public class PlayFabVersion
	{
		public static string ApiRevision = "1.4.20150806";
		public static string SdkRevision = "1.0.6";

		public static string getVersionString()
		{
			return "UnitySDK-" + SdkRevision + "-" + ApiRevision;
		}
	}
}

