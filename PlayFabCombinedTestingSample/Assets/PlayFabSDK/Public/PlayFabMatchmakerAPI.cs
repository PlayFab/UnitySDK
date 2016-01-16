using System;
using PlayFab.Json;
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
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                AuthUserResponse result = ResultContainer<AuthUserResponse>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Matchmaker/AuthUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
        /// </summary>
        public static void PlayerJoined(PlayerJoinedRequest request, PlayerJoinedCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                PlayerJoinedResponse result = ResultContainer<PlayerJoinedResponse>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Matchmaker/PlayerJoined", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
        /// </summary>
        public static void PlayerLeft(PlayerLeftRequest request, PlayerLeftCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                PlayerLeftResponse result = ResultContainer<PlayerLeftResponse>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Matchmaker/PlayerLeft", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
        /// </summary>
        public static void StartGame(StartGameRequest request, StartGameCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                StartGameResponse result = ResultContainer<StartGameResponse>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Matchmaker/StartGame", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user, which the external match-making service can then use to compute effective matches
        /// </summary>
        public static void UserInfo(UserInfoRequest request, UserInfoCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UserInfoResponse result = ResultContainer<UserInfoResponse>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Matchmaker/UserInfo", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }


    }
}
