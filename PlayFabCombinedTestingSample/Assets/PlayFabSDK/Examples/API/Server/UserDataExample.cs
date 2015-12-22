using System;
using System.Collections.Generic;

namespace PlayFab.Examples.Server
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
            GetUserData(playFabId)();
            GetUserReadOnlyData(playFabId)();
            GetUserInternalData(playFabId)();

            GetUserPublisherData(playFabId)();
            GetUserPublisherReadOnlyData(playFabId)();
            GetUserPublisherInternalData(playFabId)();
        }
        #endregion Controller Event Handling

        #region UserData - Data attached directly to the user for this title
        public static Action GetUserData(string playFabId)
        {
            Action output = () =>
            {
                var getRequest = new ServerModels.GetUserDataRequest();
                getRequest.PlayFabId = playFabId;
                // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
                PlayFabServerAPI.GetUserData(getRequest, GetUserDataCallback,
                    PfSharedControllerEx.FailCallback("GetUserData"));
            };
            return output;
        }
        private static void GetUserDataCallback(ServerModels.GetUserDataResult result)
        {
            string playFabId = result.PlayFabId;

            foreach (var eachUserEntry in result.Data)
                PfSharedModelEx.serverUsers[playFabId].userData[eachUserEntry.Key] = eachUserEntry.Value.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, null, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static Action GetUserReadOnlyData(string playFabId)
        {
            Action output = () =>
            {
                var getRequest = new ServerModels.GetUserDataRequest();
                getRequest.PlayFabId = playFabId;
                // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
                PlayFabServerAPI.GetUserReadOnlyData(getRequest, GetUserReadOnlyDataCallback, PfSharedControllerEx.FailCallback("GetUserReadOnlyData"));
            };
            return output;
        }
        private static void GetUserReadOnlyDataCallback(ServerModels.GetUserDataResult result)
        {
            string playFabId = result.PlayFabId;

            foreach (var eachUserEntry in result.Data)
                PfSharedModelEx.serverUsers[playFabId].userReadOnlyData[eachUserEntry.Key] = eachUserEntry.Value.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, null, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static Action GetUserInternalData(string playFabId)
        {
            Action output = () =>
            {
                var getRequest = new ServerModels.GetUserDataRequest();
                getRequest.PlayFabId = playFabId;
                // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
                PlayFabServerAPI.GetUserInternalData(getRequest, GetInternalUserDataCallback, PfSharedControllerEx.FailCallback("GetUserInternalData"));
            };
            return output;
        }
        private static void GetInternalUserDataCallback(ServerModels.GetUserDataResult result)
        {
            string playFabId = result.PlayFabId;

            foreach (var eachUserEntry in result.Data)
                PfSharedModelEx.serverUsers[playFabId].userInternalData[eachUserEntry.Key] = eachUserEntry.Value.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, null, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static Action UpdateUserData(string playFabId, string userDataKey, string userDataValue)
        {
            if (string.IsNullOrEmpty(userDataValue))
                userDataValue = null; // Ensure that this field is removed

            Action output = () =>
            {
                var updateRequest = new ServerModels.UpdateUserDataRequest();
                updateRequest.PlayFabId = playFabId;
                updateRequest.Data = new Dictionary<string, string>();
                updateRequest.Data[userDataKey] = userDataValue; // Multiple keys accepted, unlike this example, best-use-case modifies all keys at once when possible.

                PlayFabServerAPI.UpdateUserData(updateRequest, UpdateUserDataCallback, PfSharedControllerEx.FailCallback("UpdateUserData"));
            };
            return output;
        }
        private static void UpdateUserDataCallback(ServerModels.UpdateUserDataResult result)
        {
            string playFabId = ((ServerModels.UpdateUserDataRequest)result.Request).PlayFabId;
            Dictionary<string, string> dataUpdated = ((ServerModels.UpdateUserDataRequest)result.Request).Data;

            foreach (var dataPair in dataUpdated)
            {
                if (string.IsNullOrEmpty(dataPair.Value))
                    PfSharedModelEx.serverUsers[playFabId].userData.Remove(dataPair.Key);
                else
                    PfSharedModelEx.serverUsers[playFabId].userData[dataPair.Key] = dataPair.Value;
            }

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataChanged, playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static Action UpdateReadOnlyUserData(string playFabId, string userDataKey, string userDataValue)
        {
            if (string.IsNullOrEmpty(userDataValue))
                userDataValue = null; // Ensure that this field is removed

            Action output = () =>
            {
                var updateReadOnlyRequest = new ServerModels.UpdateUserDataRequest();
                updateReadOnlyRequest.PlayFabId = playFabId;
                updateReadOnlyRequest.Data = new Dictionary<string, string>();
                updateReadOnlyRequest.Data[userDataKey] = userDataValue; // Multiple keys accepted, unlike this example, best-use-case modifies all keys at once when possible.

                PlayFabServerAPI.UpdateUserReadOnlyData(updateReadOnlyRequest, UpdateReadOnlyUserDataCallback, PfSharedControllerEx.FailCallback("UpdateUserReadOnlyData"));
            };
            return output;
        }
        private static void UpdateReadOnlyUserDataCallback(ServerModels.UpdateUserDataResult result)
        {
            string playFabId = ((ServerModels.UpdateUserDataRequest)result.Request).PlayFabId;
            Dictionary<string, string> dataUpdated = ((ServerModels.UpdateUserDataRequest)result.Request).Data;

            foreach (var dataPair in dataUpdated)
            {
                if (string.IsNullOrEmpty(dataPair.Value))
                    PfSharedModelEx.serverUsers[playFabId].userReadOnlyData.Remove(dataPair.Key);
                else
                    PfSharedModelEx.serverUsers[playFabId].userReadOnlyData[dataPair.Key] = dataPair.Value;
            }

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataChanged, playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static Action UpdateInternalUserData(string playFabId, string userDataKey, string userDataValue)
        {
            if (string.IsNullOrEmpty(userDataValue))
                userDataValue = null; // Ensure that this field is removed

            Action output = () =>
            {
                var updateInternalRequest = new ServerModels.UpdateUserInternalDataRequest();
                updateInternalRequest.PlayFabId = playFabId;
                updateInternalRequest.Data = new Dictionary<string, string>();
                updateInternalRequest.Data[userDataKey] = userDataValue; // Multiple keys accepted, unlike this example, best-use-case modifies all keys at once when possible.

                PlayFabServerAPI.UpdateUserInternalData(updateInternalRequest, UpdateInternalUserDataCallback, PfSharedControllerEx.FailCallback("UpdateUserInternalData"));
            };
            return output;
        }
        private static void UpdateInternalUserDataCallback(ServerModels.UpdateUserDataResult result)
        {
            string playFabId = ((ServerModels.UpdateUserInternalDataRequest)result.Request).PlayFabId;
            Dictionary<string, string> dataUpdated = ((ServerModels.UpdateUserInternalDataRequest)result.Request).Data;

            foreach (var dataPair in dataUpdated)
            {
                if (string.IsNullOrEmpty(dataPair.Value))
                    PfSharedModelEx.serverUsers[playFabId].userInternalData.Remove(dataPair.Key);
                else
                    PfSharedModelEx.serverUsers[playFabId].userInternalData[dataPair.Key] = dataPair.Value;
            }

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataChanged, playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }
        #endregion UserData - Data attached directly to the user for this title

        #region UserPublisherData - Data attached directly to the user across all titles for this publisher
        public static Action GetUserPublisherData(string playFabId)
        {
            Action output = () =>
            {
                var getRequest = new ServerModels.GetUserDataRequest();
                getRequest.PlayFabId = playFabId;
                // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
                PlayFabServerAPI.GetUserPublisherData(getRequest, GetUserPublisherDataCallback, PfSharedControllerEx.FailCallback("GetUserPublisherData"));
            };
            return output;
        }
        private static void GetUserPublisherDataCallback(ServerModels.GetUserDataResult result)
        {
            string playFabId = result.PlayFabId;

            foreach (var eachUserPublisherEntry in result.Data)
                PfSharedModelEx.serverUsers[playFabId].userPublisherData[eachUserPublisherEntry.Key] = eachUserPublisherEntry.Value.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, null, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static Action GetUserPublisherReadOnlyData(string playFabId)
        {
            Action output = () =>
            {
                var getRequest = new ServerModels.GetUserDataRequest();
                getRequest.PlayFabId = playFabId;
                // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
                PlayFabServerAPI.GetUserPublisherReadOnlyData(getRequest, GetUserPublisherReadOnlyDataCallback, PfSharedControllerEx.FailCallback("GetUserPublisherReadOnlyData"));
            };
            return output;
        }
        private static void GetUserPublisherReadOnlyDataCallback(ServerModels.GetUserDataResult result)
        {
            string playFabId = result.PlayFabId;

            foreach (var eachUserPublisherEntry in result.Data)
                PfSharedModelEx.serverUsers[playFabId].userPublisherReadOnlyData[eachUserPublisherEntry.Key] = eachUserPublisherEntry.Value.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, null, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static Action GetUserPublisherInternalData(string playFabId)
        {
            Action output = () =>
            {
                var getRequest = new ServerModels.GetUserDataRequest();
                getRequest.PlayFabId = playFabId;
                // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
                PlayFabServerAPI.GetUserPublisherInternalData(getRequest, GetInternalUserPublisherDataCallback, PfSharedControllerEx.FailCallback("GetUserPublisherInternalData"));
            };
            return output;
        }
        private static void GetInternalUserPublisherDataCallback(ServerModels.GetUserDataResult result)
        {
            string playFabId = result.PlayFabId;

            foreach (var eachUserPublisherEntry in result.Data)
                PfSharedModelEx.serverUsers[playFabId].userPublisherInternalData[eachUserPublisherEntry.Key] = eachUserPublisherEntry.Value.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, null, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static Action UpdateUserPublisherData(string playFabId, string userPublisherDataKey, string userPublisherDataValue)
        {
            if (string.IsNullOrEmpty(userPublisherDataValue))
                userPublisherDataValue = null; // Ensure that this field is removed

            Action output = () =>
            {
                var updateRequest = new ServerModels.UpdateUserDataRequest();
                updateRequest.PlayFabId = playFabId;
                updateRequest.Data = new Dictionary<string, string>();
                updateRequest.Data[userPublisherDataKey] = userPublisherDataValue; // Multiple keys accepted, unlike this example, best-use-case modifies all keys at once when possible.

                PlayFabServerAPI.UpdateUserPublisherData(updateRequest, UpdateUserPublisherDataCallback, PfSharedControllerEx.FailCallback("UpdateUserPublisherData"));
            };
            return output;
        }
        private static void UpdateUserPublisherDataCallback(ServerModels.UpdateUserDataResult result)
        {
            string playFabId = ((ServerModels.UpdateUserDataRequest)result.Request).PlayFabId;
            Dictionary<string, string> dataUpdated = ((ServerModels.UpdateUserDataRequest)result.Request).Data;

            foreach (var dataPair in dataUpdated)
            {
                if (string.IsNullOrEmpty(dataPair.Value))
                    PfSharedModelEx.serverUsers[playFabId].userPublisherData.Remove(dataPair.Key);
                else
                    PfSharedModelEx.serverUsers[playFabId].userPublisherData[dataPair.Key] = dataPair.Value;
            }

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataChanged, playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static Action UpdateReadOnlyUserPublisherData(string playFabId, string userPublisherDataKey, string userPublisherDataValue)
        {
            if (string.IsNullOrEmpty(userPublisherDataValue))
                userPublisherDataValue = null; // Ensure that this field is removed

            Action output = () =>
            {
                var updateReadOnlyRequest = new ServerModels.UpdateUserDataRequest();
                updateReadOnlyRequest.PlayFabId = playFabId;
                updateReadOnlyRequest.Data = new Dictionary<string, string>();
                updateReadOnlyRequest.Data[userPublisherDataKey] = userPublisherDataValue; // Multiple keys accepted, unlike this example, best-use-case modifies all keys at once when possible.

                PlayFabServerAPI.UpdateUserPublisherReadOnlyData(updateReadOnlyRequest, UpdateReadOnlyUserPublisherDataCallback, PfSharedControllerEx.FailCallback("UpdateUserPublisherReadOnlyData"));
            };
            return output;
        }
        private static void UpdateReadOnlyUserPublisherDataCallback(ServerModels.UpdateUserDataResult result)
        {
            string playFabId = ((ServerModels.UpdateUserDataRequest)result.Request).PlayFabId;
            Dictionary<string, string> dataUpdated = ((ServerModels.UpdateUserDataRequest)result.Request).Data;

            foreach (var dataPair in dataUpdated)
            {
                if (string.IsNullOrEmpty(dataPair.Value))
                    PfSharedModelEx.serverUsers[playFabId].userPublisherReadOnlyData.Remove(dataPair.Key);
                else
                    PfSharedModelEx.serverUsers[playFabId].userPublisherReadOnlyData[dataPair.Key] = dataPair.Value;
            }

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataChanged, playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static Action UpdateInternalUserPublisherData(string playFabId, string userPublisherDataKey, string userPublisherDataValue)
        {
            if (string.IsNullOrEmpty(userPublisherDataValue))
                userPublisherDataValue = null; // Ensure that this field is removed

            Action output = () =>
            {
                var updateInternalRequest = new ServerModels.UpdateUserInternalDataRequest();
                updateInternalRequest.PlayFabId = playFabId;
                updateInternalRequest.Data = new Dictionary<string, string>();
                updateInternalRequest.Data[userPublisherDataKey] = userPublisherDataValue; // Multiple keys accepted, unlike this example, best-use-case modifies all keys at once when possible.

                PlayFabServerAPI.UpdateUserPublisherInternalData(updateInternalRequest, UpdateInternalUserPublisherDataCallback, PfSharedControllerEx.FailCallback("UpdateUserPublisherInternalData"));
            };
            return output;
        }
        private static void UpdateInternalUserPublisherDataCallback(ServerModels.UpdateUserDataResult result)
        {
            string playFabId = ((ServerModels.UpdateUserInternalDataRequest)result.Request).PlayFabId;
            Dictionary<string, string> dataUpdated = ((ServerModels.UpdateUserInternalDataRequest)result.Request).Data;

            foreach (var dataPair in dataUpdated)
            {
                if (string.IsNullOrEmpty(dataPair.Value))
                    PfSharedModelEx.serverUsers[playFabId].userPublisherInternalData.Remove(dataPair.Key);
                else
                    PfSharedModelEx.serverUsers[playFabId].userPublisherInternalData[dataPair.Key] = dataPair.Value;
            }

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataChanged, playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }
        #endregion UserPublisherData - Data attached directly to the user for this title
    }
}
