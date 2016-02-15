
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.18.160215";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

