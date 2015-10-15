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
            PfSharedModelEx.playFabId = loginResult.PlayFabId;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserLogin, loginResult.PlayFabId);
            var charRequest = new ClientModels.ListUsersCharactersRequest();
            PlayFabClientAPI.GetAllUsersCharacters(charRequest, CharCallBack, PfSharedControllerEx.FailCallback("GetAllUsersCharacters"));
        }
        public static void CharCallBack(ClientModels.ListUsersCharactersResult charResult)
        {
            PfSharedModelEx.characterIds.Clear();
            PfSharedModelEx.characterNames.Clear();
            foreach (var character in charResult.Characters)
            {
                PfSharedModelEx.characterIds.Add(character.CharacterId);
                PfSharedModelEx.characterNames.Add(character.CharacterName);
            }
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnAllCharactersLoaded, null);
        }
        #endregion Login API
    }
}
