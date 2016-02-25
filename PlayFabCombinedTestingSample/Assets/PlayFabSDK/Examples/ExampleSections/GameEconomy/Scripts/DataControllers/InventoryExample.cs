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

        }

        public static void SetUp()
        {
            // The static constructor is called as a by-product of this call
        }

		public static void LoadInventoryFromPlayFab()
		{
			if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PfSharedModelEx.ModelModes.User)
			{
				var getRequest = new ClientModels.GetUserInventoryRequest();
				PlayFabClientAPI.GetUserInventory(getRequest, LoadUserInventoryCallback, PfSharedControllerEx.FailCallback("GetUserInventory"));
			}
			else
			{
	            var getRequest = new ClientModels.GetCharacterInventoryRequest();
				getRequest.CharacterId = PlayFab.Examples.PfSharedModelEx.CurrentCharacter.Details.CharacterId;
				PlayFabClientAPI.GetCharacterInventory(getRequest, LoadCharacterInventoryCallback, PfSharedControllerEx.FailCallback("GetCharacterInventory"));
			}
		}
		
		public static void LoadUserInventoryCallback(ClientModels.GetUserInventoryResult result)
		{
			PlayFab.Examples.PfSharedModelEx.CurrentUser.UserInventory = result.Inventory;
			PlayFab.Examples.PfSharedModelEx.CurrentUser.UserVc = result.VirtualCurrency;
			PlayFab.Examples.PfSharedModelEx.CurrentUser.UserVcRechargeTimes = result.VirtualCurrencyRechargeTimes;
			
			MainExampleController.DebugOutput("User Inventory Loaded.");
		}
		
		
		public static void LoadCharacterInventoryCallback(ClientModels.GetCharacterInventoryResult result)
		{
			PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterInventory = result.Inventory;
			PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterVc = result.VirtualCurrency;
			PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterVcRechargeTimes = result.VirtualCurrencyRechargeTimes;
			
			MainExampleController.DebugOutput("Character Inventory Loaded.");
		}
		

		public static void LoadCatalogFromPlayFab(string catalogVersion = null)
		{
			var catalogRequest = new ClientModels.GetCatalogItemsRequest();
			if(!string.IsNullOrEmpty(catalogVersion) && catalogVersion != PfSharedModelEx.PrimaryCatalogVersion )
			{
				catalogRequest.CatalogVersion = catalogVersion;
			}
			PlayFabClientAPI.GetCatalogItems(catalogRequest, LoadCatalogFromPlayFabCallback, PfSharedControllerEx.FailCallback("GetCatalogItems"));
		}


		public static void LoadCatalogFromPlayFabCallback(ClientModels.GetCatalogItemsResult catalogResult)
        {
			ClientModels.GetCatalogItemsRequest request = (ClientModels.GetCatalogItemsRequest)catalogResult.Request;
			
			string catalogVersion = "";
			
			// if request is null, then we are using the primary catalog
			if(string.IsNullOrEmpty(request.CatalogVersion))
			{
				// if we have items, use the catalog from the first item 
				if(catalogResult.Catalog != null && catalogResult.Catalog.Count > 0)
				{
					PfSharedModelEx.PrimaryCatalogVersion = catalogResult.Catalog[0].CatalogVersion;
					catalogVersion = catalogResult.Catalog[0].CatalogVersion;
				}
				else
				{
					//Even if this is null, we dont have items, so something esle may be wrong.
					catalogVersion = PfSharedModelEx.PrimaryCatalogVersion;
				}
			}
			else
			{
				catalogVersion = request.CatalogVersion;
			}
			
			PfSharedModelEx.TitleCatalogs[catalogVersion] = catalogResult.Catalog;
			
			MainExampleController.DebugOutput("Title Catalog Loaded.");
		}

		// TODO address bug where catalog version is required.
		public static void LoadStoreFromPlayFab(string storeId, string catalogVersion)
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
			PfSharedModelEx.TitleStores[request.StoreId] = storeResult.Store;
			
			MainExampleController.DebugOutput("Store Loaded.");
		}
        #endregion Controller Event Handling


#region PlayFab Economy Methiods
	public static void PurchaseItem(string itemId, string vc, int price, int qty, string storeId = null, string catalogVersion = null)
	{
		if(qty == 1)
		{
			ClientModels.PurchaseItemRequest request = new ClientModels.PurchaseItemRequest();
			request.ItemId = itemId;
			request.VirtualCurrency = vc;
			request.Price = price;
			
			if(!string.IsNullOrEmpty(catalogVersion) && catalogVersion != PfSharedModelEx.PrimaryCatalogVersion )
			{
				request.CatalogVersion = catalogVersion;	
			}
			
			if(!string.IsNullOrEmpty(storeId))
			{
				request.StoreId = storeId;
			}
			
			if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PfSharedModelEx.ModelModes.Character)
			{
				request.CharacterId = PfSharedModelEx.CurrentCharacter.Details.CharacterId;
			}
			
			PlayFabClientAPI.PurchaseItem(request, PurchaseItemCallback, PfSharedControllerEx.FailCallback("PurchaseItem"));
		}
		else if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PfSharedModelEx.ModelModes.Character)
		{	
			UnityEngine.Debug.LogError("Purchasing more than one item at a time for characters is not possible.");
		}
		else
		{
			var multiRequest = new StartPurchaseRequest();
			
			if(!string.IsNullOrEmpty(catalogVersion) && catalogVersion != PfSharedModelEx.PrimaryCatalogVersion )
			{
				multiRequest.CatalogVersion = catalogVersion;	
			}
			
			if(!string.IsNullOrEmpty(storeId))
			{
				multiRequest.StoreId = storeId;
			}
			
			multiRequest.Items = new List<ItemPurchaseRequest>();
			multiRequest.Items.Add(new ItemPurchaseRequest { ItemId = itemId, Quantity = (uint)qty});
			PlayFabClientAPI.StartPurchase(multiRequest, StartPurchaseCallback, PfSharedControllerEx.FailCallback("StartPurchase"));
		}
	}
	
	public static void PurchaseItemCallback(ClientModels.PurchaseItemResult result)
	{
		ClientModels.PurchaseItemRequest request = (ClientModels.PurchaseItemRequest)result.Request;
		
		// process the diff so that we do not have to fetch the entire inventory again.
		if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PfSharedModelEx.ModelModes.User)
		{
			// add newly purchased items to inventory
			PfSharedModelEx.CurrentUser.UserInventory.AddRange(result.Items);
			
			// make VC adjustments
			PfSharedModelEx.CurrentUser.UserVc[request.VirtualCurrency] -= request.Price;
		}
		else
		{
			// add newly purchased items to inventory
			PfSharedModelEx.CurrentCharacter.CharacterInventory.AddRange(result.Items);
			
			// make VC adjustments
			PfSharedModelEx.CurrentCharacter.CharacterVc[request.VirtualCurrency] -= request.Price;
		}
		
		MainExampleController.DebugOutput("Purchase Complete.");
	}

	
	private static void StartPurchaseCallback(StartPurchaseResult result)
	{
		foreach (var payment in result.PaymentOptions)
		{
			if (payment.Currency == "RM")
				continue;
			
			var request = new PayForPurchaseRequest { Currency = payment.Currency, OrderId = result.OrderId, ProviderName = payment.ProviderName };
			PlayFabClientAPI.PayForPurchase(request, PayForPurchaseCallback, PfSharedControllerEx.FailCallback("PayForPurchase"));
			return; // Successful
		}
		
		// Failed to purchase items
		UnityEngine.Debug.LogError("Failed to purchase items"); // TODO: Add more info about items that failed
	}
	
	private static void PayForPurchaseCallback(PayForPurchaseResult result)
	{
		foreach (var vcBalancePair in result.VirtualCurrency)
			PfSharedModelEx.CurrentUser.UserVc[vcBalancePair.Key] = vcBalancePair.Value;
		
		var request = new ConfirmPurchaseRequest {OrderId = result.OrderId};
		PlayFabClientAPI.ConfirmPurchase(request, ConfirmPurchaseCallback, PfSharedControllerEx.FailCallback("ConfirmPurchase"));
	}
	
	private static void ConfirmPurchaseCallback(ConfirmPurchaseResult result)
	{
		// TODO: This may not have ideal results with stacks...
		PfSharedModelEx.CurrentUser.UserInventory.AddRange(result.Items);
		//PfSharedModelEx.globalClientUser.UpdateInvDisplay(PfSharedControllerEx.Api.Client);
		//PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, PfSharedModelEx.globalClientUser.playFabId, null, PfSharedControllerEx.Api.Client, false);
	}
	
	
	
	public static void ConsumeItem(string instanceId, int count)
	{
		ClientModels.ConsumeItemRequest request = new ClientModels.ConsumeItemRequest();
		request.ItemInstanceId = instanceId;
		request.ConsumeCount = count;
		
		if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PfSharedModelEx.ModelModes.Character)
		{
			request.CharacterId = PfSharedModelEx.CurrentCharacter.Details.CharacterId;				
		}

		PlayFabClientAPI.ConsumeItem(request, ConsumeItemCallback, PfSharedControllerEx.FailCallback("ConsumeItem"));
	}
	
	public static void ConsumeItemCallback(ClientModels.ConsumeItemResult result)
	{
		if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PfSharedModelEx.ModelModes.User)
		{
			for(int z = 0; z < PfSharedModelEx.CurrentUser.UserInventory.Count; z++)
			{
				if(PfSharedModelEx.CurrentUser.UserInventory[z].ItemInstanceId == result.ItemInstanceId)
				{
					// shouln't be less than 0, but in either event this item is completely consumed.
					if(result.RemainingUses <= 0)
					{
						PfSharedModelEx.CurrentUser.UserInventory.RemoveAt(z);
					}
					else
					{
						PfSharedModelEx.CurrentUser.UserInventory[z].RemainingUses = result.RemainingUses;
					}
				}
			}
		}
		else
		{
			for(int z = 0; z < PfSharedModelEx.CurrentCharacter.CharacterInventory.Count; z++)
			{
				if(PfSharedModelEx.CurrentCharacter.CharacterInventory[z].ItemInstanceId == result.ItemInstanceId)
				{
					// shouln't be less than 0, but in either event this item is completely consumed.
					if(result.RemainingUses <= 0)
					{
						PfSharedModelEx.CurrentCharacter.CharacterInventory.RemoveAt(z);
					}
					else
					{
						PfSharedModelEx.CurrentCharacter.CharacterInventory[z].RemainingUses = result.RemainingUses;
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
		
		if(!string.IsNullOrEmpty(catalogVersion) && catalogVersion != PfSharedModelEx.PrimaryCatalogVersion)
		{
			request.CatalogVersion = catalogVersion;
		}
		
		if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PfSharedModelEx.ModelModes.Character)
		{
			request.CharacterId = PfSharedModelEx.CurrentCharacter.Details.CharacterId;
		}
		
		PlayFabClientAPI.UnlockContainerItem(request, UnlockContainerCallback, PfSharedControllerEx.FailCallback("UnlockContainerItem"));
	}
	
	public static void UnlockContainerCallback(ClientModels.UnlockContainerItemResult result)
	{
		if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PfSharedModelEx.ModelModes.User)
		{
			// add items to the inventory
			PfSharedModelEx.CurrentUser.UserInventory.AddRange(result.GrantedItems);
			
			// if consumable, decrement remaining uses on container
			for(int z = 0; z < PfSharedModelEx.CurrentUser.UserInventory.Count; z++)
			{
				if(PfSharedModelEx.CurrentUser.UserInventory[z].ItemInstanceId == result.UnlockedItemInstanceId)
				{
					if(PfSharedModelEx.CurrentUser.UserInventory[z].RemainingUses != null)
					{
						if(PfSharedModelEx.CurrentUser.UserInventory[z].RemainingUses > 1)
						{
							PfSharedModelEx.CurrentUser.UserInventory[z].RemainingUses -= 1;
						}
						else
						{
							PfSharedModelEx.CurrentUser.UserInventory.RemoveAt(z);
						}
					}
				}
			}
			
			// if a key was used and is consumable, decrement remaining uses on key
			if(!string.IsNullOrEmpty(result.UnlockedWithItemInstanceId))
			{
				for(int z = 0; z < PfSharedModelEx.CurrentUser.UserInventory.Count; z++)
				{
					if(PfSharedModelEx.CurrentUser.UserInventory[z].ItemInstanceId == result.UnlockedWithItemInstanceId)
					{
						if(PfSharedModelEx.CurrentUser.UserInventory[z].RemainingUses != null)
						{
							if(PfSharedModelEx.CurrentUser.UserInventory[z].RemainingUses > 1)
							{
								PfSharedModelEx.CurrentUser.UserInventory[z].RemainingUses -= 1;
							}
							else
							{
								PfSharedModelEx.CurrentUser.UserInventory.RemoveAt(z);
							}
						}
					}
				}
			}
			
			// if VC was obtained, add them
			if(result.VirtualCurrency != null)
			{
				foreach(var item in result.VirtualCurrency)
				{
					int currentValue;
					PfSharedModelEx.CurrentUser.UserVc.TryGetValue(item.Key, out currentValue);
					PfSharedModelEx.CurrentUser.UserVc[item.Key] = currentValue + (int)item.Value;
				}
			}
		}
		else
		{
			// add items to the inventory
			PfSharedModelEx.CurrentCharacter.CharacterInventory.AddRange(result.GrantedItems);
			
			// if consumable, decrement remaining uses on container
			for(int z = 0; z < PfSharedModelEx.CurrentCharacter.CharacterInventory.Count; z++)
			{
				if(PfSharedModelEx.CurrentCharacter.CharacterInventory[z].ItemInstanceId == result.UnlockedItemInstanceId)
				{
					if(PfSharedModelEx.CurrentCharacter.CharacterInventory[z].RemainingUses != null)
					{
						if(PfSharedModelEx.CurrentCharacter.CharacterInventory[z].RemainingUses > 1)
						{
							PfSharedModelEx.CurrentCharacter.CharacterInventory[z].RemainingUses -= 1;
						}
						else
						{
							PfSharedModelEx.CurrentCharacter.CharacterInventory.RemoveAt(z);
						}
					}
				}
			}
			
			// if a key was used and is consumable, decrement remaining uses on key
			if(!string.IsNullOrEmpty(result.UnlockedWithItemInstanceId))
			{
				for(int z = 0; z < PfSharedModelEx.CurrentCharacter.CharacterInventory.Count; z++)
				{
					if(PfSharedModelEx.CurrentCharacter.CharacterInventory[z].ItemInstanceId == result.UnlockedWithItemInstanceId)
					{
						if(PfSharedModelEx.CurrentCharacter.CharacterInventory[z].RemainingUses != null)
						{
							if(PfSharedModelEx.CurrentCharacter.CharacterInventory[z].RemainingUses > 1)
							{
								PfSharedModelEx.CurrentCharacter.CharacterInventory[z].RemainingUses -= 1;
							}
							else
							{
								PfSharedModelEx.CurrentCharacter.CharacterInventory.RemoveAt(z);
							}
						}
					}
				}
			}
			
			// if VC was obtained, add them
			if(result.VirtualCurrency != null)
			{
				foreach(var item in result.VirtualCurrency)
				{
					int currentValue;
					PfSharedModelEx.CurrentCharacter.CharacterVc.TryGetValue(item.Key, out currentValue);
					PfSharedModelEx.CurrentCharacter.CharacterVc[item.Key] = currentValue + (int)item.Value;
				}
			}
		}
		
		MainExampleController.DebugOutput("Unlock Container Complete.");
	}
	
	// SERVER CALLS WILL BE MOVED TO CLOUD SCRIPT
	public static void ModifyVcBalance(string vcCode, int vcAmount)
	{
		if(vcAmount != 0)
		{
			RunCloudScriptRequest request = new RunCloudScriptRequest();
			if(PfSharedModelEx.ActiveMode == PfSharedModelEx.ModelModes.User)
			{
				request.ActionId = "UpdateUserVcBalance";
				request.Params = new { vc = vcCode, amount = vcAmount};
				PlayFabClientAPI.RunCloudScript(request, ModifyUserVcCallback, PfSharedControllerEx.FailCallback("ModifyUserVcBalance"));
			}
			else
			{
				request.ActionId = "UpdateCharacterVcBalance";
				request.Params = new {characterId = PfSharedModelEx.CurrentCharacter.Details.CharacterId, vc = vcCode, amount = vcAmount};
				PlayFabClientAPI.RunCloudScript(request, ModifyCharacterVcCallback, PfSharedControllerEx.FailCallback("ModifyCharacterVcBalance"));
			}
		}
	}
	
	public static void ModifyCharacterVcCallback(ClientModels.RunCloudScriptResult result)
	{
		ModifyUserVirtualCurrencyResult csResult = null;
		try
		{
			csResult = PlayFab.Json.JsonConvert.DeserializeObject<ModifyUserVirtualCurrencyResult>(result.ResultsEncoded);
			MainExampleController.DebugOutput("Successful Cast with ModifyCharacterVcCallback -- " + csResult.VirtualCurrency + " : " + csResult.Balance);
			PfSharedModelEx.CurrentCharacter.CharacterVc[csResult.VirtualCurrency] = csResult.Balance;
		}
		catch (System.Exception ex)
		{
			MainExampleController.DebugOutput("Cast error after ModifyCharacterVcCallback -- " + ex.Message);
		}
	}
	
	public static void ModifyUserVcCallback(ClientModels.RunCloudScriptResult result)
	{
		ModifyUserVirtualCurrencyResult csResult = null;
		try
		{
			csResult = PlayFab.Json.JsonConvert.DeserializeObject<ModifyUserVirtualCurrencyResult>(result.ResultsEncoded);
			MainExampleController.DebugOutput("Successful Cast with ModifyUserVcCallback -- " + csResult.VirtualCurrency + " : " + csResult.Balance);
			PfSharedModelEx.CurrentUser.UserVc[csResult.VirtualCurrency] = csResult.Balance;
			
		}
		catch (System.Exception ex)
		{
			MainExampleController.DebugOutput("Cast error after ModifyUserVcCallback -- " + ex.Message);
		}
	}
	
	// SERVER CALLS WILL BE MOVED TO CLOUD SCRIPT
	public static void GrantItem(string id, string catalogVer)
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		if(PfSharedModelEx.ActiveMode == PfSharedModelEx.ModelModes.User)
		{
			request.ActionId = "GrantItemToUser";
			request.Params = new { itemId = id, catalogVersion = catalogVer};
			PlayFabClientAPI.RunCloudScript(request, GrantItemToUserCallback, PfSharedControllerEx.FailCallback("GrantItemToUser"));
		}
		else
		{
			request.ActionId = "GrantItemToCharacter";
			request.Params = new {characterId = PfSharedModelEx.CurrentCharacter.Details.CharacterId, itemId = id, catalogVersion = catalogVer };
			PlayFabClientAPI.RunCloudScript(request, GrantItemToCharacterCallback, PfSharedControllerEx.FailCallback("GrantItemToCharacter"));
		}
	}
	
	public static void GrantItemToUserCallback(ClientModels.RunCloudScriptResult result)
	{
		GrantItemsResult csResult = null;
		try
		{
			csResult = PlayFab.Json.JsonConvert.DeserializeObject<GrantItemsResult>(result.ResultsEncoded);
			MainExampleController.DebugOutput("Successful Cast with GrantUserItem -- (" + csResult.ItemGrantResults.Count + ")");
			PfSharedModelEx.CurrentUser.UserInventory.AddRange(csResult.ItemGrantResults);
		}
		catch (System.Exception ex)
		{
			MainExampleController.DebugOutput("Cast error after GrantUserItemCallback -- " + ex.Message);
		}
	}
	
	public static void GrantItemToCharacterCallback(ClientModels.RunCloudScriptResult result)
	{
		GrantItemsResult csResult = null;
		try
		{
			csResult = PlayFab.Json.JsonConvert.DeserializeObject<GrantItemsResult>(result.ResultsEncoded);
			MainExampleController.DebugOutput("Successful Cast with GrantCharacterItem -- (" + csResult.ItemGrantResults.Count + ")");
			PfSharedModelEx.CurrentCharacter.CharacterInventory.AddRange(csResult.ItemGrantResults);
		}
		catch (System.Exception ex)
		{
			MainExampleController.DebugOutput("Cast error after GrantCharacterItem -- " + ex.Message);
		}
	}
	
	
	// SERVER CALLS WILL BE MOVED TO CLOUD SCRIPT
	public static void RevokeItem(string id)
	{
		throw new System.NotImplementedException();
	}
	
	
#endregion
	}
}


// moved over from severAPI models
public class GrantItemsResult
{
	/// <summary>
	/// Array of items granted to users.
	/// </summary>
	public List<ItemInstance> ItemGrantResults { get; set;}
	public object Request { get; set; }
	public object CustomData { get; set;  }
}

/// <summary>
/// Result of granting an item to a user
/// </summary>
public class GrantedItemInstance
{
	
	/// <summary>
	/// Unique PlayFab assigned ID of the user on whom the operation will be performed.
	/// </summary>
	public string PlayFabId { get; set;}
	
	/// <summary>
	/// Unique PlayFab assigned ID for a specific character owned by a user
	/// </summary>
	public string CharacterId { get; set;}
	
	/// <summary>
	/// Result of this operation.
	/// </summary>
	public bool Result { get; set;}
	
	/// <summary>
	/// Unique identifier for the inventory item, as defined in the catalog.
	/// </summary>
	public string ItemId { get; set;}
	
	/// <summary>
	/// Unique item identifier for this specific instance of the item.
	/// </summary>
	public string ItemInstanceId { get; set;}
	
	/// <summary>
	/// Class name for the inventory item, as defined in the catalog.
	/// </summary>
	public string ItemClass { get; set;}
	
	/// <summary>
	/// Timestamp for when this instance was purchased.
	/// </summary>
	public System.DateTime? PurchaseDate { get; set;}
	
	/// <summary>
	/// Timestamp for when this instance will expire.
	/// </summary>
	public System.DateTime? Expiration { get; set;}
	
	/// <summary>
	/// Total number of remaining uses, if this is a consumable item.
	/// </summary>
	public int? RemainingUses { get; set;}
	
	/// <summary>
	/// The number of uses that were added or removed to this item in this call.
	/// </summary>
	public int? UsesIncrementedBy { get; set;}
	
	/// <summary>
	/// Game specific comment associated with this instance when it was added to the user inventory.
	/// </summary>
	public string Annotation { get; set;}
	
	/// <summary>
	/// Catalog version for the inventory item, when this instance was created.
	/// </summary>
	public string CatalogVersion { get; set;}
	
	/// <summary>
	/// Unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container.
	/// </summary>
	public string BundleParent { get; set;}
	
	/// <summary>
	/// CatalogItem.DisplayName at the time this item was purchased.
	/// </summary>
	public string DisplayName { get; set;}
	
	/// <summary>
	/// Currency type for the cost of the catalog item.
	/// </summary>
	public string UnitCurrency { get; set;}
	
	/// <summary>
	/// Cost of the catalog item in the given currency.
	/// </summary>
	public uint UnitPrice { get; set;}
	
	/// <summary>
	/// Array of unique items that were awarded when this catalog item was purchased.
	/// </summary>
	public List<string> BundleContents { get; set;}
	
	/// <summary>
	/// A set of custom key-value pairs on the inventory item.
	/// </summary>
	public Dictionary<string,string> CustomData { get; set;}
}

