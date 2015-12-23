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
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, OnUserCharactersLoaded);
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, OnInventoryChanged);
        }

        public static void SetUp()
        {
            // The static constructor is called as a by-product of this call
        }

        private static void OnUserLogin(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            var catalogRequest = new ServerModels.GetCatalogItemsRequest();
            PlayFabServerAPI.GetCatalogItems(catalogRequest, GetCatalogCallback, PfSharedControllerEx.FailCallback("GetCatalogItems"));
            GetUserInventory(playFabId)();
        }

        private static void OnUserCharactersLoaded(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            if (eventSourceApi != PfSharedControllerEx.Api.Server)
                return;

            UserModel updatedUser; CharacterModel charModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out updatedUser) && updatedUser.serverCharacterModels.TryGetValue(characterId, out charModel))
                ((PfInvServerChar)charModel).GetInventory();
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
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnCatalogLoaded, null, null, PfSharedControllerEx.Api.Server, false);
        }

        private static void OnInventoryChanged(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            UserModel updatedUser;
            CharacterModel tempCharacter;
            if (!PfSharedModelEx.serverUsers.TryGetValue(playFabId, out updatedUser))
                return;

            if (characterId == null)
            {
                // Reload the user inventory
                GetUserInventory(playFabId)();
            }
            else
            {
                // Reload the character inventory
                if (!updatedUser.serverCharacterModels.TryGetValue(characterId, out tempCharacter))
                    return;

                PfInvServerChar eachCharacter = tempCharacter as PfInvServerChar;
                if (eachCharacter == null || eachCharacter.inventory == null)
                    return;

                eachCharacter.GetInventory();
            }
        }
        #endregion Controller Event Handling

        #region Example Implementation of PlayFab Inventory APIs
        public static Action GrantUserItem(string playFabId, string itemId)
        {
            Action output = () =>
            {
                var grantRequest = new ServerModels.GrantItemsToUserRequest();
                grantRequest.PlayFabId = playFabId;
                grantRequest.ItemIds = new List<string>() { itemId };
                PlayFabServerAPI.GrantItemsToUser(grantRequest, GrantUserItemCallback, PfSharedControllerEx.FailCallback("GrantItemsToUser"));
            };
            return output;
        }
        public static void GrantUserItemCallback(ServerModels.GrantItemsToUserResult grantResult)
        {
            string playFabId = ((ServerModels.GrantItemsToUserRequest)grantResult.Request).PlayFabId;

            // Merge the items we received with the items we know we have
            //UserModel userModel;
            //if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel))
            //    userModel.serverUserItems.AddRange(grantResult.ItemGrantResults); // TODO: Type mismatch makes this too complicated for now

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, playFabId, null, PfSharedControllerEx.Api.Server, true);
        }

        public static Action GetUserInventory(string playFabId)
        {
            Action output = () =>
            {
                var getRequest = new ServerModels.GetUserInventoryRequest();
                getRequest.PlayFabId = playFabId;
                PlayFabServerAPI.GetUserInventory(getRequest, GetUserItemsCallback, PfSharedControllerEx.FailCallback("GetUserInventory"));
            };
            return output;
        }
        public static void GetUserItemsCallback(ServerModels.GetUserInventoryResult getResult)
        {
            string playFabId = ((ServerModels.GetUserInventoryRequest)getResult.Request).PlayFabId;
            PfSharedControllerEx.sb.Length = 0;
            for (int i = 0; i < getResult.Inventory.Count; i++)
            {
                if (i != 0)
                    PfSharedControllerEx.sb.Append(", ");
                PfSharedControllerEx.sb.Append(getResult.Inventory[i].DisplayName);
            }

            UserModel userModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel))
            {
                userModel.userInvDisplay = PfSharedControllerEx.sb.ToString();
                userModel.serverUserItems = getResult.Inventory;
            }
        }

        public static Action RevokeUserItem(string playFabId, string itemInstanceId)
        {
            Action output = () =>
            {
                var revokeRequest = new AdminModels.RevokeInventoryItemRequest();
                revokeRequest.PlayFabId = playFabId;
                revokeRequest.CharacterId = null; // To indicate user inventory
                revokeRequest.ItemInstanceId = itemInstanceId;
                PlayFabAdminAPI.RevokeInventoryItem(revokeRequest, RevokeItemCallback, PfSharedControllerEx.FailCallback("RevokeInventoryItem"));
            };
            return output;
        }
        public static void RevokeItemCallback(AdminModels.RevokeInventoryResult revokeResult)
        {
            string playFabId = ((AdminModels.RevokeInventoryItemRequest)revokeResult.Request).PlayFabId;
            string characterId = ((AdminModels.RevokeInventoryItemRequest)revokeResult.Request).CharacterId;
            string revokedItemInstanceId = ((AdminModels.RevokeInventoryItemRequest)revokeResult.Request).ItemInstanceId;

            UserModel userModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel))
                userModel.RemoveItems(characterId, new HashSet<string>() { revokedItemInstanceId });

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, playFabId, characterId, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }
        #endregion Example Implementation of PlayFab Inventory APIs
    }

    /// <summary>
    /// A wrapper for inventory related, character centric, API calls and info
    /// This mostly exists because the characterId needs to be available at all steps in the process, and a class-wrapper avoids most of the Lambda-hell
    /// </summary>
    public class PfInvServerChar : ServerCharacterModel
    {
        public PfInvServerChar(string playFabId, string characterId, string characterName)
            : base(playFabId, characterId, characterName)
        {
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
            // Merge the items we received with the items we know we have
            //UserModel userModel;
            //if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel))
            //    userModel.serverUserItems.AddRange(grantResult.ItemGrantResults); // TODO: Type mismatch makes this too complicated for now

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, playFabId, characterId, PfSharedControllerEx.Api.Server, true);
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
            string playFabId = ((ServerModels.MoveItemToCharacterFromUserRequest)moveResult.Request).PlayFabId;
            string characterId = ((ServerModels.MoveItemToCharacterFromUserRequest)moveResult.Request).CharacterId;
            string movedItemInstanceId = ((ServerModels.MoveItemToCharacterFromUserRequest)moveResult.Request).ItemInstanceId;

            UserModel userModel;
            CharacterModel tempModel;
            ServerCharacterModel characterModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel)
            && userModel.serverCharacterModels.TryGetValue(characterId, out tempModel))
            {
                characterModel = tempModel as ServerCharacterModel;
                var movedItem = userModel.GetServerItem(characterId, movedItemInstanceId);
                if (movedItem != null)
                {
                    userModel.RemoveItems(characterId, new HashSet<string>() { movedItemInstanceId });
                    characterModel.inventory.Add(movedItem);
                }
            }

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, playFabId, null, PfSharedControllerEx.Api.Server, false);
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, playFabId, characterId, PfSharedControllerEx.Api.Server, false);
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
            string playFabId = ((ServerModels.MoveItemToUserFromCharacterRequest)moveResult.Request).PlayFabId;
            string characterId = ((ServerModels.MoveItemToUserFromCharacterRequest)moveResult.Request).CharacterId;
            string movedItemInstanceId = ((ServerModels.MoveItemToUserFromCharacterRequest)moveResult.Request).ItemInstanceId;

            UserModel userModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel))
            {
                var movedItem = userModel.GetServerItem(characterId, movedItemInstanceId);
                if (movedItem != null)
                {
                    userModel.RemoveItems(characterId, new HashSet<string>() { movedItemInstanceId });
                    userModel.serverUserItems.Add(movedItem);
                }
            }

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, playFabId, null, PfSharedControllerEx.Api.Server, false);
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, playFabId, characterId, PfSharedControllerEx.Api.Server, false);
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
        public void RevokeItemCallback(AdminModels.RevokeInventoryResult revokeResult)
        {
            string playFabId = ((AdminModels.RevokeInventoryItemRequest)revokeResult.Request).PlayFabId;
            string characterId = ((AdminModels.RevokeInventoryItemRequest)revokeResult.Request).CharacterId;
            string revokedItemInstanceId = ((AdminModels.RevokeInventoryItemRequest)revokeResult.Request).ItemInstanceId;

            UserModel userModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel))
                userModel.RemoveItems(characterId, new HashSet<string>() { revokedItemInstanceId });

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, playFabId, characterId, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }
    }
}
