using System.Collections.Generic;
using UnityEngine;

namespace PlayFab.Examples.Client
{
    public class C_VirtualCurrencyExampleGui : PfExampleGui
    {
        void Awake()
        {
            VirtualCurrencyExample.SetUp();
        }

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            bool charsValid = isLoggedIn && PfSharedModelEx.globalClientUser.characterIds.Count > 0;
            int colIndex, temp;

            if (PfSharedModelEx.globalClientUser.characterVC == null)
                return;

            // User Owned Currency
            Button(isLoggedIn, rowIndex, 0, "Refresh User VC:", VirtualCurrencyExample.GetUserVc);
            colIndex = 1;
            foreach (var vcKey in PfSharedModelEx.virutalCurrencyTypes)
            {
                PfSharedModelEx.globalClientUser.userVirtualCurrency.TryGetValue(vcKey, out temp);
                CounterField(isLoggedIn, rowIndex, colIndex++, vcKey + "=" + temp, VirtualCurrencyExample.AddUserVirtualCurrency(vcKey, 1), VirtualCurrencyExample.SubtractUserVirtualCurrency(vcKey, 1));
            }
            rowIndex++;
            rowIndex++;

            for (int charIndex = 0; charIndex < PfSharedModelEx.globalClientUser.characterVC.Count; charIndex++)
            {
                string eachCharacterId = PfSharedModelEx.globalClientUser.characterIds[charIndex];
                string eachCharacterName = PfSharedModelEx.globalClientUser.characterNames[charIndex];
                Dictionary<string, int> eachCharVcContainer = PfSharedModelEx.globalClientUser.characterVC[eachCharacterId];
                if (eachCharVcContainer == null)
                    continue;

                // User Owned Currency
                Button(charsValid, rowIndex, 0, "Refresh " + eachCharacterName + " VC:", VirtualCurrencyExample.GetCharacterVc(eachCharacterId));
                colIndex = 1;
                foreach (var vcKey in PfSharedModelEx.virutalCurrencyTypes)
                {
                    eachCharVcContainer.TryGetValue(vcKey, out temp);
                    TextField(charsValid, rowIndex, colIndex++, vcKey + "=" + temp); // You can display character vc on the client, but not modify it
                }
                rowIndex++;
                rowIndex++;
            }
        }
        #endregion Unity GUI
    }
}
