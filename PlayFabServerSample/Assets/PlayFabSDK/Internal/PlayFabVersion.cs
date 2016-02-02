
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.16.160201";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

