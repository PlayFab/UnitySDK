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
        public delegate void ProcessApiCallback<in TResult>(TResult result) where TResult : PlayFabResultCommon;

        /// <summary>
        /// Validates a user with the PlayFab service
        /// </summary>
        public static void AuthUser(AuthUserRequest request, ProcessApiCallback<AuthUserResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<AuthUserResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Matchmaker/AuthUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
        /// </summary>
        public static void PlayerJoined(PlayerJoinedRequest request, ProcessApiCallback<PlayerJoinedResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<PlayerJoinedResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Matchmaker/PlayerJoined", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
        /// </summary>
        public static void PlayerLeft(PlayerLeftRequest request, ProcessApiCallback<PlayerLeftResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<PlayerLeftResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Matchmaker/PlayerLeft", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
        /// </summary>
        public static void StartGame(StartGameRequest request, ProcessApiCallback<StartGameResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<StartGameResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Matchmaker/StartGame", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user, which the external match-making service can then use to compute effective matches
        /// </summary>
        public static void UserInfo(UserInfoRequest request, ProcessApiCallback<UserInfoResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UserInfoResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Matchmaker/UserInfo", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }


    }
}
