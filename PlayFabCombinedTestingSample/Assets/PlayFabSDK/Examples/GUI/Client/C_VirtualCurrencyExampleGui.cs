using System.Reflection;

namespace PlayFab.Examples.Client
{
    public class C_VirtualCurrencyExampleGui : PfExampleGui
    {
        private static readonly MethodInfo VirtualCurrencyExample_AddUserVirtualCurrency = typeof(VirtualCurrencyExample).GetMethod("AddUserVirtualCurrency", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo VirtualCurrencyExample_SubtractUserVirtualCurrency = typeof(VirtualCurrencyExample).GetMethod("SubtractUserVirtualCurrency", BindingFlags.Static | BindingFlags.Public);
        private static readonly MethodInfo VirtualCurrencyExample_GetCharacterVc = typeof(VirtualCurrencyExample).GetMethod("GetCharacterVc", BindingFlags.Static | BindingFlags.Public);

        public void Awake()
        {
            VirtualCurrencyExample.SetUp();
        }

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            bool charsValid = isLoggedIn && PfSharedModelEx.globalClientUser.clientCharacterModels.Count > 0;
            int colIndex, temp;

            // User Owned Currency
            Button(isLoggedIn, rowIndex, 0, "Refresh User VC:", VirtualCurrencyExample.GetUserVc);
            colIndex = 1;
            foreach (var vcKey in PfSharedModelEx.virutalCurrencyTypes)
            {
                PfSharedModelEx.globalClientUser.userVC.TryGetValue(vcKey, out temp);
                CounterField(isLoggedIn, rowIndex, colIndex++, vcKey + "=" + temp, VirtualCurrencyExample_AddUserVirtualCurrency, VirtualCurrencyExample_SubtractUserVirtualCurrency, vcKey, 1);
            }
            rowIndex++;
            rowIndex++;

            foreach (var charPair in PfSharedModelEx.globalClientUser.clientCharacterModels)
            {
                if (charPair.Value.characterVC == null)
                    continue;

                // User Owned Currency
                Button(charsValid, rowIndex, 0, "Refresh " + charPair.Value.characterName + " VC:", null, VirtualCurrencyExample_GetCharacterVc, charPair.Key);
                colIndex = 1;
                foreach (var vcKey in PfSharedModelEx.virutalCurrencyTypes)
                {
                    charPair.Value.characterVC.TryGetValue(vcKey, out temp);
                    TextField(charsValid, rowIndex, colIndex++, vcKey + "=" + temp); // You can display character vc on the client, but not modify it
                }
                rowIndex++;
                rowIndex++;
            }
        }
        #endregion Unity GUI
    }
}
