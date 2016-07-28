#if !DISABLE_PLAYFABCLIENT_API
using PlayFab.ClientModels;
using UnityEngine;

namespace PlayFab.Internal
{
    public static class PlayFabIdfa
    {

#if DISABLE_IDFA || (!UNITY_IOS && !UNITY_ANDROID)
        public static void OnPlayFabLogin()
        {
            // Do nothing because we're not applying device advertising id
        }
#elif (!UNITY_5_3 && !UNITY_5_4) // This section for 5.3 or newer
        public static void OnPlayFabLogin()
        {
            // TODO: Restore the old Pre-V2 plugin which extracted these ids (RequestAdvertisingIdentifierAsync doesn't exist)
        }
#else
        public static void OnPlayFabLogin()
        {
            Application.RequestAdvertisingIdentifierAsync(
                (advertisingId, trackingEnabled, error) =>
                {
                    if (!trackingEnabled)
                        return;

                    var attribRequest = new AttributeInstallRequest();
#if UNITY_ANDROID
                    attribRequest.Android_Id = advertisingId;
#elif UNITY_IOS
                    attribRequest.Idfa = advertisingId;
#endif
                    PlayFabClientAPI.AttributeInstall(attribRequest, OnAttributeInstall, null);
                }
            );
        }

        public static void OnAttributeInstall(AttributeInstallResult result)
        {
            // This is for internal testing tools.
            PlayFabSettings.AdvertisingIdType += "_Successful";
        }
#endif
    }
}
#endif
