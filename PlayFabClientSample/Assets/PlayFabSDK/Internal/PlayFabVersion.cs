
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.25.160425";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

