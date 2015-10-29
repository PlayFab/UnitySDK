using UnityEngine;

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
                PfSharedModelEx.clientTitleData[eachTitleEntry.Key] = eachTitleEntry.Value;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnTitleDataLoaded, null, null, PfSharedControllerEx.Api.Client, false);
        }
    }
}
