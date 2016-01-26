
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.15.160125";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

