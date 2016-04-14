
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.23.160414";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

