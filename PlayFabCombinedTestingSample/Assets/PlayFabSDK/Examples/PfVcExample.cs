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
    [RequireComponent(typeof(PfLoginExample))]
    public class PfVcExample : PfExampleGui
    {
        #region Data Variables
        // NOTE: There is no way to request all vc types presently, so the knowledge must be hard coded
        private HashSet<String> virutalCurrencyTypes = new HashSet<string>() { "SS", "GS", "ST" }; // Set your vcKeys here
        private Dictionary<string, int> userVirtualCurrency = new Dictionary<string, int>();
        private Dictionary<string, Dictionary<string, int>> characterVirtualCurrency = new Dictionary<string, Dictionary<string, int>>();
        #endregion Data Variables

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            bool charsValid = isLoggedIn && loginExample.characterIds.Count > 0;
            int colIndex, temp;

            if (characterVirtualCurrency == null)
                return;

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

            for (int charIndex = 0; charIndex < characterVirtualCurrency.Count; charIndex++)
            {
                string eachCharacterId = loginExample.characterIds[charIndex];
                string eachCharacterName = loginExample.characterNames[charIndex];
                Dictionary<string, int> eachCharVcContainer = characterVirtualCurrency[eachCharacterId];
                if (eachCharVcContainer == null)
                    continue;

                // User Owned Currency
                Button(charsValid, rowIndex, 0, "Refresh " + eachCharacterName + " VC:", GetCharacterInventory(eachCharacterId));
                colIndex = 1;
                foreach (var vcKey in virutalCurrencyTypes)
                {
                    eachCharVcContainer.TryGetValue(vcKey, out temp);
                    CounterField(charsValid, rowIndex, colIndex++, vcKey + "=" + temp, AddCharacterVirtualCurrency(eachCharacterId, vcKey, 1), SubtractCharacterVirtualCurrency(eachCharacterId, vcKey, 1));
                }
                rowIndex++;
                rowIndex++;
            }
        }
        #endregion Unity GUI

        #region Prerequisite login and setup code
        private void OnPfUserLoginComplete()
        {
            GetUserInventory();
        }

        private void OnPfCharLoginComplete()
        {
            characterVirtualCurrency.Clear();
            for (int i = 0; i < loginExample.characterIds.Count; i++)
            {
                characterVirtualCurrency[loginExample.characterIds[i]] = null;
                GetCharacterInventory(loginExample.characterIds[i])();
            }
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

        private Action GetCharacterInventory(string characterId, bool client = true)
        {
            Action output;
            if (client)
            {
                output = () =>
                {
                    var getRequest = new ClientModels.GetCharacterInventoryRequest();
                    getRequest.CharacterId = characterId;
                    PlayFabClientAPI.GetCharacterInventory(getRequest, GetCharacterVcCallback_C, SharedFailCallback("GetCharacterInventory"));
                };
            }
            else
            {
                output = () =>
                {
                    var getRequest = new ServerModels.GetCharacterInventoryRequest();
                    getRequest.PlayFabId = loginExample.playFabId;
                    getRequest.CharacterId = characterId;
                    PlayFabServerAPI.GetCharacterInventory(getRequest, GetCharacterVcCallback_S, SharedFailCallback("GetCharacterInventory"));
                };
            }
            return output;
        }
        private void GetCharacterVcCallback_C(ClientModels.GetCharacterInventoryResult getResult)
        {
            characterVirtualCurrency[((ClientModels.GetCharacterInventoryRequest)getResult.Request).CharacterId] = getResult.VirtualCurrency;
            foreach (var pair in getResult.VirtualCurrency)
                virutalCurrencyTypes.Add(pair.Key);
        }
        private void GetCharacterVcCallback_S(ServerModels.GetCharacterInventoryResult getResult)
        {
            characterVirtualCurrency[((ClientModels.GetCharacterInventoryRequest)getResult.Request).CharacterId] = getResult.VirtualCurrency;
            foreach (var pair in getResult.VirtualCurrency)
                virutalCurrencyTypes.Add(pair.Key);
        }

        private Action AddUserVirtualCurrency(string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.AddUserVirtualCurrencyRequest addRequest = new ServerModels.AddUserVirtualCurrencyRequest();
                addRequest.PlayFabId = loginExample.playFabId;
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
                addRequest.PlayFabId = loginExample.playFabId;
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabServerAPI.SubtractUserVirtualCurrency(addRequest, SubtractCharVcCallback, SharedFailCallback("SubtractUserVirtualCurrency"));
            };
            return output;
        }
        private void SubtractCharVcCallback(ServerModels.ModifyUserVirtualCurrencyResult subtractResult)
        {
        }

        private Action AddCharacterVirtualCurrency(string characterId, string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.AddCharacterVirtualCurrencyRequest addRequest = new ServerModels.AddCharacterVirtualCurrencyRequest();
                addRequest.PlayFabId = loginExample.playFabId;
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

        private Action SubtractCharacterVirtualCurrency(string characterId, string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.SubtractCharacterVirtualCurrencyRequest addRequest = new ServerModels.SubtractCharacterVirtualCurrencyRequest();
                addRequest.PlayFabId = loginExample.playFabId;
                addRequest.CharacterId = characterId;
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabServerAPI.SubtractCharacterVirtualCurrency(addRequest, SubtractCharVcCallback, SharedFailCallback("SubtractCharacterVirtualCurrency"));
            };
            return output;
        }
        private void SubtractCharVcCallback(ServerModels.ModifyCharacterVirtualCurrencyResult subtractResult)
        {
        }
        #endregion Example Implementation of PlayFab Inventory APIs
    }
}
