using UnityEngine;
using System;
using System.Collections.Generic;

namespace PlayFab.Examples.Server
{
    public class S_StatsExampleGui : PfExampleGui
    {
        private string _newUserDataKey = "<new key>";
        private string _newUserDataValue = "0";

        // These need to be editable in the gui, independent of the current "real" value
        private readonly Dictionary<string, int> _existingUserValues = new Dictionary<string, int>();

        private delegate Action UserUpdateDelegate(string playFabId, string key, int value);
        private delegate Action CharacterUpdateDelegate(string playFabId, string characterId, string key, int value);

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

                DisplayDataHelper(ref rowIndex, userPair.Value.playFabId, "UserStats", userPair.Value.userStatistics, StatsExample.GetUserStatistics(userPair.Value.playFabId), StatsExample.UpdateUserStatistics, _existingUserValues, ref _newUserDataKey, ref _newUserDataValue);

                foreach (var charPair in userPair.Value.serverCharacterModels)
                {
                    DisplayDataHelper(ref rowIndex, userPair.Value.playFabId, charPair.Value.characterId, charPair.Value.characterName, charPair.Value.characterStatistics, StatsExample.GetCharacterStatistics(userPair.Value.playFabId, charPair.Value.characterId), StatsExample.UpdateCharacterStatistics, _existingUserValues, ref _newUserDataKey, ref _newUserDataValue);
                }
            }
        }

        private void DisplayDataHelper(ref int rowIndex, string playFabId, string dataDescription, Dictionary<string, int> data, Action refreshAction, UserUpdateDelegate updateDelegate, Dictionary<string, int> existingValuesCache, ref string newKey, ref string newValue)
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
                Button(temp != userPair.Value && canParse, rowIndex, 2, "Update", updateDelegate(playFabId, eachKey, temp));
                Button(temp != userPair.Value, rowIndex, 3, "Undo", () => { existingValuesCache.Remove(eachKey); });
                rowIndex++;
            }
            // Display a field to add new keys - User Data
            TextField(true, rowIndex, 0, ref newKey);
            TextField(true, rowIndex, 1, ref newValue);
            canParse = int.TryParse(newValue, out temp);
            Button(canParse, rowIndex, 2, "Add", updateDelegate(playFabId, newKey, temp));
            rowIndex++;
        }

        private void DisplayDataHelper(ref int rowIndex, string playFabId, string characterId, string dataDescription, Dictionary<string, int> data, Action refreshAction, CharacterUpdateDelegate updateDelegate, Dictionary<string, int> existingValuesCache, ref string newKey, ref string newValue)
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
                Button(temp != userPair.Value && canParse, rowIndex, 2, "Update", updateDelegate(playFabId, characterId, eachKey, temp));
                Button(temp != userPair.Value, rowIndex, 3, "Undo", () => { existingValuesCache.Remove(eachKey); });
                rowIndex++;
            }

            eachValue = newValue.ToString();
            // Display a field to add new keys - User Data
            TextField(true, rowIndex, 0, ref newKey);
            TextField(true, rowIndex, 1, ref eachValue);
            canParse = int.TryParse(eachValue, out temp);
            Button(canParse, rowIndex, 2, "Add", updateDelegate(playFabId, characterId, newKey, temp));
            rowIndex++;
        }
        #endregion Unity GUI
    }
}
