using PlayFab;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using AdminModels = PlayFab.AdminModels;
using ClientModels = PlayFab.ClientModels;
using ServerModels = PlayFab.ServerModels;

namespace PlayFab.Examples
{
    public class PfLoginExample : PfExampleGui
    {
        #region Data Variables
        public string titleId = "Set your titleId here";
        public string devSecretKey = "Set your title secret key here";

        public string userName = "test username"; // Pick an existing valid username for this title
        public string email = "test@email.com"; // The email assigned to the user above
        public string password = "test password"; // The password for the user above

        public string playFabId;
        #endregion Data Variables

        #region Unity GUI
        private void OnGUI()
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();

            // Login
            Button(!isLoggedIn, 0, 0, "Login", LoginWithEmail);
        }

        private ErrorCallback SharedFailCallback(string caller)
        {
            ErrorCallback output = (PlayFabError error) =>
            {
                Debug.LogError(caller + " failure: " + error.ErrorMessage);
            };
            return output;
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
            pfLoginExample.playFabId = loginResult.PlayFabId;
            gameObject.SendMessage("OnPfLoginComplete"); // Alert any other example components that login is complete
        }
        #endregion Login API
    }
}
