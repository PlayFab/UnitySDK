
namespace PlayFab.Internal
{
	public class PlayFabVersion
	{
		public static string SdkRevision = "0.10.151116";

		public static string getVersionString()
		{
			return "UnitySDK-" + SdkRevision;
		}
	}
}

