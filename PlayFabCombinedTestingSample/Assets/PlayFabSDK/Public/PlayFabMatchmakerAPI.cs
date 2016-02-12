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

        public delegate void AuthUserRequestCallback(string urlPath, int callId, AuthUserRequest request, object customData);
        public delegate void AuthUserResponseCallback(string urlPath, int callId, AuthUserRequest request, AuthUserResponse result, PlayFabError error, object customData);
        public delegate void PlayerJoinedRequestCallback(string urlPath, int callId, PlayerJoinedRequest request, object customData);
        public delegate void PlayerJoinedResponseCallback(string urlPath, int callId, PlayerJoinedRequest request, PlayerJoinedResponse result, PlayFabError error, object customData);
        public delegate void PlayerLeftRequestCallback(string urlPath, int callId, PlayerLeftRequest request, object customData);
        public delegate void PlayerLeftResponseCallback(string urlPath, int callId, PlayerLeftRequest request, PlayerLeftResponse result, PlayFabError error, object customData);
        public delegate void StartGameRequestCallback(string urlPath, int callId, StartGameRequest request, object customData);
        public delegate void StartGameResponseCallback(string urlPath, int callId, StartGameRequest request, StartGameResponse result, PlayFabError error, object customData);
        public delegate void UserInfoRequestCallback(string urlPath, int callId, UserInfoRequest request, object customData);
        public delegate void UserInfoResponseCallback(string urlPath, int callId, UserInfoRequest request, UserInfoResponse result, PlayFabError error, object customData);

        /// <summary>
        /// Validates a user with the PlayFab service
        /// </summary>
        public static void AuthUser(AuthUserRequest request, ProcessApiCallback<AuthUserResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
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

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
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

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
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

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
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

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UserInfoResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Matchmaker/UserInfo", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }


    }
}
