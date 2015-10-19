using System;
using System.Collections.Generic;

namespace PlayFab.Examples.Server
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
            var catalogRequest = new ServerModels.GetCatalogItemsRequest();
            PlayFabServerAPI.GetCatalogItems(catalogRequest, GetCatalogCallback, PfSharedControllerEx.FailCallback("GetCatalogItems"));
        }

        private static void OnAllCharactersLoaded(string trash)
        {
            GetUserInventory();
            PfSharedModelEx.serverCharInventories.Clear();
            for (int i = 0; i < PfSharedModelEx.characterIds.Count; i++)
            {
                var newCharInv = new PfInvServerChar(PfSharedModelEx.playFabId, PfSharedModelEx.characterIds[i], PfSharedModelEx.characterNames[i]);
                PfSharedModelEx.serverCharInventories[PfSharedModelEx.characterIds[i]] = newCharInv;
            }
        }

        private static void GetCatalogCallback(ServerModels.GetCatalogItemsResult catalogResult)
        {
            PfSharedModelEx.serverCatalog.Clear();
            foreach (var catalogItem in catalogResult.Catalog)
                PfSharedModelEx.serverCatalog[catalogItem.ItemId] = catalogItem;
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
                if (!PfSharedModelEx.serverCharInventories.TryGetValue(characterId, out tempCharater))
                    return;
                PfInvServerChar eachCharacter = tempCharater as PfInvServerChar;
                if (eachCharacter == null || eachCharacter.inventory == null)
                    return;

                eachCharacter.GetInventory();
            }
        }
        #endregion Controller Event Handling

        #region Example Implementation of PlayFab Inventory APIs
        public static Action GrantUserItem(string itemId)
        {
            Action output = () =>
            {
                var grantRequest = new ServerModels.GrantItemsToUserRequest();
                grantRequest.PlayFabId = PfSharedModelEx.playFabId;
                grantRequest.ItemIds = new List<string>() { itemId };
                PlayFabServerAPI.GrantItemsToUser(grantRequest, GrantUserItemCallback, PfSharedControllerEx.FailCallback("GrantItemsToUser"));
            };
            return output;
        }
        public static void GrantUserItemCallback(ServerModels.GrantItemsToUserResult grantResult)
        {
            // You could theoretically keep your local inventory up-to-date with local information, but it's safer to refresh the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, null);
        }

        public static void GetUserInventory()
        {
            var getRequest = new ServerModels.GetUserInventoryRequest();
            getRequest.PlayFabId = PfSharedModelEx.playFabId;
            PlayFabServerAPI.GetUserInventory(getRequest, GetUserItemsCallback, PfSharedControllerEx.FailCallback("GetUserInventory"));
        }
        public static void GetUserItemsCallback(ServerModels.GetUserInventoryResult getResult)
        {
            PfSharedControllerEx.sb.Length = 0;
            for (int i = 0; i < getResult.Inventory.Count; i++)
            {
                if (i != 0)
                    PfSharedControllerEx.sb.Append(", ");
                PfSharedControllerEx.sb.Append(getResult.Inventory[i].DisplayName);
            }
            PfSharedModelEx.userInvDisplay = PfSharedControllerEx.sb.ToString();
            PfSharedModelEx.serverUserItems = getResult.Inventory;
        }

        public static Action RevokeUserItem(string itemInstanceId)
        {
            Action output = () =>
            {
                var revokeRequest = new AdminModels.RevokeInventoryItemRequest();
                revokeRequest.PlayFabId = PfSharedModelEx.playFabId;
                revokeRequest.CharacterId = null; // To indicate user inventory
                revokeRequest.ItemInstanceId = itemInstanceId;
                PlayFabAdminAPI.RevokeInventoryItem(revokeRequest, RevokeItemCallback, PfSharedControllerEx.FailCallback("RevokeInventoryItem"));
            };
            return output;
        }
        public static void RevokeItemCallback(AdminModels.RevokeInventoryResult revokeResult)
        {
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, null);
        }
        #endregion Example Implementation of PlayFab Inventory APIs
    }

    /// <summary>
    /// A wrapper for inventory related, character centric, API calls and info
    /// This mostly exists because the characterId needs to be available at all steps in the process, and a class-wrapper avoids most of the Lambda-hell
    /// </summary>
    public class PfInvServerChar : PfCharInv
    {
        public List<ServerModels.ItemInstance> inventory;

        public PfInvServerChar(string playFabId, string characterId, string characterName)
            : base(playFabId, characterId, characterName)
        {
            GetInventory();
        }

        public Action GrantCharacterItem(string itemId)
        {
            Action output = () =>
            {
                var grantRequest = new ServerModels.GrantItemsToCharacterRequest();
                grantRequest.PlayFabId = playFabId;
                grantRequest.CharacterId = characterId;
                grantRequest.ItemIds = new List<string>() { itemId };
                PlayFabServerAPI.GrantItemsToCharacter(grantRequest, GrantCharacterItemCallback, PfSharedControllerEx.FailCallback("GrantItemsToCharacter"));
            };
            return output;
        }
        public void GrantCharacterItemCallback(ServerModels.GrantItemsToCharacterResult grantResult)
        {
            // You could theoretically keep your local inventory up-to-date with local information, but it's safer to refresh the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, characterId);
        }

        public void GetInventory()
        {
            var getRequest = new ServerModels.GetCharacterInventoryRequest();
            getRequest.PlayFabId = playFabId;
            getRequest.CharacterId = characterId;
            PlayFabServerAPI.GetCharacterInventory(getRequest, GetInventoryCallback, PfSharedControllerEx.FailCallback("GetCharacterInventory"));
        }
        public void GetInventoryCallback(ServerModels.GetCharacterInventoryResult getResult)
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

        public Action MoveToCharFromUser(string itemInstanceId)
        {
            Action output = () =>
            {
                var moveRequest = new ServerModels.MoveItemToCharacterFromUserRequest();
                moveRequest.PlayFabId = playFabId;
                moveRequest.CharacterId = characterId;
                moveRequest.ItemInstanceId = itemInstanceId;
                PlayFabServerAPI.MoveItemToCharacterFromUser(moveRequest, MoveToCharCallback, PfSharedControllerEx.FailCallback("MoveItemToCharacterFromUser"));
            };
            return output;
        }
        public void MoveToCharCallback(ServerModels.MoveItemToCharacterFromUserResult moveResult)
        {
            // You could theoretically keep your local inventory up-to-date with local information, but it's safer to refresh the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, null);
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, characterId);
        }

        public Action MoveToUser(string itemInstanceId)
        {
            Action output = () =>
            {
                var moveRequest = new ServerModels.MoveItemToUserFromCharacterRequest();
                moveRequest.PlayFabId = playFabId;
                moveRequest.CharacterId = characterId;
                moveRequest.ItemInstanceId = itemInstanceId;
                PlayFabServerAPI.MoveItemToUserFromCharacter(moveRequest, MoveToUserCallback, PfSharedControllerEx.FailCallback("MoveItemToUserFromCharacter"));
            };
            return output;
        }
        public void MoveToUserCallback(ServerModels.MoveItemToUserFromCharacterResult moveResult)
        {
            // You could theoretically keep your local inventory up-to-date with local information, but it's safer to refresh the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, null);
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, characterId);
        }

        public Action RevokeItem(string itemInstanceId)
        {
            Action output = () =>
            {
                var revokeRequest = new AdminModels.RevokeInventoryItemRequest();
                revokeRequest.PlayFabId = playFabId;
                revokeRequest.CharacterId = characterId;
                revokeRequest.ItemInstanceId = itemInstanceId;
                PlayFabAdminAPI.RevokeInventoryItem(revokeRequest, RevokeItemCallback, PfSharedControllerEx.FailCallback("RevokeInventoryItem"));
            };
            return output;
        }
        public void RevokeItemCallback(AdminModels.RevokeInventoryResult moveResult)
        {
            // You could theoretically keep your local inventory up-to-date with local information, but it's safer to refresh the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, characterId);
        }
    }
}
