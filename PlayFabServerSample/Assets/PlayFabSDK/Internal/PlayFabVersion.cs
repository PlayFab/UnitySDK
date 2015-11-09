
namespace PlayFab.Internal
{
	public class PlayFabVersion
	{
		public static string ApiRevision = "1.9.20151109";
		public static string SdkRevision = "0.9.151109";

		public static string getVersionString()
		{
			return "UnitySDK-" + SdkRevision + "-" + ApiRevision;
		}
	}
}

