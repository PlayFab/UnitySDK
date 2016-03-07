
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.20.160307";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

