
namespace PlayFab.Examples.Client
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
            GetPublisherData();
        }
        #endregion Controller Event Handling

        public static void GetTitleData()
        {
            var getRequest = new ClientModels.GetTitleDataRequest();
            // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
            PlayFabClientAPI.GetTitleData(getRequest, GetTitleDataCallback, PfSharedControllerEx.FailCallback("GetTitleData"));
        }

        private static void GetTitleDataCallback(ClientModels.GetTitleDataResult result)
        {
            foreach (var eachTitleEntry in result.Data)
                PfSharedModelEx.titleData[eachTitleEntry.Key] = eachTitleEntry.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnTitleDataLoaded, null, null, PfSharedControllerEx.Api.Client, false);
        }
        public static void GetPublisherData()
        {
            var getRequest = new ClientModels.GetPublisherDataRequest();
            getRequest.Keys = PfSharedModelEx.defaultPublisherKeys; // TODO: Temporary - keys are mandatory, and we don't know what keys already exist.
            PlayFabClientAPI.GetPublisherData(getRequest, GetPublisherDataCallback, PfSharedControllerEx.FailCallback("GetPublisherData"));
        }

        private static void GetPublisherDataCallback(ClientModels.GetPublisherDataResult result)
        {
            foreach (var eachPublisherEntry in result.Data)
                PfSharedModelEx.publisherData[eachPublisherEntry.Key] = eachPublisherEntry.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnTitleDataLoaded, null, null, PfSharedControllerEx.Api.Client, false);
        }
    }
}
