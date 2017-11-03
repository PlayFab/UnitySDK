#if !DISABLE_PLAYFABCLIENT_API
using PlayFab.ClientModels;
using PlayFab.SharedModels;
using UnityEngine;

namespace PlayFab.Internal
{
    public static class PlayFabDeviceUtil
    {
        private static bool _needsAttribution;
        private static bool _gatherInfo;

        #region Make Attribution API call
        private static void DoAttributeInstall()
        {
            if (!_needsAttribution || PlayFabSettings.DisableAdvertising)
                return; // Don't send this value to PlayFab if it's not required
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
        #endregion Make Attribution API call

        #region Scrape Device Info
        private class DeviceInfoRequest : PlayFabRequestCommon
        {
            public PlayFabDataGatherer Info;
        }

        private static void SendDeviceInfoToPlayFab()
        {
            if (PlayFabSettings.DisableDeviceInfo || !_gatherInfo) return;

            var request = new DeviceInfoRequest
            {
                Info = new PlayFabDataGatherer()
            };
            PlayFabHttp.MakeApiCall<EmptyResult>("/Client/ReportDeviceInfo", request, AuthType.LoginSession, OnGatherSuccess, OnGatherFail);
        }
        private static void OnGatherSuccess(EmptyResult result)
        {
            Debug.Log("OnGatherSuccess");
        }
        private static void OnGatherFail(PlayFabError error)
        {
            Debug.Log("OnGatherFail: " + error.GenerateErrorReport());
        }
        #endregion

        public static void OnPlayFabLogin(PlayFabResultCommon result)
        {
            var loginResult = result as LoginResult;
            var registerResult = result as RegisterPlayFabUserResult;
            if (loginResult == null && registerResult == null)
                return;

            _needsAttribution = false;
            _gatherInfo = false;
            if (loginResult != null && loginResult.SettingsForUser != null)
                _needsAttribution = loginResult.SettingsForUser.NeedsAttribution;
            else if (registerResult != null && registerResult.SettingsForUser != null)
                _needsAttribution = registerResult.SettingsForUser.NeedsAttribution;
            if (loginResult != null && loginResult.SettingsForUser != null)
                _gatherInfo = loginResult.SettingsForUser.GatherDeviceInfo;
            else if (registerResult != null && registerResult.SettingsForUser != null)
                _gatherInfo = registerResult.SettingsForUser.GatherDeviceInfo;

            // Device attribution (adid or idfa)
            if (PlayFabSettings.AdvertisingIdType != null && PlayFabSettings.AdvertisingIdValue != null)
                DoAttributeInstall();
            else
                GetAdvertIdFromUnity();

            // Device information gathering
            SendDeviceInfoToPlayFab();
        }

        private static void GetAdvertIdFromUnity()
        {
#if UNITY_5_3_OR_NEWER && (UNITY_ANDROID || UNITY_IOS) && (!UNITY_EDITOR || TESTING)
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
#endif
        }
    }
}
#endif
