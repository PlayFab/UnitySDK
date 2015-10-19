using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayFab.Examples.Server
{
    /// <summary>
    /// This is example code for all the API's described here: PlayFab Inventory System - Basic Virtual Currency Guide
    /// This file contains calls to each of the functions described, an old-style Unity-gui to demonstrate the inventory changes taking place, and the prerequisite login and setup code.
    /// </summary>
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
        }

        // The static constructor is called as a by-product of this call  }

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
                GetCharacterVc(characterId)();
        }
        #endregion Controller Event Handling

        #region Example Implementation of PlayFab Virtual Currency APIs
        public static void GetUserVc()
        {
            var getRequest = new ServerModels.GetUserInventoryRequest();
            getRequest.PlayFabId = PfSharedModelEx.playFabId;
            PlayFabServerAPI.GetUserInventory(getRequest, GetUserVcCallback, PfSharedControllerEx.FailCallback("GetUserInventory"));
        }
        private static void GetUserVcCallback(ServerModels.GetUserInventoryResult getResult)
        {
            PfSharedModelEx.userVirtualCurrency = getResult.VirtualCurrency;
            foreach (var pair in getResult.VirtualCurrency)
                PfSharedModelEx.virutalCurrencyTypes.Add(pair.Key);
        }

        public static Action GetCharacterVc(string characterId)
        {
            Action output = () =>
            {
                var getRequest = new ServerModels.GetCharacterInventoryRequest();
                getRequest.PlayFabId = PfSharedModelEx.playFabId;
                getRequest.CharacterId = characterId;
                PlayFabServerAPI.GetCharacterInventory(getRequest, GetCharacterVcCallback, PfSharedControllerEx.FailCallback("GetCharacterInventory"));
            };
            return output;
        }
        private static void GetCharacterVcCallback(ServerModels.GetCharacterInventoryResult getResult)
        {
            PfSharedModelEx.characterVC[((ServerModels.GetCharacterInventoryRequest)getResult.Request).CharacterId] = getResult.VirtualCurrency;
            foreach (var pair in getResult.VirtualCurrency)
                PfSharedModelEx.virutalCurrencyTypes.Add(pair.Key);
        }

        public static Action AddUserVirtualCurrency(string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.AddUserVirtualCurrencyRequest addRequest = new ServerModels.AddUserVirtualCurrencyRequest();
                addRequest.PlayFabId = PfSharedModelEx.playFabId;
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabServerAPI.AddUserVirtualCurrency(addRequest, ModifyUserVcCallback, PfSharedControllerEx.FailCallback("AddUserVirtualCurrency"));
            };
            return output;
        }

        public static Action SubtractUserVirtualCurrency(string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.SubtractUserVirtualCurrencyRequest addRequest = new ServerModels.SubtractUserVirtualCurrencyRequest();
                addRequest.PlayFabId = PfSharedModelEx.playFabId;
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabServerAPI.SubtractUserVirtualCurrency(addRequest, ModifyUserVcCallback, PfSharedControllerEx.FailCallback("SubtractUserVirtualCurrency"));
            };
            return output;
        }

        private static void ModifyUserVcCallback(ServerModels.ModifyUserVirtualCurrencyResult modifyResult)
        {
            // You could theoretically keep your local balance up-to-date with local information, but it's safer to refresh the full list:
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnVcChanged, null);
        }

        public static Action AddCharacterVirtualCurrency(string characterId, string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.AddCharacterVirtualCurrencyRequest addRequest = new ServerModels.AddCharacterVirtualCurrencyRequest();
                addRequest.PlayFabId = PfSharedModelEx.playFabId;
                addRequest.CharacterId = characterId;
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabServerAPI.AddCharacterVirtualCurrency(addRequest, AddCharVcCallback(characterId), PfSharedControllerEx.FailCallback("AddCharacterVirtualCurrency"));
            };
            return output;
        }
        private static PlayFabServerAPI.AddCharacterVirtualCurrencyCallback AddCharVcCallback(string characterId)
        {
            PlayFabServerAPI.AddCharacterVirtualCurrencyCallback output = (ServerModels.ModifyCharacterVirtualCurrencyResult modifyResult) =>
            {
                // You could theoretically keep your local balance up-to-date with local information, but it's safer to refresh the full list:
                PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnVcChanged, characterId);
            };
            return output;
        }

        public static Action SubtractCharacterVirtualCurrency(string characterId, string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.SubtractCharacterVirtualCurrencyRequest addRequest = new ServerModels.SubtractCharacterVirtualCurrencyRequest();
                addRequest.PlayFabId = PfSharedModelEx.playFabId;
                addRequest.CharacterId = characterId;
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabServerAPI.SubtractCharacterVirtualCurrency(addRequest, SubtractCharVcCallback(characterId), PfSharedControllerEx.FailCallback("SubtractCharacterVirtualCurrency"));
            };
            return output;
        }
        private static PlayFabServerAPI.SubtractCharacterVirtualCurrencyCallback SubtractCharVcCallback(string characterId)
        {
            PlayFabServerAPI.SubtractCharacterVirtualCurrencyCallback output = (ServerModels.ModifyCharacterVirtualCurrencyResult modifyResult) =>
            {
                // You could theoretically keep your local balance up-to-date with local information, but it's safer to refresh the full list:
                PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnVcChanged, characterId);
            };
            return output;
        }
        #endregion Example Implementation of PlayFab Inventory APIs
    }
}
