using System.Collections.Generic;
using PlayFab.ClientModels;

namespace PlayFab.Examples.Client
{
    public static class UserDataExample
    {
        #region Controller Event Handling
        static UserDataExample()
        {
            //PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserLogin, OnUserLogin);
        }

        public static void SetUp()
        {
            // The static constructor is called as a by-product of this call
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
                PfSharedModelEx.currentUser.userData[eachDataEntry.Key] = eachDataEntry.Value; // need the whole object.
            //PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("User Data Loaded.");
        }

        public static void GetUserReadOnlyData()
        {
            var getRequest = new ClientModels.GetUserDataRequest();
            getRequest.PlayFabId = PfSharedModelEx.currentUser.playFabId; // You may ask for yourself specifically, any other playFabId you're aware of, or null to default to yourself
            // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
			PlayFabClientAPI.GetUserReadOnlyData(getRequest, GetUserReadOnlyDataCallback, PfSharedControllerEx.FailCallback("GetUserReadOnlyData"));
        }

        private static void GetUserReadOnlyDataCallback(ClientModels.GetUserDataResult result)
        {
            foreach (var eachDataEntry in result.Data)
                PfSharedModelEx.currentUser.userReadOnlyData[eachDataEntry.Key] = eachDataEntry.Value;
            //PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("User Read-Only Data Loaded.");
        }


		public static void UpdateUserData(Dictionary<string, string> data, bool makePrivate = false, List<string> deleteKeys = null)
        {
            if(data.Count > 0 || (deleteKeys != null && deleteKeys.Count > 0))
            {
	            var updateRequest = new ClientModels.UpdateUserDataRequest();
	            updateRequest.Data = data;
	            updateRequest.KeysToRemove = deleteKeys;
				updateRequest.Permission = makePrivate == true ? UserDataPermission.Private : UserDataPermission.Public;
			
           		PlayFabClientAPI.UpdateUserData(updateRequest, UpdateUserDataCallback, PfSharedControllerEx.FailCallback("UpdateUserData"));
			}
        }
        
        private static void UpdateUserDataCallback(ClientModels.UpdateUserDataResult result)
        {
            // weird work-around for not providing the updated data in the result object
            Dictionary<string, string> dataUpdated = ((ClientModels.UpdateUserDataRequest)result.Request).Data;
			List<string> deleted = ((ClientModels.UpdateUserDataRequest)result.Request).KeysToRemove;
			UserDataPermission? p = ((ClientModels.UpdateUserDataRequest)result.Request).Permission;
			
			foreach(var item in deleted)
			{
				PfSharedModelEx.currentUser.userData.Remove(item);
			}
			
            foreach (var dataPair in dataUpdated)
            {
				if(PfSharedModelEx.currentUser.userData.ContainsKey(dataPair.Key))
                {
                	PfSharedModelEx.currentUser.userData[dataPair.Key].Value = dataPair.Value;
					PfSharedModelEx.currentUser.userData[dataPair.Key].Permission = p;
					PfSharedModelEx.currentUser.userData[dataPair.Key].LastUpdated = System.DateTime.UtcNow;
                }
                else
                {
					PfSharedModelEx.currentUser.userData.Add(dataPair.Key, new UserDataRecord(){ Value = dataPair.Value, Permission = p, LastUpdated = System.DateTime.UtcNow  });
                }
            }

           // PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataChanged, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("User Data Updated.");
        }
        #endregion UserData - Data attached directly to the user for this title

        #region UserPublisherData - Data attached directly to the user across all titles for this publisher
        public static void GetUserPublisherData()
        {
			if(PlayFab.Examples.PfSharedModelEx.usePublisher == true)
			{
				 var request = new GetUserDataRequest();
           	 	// getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
            	PlayFabClientAPI.GetUserPublisherData(request, GetUserPublisherDataCallback, PfSharedControllerEx.FailCallback("GetUserPublisherData"));
            }
        }

        private static void GetUserPublisherDataCallback(ClientModels.GetUserDataResult result)
        {
	            foreach (var eachDataEntry in result.Data)
	            {
	                PfSharedModelEx.currentUser.userPublisherData[eachDataEntry.Key] = eachDataEntry.Value;
	            }
	            //PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
				MainExampleController.DebugOutput("User Publisher Data Loaded.");

        }

        public static void GetUserPublisherReadOnlyData()
        {
			if(PlayFab.Examples.PfSharedModelEx.usePublisher == true)
			{
	            var request = new GetUserDataRequest();
	            // getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
	            PlayFabClientAPI.GetUserPublisherReadOnlyData(request, GetUserPublisherReadOnlyDataCallback, PfSharedControllerEx.FailCallback("GetUserPublisherReadOnlyDataCallback"));
	        }
        }

        private static void GetUserPublisherReadOnlyDataCallback(ClientModels.GetUserDataResult result)
        {
            foreach (var eachDataEntry in result.Data)
                PfSharedModelEx.currentUser.userPublisherReadOnlyData[eachDataEntry.Key] = eachDataEntry.Value;
            //PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("User Publisher Read-Only Data Loaded.");
        }

		public static void UpdateUserPublisherData(Dictionary<string, string> data, bool makePrivate = false, List<string> deleteKeys = null)
        {
			if(PlayFab.Examples.PfSharedModelEx.usePublisher == true)
			{
				if(data.Count > 0 || (deleteKeys != null && deleteKeys.Count > 0))
				{
					var request = new UpdateUserDataRequest();
		            request.Data = data;
		            request.KeysToRemove = deleteKeys;
					request.Permission = makePrivate == true ? UserDataPermission.Private : UserDataPermission.Public;
				
	           	 	PlayFabClientAPI.UpdateUserPublisherData(request, UpdateUserPublisherDataCallback, PfSharedControllerEx.FailCallback("UpdateUserPublisherData"));
	           	}
	        }
        }

        private static void UpdateUserPublisherDataCallback(ClientModels.UpdateUserDataResult result)
        {
			// weird work-around for not providing the updated data in the result object
            Dictionary<string, string> dataUpdated = ((ClientModels.UpdateUserDataRequest)result.Request).Data;
			List<string> deleted = ((ClientModels.UpdateUserDataRequest)result.Request).KeysToRemove;
			UserDataPermission? p = ((ClientModels.UpdateUserDataRequest)result.Request).Permission;
			
			foreach(var item in deleted)
			{
				PfSharedModelEx.currentUser.userPublisherData.Remove(item);
			}
			
            foreach (var dataPair in dataUpdated)
            {
				if(PfSharedModelEx.currentUser.userPublisherData.ContainsKey(dataPair.Key))
				{
					PfSharedModelEx.currentUser.userPublisherData[dataPair.Key].Value = dataPair.Value;
					PfSharedModelEx.currentUser.userPublisherData[dataPair.Key].Permission = p;
					PfSharedModelEx.currentUser.userPublisherData[dataPair.Key].LastUpdated = System.DateTime.UtcNow;
				}
				else
				{
					PfSharedModelEx.currentUser.userPublisherData.Add(dataPair.Key, new UserDataRecord(){ Value = dataPair.Value, Permission = p, LastUpdated = System.DateTime.UtcNow });
				}
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
				PfSharedModelEx.currentCharacter.characterData[eachDataEntry.Key].Value = eachDataEntry.Value.Value;
			//PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("Character Data Loaded.");
		}
		
		public static void GetActiveCharacterReadOnlyData()
		{
			var request = new GetCharacterDataRequest();
			request.CharacterId = PfSharedModelEx.currentCharacter.details.CharacterId;
			
			// getRequest.Keys = new System.Collections.Generic.List<string>() { filterKey };
			PlayFabClientAPI.GetCharacterReadOnlyData(request, GetActiveCharacterReadOnlyDataCallback, PfSharedControllerEx.FailCallback("GetCharacterReadOnlyDataCallback"));
		}
		
		private static void GetActiveCharacterReadOnlyDataCallback(ClientModels.GetCharacterDataResult result)
		{
			foreach (var eachDataEntry in result.Data)
			{
				
				PfSharedModelEx.currentCharacter.characterReadOnlyData[eachDataEntry.Key] = eachDataEntry.Value;
			}
			//PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataLoaded, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("Character Read-Only Data Loaded.");
		}
		
		//TODO update this to work with a list rather than a single key.
		public static void UpdateActiveCharacterData(Dictionary<string, string> data, bool makePrivate = false, List<string> deleteKeys = null)
		{
			if(data.Count > 0 || (deleteKeys != null && deleteKeys.Count > 0))
			{
				var request = new UpdateCharacterDataRequest();
				request.Data = data;
				request.KeysToRemove = deleteKeys;
				request.Permission = makePrivate == true ? UserDataPermission.Private : UserDataPermission.Public;
				
				PlayFabClientAPI.UpdateCharacterData(request, UpdateActiveCharacterDataCallback, PfSharedControllerEx.FailCallback("UpdateCharacterData"));
			}
		}
		
		private static void UpdateActiveCharacterDataCallback(ClientModels.UpdateCharacterDataResult result)
		{
			// weird work-around for not providing the updated data in the result object
			Dictionary<string, string> dataUpdated = ((ClientModels.UpdateUserDataRequest)result.Request).Data;
			List<string> deleted = ((ClientModels.UpdateUserDataRequest)result.Request).KeysToRemove;
			UserDataPermission? p = ((ClientModels.UpdateUserDataRequest)result.Request).Permission;
			
			foreach(var item in deleted)
			{
				PfSharedModelEx.currentCharacter.characterData.Remove(item);
			}
			
			foreach (var dataPair in dataUpdated)
			{
				if(PfSharedModelEx.currentCharacter.characterData.ContainsKey(dataPair.Key))
				{
					PfSharedModelEx.currentCharacter.characterData[dataPair.Key].Value = dataPair.Value;
					PfSharedModelEx.currentCharacter.characterData[dataPair.Key].Permission = p;
					PfSharedModelEx.currentCharacter.characterData[dataPair.Key].LastUpdated = System.DateTime.UtcNow;
				}
				else
				{
					PfSharedModelEx.currentCharacter.characterData.Add(dataPair.Key, new UserDataRecord(){ Value = dataPair.Value, Permission = p, LastUpdated = System.DateTime.UtcNow });
				}
			}

			//PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserDataChanged, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
			MainExampleController.DebugOutput("Character Data Updated.");
		}
    }
}
