
namespace PlayFab.Examples.Client
{
    public static class TitleDataExample
    {
        #region Controller Event Handling
        static TitleDataExample()
        { }

        public static void SetUp()
        { }
        #endregion Controller Event Handling

        public static void GetTitleData()
        {
            var getRequest = new ClientModels.GetTitleDataRequest();
            PlayFabClientAPI.GetTitleData(getRequest, GetTitleDataCallback, PfSharedControllerEx.FailCallback("GetTitleData"));
        }

        private static void GetTitleDataCallback(ClientModels.GetTitleDataResult result)
        {
            foreach (var eachTitleEntry in result.Data)
                PfSharedModelEx.titleData[eachTitleEntry.Key] = eachTitleEntry.Value;
			MainExampleController.DebugOutput("Title Data Loaded.");
        }
        
        public static void GetPublisherData()
        {
			if(PlayFab.Examples.PfSharedModelEx.usePublisher == true)
			{
			 	var getRequest = new ClientModels.GetPublisherDataRequest();
            	getRequest.Keys = new System.Collections.Generic.List<string>();
            	PlayFabClientAPI.GetPublisherData(getRequest, GetPublisherDataCallback, PfSharedControllerEx.FailCallback("GetPublisherData"));
            }
        }

        private static void GetPublisherDataCallback(ClientModels.GetPublisherDataResult result)
        {
            foreach (var eachPublisherEntry in result.Data)
                PfSharedModelEx.publisherData[eachPublisherEntry.Key] = eachPublisherEntry.Value;
			MainExampleController.DebugOutput("Publisher Data Loaded.");
        }
    }
}
