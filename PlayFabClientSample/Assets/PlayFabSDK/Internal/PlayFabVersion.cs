
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.26.160502";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

