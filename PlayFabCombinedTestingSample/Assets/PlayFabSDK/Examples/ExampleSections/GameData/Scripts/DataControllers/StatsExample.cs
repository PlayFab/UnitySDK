using PlayFab.ClientModels;
using System.Collections.Generic;

namespace PlayFab.Examples.Client
{
    public static class StatsExample
    {
        #region Controller Event Handling
        static StatsExample()
        {
           // PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserLogin, OnUserLogin);
           // PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, OnUserCharactersLoaded);
        }

        public static void SetUp()
        {
            // The static constructor is called as a by-product of this call
        }

        #endregion Controller Event Handling

        #region User/Character stats API
        public static void GetUserStatistics()
        {
            var request = new GetUserStatisticsRequest();
            PlayFabClientAPI.GetUserStatistics(request, GetUserStatisticsCallback, PfSharedControllerEx.FailCallback("GetUserStatistics"));
        }
        private static void GetUserStatisticsCallback(GetUserStatisticsResult result)
        {
            PfSharedModelEx.currentUser.userStatistics = result.UserStatistics;
			MainExampleController.DebugOutput("User Statistics Loaded.");
        }

        public static void UpdateUserStatistics(string key, int value)
        {
            var request = new UpdateUserStatisticsRequest();
            request.UserStatistics = new Dictionary<string, int>();
            request.UserStatistics[key] = value;
            PlayFabClientAPI.UpdateUserStatistics(request, UpdateUserStatisticsCallback, PfSharedControllerEx.FailCallback("UpdateUserStatistics"));
        }

        private static void UpdateUserStatisticsCallback(UpdateUserStatisticsResult result)
        {
            var updatedStats = ((UpdateUserStatisticsRequest)result.Request).UserStatistics;

            foreach (var statPair in updatedStats)
                PfSharedModelEx.currentUser.userStatistics[statPair.Key] = statPair.Value;
                
			MainExampleController.DebugOutput("User Statistics Updated.");
        }
        
        
        // character apis ----
        //TODO get a way for the client to get character statistics
        #endregion User/Character stats API
        
        
    }
}
