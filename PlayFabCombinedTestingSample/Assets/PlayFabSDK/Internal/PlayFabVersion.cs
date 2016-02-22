
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.19.160222";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

