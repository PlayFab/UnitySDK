using System.Collections.Generic;

namespace PlayFab.Examples
{
    public class PfLoginExample : PfExampleGui
    {
        #region Example inter-relationships
        private void OnGUI()
        {
            if (loginExample == null)
                activeWindow = loginExample = GetComponent<PfLoginExample>();
            if (invExample == null)
                invExample = GetComponent<PfInventoryExample>();
            if (vcExample == null)
                vcExample = GetComponent<PfVcExample>();
            if (tradeExample == null)
                tradeExample = GetComponent<PfTradeExample>();

            int rowIndex = 0, colIndex = 0;
            if (loginExample != null)
                Button(true, rowIndex, colIndex++, "Login Example", () => { activeWindow = loginExample; });
            if (invExample != null)
                Button(true, rowIndex, colIndex++, "Inv Example", () => { activeWindow = invExample; });
            if (vcExample != null)
                Button(true, rowIndex, colIndex++, "VC Example", () => { activeWindow = vcExample; });
            if (tradeExample != null)
                Button(true, rowIndex, colIndex++, "Trade Example", () => { activeWindow = tradeExample; });

            rowIndex++;
            rowIndex++;
            if (activeWindow == loginExample)
                loginExample.OnExampleGUI(ref rowIndex);
            else if (activeWindow == invExample)
                invExample.OnExampleGUI(ref rowIndex);
            else if (activeWindow == vcExample)
                vcExample.OnExampleGUI(ref rowIndex);
            else if (activeWindow == tradeExample)
                tradeExample.OnExampleGUI(ref rowIndex);
        }
        #endregion Example inter-relationships

        #region Data Variables
        public string titleId = "Set your titleId here";
        public string devSecretKey = "Set your title secret key here";

        public string userName = "test username"; // Pick an existing valid username for this title
        public string email = "test@email.com"; // The email assigned to the user above
        public string password = "test password"; // The password for the user above

        public string playFabId;
        public List<string> characterIds = new List<string>();
        public List<string> characterNames = new List<string>();
        #endregion Data Variables

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();

            // Login
            Button(!isLoggedIn, rowIndex, 0, "Login", LoginWithEmail);
        }
        #endregion Unity GUI

        #region Login API
        private void LoginWithEmail()
        {
            PlayFabSettings.TitleId = titleId;
            PlayFabSettings.DeveloperSecretKey = devSecretKey;
            var loginRequest = new ClientModels.LoginWithEmailAddressRequest();
            loginRequest.Email = email;
            loginRequest.Password = password;
            PlayFabClientAPI.LoginWithEmailAddress(loginRequest, LoginCallBack, SharedFailCallback("LoginWithEmailAddress"));
        }
        private void LoginCallBack(ClientModels.LoginResult loginResult)
        {
            loginExample.playFabId = loginResult.PlayFabId;
            gameObject.SendMessage("OnPfUserLoginComplete"); // Alert any other example components that user-login is complete
            var charRequest = new ClientModels.ListUsersCharactersRequest();
            PlayFabClientAPI.GetAllUsersCharacters(charRequest, CharCallBack, SharedFailCallback("GetAllUsersCharacters"));
        }
        private void CharCallBack(ClientModels.ListUsersCharactersResult charResult)
        {
            characterIds.Clear();
            characterNames.Clear();
            foreach (var character in charResult.Characters)
            {
                characterIds.Add(character.CharacterId);
                characterNames.Add(character.CharacterName);
            }
            gameObject.SendMessage("OnPfCharLoginComplete"); // Alert any other example components that char-info is received
        }
        #endregion Login API
    }
}
