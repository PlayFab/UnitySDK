using UnityEngine;
using System;
using System.Collections.Generic;

namespace PlayFab.Examples.Client
{
    public class C_TitleDataExampleGui : PfExampleGui
    {
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

            DisplayReadOnlyDataHelper(ref rowIndex, "TitleData", PfSharedModelEx.titleData, TitleDataExample.GetTitleData);
            DisplayReadOnlyDataHelper(ref rowIndex, "PublisherData", PfSharedModelEx.publisherData, TitleDataExample.GetPublisherData);
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
