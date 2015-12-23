using PlayFab.ServerModels;
using System;
using System.Collections.Generic;

namespace PlayFab.Examples.Server
{
    public static class StatsExample
    {
        #region Controller Event Handling
        static StatsExample()
        {
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserLogin, OnUserLogin);
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, OnUserCharactersLoaded);
        }

        public static void SetUp()
        {
            // The static constructor is called as a by-product of this call
        }

        private static void OnUserLogin(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            GetUserStatistics(playFabId)();
        }

        private static void OnUserCharactersLoaded(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            if (eventSourceApi == PfSharedControllerEx.Api.Server)
                GetCharacterStatistics(playFabId, characterId)();
        }
        #endregion Controller Event Handling

        #region User stats API
        public static Action GetUserStatistics(string playFabId)
        {
            Action output = () =>
            {
                var request = new GetUserStatisticsRequest();
                request.PlayFabId = playFabId;
                PlayFabServerAPI.GetUserStatistics(request, GetUserStatisticsCallback,
                    PfSharedControllerEx.FailCallback("GetUserStatistics"));
            };
            return output;
        }
        private static void GetUserStatisticsCallback(GetUserStatisticsResult result)
        {
            string playFabId = ((GetUserStatisticsRequest)result.Request).PlayFabId;

            UserModel userModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel))
                userModel.userStatistics = result.UserStatistics;
        }

        public static Action UpdateUserStatistics(string playFabId, string key, int value)
        {
            Action output = () =>
            {
                var request = new UpdateUserStatisticsRequest();
                request.PlayFabId = playFabId;
                request.UserStatistics = new Dictionary<string, int>();
                request.UserStatistics[key] = value;
                PlayFabServerAPI.UpdateUserStatistics(request, UpdateUserStatisticsCallback, PfSharedControllerEx.FailCallback("UpdateUserStatistics"));
            };
            return output;
        }

        private static void UpdateUserStatisticsCallback(UpdateUserStatisticsResult result)
        {
            string playFabId = ((UpdateUserStatisticsRequest)result.Request).PlayFabId;
            var updatedStats = ((UpdateUserStatisticsRequest)result.Request).UserStatistics;

            UserModel userModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel))
                foreach (var statPair in updatedStats)
                    userModel.userStatistics[statPair.Key] = statPair.Value;
        }
        #endregion User stats API

        #region Character stats API
        public static Action GetCharacterStatistics(string playFabId, string characterId)
        {
            Action output = () =>
            {
                var request = new GetCharacterStatisticsRequest();
                request.PlayFabId = playFabId;
                request.CharacterId = characterId;
                PlayFabServerAPI.GetCharacterStatistics(request, GetCharacterStatisticsCallback, PfSharedControllerEx.FailCallback("GetCharacterStatistics"));
            };
            return output;
        }
        private static void GetCharacterStatisticsCallback(GetCharacterStatisticsResult result)
        {
            string playFabId = ((GetCharacterStatisticsRequest)result.Request).PlayFabId;
            string characterId = ((GetCharacterStatisticsRequest)result.Request).CharacterId;

            UserModel userModel; CharacterModel characterModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel) && userModel.serverCharacterModels.TryGetValue(characterId, out characterModel))
                characterModel.characterStatistics = result.CharacterStatistics;
        }

        public static Action UpdateCharacterStatistics(string playFabId, string characterId, string key, int value)
        {
            Action output = () =>
            {
                var request = new UpdateCharacterStatisticsRequest();
                request.CharacterStatistics = new Dictionary<string, int>();
                request.PlayFabId = playFabId;
                request.CharacterId = characterId;
                request.CharacterStatistics[key] = value;
                PlayFabServerAPI.UpdateCharacterStatistics(request, UpdateCharacterStatisticsCallback, PfSharedControllerEx.FailCallback("UpdateCharacterStatistics"));
            };
            return output;
        }

        private static void UpdateCharacterStatisticsCallback(UpdateCharacterStatisticsResult result)
        {
            string playFabId = ((UpdateCharacterStatisticsRequest)result.Request).PlayFabId;
            string characterId = ((UpdateCharacterStatisticsRequest)result.Request).CharacterId;
            var updatedStats = ((UpdateCharacterStatisticsRequest)result.Request).CharacterStatistics;

            UserModel userModel; CharacterModel characterModel;
            if (PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel) && userModel.serverCharacterModels.TryGetValue(characterId, out characterModel))
                foreach (var statPair in updatedStats)
                    characterModel.characterStatistics[statPair.Key] = statPair.Value;
        }
        #endregion Character stats API
    }
}
