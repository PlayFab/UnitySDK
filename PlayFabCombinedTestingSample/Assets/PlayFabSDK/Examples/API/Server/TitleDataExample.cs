using System;

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
            GetPublisherData();
        }
        #endregion Controller Event Handling

        #region Title Data - Information stored per-title, usually title-global information
        public static void GetTitleData()
        {
            var getRequest = new ServerModels.GetTitleDataRequest();
            // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
            PlayFabServerAPI.GetTitleData(getRequest, GetTitleDataCallback, PfSharedControllerEx.FailCallback("GetTitleData"));
        }
        private static void GetTitleDataCallback(ServerModels.GetTitleDataResult result)
        {
            foreach (var eachTitleEntry in result.Data)
                PfSharedModelEx.titleData[eachTitleEntry.Key] = eachTitleEntry.Value;
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
                PfSharedModelEx.titleInternalData[eachTitleEntry.Key] = eachTitleEntry.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnTitleDataLoaded, null, null, PfSharedControllerEx.Api.Server, false);
        }

        public static void SetTitleData(string titleDataKey, string titleDataValue)
        {
            if (string.IsNullOrEmpty(titleDataValue))
                titleDataValue = null; // Ensure that this field is removed

            // This api-call updates one titleData key at a time.
            // You can remove a key by setting the value to null.
            var updateRequest = new ServerModels.SetTitleDataRequest();
            updateRequest.Key = titleDataKey;
            updateRequest.Value = titleDataValue;

            PlayFabServerAPI.SetTitleData(updateRequest, SetTitleDataCallback, PfSharedControllerEx.FailCallback("SetTitleData"));
        }
        private static void SetTitleDataCallback(ServerModels.SetTitleDataResult result)
        {
            string dataKey = ((ServerModels.SetTitleDataRequest)result.Request).Key;
            string dataValue = ((ServerModels.SetTitleDataRequest)result.Request).Value;

            if (string.IsNullOrEmpty(dataValue))
                PfSharedModelEx.titleData.Remove(dataKey);
            else
                PfSharedModelEx.titleData[dataKey] = dataValue;

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnTitleDataChanged, null, null, PfSharedControllerEx.Api.Server, false);
        }

        public static void SetTitleInternalData(string titleDataKey, string titleDataValue)
        {
            if (string.IsNullOrEmpty(titleDataValue))
                titleDataValue = null; // Ensure that this field is removed

            // This api-call updates one titleData key at a time.
            // You can remove a key by setting the value to null.
            var updateRequest = new ServerModels.SetTitleDataRequest();
            updateRequest.Key = titleDataKey;
            updateRequest.Value = titleDataValue;

            PlayFabServerAPI.SetTitleInternalData(updateRequest, SetInternalTitleDataCallback, PfSharedControllerEx.FailCallback("SetTitleInternalData"));
        }
        private static void SetInternalTitleDataCallback(ServerModels.SetTitleDataResult result)
        {
            string dataKey = ((ServerModels.SetTitleDataRequest)result.Request).Key;
            string dataValue = ((ServerModels.SetTitleDataRequest)result.Request).Value;

            if (string.IsNullOrEmpty(dataValue))
                PfSharedModelEx.titleInternalData.Remove(dataKey);
            else
                PfSharedModelEx.titleInternalData[dataKey] = dataValue;

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnTitleDataChanged, null, null, PfSharedControllerEx.Api.Server, false);
        }
        #endregion Title Data - Information stored per-title, usually title-global information

        #region Publisher Data - Information stored for all titles under a publisher
        public static void GetPublisherData()
        {
            var getRequest = new ServerModels.GetPublisherDataRequest();
            getRequest.Keys = PfSharedModelEx.defaultPublisherKeys; // TODO: Temporary - keys are mandatory, and we don't know what keys already exist.
            PlayFabServerAPI.GetPublisherData(getRequest, GetPublisherDataCallback, PfSharedControllerEx.FailCallback("GetPublisherData"));
        }
        private static void GetPublisherDataCallback(ServerModels.GetPublisherDataResult result)
        {
            foreach (var eachPublisherEntry in result.Data)
                PfSharedModelEx.publisherData[eachPublisherEntry.Key] = eachPublisherEntry.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnTitleDataLoaded, null, null, PfSharedControllerEx.Api.Server, false);
        }

        public static void SetPublisherData(string publisherDataKey, string publisherDataValue)
        {
            if (string.IsNullOrEmpty(publisherDataValue))
                publisherDataValue = null; // Ensure that this field is removed

            if (!PfSharedModelEx.defaultPublisherKeys.Contains(publisherDataKey))
                throw new Exception("TEMPORARY LIMITATION: Add this key to defaultPublisherKeys:" + publisherDataKey + ".  You must keep track of the keys you create, because GetPublisherData won't return keys you don't explicitly ask for.");

            // This api-call updates one PublisherData key at a time.
            // You can remove a key by setting the value to null.
            var updateRequest = new ServerModels.SetPublisherDataRequest();
            updateRequest.Key = publisherDataKey;
            updateRequest.Value = publisherDataValue;

            PlayFabServerAPI.SetPublisherData(updateRequest, SetPublisherDataCallback, PfSharedControllerEx.FailCallback("SetPublisherData"));
        }
        private static void SetPublisherDataCallback(ServerModels.SetPublisherDataResult result)
        {
            string dataKey = ((ServerModels.SetPublisherDataRequest)result.Request).Key;
            string dataValue = ((ServerModels.SetPublisherDataRequest)result.Request).Value;

            if (string.IsNullOrEmpty(dataValue))
            {
                PfSharedModelEx.publisherData.Remove(dataKey);
            }
            else
            {
                PfSharedModelEx.publisherData[dataKey] = dataValue;
            }

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnTitleDataChanged, null, null, PfSharedControllerEx.Api.Server, false);
        }
        #endregion Publisher Data - Information stored for all titles under a publisher
    }
}
