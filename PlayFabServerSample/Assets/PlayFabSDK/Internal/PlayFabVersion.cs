
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.17.160208";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

