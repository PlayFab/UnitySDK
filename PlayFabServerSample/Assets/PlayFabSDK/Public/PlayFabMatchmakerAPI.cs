using System;
using PlayFab.Json;
using PlayFab.MatchmakerModels;
using PlayFab.Internal;

namespace PlayFab
{
    /// <summary>
    /// Enables the use of an external match-making service in conjunction with PlayFab hosted Game Server instances
    /// </summary>
    public static class PlayFabMatchmakerAPI
    {
        public delegate void AuthUserCallback(AuthUserResponse result);
        public delegate void PlayerJoinedCallback(PlayerJoinedResponse result);
        public delegate void PlayerLeftCallback(PlayerLeftResponse result);
        public delegate void StartGameCallback(StartGameResponse result);
        public delegate void UserInfoCallback(UserInfoResponse result);


        /// <summary>
        /// Validates a user with the PlayFab service
        /// </summary>
        public static void AuthUser(AuthUserRequest request, AuthUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                AuthUserResponse result;
                ResultContainer<AuthUserResponse>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    
                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Matchmaker/AuthUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
        /// </summary>
        public static void PlayerJoined(PlayerJoinedRequest request, PlayerJoinedCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                PlayerJoinedResponse result;
                ResultContainer<PlayerJoinedResponse>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    
                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Matchmaker/PlayerJoined", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
        /// </summary>
        public static void PlayerLeft(PlayerLeftRequest request, PlayerLeftCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                PlayerLeftResponse result;
                ResultContainer<PlayerLeftResponse>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    
                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Matchmaker/PlayerLeft", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
        /// </summary>
        public static void StartGame(StartGameRequest request, StartGameCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                StartGameResponse result;
                ResultContainer<StartGameResponse>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    
                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Matchmaker/StartGame", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user, which the external match-making service can then use to compute effective matches
        /// </summary>
        public static void UserInfo(UserInfoRequest request, UserInfoCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UserInfoResponse result;
                ResultContainer<UserInfoResponse>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    
                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Matchmaker/UserInfo", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }


    }
}
