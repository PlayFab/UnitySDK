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
        private static void DoAttributeInstall(PlayFabApiSettings settings, IPlayFabInstanceApi instanceApi)
        {
            if (!_needsAttribution || settings.DisableAdvertising)
                return; // Don't send this value to PlayFab if it's not required
            var attribRequest = new ClientModels.AttributeInstallRequest();
            switch (settings.AdvertisingIdType)
            {
                case PlayFabSettings.AD_TYPE_ANDROID_ID: attribRequest.Adid = settings.AdvertisingIdValue; break;
                case PlayFabSettings.AD_TYPE_IDFA: attribRequest.Idfa = settings.AdvertisingIdValue; break;
            }
            var clientInstanceApi = instanceApi as PlayFabClientInstanceAPI;
            if (clientInstanceApi != null)
                clientInstanceApi.AttributeInstall(attribRequest, OnAttributeInstall, null, settings);
            else
                PlayFabClientAPI.AttributeInstall(attribRequest, OnAttributeInstall, null, settings);
        }
        private static void OnAttributeInstall(ClientModels.AttributeInstallResult result)
        {
            var settings = (PlayFabApiSettings)result.CustomData;
            // This is for internal testing.
            settings.AdvertisingIdType += "_Successful";
        }
        #endregion Make Attribution API call

        #region Scrape Device Info
        private static void SendDeviceInfoToPlayFab(PlayFabApiSettings settings, IPlayFabInstanceApi instanceApi)
        {
            if (settings.DisableDeviceInfo || !_gatherDeviceInfo) return;

            var serializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
            var request = new ClientModels.DeviceInfoRequest
            {
                Info = serializer.DeserializeObject<Dictionary<string, object>>(serializer.SerializeObject(new PlayFabDataGatherer()))
            };
            var clientInstanceApi = instanceApi as PlayFabClientInstanceAPI;
            if (clientInstanceApi != null)
                clientInstanceApi.ReportDeviceInfo(request, null, OnGatherFail, settings);
            else
                PlayFabClientAPI.ReportDeviceInfo(request, null, OnGatherFail, settings);
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
        public static void OnPlayFabLogin(PlayFabResultCommon result, PlayFabApiSettings settings, IPlayFabInstanceApi instanceApi)
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

            _OnPlayFabLogin(settingsForUser, playFabId, entityId, entityType, settings, instanceApi);
        }

        /// <summary>
        /// Separated from OnPlayFabLogin, to explicitly lose the refs to loginResult and registerResult, because
        ///   only one will be defined, but both usually have all the information we REALLY need here.
        /// But the result signatures are different and clunky, so do the separation above, and processing here
        /// </summary>
        private static void _OnPlayFabLogin(ClientModels.UserSettings settingsForUser, string playFabId, string entityId, string entityType, PlayFabApiSettings settings, IPlayFabInstanceApi instanceApi)
        {
            _needsAttribution = _gatherDeviceInfo = _gatherScreenTime = false;
            if (settingsForUser != null)
            {
                _needsAttribution = settingsForUser.NeedsAttribution;
                _gatherDeviceInfo = settingsForUser.GatherDeviceInfo;
                _gatherScreenTime = settingsForUser.GatherFocusInfo;
            }

            // Device attribution (adid or idfa)
            if (settings.AdvertisingIdType != null && settings.AdvertisingIdValue != null)
                DoAttributeInstall(settings, instanceApi);
            else
                GetAdvertIdFromUnity(settings, instanceApi);

            // Device information gathering
            SendDeviceInfoToPlayFab(settings, instanceApi);

#if !DISABLE_PLAYFABENTITY_API
            if (!string.IsNullOrEmpty(entityId) && !string.IsNullOrEmpty(entityType) && _gatherScreenTime)
            {
                PlayFabHttp.InitializeScreenTimeTracker(entityId, entityType, playFabId);
            }
            else
            {
                settings.DisableFocusTimeCollection = true;
            }
#endif
        }

        private static void GetAdvertIdFromUnity(PlayFabApiSettings settings, IPlayFabInstanceApi instanceApi)
        {
#if UNITY_5_3_OR_NEWER && (UNITY_ANDROID || UNITY_IOS) && (!UNITY_EDITOR || TESTING)
            Application.RequestAdvertisingIdentifierAsync(
                (advertisingId, trackingEnabled, error) =>
                {
                    settings.DisableAdvertising = !trackingEnabled;
                    if (!trackingEnabled)
                        return;
#if UNITY_ANDROID
                    settings.AdvertisingIdType = PlayFabSettings.AD_TYPE_ANDROID_ID;
#elif UNITY_IOS
                    settings.AdvertisingIdType = PlayFabSettings.AD_TYPE_IDFA;
#endif
                    settings.AdvertisingIdValue = advertisingId;
                    DoAttributeInstall(settings, instanceApi);
                }
            );
#endif
        }
    }
}
#endif
