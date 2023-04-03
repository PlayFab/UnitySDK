#if ENABLE_PLAYFABSERVER_API && !DISABLE_PLAYFAB_STATIC_API

using System;
using System.Collections.Generic;
using PlayFab.ServerModels;
using PlayFab.Internal;

namespace PlayFab
{
    /// <summary>
    /// Provides functionality to allow external (developer-controlled) servers to interact with user inventories and data in a
    /// trusted manner, and to handle matchmaking and client connection orchestration
    /// </summary>
    public static class PlayFabServerAPI
    {
        static PlayFabServerAPI() {}


        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabSettings.staticPlayer.ForgetAllCredentials();
        }

        /// <summary>
        /// Increments the character's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void AddCharacterVirtualCurrency(AddCharacterVirtualCurrencyRequest request, Action<ModifyCharacterVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/AddCharacterVirtualCurrency", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds the Friend user to the friendlist of the user with PlayFabId. At least one of
        /// FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName should be initialized.
        /// </summary>
        public static void AddFriend(AddFriendRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/AddFriend", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds the specified generic service identifier to the player's PlayFab account. This is designed to allow for a PlayFab
        /// ID lookup of any arbitrary service identifier a title wants to add. This identifier should never be used as
        /// authentication credentials, as the intent is that it is easily accessible by other players.
        /// </summary>
        public static void AddGenericID(AddGenericIDRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/AddGenericID", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds a given tag to a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        public static void AddPlayerTag(AddPlayerTagRequest request, Action<AddPlayerTagResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/AddPlayerTag", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users
        /// in the group (and the server) can add new members. Shared Groups are designed for sharing data between a very small
        /// number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static void AddSharedGroupMembers(AddSharedGroupMembersRequest request, Action<AddSharedGroupMembersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/AddSharedGroupMembers", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Increments the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, Action<ModifyUserVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/AddUserVirtualCurrency", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Validated a client's session ticket, and if successful, returns details for that user
        /// </summary>
        public static void AuthenticateSessionTicket(AuthenticateSessionTicketRequest request, Action<AuthenticateSessionTicketResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/AuthenticateSessionTicket", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Awards the specified users the specified Steam achievements
        /// </summary>
        public static void AwardSteamAchievement(AwardSteamAchievementRequest request, Action<AwardSteamAchievementResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/AwardSteamAchievement", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Bans users by PlayFab ID with optional IP address, or MAC address for the provided game.
        /// </summary>
        public static void BanUsers(BanUsersRequest request, Action<BanUsersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/BanUsers", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
        /// </summary>
        public static void ConsumeItem(ConsumeItemRequest request, Action<ConsumeItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/ConsumeItem", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the
        /// group. When created by a server, the group will initially have no members. Shared Groups are designed for sharing data
        /// between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static void CreateSharedGroup(CreateSharedGroupRequest request, Action<CreateSharedGroupResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/CreateSharedGroup", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Deletes the specific character ID from the specified user.
        /// </summary>
        public static void DeleteCharacterFromUser(DeleteCharacterFromUserRequest request, Action<DeleteCharacterFromUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/DeleteCharacterFromUser", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Removes a user's player account from a title and deletes all associated data
        /// </summary>
        public static void DeletePlayer(DeletePlayerRequest request, Action<DeletePlayerResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/DeletePlayer", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Deletes push notification template for title
        /// </summary>
        public static void DeletePushNotificationTemplate(DeletePushNotificationTemplateRequest request, Action<DeletePushNotificationTemplateResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/DeletePushNotificationTemplate", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Deletes a shared group, freeing up the shared group ID to be reused for a new group. Shared Groups are designed for
        /// sharing data between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static void DeleteSharedGroup(DeleteSharedGroupRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/DeleteSharedGroup", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Inform the matchmaker that a Game Server Instance is removed.
        /// </summary>
        [Obsolete("No longer available", false)]
        public static void DeregisterGame(DeregisterGameRequest request, Action<DeregisterGameResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/DeregisterGame", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Returns the result of an evaluation of a Random Result Table - the ItemId from the game Catalog which would have been
        /// added to the player inventory, if the Random Result Table were added via a Bundle or a call to UnlockContainer.
        /// </summary>
        public static void EvaluateRandomResultTable(EvaluateRandomResultTableRequest request, Action<EvaluateRandomResultTableResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/EvaluateRandomResultTable", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' set to the PlayFab ID of the authenticated player. The
        /// PlayFab ID is the entity ID of the player's master_player_account entity.
        /// </summary>
        public static void ExecuteCloudScript(ExecuteCloudScriptServerRequest request, Action<ExecuteCloudScriptResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/ExecuteCloudScript", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        public static void ExecuteCloudScript<TOut>(ExecuteCloudScriptServerRequest request, Action<ExecuteCloudScriptResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method");
            Action<ExecuteCloudScriptResult> wrappedResultCallback = (wrappedResult) =>
            {
                var serializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
                var wrappedJson = serializer.SerializeObject(wrappedResult.FunctionResult);
                try {
                    wrappedResult.FunctionResult = serializer.DeserializeObject<TOut>(wrappedJson);
                } catch (Exception) {
                    wrappedResult.FunctionResult = wrappedJson;
                    wrappedResult.Logs.Add(new LogStatement { Level = "Warning", Data = wrappedJson, Message = "Sdk Message: Could not deserialize result as: " + typeof(TOut).Name });
                }
                resultCallback(wrappedResult);
            };
            PlayFabHttp.MakeApiCall("/Server/ExecuteCloudScript", request, AuthType.DevSecretKey, wrappedResultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves an array of player segment definitions. Results from this can be used in subsequent API calls such as
        /// GetPlayersInSegment which requires a Segment ID. While segment names can change the ID for that segment will not change.
        /// </summary>
        public static void GetAllSegments(GetAllSegmentsRequest request, Action<GetAllSegmentsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetAllSegments", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be
        /// evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public static void GetAllUsersCharacters(ListUsersCharactersRequest request, Action<ListUsersCharactersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetAllUsersCharacters", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static void GetCatalogItems(GetCatalogItemsRequest request, Action<GetCatalogItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetCatalogItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetCharacterData(GetCharacterDataRequest request, Action<GetCharacterDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetCharacterData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
        /// </summary>
        public static void GetCharacterInternalData(GetCharacterDataRequest request, Action<GetCharacterDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetCharacterInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the specified character's current inventory of virtual goods
        /// </summary>
        public static void GetCharacterInventory(GetCharacterInventoryRequest request, Action<GetCharacterInventoryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetCharacterInventory", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetCharacterLeaderboard(GetCharacterLeaderboardRequest request, Action<GetCharacterLeaderboardResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetCharacterLeaderboard", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        public static void GetCharacterReadOnlyData(GetCharacterDataRequest request, Action<GetCharacterDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetCharacterReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the specific character
        /// </summary>
        public static void GetCharacterStatistics(GetCharacterStatisticsRequest request, Action<GetCharacterStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetCharacterStatistics", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent HTTP GET to the returned
        /// URL will attempt to download the content. A HEAD query to the returned URL will attempt to retrieve the metadata of the
        /// content. Note that a successful result does not guarantee the existence of this content - if it has not been uploaded,
        /// the query to retrieve the data will fail. See this post for more information:
        /// https://community.playfab.com/hc/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service. Also,
        /// please be aware that the Content service is specifically PlayFab's CDN offering, for which standard CDN rates apply.
        /// </summary>
        public static void GetContentDownloadUrl(GetContentDownloadUrlRequest request, Action<GetContentDownloadUrlResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetContentDownloadUrl", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves a list of ranked friends of the given player for the given statistic, starting from the indicated point in the
        /// leaderboard
        /// </summary>
        public static void GetFriendLeaderboard(GetFriendLeaderboardRequest request, Action<GetLeaderboardResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetFriendLeaderboard", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the current friends for the user with PlayFabId, constrained to users who have PlayFab accounts. Friends from
        /// linked accounts (Facebook, Steam) are also included. You may optionally exclude some linked services' friends.
        /// </summary>
        public static void GetFriendsList(GetFriendsListRequest request, Action<GetFriendsListResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetFriendsList", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetLeaderboard(GetLeaderboardRequest request, Action<GetLeaderboardResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetLeaderboard", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, centered on the requested user
        /// </summary>
        public static void GetLeaderboardAroundCharacter(GetLeaderboardAroundCharacterRequest request, Action<GetLeaderboardAroundCharacterResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetLeaderboardAroundCharacter", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
        /// </summary>
        public static void GetLeaderboardAroundUser(GetLeaderboardAroundUserRequest request, Action<GetLeaderboardAroundUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetLeaderboardAroundUser", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves a list of all of the user's characters for the given statistic.
        /// </summary>
        public static void GetLeaderboardForUserCharacters(GetLeaderboardForUsersCharactersRequest request, Action<GetLeaderboardForUsersCharactersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetLeaderboardForUserCharacters", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Returns whatever info is requested in the response for the user. Note that PII (like email address, facebook id) may be
        /// returned. All parameters default to false.
        /// </summary>
        public static void GetPlayerCombinedInfo(GetPlayerCombinedInfoRequest request, Action<GetPlayerCombinedInfoResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayerCombinedInfo", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the player's profile
        /// </summary>
        public static void GetPlayerProfile(GetPlayerProfileRequest request, Action<GetPlayerProfileResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayerProfile", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// List all segments that a player currently belongs to at this moment in time.
        /// </summary>
        public static void GetPlayerSegments(GetPlayersSegmentsRequest request, Action<GetPlayerSegmentsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayerSegments", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Allows for paging through all players in a given segment. This API creates a snapshot of all player profiles that match
        /// the segment definition at the time of its creation and lives through the Total Seconds to Live, refreshing its life span
        /// on each subsequent use of the Continuation Token. Profiles that change during the course of paging will not be reflected
        /// in the results. AB Test segments are currently not supported by this operation. NOTE: This API is limited to being
        /// called 30 times in one minute. You will be returned an error if you exceed this threshold.
        /// </summary>
        public static void GetPlayersInSegment(GetPlayersInSegmentRequest request, Action<GetPlayersInSegmentResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayersInSegment", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the current version and values for the indicated statistics, for the local player.
        /// </summary>
        public static void GetPlayerStatistics(GetPlayerStatisticsRequest request, Action<GetPlayerStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayerStatistics", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        public static void GetPlayerStatisticVersions(GetPlayerStatisticVersionsRequest request, Action<GetPlayerStatisticVersionsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayerStatisticVersions", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Get all tags with a given Namespace (optional) from a player profile.
        /// </summary>
        public static void GetPlayerTags(GetPlayerTagsRequest request, Action<GetPlayerTagsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayerTags", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        public static void GetPlayFabIDsFromFacebookIDs(GetPlayFabIDsFromFacebookIDsRequest request, Action<GetPlayFabIDsFromFacebookIDsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayFabIDsFromFacebookIDs", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook Instant Games identifiers.
        /// </summary>
        public static void GetPlayFabIDsFromFacebookInstantGamesIds(GetPlayFabIDsFromFacebookInstantGamesIdsRequest request, Action<GetPlayFabIDsFromFacebookInstantGamesIdsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayFabIDsFromFacebookInstantGamesIds", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of generic service identifiers. A generic identifier is the
        /// service name plus the service-specific ID for the player, as specified by the title when the generic identifier was
        /// added to the player account.
        /// </summary>
        public static void GetPlayFabIDsFromGenericIDs(GetPlayFabIDsFromGenericIDsRequest request, Action<GetPlayFabIDsFromGenericIDsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayFabIDsFromGenericIDs", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Service Account identifiers.
        /// </summary>
        public static void GetPlayFabIDsFromNintendoServiceAccountIds(GetPlayFabIDsFromNintendoServiceAccountIdsRequest request, Action<GetPlayFabIDsFromNintendoServiceAccountIdsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayFabIDsFromNintendoServiceAccountIds", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Nintendo Switch Device identifiers.
        /// </summary>
        public static void GetPlayFabIDsFromNintendoSwitchDeviceIds(GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest request, Action<GetPlayFabIDsFromNintendoSwitchDeviceIdsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayFabIDsFromNintendoSwitchDeviceIds", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation :tm: Network identifiers.
        /// </summary>
        public static void GetPlayFabIDsFromPSNAccountIDs(GetPlayFabIDsFromPSNAccountIDsRequest request, Action<GetPlayFabIDsFromPSNAccountIDsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayFabIDsFromPSNAccountIDs", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers are the profile
        /// IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        public static void GetPlayFabIDsFromSteamIDs(GetPlayFabIDsFromSteamIDsRequest request, Action<GetPlayFabIDsFromSteamIDsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayFabIDsFromSteamIDs", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Twitch identifiers. The Twitch identifiers are the IDs for
        /// the user accounts, available as "_id" from the Twitch API methods (ex:
        /// https://github.com/justintv/Twitch-API/blob/master/v3_resources/users.md#get-usersuser).
        /// </summary>
        public static void GetPlayFabIDsFromTwitchIDs(GetPlayFabIDsFromTwitchIDsRequest request, Action<GetPlayFabIDsFromTwitchIDsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayFabIDsFromTwitchIDs", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of XboxLive identifiers.
        /// </summary>
        public static void GetPlayFabIDsFromXboxLiveIDs(GetPlayFabIDsFromXboxLiveIDsRequest request, Action<GetPlayFabIDsFromXboxLiveIDsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPlayFabIDsFromXboxLiveIDs", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public static void GetPublisherData(GetPublisherDataRequest request, Action<GetPublisherDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetPublisherData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the configuration information for the specified random results tables for the title, including all ItemId
        /// values and weights
        /// </summary>
        public static void GetRandomResultTables(GetRandomResultTablesRequest request, Action<GetRandomResultTablesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetRandomResultTables", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the associated PlayFab account identifiers for the given set of server custom identifiers.
        /// </summary>
        public static void GetServerCustomIDsFromPlayFabIDs(GetServerCustomIDsFromPlayFabIDsRequest request, Action<GetServerCustomIDsFromPlayFabIDsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetServerCustomIDsFromPlayFabIDs", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all
        /// public and private group data. Shared Groups are designed for sharing data between a very small number of players,
        /// please see our guide: https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static void GetSharedGroupData(GetSharedGroupDataRequest request, Action<GetSharedGroupDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetSharedGroupData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the set of items defined for the specified store, including all prices defined, for the specified player
        /// </summary>
        public static void GetStoreItems(GetStoreItemsServerRequest request, Action<GetStoreItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetStoreItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the current server time
        /// </summary>
        public static void GetTime(GetTimeRequest request, Action<GetTimeResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetTime", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        public static void GetTitleData(GetTitleDataRequest request, Action<GetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetTitleData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the key-value store of custom internal title settings
        /// </summary>
        public static void GetTitleInternalData(GetTitleDataRequest request, Action<GetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetTitleInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        public static void GetTitleNews(GetTitleNewsRequest request, Action<GetTitleNewsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetTitleNews", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user
        /// </summary>
        public static void GetUserAccountInfo(GetUserAccountInfoRequest request, Action<GetUserAccountInfoResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetUserAccountInfo", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Gets all bans for a user.
        /// </summary>
        public static void GetUserBans(GetUserBansRequest request, Action<GetUserBansResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetUserBans", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetUserData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserInternalData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetUserInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        public static void GetUserInventory(GetUserInventoryRequest request, Action<GetUserInventoryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetUserInventory", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserPublisherData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetUserPublisherData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserPublisherInternalData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetUserPublisherInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserPublisherReadOnlyData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetUserPublisherReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserReadOnlyData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GetUserReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated
        /// with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public static void GrantCharacterToUser(GrantCharacterToUserRequest request, Action<GrantCharacterToUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GrantCharacterToUser", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds the specified items to the specified character's inventory
        /// </summary>
        public static void GrantItemsToCharacter(GrantItemsToCharacterRequest request, Action<GrantItemsToCharacterResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GrantItemsToCharacter", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds the specified items to the specified user's inventory
        /// </summary>
        public static void GrantItemsToUser(GrantItemsToUserRequest request, Action<GrantItemsToUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GrantItemsToUser", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds the specified items to the specified user inventories
        /// </summary>
        public static void GrantItemsToUsers(GrantItemsToUsersRequest request, Action<GrantItemsToUsersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/GrantItemsToUsers", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Links the Nintendo account associated with the token to the user's PlayFab account
        /// </summary>
        public static void LinkNintendoServiceAccount(LinkNintendoServiceAccountRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/LinkNintendoServiceAccount", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Links the NintendoSwitchDeviceId to the user's PlayFab account
        /// </summary>
        public static void LinkNintendoSwitchDeviceId(LinkNintendoSwitchDeviceIdRequest request, Action<LinkNintendoSwitchDeviceIdResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/LinkNintendoSwitchDeviceId", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Links the PlayStation :tm: Network account associated with the provided access code to the user's PlayFab account
        /// </summary>
        public static void LinkPSNAccount(LinkPSNAccountRequest request, Action<LinkPSNAccountResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/LinkPSNAccount", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Links the custom server identifier, generated by the title, to the user's PlayFab account.
        /// </summary>
        public static void LinkServerCustomId(LinkServerCustomIdRequest request, Action<LinkServerCustomIdResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/LinkServerCustomId", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Links the Steam account associated with the provided Steam ID to the user's PlayFab account
        /// </summary>
        public static void LinkSteamId(LinkSteamIdRequest request, Action<LinkSteamIdResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/LinkSteamId", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Links the Xbox Live account associated with the provided access code to the user's PlayFab account
        /// </summary>
        public static void LinkXboxAccount(LinkXboxAccountRequest request, Action<LinkXboxAccountResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/LinkXboxAccount", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Securely login a game client from an external server backend using a custom identifier for that player. Server Custom ID
        /// and Client Custom ID are mutually exclusive and cannot be used to retrieve the same player account.
        /// </summary>
        public static void LoginWithServerCustomId(LoginWithServerCustomIdRequest request, Action<ServerLoginResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/LoginWithServerCustomId", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Signs the user in using an Steam ID, returning a session identifier that can subsequently be used for API calls which
        /// require an authenticated user
        /// </summary>
        public static void LoginWithSteamId(LoginWithSteamIdRequest request, Action<ServerLoginResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/LoginWithSteamId", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Signs the user in using a Xbox Live Token from an external server backend, returning a session identifier that can
        /// subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithXbox(LoginWithXboxRequest request, Action<ServerLoginResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/LoginWithXbox", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Signs the user in using an Xbox ID and Sandbox ID, returning a session identifier that can subsequently be used for API
        /// calls which require an authenticated user
        /// </summary>
        public static void LoginWithXboxId(LoginWithXboxIdRequest request, Action<ServerLoginResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/LoginWithXboxId", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Modifies the number of remaining uses of a player's inventory item
        /// </summary>
        public static void ModifyItemUses(ModifyItemUsesRequest request, Action<ModifyItemUsesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/ModifyItemUses", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Moves an item from a character's inventory into another of the users's character's inventory.
        /// </summary>
        public static void MoveItemToCharacterFromCharacter(MoveItemToCharacterFromCharacterRequest request, Action<MoveItemToCharacterFromCharacterResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/MoveItemToCharacterFromCharacter", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Moves an item from a user's inventory into their character's inventory.
        /// </summary>
        public static void MoveItemToCharacterFromUser(MoveItemToCharacterFromUserRequest request, Action<MoveItemToCharacterFromUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/MoveItemToCharacterFromUser", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Moves an item from a character's inventory into the owning user's inventory.
        /// </summary>
        public static void MoveItemToUserFromCharacter(MoveItemToUserFromCharacterRequest request, Action<MoveItemToUserFromCharacterResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/MoveItemToUserFromCharacter", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Informs the PlayFab match-making service that the user specified has left the Game Server Instance
        /// </summary>
        [Obsolete("No longer available", false)]
        public static void NotifyMatchmakerPlayerLeft(NotifyMatchmakerPlayerLeftRequest request, Action<NotifyMatchmakerPlayerLeftResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/NotifyMatchmakerPlayerLeft", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated via the
        /// Economy->Catalogs tab in the PlayFab Game Manager.
        /// </summary>
        public static void RedeemCoupon(RedeemCouponRequest request, Action<RedeemCouponResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/RedeemCoupon", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Validates a Game Server session ticket and returns details about the user
        /// </summary>
        [Obsolete("No longer available", false)]
        public static void RedeemMatchmakerTicket(RedeemMatchmakerTicketRequest request, Action<RedeemMatchmakerTicketResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/RedeemMatchmakerTicket", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Set the state of the indicated Game Server Instance. Also update the heartbeat for the instance.
        /// </summary>
        [Obsolete("No longer available", false)]
        public static void RefreshGameServerInstanceHeartbeat(RefreshGameServerInstanceHeartbeatRequest request, Action<RefreshGameServerInstanceHeartbeatResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/RefreshGameServerInstanceHeartbeat", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Inform the matchmaker that a new Game Server Instance is added.
        /// </summary>
        [Obsolete("No longer available", false)]
        public static void RegisterGame(RegisterGameRequest request, Action<RegisterGameResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/RegisterGame", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Removes the specified friend from the the user's friend list
        /// </summary>
        public static void RemoveFriend(RemoveFriendRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/RemoveFriend", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Removes the specified generic service identifier from the player's PlayFab account.
        /// </summary>
        public static void RemoveGenericID(RemoveGenericIDRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/RemoveGenericID", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Remove a given tag from a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        public static void RemovePlayerTag(RemovePlayerTagRequest request, Action<RemovePlayerTagResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/RemovePlayerTag", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the
        /// group can remove members. If as a result of the call, zero users remain with access, the group and its associated data
        /// will be deleted. Shared Groups are designed for sharing data between a very small number of players, please see our
        /// guide: https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static void RemoveSharedGroupMembers(RemoveSharedGroupMembersRequest request, Action<RemoveSharedGroupMembersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/RemoveSharedGroupMembers", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service
        /// representatives for the title can take action concerning potentially toxic players.
        /// </summary>
        public static void ReportPlayer(ReportPlayerServerRequest request, Action<ReportPlayerServerResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/ReportPlayer", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Revoke all active bans for a user.
        /// </summary>
        public static void RevokeAllBansForUser(RevokeAllBansForUserRequest request, Action<RevokeAllBansForUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/RevokeAllBansForUser", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Revoke all active bans specified with BanId.
        /// </summary>
        public static void RevokeBans(RevokeBansRequest request, Action<RevokeBansResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/RevokeBans", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Revokes access to an item in a user's inventory
        /// </summary>
        public static void RevokeInventoryItem(RevokeInventoryItemRequest request, Action<RevokeInventoryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/RevokeInventoryItem", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Revokes access for up to 25 items across multiple users and characters.
        /// </summary>
        public static void RevokeInventoryItems(RevokeInventoryItemsRequest request, Action<RevokeInventoryItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/RevokeInventoryItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Saves push notification template for title
        /// </summary>
        public static void SavePushNotificationTemplate(SavePushNotificationTemplateRequest request, Action<SavePushNotificationTemplateResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SavePushNotificationTemplate", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Forces an email to be sent to the registered contact email address for the user's account based on an account recovery
        /// email template
        /// </summary>
        public static void SendCustomAccountRecoveryEmail(SendCustomAccountRecoveryEmailRequest request, Action<SendCustomAccountRecoveryEmailResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SendCustomAccountRecoveryEmail", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Sends an email based on an email template to a player's contact email
        /// </summary>
        public static void SendEmailFromTemplate(SendEmailFromTemplateRequest request, Action<SendEmailFromTemplateResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SendEmailFromTemplate", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push
        /// Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
        /// </summary>
        public static void SendPushNotification(SendPushNotificationRequest request, Action<SendPushNotificationResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SendPushNotification", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Sends an iOS/Android Push Notification template to a specific user, if that user's device has been configured for Push
        /// Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
        /// </summary>
        public static void SendPushNotificationFromTemplate(SendPushNotificationFromTemplateRequest request, Action<SendPushNotificationResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SendPushNotificationFromTemplate", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the tag list for a specified user in the friend list of another user
        /// </summary>
        public static void SetFriendTags(SetFriendTagsRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SetFriendTags", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Sets the custom data of the indicated Game Server Instance
        /// </summary>
        [Obsolete("No longer available", false)]
        public static void SetGameServerInstanceData(SetGameServerInstanceDataRequest request, Action<SetGameServerInstanceDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SetGameServerInstanceData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Set the state of the indicated Game Server Instance.
        /// </summary>
        [Obsolete("No longer available", false)]
        public static void SetGameServerInstanceState(SetGameServerInstanceStateRequest request, Action<SetGameServerInstanceStateResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SetGameServerInstanceState", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Set custom tags for the specified Game Server Instance
        /// </summary>
        [Obsolete("No longer available", false)]
        public static void SetGameServerInstanceTags(SetGameServerInstanceTagsRequest request, Action<SetGameServerInstanceTagsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SetGameServerInstanceTags", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Sets the player's secret if it is not already set. Player secrets are used to sign API requests. To reset a player's
        /// secret use the Admin or Server API method SetPlayerSecret.
        /// </summary>
        public static void SetPlayerSecret(SetPlayerSecretRequest request, Action<SetPlayerSecretResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SetPlayerSecret", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        public static void SetPublisherData(SetPublisherDataRequest request, Action<SetPublisherDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SetPublisherData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        public static void SetTitleData(SetTitleDataRequest request, Action<SetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SetTitleData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        public static void SetTitleInternalData(SetTitleDataRequest request, Action<SetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SetTitleInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Decrements the character's balance of the specified virtual currency by the stated amount. It is possible to make a VC
        /// balance negative with this API.
        /// </summary>
        public static void SubtractCharacterVirtualCurrency(SubtractCharacterVirtualCurrencyRequest request, Action<ModifyCharacterVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SubtractCharacterVirtualCurrency", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Decrements the user's balance of the specified virtual currency by the stated amount. It is possible to make a VC
        /// balance negative with this API.
        /// </summary>
        public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, Action<ModifyUserVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/SubtractUserVirtualCurrency", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Unlinks the related Nintendo account from the user's PlayFab account
        /// </summary>
        public static void UnlinkNintendoServiceAccount(UnlinkNintendoServiceAccountRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UnlinkNintendoServiceAccount", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Unlinks the related NintendoSwitchDeviceId from the user's PlayFab account
        /// </summary>
        public static void UnlinkNintendoSwitchDeviceId(UnlinkNintendoSwitchDeviceIdRequest request, Action<UnlinkNintendoSwitchDeviceIdResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UnlinkNintendoSwitchDeviceId", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Unlinks the related PlayStation :tm: Network account from the user's PlayFab account
        /// </summary>
        public static void UnlinkPSNAccount(UnlinkPSNAccountRequest request, Action<UnlinkPSNAccountResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UnlinkPSNAccount", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Unlinks the custom server identifier from the user's PlayFab account.
        /// </summary>
        public static void UnlinkServerCustomId(UnlinkServerCustomIdRequest request, Action<UnlinkServerCustomIdResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UnlinkServerCustomId", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Unlinks the Steam account associated with the provided Steam ID to the user's PlayFab account
        /// </summary>
        public static void UnlinkSteamId(UnlinkSteamIdRequest request, Action<UnlinkSteamIdResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UnlinkSteamId", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Unlinks the related Xbox Live account from the user's PlayFab account
        /// </summary>
        public static void UnlinkXboxAccount(UnlinkXboxAccountRequest request, Action<UnlinkXboxAccountResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UnlinkXboxAccount", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when required), and
        /// returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses >
        /// 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        public static void UnlockContainerInstance(UnlockContainerInstanceRequest request, Action<UnlockContainerItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UnlockContainerInstance", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary unlocks it
        /// using any appropriate key, and returns the contents of the opened container. If the container (and key when relevant)
        /// are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of
        /// ConsumeItem.
        /// </summary>
        public static void UnlockContainerItem(UnlockContainerItemRequest request, Action<UnlockContainerItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UnlockContainerItem", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Update the avatar URL of the specified player
        /// </summary>
        public static void UpdateAvatarUrl(UpdateAvatarUrlRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateAvatarUrl", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates information of a list of existing bans specified with Ban Ids.
        /// </summary>
        public static void UpdateBans(UpdateBansRequest request, Action<UpdateBansResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateBans", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's character which is readable and writable by the client
        /// </summary>
        public static void UpdateCharacterData(UpdateCharacterDataRequest request, Action<UpdateCharacterDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateCharacterData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's character which cannot be accessed by the client
        /// </summary>
        public static void UpdateCharacterInternalData(UpdateCharacterDataRequest request, Action<UpdateCharacterDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateCharacterInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        public static void UpdateCharacterReadOnlyData(UpdateCharacterDataRequest request, Action<UpdateCharacterDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateCharacterReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the specific character
        /// </summary>
        public static void UpdateCharacterStatistics(UpdateCharacterStatisticsRequest request, Action<UpdateCharacterStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateCharacterStatistics", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user
        /// </summary>
        public static void UpdatePlayerStatistics(UpdatePlayerStatisticsRequest request, Action<UpdatePlayerStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdatePlayerStatistics", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated
        /// or added in this call will be readable by users not in the group. By default, data permissions are set to Private.
        /// Regardless of the permission setting, only members of the group (and the server) can update the data. Shared Groups are
        /// designed for sharing data between a very small number of players, please see our guide:
        /// https://docs.microsoft.com/gaming/playfab/features/social/groups/using-shared-group-data
        /// </summary>
        public static void UpdateSharedGroupData(UpdateSharedGroupDataRequest request, Action<UpdateSharedGroupDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateSharedGroupData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateUserData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserInternalData(UpdateUserInternalDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateUserInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the key-value pair data tagged to the specified item, which is read-only from the client.
        /// </summary>
        public static void UpdateUserInventoryItemCustomData(UpdateUserInventoryItemDataRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateUserInventoryItemCustomData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserPublisherData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateUserPublisherData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserPublisherInternalData(UpdateUserInternalDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateUserPublisherInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserPublisherReadOnlyData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateUserPublisherReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserReadOnlyData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/UpdateUserReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Writes a character-based event into PlayStream.
        /// </summary>
        public static void WriteCharacterEvent(WriteServerCharacterEventRequest request, Action<WriteEventResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/WriteCharacterEvent", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Writes a player-based event into PlayStream.
        /// </summary>
        public static void WritePlayerEvent(WriteServerPlayerEventRequest request, Action<WriteEventResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/WritePlayerEvent", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Writes a title-based event into PlayStream.
        /// </summary>
        public static void WriteTitleEvent(WriteTitleEventRequest request, Action<WriteEventResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Server/WriteTitleEvent", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }


    }
}

#endif
