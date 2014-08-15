
namespace PlayFab.Internal
{
	public class PlayFabVersion
	{
		public static string ApiRevision = "1.0.0.b6";
		public static string SdkRevision = "1.0.3";

		public static string getVersionString()
		{
			return "UnitySDK-" + SdkRevision + "-" + ApiRevision;
		}
	}
}

