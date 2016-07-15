#if ENABLE_PLAYFABADMIN_API
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

        /// <summary>
        /// Retrieves the relevant details for a specified user, based upon a match against a supplied unique identifier
        /// </summary>
        public static void GetUserAccountInfo(LookupUserAccountInfoRequest request, Action<LookupUserAccountInfoResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<LookupUserAccountInfoRequest, LookupUserAccountInfoResult>("Admin", "/Admin/GetUserAccountInfo", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Resets all title-specific information about a particular account, including user data, virtual currency balances, inventory, purchase history, and statistics
        /// </summary>
        public static void ResetUsers(ResetUsersRequest request, Action<BlankResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<ResetUsersRequest, BlankResult>("Admin", "/Admin/ResetUsers", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Forces an email to be sent to the registered email address for the specified account, with a link allowing the user to change the password
        /// </summary>
        public static void SendAccountRecoveryEmail(SendAccountRecoveryEmailRequest request, Action<SendAccountRecoveryEmailResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SendAccountRecoveryEmailRequest, SendAccountRecoveryEmailResult>("Admin", "/Admin/SendAccountRecoveryEmail", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title specific display name for a user
        /// </summary>
        public static void UpdateUserTitleDisplayName(UpdateUserTitleDisplayNameRequest request, Action<UpdateUserTitleDisplayNameResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserTitleDisplayNameRequest, UpdateUserTitleDisplayNameResult>("Admin", "/Admin/UpdateUserTitleDisplayName", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds a new player statistic configuration to the title, optionally allowing the developer to specify a reset interval and an aggregation method.
        /// </summary>
        public static void CreatePlayerStatisticDefinition(CreatePlayerStatisticDefinitionRequest request, Action<CreatePlayerStatisticDefinitionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<CreatePlayerStatisticDefinitionRequest, CreatePlayerStatisticDefinitionResult>("Admin", "/Admin/CreatePlayerStatisticDefinition", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
        /// </summary>
        public static void DeleteUsers(DeleteUsersRequest request, Action<DeleteUsersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<DeleteUsersRequest, DeleteUsersResult>("Admin", "/Admin/DeleteUsers", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves a download URL for the requested report
        /// </summary>
        public static void GetDataReport(GetDataReportRequest request, Action<GetDataReportResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetDataReportRequest, GetDataReportResult>("Admin", "/Admin/GetDataReport", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the configuration information for all player statistics defined in the title, regardless of whether they have a reset interval.
        /// </summary>
        public static void GetPlayerStatisticDefinitions(GetPlayerStatisticDefinitionsRequest request, Action<GetPlayerStatisticDefinitionsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetPlayerStatisticDefinitionsRequest, GetPlayerStatisticDefinitionsResult>("Admin", "/Admin/GetPlayerStatisticDefinitions", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        public static void GetPlayerStatisticVersions(GetPlayerStatisticVersionsRequest request, Action<GetPlayerStatisticVersionsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetPlayerStatisticVersionsRequest, GetPlayerStatisticVersionsResult>("Admin", "/Admin/GetPlayerStatisticVersions", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserDataRequest, GetUserDataResult>("Admin", "/Admin/GetUserData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserInternalData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserDataRequest, GetUserDataResult>("Admin", "/Admin/GetUserInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserPublisherData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserDataRequest, GetUserDataResult>("Admin", "/Admin/GetUserPublisherData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserPublisherInternalData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserDataRequest, GetUserDataResult>("Admin", "/Admin/GetUserPublisherInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserPublisherReadOnlyData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserDataRequest, GetUserDataResult>("Admin", "/Admin/GetUserPublisherReadOnlyData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserReadOnlyData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserDataRequest, GetUserDataResult>("Admin", "/Admin/GetUserReadOnlyData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Resets the indicated statistic, removing all player entries for it and backing up the old values.
        /// </summary>
        public static void IncrementPlayerStatisticVersion(IncrementPlayerStatisticVersionRequest request, Action<IncrementPlayerStatisticVersionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<IncrementPlayerStatisticVersionRequest, IncrementPlayerStatisticVersionResult>("Admin", "/Admin/IncrementPlayerStatisticVersion", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Completely removes all statistics for the specified user, for the current game
        /// </summary>
        public static void ResetUserStatistics(ResetUserStatisticsRequest request, Action<ResetUserStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<ResetUserStatisticsRequest, ResetUserStatisticsResult>("Admin", "/Admin/ResetUserStatistics", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates a player statistic configuration for the title, optionally allowing the developer to specify a reset interval.
        /// </summary>
        public static void UpdatePlayerStatisticDefinition(UpdatePlayerStatisticDefinitionRequest request, Action<UpdatePlayerStatisticDefinitionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdatePlayerStatisticDefinitionRequest, UpdatePlayerStatisticDefinitionResult>("Admin", "/Admin/UpdatePlayerStatisticDefinition", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserDataRequest, UpdateUserDataResult>("Admin", "/Admin/UpdateUserData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserInternalData(UpdateUserInternalDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserInternalDataRequest, UpdateUserDataResult>("Admin", "/Admin/UpdateUserInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserPublisherData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserDataRequest, UpdateUserDataResult>("Admin", "/Admin/UpdateUserPublisherData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserPublisherInternalData(UpdateUserInternalDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserInternalDataRequest, UpdateUserDataResult>("Admin", "/Admin/UpdateUserPublisherInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserPublisherReadOnlyData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserDataRequest, UpdateUserDataResult>("Admin", "/Admin/UpdateUserPublisherReadOnlyData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserReadOnlyData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserDataRequest, UpdateUserDataResult>("Admin", "/Admin/UpdateUserReadOnlyData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds a new news item to the title's news feed
        /// </summary>
        public static void AddNews(AddNewsRequest request, Action<AddNewsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<AddNewsRequest, AddNewsResult>("Admin", "/Admin/AddNews", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds one or more virtual currencies to the set defined for the title. Virtual Currencies have a maximum value of 2,147,483,647 when granted to a player. Any value over that will be discarded.
        /// </summary>
        public static void AddVirtualCurrencyTypes(AddVirtualCurrencyTypesRequest request, Action<BlankResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<AddVirtualCurrencyTypesRequest, BlankResult>("Admin", "/Admin/AddVirtualCurrencyTypes", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static void GetCatalogItems(GetCatalogItemsRequest request, Action<GetCatalogItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetCatalogItemsRequest, GetCatalogItemsResult>("Admin", "/Admin/GetCatalogItems", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public static void GetPublisherData(GetPublisherDataRequest request, Action<GetPublisherDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetPublisherDataRequest, GetPublisherDataResult>("Admin", "/Admin/GetPublisherData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the random drop table configuration for the title
        /// </summary>
        public static void GetRandomResultTables(GetRandomResultTablesRequest request, Action<GetRandomResultTablesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetRandomResultTablesRequest, GetRandomResultTablesResult>("Admin", "/Admin/GetRandomResultTables", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        public static void GetStoreItems(GetStoreItemsRequest request, Action<GetStoreItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetStoreItemsRequest, GetStoreItemsResult>("Admin", "/Admin/GetStoreItems", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings which can be read by the client
        /// </summary>
        public static void GetTitleData(GetTitleDataRequest request, Action<GetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetTitleDataRequest, GetTitleDataResult>("Admin", "/Admin/GetTitleData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings which cannot be read by the client
        /// </summary>
        public static void GetTitleInternalData(GetTitleDataRequest request, Action<GetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetTitleDataRequest, GetTitleDataResult>("Admin", "/Admin/GetTitleInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retuns the list of all defined virtual currencies for the title
        /// </summary>
        public static void ListVirtualCurrencyTypes(ListVirtualCurrencyTypesRequest request, Action<ListVirtualCurrencyTypesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<ListVirtualCurrencyTypesRequest, ListVirtualCurrencyTypesResult>("Admin", "/Admin/ListVirtualCurrencyTypes", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Creates the catalog configuration of all virtual goods for the specified catalog version
        /// </summary>
        public static void SetCatalogItems(UpdateCatalogItemsRequest request, Action<UpdateCatalogItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateCatalogItemsRequest, UpdateCatalogItemsResult>("Admin", "/Admin/SetCatalogItems", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Sets all the items in one virtual store
        /// </summary>
        public static void SetStoreItems(UpdateStoreItemsRequest request, Action<UpdateStoreItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateStoreItemsRequest, UpdateStoreItemsResult>("Admin", "/Admin/SetStoreItems", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Creates and updates the key-value store of custom title settings which can be read by the client
        /// </summary>
        public static void SetTitleData(SetTitleDataRequest request, Action<SetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SetTitleDataRequest, SetTitleDataResult>("Admin", "/Admin/SetTitleData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom title settings which cannot be read by the client
        /// </summary>
        public static void SetTitleInternalData(SetTitleDataRequest request, Action<SetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SetTitleDataRequest, SetTitleDataResult>("Admin", "/Admin/SetTitleInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Sets the Amazon Resource Name (ARN) for iOS and Android push notifications. Documentation on the exact restrictions can be found at: http://docs.aws.amazon.com/sns/latest/api/API_CreatePlatformApplication.html. Currently, Amazon device Messaging is not supported.
        /// </summary>
        public static void SetupPushNotification(SetupPushNotificationRequest request, Action<SetupPushNotificationResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SetupPushNotificationRequest, SetupPushNotificationResult>("Admin", "/Admin/SetupPushNotification", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the catalog configuration for virtual goods in the specified catalog version
        /// </summary>
        public static void UpdateCatalogItems(UpdateCatalogItemsRequest request, Action<UpdateCatalogItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateCatalogItemsRequest, UpdateCatalogItemsResult>("Admin", "/Admin/UpdateCatalogItems", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the random drop table configuration for the title
        /// </summary>
        public static void UpdateRandomResultTables(UpdateRandomResultTablesRequest request, Action<UpdateRandomResultTablesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateRandomResultTablesRequest, UpdateRandomResultTablesResult>("Admin", "/Admin/UpdateRandomResultTables", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates an existing virtual item store with new or modified items
        /// </summary>
        public static void UpdateStoreItems(UpdateStoreItemsRequest request, Action<UpdateStoreItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateStoreItemsRequest, UpdateStoreItemsResult>("Admin", "/Admin/UpdateStoreItems", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Increments the specified virtual currency by the stated amount
        /// </summary>
        public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, Action<ModifyUserVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<AddUserVirtualCurrencyRequest, ModifyUserVirtualCurrencyResult>("Admin", "/Admin/AddUserVirtualCurrency", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        public static void GetUserInventory(GetUserInventoryRequest request, Action<GetUserInventoryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserInventoryRequest, GetUserInventoryResult>("Admin", "/Admin/GetUserInventory", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds the specified items to the specified user inventories
        /// </summary>
        public static void GrantItemsToUsers(GrantItemsToUsersRequest request, Action<GrantItemsToUsersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GrantItemsToUsersRequest, GrantItemsToUsersResult>("Admin", "/Admin/GrantItemsToUsers", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Revokes access to an item in a user's inventory
        /// </summary>
        public static void RevokeInventoryItem(RevokeInventoryItemRequest request, Action<RevokeInventoryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<RevokeInventoryItemRequest, RevokeInventoryResult>("Admin", "/Admin/RevokeInventoryItem", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Decrements the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, Action<ModifyUserVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SubtractUserVirtualCurrencyRequest, ModifyUserVirtualCurrencyResult>("Admin", "/Admin/SubtractUserVirtualCurrency", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the details for a specific completed session, including links to standard out and standard error logs
        /// </summary>
        public static void GetMatchmakerGameInfo(GetMatchmakerGameInfoRequest request, Action<GetMatchmakerGameInfoResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetMatchmakerGameInfoRequest, GetMatchmakerGameInfoResult>("Admin", "/Admin/GetMatchmakerGameInfo", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the details of defined game modes for the specified game server executable
        /// </summary>
        public static void GetMatchmakerGameModes(GetMatchmakerGameModesRequest request, Action<GetMatchmakerGameModesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetMatchmakerGameModesRequest, GetMatchmakerGameModesResult>("Admin", "/Admin/GetMatchmakerGameModes", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the game server mode details for the specified game server executable
        /// </summary>
        public static void ModifyMatchmakerGameModes(ModifyMatchmakerGameModesRequest request, Action<ModifyMatchmakerGameModesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<ModifyMatchmakerGameModesRequest, ModifyMatchmakerGameModesResult>("Admin", "/Admin/ModifyMatchmakerGameModes", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds the game server executable specified (previously uploaded - see GetServerBuildUploadUrl) to the set of those a client is permitted to request in a call to StartGame
        /// </summary>
        public static void AddServerBuild(AddServerBuildRequest request, Action<AddServerBuildResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<AddServerBuildRequest, AddServerBuildResult>("Admin", "/Admin/AddServerBuild", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the build details for the specified game server executable
        /// </summary>
        public static void GetServerBuildInfo(GetServerBuildInfoRequest request, Action<GetServerBuildInfoResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetServerBuildInfoRequest, GetServerBuildInfoResult>("Admin", "/Admin/GetServerBuildInfo", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the pre-authorized URL for uploading a game server package containing a build (does not enable the build for use - see AddServerBuild)
        /// </summary>
        public static void GetServerBuildUploadUrl(GetServerBuildUploadURLRequest request, Action<GetServerBuildUploadURLResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetServerBuildUploadURLRequest, GetServerBuildUploadURLResult>("Admin", "/Admin/GetServerBuildUploadUrl", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the build details for all game server executables which are currently defined for the title
        /// </summary>
        public static void ListServerBuilds(ListBuildsRequest request, Action<ListBuildsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<ListBuildsRequest, ListBuildsResult>("Admin", "/Admin/ListServerBuilds", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the build details for the specified game server executable
        /// </summary>
        public static void ModifyServerBuild(ModifyServerBuildRequest request, Action<ModifyServerBuildResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<ModifyServerBuildRequest, ModifyServerBuildResult>("Admin", "/Admin/ModifyServerBuild", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Removes the game server executable specified from the set of those a client is permitted to request in a call to StartGame
        /// </summary>
        public static void RemoveServerBuild(RemoveServerBuildRequest request, Action<RemoveServerBuildResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<RemoveServerBuildRequest, RemoveServerBuildResult>("Admin", "/Admin/RemoveServerBuild", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        public static void SetPublisherData(SetPublisherDataRequest request, Action<SetPublisherDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SetPublisherDataRequest, SetPublisherDataResult>("Admin", "/Admin/SetPublisherData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Gets the contents and information of a specific Cloud Script revision.
        /// </summary>
        public static void GetCloudScriptRevision(GetCloudScriptRevisionRequest request, Action<GetCloudScriptRevisionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetCloudScriptRevisionRequest, GetCloudScriptRevisionResult>("Admin", "/Admin/GetCloudScriptRevision", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Lists all the current cloud script versions. For each version, information about the current published and latest revisions is also listed.
        /// </summary>
        public static void GetCloudScriptVersions(GetCloudScriptVersionsRequest request, Action<GetCloudScriptVersionsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetCloudScriptVersionsRequest, GetCloudScriptVersionsResult>("Admin", "/Admin/GetCloudScriptVersions", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Sets the currently published revision of a title Cloud Script
        /// </summary>
        public static void SetPublishedRevision(SetPublishedRevisionRequest request, Action<SetPublishedRevisionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SetPublishedRevisionRequest, SetPublishedRevisionResult>("Admin", "/Admin/SetPublishedRevision", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Creates a new Cloud Script revision and uploads source code to it. Note that at this time, only one file should be submitted in the revision.
        /// </summary>
        public static void UpdateCloudScript(UpdateCloudScriptRequest request, Action<UpdateCloudScriptResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateCloudScriptRequest, UpdateCloudScriptResult>("Admin", "/Admin/UpdateCloudScript", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Delete a content file from the title
        /// </summary>
        public static void DeleteContent(DeleteContentRequest request, Action<BlankResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<DeleteContentRequest, BlankResult>("Admin", "/Admin/DeleteContent", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// List all contents of the title and get statistics such as size
        /// </summary>
        public static void GetContentList(GetContentListRequest request, Action<GetContentListResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetContentListRequest, GetContentListResult>("Admin", "/Admin/GetContentList", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the pre-signed URL for uploading a content file. A subsequent HTTP PUT to the returned URL uploads the content.
        /// </summary>
        public static void GetContentUploadUrl(GetContentUploadUrlRequest request, Action<GetContentUploadUrlResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetContentUploadUrlRequest, GetContentUploadUrlResult>("Admin", "/Admin/GetContentUploadUrl", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Completely removes all statistics for the specified character, for the current game
        /// </summary>
        public static void ResetCharacterStatistics(ResetCharacterStatisticsRequest request, Action<ResetCharacterStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<ResetCharacterStatisticsRequest, ResetCharacterStatisticsResult>("Admin", "/Admin/ResetCharacterStatistics", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }


    }
}
#endif
