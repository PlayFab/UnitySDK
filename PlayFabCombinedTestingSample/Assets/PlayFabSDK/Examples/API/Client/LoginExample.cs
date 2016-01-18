using PlayFab.ClientModels;
using PlayFab.Examples.Server;

namespace PlayFab.Examples.Client
{
    public static class LoginExample
    {
        #region Login API
        public static void LoginWithEmail(string titleId, string devSecretKey, string email, string password)
        {
            PlayFabSettings.TitleId = titleId;
            PlayFabSettings.DeveloperSecretKey = devSecretKey;
            var loginRequest = new LoginWithEmailAddressRequest();
            loginRequest.Email = email;
            loginRequest.Password = password;
            PlayFabClientAPI.LoginWithEmailAddress(loginRequest, LoginCallBack, PfSharedControllerEx.FailCallback("LoginWithEmailAddress"));
        }
        public static void LoginCallBack(LoginResult loginResult)
        {
            // CLIENT
            PfSharedModelEx.globalClientUser.playFabId = loginResult.PlayFabId;
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserLogin, loginResult.PlayFabId, null, PfSharedControllerEx.Api.Client, false);
            var clientRequest = new ListUsersCharactersRequest();
            PlayFabClientAPI.GetAllUsersCharacters(clientRequest, ClientCharCallBack, PfSharedControllerEx.FailCallback("C_GetAllUsersCharacters"));

            // SERVER
            PfSharedModelEx.serverUsers.Add(loginResult.PlayFabId, PfSharedModelEx.globalClientUser); // Ensure that they share the same object reference
            var serverRequest = new ServerModels.ListUsersCharactersRequest();
            serverRequest.PlayFabId = loginResult.PlayFabId;
            PlayFabServerAPI.GetAllUsersCharacters(serverRequest, ServerCharCallBack, PfSharedControllerEx.FailCallback("S_GetAllUsersCharacters"));
        }
        public static void ClientCharCallBack(ListUsersCharactersResult charResult)
        {
            CharacterModel temp;
            foreach (var character in charResult.Characters)
            {
                if (!PfSharedModelEx.globalClientUser.clientCharacterModels.TryGetValue(character.CharacterId, out temp))
                    PfSharedModelEx.globalClientUser.clientCharacterModels[character.CharacterId] = new PfInvClientChar(PfSharedModelEx.globalClientUser.playFabId, character.CharacterId, character.CharacterName);
                PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, PfSharedModelEx.globalClientUser.playFabId, character.CharacterId, PfSharedControllerEx.Api.Client, false);
            }
        }
        public static void ServerCharCallBack(ServerModels.ListUsersCharactersResult charResult)
        {
            string playFabId = ((ServerModels.ListUsersCharactersRequest)charResult.Request).PlayFabId;

            UserModel userModel;
            if (!PfSharedModelEx.serverUsers.TryGetValue(playFabId, out userModel))
                return;

            CharacterModel temp;
            foreach (var character in charResult.Characters)
            {
                if (!userModel.serverCharacterModels.TryGetValue(character.CharacterId, out temp))
                    userModel.serverCharacterModels[character.CharacterId] = new Server.PfInvServerChar(playFabId, character.CharacterId, character.CharacterName);
                userModel.serverCharacterModels[character.CharacterId] = new PfInvServerChar(playFabId, character.CharacterId, character.CharacterName);
                PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, playFabId, character.CharacterId, PfSharedControllerEx.Api.Server, false);
            }
        }
        #endregion Login API
    }
}
