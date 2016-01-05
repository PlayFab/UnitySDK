using System.Collections.Generic;
using System.Reflection;

namespace PlayFab.Examples.Server
{
    public class S_StatsExampleGui : PfExampleGui
    {
        private static readonly MethodInfo StatsExample_GetUserStatistics = typeof(StatsExample).GetMethod("GetUserStatistics", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo StatsExample_UpdateUserStatistics = typeof(StatsExample).GetMethod("UpdateUserStatistics", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo StatsExample_GetCharacterStatistics = typeof(StatsExample).GetMethod("GetCharacterStatistics", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo StatsExample_UpdateCharacterStatistics = typeof(StatsExample).GetMethod("UpdateCharacterStatistics", BindingFlags.Static | BindingFlags.Public);

        private string _newUserDataKey = "<new key>";
        private int _newUserDataValue = 0;

        // These need to be editable in the gui, independent of the current "real" value
        private readonly Dictionary<string, int> _existingUserValues = new Dictionary<string, int>();

        public void Awake()
        {
            StatsExample.SetUp();
        }

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            if (!isLoggedIn)
                return;

            foreach (var userPair in PfSharedModelEx.serverUsers)
            {
                TextField(true, rowIndex, 0, userPair.Value.playFabId);
                rowIndex++;

                DisplayDataHelper(ref rowIndex, "UserStats", userPair.Value.playFabId, null, userPair.Value.userStatistics, StatsExample_GetUserStatistics, StatsExample_UpdateUserStatistics, _existingUserValues, ref _newUserDataKey, ref _newUserDataValue);

                foreach (var charPair in userPair.Value.serverCharacterModels)
                {
                    DisplayDataHelper(ref rowIndex, charPair.Value.characterName, userPair.Value.playFabId, charPair.Value.characterId, charPair.Value.characterStatistics, StatsExample_GetCharacterStatistics, StatsExample_UpdateCharacterStatistics, _existingUserValues, ref _newUserDataKey, ref _newUserDataValue);
                }
            }
        }
        #endregion Unity GUI
    }
}
