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
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserLogin, OnUserLogin);
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, OnUserCharactersLoaded);
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, OnInventoryChanged);
        }

        public static void SetUp()
        {
            // The static constructor is called as a by-product of this call
        }

        private static void OnUserLogin(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            /*
            	get catalog
            	get user inv
            	
            */
            
            GetUserInventory();
            var catalogRequest = new ClientModels.GetCatalogItemsRequest();
            PlayFabClientAPI.GetCatalogItems(catalogRequest, GetCatalogCallback, PfSharedControllerEx.FailCallback("GetCatalogItems"));
        }

		// OnCharacterListLoaded.
			// getinventory
			
		//On activeCharacterToggle
		
		//On ExampleStart
		
		

//
		public static void LoginCallBack(LoginResult loginResult)
		{
			// CLIENT
//			PfSharedModelEx.globalClientUser.playFabId = loginResult.PlayFabId;
//			PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserLogin, loginResult.PlayFabId, null, PfSharedControllerEx.Api.Client, false);
//			var clientRequest = new ListUsersCharactersRequest();
//			PlayFabClientAPI.GetAllUsersCharacters(clientRequest, ClientCharCallBack, PfSharedControllerEx.FailCallback("C_GetAllUsersCharacters"));
			
		}
//		
//		public static void ClientCharCallBack(ListUsersCharactersResult charResult)
//		{
//			CharacterModel temp;
//			foreach (var character in charResult.Characters)
//			{
//				if (!PfSharedModelEx.globalClientUser.clientCharacterModels.TryGetValue(character.CharacterId, out temp))
//					PfSharedModelEx.globalClientUser.clientCharacterModels[character.CharacterId] = new PfInvClientChar(PfSharedModelEx.globalClientUser.playFabId, character.CharacterId, character.CharacterName);
//				PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, PfSharedModelEx.globalClientUser.playFabId, character.CharacterId, PfSharedControllerEx.Api.Client, false);
//			}
//		}


        private static void OnUserCharactersLoaded(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
//            if (eventSourceApi != PfSharedControllerEx.Api.Client)
//                return;
//
//            CharacterModel charModel;
//            if (PfSharedModelEx.currentUser.userCharacters.TryGetValue(characterId, out charModel))
//                ((PfInvClientChar)charModel).GetInventory();
        }

        private static void GetCatalogCallback(ClientModels.GetCatalogItemsResult catalogResult)
        {
//            PfSharedModelEx.titleCatalog.Clear();
//            foreach (var catalogItem in catalogResult.Catalog)
//                PfSharedModelEx.titleCatalog[catalogItem.ItemId] = catalogItem;
            //PfSharedModelEx.consumableItemIds.Clear();
            //PfSharedModelEx.containerItemIds.Clear();

//            foreach (var each in catalogResult.Catalog)
//            {
//                if (each.Container != null)
//                    PfSharedModelEx.containerItemIds.Add(each.ItemId);
//                else if (each.Consumable != null && each.Consumable.UsageCount > 0)
//                    PfSharedModelEx.consumableItemIds.Add(each.ItemId);
//            }
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnCatalogLoaded, null, null, PfSharedControllerEx.Api.Client, false);
        }

        private static void OnInventoryChanged(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            if (!requiresFullRefresh && (eventSourceApi & PfSharedControllerEx.Api.Client) == PfSharedControllerEx.Api.Client)
                return; // Don't need to handle this event

            if (string.IsNullOrEmpty(characterId))
            {
                // Reload the user inventory
                GetUserInventory();
            }
            else
            {
                // Reload the character inventory
//                CharacterModel tempCharacter;
//                if (!PfSharedModelEx.currentUser.userCharacters.TryGetValue(characterId, out tempCharacter))
//                    return;
//                PfInvClientChar eachCharacter = tempCharacter as PfInvClientChar;
//                if (eachCharacter == null || eachCharacter.inventory == null)
//                    return;
//
//                eachCharacter.GetInventory();
            }
        }
        #endregion Controller Event Handling


#region PlayFab Economy Methiods
	public static void PurchaseItemFromStore()
	{
		
	}
	
	public static void PurchaseItemFromCatalog()
	{
		
	}
	
	public static void UpdateItemUses()
	{
		
	}
	
	public static void UpdateVcBalance()
	{
	
	}
	
#endregion


        #region Example Implementation of PlayFab Inventory APIs
        public static void PurchaseUserItem(string itemId)
        {
//            string vcKey; int cost;
//            if (PfSharedModelEx.currentUser.GetClientItemPrice(null, itemId, out vcKey, out cost))
//            {
//                var purchaseRequest = new ClientModels.PurchaseItemRequest();
//                purchaseRequest.ItemId = itemId;
//                purchaseRequest.VirtualCurrency = vcKey;
//                purchaseRequest.Price = cost;
//                PlayFabClientAPI.PurchaseItem(purchaseRequest, PurchaseUserItemCallback, PfSharedControllerEx.FailCallback("PurchaseItem"));
//            }
//            else
//            {
//                UnityEngine.Debug.LogWarning("You cannot afford this item");
//            }
        }
        public static void PurchaseUserItemCallback(ClientModels.PurchaseItemResult purchaseResult)
        {
            // Merge the items we bought with the items we know we have
//            PfSharedModelEx.currentUser.clientUserItems.AddRange(purchaseResult.Items);
//            string vcKey = ((ClientModels.PurchaseItemRequest)purchaseResult.Request).VirtualCurrency;
//            int cost = ((ClientModels.PurchaseItemRequest)purchaseResult.Request).Price;
//            PfSharedModelEx.currentUser.ModifyVcBalance(null, vcKey, -cost);
//
//            PfSharedModelEx.currentUser.UpdateInvDisplay(PfSharedControllerEx.Api.Client);
//            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client, false);
//            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnVcChanged, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static void GetUserInventory()
        {
            var getRequest = new ClientModels.GetUserInventoryRequest();
            PlayFabClientAPI.GetUserInventory(getRequest, GetUserItemsCallback, PfSharedControllerEx.FailCallback("GetUserInventory"));
        }
        public static void GetUserItemsCallback(ClientModels.GetUserInventoryResult getResult)
        {
//            PfSharedModelEx.currentUser.clientUserItems = getResult.Inventory;
//            PfSharedModelEx.currentUser.UpdateInvDisplay(PfSharedControllerEx.Api.Client);
        }

        public static void ConsumeUserItem(string itemInstanceId)
        {
            var consumeRequest = new ClientModels.ConsumeItemRequest();
            consumeRequest.ConsumeCount = 1;
            consumeRequest.CharacterId = null; // To indicate user inventory
            consumeRequest.ItemInstanceId = itemInstanceId;
            PlayFabClientAPI.ConsumeItem(consumeRequest, ConsumeItemCallback, PfSharedControllerEx.FailCallback("ConsumeItem"));
        }
        public static void ConsumeItemCallback(ClientModels.ConsumeItemResult consumeResult)
        {
//            string characterId = ((ClientModels.ConsumeItemRequest)consumeResult.Request).CharacterId;
//            //if (consumeResult.RemainingUses == 0)
//                //PfSharedModelEx.globalClientUser.RemoveItems(characterId, new HashSet<string>() { consumeResult.ItemInstanceId });
//           // else
//                PfSharedModelEx.currentUser.UpdateRemainingUses(characterId, consumeResult.ItemInstanceId, consumeResult.RemainingUses);
//
//            PfSharedModelEx.currentUser.UpdateInvDisplay(PfSharedControllerEx.Api.Client);
//            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, PfSharedModelEx.currentUser.playFabId, characterId, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static void UnlockUserContainer(string itemId)
        {
            var unlockRequest = new ClientModels.UnlockContainerItemRequest();
            unlockRequest.CharacterId = null; // To indicate user inventory
            unlockRequest.ContainerItemId = itemId;
            PlayFabClientAPI.UnlockContainerItem(unlockRequest, UnlockUserContainerCallback, PfSharedControllerEx.FailCallback("UnlockContainerItem"));
        }
        public static void UnlockUserContainerCallback(ClientModels.UnlockContainerItemResult unlockResult)
        {
//            string characterId = ((ClientModels.UnlockContainerItemRequest)unlockResult.Request).CharacterId;
//
//            PfSharedModelEx.currentUser.clientUserItems.AddRange(unlockResult.GrantedItems);
//            var unlockedItem = PfSharedModelEx.currentUser.GetClientItem(characterId, unlockResult.UnlockedItemInstanceId);
//            if (unlockedItem != null && unlockedItem.RemainingUses > 0)
//            {
//                unlockedItem.RemainingUses -= 1;
////                if (unlockedItem.RemainingUses <= 0)
////                    PfSharedModelEx.globalClientUser.RemoveItems(characterId, new HashSet<string>() { unlockResult.UnlockedItemInstanceId });
//            }
//
//            PfSharedModelEx.currentUser.UpdateInvDisplay(PfSharedControllerEx.Api.Client);
//            bool needsFullRefresh = (unlockedItem == null); // If we couldn't find our unlocked item, we're stuck and we need a full refresh
//            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, PfSharedModelEx.currentUser.playFabId, characterId, PfSharedControllerEx.Api.Client, needsFullRefresh);
//            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnVcChanged, PfSharedModelEx.currentUser.playFabId, characterId, PfSharedControllerEx.Api.Client, true); // unlockResult contains no information about potential currency we may have gained
        }
        #endregion Example Implementation of PlayFab Inventory APIs
    }

//    /// <summary>
//    /// A wrapper for inventory related, character centric, API calls and info
//    /// This mostly exists because the characterId needs to be available at all steps in the process, and a class-wrapper avoids most of the Lambda-hell
//    /// </summary>
//    public class PfInvClientChar : ClientCharacterModel
//    {
//        public PfInvClientChar(string playFabId, string characterId, string characterName)
//            : base(playFabId, characterId, characterName)
//        {
//        }
//
//        public void PurchaseCharacterItem(string itemId)
//        {
//            string vcKey; int cost;
//            if (PfSharedModelEx.globalClientUser.GetClientItemPrice(null, itemId, out vcKey, out cost))
//            {
//                var purchaseRequest = new ClientModels.PurchaseItemRequest();
//                purchaseRequest.CharacterId = characterId;
//                purchaseRequest.ItemId = itemId;
//                purchaseRequest.VirtualCurrency = vcKey;
//                purchaseRequest.Price = cost;
//                PlayFabClientAPI.PurchaseItem(purchaseRequest, PurchaseItemCallback, PfSharedControllerEx.FailCallback("PurchaseItem"));
//            }
//            else
//            {
//                UnityEngine.Debug.LogWarning("You cannot afford this item");
//            }
//        }
//        public void PurchaseItemCallback(ClientModels.PurchaseItemResult purchaseResult)
//        {
//            string characterId = ((ClientModels.PurchaseItemRequest)purchaseResult.Request).CharacterId;
//
//            // Merge the items we bought with the items we know we have
//            CharacterModel tempModel;
//            if (PfSharedModelEx.globalClientUser.clientCharacterModels.TryGetValue(characterId, out tempModel))
//            {
//                PfInvClientChar characterModel = tempModel as PfInvClientChar;
//                if (characterModel != null)
//                    characterModel.inventory.AddRange(purchaseResult.Items);
//                tempModel.UpdateInvDisplay();
//            }
//            string vcKey = ((ClientModels.PurchaseItemRequest)purchaseResult.Request).VirtualCurrency;
//            int cost = ((ClientModels.PurchaseItemRequest)purchaseResult.Request).Price;
//            PfSharedModelEx.globalClientUser.ModifyVcBalance(characterId, vcKey, -cost);
//
//            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, PfSharedModelEx.globalClientUser.playFabId, characterId, PfSharedControllerEx.Api.Client, false);
//            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnVcChanged, PfSharedModelEx.globalClientUser.playFabId, characterId, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
//        }
//
//        public void GetInventory()
//        {
//            var getRequest = new ClientModels.GetCharacterInventoryRequest();
//            getRequest.CharacterId = characterId;
//            PlayFabClientAPI.GetCharacterInventory(getRequest, GetInventoryCallback, PfSharedControllerEx.FailCallback("GetCharacterInventory"));
//        }
//        public void GetInventoryCallback(ClientModels.GetCharacterInventoryResult getResult)
//        {
//            PfSharedControllerEx.sb.Length = 0;
//            for (int i = 0; i < getResult.Inventory.Count; i++)
//            {
//                if (i != 0)
//                    PfSharedControllerEx.sb.Append(", ");
//                PfSharedControllerEx.sb.Append(getResult.Inventory[i].DisplayName);
//            }
//            //inventoryDisplay = PfSharedControllerEx.sb.ToString();
//            inventory = getResult.Inventory;
//        }
//
//        public void ConsumeItem(string itemInstanceId)
//        {
//            var consumeRequest = new ClientModels.ConsumeItemRequest();
//            consumeRequest.ConsumeCount = 1;
//            consumeRequest.CharacterId = characterId;
//            consumeRequest.ItemInstanceId = itemInstanceId;
//            PlayFabClientAPI.ConsumeItem(consumeRequest, ConsumeItemCallback, PfSharedControllerEx.FailCallback("ConsumeItem"));
//        }
//        public void ConsumeItemCallback(ClientModels.ConsumeItemResult consumeResult)
//        {
//           // if (consumeResult.RemainingUses == 0)
//            //    PfSharedModelEx.globalClientUser.RemoveItems(characterId, new HashSet<string>() { consumeResult.ItemInstanceId });
////            else
//                PfSharedModelEx.globalClientUser.UpdateRemainingUses(characterId, consumeResult.ItemInstanceId, consumeResult.RemainingUses);
//
//            CharacterModel tempModel;
//            if (PfSharedModelEx.globalClientUser.clientCharacterModels.TryGetValue(characterId, out tempModel))
//                tempModel.UpdateInvDisplay();
//
//            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, PfSharedModelEx.globalClientUser.playFabId, characterId, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
//        }
//
//        public void UnlockContainer(string itemId)
//        {
//            var unlockRequest = new ClientModels.UnlockContainerItemRequest();
//            unlockRequest.CharacterId = characterId;
//            unlockRequest.ContainerItemId = itemId;
//            PlayFabClientAPI.UnlockContainerItem(unlockRequest, UnlockContainerCallback, PfSharedControllerEx.FailCallback("UnlockContainerItem"));
//        }
//        public void UnlockContainerCallback(ClientModels.UnlockContainerItemResult unlockResult)
//        {
//            // Merge the items we bought with the items we know we have
//            CharacterModel tempModel;
//            if (PfSharedModelEx.globalClientUser.clientCharacterModels.TryGetValue(characterId, out tempModel))
//            {
//                PfInvClientChar characterModel = tempModel as PfInvClientChar;
//                if (characterModel != null)
//                    characterModel.inventory.AddRange(unlockResult.GrantedItems);
//            }
//
//            // Get the unlocked item before we remove it (we need info from it later)
//            var unlockedItem = PfSharedModelEx.globalClientUser.GetClientItem(characterId, unlockResult.UnlockedItemInstanceId);
//            if (unlockedItem != null && unlockedItem.RemainingUses > 0)
//            {
//                unlockedItem.RemainingUses -= 1;
//             //   if (unlockedItem.RemainingUses <= 0)
//              //      PfSharedModelEx.globalClientUser.RemoveItems(characterId, new HashSet<string>() { unlockResult.UnlockedItemInstanceId });
//            }
//
//            if (tempModel != null)
//                tempModel.UpdateInvDisplay();
//
//            bool needsFullRefresh = (unlockedItem == null); // If we couldn't find our unlocked item, we're stuck and we need a full refresh
//            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, PfSharedModelEx.globalClientUser.playFabId, characterId, PfSharedControllerEx.Api.Client, needsFullRefresh);
//            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnVcChanged, PfSharedModelEx.globalClientUser.playFabId, characterId, PfSharedControllerEx.Api.Client, true); // unlockResult contains no information about potential currency we may have gained
//        }
//    }
}
