using PlayFab;
using System;
using System.Collections.Generic;
using UnityEngine;
using ClientModels = PlayFab.ClientModels;
using ServerModels = PlayFab.ServerModels;

namespace PlayFab.Examples
{
    /// <summary>
    /// This is example code for all the API's described here: PlayFab Inventory System - Basic Trading Guide
    /// This file contains calls to each of the functions described, an old-style Unity-gui to demonstrate the inventory changes taking place, and the prerequisite login and setup code.
    /// </summary>
    public class PfTradeBasics : PfExampleGui
    {
        #region Data Variables
        public string char1Name;
        public string char2Name;
        public string character1Id;
        public string character2Id;

        // User/Character inventories
        private List<ClientModels.ItemInstance> userItems;
        private List<ClientModels.ItemInstance> char1Items;
        private List<ClientModels.ItemInstance> char2Items;
        #endregion Data Variables

        #region Unity GUI
        private void OnGUI()
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            bool char1Valid = isLoggedIn && !string.IsNullOrEmpty(character1Id);
            bool char2Valid = isLoggedIn && !string.IsNullOrEmpty(character2Id);
            int rowIndex = 0;

            // Display User Items
            TextField(isLoggedIn, rowIndex, 0, "User Items:");
            if (userItems != null)
                for (int i = 0; i < userItems.Count; i++)
                    Button(isLoggedIn, rowIndex, i + 1, userItems[i].DisplayName, null);
            rowIndex++;

            // Display Char1 Items
            TextField(char1Valid, rowIndex, 0, char1Name + " Items:");
            if (char1Items != null)
                for (int i = 0; i < char1Items.Count; i++)
                    Button(char1Valid, rowIndex, i + 1, char1Items[i].DisplayName, null);
            rowIndex++;
            rowIndex++;

            // Display User Items
            TextField(char2Valid, rowIndex, 0, char2Name + " Items:");
            if (char2Items != null)
                for (int i = 0; i < char2Items.Count; i++)
                    Button(char2Valid, rowIndex, i + 1, char2Items[i].DisplayName, null);
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

        #region Prerequisite login and setup code
        private void OnPfLoginComplete()
        {
            var charRequest = new ClientModels.ListUsersCharactersRequest();
            PlayFabClientAPI.GetAllUsersCharacters(charRequest, CharCallBack, SharedFailCallback("GetAllUsersCharacters"));
            GetUserInventory();
        }
        private void CharCallBack(ClientModels.ListUsersCharactersResult charResult)
        {
            foreach (var character in charResult.Characters)
            {
                if (character.CharacterName.ToLower() == char1Name.ToLower())
                    character1Id = character.CharacterId;
                else if (character.CharacterName.ToLower() == char2Name.ToLower())
                    character2Id = character.CharacterId;
            }
            if (!string.IsNullOrEmpty(character1Id))
                GetCharacterInventory(character1Id)();
            if (!string.IsNullOrEmpty(character2Id))
                GetCharacterInventory(character2Id)();
        }
        #endregion Prerequisite login and setup code

        #region Prerequisite PlayFab Inventory APIs
        private void GetUserInventory()
        {
            var getRequest = new ClientModels.GetUserInventoryRequest();
            PlayFabClientAPI.GetUserInventory(getRequest, GetUserInventoryCallback, SharedFailCallback("GetUserInventory"));
        }
        private void GetUserInventoryCallback(ClientModels.GetUserInventoryResult getResult)
        {
            userItems = getResult.Inventory;
        }

        private Action GetCharacterInventory(string characterId)
        {
            Action output = () =>
            {
                var getRequest = new ClientModels.GetCharacterInventoryRequest();
                getRequest.CharacterId = characterId;
                PlayFabClientAPI.GetCharacterInventory(getRequest, GetCharInventoryCallback, SharedFailCallback("GetCharacterInventory: " + characterId));
            };
            return output;
        }
        private void GetCharInventoryCallback(ClientModels.GetCharacterInventoryResult getResult)
        {
            if (getResult.CharacterId == character1Id)
                char1Items = getResult.Inventory;
            else if (getResult.CharacterId == character2Id)
                char2Items = getResult.Inventory;
        }
        #endregion
    }
}
