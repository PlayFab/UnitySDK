using UnityEngine;
using System;
using System.Collections.Generic;

namespace PlayFab.Examples.Client
{
    public class C_StatsExampleGui : PfExampleGui
    {
        private string _newUserDataKey = "<new key>";
        private int _newUserDataValue = 0;

        // These need to be editable in the gui, independent of the current "real" value
        private readonly Dictionary<string, int> _existingUserValues = new Dictionary<string, int>();

        private delegate Action UpdateDelegate(string key, int value);

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

            DisplayDataHelper(ref rowIndex, "UserStats", PfSharedModelEx.globalClientUser.userStatistics, StatsExample.GetUserStatistics, StatsExample.UpdateUserStatistics, _existingUserValues, ref _newUserDataKey, ref _newUserDataValue);
            // Client doesn't have access to CharacterStats
        }

        private void DisplayDataHelper(ref int rowIndex, string dataDescription, Dictionary<string, int> data, Action refreshAction, UpdateDelegate updateDelegate, Dictionary<string, int> existingValuesCache, ref string newKey, ref int newValue)
        {
            int temp;
            bool canParse;
            string eachValue;

            Button(true, rowIndex, 0, dataDescription, refreshAction);
            rowIndex++;
            // Display each of the existing keys
            foreach (var userPair in data)
            {
                string eachKey = userPair.Key;
                if (existingValuesCache.TryGetValue(eachKey, out temp))
                    eachValue = temp.ToString();
                else
                    eachValue = userPair.Value.ToString();

                TextField(true, rowIndex, 0, eachKey); // Existing keys cannot be modified
                TextField(true, rowIndex, 1, ref eachValue);

                canParse = int.TryParse(eachValue, out temp);
                existingValuesCache[eachKey] = temp;
                Button(temp != userPair.Value, rowIndex, 2, string.IsNullOrEmpty(eachValue) ? "Delete key" : "Update", updateDelegate(eachKey, temp));
                Button(temp != userPair.Value, rowIndex, 3, "Undo", () => { existingValuesCache.Remove(eachKey); });
                rowIndex++;
            }
            eachValue = newValue.ToString();
            // Display a field to add new keys - User Data
            TextField(true, rowIndex, 0, ref newKey);
            TextField(true, rowIndex, 1, ref eachValue);
            canParse = int.TryParse(eachValue, out temp);
            Button(canParse, rowIndex, 2, "Add", updateDelegate(newKey, temp));
            rowIndex++;
        }

        private void DisplayReadOnlyDataHelper(ref int rowIndex, string dataDescription, Dictionary<string, string> data, Action refreshAction)
        {
            Button(true, rowIndex, 0, dataDescription, refreshAction);
            rowIndex++;
            // Display each of the existing keys
            foreach (var userPair in data)
            {
                TextField(true, rowIndex, 0, userPair.Key);
                TextField(true, rowIndex, 1, userPair.Value);
                rowIndex++;
            }
        }
        #endregion Unity GUI
    }
}
