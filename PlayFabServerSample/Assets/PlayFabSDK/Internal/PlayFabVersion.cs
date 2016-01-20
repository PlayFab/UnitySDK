
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.13.151210";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

