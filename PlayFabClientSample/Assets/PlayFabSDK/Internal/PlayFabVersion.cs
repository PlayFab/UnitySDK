
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.24.160419";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

