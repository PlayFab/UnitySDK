
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkRevision = "0.14.160118";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkRevision;
        }
    }
}

