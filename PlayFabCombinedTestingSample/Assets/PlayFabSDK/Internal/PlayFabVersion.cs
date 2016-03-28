
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.21.160328";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

