using System.Collections.Generic;
using PlayFab.ClientModels;

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

            GetUserPublisherData();
            GetUserPublisherReadOnlyData();
        }
        #endregion Controller Event Handling

        #region UserData - Data attached directly to the user for this title
        public static void GetUserData()
        {
            var getRequest = new ClientModels.GetUserDataRequest();
            getRequest.PlayFabId = PfSharedModelEx.currentUser.playFabId; // You may ask for yourself specifically, any other playFabId you're aware of, or null to default to yourself
            // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
            PlayFabClientAPI.GetUserData(getRequest, GetUserDataCallback, PfSharedControllerEx.FailCallback("GetUserData"));
        }

        private static void GetUserDataCallback(ClientModels.GetUserDataResult result)
        {
            foreach (var eachDataEntry in result.Data)
                PfSharedModelEx.currentUser.userData[eachDataEntry.Key] = eachDataEntry.Value.Value;
            //PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("User Data Loaded.");
        }

        public static void GetUserReadOnlyData()
        {
            var getRequest = new ClientModels.GetUserDataRequest();
            getRequest.PlayFabId = PfSharedModelEx.currentUser.playFabId; // You may ask for yourself specifically, any other playFabId you're aware of, or null to default to yourself
            // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
            PlayFabClientAPI.GetUserReadOnlyData(getRequest, GetUserDataCallback, PfSharedControllerEx.FailCallback("GetUserReadOnlyData"));
        }

        private static void GetUserReadOnlyDataCallback(ClientModels.GetUserDataResult result)
        {
            foreach (var eachDataEntry in result.Data)
                PfSharedModelEx.currentUser.userReadOnlyData[eachDataEntry.Key] = eachDataEntry.Value.Value;
            //PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("User Read-Only Data Loaded.");
        }

        public static void UpdateUserData(string userDataKey, string userDataValue)
        {
            if (string.IsNullOrEmpty(userDataValue))
                userDataValue = null; // Ensure that this field is removed

            var updateRequest = new ClientModels.UpdateUserDataRequest();
            updateRequest.Data = new Dictionary<string, string>();
            updateRequest.Data[userDataKey] = userDataValue; // Multiple keys accepted, unlike this example, best-use-case modifies all keys at once when possible.

            PlayFabClientAPI.UpdateUserData(updateRequest, UpdateUserDataCallback, PfSharedControllerEx.FailCallback("UpdateUserData"));
        }
        private static void UpdateUserDataCallback(ClientModels.UpdateUserDataResult result)
        {
            Dictionary<string, string> dataUpdated = ((ClientModels.UpdateUserDataRequest)result.Request).Data;

            foreach (var dataPair in dataUpdated)
            {
                if (string.IsNullOrEmpty(dataPair.Value))
                    PfSharedModelEx.currentUser.userData.Remove(dataPair.Key);
                else
                    PfSharedModelEx.currentUser.userData[dataPair.Key] = dataPair.Value;
            }

           // PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataChanged, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("User Data Updated.");
        }
        #endregion UserData - Data attached directly to the user for this title

        #region UserPublisherData - Data attached directly to the user across all titles for this publisher
        public static void GetUserPublisherData()
        {
            var request = new GetUserDataRequest();
            // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
            PlayFabClientAPI.GetUserPublisherData(request, GetUserPublisherDataCallback, PfSharedControllerEx.FailCallback("GetUserPublisherDataCallback"));
        }

        private static void GetUserPublisherDataCallback(ClientModels.GetUserDataResult result)
        {
            foreach (var eachDataEntry in result.Data)
                PfSharedModelEx.currentUser.userPublisherData[eachDataEntry.Key] = eachDataEntry.Value.Value;
            //PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("User Publisher Data Loaded.");
        }

        public static void GetUserPublisherReadOnlyData()
        {
            var request = new GetUserDataRequest();
            // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
            PlayFabClientAPI.GetUserPublisherReadOnlyData(request, GetUserPublisherReadOnlyDataCallback, PfSharedControllerEx.FailCallback("GetUserPublisherReadOnlyDataCallback"));
        }

        private static void GetUserPublisherReadOnlyDataCallback(ClientModels.GetUserDataResult result)
        {
            foreach (var eachDataEntry in result.Data)
                PfSharedModelEx.currentUser.userPublisherReadOnlyData[eachDataEntry.Key] = eachDataEntry.Value.Value;
            //PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("User Publisher Read-Only Data Loaded.");
        }

        public static void UpdatePublisherdata(string userDataKey, string userDataValue)
        {
            var request = new UpdateUserDataRequest();
            request.Data = new Dictionary<string, string>();
            request.Data[userDataKey] = userDataValue;
            PlayFabClientAPI.UpdateUserPublisherData(request, UpdateUserPublisherDataCallback, PfSharedControllerEx.FailCallback("UpdateUserPublisherData"));
        }

        private static void UpdateUserPublisherDataCallback(ClientModels.UpdateUserDataResult result)
        {
            Dictionary<string, string> dataUpdated = ((ClientModels.UpdateUserDataRequest)result.Request).Data;

            foreach (var dataPair in dataUpdated)
            {
                if (string.IsNullOrEmpty(dataPair.Value))
                    PfSharedModelEx.currentUser.userPublisherData.Remove(dataPair.Key);
                else
                    PfSharedModelEx.currentUser.userPublisherData[dataPair.Key] = dataPair.Value;
            }

           // PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataChanged, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("User Publisher Data Updated");
        }

        #endregion UserPublisherData - Data attached directly to the user across all titles for this publisher
        
        
        
        // begin character data methods:
		public static void GetActiveCharacterData()
		{
			var request = new GetCharacterDataRequest();
			request.CharacterId = PfSharedModelEx.currentCharacter.details.CharacterId;
			// getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
			PlayFabClientAPI.GetCharacterData(request, GetActiveCharacterDataCallback, PfSharedControllerEx.FailCallback("GetCharacterDataCallback"));
		}
		
		private static void GetActiveCharacterDataCallback(ClientModels.GetCharacterDataResult result)
		{
			foreach (var eachDataEntry in result.Data)
				PfSharedModelEx.currentCharacter.characterData[eachDataEntry.Key] = eachDataEntry.Value.Value;
			//PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("Character Data Loaded.");
		}
		
		public static void GetActiveCharacterReadOnlyData()
		{
			var request = new GetCharacterDataRequest();
			// getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
			PlayFabClientAPI.GetCharacterReadOnlyData(request, GetActiveCharacterReadOnlyDataCallback, PfSharedControllerEx.FailCallback("GetUserPublisherReadOnlyDataCallback"));
		}
		
		private static void GetActiveCharacterReadOnlyDataCallback(ClientModels.GetCharacterDataResult result)
		{
			foreach (var eachDataEntry in result.Data)
				PfSharedModelEx.currentCharacter.characterReadOnlyData[eachDataEntry.Key] = eachDataEntry.Value.Value;
			//PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("Character Read-Only Data Loaded.");
		}
		
		//TODO update this to work with a list rather than a single key.
		public static void UpdateActiveCharacterData(string userDataKey, string userDataValue)
		{
			var request = new UpdateCharacterDataRequest();
			request.Data = new Dictionary<string, string>();
			request.Data[userDataKey] = userDataValue;
			PlayFabClientAPI.UpdateCharacterData(request, UpdateActiveCharacterDataCallback, PfSharedControllerEx.FailCallback("UpdateCharacterData"));
		}
		
		private static void UpdateActiveCharacterDataCallback(ClientModels.UpdateCharacterDataResult result)
		{
			Dictionary<string, string> dataUpdated = ((ClientModels.UpdateUserDataRequest)result.Request).Data;
			
			foreach (var dataPair in dataUpdated)
			{
				if (string.IsNullOrEmpty(dataPair.Value))
					PfSharedModelEx.currentUser.userPublisherData.Remove(dataPair.Key);
				else
					PfSharedModelEx.currentUser.userPublisherData[dataPair.Key] = dataPair.Value;
			}
			
			//PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataChanged, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("Character Data Updated.");
		}
    }
}
