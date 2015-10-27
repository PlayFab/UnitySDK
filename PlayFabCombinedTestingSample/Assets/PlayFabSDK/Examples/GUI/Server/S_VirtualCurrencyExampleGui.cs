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

            foreach (var userPair in PfSharedModelEx.serverUsers)
            {
                bool charsValid = isLoggedIn && userPair.Value.characterIds.Count > 0;
                int colIndex, temp;

                if (userPair.Value.characterVC == null)
                    return;

                // User Owned Currency
                Button(isLoggedIn, rowIndex, 0, "Refresh User VC:", VirtualCurrencyExample.GetUserVc(userPair.Key));
                colIndex = 1;
                foreach (var vcKey in PfSharedModelEx.virutalCurrencyTypes)
                {
                    userPair.Value.userVirtualCurrency.TryGetValue(vcKey, out temp);
                    CounterField(isLoggedIn, rowIndex, colIndex++, vcKey + "=" + temp, VirtualCurrencyExample.AddUserVirtualCurrency(userPair.Key, vcKey, 1), VirtualCurrencyExample.SubtractUserVirtualCurrency(userPair.Key, vcKey, 1));
                }
                rowIndex++;
                rowIndex++;

                for (int charIndex = 0; charIndex < userPair.Value.characterVC.Count; charIndex++)
                {
                    string eachCharacterId = userPair.Value.characterIds[charIndex];
                    string eachCharacterName = userPair.Value.characterNames[charIndex];
                    Dictionary<string, int> eachCharVcContainer = userPair.Value.characterVC[eachCharacterId];
                    if (eachCharVcContainer == null)
                        continue;

                    // User Owned Currency
                    Button(charsValid, rowIndex, 0, "Refresh " + eachCharacterName + " VC:", VirtualCurrencyExample.GetCharacterVc(userPair.Key, eachCharacterId));
                    colIndex = 1;
                    foreach (var vcKey in PfSharedModelEx.virutalCurrencyTypes)
                    {
                        eachCharVcContainer.TryGetValue(vcKey, out temp);
                        CounterField(charsValid, rowIndex, colIndex++, vcKey + "=" + temp, VirtualCurrencyExample.AddCharacterVirtualCurrency(userPair.Key, eachCharacterId, vcKey, 1), VirtualCurrencyExample.SubtractCharacterVirtualCurrency(userPair.Key, eachCharacterId, vcKey, 1));
                    }
                    rowIndex++;
                    rowIndex++;
                }
            }
        }
        #endregion Unity GUI
    }
}
