using System;
using PlayFab.AdminModels;
using PlayFab.Internal;
using UnityEngine;

namespace PlayFab
{
    /// <summary>
    /// APIs for managing title configurations, uploaded Game Server code executables, and user data
    /// </summary>
    public static class PlayFabAdminAPI
    {
        public delegate void ProcessApiCallback<in TResult>(TResult result) where TResult : PlayFabResultCommon;

        public delegate void GetUserAccountInfoRequestCallback(string urlPath, int callId, LookupUserAccountInfoRequest request, object customData);
        public delegate void GetUserAccountInfoResponseCallback(string urlPath, int callId, LookupUserAccountInfoRequest request, LookupUserAccountInfoResult result, PlayFabError error, object customData);
        public delegate void ResetUsersRequestCallback(string urlPath, int callId, ResetUsersRequest request, object customData);
        public delegate void ResetUsersResponseCallback(string urlPath, int callId, ResetUsersRequest request, BlankResult result, PlayFabError error, object customData);
        public delegate void SendAccountRecoveryEmailRequestCallback(string urlPath, int callId, SendAccountRecoveryEmailRequest request, object customData);
        public delegate void SendAccountRecoveryEmailResponseCallback(string urlPath, int callId, SendAccountRecoveryEmailRequest request, SendAccountRecoveryEmailResult result, PlayFabError error, object customData);
        public delegate void UpdateUserTitleDisplayNameRequestCallback(string urlPath, int callId, UpdateUserTitleDisplayNameRequest request, object customData);
        public delegate void UpdateUserTitleDisplayNameResponseCallback(string urlPath, int callId, UpdateUserTitleDisplayNameRequest request, UpdateUserTitleDisplayNameResult result, PlayFabError error, object customData);
        public delegate void CreatePlayerStatisticDefinitionRequestCallback(string urlPath, int callId, CreatePlayerStatisticDefinitionRequest request, object customData);
        public delegate void CreatePlayerStatisticDefinitionResponseCallback(string urlPath, int callId, CreatePlayerStatisticDefinitionRequest request, CreatePlayerStatisticDefinitionResult result, PlayFabError error, object customData);
        public delegate void DeleteUsersRequestCallback(string urlPath, int callId, DeleteUsersRequest request, object customData);
        public delegate void DeleteUsersResponseCallback(string urlPath, int callId, DeleteUsersRequest request, DeleteUsersResult result, PlayFabError error, object customData);
        public delegate void GetDataReportRequestCallback(string urlPath, int callId, GetDataReportRequest request, object customData);
        public delegate void GetDataReportResponseCallback(string urlPath, int callId, GetDataReportRequest request, GetDataReportResult result, PlayFabError error, object customData);
        public delegate void GetPlayerStatisticDefinitionsRequestCallback(string urlPath, int callId, GetPlayerStatisticDefinitionsRequest request, object customData);
        public delegate void GetPlayerStatisticDefinitionsResponseCallback(string urlPath, int callId, GetPlayerStatisticDefinitionsRequest request, GetPlayerStatisticDefinitionsResult result, PlayFabError error, object customData);
        public delegate void GetPlayerStatisticVersionsRequestCallback(string urlPath, int callId, GetPlayerStatisticVersionsRequest request, object customData);
        public delegate void GetPlayerStatisticVersionsResponseCallback(string urlPath, int callId, GetPlayerStatisticVersionsRequest request, GetPlayerStatisticVersionsResult result, PlayFabError error, object customData);
        public delegate void GetUserDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void GetUserInternalDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserInternalDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void GetUserPublisherDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserPublisherDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void GetUserPublisherInternalDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserPublisherInternalDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void GetUserPublisherReadOnlyDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserPublisherReadOnlyDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void GetUserReadOnlyDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserReadOnlyDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void IncrementPlayerStatisticVersionRequestCallback(string urlPath, int callId, IncrementPlayerStatisticVersionRequest request, object customData);
        public delegate void IncrementPlayerStatisticVersionResponseCallback(string urlPath, int callId, IncrementPlayerStatisticVersionRequest request, IncrementPlayerStatisticVersionResult result, PlayFabError error, object customData);
        public delegate void ResetUserStatisticsRequestCallback(string urlPath, int callId, ResetUserStatisticsRequest request, object customData);
        public delegate void ResetUserStatisticsResponseCallback(string urlPath, int callId, ResetUserStatisticsRequest request, ResetUserStatisticsResult result, PlayFabError error, object customData);
        public delegate void UpdatePlayerStatisticDefinitionRequestCallback(string urlPath, int callId, UpdatePlayerStatisticDefinitionRequest request, object customData);
        public delegate void UpdatePlayerStatisticDefinitionResponseCallback(string urlPath, int callId, UpdatePlayerStatisticDefinitionRequest request, UpdatePlayerStatisticDefinitionResult result, PlayFabError error, object customData);
        public delegate void UpdateUserDataRequestCallback(string urlPath, int callId, UpdateUserDataRequest request, object customData);
        public delegate void UpdateUserDataResponseCallback(string urlPath, int callId, UpdateUserDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void UpdateUserInternalDataRequestCallback(string urlPath, int callId, UpdateUserInternalDataRequest request, object customData);
        public delegate void UpdateUserInternalDataResponseCallback(string urlPath, int callId, UpdateUserInternalDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void UpdateUserPublisherDataRequestCallback(string urlPath, int callId, UpdateUserDataRequest request, object customData);
        public delegate void UpdateUserPublisherDataResponseCallback(string urlPath, int callId, UpdateUserDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void UpdateUserPublisherInternalDataRequestCallback(string urlPath, int callId, UpdateUserInternalDataRequest request, object customData);
        public delegate void UpdateUserPublisherInternalDataResponseCallback(string urlPath, int callId, UpdateUserInternalDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void UpdateUserPublisherReadOnlyDataRequestCallback(string urlPath, int callId, UpdateUserDataRequest request, object customData);
        public delegate void UpdateUserPublisherReadOnlyDataResponseCallback(string urlPath, int callId, UpdateUserDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void UpdateUserReadOnlyDataRequestCallback(string urlPath, int callId, UpdateUserDataRequest request, object customData);
        public delegate void UpdateUserReadOnlyDataResponseCallback(string urlPath, int callId, UpdateUserDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void AddNewsRequestCallback(string urlPath, int callId, AddNewsRequest request, object customData);
        public delegate void AddNewsResponseCallback(string urlPath, int callId, AddNewsRequest request, AddNewsResult result, PlayFabError error, object customData);
        public delegate void AddVirtualCurrencyTypesRequestCallback(string urlPath, int callId, AddVirtualCurrencyTypesRequest request, object customData);
        public delegate void AddVirtualCurrencyTypesResponseCallback(string urlPath, int callId, AddVirtualCurrencyTypesRequest request, BlankResult result, PlayFabError error, object customData);
        public delegate void GetCatalogItemsRequestCallback(string urlPath, int callId, GetCatalogItemsRequest request, object customData);
        public delegate void GetCatalogItemsResponseCallback(string urlPath, int callId, GetCatalogItemsRequest request, GetCatalogItemsResult result, PlayFabError error, object customData);
        public delegate void GetPublisherDataRequestCallback(string urlPath, int callId, GetPublisherDataRequest request, object customData);
        public delegate void GetPublisherDataResponseCallback(string urlPath, int callId, GetPublisherDataRequest request, GetPublisherDataResult result, PlayFabError error, object customData);
        public delegate void GetRandomResultTablesRequestCallback(string urlPath, int callId, GetRandomResultTablesRequest request, object customData);
        public delegate void GetRandomResultTablesResponseCallback(string urlPath, int callId, GetRandomResultTablesRequest request, GetRandomResultTablesResult result, PlayFabError error, object customData);
        public delegate void GetStoreItemsRequestCallback(string urlPath, int callId, GetStoreItemsRequest request, object customData);
        public delegate void GetStoreItemsResponseCallback(string urlPath, int callId, GetStoreItemsRequest request, GetStoreItemsResult result, PlayFabError error, object customData);
        public delegate void GetTitleDataRequestCallback(string urlPath, int callId, GetTitleDataRequest request, object customData);
        public delegate void GetTitleDataResponseCallback(string urlPath, int callId, GetTitleDataRequest request, GetTitleDataResult result, PlayFabError error, object customData);
        public delegate void ListVirtualCurrencyTypesRequestCallback(string urlPath, int callId, ListVirtualCurrencyTypesRequest request, object customData);
        public delegate void ListVirtualCurrencyTypesResponseCallback(string urlPath, int callId, ListVirtualCurrencyTypesRequest request, ListVirtualCurrencyTypesResult result, PlayFabError error, object customData);
        public delegate void SetCatalogItemsRequestCallback(string urlPath, int callId, UpdateCatalogItemsRequest request, object customData);
        public delegate void SetCatalogItemsResponseCallback(string urlPath, int callId, UpdateCatalogItemsRequest request, UpdateCatalogItemsResult result, PlayFabError error, object customData);
        public delegate void SetStoreItemsRequestCallback(string urlPath, int callId, UpdateStoreItemsRequest request, object customData);
        public delegate void SetStoreItemsResponseCallback(string urlPath, int callId, UpdateStoreItemsRequest request, UpdateStoreItemsResult result, PlayFabError error, object customData);
        public delegate void SetTitleDataRequestCallback(string urlPath, int callId, SetTitleDataRequest request, object customData);
        public delegate void SetTitleDataResponseCallback(string urlPath, int callId, SetTitleDataRequest request, SetTitleDataResult result, PlayFabError error, object customData);
        public delegate void SetupPushNotificationRequestCallback(string urlPath, int callId, SetupPushNotificationRequest request, object customData);
        public delegate void SetupPushNotificationResponseCallback(string urlPath, int callId, SetupPushNotificationRequest request, SetupPushNotificationResult result, PlayFabError error, object customData);
        public delegate void UpdateCatalogItemsRequestCallback(string urlPath, int callId, UpdateCatalogItemsRequest request, object customData);
        public delegate void UpdateCatalogItemsResponseCallback(string urlPath, int callId, UpdateCatalogItemsRequest request, UpdateCatalogItemsResult result, PlayFabError error, object customData);
        public delegate void UpdateRandomResultTablesRequestCallback(string urlPath, int callId, UpdateRandomResultTablesRequest request, object customData);
        public delegate void UpdateRandomResultTablesResponseCallback(string urlPath, int callId, UpdateRandomResultTablesRequest request, UpdateRandomResultTablesResult result, PlayFabError error, object customData);
        public delegate void UpdateStoreItemsRequestCallback(string urlPath, int callId, UpdateStoreItemsRequest request, object customData);
        public delegate void UpdateStoreItemsResponseCallback(string urlPath, int callId, UpdateStoreItemsRequest request, UpdateStoreItemsResult result, PlayFabError error, object customData);
        public delegate void AddUserVirtualCurrencyRequestCallback(string urlPath, int callId, AddUserVirtualCurrencyRequest request, object customData);
        public delegate void AddUserVirtualCurrencyResponseCallback(string urlPath, int callId, AddUserVirtualCurrencyRequest request, ModifyUserVirtualCurrencyResult result, PlayFabError error, object customData);
        public delegate void GetUserInventoryRequestCallback(string urlPath, int callId, GetUserInventoryRequest request, object customData);
        public delegate void GetUserInventoryResponseCallback(string urlPath, int callId, GetUserInventoryRequest request, GetUserInventoryResult result, PlayFabError error, object customData);
        public delegate void GrantItemsToUsersRequestCallback(string urlPath, int callId, GrantItemsToUsersRequest request, object customData);
        public delegate void GrantItemsToUsersResponseCallback(string urlPath, int callId, GrantItemsToUsersRequest request, GrantItemsToUsersResult result, PlayFabError error, object customData);
        public delegate void RevokeInventoryItemRequestCallback(string urlPath, int callId, RevokeInventoryItemRequest request, object customData);
        public delegate void RevokeInventoryItemResponseCallback(string urlPath, int callId, RevokeInventoryItemRequest request, RevokeInventoryResult result, PlayFabError error, object customData);
        public delegate void SubtractUserVirtualCurrencyRequestCallback(string urlPath, int callId, SubtractUserVirtualCurrencyRequest request, object customData);
        public delegate void SubtractUserVirtualCurrencyResponseCallback(string urlPath, int callId, SubtractUserVirtualCurrencyRequest request, ModifyUserVirtualCurrencyResult result, PlayFabError error, object customData);
        public delegate void GetMatchmakerGameInfoRequestCallback(string urlPath, int callId, GetMatchmakerGameInfoRequest request, object customData);
        public delegate void GetMatchmakerGameInfoResponseCallback(string urlPath, int callId, GetMatchmakerGameInfoRequest request, GetMatchmakerGameInfoResult result, PlayFabError error, object customData);
        public delegate void GetMatchmakerGameModesRequestCallback(string urlPath, int callId, GetMatchmakerGameModesRequest request, object customData);
        public delegate void GetMatchmakerGameModesResponseCallback(string urlPath, int callId, GetMatchmakerGameModesRequest request, GetMatchmakerGameModesResult result, PlayFabError error, object customData);
        public delegate void ModifyMatchmakerGameModesRequestCallback(string urlPath, int callId, ModifyMatchmakerGameModesRequest request, object customData);
        public delegate void ModifyMatchmakerGameModesResponseCallback(string urlPath, int callId, ModifyMatchmakerGameModesRequest request, ModifyMatchmakerGameModesResult result, PlayFabError error, object customData);
        public delegate void AddServerBuildRequestCallback(string urlPath, int callId, AddServerBuildRequest request, object customData);
        public delegate void AddServerBuildResponseCallback(string urlPath, int callId, AddServerBuildRequest request, AddServerBuildResult result, PlayFabError error, object customData);
        public delegate void GetServerBuildInfoRequestCallback(string urlPath, int callId, GetServerBuildInfoRequest request, object customData);
        public delegate void GetServerBuildInfoResponseCallback(string urlPath, int callId, GetServerBuildInfoRequest request, GetServerBuildInfoResult result, PlayFabError error, object customData);
        public delegate void GetServerBuildUploadUrlRequestCallback(string urlPath, int callId, GetServerBuildUploadURLRequest request, object customData);
        public delegate void GetServerBuildUploadUrlResponseCallback(string urlPath, int callId, GetServerBuildUploadURLRequest request, GetServerBuildUploadURLResult result, PlayFabError error, object customData);
        public delegate void ListServerBuildsRequestCallback(string urlPath, int callId, ListBuildsRequest request, object customData);
        public delegate void ListServerBuildsResponseCallback(string urlPath, int callId, ListBuildsRequest request, ListBuildsResult result, PlayFabError error, object customData);
        public delegate void ModifyServerBuildRequestCallback(string urlPath, int callId, ModifyServerBuildRequest request, object customData);
        public delegate void ModifyServerBuildResponseCallback(string urlPath, int callId, ModifyServerBuildRequest request, ModifyServerBuildResult result, PlayFabError error, object customData);
        public delegate void RemoveServerBuildRequestCallback(string urlPath, int callId, RemoveServerBuildRequest request, object customData);
        public delegate void RemoveServerBuildResponseCallback(string urlPath, int callId, RemoveServerBuildRequest request, RemoveServerBuildResult result, PlayFabError error, object customData);
        public delegate void SetPublisherDataRequestCallback(string urlPath, int callId, SetPublisherDataRequest request, object customData);
        public delegate void SetPublisherDataResponseCallback(string urlPath, int callId, SetPublisherDataRequest request, SetPublisherDataResult result, PlayFabError error, object customData);
        public delegate void GetCloudScriptRevisionRequestCallback(string urlPath, int callId, GetCloudScriptRevisionRequest request, object customData);
        public delegate void GetCloudScriptRevisionResponseCallback(string urlPath, int callId, GetCloudScriptRevisionRequest request, GetCloudScriptRevisionResult result, PlayFabError error, object customData);
        public delegate void GetCloudScriptVersionsRequestCallback(string urlPath, int callId, GetCloudScriptVersionsRequest request, object customData);
        public delegate void GetCloudScriptVersionsResponseCallback(string urlPath, int callId, GetCloudScriptVersionsRequest request, GetCloudScriptVersionsResult result, PlayFabError error, object customData);
        public delegate void SetPublishedRevisionRequestCallback(string urlPath, int callId, SetPublishedRevisionRequest request, object customData);
        public delegate void SetPublishedRevisionResponseCallback(string urlPath, int callId, SetPublishedRevisionRequest request, SetPublishedRevisionResult result, PlayFabError error, object customData);
        public delegate void UpdateCloudScriptRequestCallback(string urlPath, int callId, UpdateCloudScriptRequest request, object customData);
        public delegate void UpdateCloudScriptResponseCallback(string urlPath, int callId, UpdateCloudScriptRequest request, UpdateCloudScriptResult result, PlayFabError error, object customData);
        public delegate void DeleteContentRequestCallback(string urlPath, int callId, DeleteContentRequest request, object customData);
        public delegate void DeleteContentResponseCallback(string urlPath, int callId, DeleteContentRequest request, BlankResult result, PlayFabError error, object customData);
        public delegate void GetContentListRequestCallback(string urlPath, int callId, GetContentListRequest request, object customData);
        public delegate void GetContentListResponseCallback(string urlPath, int callId, GetContentListRequest request, GetContentListResult result, PlayFabError error, object customData);
        public delegate void GetContentUploadUrlRequestCallback(string urlPath, int callId, GetContentUploadUrlRequest request, object customData);
        public delegate void GetContentUploadUrlResponseCallback(string urlPath, int callId, GetContentUploadUrlRequest request, GetContentUploadUrlResult result, PlayFabError error, object customData);
        public delegate void ResetCharacterStatisticsRequestCallback(string urlPath, int callId, ResetCharacterStatisticsRequest request, object customData);
        public delegate void ResetCharacterStatisticsResponseCallback(string urlPath, int callId, ResetCharacterStatisticsRequest request, ResetCharacterStatisticsResult result, PlayFabError error, object customData);

        /// <summary>
        /// Retrieves the relevant details for a specified user, based upon a match against a supplied unique identifier
        /// </summary>
        public static void GetUserAccountInfo(LookupUserAccountInfoRequest request, ProcessApiCallback<LookupUserAccountInfoResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LookupUserAccountInfoResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetUserAccountInfo", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Resets all title-specific information about a particular account, including user data, virtual currency balances, inventory, purchase history, and statistics
        /// </summary>
        public static void ResetUsers(ResetUsersRequest request, ProcessApiCallback<BlankResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<BlankResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/ResetUsers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Forces an email to be sent to the registered email address for the specified account, with a link allowing the user to change the password
        /// </summary>
        public static void SendAccountRecoveryEmail(SendAccountRecoveryEmailRequest request, ProcessApiCallback<SendAccountRecoveryEmailResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SendAccountRecoveryEmailResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/SendAccountRecoveryEmail", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title specific display name for a user
        /// </summary>
        public static void UpdateUserTitleDisplayName(UpdateUserTitleDisplayNameRequest request, ProcessApiCallback<UpdateUserTitleDisplayNameResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserTitleDisplayNameResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/UpdateUserTitleDisplayName", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds a new player statistic configuration to the title, optionally allowing the developer to specify a reset interval and an aggregation method.
        /// </summary>
        public static void CreatePlayerStatisticDefinition(CreatePlayerStatisticDefinitionRequest request, ProcessApiCallback<CreatePlayerStatisticDefinitionResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<CreatePlayerStatisticDefinitionResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/CreatePlayerStatisticDefinition", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
        /// </summary>
        public static void DeleteUsers(DeleteUsersRequest request, ProcessApiCallback<DeleteUsersResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<DeleteUsersResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/DeleteUsers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a download URL for the requested report
        /// </summary>
        public static void GetDataReport(GetDataReportRequest request, ProcessApiCallback<GetDataReportResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetDataReportResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetDataReport", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the configuration information for all player statistics defined in the title, regardless of whether they have a reset interval.
        /// </summary>
        public static void GetPlayerStatisticDefinitions(GetPlayerStatisticDefinitionsRequest request, ProcessApiCallback<GetPlayerStatisticDefinitionsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayerStatisticDefinitionsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetPlayerStatisticDefinitions", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        public static void GetPlayerStatisticVersions(GetPlayerStatisticVersionsRequest request, ProcessApiCallback<GetPlayerStatisticVersionsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayerStatisticVersionsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetPlayerStatisticVersions", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserData(GetUserDataRequest request, ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetUserData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserInternalData(GetUserDataRequest request, ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetUserInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserPublisherData(GetUserDataRequest request, ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetUserPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserPublisherInternalData(GetUserDataRequest request, ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetUserPublisherInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserPublisherReadOnlyData(GetUserDataRequest request, ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetUserPublisherReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserReadOnlyData(GetUserDataRequest request, ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetUserReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Resets the indicated statistic, removing all player entries for it and backing up the old values.
        /// </summary>
        public static void IncrementPlayerStatisticVersion(IncrementPlayerStatisticVersionRequest request, ProcessApiCallback<IncrementPlayerStatisticVersionResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<IncrementPlayerStatisticVersionResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/IncrementPlayerStatisticVersion", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Completely removes all statistics for the specified user, for the current game
        /// </summary>
        public static void ResetUserStatistics(ResetUserStatisticsRequest request, ProcessApiCallback<ResetUserStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ResetUserStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/ResetUserStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates a player statistic configuration for the title, optionally allowing the developer to specify a reset interval.
        /// </summary>
        public static void UpdatePlayerStatisticDefinition(UpdatePlayerStatisticDefinitionRequest request, ProcessApiCallback<UpdatePlayerStatisticDefinitionResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdatePlayerStatisticDefinitionResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/UpdatePlayerStatisticDefinition", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserData(UpdateUserDataRequest request, ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/UpdateUserData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserInternalData(UpdateUserInternalDataRequest request, ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/UpdateUserInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserPublisherData(UpdateUserDataRequest request, ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/UpdateUserPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserPublisherInternalData(UpdateUserInternalDataRequest request, ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/UpdateUserPublisherInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserPublisherReadOnlyData(UpdateUserDataRequest request, ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/UpdateUserPublisherReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserReadOnlyData(UpdateUserDataRequest request, ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/UpdateUserReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds a new news item to the title's news feed
        /// </summary>
        public static void AddNews(AddNewsRequest request, ProcessApiCallback<AddNewsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<AddNewsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/AddNews", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds one or more virtual currencies to the set defined for the title. Virtual Currencies have a maximum value of 2,147,483,647 when granted to a player. Any value over that will be discarded.
        /// </summary>
        public static void AddVirtualCurrencyTypes(AddVirtualCurrencyTypesRequest request, ProcessApiCallback<BlankResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<BlankResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/AddVirtualCurrencyTypes", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static void GetCatalogItems(GetCatalogItemsRequest request, ProcessApiCallback<GetCatalogItemsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCatalogItemsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetCatalogItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public static void GetPublisherData(GetPublisherDataRequest request, ProcessApiCallback<GetPublisherDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPublisherDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the random drop table configuration for the title
        /// </summary>
        public static void GetRandomResultTables(GetRandomResultTablesRequest request, ProcessApiCallback<GetRandomResultTablesResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetRandomResultTablesResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetRandomResultTables", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        public static void GetStoreItems(GetStoreItemsRequest request, ProcessApiCallback<GetStoreItemsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetStoreItemsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetStoreItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        public static void GetTitleData(GetTitleDataRequest request, ProcessApiCallback<GetTitleDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetTitleDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetTitleData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retuns the list of all defined virtual currencies for the title
        /// </summary>
        public static void ListVirtualCurrencyTypes(ListVirtualCurrencyTypesRequest request, ProcessApiCallback<ListVirtualCurrencyTypesResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ListVirtualCurrencyTypesResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/ListVirtualCurrencyTypes", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Creates the catalog configuration of all virtual goods for the specified catalog version
        /// </summary>
        public static void SetCatalogItems(UpdateCatalogItemsRequest request, ProcessApiCallback<UpdateCatalogItemsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateCatalogItemsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/SetCatalogItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Sets all the items in one virtual store
        /// </summary>
        public static void SetStoreItems(UpdateStoreItemsRequest request, ProcessApiCallback<UpdateStoreItemsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateStoreItemsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/SetStoreItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Creates and updates the key-value store of custom title settings
        /// </summary>
        public static void SetTitleData(SetTitleDataRequest request, ProcessApiCallback<SetTitleDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SetTitleDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/SetTitleData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Sets the Amazon Resource Name (ARN) for iOS and Android push notifications. Documentation on the exact restrictions can be found at: http://docs.aws.amazon.com/sns/latest/api/API_CreatePlatformApplication.html. Currently, Amazon device Messaging is not supported.
        /// </summary>
        public static void SetupPushNotification(SetupPushNotificationRequest request, ProcessApiCallback<SetupPushNotificationResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SetupPushNotificationResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/SetupPushNotification", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the catalog configuration for virtual goods in the specified catalog version
        /// </summary>
        public static void UpdateCatalogItems(UpdateCatalogItemsRequest request, ProcessApiCallback<UpdateCatalogItemsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateCatalogItemsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/UpdateCatalogItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the random drop table configuration for the title
        /// </summary>
        public static void UpdateRandomResultTables(UpdateRandomResultTablesRequest request, ProcessApiCallback<UpdateRandomResultTablesResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateRandomResultTablesResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/UpdateRandomResultTables", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates an existing virtual item store with new or modified items
        /// </summary>
        public static void UpdateStoreItems(UpdateStoreItemsRequest request, ProcessApiCallback<UpdateStoreItemsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateStoreItemsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/UpdateStoreItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Increments the specified virtual currency by the stated amount
        /// </summary>
        public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, ProcessApiCallback<ModifyUserVirtualCurrencyResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/AddUserVirtualCurrency", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        public static void GetUserInventory(GetUserInventoryRequest request, ProcessApiCallback<GetUserInventoryResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserInventoryResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetUserInventory", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds the specified items to the specified user inventories
        /// </summary>
        public static void GrantItemsToUsers(GrantItemsToUsersRequest request, ProcessApiCallback<GrantItemsToUsersResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GrantItemsToUsersResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GrantItemsToUsers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Revokes access to an item in a user's inventory
        /// </summary>
        public static void RevokeInventoryItem(RevokeInventoryItemRequest request, ProcessApiCallback<RevokeInventoryResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RevokeInventoryResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/RevokeInventoryItem", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Decrements the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, ProcessApiCallback<ModifyUserVirtualCurrencyResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/SubtractUserVirtualCurrency", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the details for a specific completed session, including links to standard out and standard error logs
        /// </summary>
        public static void GetMatchmakerGameInfo(GetMatchmakerGameInfoRequest request, ProcessApiCallback<GetMatchmakerGameInfoResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetMatchmakerGameInfoResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetMatchmakerGameInfo", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the details of defined game modes for the specified game server executable
        /// </summary>
        public static void GetMatchmakerGameModes(GetMatchmakerGameModesRequest request, ProcessApiCallback<GetMatchmakerGameModesResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetMatchmakerGameModesResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetMatchmakerGameModes", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the game server mode details for the specified game server executable
        /// </summary>
        public static void ModifyMatchmakerGameModes(ModifyMatchmakerGameModesRequest request, ProcessApiCallback<ModifyMatchmakerGameModesResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ModifyMatchmakerGameModesResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/ModifyMatchmakerGameModes", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds the game server executable specified (previously uploaded - see GetServerBuildUploadUrl) to the set of those a client is permitted to request in a call to StartGame
        /// </summary>
        public static void AddServerBuild(AddServerBuildRequest request, ProcessApiCallback<AddServerBuildResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<AddServerBuildResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/AddServerBuild", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the build details for the specified game server executable
        /// </summary>
        public static void GetServerBuildInfo(GetServerBuildInfoRequest request, ProcessApiCallback<GetServerBuildInfoResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetServerBuildInfoResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetServerBuildInfo", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the pre-authorized URL for uploading a game server package containing a build (does not enable the build for use - see AddServerBuild)
        /// </summary>
        public static void GetServerBuildUploadUrl(GetServerBuildUploadURLRequest request, ProcessApiCallback<GetServerBuildUploadURLResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetServerBuildUploadURLResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetServerBuildUploadUrl", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the build details for all game server executables which are currently defined for the title
        /// </summary>
        public static void ListServerBuilds(ListBuildsRequest request, ProcessApiCallback<ListBuildsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ListBuildsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/ListServerBuilds", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the build details for the specified game server executable
        /// </summary>
        public static void ModifyServerBuild(ModifyServerBuildRequest request, ProcessApiCallback<ModifyServerBuildResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ModifyServerBuildResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/ModifyServerBuild", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Removes the game server executable specified from the set of those a client is permitted to request in a call to StartGame
        /// </summary>
        public static void RemoveServerBuild(RemoveServerBuildRequest request, ProcessApiCallback<RemoveServerBuildResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RemoveServerBuildResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/RemoveServerBuild", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        public static void SetPublisherData(SetPublisherDataRequest request, ProcessApiCallback<SetPublisherDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SetPublisherDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/SetPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Gets the contents and information of a specific Cloud Script revision.
        /// </summary>
        public static void GetCloudScriptRevision(GetCloudScriptRevisionRequest request, ProcessApiCallback<GetCloudScriptRevisionResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCloudScriptRevisionResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetCloudScriptRevision", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Lists all the current cloud script versions. For each version, information about the current published and latest revisions is also listed.
        /// </summary>
        public static void GetCloudScriptVersions(GetCloudScriptVersionsRequest request, ProcessApiCallback<GetCloudScriptVersionsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCloudScriptVersionsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetCloudScriptVersions", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Sets the currently published revision of a title Cloud Script
        /// </summary>
        public static void SetPublishedRevision(SetPublishedRevisionRequest request, ProcessApiCallback<SetPublishedRevisionResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SetPublishedRevisionResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/SetPublishedRevision", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Creates a new Cloud Script revision and uploads source code to it. Note that at this time, only one file should be submitted in the revision.
        /// </summary>
        public static void UpdateCloudScript(UpdateCloudScriptRequest request, ProcessApiCallback<UpdateCloudScriptResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateCloudScriptResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/UpdateCloudScript", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Delete a content file from the title
        /// </summary>
        public static void DeleteContent(DeleteContentRequest request, ProcessApiCallback<BlankResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<BlankResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/DeleteContent", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// List all contents of the title and get statistics such as size
        /// </summary>
        public static void GetContentList(GetContentListRequest request, ProcessApiCallback<GetContentListResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetContentListResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetContentList", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the pre-signed URL for uploading a content file. A subsequent HTTP PUT to the returned URL uploads the content.
        /// </summary>
        public static void GetContentUploadUrl(GetContentUploadUrlRequest request, ProcessApiCallback<GetContentUploadUrlResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetContentUploadUrlResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/GetContentUploadUrl", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Completely removes all statistics for the specified character, for the current game
        /// </summary>
        public static void ResetCharacterStatistics(ResetCharacterStatisticsRequest request, ProcessApiCallback<ResetCharacterStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ResetCharacterStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Admin/ResetCharacterStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }


    }
}
