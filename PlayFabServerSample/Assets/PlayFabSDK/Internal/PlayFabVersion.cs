
namespace PlayFab.Internal
{
	public class PlayFabVersion
	{
		public static string SdkRevision = "0.10.151109";

		public static string getVersionString()
		{
			return "UnitySDK-" + SdkRevision;
		}
	}
}

