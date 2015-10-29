using UnityEngine;
using System.Collections.Generic;

namespace PlayFab.Examples.Server
{
    public class S_TitleDataExampleGui : PfExampleGui
    {
        private string newTitleDataKey = "<new key>";
        private string newTitleDataValue = "";
        private string newTitleInternalDataKey = "<new key>";
        private string newTitleInternalDataValue = "";

        // These need to be editable in the gui, independent of the current "real" value
        private Dictionary<string, string> existingValues = new Dictionary<string, string>();
        private Dictionary<string, string> existingInternalValues = new Dictionary<string, string>();

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

            Button(true, rowIndex, 0, "Refresh TitleData", TitleDataExample.GetTitleData);
            rowIndex++;

            // Display each of the existing keys - Title Data
            foreach (var titlePair in PfSharedModelEx.serverTitleData)
            {
                string eachKey = titlePair.Key, eachValue;
                if (!existingValues.TryGetValue(eachKey, out eachValue))
                    eachValue = titlePair.Value;

                TextField(true, rowIndex, 0, eachKey); // Existing keys cannot be modified
                existingValues[eachKey] = eachValue = TextField(true, rowIndex, 1, eachValue);
                Button(true, rowIndex, 2, string.IsNullOrEmpty(eachValue) ? "Delete key" : "Update TitleData", TitleDataExample.SetTitleData(eachKey, eachValue, false));
                Button(eachValue != titlePair.Value, rowIndex, 3, "Undo", () => { existingValues.Remove(eachKey); });
                rowIndex++;
            };
            // Display a field to add new keys - Title Data
            TextField(true, rowIndex, 0, ref newTitleDataKey);
            TextField(true, rowIndex, 1, ref newTitleDataValue);
            Button(true, rowIndex, 2, "Add TitleData", TitleDataExample.SetTitleData(newTitleDataKey, newTitleDataValue, false));
            rowIndex++;
            rowIndex++;

            Button(true, rowIndex, 0, "Refresh InternalData", TitleDataExample.GetTitleInternalData);
            rowIndex++;

            // Display each of the existing keys - Internal Title Data
            foreach (var titlePair in PfSharedModelEx.serverInternalTitleData)
            {
                string eachKey = titlePair.Key, eachValue;
                if (!existingInternalValues.TryGetValue(eachKey, out eachValue))
                    eachValue = titlePair.Value;

                TextField(true, rowIndex, 0, eachKey); // Existing keys cannot be modified
                existingInternalValues[eachKey] = eachValue = TextField(true, rowIndex, 1, eachValue);
                Button(true, rowIndex, 2, string.IsNullOrEmpty(eachValue) ? "Delete key" : "Update InternalData", TitleDataExample.SetTitleData(eachKey, eachValue, true));
                Button(eachValue != titlePair.Value, rowIndex, 3, "Undo", () => { existingInternalValues.Remove(eachKey); });
                rowIndex++;
            };
            // Display a field to add new keys - Internal Title Data
            TextField(true, rowIndex, 0, ref newTitleInternalDataKey);
            TextField(true, rowIndex, 1, ref newTitleInternalDataValue);
            Button(true, rowIndex, 2, "Add InternalData", TitleDataExample.SetTitleData(newTitleInternalDataKey, newTitleInternalDataValue, true));
        }
        #endregion Unity GUI
    }
}
