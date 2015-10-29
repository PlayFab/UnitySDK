using System;
using UnityEngine;

namespace PlayFab.Examples.Server
{
    public static class TitleDataExample
    {
        #region Controller Event Handling
        static TitleDataExample()
        {
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserLogin, OnUserLogin);
        }

        public static void SetUp()
        {
            // The static constructor is called as a by-product of this call
        }

        private static void OnUserLogin(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            GetTitleData();
            GetTitleInternalData();
        }
        #endregion Controller Event Handling

        public static void GetTitleData()
        {
            var getRequest = new ServerModels.GetTitleDataRequest();
            // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
            PlayFabServerAPI.GetTitleData(getRequest, GetTitleDataCallback, PfSharedControllerEx.FailCallback("GetTitleData"));
        }
        private static void GetTitleDataCallback(ServerModels.GetTitleDataResult result)
        {
            foreach (var eachTitleEntry in result.Data)
                PfSharedModelEx.serverTitleData[eachTitleEntry.Key] = eachTitleEntry.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnTitleDataLoaded, null, null, PfSharedControllerEx.Api.Server, false);
        }

        public static void GetTitleInternalData()
        {
            var getRequest = new ServerModels.GetTitleDataRequest();
            // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
            PlayFabServerAPI.GetTitleInternalData(getRequest, GetInternalTitleDataCallback, PfSharedControllerEx.FailCallback("GetTitleInternalData"));
        }
        private static void GetInternalTitleDataCallback(ServerModels.GetTitleDataResult result)
        {
            foreach (var eachTitleEntry in result.Data)
                PfSharedModelEx.serverInternalTitleData[eachTitleEntry.Key] = eachTitleEntry.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInternalTitleDataLoaded, null, null, PfSharedControllerEx.Api.Server, false);
        }

        public static Action SetTitleData(string titleDataKey, string titleDataValue, bool internalData = false)
        {
            if (string.IsNullOrEmpty(titleDataValue))
                titleDataValue = null; // Ensure that this field is removed

            Action output = () =>
            {
                // This api-call updates one titleData key at a time.
                // You can remove a key by setting the value to null.
                var updateRequest = new ServerModels.SetTitleDataRequest();
                updateRequest.Key = titleDataKey;
                updateRequest.Value = titleDataValue;

                if (internalData)
                    PlayFabServerAPI.SetTitleInternalData(updateRequest, SetInternalTitleDataCallback, PfSharedControllerEx.FailCallback("SetTitleInternalData"));
                else
                    PlayFabServerAPI.SetTitleData(updateRequest, SetTitleDataCallback, PfSharedControllerEx.FailCallback("SetTitleData"));
            };
            return output;
        }
        private static void SetTitleDataCallback(ServerModels.SetTitleDataResult result)
        {
            string dataKey = ((ServerModels.SetTitleDataRequest)result.Request).Key;
            string dataValue = ((ServerModels.SetTitleDataRequest)result.Request).Value;

            if (string.IsNullOrEmpty(dataValue))
            {
                PfSharedModelEx.serverTitleData.Remove(dataKey);
                PfSharedModelEx.clientTitleData.Remove(dataKey); // Make the same modification to client, since it's mirrored there
            }
            else
            {
                PfSharedModelEx.serverTitleData[dataKey] = dataValue;
                PfSharedModelEx.clientTitleData[dataKey] = dataValue; // Make the same modification to client, since it's mirrored there
            }

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnTitleDataChanged, null, null, PfSharedControllerEx.Api.Server, false);
        }
        private static void SetInternalTitleDataCallback(ServerModels.SetTitleDataResult result)
        {
            string dataKey = ((ServerModels.SetTitleDataRequest)result.Request).Key;
            string dataValue = ((ServerModels.SetTitleDataRequest)result.Request).Value;

            if (string.IsNullOrEmpty(dataValue))
                PfSharedModelEx.serverInternalTitleData.Remove(dataKey);
            else
                PfSharedModelEx.serverInternalTitleData[dataKey] = dataValue;

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnTitleDataChanged, null, null, PfSharedControllerEx.Api.Server, false);
        }
    }
}
