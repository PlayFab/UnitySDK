using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayFab.Examples.Client
{
    /// <summary>
    /// This is example code for all the API's described here: PlayFab Inventory System - Basic Virtual Currency Guide
    /// This file contains calls to each of the functions described, an old-style Unity-gui to demonstrate the inventory changes taking place, and the prerequisite login and setup code.
    /// </summary>
    [RequireComponent(typeof(LoginExample))]
    public static class VirtualCurrencyExample
    {
        #region Controller Event Handling
        static VirtualCurrencyExample()
        {
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserLogin, OnUserLogin);
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnAllCharactersLoaded, OnAllCharactersLoaded);
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnVcChanged, OnVcChanged);
        }

        public static void SetUp()
        {
            // The static constructor is called as a by-product of this call
        }

        private static void OnUserLogin(string playFabId)
        {
            GetUserVc();
        }

        private static void OnAllCharactersLoaded(string trash)
        {
            PfSharedModelEx.characterVC.Clear();
            for (int i = 0; i < PfSharedModelEx.characterIds.Count; i++)
            {
                PfSharedModelEx.characterVC[PfSharedModelEx.characterIds[i]] = null;
                GetCharacterVc(PfSharedModelEx.characterIds[i])();
            }
        }

        private static void OnVcChanged(string characterId)
        {
            if (characterId == null) // Reload the user inventory
                GetUserVc();
            else // Reload the character inventory
                GetCharacterVc(characterId);
        }
        #endregion Controller Event Handling

        #region Example Implementation of PlayFab Virtual Currency APIs
        public static void GetUserVc()
        {
            var getRequest = new ClientModels.GetUserInventoryRequest();
            PlayFabClientAPI.GetUserInventory(getRequest, GetUserVcCallback, PfSharedControllerEx.FailCallback("GetUserInventory"));
        }
        private static void GetUserVcCallback(ClientModels.GetUserInventoryResult getResult)
        {
            PfSharedModelEx.userVirtualCurrency = getResult.VirtualCurrency;
            foreach (var pair in getResult.VirtualCurrency)
                PfSharedModelEx.virutalCurrencyTypes.Add(pair.Key);
        }

        public static Action GetCharacterVc(string characterId)
        {
            Action output = () =>
            {
                var getRequest = new ClientModels.GetCharacterInventoryRequest();
                getRequest.CharacterId = characterId;
                PlayFabClientAPI.GetCharacterInventory(getRequest, GetCharacterVcCallback, PfSharedControllerEx.FailCallback("GetCharacterInventory"));
            };
            return output;
        }
        private static void GetCharacterVcCallback(ClientModels.GetCharacterInventoryResult getResult)
        {
            PfSharedModelEx.characterVC[((ClientModels.GetCharacterInventoryRequest)getResult.Request).CharacterId] = getResult.VirtualCurrency;
            foreach (var pair in getResult.VirtualCurrency)
                PfSharedModelEx.virutalCurrencyTypes.Add(pair.Key);
        }

        public static Action AddUserVirtualCurrency(string vcKey, int amt)
        {
            Action output = () =>
            {
                ClientModels.AddUserVirtualCurrencyRequest addRequest = new ClientModels.AddUserVirtualCurrencyRequest();
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabClientAPI.AddUserVirtualCurrency(addRequest, ModifyUserVcCallback, PfSharedControllerEx.FailCallback("AddUserVirtualCurrency"));
            };
            return output;
        }

        public static Action SubtractUserVirtualCurrency(string vcKey, int amt)
        {
            Action output = () =>
            {
                ClientModels.SubtractUserVirtualCurrencyRequest addRequest = new ClientModels.SubtractUserVirtualCurrencyRequest();
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabClientAPI.SubtractUserVirtualCurrency(addRequest, ModifyUserVcCallback, PfSharedControllerEx.FailCallback("SubtractUserVirtualCurrency"));
            };
            return output;
        }

        private static void ModifyUserVcCallback(ClientModels.ModifyUserVirtualCurrencyResult addResult)
        {
            // You could theoretically keep your local balance up-to-date with local information, but it's safer to refresh the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnVcChanged, null);
        }
        #endregion Example Implementation of PlayFab Inventory APIs
    }
}
