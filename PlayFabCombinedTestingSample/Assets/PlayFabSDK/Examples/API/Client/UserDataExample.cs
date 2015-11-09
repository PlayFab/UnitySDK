using System;
using System.Collections.Generic;

namespace PlayFab.Examples.Client
{
    public static class UserDataExample
    {
        #region Controller Event Handling
        static UserDataExample()
        {
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserLogin, OnUserLogin);
        }

        public static void SetUp()
        {
            // The static constructor is called as a by-product of this call
        }

        private static void OnUserLogin(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            GetUserData();
            GetUserReadOnlyData();
        }
        #endregion Controller Event Handling

        public static void GetUserData()
        {
            var getRequest = new ClientModels.GetUserDataRequest();
            getRequest.PlayFabId = PfSharedModelEx.globalClientUser.playFabId; // You may ask for yourself specifically, any other playFabId you're aware of, or null to default to yourself
            // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
            PlayFabClientAPI.GetUserData(getRequest, GetUserDataCallback, PfSharedControllerEx.FailCallback("GetUserData"));
        }

        private static void GetUserDataCallback(ClientModels.GetUserDataResult result)
        {
            foreach (var eachDataEntry in result.Data)
                PfSharedModelEx.globalClientUser.userData[eachDataEntry.Key] = eachDataEntry.Value.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.globalClientUser.playFabId, null, PfSharedControllerEx.Api.Client, false);
        }

        public static void GetUserReadOnlyData()
        {
            var getRequest = new ClientModels.GetUserDataRequest();
            getRequest.PlayFabId = PfSharedModelEx.globalClientUser.playFabId; // You may ask for yourself specifically, any other playFabId you're aware of, or null to default to yourself
            // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
            PlayFabClientAPI.GetUserReadOnlyData(getRequest, GetUserDataCallback, PfSharedControllerEx.FailCallback("GetUserReadOnlyData"));
        }

        private static void GetUserReadOnlyDataCallback(ClientModels.GetUserDataResult result)
        {
            foreach (var eachDataEntry in result.Data)
                PfSharedModelEx.globalClientUser.userReadOnlyData[eachDataEntry.Key] = eachDataEntry.Value.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.globalClientUser.playFabId, null, PfSharedControllerEx.Api.Client, false);
        }

        public static Action UpdateUserData(string userDataKey, string userDataValue)
        {
            if (string.IsNullOrEmpty(userDataValue))
                userDataValue = null; // Ensure that this field is removed

            Action output = () =>
            {
                var updateRequest = new ClientModels.UpdateUserDataRequest();
                updateRequest.Data[userDataKey] = userDataValue; // Multiple keys accepted, unlike this example, best-use-case modifies all keys at once when possible.

                PlayFabClientAPI.UpdateUserData(updateRequest, UpdateUserDataCallback, PfSharedControllerEx.FailCallback("UpdateUserData"));
            };
            return output;
        }
        private static void UpdateUserDataCallback(ClientModels.UpdateUserDataResult result)
        {
            Dictionary<string, string> dataUpdated = ((ClientModels.UpdateUserDataRequest)result.Request).Data;

            foreach (var dataPair in dataUpdated)
            {
                if (string.IsNullOrEmpty(dataPair.Value))
                    PfSharedModelEx.globalClientUser.userData.Remove(dataPair.Key);
                else
                    PfSharedModelEx.globalClientUser.userData[dataPair.Key] = dataPair.Value;
            }

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataChanged, PfSharedModelEx.globalClientUser.playFabId, null, PfSharedControllerEx.Api.Server, false);
        }
    }
}
