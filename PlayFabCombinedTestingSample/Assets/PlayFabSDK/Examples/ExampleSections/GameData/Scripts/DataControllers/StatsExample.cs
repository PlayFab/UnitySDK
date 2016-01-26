using PlayFab.ClientModels;
using System.Collections.Generic;

namespace PlayFab.Examples.Client
{
    public static class StatsExample
    {
        #region Controller Event Handling
        static StatsExample()
        { }
        #endregion Controller Event Handling

        #region User/Character stats API
        public static void GetUserStatistics()
        {
            var request = new GetUserStatisticsRequest();
            PlayFabClientAPI.GetUserStatistics(request, GetUserStatisticsCallback, PfSharedControllerEx.FailCallback("GetUserStatistics"));
        }
        private static void GetUserStatisticsCallback(GetUserStatisticsResult result)
        {
            PfSharedModelEx.CurrentUser.UserStatistics = result.UserStatistics;
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
                PfSharedModelEx.CurrentUser.UserStatistics[statPair.Key] = statPair.Value;
                
			MainExampleController.DebugOutput("User Statistics Updated.");
        }
        
		public static void GetCharacterStatistics()
		{
			throw new System.NotImplementedException();
		}
		private static void GetCharacterStatisticsCallback(object result)
		{
			throw new System.NotImplementedException();
		}
		
		public static void UpdateCharacterStatistics(string key, int value)
		{
			throw new System.NotImplementedException();
		}
		
		private static void UpdateCharacterStatisticsCallback(object result)
		{
			throw new System.NotImplementedException();
		}
        #endregion User/Character stats API
    }
}
