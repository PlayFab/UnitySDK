using PlayFab;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using AdminModels = PlayFab.AdminModels;
using ClientModels = PlayFab.ClientModels;
using ServerModels = PlayFab.ServerModels;

namespace PlayFab.Examples
{
    /// <summary>
    /// This example will have poor performance for a real title with lots of items.
    /// However, it's a very consise example for a test-title, with a small number of CatalogItems.
    /// 
    /// This is example code for all the API's described here: PlayFab Inventory System - Basic Inventory Guide
    /// This file contains calls to each of the functions described, an old-style Unity-gui to demonstrate the inventory changes taking place, and the prerequisite login and setup code.
    /// </summary>
    public class PfItemBasics : PfExampleGui
    {
        #region Data Variables
        public string charName;
        public string characterId;

        public string userInventory;
        public string charInventory;

        private List<ClientModels.CatalogItem> catalogItems;
        private HashSet<string> consumableItemIds = new HashSet<string>();
        private HashSet<string> containerItemIds = new HashSet<string>();
        private List<ClientModels.ItemInstance> userItems;
        private List<ClientModels.ItemInstance> charItems;

        private static StringBuilder sb = new StringBuilder();
        #endregion Data Variables

        #region Unity GUI
        private void OnGUI()
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            bool charValid = isLoggedIn && !string.IsNullOrEmpty(characterId);
            int rowIndex = 0;

            Button(isLoggedIn, rowIndex, 0, "Refresh User Inv", GetUserInventory_S);
            TextField(isLoggedIn, rowIndex, 1, ref userInventory);
            rowIndex++;
            // Grant User Items
            TextField(isLoggedIn, rowIndex, 0, "Grant User Item:");
            if (catalogItems != null)
                for (int i = 0; i < catalogItems.Count; i++)
                    Button(isLoggedIn, rowIndex, i + 1, catalogItems[i].DisplayName, GrantUserItem(catalogItems[i].ItemId));
            rowIndex++;
            // Move User Items to Character
            TextField(charValid, rowIndex, 0, "Move to Character:");
            if (userItems != null)
                for (int i = 0; i < userItems.Count; i++)
                    Button(charValid, rowIndex, i + 1, userItems[i].DisplayName, MoveToChar(userItems[i].ItemInstanceId));
            rowIndex++;
            // Revoke User Items
            TextField(isLoggedIn, rowIndex, 0, "Revoke:");
            if (userItems != null)
                for (int i = 0; i < userItems.Count; i++)
                    Button(isLoggedIn, rowIndex, i + 1, userItems[i].DisplayName, RevokeItem(userItems[i].ItemInstanceId));
            rowIndex++;
            // Consume Appropriate User Items
            TextField(isLoggedIn, rowIndex, 0, "Consume:");
            if (userItems != null)
            {
                int colIndex = 1;
                for (int i = 0; i < userItems.Count; i++)
                    if (consumableItemIds.Contains(userItems[i].ItemId))
                        Button(isLoggedIn, rowIndex, colIndex++, userItems[i].DisplayName, ConsumeItem(userItems[i].ItemInstanceId));
            }
            rowIndex++;
            // Open Appropriate User Containers
            TextField(isLoggedIn, rowIndex, 0, "Open:");
            if (userItems != null)
            {
                int colIndex = 1;
                for (int i = 0; i < userItems.Count; i++)
                    if (containerItemIds.Contains(userItems[i].ItemId))
                        Button(isLoggedIn, rowIndex, colIndex++, userItems[i].DisplayName, UnlockItem(userItems[i].ItemId));
            }
            rowIndex++;
            rowIndex++;

            Button(charValid, rowIndex, 0, "Refresh Char Inv", GetCharacterInventory_S);
            TextField(charValid, rowIndex, 1, ref charInventory);
            rowIndex++;
            // Grant Char Items
            TextField(charValid, rowIndex, 0, "Grant Char Item:");
            if (catalogItems != null)
                for (int i = 0; i < catalogItems.Count; i++)
                    Button(charValid, rowIndex, i + 1, catalogItems[i].DisplayName, GrantCharacterItem(catalogItems[i].ItemId));
            rowIndex++;
            // Move Character Items to User
            TextField(charValid, rowIndex, 0, "Move to User:");
            if (charItems != null)
                for (int i = 0; i < charItems.Count; i++)
                    Button(charValid, rowIndex, i + 1, charItems[i].DisplayName, MoveToUser(charItems[i].ItemInstanceId));
            rowIndex++;
            // Revoke Character Items
            TextField(charValid, rowIndex, 0, "Revoke:");
            if (charItems != null)
                for (int i = 0; i < charItems.Count; i++)
                    Button(charValid, rowIndex, i + 1, charItems[i].DisplayName, RevokeItem(charItems[i].ItemInstanceId, characterId));
            rowIndex++;
            // Consume Appropriate Character Items
            TextField(charValid, rowIndex, 0, "Consume:");
            if (charItems != null)
            {
                int colIndex = 1;
                for (int i = 0; i < charItems.Count; i++)
                    if (consumableItemIds.Contains(charItems[i].ItemId))
                        Button(charValid, rowIndex, colIndex++, charItems[i].DisplayName, ConsumeItem(charItems[i].ItemInstanceId, characterId));
            }
            rowIndex++;
            // Open Appropriate Character Containers
            TextField(charValid, rowIndex, 0, "Open:");
            if (charItems != null)
            {
                int colIndex = 1;
                for (int i = 0; i < charItems.Count; i++)
                    if (containerItemIds.Contains(charItems[i].ItemId))
                        Button(charValid, rowIndex, colIndex++, charItems[i].DisplayName, UnlockItem(charItems[i].ItemId, characterId));
            }
        }

        private ErrorCallback SharedFailCallback(string caller)
        {
            ErrorCallback output = (PlayFabError error) =>
            {
                Debug.LogError(caller + " failure: " + error.ErrorMessage);
            };
            return output;
        }
        #endregion Unity GUI

        #region Post-Login calls
        private void OnPfLoginComplete()
        {
            var charRequest = new ClientModels.ListUsersCharactersRequest();
            PlayFabClientAPI.GetAllUsersCharacters(charRequest, CharCallBack, SharedFailCallback("GetAllUsersCharacters"));
            var catalogRequest = new ClientModels.GetCatalogItemsRequest();
            PlayFabClientAPI.GetCatalogItems(catalogRequest, GetCatalogCallback, SharedFailCallback("GetCatalogItems"));
        }

        private void GetCatalogCallback(ClientModels.GetCatalogItemsResult catalogResult)
        {
            catalogItems = catalogResult.Catalog;
            consumableItemIds.Clear();
            containerItemIds.Clear();

            foreach (var each in catalogItems)
            {
                if (each.Container != null)
                    containerItemIds.Add(each.ItemId);
                else if (each.Consumable != null && each.Consumable.UsageCount > 0)
                    consumableItemIds.Add(each.ItemId);
            }
        }
        private void CharCallBack(ClientModels.ListUsersCharactersResult charResult)
        {
            foreach (var character in charResult.Characters)
                if (character.CharacterName.ToLower() == charName.ToLower())
                    characterId = character.CharacterId;
            if (!string.IsNullOrEmpty(characterId))
                GetCharacterInventory_C();
        }
        #endregion Post-Login calls

        #region Example Implementation of PlayFab Inventory APIs
        private Action GrantUserItem(string itemId)
        {
            Action output = () =>
            {
                var grantRequest = new ServerModels.GrantItemsToUserRequest();
                grantRequest.PlayFabId = pfLoginExample.playFabId;
                grantRequest.ItemIds = new List<string>() { itemId };
                PlayFabServerAPI.GrantItemsToUser(grantRequest, GrantUserItemCallback, SharedFailCallback("GrantItemsToUser"));
            };
            return output;
        }
        private void GrantUserItemCallback(ServerModels.GrantItemsToUserResult grantResult)
        {
            // You could theoretically keep your local inventory up-to-date with the diff information, but it's safer to have the full list:
            GetUserInventory_C();
        }

        private void GetUserInventory_C()
        {
            var getRequest = new ClientModels.GetUserInventoryRequest();
            PlayFabClientAPI.GetUserInventory(getRequest, GetUserItemsCallback_C, SharedFailCallback("GetUserInventory_C"));
        }
        private void GetUserItemsCallback_C(ClientModels.GetUserInventoryResult getResult)
        {
            userItems = getResult.Inventory;
            sb.Length = 0;
            for (int i = 0; i < getResult.Inventory.Count; i++)
            {
                if (i != 0)
                    sb.Append(", ");
                sb.Append(getResult.Inventory[i].DisplayName);
            }
            userInventory = sb.ToString();
        }

        private void GetUserInventory_S()
        {
            var getRequest = new ServerModels.GetUserInventoryRequest();
            getRequest.PlayFabId = pfLoginExample.playFabId;
            PlayFabServerAPI.GetUserInventory(getRequest, GetUserItemsCallback_S, SharedFailCallback("GetUserInventory_S"));
        }
        private void GetUserItemsCallback_S(ServerModels.GetUserInventoryResult getResult)
        {
            sb.Length = 0;
            for (int i = 0; i < getResult.Inventory.Count; i++)
            {
                if (i != 0)
                    sb.Append(", ");
                sb.Append(getResult.Inventory[i].DisplayName);
            }
            userInventory = sb.ToString();
        }

        private Action GrantCharacterItem(string itemId)
        {
            Action output = () =>
            {
                var grantRequest = new ServerModels.GrantItemsToCharacterRequest();
                grantRequest.PlayFabId = pfLoginExample.playFabId;
                grantRequest.CharacterId = characterId;
                grantRequest.ItemIds = new List<string>() { itemId };
                PlayFabServerAPI.GrantItemsToCharacter(grantRequest, GrantCharacterItemCallback, SharedFailCallback("GrantItemsToCharacter"));
            };
            return output;
        }
        private void GrantCharacterItemCallback(ServerModels.GrantItemsToCharacterResult grantResult)
        {
            // You could theoretically keep your local inventory up-to-date with the diff information, but it's safer to have the full list:
            GetCharacterInventory_C();
        }

        private void GetCharacterInventory_C()
        {
            var getRequest = new ClientModels.GetCharacterInventoryRequest();
            getRequest.CharacterId = characterId;
            PlayFabClientAPI.GetCharacterInventory(getRequest, GetCharacterItemsCallback_C, SharedFailCallback("GetCharacterInventory_C"));
        }
        private void GetCharacterItemsCallback_C(ClientModels.GetCharacterInventoryResult getResult)
        {
            charItems = getResult.Inventory;
            sb.Length = 0;
            for (int i = 0; i < getResult.Inventory.Count; i++)
            {
                if (i != 0)
                    sb.Append(", ");
                sb.Append(getResult.Inventory[i].DisplayName);
            }
            charInventory = sb.ToString();
        }

        private void GetCharacterInventory_S()
        {
            var getRequest = new ServerModels.GetCharacterInventoryRequest();
            getRequest.PlayFabId = pfLoginExample.playFabId;
            getRequest.CharacterId = characterId;
            PlayFabServerAPI.GetCharacterInventory(getRequest, GetCharacterItemsCallback_S, SharedFailCallback("GetCharacterInventory_S"));
        }
        private void GetCharacterItemsCallback_S(ServerModels.GetCharacterInventoryResult getResult)
        {
            sb.Length = 0;
            for (int i = 0; i < getResult.Inventory.Count; i++)
            {
                if (i != 0)
                    sb.Append(", ");
                sb.Append(getResult.Inventory[i].DisplayName);
            }
            charInventory = sb.ToString();
        }

        private Action MoveToChar(string itemInstanceId)
        {
            Action output = () =>
            {
                var moveRequest = new ServerModels.MoveItemToCharacterFromUserRequest();
                moveRequest.PlayFabId = pfLoginExample.playFabId;
                moveRequest.CharacterId = characterId;
                moveRequest.ItemInstanceId = itemInstanceId;
                PlayFabServerAPI.MoveItemToCharacterFromUser(moveRequest, MoveToCharCallback, SharedFailCallback("MoveItemToCharacterFromUser"));
            };
            return output;
        }
        private void MoveToCharCallback(ServerModels.MoveItemToCharacterFromUserResult moveResult)
        {
            GetUserInventory_C();
            GetCharacterInventory_C();
        }

        private Action MoveToUser(string itemInstanceId)
        {
            Action output = () =>
            {
                var moveRequest = new ServerModels.MoveItemToUserFromCharacterRequest();
                moveRequest.PlayFabId = pfLoginExample.playFabId;
                moveRequest.CharacterId = characterId;
                moveRequest.ItemInstanceId = itemInstanceId;
                PlayFabServerAPI.MoveItemToUserFromCharacter(moveRequest, MoveToUserCallback, SharedFailCallback("MoveItemToUserFromCharacter"));
            };
            return output;
        }
        private void MoveToUserCallback(ServerModels.MoveItemToUserFromCharacterResult moveResult)
        {
            GetUserInventory_C();
            GetCharacterInventory_C();
        }

        private Action RevokeItem(string itemInstanceId, string characterId = null)
        {
            Action output = () =>
            {
                var revokeRequest = new AdminModels.RevokeInventoryItemRequest();
                revokeRequest.PlayFabId = pfLoginExample.playFabId;
                revokeRequest.CharacterId = characterId;
                revokeRequest.ItemInstanceId = itemInstanceId;
                PlayFabAdminAPI.RevokeInventoryItem(revokeRequest, RevokeItemCallback, SharedFailCallback("RevokeInventoryItem"));
            };
            return output;
        }
        private void RevokeItemCallback(AdminModels.RevokeInventoryResult revokeResult)
        {
            GetUserInventory_C();
            GetCharacterInventory_C();
        }

        private Action ConsumeItem(string itemInstanceId, string characterId = null)
        {
            Action output = () =>
            {
                var consumeRequest = new ClientModels.ConsumeItemRequest();
                consumeRequest.ConsumeCount = 1;
                consumeRequest.CharacterId = characterId;
                consumeRequest.ItemInstanceId = itemInstanceId;
                PlayFabClientAPI.ConsumeItem(consumeRequest, ConsumeItemCallback, SharedFailCallback("ConsumeItem"));
            };
            return output;
        }
        private void ConsumeItemCallback(ClientModels.ConsumeItemResult consumeResult)
        {
            GetUserInventory_C();
            GetCharacterInventory_C();
        }

        private Action UnlockItem(string itemId, string characterId = null)
        {
            Action output = () =>
            {
                var unlockRequest = new ClientModels.UnlockContainerItemRequest();
                unlockRequest.CharacterId = characterId;
                unlockRequest.ContainerItemId = itemId;
                PlayFabClientAPI.UnlockContainerItem(unlockRequest, ConsumeItemCallback, SharedFailCallback("UnlockContainerItem"));
            };
            return output;
        }
        private void ConsumeItemCallback(ClientModels.UnlockContainerItemResult unlockResult)
        {
            GetUserInventory_C();
            GetCharacterInventory_C();
        }
        #endregion Example Implementation of PlayFab Inventory APIs
    }
}
