#if !DISABLE_PLAYFABCLIENT_API
using PlayFab.ClientModels;
using PlayFab.SharedModels;
using PlayFab.Json;
using UnityEngine;
using System.Collections.Generic;

namespace PlayFab.Internal
{
    public static class PlayFabDeviceUtil
    {
        private static bool _needsAttribution, _gatherInfo, _gatherScreenTime;

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
        private static void SendDeviceInfoToPlayFab()
        {
            if (PlayFabSettings.DisableDeviceInfo || !_gatherInfo) return;

            var request = new DeviceInfoRequest
            {
                Info = JsonWrapper.DeserializeObject<Dictionary<string, object>>(JsonWrapper.SerializeObject(new PlayFabDataGatherer()))
            };
            PlayFabClientAPI.ReportDeviceInfo(request, OnGatherSuccess, OnGatherFail);
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

            _needsAttribution = _gatherInfo = _gatherScreenTime = false;
            if (loginResult != null && loginResult.SettingsForUser != null)
                _needsAttribution = loginResult.SettingsForUser.NeedsAttribution;
            else if (registerResult != null && registerResult.SettingsForUser != null)
                _needsAttribution = registerResult.SettingsForUser.NeedsAttribution;
            if (loginResult != null && loginResult.SettingsForUser != null)
                _gatherInfo = loginResult.SettingsForUser.GatherDeviceInfo;
            else if (registerResult != null && registerResult.SettingsForUser != null)
                _gatherInfo = registerResult.SettingsForUser.GatherDeviceInfo;
            if (loginResult != null && loginResult.SettingsForUser != null)
                _gatherScreenTime = loginResult.SettingsForUser.GatherFocusInfo;
            else if (registerResult != null && registerResult.SettingsForUser != null)
                _gatherScreenTime = registerResult.SettingsForUser.GatherFocusInfo;

            // Device attribution (adid or idfa)
            if (PlayFabSettings.AdvertisingIdType != null && PlayFabSettings.AdvertisingIdValue != null)
                DoAttributeInstall();
            else
                GetAdvertIdFromUnity();

            // Device information gathering
            SendDeviceInfoToPlayFab();

#if ENABLE_PLAYFABENTITY_API
            string playFabUserId = loginResult.PlayFabId;
            EntityModels.EntityKey entityKey = new EntityModels.EntityKey();
            if (loginResult.EntityToken != null && _gatherScreenTime)
            {
                entityKey.Id = loginResult.EntityToken.Entity.Id;
                entityKey.Type = (PlayFab.EntityModels.EntityTypes)(int)loginResult.EntityToken.Entity.Type; // possible loss of data 
                entityKey.TypeString = loginResult.EntityToken.Entity.TypeString;

                PlayFabHttp.InitializeScreenTimeTracker(entityKey, playFabUserId);
            }
            else
            {
                PlayFabSettings.DisableFocusTimeCollection = true;
            }
#endif
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
