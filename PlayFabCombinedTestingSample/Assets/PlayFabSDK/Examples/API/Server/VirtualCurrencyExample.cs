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
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, OnUserCharactersLoaded);
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnVcChanged, OnVcChanged);
        }
        public static void SetUp()
        {
        }

        // The static constructor is called as a by-product of this call  }

        private static void OnUserLogin(string playFabId)
        {
            // Reload the user VC
            foreach (var userPair in PfSharedModelEx.serverUsers)
                GetUserVc(userPair.Key)();
        }

        private static void OnUserCharactersLoaded(string playFabId)
        {
            PfSharedModelEx.serverUsers[playFabId].characterVC.Clear();
            for (int i = 0; i < PfSharedModelEx.serverUsers[playFabId].characterIds.Count; i++)
                GetCharacterVc(playFabId, PfSharedModelEx.serverUsers[playFabId].characterIds[i])();
        }

        private static void OnVcChanged(string characterId)
        {
            foreach (var userPair in PfSharedModelEx.serverUsers)
                if (characterId == null)
                    // Reload the user VC
                    GetUserVc(userPair.Key)();
                else if (userPair.Value.characterIds.IndexOf(characterId) != -1)
                    // Reload the character VC
                    GetCharacterVc(userPair.Value.playFabId, characterId)();
        }
        #endregion Controller Event Handling

        #region Example Implementation of PlayFab Virtual Currency APIs
        public static Action GetUserVc(string playFabId)
        {
            Action output = () =>
            {
                var getRequest = new ServerModels.GetUserInventoryRequest();
                getRequest.PlayFabId = playFabId;
                PlayFabServerAPI.GetUserInventory(getRequest, GetUserVcCallback, PfSharedControllerEx.FailCallback("GetUserInventory"));
            };
            return output;
        }
        private static void GetUserVcCallback(ServerModels.GetUserInventoryResult getResult)
        {
            string playFabId = ((ServerModels.GetUserInventoryRequest)getResult.Request).PlayFabId;

            PfSharedModelEx.serverUsers[playFabId].userVirtualCurrency = getResult.VirtualCurrency;
            foreach (var pair in getResult.VirtualCurrency)
                PfSharedModelEx.virutalCurrencyTypes.Add(pair.Key);
        }

        public static Action GetCharacterVc(string playFabId, string characterId)
        {
            Action output = () =>
            {
                var getRequest = new ServerModels.GetCharacterInventoryRequest();
                getRequest.PlayFabId = playFabId;
                getRequest.CharacterId = characterId;
                PlayFabServerAPI.GetCharacterInventory(getRequest, GetCharacterVcCallback, PfSharedControllerEx.FailCallback("GetCharacterInventory"));
            };
            return output;
        }
        private static void GetCharacterVcCallback(ServerModels.GetCharacterInventoryResult getResult)
        {
            string playFabId = ((ServerModels.GetCharacterInventoryRequest)getResult.Request).PlayFabId;

            PfSharedModelEx.serverUsers[playFabId].characterVC[((ServerModels.GetCharacterInventoryRequest)getResult.Request).CharacterId] = getResult.VirtualCurrency;
            foreach (var pair in getResult.VirtualCurrency)
                PfSharedModelEx.virutalCurrencyTypes.Add(pair.Key);
        }

        public static Action AddUserVirtualCurrency(string playFabId, string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.AddUserVirtualCurrencyRequest addRequest = new ServerModels.AddUserVirtualCurrencyRequest();
                addRequest.PlayFabId = playFabId;
                addRequest.VirtualCurrency = vcKey;
                addRequest.Amount = amt;
                PlayFabServerAPI.AddUserVirtualCurrency(addRequest, ModifyUserVcCallback, PfSharedControllerEx.FailCallback("AddUserVirtualCurrency"));
            };
            return output;
        }

        public static Action SubtractUserVirtualCurrency(string playFabId, string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.SubtractUserVirtualCurrencyRequest addRequest = new ServerModels.SubtractUserVirtualCurrencyRequest();
                addRequest.PlayFabId = playFabId;
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

        public static Action AddCharacterVirtualCurrency(string playFabId, string characterId, string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.AddCharacterVirtualCurrencyRequest addRequest = new ServerModels.AddCharacterVirtualCurrencyRequest();
                addRequest.PlayFabId = playFabId;
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

        public static Action SubtractCharacterVirtualCurrency(string playFabId, string characterId, string vcKey, int amt)
        {
            Action output = () =>
            {
                ServerModels.SubtractCharacterVirtualCurrencyRequest addRequest = new ServerModels.SubtractCharacterVirtualCurrencyRequest();
                addRequest.PlayFabId = playFabId;
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
