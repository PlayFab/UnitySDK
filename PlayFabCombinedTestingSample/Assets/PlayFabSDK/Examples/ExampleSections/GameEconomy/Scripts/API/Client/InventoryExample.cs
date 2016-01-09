using System.Collections.Generic;
using PlayFab.ClientModels;

namespace PlayFab.Examples.Client
{
    /// <summary>
    /// This example will have poor performance for a real title with lots of items.
    /// However, it's a very consise example for a test-title, with a small number of CatalogItems.
    /// 
    /// This is example code for all the API's described here: PlayFab Inventory System - Basic Inventory Guide
    /// This file contains calls to each of the functions described, an old-style Unity-gui to demonstrate the inventory changes taking place, and the prerequisite login and setup code.
    /// </summary>
    public static class InventoryExample
    {
        #region Controller Event Handling
        static InventoryExample()
        {
           // PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserLogin, OnUserLogin);
           // PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, OnUserCharactersLoaded);
           // PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, OnInventoryChanged);
        }

        public static void SetUp()
        {
            // The static constructor is called as a by-product of this call
        }


		public static void LoadInventoryFromPlayFab()
		{
			if(PlayFab.Examples.PfSharedModelEx.activeMode == PfSharedModelEx.ModelModes.User)
			{
				var getRequest = new ClientModels.GetUserInventoryRequest();
				PlayFabClientAPI.GetUserInventory(getRequest, LoadUserInventoryCallback, PfSharedControllerEx.FailCallback("GetUserInventory"));
			}
			else
			{
	            var getRequest = new ClientModels.GetCharacterInventoryRequest();
				getRequest.CharacterId = PlayFab.Examples.PfSharedModelEx.currentCharacter.details.CharacterId;
				PlayFabClientAPI.GetCharacterInventory(getRequest, LoadCharacterInventoryCallback, PfSharedControllerEx.FailCallback("GetCharacterInventory"));
			}
		}
		
		public static void LoadUserInventoryCallback(ClientModels.GetUserInventoryResult result)
		{
			PlayFab.Examples.PfSharedModelEx.currentUser.userInventory = result.Inventory;
			PlayFab.Examples.PfSharedModelEx.currentUser.userVC = result.VirtualCurrency;
			PlayFab.Examples.PfSharedModelEx.currentUser.userVcRechargeTimes = result.VirtualCurrencyRechargeTimes;
			
			MainExampleController.DebugOutput("User Inventory Loaded.");
		}
		
		
		public static void LoadCharacterInventoryCallback(ClientModels.GetCharacterInventoryResult result)
		{
			PlayFab.Examples.PfSharedModelEx.currentCharacter.characterInventory = result.Inventory;
			PlayFab.Examples.PfSharedModelEx.currentCharacter.characterVC = result.VirtualCurrency;
			PlayFab.Examples.PfSharedModelEx.currentCharacter.characterVcRechargeTimes = result.VirtualCurrencyRechargeTimes;
			
			MainExampleController.DebugOutput("Character Inventory Loaded.");
		}
		

		public static void LoadCatalogFromPlayFab(string catalogVersion = null)
		{
			var catalogRequest = new ClientModels.GetCatalogItemsRequest();
			if(!string.IsNullOrEmpty(catalogVersion))
			{
				catalogRequest.CatalogVersion = catalogVersion;
			}
			PlayFabClientAPI.GetCatalogItems(catalogRequest, LoadCatalogFromPlayFabCallback, PfSharedControllerEx.FailCallback("GetCatalogItems"));
		}


		public static void LoadCatalogFromPlayFabCallback(ClientModels.GetCatalogItemsResult catalogResult)
        {
			ClientModels.GetCatalogItemsRequest request = (ClientModels.GetCatalogItemsRequest)catalogResult.Request;
			
			if(!string.IsNullOrEmpty(request.CatalogVersion))
			{ 
				PfSharedModelEx.titleCatalogs[request.CatalogVersion] = catalogResult.Catalog;
			}
			else
			{
				PfSharedModelEx.titleCatalogs["primary"] = catalogResult.Catalog;
			}
			
			MainExampleController.DebugOutput("Title Catalog Loaded.");
			// fire catalog loaded event (supply catalog version)
            // PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnCatalogLoaded, null, null, PfSharedControllerEx.Api.Client, false);
        }

		public static void LoadStoreFromPlayFab(string storeId, string catalogVersion = null)
		{
			if(!string.IsNullOrEmpty(storeId))
			{
				var storeRequest = new ClientModels.GetStoreItemsRequest();
				storeRequest.StoreId = storeId;
				
				if(!string.IsNullOrEmpty(catalogVersion))
				{
					storeRequest.CatalogVersion = catalogVersion;
				}
				PlayFabClientAPI.GetStoreItems(storeRequest, LoadStoreFromPlayFabCallback, PfSharedControllerEx.FailCallback("GetStoreItems"));
			}
		}
		
		public static void LoadStoreFromPlayFabCallback(ClientModels.GetStoreItemsResult storeResult)
		{
			ClientModels.GetStoreItemsRequest request = (ClientModels.GetStoreItemsRequest)storeResult.Request;
			PfSharedModelEx.titleStores[request.StoreId] = storeResult.Store;
			
			MainExampleController.DebugOutput("Store Loaded.");
			// fire catalog loaded event (supply catalog version)
			// PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnCatalogLoaded, null, null, PfSharedControllerEx.Api.Client, false);
		}
        #endregion Controller Event Handling


#region PlayFab Economy Methiods
	public static void PurchaseItem(string itemId, string vc, int price, string storeId = null, string catalogVersion = null)
	{
		ClientModels.PurchaseItemRequest request = new ClientModels.PurchaseItemRequest();
		request.ItemId = itemId;
		request.VirtualCurrency = vc;
		request.Price = price;
		
		if(!string.IsNullOrEmpty(catalogVersion))
		{
			request.CatalogVersion = catalogVersion;	
		}
		
		if(!string.IsNullOrEmpty(storeId))
		{
			request.StoreId = storeId;
		}
		
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PfSharedModelEx.ModelModes.Character)
		{
			request.CharacterId = PfSharedModelEx.currentCharacter.details.CharacterId;
		}
		
		PlayFabClientAPI.PurchaseItem(request, PurchaseItemCallback, PfSharedControllerEx.FailCallback("PurchaseItem"));
	}
	
	public static void PurchaseItemCallback(ClientModels.PurchaseItemResult result)
	{
		ClientModels.PurchaseItemRequest request = (ClientModels.PurchaseItemRequest)result.Request;
		
		// process the diff so that we do not have to fetch the entire inventory again.
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PfSharedModelEx.ModelModes.User)
		{
			// add newly purchased items to inventory
			PfSharedModelEx.currentUser.userInventory.AddRange(result.Items);
			
			// make VC adjustments
			PfSharedModelEx.currentUser.userVC[request.VirtualCurrency] -= request.Price;
		}
		else
		{
			// add newly purchased items to inventory
			PfSharedModelEx.currentCharacter.characterInventory.AddRange(result.Items);
			
			// make VC adjustments
			PfSharedModelEx.currentCharacter.characterVC[request.VirtualCurrency] -= request.Price;
		}
		
		MainExampleController.DebugOutput("Purchase Complete.");
	}
	
	
	public static void ConsumeItem(string instanceId, int count)
	{
		ClientModels.ConsumeItemRequest request = new ClientModels.ConsumeItemRequest();
		request.ItemInstanceId = instanceId;
		request.ConsumeCount = count;
		
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PfSharedModelEx.ModelModes.Character)
		{
			request.CharacterId = PfSharedModelEx.currentCharacter.details.CharacterId;				
		}

		PlayFabClientAPI.ConsumeItem(request, ConsumeItemCallback, PfSharedControllerEx.FailCallback("ConsumeItem"));
	}
	
	public static void ConsumeItemCallback(ClientModels.ConsumeItemResult result)
	{
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PfSharedModelEx.ModelModes.User)
		{
			for(int z = 0; z < PfSharedModelEx.currentUser.userInventory.Count; z++)
			{
				if(PfSharedModelEx.currentUser.userInventory[z].ItemInstanceId == result.ItemInstanceId)
				{
					// shouln't be less than 0, but in either event this item is completely consumed.
					if(result.RemainingUses <= 0)
					{
						PfSharedModelEx.currentUser.userInventory.RemoveAt(z);
					}
					else
					{
						PfSharedModelEx.currentUser.userInventory[z].RemainingUses = result.RemainingUses;
					}
				}
			}
		}
		else
		{
			for(int z = 0; z < PfSharedModelEx.currentCharacter.characterInventory.Count; z++)
			{
				if(PfSharedModelEx.currentCharacter.characterInventory[z].ItemInstanceId == result.ItemInstanceId)
				{
					// shouln't be less than 0, but in either event this item is completely consumed.
					if(result.RemainingUses <= 0)
					{
						PfSharedModelEx.currentCharacter.characterInventory.RemoveAt(z);
					}
					else
					{
						PfSharedModelEx.currentCharacter.characterInventory[z].RemainingUses = result.RemainingUses;
					}
				}
			}
		}
		
		MainExampleController.DebugOutput("Consume Item Complete.");
	}
	
	
	public static void UnlockContainer(string containerItemId, string catalogVersion = null)
	{
		ClientModels.UnlockContainerItemRequest request = new ClientModels.UnlockContainerItemRequest();
		request.ContainerItemId = containerItemId;
		
		if(!string.IsNullOrEmpty(catalogVersion))
		{
			request.CatalogVersion = catalogVersion;
		}
		
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PfSharedModelEx.ModelModes.Character)
		{
			request.CharacterId = PfSharedModelEx.currentCharacter.details.CharacterId;
		}
		
		PlayFabClientAPI.UnlockContainerItem(request, UnlockContainerCallback, PfSharedControllerEx.FailCallback("UnlockContainerItem"));
	}
	
	public static void UnlockContainerCallback(ClientModels.UnlockContainerItemResult result)
	{
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PfSharedModelEx.ModelModes.User)
		{
			// add items to the inventory
			PfSharedModelEx.currentUser.userInventory.AddRange(result.GrantedItems);
			
			// if consumable, decrement remaining uses on container
			for(int z = 0; z < PfSharedModelEx.currentUser.userInventory.Count; z++)
			{
				if(PfSharedModelEx.currentUser.userInventory[z].ItemInstanceId == result.UnlockedItemInstanceId)
				{
					if(PfSharedModelEx.currentUser.userInventory[z].RemainingUses != null)
					{
						if(PfSharedModelEx.currentUser.userInventory[z].RemainingUses > 1)
						{
							PfSharedModelEx.currentUser.userInventory[z].RemainingUses -= 1;
						}
						else
						{
							PfSharedModelEx.currentUser.userInventory.RemoveAt(z);
						}
					}
				}
			}
			
			// if a key was used and is consumable, decrement remaining uses on key
			if(!string.IsNullOrEmpty(result.UnlockedWithItemInstanceId))
			{
				for(int z = 0; z < PfSharedModelEx.currentUser.userInventory.Count; z++)
				{
					if(PfSharedModelEx.currentUser.userInventory[z].ItemInstanceId == result.UnlockedWithItemInstanceId)
					{
						if(PfSharedModelEx.currentUser.userInventory[z].RemainingUses != null)
						{
							if(PfSharedModelEx.currentUser.userInventory[z].RemainingUses > 1)
							{
								PfSharedModelEx.currentUser.userInventory[z].RemainingUses -= 1;
							}
							else
							{
								PfSharedModelEx.currentUser.userInventory.RemoveAt(z);
							}
						}
					}
				}
			}
			
			// if VC was obtained, add them
			foreach(var item in result.VirtualCurrency)
			{
				int currentValue;
				PfSharedModelEx.currentUser.userVC.TryGetValue(item.Key, out currentValue);
				PfSharedModelEx.currentUser.userVC[item.Key] = currentValue + (int)item.Value;
			}
		}
		else
		{
			// add items to the inventory
			PfSharedModelEx.currentCharacter.characterInventory.AddRange(result.GrantedItems);
			
			// if consumable, decrement remaining uses on container
			for(int z = 0; z < PfSharedModelEx.currentCharacter.characterInventory.Count; z++)
			{
				if(PfSharedModelEx.currentCharacter.characterInventory[z].ItemInstanceId == result.UnlockedItemInstanceId)
				{
					if(PfSharedModelEx.currentCharacter.characterInventory[z].RemainingUses != null)
					{
						if(PfSharedModelEx.currentCharacter.characterInventory[z].RemainingUses > 1)
						{
							PfSharedModelEx.currentCharacter.characterInventory[z].RemainingUses -= 1;
						}
						else
						{
							PfSharedModelEx.currentCharacter.characterInventory.RemoveAt(z);
						}
					}
				}
			}
			
			// if a key was used and is consumable, decrement remaining uses on key
			if(!string.IsNullOrEmpty(result.UnlockedWithItemInstanceId))
			{
				for(int z = 0; z < PfSharedModelEx.currentCharacter.characterInventory.Count; z++)
				{
					if(PfSharedModelEx.currentCharacter.characterInventory[z].ItemInstanceId == result.UnlockedWithItemInstanceId)
					{
						if(PfSharedModelEx.currentCharacter.characterInventory[z].RemainingUses != null)
						{
							if(PfSharedModelEx.currentCharacter.characterInventory[z].RemainingUses > 1)
							{
								PfSharedModelEx.currentCharacter.characterInventory[z].RemainingUses -= 1;
							}
							else
							{
								PfSharedModelEx.currentCharacter.characterInventory.RemoveAt(z);
							}
						}
					}
				}
			}
			
			// if VC was obtained, add them
			foreach(var item in result.VirtualCurrency)
			{
				int currentValue;
				PfSharedModelEx.currentCharacter.characterVC.TryGetValue(item.Key, out currentValue);
				PfSharedModelEx.currentCharacter.characterVC[item.Key] = currentValue + (int)item.Value;
			}
		}
		
		MainExampleController.DebugOutput("Unlock Container Complete.");
	}
	
	// SERVER CALLS WILL BE MOVED TO CLOUD SCRIPT
	private static void ModifyVcBalance()
	{}
	
	// SERVER CALLS WILL BE MOVED TO CLOUD SCRIPT
	private static void GrantItem()
	{}
	
	// SERVER CALLS WILL BE MOVED TO CLOUD SCRIPT
	private static void RevokeItem()
	{
		// waiting on Siva to complete moving this API over to Server/
	}
	
	
#endregion
	}
}
