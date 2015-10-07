using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PlayFab.Examples
{
    /// <summary>
    /// This example will have poor performance for a real title with lots of items.
    /// However, it's a very consise example for a test-title, with a small number of CatalogItems.
    /// 
    /// This is example code for all the API's described here: PlayFab Inventory System - Basic Inventory Guide
    /// This file contains calls to each of the functions described, an old-style Unity-gui to demonstrate the inventory changes taking place, and the prerequisite login and setup code.
    /// </summary>
    [RequireComponent(typeof(PfLoginExample))]
    public class PfInventoryExample : PfExampleGui
    {
        #region Data Variables
        public string userInvDisplay;

        public Dictionary<string, ClientModels.CatalogItem> catalogItems = new Dictionary<string, ClientModels.CatalogItem>();
        public HashSet<string> consumableItemIds = new HashSet<string>();
        public HashSet<string> containerItemIds = new HashSet<string>();
        public List<ClientModels.ItemInstance> userItems;
        public Dictionary<string, PfInvCharacter> charInventories = new Dictionary<string, PfInvCharacter>();

        private static StringBuilder sb = new StringBuilder();
        #endregion Data Variables

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            bool charsValid = isLoggedIn && loginExample.characterIds.Count > 0;
            int colIndex;

            Button(isLoggedIn, rowIndex, 0, "Refresh User Inv", GetUserInventory);
            TextField(isLoggedIn, rowIndex, 1, ref userInvDisplay);
            rowIndex++;
            // Grant User Items
            TextField(isLoggedIn, rowIndex, 0, "Grant User Item:");
            if (catalogItems != null)
            {
                colIndex = 1;
                foreach (var catalogPair in catalogItems)
                    Button(isLoggedIn, rowIndex, colIndex++, catalogPair.Value.DisplayName, GrantUserItem(catalogPair.Key));
            }
            rowIndex++;
            // Move User Items to characters
            for (int charIndex = 0; userItems != null && charIndex < loginExample.characterIds.Count; charIndex++)
            {
                PfInvCharacter eachCharacter;
                if (!charInventories.TryGetValue(loginExample.characterIds[charIndex], out eachCharacter))
                    continue;
                TextField(eachCharacter != null, rowIndex, 0, "Move to " + eachCharacter.characterName + ":");
                for (int i = 0; i < userItems.Count; i++)
                    Button(eachCharacter != null, rowIndex, i + 1, userItems[i].DisplayName, eachCharacter.MoveToCharFromUser(userItems[i].ItemInstanceId));
                rowIndex++;
            }
            // Revoke User Items
            TextField(isLoggedIn, rowIndex, 0, "Revoke:");
            if (userItems != null)
                for (int i = 0; i < userItems.Count; i++)
                    Button(isLoggedIn, rowIndex, i + 1, userItems[i].DisplayName, RevokeUserItem(userItems[i].ItemInstanceId));
            rowIndex++;
            // Consume Appropriate User Items
            TextField(isLoggedIn, rowIndex, 0, "Consume:");
            if (userItems != null)
            {
                colIndex = 1;
                for (int i = 0; i < userItems.Count; i++)
                    if (consumableItemIds.Contains(userItems[i].ItemId))
                        Button(isLoggedIn, rowIndex, colIndex++, userItems[i].DisplayName, ConsumeUserItem(userItems[i].ItemInstanceId));
            }
            rowIndex++;
            // Open Appropriate User Containers
            TextField(isLoggedIn, rowIndex, 0, "Open:");
            if (userItems != null)
            {
                colIndex = 1;
                for (int i = 0; i < userItems.Count; i++)
                    if (containerItemIds.Contains(userItems[i].ItemId))
                        Button(isLoggedIn, rowIndex, colIndex++, userItems[i].DisplayName, UnlockUserContainer(userItems[i].ItemId));
            }
            rowIndex++;
            rowIndex++;

            for (int charIndex = 0; charIndex < loginExample.characterIds.Count; charIndex++)
            {
                string eachCharacterId = loginExample.characterIds[charIndex];
                string eachCharacterName = loginExample.characterNames[charIndex];
                PfInvCharacter eachCharacter;
                if (!charInventories.TryGetValue(eachCharacterId, out eachCharacter) || eachCharacter.inventory == null)
                    continue;

                Button(charsValid, rowIndex, 0, "Refresh " + eachCharacterName + " Inv", eachCharacter.GetInventory);
                TextField(charsValid, rowIndex, 1, eachCharacter.inventoryDisplay);
                rowIndex++;
                // Grant Char Items
                TextField(charsValid, rowIndex, 0, "Grant " + eachCharacterName + " Item:");
                if (catalogItems != null)
                {
                    colIndex = 1;
                    foreach (var catalogPair in catalogItems)
                        Button(charsValid, rowIndex, colIndex++, catalogPair.Value.DisplayName, eachCharacter.GrantCharacterItem(catalogPair.Key));
                }
                rowIndex++;
                // Move Character Items to User
                TextField(charsValid, rowIndex, 0, "Move to User:");
                for (int i = 0; i < eachCharacter.inventory.Count; i++)
                    Button(charsValid, rowIndex, i + 1, eachCharacter.inventory[i].DisplayName, eachCharacter.MoveToUser(eachCharacter.inventory[i].ItemInstanceId));
                rowIndex++;
                // Revoke Character Items
                TextField(charsValid, rowIndex, 0, "Revoke:");
                for (int i = 0; i < eachCharacter.inventory.Count; i++)
                    Button(charsValid, rowIndex, i + 1, eachCharacter.inventory[i].DisplayName, eachCharacter.RevokeItem(eachCharacter.inventory[i].ItemInstanceId));
                rowIndex++;
                // Consume Appropriate Character Items
                TextField(charsValid, rowIndex, 0, "Consume:");
                colIndex = 1;
                for (int i = 0; i < eachCharacter.inventory.Count; i++)
                    if (consumableItemIds.Contains(eachCharacter.inventory[i].ItemId))
                        Button(charsValid, rowIndex, colIndex++, eachCharacter.inventory[i].DisplayName, eachCharacter.ConsumeItem(eachCharacter.inventory[i].ItemInstanceId));

                rowIndex++;
                // Open Appropriate Character Containers
                TextField(charsValid, rowIndex, 0, "Open:");
                colIndex = 1;
                for (int i = 0; i < eachCharacter.inventory.Count; i++)
                    if (containerItemIds.Contains(eachCharacter.inventory[i].ItemId))
                        Button(charsValid, rowIndex, colIndex++, eachCharacter.inventory[i].DisplayName, eachCharacter.UnlockContainer(eachCharacter.inventory[i].ItemId));
                rowIndex++;
                rowIndex++;
            }
        }
        #endregion Unity GUI

        #region Post-Login calls
        protected void OnPfUserLoginComplete()
        {
            var catalogRequest = new ClientModels.GetCatalogItemsRequest();
            PlayFabClientAPI.GetCatalogItems(catalogRequest, GetCatalogCallback, SharedFailCallback("GetCatalogItems"));
        }

        protected void OnPfCharLoginComplete()
        {
            GetUserInventory();
            charInventories.Clear();
            for (int i = 0; i < loginExample.characterIds.Count; i++)
            {
                charInventories[loginExample.characterIds[i]] = new PfInvCharacter(this, loginExample.playFabId, loginExample.characterIds[i], loginExample.characterNames[i]);
                charInventories[loginExample.characterIds[i]].GetInventory();
            }
        }

        private void GetCatalogCallback(ClientModels.GetCatalogItemsResult catalogResult)
        {
            catalogItems.Clear();
            foreach (var catalogItem in catalogResult.Catalog)
                catalogItems[catalogItem.ItemId] = catalogItem;
            consumableItemIds.Clear();
            containerItemIds.Clear();

            foreach (var each in catalogResult.Catalog)
            {
                if (each.Container != null)
                    containerItemIds.Add(each.ItemId);
                else if (each.Consumable != null && each.Consumable.UsageCount > 0)
                    consumableItemIds.Add(each.ItemId);
            }
            gameObject.SendMessage("OnPfCatalogLoadComplete"); // Alert any other example components that the catalog is loaded
        }
        #endregion Post-Login calls

        #region Example Implementation of PlayFab Inventory APIs
        protected Action GrantUserItem(string itemId)
        {
            Action output = () =>
            {
                var grantRequest = new ServerModels.GrantItemsToUserRequest();
                grantRequest.PlayFabId = loginExample.playFabId;
                grantRequest.ItemIds = new List<string>() { itemId };
                PlayFabServerAPI.GrantItemsToUser(grantRequest, GrantUserItemCallback, SharedFailCallback("GrantItemsToUser"));
            };
            return output;
        }
        private void GrantUserItemCallback(ServerModels.GrantItemsToUserResult grantResult)
        {
            // You could theoretically keep your local inventory up-to-date with the diff information, but it's safer to have the full list:
            GetUserInventory();
        }

        internal void GetUserInventory()
        {
            //if (client)
            //{
            var getRequest = new ClientModels.GetUserInventoryRequest();
            PlayFabClientAPI.GetUserInventory(getRequest, GetUserItemsCallback_C, SharedFailCallback("GetUserInventory"));
            //}
            //else
            //{
            //    var getRequest = new ServerModels.GetUserInventoryRequest();
            //    getRequest.PlayFabId = pfLoginExample.playFabId;
            //    PlayFabServerAPI.GetUserInventory(getRequest, GetUserItemsCallback_S, SharedFailCallback("GetUserInventory"));
            //}
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
            userInvDisplay = sb.ToString();
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
            userInvDisplay = sb.ToString();
        }

        private Action RevokeUserItem(string itemInstanceId)
        {
            Action output = () =>
            {
                var revokeRequest = new AdminModels.RevokeInventoryItemRequest();
                revokeRequest.PlayFabId = loginExample.playFabId;
                revokeRequest.CharacterId = null; // To indicate user inventory
                revokeRequest.ItemInstanceId = itemInstanceId;
                PlayFabAdminAPI.RevokeInventoryItem(revokeRequest, RevokeItemCallback, SharedFailCallback("RevokeInventoryItem"));
            };
            return output;
        }
        private void RevokeItemCallback(AdminModels.RevokeInventoryResult moveResult)
        {
            GetUserInventory();
        }

        private Action ConsumeUserItem(string itemInstanceId)
        {
            Action output = () =>
            {
                var consumeRequest = new ClientModels.ConsumeItemRequest();
                consumeRequest.ConsumeCount = 1;
                consumeRequest.CharacterId = null; // To indicate user inventory
                consumeRequest.ItemInstanceId = itemInstanceId;
                PlayFabClientAPI.ConsumeItem(consumeRequest, ConsumeItemCallback, SharedFailCallback("ConsumeItem"));
            };
            return output;
        }
        private void ConsumeItemCallback(ClientModels.ConsumeItemResult consumeResult)
        {
            GetUserInventory();
        }

        private Action UnlockUserContainer(string itemId)
        {
            Action output = () =>
            {
                var unlockRequest = new ClientModels.UnlockContainerItemRequest();
                unlockRequest.CharacterId = null; // To indicate user inventory
                unlockRequest.ContainerItemId = itemId;
                PlayFabClientAPI.UnlockContainerItem(unlockRequest, UnlockUserContainerCallback, SharedFailCallback("UnlockContainerItem"));
            };
            return output;
        }
        private void UnlockUserContainerCallback(ClientModels.UnlockContainerItemResult consumeResult)
        {
            GetUserInventory();
        }
        #endregion Example Implementation of PlayFab Inventory APIs
    }

    /// <summary>
    /// A wrapper for inventory related, character centric, API calls and info
    /// This mostly exists because the characterId needs to be available at all steps in the process, and a class-wrapper avoids most of the Lambda-hell
    /// </summary>
    public class PfInvCharacter
    {
        private static StringBuilder sb = new StringBuilder();

        private PfInventoryExample parent;
        public bool client = true; // Where applicable, use the relevant client or server calls (same functionality)
        public string playFabId;
        public string characterId;
        public string characterName;
        public string inventoryDisplay = "";
        public List<ClientModels.ItemInstance> inventory;

        public PfInvCharacter(PfInventoryExample parent, string playFabId, string characterId, string characterName)
        {
            this.parent = parent;
            this.playFabId = playFabId;
            this.characterId = characterId;
            this.characterName = characterName;
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
                PlayFabServerAPI.GrantItemsToCharacter(grantRequest, GrantCharacterItemCallback, PfInventoryExample.SharedFailCallback("GrantItemsToCharacter"));
            };
            return output;
        }
        private void GrantCharacterItemCallback(ServerModels.GrantItemsToCharacterResult grantResult)
        {
            // You could theoretically keep your local inventory up-to-date with the diff information, but it's safer to refresh the full list:
            GetInventory();
        }

        public void GetInventory()
        {
            if (client)
            {
                var getRequest = new ClientModels.GetCharacterInventoryRequest();
                getRequest.CharacterId = characterId;
                PlayFabClientAPI.GetCharacterInventory(getRequest, GetInventoryCallback_C, PfInventoryExample.SharedFailCallback("GetCharacterInventory"));
            }
            else
            {
                var getRequest = new ServerModels.GetCharacterInventoryRequest();
                getRequest.PlayFabId = playFabId;
                getRequest.CharacterId = characterId;
                PlayFabServerAPI.GetCharacterInventory(getRequest, GetInventoryCallback_S, PfInventoryExample.SharedFailCallback("GetCharacterInventory"));
            }
        }
        private void GetInventoryCallback_C(ClientModels.GetCharacterInventoryResult getResult)
        {
            sb.Length = 0;
            for (int i = 0; i < getResult.Inventory.Count; i++)
            {
                if (i != 0)
                    sb.Append(", ");
                sb.Append(getResult.Inventory[i].DisplayName);
            }
            inventoryDisplay = sb.ToString();
            inventory = getResult.Inventory;
        }
        private void GetInventoryCallback_S(ServerModels.GetCharacterInventoryResult getResult)
        {
            sb.Length = 0;
            for (int i = 0; i < getResult.Inventory.Count; i++)
            {
                if (i != 0)
                    sb.Append(", ");
                sb.Append(getResult.Inventory[i].DisplayName);
            }
            inventoryDisplay = sb.ToString();
            // inventory = getResult.Inventory; // TODO: Convert from server to client items
        }
        public Action MoveToCharFromUser(string itemInstanceId)
        {
            Action output = () =>
            {
                var moveRequest = new ServerModels.MoveItemToCharacterFromUserRequest();
                moveRequest.PlayFabId = playFabId;
                moveRequest.CharacterId = characterId;
                moveRequest.ItemInstanceId = itemInstanceId;
                PlayFabServerAPI.MoveItemToCharacterFromUser(moveRequest, MoveToCharCallback, PfInventoryExample.SharedFailCallback("MoveItemToCharacterFromUser"));
            };
            return output;
        }
        private void MoveToCharCallback(ServerModels.MoveItemToCharacterFromUserResult moveResult)
        {
            parent.GetUserInventory();
            GetInventory();
        }

        public Action MoveToUser(string itemInstanceId)
        {
            Action output = () =>
            {
                var moveRequest = new ServerModels.MoveItemToUserFromCharacterRequest();
                moveRequest.PlayFabId = playFabId;
                moveRequest.CharacterId = characterId;
                moveRequest.ItemInstanceId = itemInstanceId;
                PlayFabServerAPI.MoveItemToUserFromCharacter(moveRequest, MoveToUserCallback, PfInventoryExample.SharedFailCallback("MoveItemToUserFromCharacter"));
            };
            return output;
        }
        private void MoveToUserCallback(ServerModels.MoveItemToUserFromCharacterResult moveResult)
        {
            parent.GetUserInventory();
            GetInventory();
        }

        public Action RevokeItem(string itemInstanceId)
        {
            Action output = () =>
            {
                var revokeRequest = new AdminModels.RevokeInventoryItemRequest();
                revokeRequest.PlayFabId = playFabId;
                revokeRequest.CharacterId = characterId;
                revokeRequest.ItemInstanceId = itemInstanceId;
                PlayFabAdminAPI.RevokeInventoryItem(revokeRequest, RevokeItemCallback, PfInventoryExample.SharedFailCallback("RevokeInventoryItem"));
            };
            return output;
        }
        private void RevokeItemCallback(AdminModels.RevokeInventoryResult moveResult)
        {
            GetInventory();
        }

        public Action ConsumeItem(string itemInstanceId)
        {
            Action output = () =>
            {
                var consumeRequest = new ClientModels.ConsumeItemRequest();
                consumeRequest.ConsumeCount = 1;
                consumeRequest.CharacterId = characterId;
                consumeRequest.ItemInstanceId = itemInstanceId;
                PlayFabClientAPI.ConsumeItem(consumeRequest, ConsumeItemCallback, PfInventoryExample.SharedFailCallback("ConsumeItem"));
            };
            return output;
        }
        private void ConsumeItemCallback(ClientModels.ConsumeItemResult consumeResult)
        {
            GetInventory();
        }

        public Action UnlockContainer(string itemId)
        {
            Action output = () =>
            {
                var unlockRequest = new ClientModels.UnlockContainerItemRequest();
                unlockRequest.CharacterId = characterId;
                unlockRequest.ContainerItemId = itemId;
                PlayFabClientAPI.UnlockContainerItem(unlockRequest, UnlockContainerallback, PfInventoryExample.SharedFailCallback("UnlockContainerItem"));
            };
            return output;
        }
        private void UnlockContainerallback(ClientModels.UnlockContainerItemResult consumeResult)
        {
            GetInventory();
        }
    }
}
