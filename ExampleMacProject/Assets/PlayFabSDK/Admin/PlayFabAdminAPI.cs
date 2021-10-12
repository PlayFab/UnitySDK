#if ENABLE_PLAYFABADMIN_API && !DISABLE_PLAYFAB_STATIC_API

using System;
using System.Collections.Generic;
using PlayFab.AdminModels;
using PlayFab.Internal;

namespace PlayFab
{
    /// <summary>
    /// APIs for managing title configurations, uploaded Game Server code executables, and user data
    /// </summary>
    public static class PlayFabAdminAPI
    {
        static PlayFabAdminAPI() {}


        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabSettings.staticPlayer.ForgetAllCredentials();
        }

        /// <summary>
        /// Abort an ongoing task instance.
        /// </summary>
        public static void AbortTaskInstance(AbortTaskInstanceRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/AbortTaskInstance", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Update news item to include localized version
        /// </summary>
        public static void AddLocalizedNews(AddLocalizedNewsRequest request, Action<AddLocalizedNewsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/AddLocalizedNews", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds a new news item to the title's news feed
        /// </summary>
        public static void AddNews(AddNewsRequest request, Action<AddNewsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/AddNews", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds a given tag to a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        public static void AddPlayerTag(AddPlayerTagRequest request, Action<AddPlayerTagResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/AddPlayerTag", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds the game server executable specified (previously uploaded - see GetServerBuildUploadUrl) to the set of those a
        /// client is permitted to request in a call to StartGame
        /// </summary>
        public static void AddServerBuild(AddServerBuildRequest request, Action<AddServerBuildResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/AddServerBuild", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Increments the specified virtual currency by the stated amount
        /// </summary>
        public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, Action<ModifyUserVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/AddUserVirtualCurrency", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds one or more virtual currencies to the set defined for the title. Virtual Currencies have a maximum value of
        /// 2,147,483,647 when granted to a player. Any value over that will be discarded.
        /// </summary>
        public static void AddVirtualCurrencyTypes(AddVirtualCurrencyTypesRequest request, Action<BlankResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/AddVirtualCurrencyTypes", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Bans users by PlayFab ID with optional IP address, or MAC address for the provided game.
        /// </summary>
        public static void BanUsers(BanUsersRequest request, Action<BanUsersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/BanUsers", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Checks the global count for the limited edition item.
        /// </summary>
        public static void CheckLimitedEditionItemAvailability(CheckLimitedEditionItemAvailabilityRequest request, Action<CheckLimitedEditionItemAvailabilityResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/CheckLimitedEditionItemAvailability", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Create an ActionsOnPlayersInSegment task, which iterates through all players in a segment to execute action.
        /// </summary>
        public static void CreateActionsOnPlayersInSegmentTask(CreateActionsOnPlayerSegmentTaskRequest request, Action<CreateTaskResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/CreateActionsOnPlayersInSegmentTask", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Create a CloudScript task, which can run a CloudScript on a schedule.
        /// </summary>
        public static void CreateCloudScriptTask(CreateCloudScriptTaskRequest request, Action<CreateTaskResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/CreateCloudScriptTask", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Create a Insights Scheduled Scaling task, which can scale Insights Performance Units on a schedule
        /// </summary>
        public static void CreateInsightsScheduledScalingTask(CreateInsightsScheduledScalingTaskRequest request, Action<CreateTaskResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/CreateInsightsScheduledScalingTask", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Registers a relationship between a title and an Open ID Connect provider.
        /// </summary>
        public static void CreateOpenIdConnection(CreateOpenIdConnectionRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/CreateOpenIdConnection", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Creates a new Player Shared Secret Key. It may take up to 5 minutes for this key to become generally available after
        /// this API returns.
        /// </summary>
        public static void CreatePlayerSharedSecret(CreatePlayerSharedSecretRequest request, Action<CreatePlayerSharedSecretResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/CreatePlayerSharedSecret", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds a new player statistic configuration to the title, optionally allowing the developer to specify a reset interval
        /// and an aggregation method.
        /// </summary>
        public static void CreatePlayerStatisticDefinition(CreatePlayerStatisticDefinitionRequest request, Action<CreatePlayerStatisticDefinitionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/CreatePlayerStatisticDefinition", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Creates a new player segment by defining the conditions on player properties. Also, create actions to target the player
        /// segments for a title.
        /// </summary>
        public static void CreateSegment(CreateSegmentRequest request, Action<CreateSegmentResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/CreateSegment", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Delete a content file from the title. When deleting a file that does not exist, it returns success.
        /// </summary>
        public static void DeleteContent(DeleteContentRequest request, Action<BlankResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/DeleteContent", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Removes a master player account entirely from all titles and deletes all associated data
        /// </summary>
        public static void DeleteMasterPlayerAccount(DeleteMasterPlayerAccountRequest request, Action<DeleteMasterPlayerAccountResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/DeleteMasterPlayerAccount", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Deletes a player's subscription
        /// </summary>
        public static void DeleteMembershipSubscription(DeleteMembershipSubscriptionRequest request, Action<DeleteMembershipSubscriptionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/DeleteMembershipSubscription", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Removes a relationship between a title and an OpenID Connect provider.
        /// </summary>
        public static void DeleteOpenIdConnection(DeleteOpenIdConnectionRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/DeleteOpenIdConnection", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Removes a user's player account from a title and deletes all associated data
        /// </summary>
        public static void DeletePlayer(DeletePlayerRequest request, Action<DeletePlayerResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/DeletePlayer", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Deletes an existing Player Shared Secret Key. It may take up to 5 minutes for this delete to be reflected after this API
        /// returns.
        /// </summary>
        public static void DeletePlayerSharedSecret(DeletePlayerSharedSecretRequest request, Action<DeletePlayerSharedSecretResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/DeletePlayerSharedSecret", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Deletes an existing player segment and its associated action(s) for a title.
        /// </summary>
        public static void DeleteSegment(DeleteSegmentRequest request, Action<DeleteSegmentsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/DeleteSegment", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Deletes an existing virtual item store
        /// </summary>
        public static void DeleteStore(DeleteStoreRequest request, Action<DeleteStoreResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/DeleteStore", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Delete a task.
        /// </summary>
        public static void DeleteTask(DeleteTaskRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/DeleteTask", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Permanently deletes a title and all associated configuration
        /// </summary>
        public static void DeleteTitle(DeleteTitleRequest request, Action<DeleteTitleResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/DeleteTitle", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Deletes a specified set of title data overrides.
        /// </summary>
        public static void DeleteTitleDataOverride(DeleteTitleDataOverrideRequest request, Action<DeleteTitleDataOverrideResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/DeleteTitleDataOverride", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Exports all associated data of a master player account
        /// </summary>
        public static void ExportMasterPlayerData(ExportMasterPlayerDataRequest request, Action<ExportMasterPlayerDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/ExportMasterPlayerData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Get information about a ActionsOnPlayersInSegment task instance.
        /// </summary>
        public static void GetActionsOnPlayersInSegmentTaskInstance(GetTaskInstanceRequest request, Action<GetActionsOnPlayersInSegmentTaskInstanceResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetActionsOnPlayersInSegmentTaskInstance", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
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


            PlayFabHttp.MakeApiCall("/Admin/GetAllSegments", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static void GetCatalogItems(GetCatalogItemsRequest request, Action<GetCatalogItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetCatalogItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Gets the contents and information of a specific Cloud Script revision.
        /// </summary>
        public static void GetCloudScriptRevision(GetCloudScriptRevisionRequest request, Action<GetCloudScriptRevisionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetCloudScriptRevision", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Get detail information about a CloudScript task instance.
        /// </summary>
        public static void GetCloudScriptTaskInstance(GetTaskInstanceRequest request, Action<GetCloudScriptTaskInstanceResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetCloudScriptTaskInstance", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Lists all the current cloud script versions. For each version, information about the current published and latest
        /// revisions is also listed.
        /// </summary>
        public static void GetCloudScriptVersions(GetCloudScriptVersionsRequest request, Action<GetCloudScriptVersionsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetCloudScriptVersions", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// List all contents of the title and get statistics such as size
        /// </summary>
        public static void GetContentList(GetContentListRequest request, Action<GetContentListResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetContentList", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the pre-signed URL for uploading a content file. A subsequent HTTP PUT to the returned URL uploads the
        /// content. Also, please be aware that the Content service is specifically PlayFab's CDN offering, for which standard CDN
        /// rates apply.
        /// </summary>
        public static void GetContentUploadUrl(GetContentUploadUrlRequest request, Action<GetContentUploadUrlResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetContentUploadUrl", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves a download URL for the requested report
        /// </summary>
        public static void GetDataReport(GetDataReportRequest request, Action<GetDataReportResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetDataReport", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the details for a specific completed session, including links to standard out and standard error logs
        /// </summary>
        public static void GetMatchmakerGameInfo(GetMatchmakerGameInfoRequest request, Action<GetMatchmakerGameInfoResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetMatchmakerGameInfo", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the details of defined game modes for the specified game server executable
        /// </summary>
        public static void GetMatchmakerGameModes(GetMatchmakerGameModesRequest request, Action<GetMatchmakerGameModesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetMatchmakerGameModes", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Get the list of titles that the player has played
        /// </summary>
        public static void GetPlayedTitleList(GetPlayedTitleListRequest request, Action<GetPlayedTitleListResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetPlayedTitleList", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Gets a player's ID from an auth token.
        /// </summary>
        public static void GetPlayerIdFromAuthToken(GetPlayerIdFromAuthTokenRequest request, Action<GetPlayerIdFromAuthTokenResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetPlayerIdFromAuthToken", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the player's profile
        /// </summary>
        public static void GetPlayerProfile(GetPlayerProfileRequest request, Action<GetPlayerProfileResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetPlayerProfile", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// List all segments that a player currently belongs to at this moment in time.
        /// </summary>
        public static void GetPlayerSegments(GetPlayersSegmentsRequest request, Action<GetPlayerSegmentsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetPlayerSegments", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Returns all Player Shared Secret Keys including disabled and expired.
        /// </summary>
        public static void GetPlayerSharedSecrets(GetPlayerSharedSecretsRequest request, Action<GetPlayerSharedSecretsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetPlayerSharedSecrets", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
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


            PlayFabHttp.MakeApiCall("/Admin/GetPlayersInSegment", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the configuration information for all player statistics defined in the title, regardless of whether they have
        /// a reset interval.
        /// </summary>
        public static void GetPlayerStatisticDefinitions(GetPlayerStatisticDefinitionsRequest request, Action<GetPlayerStatisticDefinitionsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetPlayerStatisticDefinitions", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        public static void GetPlayerStatisticVersions(GetPlayerStatisticVersionsRequest request, Action<GetPlayerStatisticVersionsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetPlayerStatisticVersions", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Get all tags with a given Namespace (optional) from a player profile.
        /// </summary>
        public static void GetPlayerTags(GetPlayerTagsRequest request, Action<GetPlayerTagsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetPlayerTags", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Gets the requested policy.
        /// </summary>
        public static void GetPolicy(GetPolicyRequest request, Action<GetPolicyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetPolicy", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public static void GetPublisherData(GetPublisherDataRequest request, Action<GetPublisherDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetPublisherData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the random drop table configuration for the title
        /// </summary>
        public static void GetRandomResultTables(GetRandomResultTablesRequest request, Action<GetRandomResultTablesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetRandomResultTables", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Get detail information of a segment and its associated definition(s) and action(s) for a title.
        /// </summary>
        public static void GetSegments(GetSegmentsRequest request, Action<GetSegmentsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetSegments", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the build details for the specified game server executable
        /// </summary>
        public static void GetServerBuildInfo(GetServerBuildInfoRequest request, Action<GetServerBuildInfoResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetServerBuildInfo", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the pre-authorized URL for uploading a game server package containing a build (does not enable the build for
        /// use - see AddServerBuild)
        /// </summary>
        public static void GetServerBuildUploadUrl(GetServerBuildUploadURLRequest request, Action<GetServerBuildUploadURLResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetServerBuildUploadUrl", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        public static void GetStoreItems(GetStoreItemsRequest request, Action<GetStoreItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetStoreItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Query for task instances by task, status, or time range.
        /// </summary>
        public static void GetTaskInstances(GetTaskInstancesRequest request, Action<GetTaskInstancesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetTaskInstances", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Get definition information on a specified task or all tasks within a title.
        /// </summary>
        public static void GetTasks(GetTasksRequest request, Action<GetTasksResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetTasks", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings which can be read by the client
        /// </summary>
        public static void GetTitleData(GetTitleDataRequest request, Action<GetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetTitleData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings which cannot be read by the client
        /// </summary>
        public static void GetTitleInternalData(GetTitleDataRequest request, Action<GetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetTitleInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user, based upon a match against a supplied unique identifier
        /// </summary>
        public static void GetUserAccountInfo(LookupUserAccountInfoRequest request, Action<LookupUserAccountInfoResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetUserAccountInfo", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Gets all bans for a user.
        /// </summary>
        public static void GetUserBans(GetUserBansRequest request, Action<GetUserBansResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetUserBans", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetUserData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserInternalData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetUserInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        public static void GetUserInventory(GetUserInventoryRequest request, Action<GetUserInventoryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetUserInventory", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserPublisherData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetUserPublisherData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserPublisherInternalData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetUserPublisherInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserPublisherReadOnlyData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetUserPublisherReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserReadOnlyData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GetUserReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Adds the specified items to the specified user inventories
        /// </summary>
        public static void GrantItemsToUsers(GrantItemsToUsersRequest request, Action<GrantItemsToUsersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/GrantItemsToUsers", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Increases the global count for the given scarce resource.
        /// </summary>
        public static void IncrementLimitedEditionItemAvailability(IncrementLimitedEditionItemAvailabilityRequest request, Action<IncrementLimitedEditionItemAvailabilityResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/IncrementLimitedEditionItemAvailability", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Resets the indicated statistic, removing all player entries for it and backing up the old values.
        /// </summary>
        public static void IncrementPlayerStatisticVersion(IncrementPlayerStatisticVersionRequest request, Action<IncrementPlayerStatisticVersionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/IncrementPlayerStatisticVersion", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves a list of all Open ID Connect providers registered to a title.
        /// </summary>
        public static void ListOpenIdConnection(ListOpenIdConnectionRequest request, Action<ListOpenIdConnectionResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/ListOpenIdConnection", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves the build details for all game server executables which are currently defined for the title
        /// </summary>
        public static void ListServerBuilds(ListBuildsRequest request, Action<ListBuildsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/ListServerBuilds", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retuns the list of all defined virtual currencies for the title
        /// </summary>
        public static void ListVirtualCurrencyTypes(ListVirtualCurrencyTypesRequest request, Action<ListVirtualCurrencyTypesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/ListVirtualCurrencyTypes", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the game server mode details for the specified game server executable
        /// </summary>
        public static void ModifyMatchmakerGameModes(ModifyMatchmakerGameModesRequest request, Action<ModifyMatchmakerGameModesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/ModifyMatchmakerGameModes", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the build details for the specified game server executable
        /// </summary>
        public static void ModifyServerBuild(ModifyServerBuildRequest request, Action<ModifyServerBuildResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/ModifyServerBuild", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Attempts to process an order refund through the original real money payment provider.
        /// </summary>
        public static void RefundPurchase(RefundPurchaseRequest request, Action<RefundPurchaseResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/RefundPurchase", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Remove a given tag from a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        public static void RemovePlayerTag(RemovePlayerTagRequest request, Action<RemovePlayerTagResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/RemovePlayerTag", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Removes the game server executable specified from the set of those a client is permitted to request in a call to
        /// StartGame
        /// </summary>
        public static void RemoveServerBuild(RemoveServerBuildRequest request, Action<RemoveServerBuildResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/RemoveServerBuild", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Removes one or more virtual currencies from the set defined for the title.
        /// </summary>
        public static void RemoveVirtualCurrencyTypes(RemoveVirtualCurrencyTypesRequest request, Action<BlankResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/RemoveVirtualCurrencyTypes", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Completely removes all statistics for the specified character, for the current game
        /// </summary>
        public static void ResetCharacterStatistics(ResetCharacterStatisticsRequest request, Action<ResetCharacterStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/ResetCharacterStatistics", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Reset a player's password for a given title.
        /// </summary>
        public static void ResetPassword(ResetPasswordRequest request, Action<ResetPasswordResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/ResetPassword", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Completely removes all statistics for the specified user, for the current game
        /// </summary>
        public static void ResetUserStatistics(ResetUserStatisticsRequest request, Action<ResetUserStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/ResetUserStatistics", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Attempts to resolve a dispute with the original order's payment provider.
        /// </summary>
        public static void ResolvePurchaseDispute(ResolvePurchaseDisputeRequest request, Action<ResolvePurchaseDisputeResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/ResolvePurchaseDispute", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Revoke all active bans for a user.
        /// </summary>
        public static void RevokeAllBansForUser(RevokeAllBansForUserRequest request, Action<RevokeAllBansForUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/RevokeAllBansForUser", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Revoke all active bans specified with BanId.
        /// </summary>
        public static void RevokeBans(RevokeBansRequest request, Action<RevokeBansResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/RevokeBans", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Revokes access to an item in a user's inventory
        /// </summary>
        public static void RevokeInventoryItem(RevokeInventoryItemRequest request, Action<RevokeInventoryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/RevokeInventoryItem", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Revokes access for up to 25 items across multiple users and characters.
        /// </summary>
        public static void RevokeInventoryItems(RevokeInventoryItemsRequest request, Action<RevokeInventoryItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/RevokeInventoryItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Run a task immediately regardless of its schedule.
        /// </summary>
        public static void RunTask(RunTaskRequest request, Action<RunTaskResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/RunTask", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Forces an email to be sent to the registered email address for the user's account, with a link allowing the user to
        /// change the password.If an account recovery email template ID is provided, an email using the custom email template will
        /// be used.
        /// </summary>
        public static void SendAccountRecoveryEmail(SendAccountRecoveryEmailRequest request, Action<SendAccountRecoveryEmailResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/SendAccountRecoveryEmail", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Creates the catalog configuration of all virtual goods for the specified catalog version
        /// </summary>
        public static void SetCatalogItems(UpdateCatalogItemsRequest request, Action<UpdateCatalogItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/SetCatalogItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Sets the override expiration for a membership subscription
        /// </summary>
        public static void SetMembershipOverride(SetMembershipOverrideRequest request, Action<SetMembershipOverrideResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/SetMembershipOverride", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Sets or resets the player's secret. Player secrets are used to sign API requests.
        /// </summary>
        public static void SetPlayerSecret(SetPlayerSecretRequest request, Action<SetPlayerSecretResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/SetPlayerSecret", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Sets the currently published revision of a title Cloud Script
        /// </summary>
        public static void SetPublishedRevision(SetPublishedRevisionRequest request, Action<SetPublishedRevisionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/SetPublishedRevision", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        public static void SetPublisherData(SetPublisherDataRequest request, Action<SetPublisherDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/SetPublisherData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Sets all the items in one virtual store
        /// </summary>
        public static void SetStoreItems(UpdateStoreItemsRequest request, Action<UpdateStoreItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/SetStoreItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Creates and updates the key-value store of custom title settings which can be read by the client
        /// </summary>
        public static void SetTitleData(SetTitleDataRequest request, Action<SetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/SetTitleData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Set and delete key-value pairs in a title data override instance.
        /// </summary>
        public static void SetTitleDataAndOverrides(SetTitleDataAndOverridesRequest request, Action<SetTitleDataAndOverridesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/SetTitleDataAndOverrides", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the key-value store of custom title settings which cannot be read by the client
        /// </summary>
        public static void SetTitleInternalData(SetTitleDataRequest request, Action<SetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/SetTitleInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Sets the Amazon Resource Name (ARN) for iOS and Android push notifications. Documentation on the exact restrictions can
        /// be found at: http://docs.aws.amazon.com/sns/latest/api/API_CreatePlatformApplication.html. Currently, Amazon device
        /// Messaging is not supported.
        /// </summary>
        public static void SetupPushNotification(SetupPushNotificationRequest request, Action<SetupPushNotificationResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/SetupPushNotification", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Decrements the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, Action<ModifyUserVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/SubtractUserVirtualCurrency", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates information of a list of existing bans specified with Ban Ids.
        /// </summary>
        public static void UpdateBans(UpdateBansRequest request, Action<UpdateBansResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateBans", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the catalog configuration for virtual goods in the specified catalog version
        /// </summary>
        public static void UpdateCatalogItems(UpdateCatalogItemsRequest request, Action<UpdateCatalogItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateCatalogItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Creates a new Cloud Script revision and uploads source code to it. Note that at this time, only one file should be
        /// submitted in the revision.
        /// </summary>
        public static void UpdateCloudScript(UpdateCloudScriptRequest request, Action<UpdateCloudScriptResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateCloudScript", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Modifies data and credentials for an existing relationship between a title and an Open ID Connect provider
        /// </summary>
        public static void UpdateOpenIdConnection(UpdateOpenIdConnectionRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateOpenIdConnection", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates a existing Player Shared Secret Key. It may take up to 5 minutes for this update to become generally available
        /// after this API returns.
        /// </summary>
        public static void UpdatePlayerSharedSecret(UpdatePlayerSharedSecretRequest request, Action<UpdatePlayerSharedSecretResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdatePlayerSharedSecret", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates a player statistic configuration for the title, optionally allowing the developer to specify a reset interval.
        /// </summary>
        public static void UpdatePlayerStatisticDefinition(UpdatePlayerStatisticDefinitionRequest request, Action<UpdatePlayerStatisticDefinitionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdatePlayerStatisticDefinition", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Changes a policy for a title
        /// </summary>
        public static void UpdatePolicy(UpdatePolicyRequest request, Action<UpdatePolicyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdatePolicy", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the random drop table configuration for the title
        /// </summary>
        public static void UpdateRandomResultTables(UpdateRandomResultTablesRequest request, Action<UpdateRandomResultTablesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateRandomResultTables", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates an existing player segment and its associated definition(s) and action(s) for a title.
        /// </summary>
        public static void UpdateSegment(UpdateSegmentRequest request, Action<UpdateSegmentResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateSegment", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates an existing virtual item store with new or modified items
        /// </summary>
        public static void UpdateStoreItems(UpdateStoreItemsRequest request, Action<UpdateStoreItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateStoreItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Update an existing task.
        /// </summary>
        public static void UpdateTask(UpdateTaskRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateTask", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateUserData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserInternalData(UpdateUserInternalDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateUserInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserPublisherData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateUserPublisherData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserPublisherInternalData(UpdateUserInternalDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateUserPublisherInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserPublisherReadOnlyData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateUserPublisherReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserReadOnlyData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateUserReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the title specific display name for a user
        /// </summary>
        public static void UpdateUserTitleDisplayName(UpdateUserTitleDisplayNameRequest request, Action<UpdateUserTitleDisplayNameResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (string.IsNullOrEmpty(callSettings.DeveloperSecretKey)) { throw new PlayFabException(PlayFabExceptionCode.DeveloperKeyNotSet, "Must set DeveloperSecretKey in settings to call this method"); }


            PlayFabHttp.MakeApiCall("/Admin/UpdateUserTitleDisplayName", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }


    }
}

#endif
