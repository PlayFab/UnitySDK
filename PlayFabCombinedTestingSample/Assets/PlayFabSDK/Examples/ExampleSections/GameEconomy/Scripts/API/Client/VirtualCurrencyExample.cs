using UnityEngine;

namespace PlayFab.Examples.Client
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
            // The static constructor is called as a by-product of this call
        }

        private static void OnUserLogin(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            GetUserVc();
        }

        private static void OnUserCharactersLoaded(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            if (eventSourceApi == PfSharedControllerEx.Api.Client)
                GetCharacterVc(characterId);
        }

        private static void OnVcChanged(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            if (!requiresFullRefresh)
                return;

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
            PfSharedModelEx.currentUser.userVC = getResult.VirtualCurrency;
//            foreach (var pair in getResult.VirtualCurrency)
//                PfSharedModelEx.virutalCurrencyTypes.Add(pair.Key);
        }

        public static void GetCharacterVc(string characterId)
        {
            var getRequest = new ClientModels.GetCharacterInventoryRequest();
            getRequest.CharacterId = characterId;
            PlayFabClientAPI.GetCharacterInventory(getRequest, GetCharacterVcCallback, PfSharedControllerEx.FailCallback("GetCharacterInventory"));
        }
        private static void GetCharacterVcCallback(ClientModels.GetCharacterInventoryResult getResult)
        {
            string characterId = ((ClientModels.GetCharacterInventoryRequest)getResult.Request).CharacterId;

            CharacterModel characterModel;
            if (PfSharedModelEx.currentUser.userCharacters.TryGetValue(characterId, out characterModel))
                characterModel.characterVC = getResult.VirtualCurrency;
//            foreach (var pair in getResult.VirtualCurrency)
//                PfSharedModelEx.virutalCurrencyTypes.Add(pair.Key);
        }

        public static void AddUserVirtualCurrency(string vcKey, int amt)
        {
            ClientModels.AddUserVirtualCurrencyRequest addRequest = new ClientModels.AddUserVirtualCurrencyRequest();
            addRequest.VirtualCurrency = vcKey;
            addRequest.Amount = amt;
            PlayFabClientAPI.AddUserVirtualCurrency(addRequest, ModifyUserVcCallback, PfSharedControllerEx.FailCallback("AddUserVirtualCurrency"));
        }

        public static void SubtractUserVirtualCurrency(string vcKey, int amt)
        {
            ClientModels.SubtractUserVirtualCurrencyRequest addRequest = new ClientModels.SubtractUserVirtualCurrencyRequest();
            addRequest.VirtualCurrency = vcKey;
            addRequest.Amount = amt;
            PlayFabClientAPI.SubtractUserVirtualCurrency(addRequest, ModifyUserVcCallback, PfSharedControllerEx.FailCallback("SubtractUserVirtualCurrency"));
        }

        private static void ModifyUserVcCallback(ClientModels.ModifyUserVirtualCurrencyResult modResult)
        {
//            PfSharedModelEx.currentUser.SetVcBalance(null, modResult.VirtualCurrency, modResult.Balance);
//
//            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnVcChanged, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }
        #endregion Example Implementation of PlayFab Inventory APIs
    }
}
