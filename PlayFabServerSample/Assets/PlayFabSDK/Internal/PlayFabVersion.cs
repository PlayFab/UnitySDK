
namespace PlayFab.Internal
{
	public class PlayFabVersion
	{
		public static string SdkRevision = "0.11.151123";

		public static string getVersionString()
		{
			return "UnitySDK-" + SdkRevision;
		}
	}
}

