
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.22.160411";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

