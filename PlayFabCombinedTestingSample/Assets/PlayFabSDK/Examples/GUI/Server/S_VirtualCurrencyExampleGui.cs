using System.Reflection;

namespace PlayFab.Examples.Server
{
    public class S_VirtualCurrencyExampleGui : PfExampleGui
    {
        private static readonly MethodInfo VirtualCurrencyExample_GetUserVc = typeof(VirtualCurrencyExample).GetMethod("GetUserVc", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo VirtualCurrencyExample_AddUserVirtualCurrency = typeof(VirtualCurrencyExample).GetMethod("AddUserVirtualCurrency", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo VirtualCurrencyExample_SubtractUserVirtualCurrency = typeof(VirtualCurrencyExample).GetMethod("SubtractUserVirtualCurrency", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo VirtualCurrencyExample_GetCharacterVc = typeof(VirtualCurrencyExample).GetMethod("GetCharacterVc", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo VirtualCurrencyExample_AddCharacterVirtualCurrency = typeof(VirtualCurrencyExample).GetMethod("AddCharacterVirtualCurrency", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo VirtualCurrencyExample_SubtractCharacterVirtualCurrency = typeof(VirtualCurrencyExample).GetMethod("SubtractCharacterVirtualCurrency", BindingFlags.Static | BindingFlags.Public);

        public void Awake()
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
                Button(isLoggedIn, rowIndex, 0, "Refresh User VC:", null, VirtualCurrencyExample_GetUserVc, userPair.Key);
                colIndex = 1;
                foreach (var vcKey in PfSharedModelEx.virutalCurrencyTypes)
                {
                    userPair.Value.userVC.TryGetValue(vcKey, out temp);
                    CounterField(isLoggedIn, rowIndex, colIndex++, vcKey + "=" + temp, VirtualCurrencyExample_AddUserVirtualCurrency, VirtualCurrencyExample_SubtractUserVirtualCurrency, userPair.Key, vcKey, 1);
                }
                rowIndex++;
                rowIndex++;

                foreach (var charPair in userPair.Value.serverCharacterModels)
                {
                    PfInvServerChar eachCharacter = charPair.Value as PfInvServerChar;
                    if (eachCharacter == null || eachCharacter.characterVC == null)
                        continue;

                    // User Owned Currency
                    Button(charsValid, rowIndex, 0, "Refresh " + eachCharacter.characterName + " VC:", null, VirtualCurrencyExample_GetCharacterVc, userPair.Key, eachCharacter.characterId);
                    colIndex = 1;
                    foreach (var vcKey in PfSharedModelEx.virutalCurrencyTypes)
                    {
                        eachCharacter.characterVC.TryGetValue(vcKey, out temp);
                        CounterField(charsValid, rowIndex, colIndex++, vcKey + "=" + temp, VirtualCurrencyExample_AddCharacterVirtualCurrency, VirtualCurrencyExample_SubtractCharacterVirtualCurrency, userPair.Key, eachCharacter.characterId, vcKey, 1);
                    }
                    rowIndex++;
                    rowIndex++;
                }
            }
        }
        #endregion Unity GUI
    }
}
