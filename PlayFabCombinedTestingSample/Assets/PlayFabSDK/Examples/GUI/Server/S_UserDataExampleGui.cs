using UnityEngine;
using System;
using System.Collections.Generic;

namespace PlayFab.Examples.Server
{
    public class S_UserDataExampleGui : PfExampleGui
    {
        private string _newUserDataKey = "<new key>";
        private string _newUserDataValue = "";
        private string _newUserReadOnlyDataKey = "<new key>";
        private string _newUserReadOnlyDataValue = "";
        private string _newUserInternalDataKey = "<new key>";
        private string _newUserInternalDataValue = "";
        private string _newUserPubDataKey = "<new key>";
        private string _newUserPubDataValue = "";
        private string _newUserReadOnlyPubDataKey = "<new key>";
        private string _newUserReadOnlyPubDataValue = "";
        private string _newUserInternalPubDataKey = "<new key>";
        private string _newUserInternalPubDataValue = "";

        // These need to be editable in the gui, independent of the current "real" value
        private readonly Dictionary<string, string> _existingUserValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingReadOnlyUserValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingInternalUserValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingPubValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingReadOnlyPubValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingInternalPubValues = new Dictionary<string, string>();

        private delegate Action UpdateDelegate(string playFabId, string key, string value);

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

            foreach (var serverUserPair in PfSharedModelEx.serverUsers)
            {
                string playFabId = serverUserPair.Key;
                var eachUser = serverUserPair.Value;

                TextField(true, rowIndex, 0, "PlayerId:");
                TextField(true, rowIndex, 1, playFabId);
                rowIndex++;
                rowIndex++;

                DisplayDataHelper(ref rowIndex, "UserData", playFabId, eachUser.userData, UserDataExample.GetUserData(playFabId), UserDataExample.UpdateUserData, _existingUserValues, ref _newUserDataKey, ref _newUserDataValue);
                DisplayDataHelper(ref rowIndex, "RO-UserData", playFabId, eachUser.userReadOnlyData, UserDataExample.GetUserReadOnlyData(playFabId), UserDataExample.UpdateReadOnlyUserData, _existingReadOnlyUserValues, ref _newUserReadOnlyDataKey, ref _newUserReadOnlyDataValue);
                DisplayDataHelper(ref rowIndex, "InternalData", playFabId, eachUser.userInternalData, UserDataExample.GetUserInternalData(playFabId), UserDataExample.UpdateInternalUserData, _existingInternalUserValues, ref _newUserInternalDataKey, ref _newUserInternalDataValue);
                rowIndex++;

                DisplayDataHelper(ref rowIndex, "UserPubData", playFabId, eachUser.userPublisherData, UserDataExample.GetUserPublisherData(playFabId), UserDataExample.UpdateUserPublisherData, _existingPubValues, ref _newUserPubDataKey, ref _newUserPubDataValue);
                DisplayDataHelper(ref rowIndex, "RO-UserPubData", playFabId, eachUser.userPublisherReadOnlyData, UserDataExample.GetUserPublisherReadOnlyData(playFabId), UserDataExample.UpdateReadOnlyUserPublisherData, _existingReadOnlyPubValues, ref _newUserReadOnlyPubDataKey, ref _newUserReadOnlyPubDataValue);
                DisplayDataHelper(ref rowIndex, "InternalPubData", playFabId, eachUser.userPublisherInternalData, UserDataExample.GetUserInternalData(playFabId), UserDataExample.UpdateInternalUserPublisherData, _existingInternalPubValues, ref _newUserInternalPubDataKey, ref _newUserInternalPubDataValue);
            }
        }

        private void DisplayDataHelper(ref int rowIndex, string dataDescription, string playFabId, Dictionary<string, string> data, Action refreshAction, UpdateDelegate updateDelegate, Dictionary<string, string> existingValuesCache, ref string newKey, ref string newValue)
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
                    updateDelegate(playFabId, eachKey, eachValue));
                Button(eachValue != userPair.Value, rowIndex, 3, "Undo", () => { existingValuesCache.Remove(eachKey); });
                rowIndex++;
            }
            // Display a field to add new keys - User Data
            TextField(true, rowIndex, 0, ref newKey);
            TextField(true, rowIndex, 1, ref newValue);
            Button(true, rowIndex, 2, "Add",
                updateDelegate(playFabId, newKey, newValue));
            rowIndex++;
        }

        #endregion Unity GUI
    }
}
