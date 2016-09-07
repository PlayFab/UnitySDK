#if ENABLE_PLAYFABADMIN_API
using System;
using PlayFab.AdminModels;
using PlayFab.Internal;
using PlayFab.Json;

namespace PlayFab
{
    /// <summary>
    /// APIs for managing title configurations, uploaded Game Server code executables, and user data
    /// </summary>
    public static class PlayFabAdminAPI
    {

        /// <summary>
        /// Bans users by PlayFab ID with optional IP address, or MAC address for the provided game.
        /// </summary>
        public static void BanUsers(BanUsersRequest request, Action<BanUsersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/BanUsers", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user, based upon a match against a supplied unique identifier
        /// </summary>
        public static void GetUserAccountInfo(LookupUserAccountInfoRequest request, Action<LookupUserAccountInfoResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetUserAccountInfo", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Gets all bans for a user.
        /// </summary>
        public static void GetUserBans(GetUserBansRequest request, Action<GetUserBansResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetUserBans", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Resets all title-specific information about a particular account, including user data, virtual currency balances, inventory, purchase history, and statistics
        /// </summary>
        public static void ResetUsers(ResetUsersRequest request, Action<BlankResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/ResetUsers", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Revoke all active bans for a user.
        /// </summary>
        public static void RevokeAllBansForUser(RevokeAllBansForUserRequest request, Action<RevokeAllBansForUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/RevokeAllBansForUser", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Revoke all active bans specified with BanId.
        /// </summary>
        public static void RevokeBans(RevokeBansRequest request, Action<RevokeBansResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/RevokeBans", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Forces an email to be sent to the registered email address for the specified account, with a link allowing the user to change the password
        /// </summary>
        public static void SendAccountRecoveryEmail(SendAccountRecoveryEmailRequest request, Action<SendAccountRecoveryEmailResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/SendAccountRecoveryEmail", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates information of a list of existing bans specified with Ban Ids.
        /// </summary>
        public static void UpdateBans(UpdateBansRequest request, Action<UpdateBansResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdateBans", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title specific display name for a user
        /// </summary>
        public static void UpdateUserTitleDisplayName(UpdateUserTitleDisplayNameRequest request, Action<UpdateUserTitleDisplayNameResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdateUserTitleDisplayName", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds a new player statistic configuration to the title, optionally allowing the developer to specify a reset interval and an aggregation method.
        /// </summary>
        public static void CreatePlayerStatisticDefinition(CreatePlayerStatisticDefinitionRequest request, Action<CreatePlayerStatisticDefinitionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/CreatePlayerStatisticDefinition", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics. This method does not remove the player's event history, login history, inventory items, nor virtual currencies.
        /// </summary>
        public static void DeleteUsers(DeleteUsersRequest request, Action<DeleteUsersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/DeleteUsers", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves a download URL for the requested report
        /// </summary>
        public static void GetDataReport(GetDataReportRequest request, Action<GetDataReportResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetDataReport", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the configuration information for all player statistics defined in the title, regardless of whether they have a reset interval.
        /// </summary>
        public static void GetPlayerStatisticDefinitions(GetPlayerStatisticDefinitionsRequest request, Action<GetPlayerStatisticDefinitionsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetPlayerStatisticDefinitions", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        public static void GetPlayerStatisticVersions(GetPlayerStatisticVersionsRequest request, Action<GetPlayerStatisticVersionsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetPlayerStatisticVersions", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetUserData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserInternalData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetUserInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserPublisherData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetUserPublisherData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserPublisherInternalData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetUserPublisherInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserPublisherReadOnlyData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetUserPublisherReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserReadOnlyData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetUserReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Resets the indicated statistic, removing all player entries for it and backing up the old values.
        /// </summary>
        public static void IncrementPlayerStatisticVersion(IncrementPlayerStatisticVersionRequest request, Action<IncrementPlayerStatisticVersionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/IncrementPlayerStatisticVersion", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Completely removes all statistics for the specified user, for the current game
        /// </summary>
        public static void ResetUserStatistics(ResetUserStatisticsRequest request, Action<ResetUserStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/ResetUserStatistics", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates a player statistic configuration for the title, optionally allowing the developer to specify a reset interval.
        /// </summary>
        public static void UpdatePlayerStatisticDefinition(UpdatePlayerStatisticDefinitionRequest request, Action<UpdatePlayerStatisticDefinitionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdatePlayerStatisticDefinition", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdateUserData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserInternalData(UpdateUserInternalDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdateUserInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserPublisherData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdateUserPublisherData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserPublisherInternalData(UpdateUserInternalDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdateUserPublisherInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserPublisherReadOnlyData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdateUserPublisherReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserReadOnlyData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdateUserReadOnlyData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds a new news item to the title's news feed
        /// </summary>
        public static void AddNews(AddNewsRequest request, Action<AddNewsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/AddNews", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds one or more virtual currencies to the set defined for the title. Virtual Currencies have a maximum value of 2,147,483,647 when granted to a player. Any value over that will be discarded.
        /// </summary>
        public static void AddVirtualCurrencyTypes(AddVirtualCurrencyTypesRequest request, Action<BlankResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/AddVirtualCurrencyTypes", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Deletes an existing virtual item store
        /// </summary>
        public static void DeleteStore(DeleteStoreRequest request, Action<DeleteStoreResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/DeleteStore", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static void GetCatalogItems(GetCatalogItemsRequest request, Action<GetCatalogItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetCatalogItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public static void GetPublisherData(GetPublisherDataRequest request, Action<GetPublisherDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetPublisherData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the random drop table configuration for the title
        /// </summary>
        public static void GetRandomResultTables(GetRandomResultTablesRequest request, Action<GetRandomResultTablesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetRandomResultTables", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        public static void GetStoreItems(GetStoreItemsRequest request, Action<GetStoreItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetStoreItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings which can be read by the client
        /// </summary>
        public static void GetTitleData(GetTitleDataRequest request, Action<GetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetTitleData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings which cannot be read by the client
        /// </summary>
        public static void GetTitleInternalData(GetTitleDataRequest request, Action<GetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetTitleInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retuns the list of all defined virtual currencies for the title
        /// </summary>
        public static void ListVirtualCurrencyTypes(ListVirtualCurrencyTypesRequest request, Action<ListVirtualCurrencyTypesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/ListVirtualCurrencyTypes", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Removes one or more virtual currencies from the set defined for the title.
        /// </summary>
        public static void RemoveVirtualCurrencyTypes(RemoveVirtualCurrencyTypesRequest request, Action<BlankResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/RemoveVirtualCurrencyTypes", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Creates the catalog configuration of all virtual goods for the specified catalog version
        /// </summary>
        public static void SetCatalogItems(UpdateCatalogItemsRequest request, Action<UpdateCatalogItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/SetCatalogItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Sets all the items in one virtual store
        /// </summary>
        public static void SetStoreItems(UpdateStoreItemsRequest request, Action<UpdateStoreItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/SetStoreItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Creates and updates the key-value store of custom title settings which can be read by the client
        /// </summary>
        public static void SetTitleData(SetTitleDataRequest request, Action<SetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/SetTitleData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom title settings which cannot be read by the client
        /// </summary>
        public static void SetTitleInternalData(SetTitleDataRequest request, Action<SetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/SetTitleInternalData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Sets the Amazon Resource Name (ARN) for iOS and Android push notifications. Documentation on the exact restrictions can be found at: http://docs.aws.amazon.com/sns/latest/api/API_CreatePlatformApplication.html. Currently, Amazon device Messaging is not supported.
        /// </summary>
        public static void SetupPushNotification(SetupPushNotificationRequest request, Action<SetupPushNotificationResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/SetupPushNotification", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the catalog configuration for virtual goods in the specified catalog version
        /// </summary>
        public static void UpdateCatalogItems(UpdateCatalogItemsRequest request, Action<UpdateCatalogItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdateCatalogItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the random drop table configuration for the title
        /// </summary>
        public static void UpdateRandomResultTables(UpdateRandomResultTablesRequest request, Action<UpdateRandomResultTablesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdateRandomResultTables", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates an existing virtual item store with new or modified items
        /// </summary>
        public static void UpdateStoreItems(UpdateStoreItemsRequest request, Action<UpdateStoreItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdateStoreItems", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Increments the specified virtual currency by the stated amount
        /// </summary>
        public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, Action<ModifyUserVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/AddUserVirtualCurrency", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        public static void GetUserInventory(GetUserInventoryRequest request, Action<GetUserInventoryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetUserInventory", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds the specified items to the specified user inventories
        /// </summary>
        public static void GrantItemsToUsers(GrantItemsToUsersRequest request, Action<GrantItemsToUsersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GrantItemsToUsers", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Revokes access to an item in a user's inventory
        /// </summary>
        public static void RevokeInventoryItem(RevokeInventoryItemRequest request, Action<RevokeInventoryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/RevokeInventoryItem", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Decrements the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, Action<ModifyUserVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/SubtractUserVirtualCurrency", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the details for a specific completed session, including links to standard out and standard error logs
        /// </summary>
        public static void GetMatchmakerGameInfo(GetMatchmakerGameInfoRequest request, Action<GetMatchmakerGameInfoResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetMatchmakerGameInfo", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the details of defined game modes for the specified game server executable
        /// </summary>
        public static void GetMatchmakerGameModes(GetMatchmakerGameModesRequest request, Action<GetMatchmakerGameModesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetMatchmakerGameModes", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the game server mode details for the specified game server executable
        /// </summary>
        public static void ModifyMatchmakerGameModes(ModifyMatchmakerGameModesRequest request, Action<ModifyMatchmakerGameModesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/ModifyMatchmakerGameModes", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds the game server executable specified (previously uploaded - see GetServerBuildUploadUrl) to the set of those a client is permitted to request in a call to StartGame
        /// </summary>
        public static void AddServerBuild(AddServerBuildRequest request, Action<AddServerBuildResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/AddServerBuild", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the build details for the specified game server executable
        /// </summary>
        public static void GetServerBuildInfo(GetServerBuildInfoRequest request, Action<GetServerBuildInfoResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetServerBuildInfo", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the pre-authorized URL for uploading a game server package containing a build (does not enable the build for use - see AddServerBuild)
        /// </summary>
        public static void GetServerBuildUploadUrl(GetServerBuildUploadURLRequest request, Action<GetServerBuildUploadURLResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetServerBuildUploadUrl", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the build details for all game server executables which are currently defined for the title
        /// </summary>
        public static void ListServerBuilds(ListBuildsRequest request, Action<ListBuildsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/ListServerBuilds", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the build details for the specified game server executable
        /// </summary>
        public static void ModifyServerBuild(ModifyServerBuildRequest request, Action<ModifyServerBuildResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/ModifyServerBuild", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Removes the game server executable specified from the set of those a client is permitted to request in a call to StartGame
        /// </summary>
        public static void RemoveServerBuild(RemoveServerBuildRequest request, Action<RemoveServerBuildResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/RemoveServerBuild", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        public static void SetPublisherData(SetPublisherDataRequest request, Action<SetPublisherDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/SetPublisherData", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Gets the contents and information of a specific Cloud Script revision.
        /// </summary>
        public static void GetCloudScriptRevision(GetCloudScriptRevisionRequest request, Action<GetCloudScriptRevisionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetCloudScriptRevision", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Lists all the current cloud script versions. For each version, information about the current published and latest revisions is also listed.
        /// </summary>
        public static void GetCloudScriptVersions(GetCloudScriptVersionsRequest request, Action<GetCloudScriptVersionsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetCloudScriptVersions", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Sets the currently published revision of a title Cloud Script
        /// </summary>
        public static void SetPublishedRevision(SetPublishedRevisionRequest request, Action<SetPublishedRevisionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/SetPublishedRevision", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Creates a new Cloud Script revision and uploads source code to it. Note that at this time, only one file should be submitted in the revision.
        /// </summary>
        public static void UpdateCloudScript(UpdateCloudScriptRequest request, Action<UpdateCloudScriptResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/UpdateCloudScript", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Delete a content file from the title
        /// </summary>
        public static void DeleteContent(DeleteContentRequest request, Action<BlankResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/DeleteContent", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// List all contents of the title and get statistics such as size
        /// </summary>
        public static void GetContentList(GetContentListRequest request, Action<GetContentListResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetContentList", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the pre-signed URL for uploading a content file. A subsequent HTTP PUT to the returned URL uploads the content.
        /// </summary>
        public static void GetContentUploadUrl(GetContentUploadUrlRequest request, Action<GetContentUploadUrlResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetContentUploadUrl", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Completely removes all statistics for the specified character, for the current game
        /// </summary>
        public static void ResetCharacterStatistics(ResetCharacterStatisticsRequest request, Action<ResetCharacterStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/ResetCharacterStatistics", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds a given tag to a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        public static void AddPlayerTag(AddPlayerTagRequest request, Action<AddPlayerTagResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/AddPlayerTag", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieve a list of all PlayStream actions groups.
        /// </summary>
        public static void GetAllActionGroups(GetAllActionGroupsRequest request, Action<GetAllActionGroupsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetAllActionGroups", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves an array of player segment definitions. Results from this can be used in subsequent API calls such as GetPlayersInSegment which requires a Segment ID. While segment names can change the ID for that segment will not change.
        /// </summary>
        public static void GetAllSegments(GetAllSegmentsRequest request, Action<GetAllSegmentsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetAllSegments", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// List all segments that a player currently belongs to at this moment in time.
        /// </summary>
        public static void GetPlayerSegments(GetPlayersSegmentsRequest request, Action<GetPlayerSegmentsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetPlayerSegments", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Allows for paging through all players in a given segment. This API creates a snapshot of all player profiles that match the segment definition at the time of its creation and lives through the Total Seconds to Live, refreshing its life span on each subsequent use of the Continuation Token. Profiles that change during the course of paging will not be reflected in the results. AB Test segments are currently not supported by this operation.
        /// </summary>
        public static void GetPlayersInSegment(GetPlayersInSegmentRequest request, Action<GetPlayersInSegmentResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetPlayersInSegment", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Get all tags with a given Namespace (optional) from a player profile.
        /// </summary>
        public static void GetPlayerTags(GetPlayerTagsRequest request, Action<GetPlayerTagsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/GetPlayerTags", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Remove a given tag from a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        public static void RemovePlayerTag(RemovePlayerTagRequest request, Action<RemovePlayerTagResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall("/Admin/RemovePlayerTag", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData);
        }


    }
}
#endif
