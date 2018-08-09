#if !DISABLE_PLAYFABCLIENT_API
using PlayFab.ClientModels;
using UnityEngine;

namespace PlayFab.Internal
{
    public static class PlayFabIdfa
    {
        static PlayFabIdfa() { }

        public static void DoAttributeInstall()
        {
            var attribRequest = new AttributeInstallRequest();
            switch (PlayFabSettings.AdvertisingIdType)
            {
                case PlayFabSettings.AD_TYPE_ANDROID_ID: attribRequest.Adid = PlayFabSettings.AdvertisingIdValue; break;
                case PlayFabSettings.AD_TYPE_IDFA: attribRequest.Idfa = PlayFabSettings.AdvertisingIdValue; break;
            }
            PlayFabClientAPI.AttributeInstall(attribRequest, OnAttributeInstall, null);
        }

        private static void OnAttributeInstall(AttributeInstallResult result)
        {
            // This is for internal testing.
            PlayFabSettings.AdvertisingIdType += "_Successful";
        }

#if DISABLE_IDFA || (!UNITY_IOS && !UNITY_ANDROID)
        public static void OnPlayFabLogin()
        {
            if (!PlayFabSettings.DisableAdvertising && PlayFabSettings.AdvertisingIdType != null && PlayFabSettings.AdvertisingIdValue != null)
                DoAttributeInstall();
        }
#elif (!UNITY_5_3 && !UNITY_5_4 && !UNITY_5_5 && !UNITY_5_6) // This section for 5.3 or newer
        public static void OnPlayFabLogin()
        {
            if (PlayFabSettings.DisableAdvertising)
                return;
            if (PlayFabSettings.AdvertisingIdType != null && PlayFabSettings.AdvertisingIdValue != null)
                DoAttributeInstall();
            // else
                // TODO: Restore the old Pre-V2 plugin which extracted these ids (RequestAdvertisingIdentifierAsync doesn't exist)
        }
#else
        public static void OnPlayFabLogin()
        {
            if (PlayFabSettings.DisableAdvertising)
                return;
            if (PlayFabSettings.AdvertisingIdType != null && PlayFabSettings.AdvertisingIdValue != null)
                DoAttributeInstall();
            else
                GetAdvertIdFromUnity();
        }

        private static void GetAdvertIdFromUnity()
        {
            Application.RequestAdvertisingIdentifierAsync(
                (advertisingId, trackingEnabled, error) =>
                {
                    PlayFabSettings.DisableAdvertising = !trackingEnabled;
                    if (!trackingEnabled)
                        return;
#if UNITY_ANDROID
                    PlayFabSettings.AdvertisingIdType = PlayFabSettings.AD_TYPE_ANDROID_ID;
#elif UNITY_IOS
                    PlayFabSettings.AdvertisingIdType = PlayFabSettings.AD_TYPE_IDFA;
#endif
                    PlayFabSettings.AdvertisingIdValue = advertisingId;
                    DoAttributeInstall();
                }
            );
        }
#endif
    }
}
#endif
