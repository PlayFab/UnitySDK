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

        private static void OnUserLogin(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            // Reload the user VC
            GetUserVc(playFabId)();
        }

        private static void OnUserCharactersLoaded(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            UserModel updatedUser;
            if (!PfSharedModelEx.serverUsers.TryGetValue(playFabId, out updatedUser))
                return;

            for (int i = 0; i < updatedUser.characterIds.Count; i++)
                GetCharacterVc(playFabId, updatedUser.characterIds[i])();
        }

        private static void OnVcChanged(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            UserModel updatedUser;
            if (!PfSharedModelEx.serverUsers.TryGetValue(playFabId, out updatedUser))
                return;

            if (characterId == null)
                // Reload the user VC
                GetUserVc(playFabId)();
            else if (updatedUser.characterIds.IndexOf(characterId) != -1)
                // Reload the character VC
                GetCharacterVc(playFabId, characterId)();
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

            UserModel userModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel))
                userModel.userVC = getResult.VirtualCurrency;
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
            string characterId = ((ServerModels.GetCharacterInventoryRequest)getResult.Request).CharacterId;

            UserModel userModel;
            CharacterModel characterModel;

            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel)
            && userModel.serverCharacterModels.TryGetValue(characterId, out characterModel))
                characterModel.characterVC = getResult.VirtualCurrency;

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
            UserModel userModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(modifyResult.PlayFabId, out userModel))
                userModel.SetVcBalance(null, modifyResult.VirtualCurrency, modifyResult.Balance);

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnVcChanged, modifyResult.PlayFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
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
                PlayFabServerAPI.AddCharacterVirtualCurrency(addRequest, AddCharVcCallback, PfSharedControllerEx.FailCallback("AddCharacterVirtualCurrency"));
            };
            return output;
        }
        private static void AddCharVcCallback(ServerModels.ModifyCharacterVirtualCurrencyResult modifyResult)
        {
            string playFabId = ((ServerModels.AddCharacterVirtualCurrencyRequest)modifyResult.Request).PlayFabId;
            string characterId = ((ServerModels.AddCharacterVirtualCurrencyRequest)modifyResult.Request).CharacterId;

            UserModel userModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel))
                userModel.SetVcBalance(characterId, modifyResult.VirtualCurrency, modifyResult.Balance);

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnVcChanged, playFabId, characterId, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
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
                PlayFabServerAPI.SubtractCharacterVirtualCurrency(addRequest, SubtractCharVcCallback, PfSharedControllerEx.FailCallback("SubtractCharacterVirtualCurrency"));
            };
            return output;
        }
        private static void SubtractCharVcCallback(ServerModels.ModifyCharacterVirtualCurrencyResult modifyResult)
        {
            string playFabId = ((ServerModels.SubtractCharacterVirtualCurrencyRequest)modifyResult.Request).PlayFabId;
            string characterId = ((ServerModels.SubtractCharacterVirtualCurrencyRequest)modifyResult.Request).CharacterId;

            UserModel userModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel))
                userModel.SetVcBalance(characterId, modifyResult.VirtualCurrency, modifyResult.Balance);

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnVcChanged, playFabId, characterId, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }
        #endregion Example Implementation of PlayFab Inventory APIs
    }
}
