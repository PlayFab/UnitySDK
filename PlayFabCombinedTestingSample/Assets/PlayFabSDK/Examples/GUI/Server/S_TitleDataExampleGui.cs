using System;
using UnityEngine;
using System.Collections.Generic;

namespace PlayFab.Examples.Server
{
    public class S_TitleDataExampleGui : PfExampleGui
    {
        private string _newTitleDataKey = "<new key>";
        private string _newTitleDataValue = "";
        private string _newTitleInternalDataKey = "<new key>";
        private string _newTitleInternalDataValue = "";
        private string _newPubDataKey = "<new key>";
        private string _newPubDataValue = "";

        // These need to be editable in the gui, independent of the current "real" value
        private readonly Dictionary<string, string> _existingTitleValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingInternalValues = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _existingPublisherValues = new Dictionary<string, string>();

        private delegate Action UpdateDelegate(string key, string value);

        void Awake()
        {
            TitleDataExample.SetUp();
        }


        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            if (!isLoggedIn)
                return;

            DisplayDataHelper(ref rowIndex, "TitleData", PfSharedModelEx.titleData, TitleDataExample.GetTitleData, TitleDataExample.SetTitleData, _existingTitleValues, ref _newTitleDataKey, ref _newTitleDataValue);
            DisplayDataHelper(ref rowIndex, "InternalTitleData", PfSharedModelEx.titleInternalData, TitleDataExample.GetTitleInternalData, TitleDataExample.SetTitleInternalData, _existingInternalValues, ref _newTitleInternalDataKey, ref _newTitleInternalDataValue);
            DisplayDataHelper(ref rowIndex, "PublisherData", PfSharedModelEx.publisherData, TitleDataExample.GetPublisherData, TitleDataExample.SetPublisherData, _existingPublisherValues, ref _newPubDataKey, ref _newPubDataValue);
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
                Button(eachValue != userPair.Value, rowIndex, 2, string.IsNullOrEmpty(eachValue) ? "Delete key" : "Update",
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
        #endregion Unity GUI
    }
}
