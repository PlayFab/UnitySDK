using System.Collections.Generic;
using System.Reflection;

namespace PlayFab.Examples.Client
{
    public class C_StatsExampleGui : PfExampleGui
    {
        private static readonly MethodInfo StatsExample_UpdateUserStatistics = typeof(StatsExample).GetMethod("UpdateUserStatistics", BindingFlags.Static | BindingFlags.Public);

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

            DisplayDataHelper(ref rowIndex, "UserStats", PfSharedModelEx.globalClientUser.userStatistics, StatsExample.GetUserStatistics, StatsExample_UpdateUserStatistics, _existingUserValues, ref _newUserDataKey, ref _newUserDataValue);
            // Client doesn't have access to CharacterStats
        }
        #endregion Unity GUI
    }
}
