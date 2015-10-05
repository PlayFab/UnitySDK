using PlayFab;
using System;
using System.Collections.Generic;
using UnityEngine;
using ClientModels = PlayFab.ClientModels;
using ServerModels = PlayFab.ServerModels;

namespace PlayFab.Examples
{
    /// <summary>
    /// This is example code for all the API's described here: PlayFab Inventory System - Basic Virtual Currency Guide
    /// This file contains calls to each of the functions described, an old-style Unity-gui to demonstrate the inventory changes taking place, and the prerequisite login and setup code.
    /// </summary>
    public class PfVcBasics : PfExampleGui
    {
        #region Data Variables
        public string charName;
        public string characterId;

        // NOTE: There is no way to request this information presently, so the knowledge must be hard coded
        private HashSet<String> virutalCurrencyTypes = new HashSet<string>() { "SS", "GS", "ST" }; // Set your vcKeys here
        private Dictionary<string, int> userVirtualCurrency = new Dictionary<string, int>();
        private Dictionary<string, int> characterVirtualCurrency = new Dictionary<string, int>();
        #endregion Data Variables

        #region Unity GUI
        private void OnGUI()
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            bool charValid = isLoggedIn && !string.IsNullOrEmpty(characterId);
            int rowIndex = 0, colIndex, temp;

            // User Owned Currency
            Button(isLoggedIn, rowIndex, 0, "Refresh User VC:", GetUserInventory);
            colIndex = 1;
            foreach (var vcKey in virutalCurrencyTypes)
            {
                userVirtualCurrency.TryGetValue(vcKey, out temp);
                CounterField(isLoggedIn, rowIndex, colIndex++, vcKey + "=" + temp, AddUserVirtualCurrency(vcKey, 1), SubtractUserVirtualCurrency(vcKey, 1));
            }
            rowIndex++;
            rowIndex++;

            // User Owned Currency
            Button(charValid, rowIndex, 0, "Refresh Char VC:", GetCharacterInventory);
            colIndex = 1;
            foreach (var vcKey in virutalCurrencyTypes)
            {
                characterVirtualCurrency.TryGetValue(vcKey, out temp);
                CounterField(charValid, rowIndex, colIndex++, vcKey + "=" + temp, AddCharacterVirtualCurrency(vcKey, 1), SubtractCharacterVirtualCurrency(vcKey, 1));
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
                if (character.CharacterName.ToLower() == charName.ToLower())
                    characterId = character.CharacterId;
            if (!string.IsNullOrEmpty(characterId))
                GetCharacterInventory();
        }
        #endregion Prerequisite login and setup code

        #region Example Implementation of PlayFab Virtual Currency APIs
        private void GetUserInventory()
        {
            var getRequest = new ClientModels.GetUserInventoryRequest();
            PlayFabClientAPI.GetUserInventory(getRequest, GetUserVcCallback, SharedFailCallback("GetUserInventory"));
        }
        private void GetUserVcCallback(ClientModels.GetUserInventoryResult getResult)
        {
            userVirtualCurrency = getResult.VirtualCurrency;
            foreach (var pair in getResult.VirtualCurrency)
                virutalCurrencyTypes.Add(pair.Key);
        }

        private void GetCharacterInventory()
        {
            var getRequest = new ClientModels.GetCharacterInventoryRequest();
            getRequest.CharacterId = characterId;
            PlayFabClientAPI.GetCharacterInventory(getRequest, GetCharVcCallback, SharedFailCallback("GetCharacterInventory"));
        }
        private void GetCharVcCallback(ClientModels.GetCharacterInventoryResult getResult)
        {
            characterVirtualCurrency = getResult.VirtualCurrency;
            foreach (var pair in getResult.VirtualCurrency)
                virutalCurrencyTypes.Add(pair.Key);
        }

        private Action AddUserVirtualCurrency(string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.AddUserVirtualCurrencyRequest addRequest = new ServerModels.AddUserVirtualCurrencyRequest();
                addRequest.PlayFabId = pfLoginExample.playFabId;
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabServerAPI.AddUserVirtualCurrency(addRequest, AddCharVcCallback, SharedFailCallback("AddUserVirtualCurrency"));
            };
            return output;
        }
        private void AddCharVcCallback(ServerModels.ModifyUserVirtualCurrencyResult addResult)
        {
        }

        private Action SubtractUserVirtualCurrency(string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.SubtractUserVirtualCurrencyRequest addRequest = new ServerModels.SubtractUserVirtualCurrencyRequest();
                addRequest.PlayFabId = pfLoginExample.playFabId;
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabServerAPI.SubtractUserVirtualCurrency(addRequest, SubtractCharVcCallback, SharedFailCallback("SubtractUserVirtualCurrency"));
            };
            return output;
        }
        private void SubtractCharVcCallback(ServerModels.ModifyUserVirtualCurrencyResult addResult)
        {
        }

        private Action AddCharacterVirtualCurrency(string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.AddCharacterVirtualCurrencyRequest addRequest = new ServerModels.AddCharacterVirtualCurrencyRequest();
                addRequest.PlayFabId = pfLoginExample.playFabId;
                addRequest.CharacterId = characterId;
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabServerAPI.AddCharacterVirtualCurrency(addRequest, AddCharVcCallback, SharedFailCallback("AddCharacterVirtualCurrency"));
            };
            return output;
        }
        private void AddCharVcCallback(ServerModels.ModifyCharacterVirtualCurrencyResult addResult)
        {
        }

        private Action SubtractCharacterVirtualCurrency(string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.SubtractCharacterVirtualCurrencyRequest addRequest = new ServerModels.SubtractCharacterVirtualCurrencyRequest();
                addRequest.PlayFabId = pfLoginExample.playFabId;
                addRequest.CharacterId = characterId;
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabServerAPI.SubtractCharacterVirtualCurrency(addRequest, SubtractCharVcCallback, SharedFailCallback("SubtractCharacterVirtualCurrency"));
            };
            return output;
        }
        private void SubtractCharVcCallback(ServerModels.ModifyCharacterVirtualCurrencyResult addResult)
        {
        }
        #endregion Example Implementation of PlayFab Inventory APIs
    }
}
