using UnityEngine;
using System;
using System.Collections.Generic;

namespace PlayFab.Examples.Client
{
    public class C_UserDataExampleGui : PfExampleGui
    {
        private string _newUserDataKey = "<new key>";
        private string _newUserDataValue = "";
        private string _newUserPubDataKey = "<new key>";
        private string _newUserPubDataValue = "";

        // These need to be editable in the gui, independent of the current "real" value
        private readonly Dictionary<string, string> _existingUserValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingPubValues = new Dictionary<string, string>();

        private delegate Action UpdateDelegate(string key, string value);

        public void Awake()
        {
            UserDataExample.SetUp();
        }

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            if (!isLoggedIn)
                return;

            DisplayDataHelper(ref rowIndex, "UserData", PfSharedModelEx.globalClientUser.userData, UserDataExample.GetUserData, UserDataExample.UpdateUserData, _existingUserValues, ref _newUserDataKey, ref _newUserDataValue);
            DisplayReadOnlyDataHelper(ref rowIndex, "RO-UserData", PfSharedModelEx.globalClientUser.userReadOnlyData, UserDataExample.GetUserReadOnlyData);
            // Client doesn't have access to internal user data
            rowIndex++;

            DisplayDataHelper(ref rowIndex, "UserPubData", PfSharedModelEx.globalClientUser.userPublisherData, UserDataExample.GetUserPublisherData, UserDataExample.UpdatePublisherdata, _existingPubValues, ref _newUserPubDataKey, ref _newUserPubDataValue);
            DisplayReadOnlyDataHelper(ref rowIndex, "RO-UserPubData", PfSharedModelEx.globalClientUser.userPublisherReadOnlyData, UserDataExample.GetUserPublisherReadOnlyData);
            // Client doesn't have access to internal user publisher data
        }

        private void DisplayDataHelper(ref int rowIndex, string dataDescription, Dictionary<string, string> data, Action refreshAction, UpdateDelegate updateDelegate, Dictionary<string, string> existingValuesCache, ref string newKey, ref string newValue)
        {
            Button(true, rowIndex, 0, dataDescription, refreshAction);
            rowIndex++;
            // Display each of the existing keys
            foreach (var userPair in data)
            {
                string eachKey = userPair.Key, eachValue;
                if (!existingValuesCache.TryGetValue(eachKey, out eachValue))
                    eachValue = userPair.Value;

                TextField(true, rowIndex, 0, eachKey); // Existing keys cannot be modified
                existingValuesCache[eachKey] = eachValue = TextField(true, rowIndex, 1, eachValue);
                Button(true, rowIndex, 2, string.IsNullOrEmpty(eachValue) ? "Delete key" : "Update",
                    updateDelegate(eachKey, eachValue));
                Button(eachValue != userPair.Value, rowIndex, 3, "Undo", () => { existingValuesCache.Remove(eachKey); });
                rowIndex++;
            }
            // Display a field to add new keys - User Data
            TextField(true, rowIndex, 0, ref newKey);
            TextField(true, rowIndex, 1, ref newValue);
            Button(true, rowIndex, 2, "Add",
                updateDelegate(newKey, newValue));
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
