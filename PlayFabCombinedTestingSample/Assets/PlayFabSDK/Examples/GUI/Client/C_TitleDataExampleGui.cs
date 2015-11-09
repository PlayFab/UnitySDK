using UnityEngine;
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

            Button(true, rowIndex, 0, "Refresh TitleData", TitleDataExample.GetTitleData);
            rowIndex++;

            // Display each of the existing keys - Title Data
            foreach (var titlePair in PfSharedModelEx.titleData)
            {
                // The client cannot modify title data
                TextField(true, rowIndex, 0, titlePair.Key);
                TextField(true, rowIndex, 1, titlePair.Value);
                rowIndex++;
            };
        }
        #endregion Unity GUI
    }
}
