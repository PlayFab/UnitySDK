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
                bool charsValid = isLoggedIn && userPair.Value.serverCharacterModels.Count > 0;
                int colIndex, temp;

                // User Owned Currency
                Button(isLoggedIn, rowIndex, 0, "Refresh User VC:", VirtualCurrencyExample.GetUserVc(userPair.Key));
                colIndex = 1;
                foreach (var vcKey in PfSharedModelEx.virutalCurrencyTypes)
                {
                    userPair.Value.userVC.TryGetValue(vcKey, out temp);
                    CounterField(isLoggedIn, rowIndex, colIndex++, vcKey + "=" + temp, VirtualCurrencyExample.AddUserVirtualCurrency(userPair.Key, vcKey, 1), VirtualCurrencyExample.SubtractUserVirtualCurrency(userPair.Key, vcKey, 1));
                }
                rowIndex++;
                rowIndex++;

                foreach (var charPair in userPair.Value.serverCharacterModels)
                {
                    PfInvServerChar eachCharacter = charPair.Value as PfInvServerChar;
                    if (eachCharacter == null || eachCharacter.characterVC == null)
                        continue;

                    // User Owned Currency
                    Button(charsValid, rowIndex, 0, "Refresh " + eachCharacter.characterName + " VC:", VirtualCurrencyExample.GetCharacterVc(userPair.Key, eachCharacter.characterId));
                    colIndex = 1;
                    foreach (var vcKey in PfSharedModelEx.virutalCurrencyTypes)
                    {
                        eachCharacter.characterVC.TryGetValue(vcKey, out temp);
                        CounterField(charsValid, rowIndex, colIndex++, vcKey + "=" + temp, VirtualCurrencyExample.AddCharacterVirtualCurrency(userPair.Key, eachCharacter.characterId, vcKey, 1), VirtualCurrencyExample.SubtractCharacterVirtualCurrency(userPair.Key, eachCharacter.characterId, vcKey, 1));
                    }
                    rowIndex++;
                    rowIndex++;
                }
            }
        }
        #endregion Unity GUI
    }
}
