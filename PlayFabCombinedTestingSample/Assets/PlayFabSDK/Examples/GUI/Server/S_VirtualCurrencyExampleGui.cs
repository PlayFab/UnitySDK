using System.Collections.Generic;
using UnityEngine;

namespace PlayFab.Examples.Server
{
    public class S_VirtualCurrencyExampleGui : PfExampleGui
    {
        void Awake()
        {
            VirtualCurrencyExample.SetUp();
        }

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            bool charsValid = isLoggedIn && PfSharedModelEx.characterIds.Count > 0;
            int colIndex, temp;

            if (PfSharedModelEx.characterVC == null)
                return;

            // User Owned Currency
            Button(isLoggedIn, rowIndex, 0, "Refresh User VC:", VirtualCurrencyExample.GetUserVc);
            colIndex = 1;
            foreach (var vcKey in PfSharedModelEx.virutalCurrencyTypes)
            {
                PfSharedModelEx.userVirtualCurrency.TryGetValue(vcKey, out temp);
                CounterField(isLoggedIn, rowIndex, colIndex++, vcKey + "=" + temp, VirtualCurrencyExample.AddUserVirtualCurrency(vcKey, 1), VirtualCurrencyExample.SubtractUserVirtualCurrency(vcKey, 1));
            }
            rowIndex++;
            rowIndex++;

            for (int charIndex = 0; charIndex < PfSharedModelEx.characterVC.Count; charIndex++)
            {
                string eachCharacterId = PfSharedModelEx.characterIds[charIndex];
                string eachCharacterName = PfSharedModelEx.characterNames[charIndex];
                Dictionary<string, int> eachCharVcContainer = PfSharedModelEx.characterVC[eachCharacterId];
                if (eachCharVcContainer == null)
                    continue;

                // User Owned Currency
                Button(charsValid, rowIndex, 0, "Refresh " + eachCharacterName + " VC:", VirtualCurrencyExample.GetCharacterVc(eachCharacterId));
                colIndex = 1;
                foreach (var vcKey in PfSharedModelEx.virutalCurrencyTypes)
                {
                    eachCharVcContainer.TryGetValue(vcKey, out temp);
                    CounterField(charsValid, rowIndex, colIndex++, vcKey + "=" + temp, VirtualCurrencyExample.AddCharacterVirtualCurrency(eachCharacterId, vcKey, 1), VirtualCurrencyExample.SubtractCharacterVirtualCurrency(eachCharacterId, vcKey, 1));
                }
                rowIndex++;
                rowIndex++;
            }
        }
        #endregion Unity GUI
    }
}
