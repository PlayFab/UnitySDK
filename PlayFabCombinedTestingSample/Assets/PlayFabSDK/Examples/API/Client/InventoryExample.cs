using System;
using System.Collections.Generic;

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
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnAllCharactersLoaded, OnAllCharactersLoaded);
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, OnInventoryChanged);
        }

        public static void SetUp()
        {
            // The static constructor is called as a by-product of this call
        }

        private static void OnUserLogin(string playFabId)
        {
            var catalogRequest = new ClientModels.GetCatalogItemsRequest();
            PlayFabClientAPI.GetCatalogItems(catalogRequest, GetCatalogCallback, PfSharedControllerEx.FailCallback("GetCatalogItems"));
        }

        private static void OnAllCharactersLoaded(string trash)
        {
            GetUserInventory();
            PfSharedModelEx.clientCharInventories.Clear();
            for (int i = 0; i < PfSharedModelEx.characterIds.Count; i++)
            {
                var newInv = new PfInvClientChar(PfSharedModelEx.playFabId, PfSharedModelEx.characterIds[i], PfSharedModelEx.characterNames[i]);
                PfSharedModelEx.clientCharInventories[PfSharedModelEx.characterIds[i]] = newInv;
            }
        }

        private static void GetCatalogCallback(ClientModels.GetCatalogItemsResult catalogResult)
        {
            PfSharedModelEx.clientCatalog.Clear();
            foreach (var catalogItem in catalogResult.Catalog)
                PfSharedModelEx.clientCatalog[catalogItem.ItemId] = catalogItem;
            PfSharedModelEx.consumableItemIds.Clear();
            PfSharedModelEx.containerItemIds.Clear();

            foreach (var each in catalogResult.Catalog)
            {
                if (each.Container != null)
                    PfSharedModelEx.containerItemIds.Add(each.ItemId);
                else if (each.Consumable != null && each.Consumable.UsageCount > 0)
                    PfSharedModelEx.consumableItemIds.Add(each.ItemId);
            }
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnCatalogLoaded, null);
        }

        private static void OnInventoryChanged(string characterId)
        {
            if (characterId == null)
            {
                // Reload the user inventory
                GetUserInventory();
            }
            else
            {
                // Reload the character inventory
                PfCharInv tempCharater;
                if (!PfSharedModelEx.clientCharInventories.TryGetValue(characterId, out tempCharater))
                    return;
                PfInvClientChar eachCharacter = tempCharater as PfInvClientChar;
                if (eachCharacter == null || eachCharacter.inventory == null)
                    return;

                eachCharacter.GetInventory();
            }
        }
        #endregion Controller Event Handling

        #region Example Implementation of PlayFab Inventory APIs
        public static Action PurchaseUserItem(string itemId)
        {
            Action output = () =>
            {
                var purchaseRequest = new ClientModels.PurchaseItemRequest();
                purchaseRequest.ItemId = itemId;
                purchaseRequest.VirtualCurrency = "TODO";
                purchaseRequest.Price = 99999999;
                PlayFabClientAPI.PurchaseItem(purchaseRequest, PurchaseItemCallback, PfSharedControllerEx.FailCallback("PurchaseItem"));
            };
            return output;
        }
        public static void PurchaseItemCallback(ClientModels.PurchaseItemResult purchaseResult)
        {
            // You could theoretically keep your local inventory up-to-date with local information, but it's safer to have the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, null);
        }

        public static void GetUserInventory()
        {
            var getRequest = new ClientModels.GetUserInventoryRequest();
            PlayFabClientAPI.GetUserInventory(getRequest, GetUserItemsCallback, PfSharedControllerEx.FailCallback("GetUserInventory"));
        }
        public static void GetUserItemsCallback(ClientModels.GetUserInventoryResult getResult)
        {
            PfSharedModelEx.clientUserItems = getResult.Inventory;
            PfSharedControllerEx.sb.Length = 0;
            for (int i = 0; i < getResult.Inventory.Count; i++)
            {
                if (i != 0)
                    PfSharedControllerEx.sb.Append(", ");
                PfSharedControllerEx.sb.Append(getResult.Inventory[i].DisplayName);
            }
            PfSharedModelEx.userInvDisplay = PfSharedControllerEx.sb.ToString();
            PfSharedModelEx.clientUserItems = getResult.Inventory;
        }

        public static Action ConsumeUserItem(string itemInstanceId)
        {
            Action output = () =>
            {
                var consumeRequest = new ClientModels.ConsumeItemRequest();
                consumeRequest.ConsumeCount = 1;
                consumeRequest.CharacterId = null; // To indicate user inventory
                consumeRequest.ItemInstanceId = itemInstanceId;
                PlayFabClientAPI.ConsumeItem(consumeRequest, ConsumeItemCallback, PfSharedControllerEx.FailCallback("ConsumeItem"));
            };
            return output;
        }
        public static void ConsumeItemCallback(ClientModels.ConsumeItemResult consumeResult)
        {
            // You could theoretically keep your local inventory up-to-date with local information, but it's safer to refresh the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, null);
        }

        public static Action UnlockUserContainer(string itemId)
        {
            Action output = () =>
            {
                var unlockRequest = new ClientModels.UnlockContainerItemRequest();
                unlockRequest.CharacterId = null; // To indicate user inventory
                unlockRequest.ContainerItemId = itemId;
                PlayFabClientAPI.UnlockContainerItem(unlockRequest, UnlockUserContainerCallback, PfSharedControllerEx.FailCallback("UnlockContainerItem"));
            };
            return output;
        }
        public static void UnlockUserContainerCallback(ClientModels.UnlockContainerItemResult unlockResult)
        {
            // You could theoretically keep your local inventory up-to-date with local information, but it's safer to refresh the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, null);
        }
        #endregion Example Implementation of PlayFab Inventory APIs
    }

    /// <summary>
    /// A wrapper for inventory related, character centric, API calls and info
    /// This mostly exists because the characterId needs to be available at all steps in the process, and a class-wrapper avoids most of the Lambda-hell
    /// </summary>
    public class PfInvClientChar : PfCharInv
    {
        public List<ClientModels.ItemInstance> inventory;

        public PfInvClientChar(string playFabId, string characterId, string characterName)
            : base(playFabId, characterId, characterName)
        {
            GetInventory();
        }

        public Action PurchaseCharacterItem(string itemId)
        {
            Action output = () =>
            {
                var purchaseRequest = new ClientModels.PurchaseItemRequest();
                purchaseRequest.CharacterId = characterId;
                purchaseRequest.ItemId = itemId;
                purchaseRequest.VirtualCurrency = "TODO";
                purchaseRequest.Price = 999999;
                PlayFabClientAPI.PurchaseItem(purchaseRequest, PurchaseItemCallback, PfSharedControllerEx.FailCallback("PurchaseItem"));
            };
            return output;
        }
        public void PurchaseItemCallback(ClientModels.PurchaseItemResult purchaseResult)
        {
            // You could theoretically keep your local inventory up-to-date with local information, but it's safer to refresh the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, characterId);
        }

        public void GetInventory()
        {
            var getRequest = new ClientModels.GetCharacterInventoryRequest();
            getRequest.CharacterId = characterId;
            PlayFabClientAPI.GetCharacterInventory(getRequest, GetInventoryCallback, PfSharedControllerEx.FailCallback("GetCharacterInventory"));
        }
        public void GetInventoryCallback(ClientModels.GetCharacterInventoryResult getResult)
        {
            PfSharedControllerEx.sb.Length = 0;
            for (int i = 0; i < getResult.Inventory.Count; i++)
            {
                if (i != 0)
                    PfSharedControllerEx.sb.Append(", ");
                PfSharedControllerEx.sb.Append(getResult.Inventory[i].DisplayName);
            }
            inventoryDisplay = PfSharedControllerEx.sb.ToString();
            inventory = getResult.Inventory;
        }

        public Action ConsumeItem(string itemInstanceId)
        {
            Action output = () =>
            {
                var consumeRequest = new ClientModels.ConsumeItemRequest();
                consumeRequest.ConsumeCount = 1;
                consumeRequest.CharacterId = characterId;
                consumeRequest.ItemInstanceId = itemInstanceId;
                PlayFabClientAPI.ConsumeItem(consumeRequest, ConsumeItemCallback, PfSharedControllerEx.FailCallback("ConsumeItem"));
            };
            return output;
        }
        public void ConsumeItemCallback(ClientModels.ConsumeItemResult consumeResult)
        {
            // You could theoretically keep your local inventory up-to-date with local information, but it's safer to refresh the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, characterId);
        }

        public Action UnlockContainer(string itemId)
        {
            Action output = () =>
            {
                var unlockRequest = new ClientModels.UnlockContainerItemRequest();
                unlockRequest.CharacterId = characterId;
                unlockRequest.ContainerItemId = itemId;
                PlayFabClientAPI.UnlockContainerItem(unlockRequest, UnlockContainerallback, PfSharedControllerEx.FailCallback("UnlockContainerItem"));
            };
            return output;
        }
        public void UnlockContainerallback(ClientModels.UnlockContainerItemResult unlockResult)
        {
            // You could theoretically keep your local inventory up-to-date with local information, but it's safer to refresh the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, characterId);
        }
    }
}
