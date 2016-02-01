using System.Collections.Generic;
using PlayFab.ClientModels;

namespace PlayFab.Examples.Client
{
    public static class UserDataExample
    {
        #region Controller Event Handling
        static UserDataExample()
        {}

        public static void SetUp()
        {}

        #endregion Controller Event Handling

        #region UserData - Data attached directly to the user for this title
        public static void GetUserData()
        {
            var getRequest = new ClientModels.GetUserDataRequest();
            getRequest.PlayFabId = PfSharedModelEx.CurrentUser.PlayFabId; 
            PlayFabClientAPI.GetUserData(getRequest, GetUserDataCallback, PfSharedControllerEx.FailCallback("GetUserData"));
        }

        private static void GetUserDataCallback(ClientModels.GetUserDataResult result)
        {
            foreach (var eachDataEntry in result.Data)
                PfSharedModelEx.CurrentUser.UserData[eachDataEntry.Key] = eachDataEntry.Value;
            MainExampleController.DebugOutput("User Data Loaded.");
        }

        public static void GetUserReadOnlyData()
        {
            var getRequest = new ClientModels.GetUserDataRequest();
            getRequest.PlayFabId = PfSharedModelEx.CurrentUser.PlayFabId;
            PlayFabClientAPI.GetUserReadOnlyData(getRequest, GetUserReadOnlyDataCallback, PfSharedControllerEx.FailCallback("GetUserReadOnlyData"));
        }

        private static void GetUserReadOnlyDataCallback(ClientModels.GetUserDataResult result)
        {
            foreach (var eachDataEntry in result.Data)
                PfSharedModelEx.CurrentUser.UserReadOnlyData[eachDataEntry.Key] = eachDataEntry.Value;
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
				PfSharedModelEx.CurrentUser.UserData.Remove(item);
			}
			
            foreach (var dataPair in dataUpdated)
            {
				if(PfSharedModelEx.CurrentUser.UserData.ContainsKey(dataPair.Key))
                {
                	PfSharedModelEx.CurrentUser.UserData[dataPair.Key].Value = dataPair.Value;
					PfSharedModelEx.CurrentUser.UserData[dataPair.Key].Permission = p;
					PfSharedModelEx.CurrentUser.UserData[dataPair.Key].LastUpdated = System.DateTime.UtcNow;
                }
                else
                {
					PfSharedModelEx.CurrentUser.UserData.Add(dataPair.Key, new UserDataRecord(){ Value = dataPair.Value, Permission = p, LastUpdated = System.DateTime.UtcNow  });
                }
            }
            
            MainExampleController.DebugOutput("User Data Updated.");
        }
        #endregion UserData - Data attached directly to the user for this title

        #region UserPublisherData - Data attached directly to the user across all titles for this publisher
        public static void GetUserPublisherData()
        {
			if(PlayFab.Examples.PfSharedModelEx.UserPublisher == true)
			{
				var request = new GetUserDataRequest();
           	 	PlayFabClientAPI.GetUserPublisherData(request, GetUserPublisherDataCallback, PfSharedControllerEx.FailCallback("GetUserPublisherData"));
            }
        }

        private static void GetUserPublisherDataCallback(ClientModels.GetUserDataResult result)
        {
	            foreach (var eachDataEntry in result.Data)
	            {
	                PfSharedModelEx.CurrentUser.UserPublisherData[eachDataEntry.Key] = eachDataEntry.Value;
	            }
	            MainExampleController.DebugOutput("User Publisher Data Loaded.");

        }

        public static void GetUserPublisherReadOnlyData()
        {
			if(PlayFab.Examples.PfSharedModelEx.UserPublisher == true)
			{
	            var request = new GetUserDataRequest();
	            PlayFabClientAPI.GetUserPublisherReadOnlyData(request, GetUserPublisherReadOnlyDataCallback, PfSharedControllerEx.FailCallback("GetUserPublisherReadOnlyDataCallback"));
	        }
        }

        private static void GetUserPublisherReadOnlyDataCallback(ClientModels.GetUserDataResult result)
        {
            foreach (var eachDataEntry in result.Data)
                PfSharedModelEx.CurrentUser.UserPublisherReadOnlyData[eachDataEntry.Key] = eachDataEntry.Value;
      		MainExampleController.DebugOutput("User Publisher Read-Only Data Loaded.");
        }

		public static void UpdateUserPublisherData(Dictionary<string, string> data, bool makePrivate = false, List<string> deleteKeys = null)
        {
			if(PlayFab.Examples.PfSharedModelEx.UserPublisher == true)
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
				PfSharedModelEx.CurrentUser.UserPublisherData.Remove(item);
			}
			
            foreach (var dataPair in dataUpdated)
            {
				if(PfSharedModelEx.CurrentUser.UserPublisherData.ContainsKey(dataPair.Key))
				{
					PfSharedModelEx.CurrentUser.UserPublisherData[dataPair.Key].Value = dataPair.Value;
					PfSharedModelEx.CurrentUser.UserPublisherData[dataPair.Key].Permission = p;
					PfSharedModelEx.CurrentUser.UserPublisherData[dataPair.Key].LastUpdated = System.DateTime.UtcNow;
				}
				else
				{
					PfSharedModelEx.CurrentUser.UserPublisherData.Add(dataPair.Key, new UserDataRecord(){ Value = dataPair.Value, Permission = p, LastUpdated = System.DateTime.UtcNow });
				}
            }
            
            MainExampleController.DebugOutput("User Publisher Data Updated");
        }

        #endregion UserPublisherData - Data attached directly to the user across all titles for this publisher
        
        
        
        // begin character data methods:
		public static void GetActiveCharacterData()
		{
			var request = new GetCharacterDataRequest();
			request.CharacterId = PfSharedModelEx.CurrentCharacter.Details.CharacterId;
			
			PlayFabClientAPI.GetCharacterData(request, GetActiveCharacterDataCallback, PfSharedControllerEx.FailCallback("GetCharacterDataCallback"));
		}
		
		private static void GetActiveCharacterDataCallback(ClientModels.GetCharacterDataResult result)
		{
			foreach (var eachDataEntry in result.Data)
				PfSharedModelEx.CurrentCharacter.CharacterData[eachDataEntry.Key].Value = eachDataEntry.Value.Value;
			MainExampleController.DebugOutput("Character Data Loaded.");
		}
		
		public static void GetActiveCharacterReadOnlyData()
		{
			var request = new GetCharacterDataRequest();
			request.CharacterId = PfSharedModelEx.CurrentCharacter.Details.CharacterId;
			
			PlayFabClientAPI.GetCharacterReadOnlyData(request, GetActiveCharacterReadOnlyDataCallback, PfSharedControllerEx.FailCallback("GetCharacterReadOnlyDataCallback"));
		}
		
		private static void GetActiveCharacterReadOnlyDataCallback(ClientModels.GetCharacterDataResult result)
		{
			foreach (var eachDataEntry in result.Data)
			{
				
				PfSharedModelEx.CurrentCharacter.CharacterReadOnlyData[eachDataEntry.Key] = eachDataEntry.Value;
			}
			
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
				PfSharedModelEx.CurrentCharacter.CharacterData.Remove(item);
			}
			
			foreach (var dataPair in dataUpdated)
			{
				if(PfSharedModelEx.CurrentCharacter.CharacterData.ContainsKey(dataPair.Key))
				{
					PfSharedModelEx.CurrentCharacter.CharacterData[dataPair.Key].Value = dataPair.Value;
					PfSharedModelEx.CurrentCharacter.CharacterData[dataPair.Key].Permission = p;
					PfSharedModelEx.CurrentCharacter.CharacterData[dataPair.Key].LastUpdated = System.DateTime.UtcNow;
				}
				else
				{
					PfSharedModelEx.CurrentCharacter.CharacterData.Add(dataPair.Key, new UserDataRecord(){ Value = dataPair.Value, Permission = p, LastUpdated = System.DateTime.UtcNow });
				}
			}

			MainExampleController.DebugOutput("Character Data Updated.");
		}
    }
}
