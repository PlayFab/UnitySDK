#if !DISABLE_PLAYFABCLIENT_API
using System.Collections.Generic;
using PlayFab.Json;
using PlayFab.SharedModels;
using UnityEngine;

namespace PlayFab.Internal
{
    public static class PlayFabDeviceUtil
    {
        private static bool _needsAttribution, _gatherDeviceInfo, _gatherScreenTime;

        #region Make Attribution API call
        private static void DoAttributeInstall()
        {
            if (!_needsAttribution || PlayFabSettings.DisableAdvertising)
                return; // Don't send this value to PlayFab if it's not required
            var attribRequest = new ClientModels.AttributeInstallRequest();
            switch (PlayFabSettings.AdvertisingIdType)
            {
                case PlayFabSettings.AD_TYPE_ANDROID_ID: attribRequest.Adid = PlayFabSettings.AdvertisingIdValue; break;
                case PlayFabSettings.AD_TYPE_IDFA: attribRequest.Idfa = PlayFabSettings.AdvertisingIdValue; break;
            }
            PlayFabClientAPI.AttributeInstall(attribRequest, OnAttributeInstall, null);
        }
        private static void OnAttributeInstall(ClientModels.AttributeInstallResult result)
        {
            // This is for internal testing.
            PlayFabSettings.AdvertisingIdType += "_Successful";
        }
        #endregion Make Attribution API call

        #region Scrape Device Info
        private static void SendDeviceInfoToPlayFab()
        {
            if (PlayFabSettings.DisableDeviceInfo || !_gatherDeviceInfo) return;

            var serializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
            var request = new ClientModels.DeviceInfoRequest
            {
                Info = serializer.DeserializeObject<Dictionary<string, object>>(serializer.SerializeObject(new PlayFabDataGatherer()))
            };
            PlayFabClientAPI.ReportDeviceInfo(request, null, OnGatherFail);
        }
        private static void OnGatherFail(PlayFabError error)
        {
            Debug.Log("OnGatherFail: " + error.GenerateErrorReport());
        }
        #endregion

        /// <summary>
        /// When a PlayFab login occurs, check the result information, and
        ///   relay it to _OnPlayFabLogin where the information is used
        /// </summary>
        /// <param name="result"></param>
        public static void OnPlayFabLogin(PlayFabResultCommon result)
        {
            var loginResult = result as ClientModels.LoginResult;
            var registerResult = result as ClientModels.RegisterPlayFabUserResult;
            if (loginResult == null && registerResult == null)
                return;

            // Gather things common to the result types
            ClientModels.UserSettings settingsForUser = null;
            string playFabId = null;
            string entityId = null;
            string entityType = null;

            if (loginResult != null)
            {
                settingsForUser = loginResult.SettingsForUser;
                playFabId = loginResult.PlayFabId;
                if (loginResult.EntityToken != null)
                {
                    entityId = loginResult.EntityToken.Entity.Id;
                    entityType = loginResult.EntityToken.Entity.Type;
                }
            }
            else if (registerResult != null)
            {
                settingsForUser = registerResult.SettingsForUser;
                playFabId = registerResult.PlayFabId;
                if (registerResult.EntityToken != null)
                {
                    entityId = registerResult.EntityToken.Entity.Id;
                    entityType = registerResult.EntityToken.Entity.Type;
                }
            }

            _OnPlayFabLogin(settingsForUser, playFabId, entityId, entityType);
        }

        /// <summary>
        /// Separated from OnPlayFabLogin, to explicitly lose the refs to loginResult and registerResult, because
        ///   only one will be defined, but both usually have all the information we REALLY need here.
        /// But the result signatures are different and clunky, so do the separation above, and processing here
        /// </summary>
        private static void _OnPlayFabLogin(ClientModels.UserSettings settingsForUser, string playFabId, string entityId, string entityType)
        {
            _needsAttribution = _gatherDeviceInfo = _gatherScreenTime = false;
            if (settingsForUser != null)
            {
                _needsAttribution = settingsForUser.NeedsAttribution;
                _gatherDeviceInfo = settingsForUser.GatherDeviceInfo;
                _gatherScreenTime = settingsForUser.GatherFocusInfo;
            }

            // Device attribution (adid or idfa)
            if (PlayFabSettings.AdvertisingIdType != null && PlayFabSettings.AdvertisingIdValue != null)
                DoAttributeInstall();
            else
                GetAdvertIdFromUnity();

            // Device information gathering
            SendDeviceInfoToPlayFab();

#if !DISABLE_PLAYFABENTITY_API
            if (!string.IsNullOrEmpty(entityId) && !string.IsNullOrEmpty(entityType) && _gatherScreenTime)
            {
                PlayFabHttp.InitializeScreenTimeTracker(entityId, entityType, playFabId);
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
