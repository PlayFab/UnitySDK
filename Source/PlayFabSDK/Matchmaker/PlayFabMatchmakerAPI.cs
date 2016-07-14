#if ENABLE_PLAYFABSERVER_API
using System;
using PlayFab.MatchmakerModels;
using PlayFab.Internal;
using UnityEngine;

namespace PlayFab
{
    /// <summary>
    /// Enables the use of an external match-making service in conjunction with PlayFab hosted Game Server instances
    /// </summary>
    public static class PlayFabMatchmakerAPI
    {

        /// <summary>
        /// Validates a user with the PlayFab service
        /// </summary>
        public static void AuthUser(AuthUserRequest request, Action<AuthUserResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<AuthUserRequest, AuthUserResponse>("Matchmaker", "/Matchmaker/AuthUser", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
        /// </summary>
        public static void PlayerJoined(PlayerJoinedRequest request, Action<PlayerJoinedResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<PlayerJoinedRequest, PlayerJoinedResponse>("Matchmaker", "/Matchmaker/PlayerJoined", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
        /// </summary>
        public static void PlayerLeft(PlayerLeftRequest request, Action<PlayerLeftResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<PlayerLeftRequest, PlayerLeftResponse>("Matchmaker", "/Matchmaker/PlayerLeft", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
        /// </summary>
        public static void StartGame(StartGameRequest request, Action<StartGameResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<StartGameRequest, StartGameResponse>("Matchmaker", "/Matchmaker/StartGame", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user, which the external match-making service can then use to compute effective matches
        /// </summary>
        public static void UserInfo(UserInfoRequest request, Action<UserInfoResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UserInfoRequest, UserInfoResponse>("Matchmaker", "/Matchmaker/UserInfo", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }


    }
}
#endif
