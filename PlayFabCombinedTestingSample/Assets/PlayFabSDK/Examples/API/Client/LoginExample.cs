using System.Collections.Generic;

namespace PlayFab.Examples.Client
{
    public static class LoginExample
    {
        #region Login API
        public static void LoginWithEmail(string titleId, string devSecretKey, string email, string password)
        {
            PlayFabSettings.TitleId = titleId;
            PlayFabSettings.DeveloperSecretKey = devSecretKey;
            var loginRequest = new ClientModels.LoginWithEmailAddressRequest();
            loginRequest.Email = email;
            loginRequest.Password = password;
            PlayFabClientAPI.LoginWithEmailAddress(loginRequest, LoginCallBack, PfSharedControllerEx.FailCallback("LoginWithEmailAddress"));
        }
        public static void LoginCallBack(ClientModels.LoginResult loginResult)
        {
            // CLIENT
            PfSharedModelEx.globalClientUser.playFabId = loginResult.PlayFabId;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserLogin, loginResult.PlayFabId);
            var charRequest = new ClientModels.ListUsersCharactersRequest();
            PlayFabClientAPI.GetAllUsersCharacters(charRequest, CharCallBack, PfSharedControllerEx.FailCallback("GetAllUsersCharacters"));

            // SERVER - Re-use the same reference for now, but really it needs to create a separate object for each loaded player
            PfSharedModelEx.serverUsers.Add(loginResult.PlayFabId, PfSharedModelEx.globalClientUser);
        }
        public static void CharCallBack(ClientModels.ListUsersCharactersResult charResult)
        {
            PfSharedModelEx.globalClientUser.characterIds.Clear();
            PfSharedModelEx.globalClientUser.characterNames.Clear();
            foreach (var character in charResult.Characters)
            {
                PfSharedModelEx.globalClientUser.characterIds.Add(character.CharacterId);
                PfSharedModelEx.globalClientUser.characterNames.Add(character.CharacterName);
            }
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, PfSharedModelEx.globalClientUser.playFabId);
        }
        #endregion Login API
    }
}
