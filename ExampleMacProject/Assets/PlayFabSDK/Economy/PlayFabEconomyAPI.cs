#if !DISABLE_PLAYFABENTITY_API && !DISABLE_PLAYFAB_STATIC_API

using System;
using System.Collections.Generic;
using PlayFab.EconomyModels;
using PlayFab.Internal;

namespace PlayFab
{
    /// <summary>
    /// API methods for managing the catalog. Inventory manages in-game assets for any given entity.
    /// </summary>
    public static class PlayFabEconomyAPI
    {
        static PlayFabEconomyAPI() {}


        /// <summary>
        /// Verify entity login.
        /// </summary>
        public static bool IsEntityLoggedIn()
        {
            return PlayFabSettings.staticPlayer.IsEntityLoggedIn();
        }

        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabSettings.staticPlayer.ForgetAllCredentials();
        }

        /// <summary>
        /// Add inventory items. Up to 3500 stacks of items can be added to a single inventory collection. Stack size is uncapped.
        /// </summary>
        public static void AddInventoryItems(AddInventoryItemsRequest request, Action<AddInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/AddInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Creates a new item in the working catalog using provided metadata.
        /// </summary>
        public static void CreateDraftItem(CreateDraftItemRequest request, Action<CreateDraftItemResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/CreateDraftItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Creates one or more upload URLs which can be used by the client to upload raw file data. Content URls and uploaded
        /// content will be garbage collected after 24 hours if not attached to a draft or published item. Detailed pricing info
        /// around uploading content can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/pricing/meters/catalog-meters
        /// </summary>
        public static void CreateUploadUrls(CreateUploadUrlsRequest request, Action<CreateUploadUrlsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/CreateUploadUrls", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Deletes all reviews, helpfulness votes, and ratings submitted by the entity specified.
        /// </summary>
        public static void DeleteEntityItemReviews(DeleteEntityItemReviewsRequest request, Action<DeleteEntityItemReviewsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/DeleteEntityItemReviews", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Delete an Inventory Collection. More information about Inventory Collections can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/inventory/collections
        /// </summary>
        public static void DeleteInventoryCollection(DeleteInventoryCollectionRequest request, Action<DeleteInventoryCollectionResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/DeleteInventoryCollection", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Delete inventory items
        /// </summary>
        public static void DeleteInventoryItems(DeleteInventoryItemsRequest request, Action<DeleteInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/DeleteInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Removes an item from working catalog and all published versions from the public catalog.
        /// </summary>
        public static void DeleteItem(DeleteItemRequest request, Action<DeleteItemResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/DeleteItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Execute a list of Inventory Operations. A maximum list of 10 operations can be performed by a single request. There is
        /// also a limit to 250 items that can be modified/added in a single request. For example, adding a bundle with 50 items
        /// counts as 50 items modified. All operations must be done within a single inventory collection. This API has a reduced
        /// RPS compared to an individual inventory operation with Player Entities limited to 15 requests in 90 seconds and Title
        /// Entities limited to 500 requests in 10 seconds.
        /// </summary>
        public static void ExecuteInventoryOperations(ExecuteInventoryOperationsRequest request, Action<ExecuteInventoryOperationsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/ExecuteInventoryOperations", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Gets the configuration for the catalog. Only Title Entities can call this API. There is a limit of 100 requests in 10
        /// seconds for this API. More information about the Catalog Config can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/settings
        /// </summary>
        public static void GetCatalogConfig(GetCatalogConfigRequest request, Action<GetCatalogConfigResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/GetCatalogConfig", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves an item from the working catalog. This item represents the current working state of the item. GetDraftItem
        /// does not work off a cache of the Catalog and should be used when trying to get recent item updates. However, please note
        /// that item references data is cached and may take a few moments for changes to propagate.
        /// </summary>
        public static void GetDraftItem(GetDraftItemRequest request, Action<GetDraftItemResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/GetDraftItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves a paginated list of the items from the draft catalog. Up to 50 IDs can be retrieved in a single request.
        /// GetDraftItems does not work off a cache of the Catalog and should be used when trying to get recent item updates.
        /// </summary>
        public static void GetDraftItems(GetDraftItemsRequest request, Action<GetDraftItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/GetDraftItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves a paginated list of the items from the draft catalog created by the Entity. Up to 50 items can be returned at
        /// once. You can use continuation tokens to paginate through results that return greater than the limit.
        /// GetEntityDraftItems does not work off a cache of the Catalog and should be used when trying to get recent item updates.
        /// </summary>
        public static void GetEntityDraftItems(GetEntityDraftItemsRequest request, Action<GetEntityDraftItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/GetEntityDraftItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Gets the submitted review for the specified item by the authenticated entity. Individual ratings and reviews data update
        /// in near real time with delays within a few seconds.
        /// </summary>
        public static void GetEntityItemReview(GetEntityItemReviewRequest request, Action<GetEntityItemReviewResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/GetEntityItemReview", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Get Inventory Collection Ids. Up to 50 Ids can be returned at once. You can use continuation tokens to paginate through
        /// results that return greater than the limit. It can take a few seconds for new collection Ids to show up.
        /// </summary>
        public static void GetInventoryCollectionIds(GetInventoryCollectionIdsRequest request, Action<GetInventoryCollectionIdsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/GetInventoryCollectionIds", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Get current inventory items.
        /// </summary>
        public static void GetInventoryItems(GetInventoryItemsRequest request, Action<GetInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/GetInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves an item from the public catalog. GetItem does not work off a cache of the Catalog and should be used when
        /// trying to get recent item updates. However, please note that item references data is cached and may take a few moments
        /// for changes to propagate.
        /// </summary>
        public static void GetItem(GetItemRequest request, Action<GetItemResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/GetItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Search for a given item and return a set of bundles and stores containing the item. Up to 50 items can be returned at
        /// once. You can use continuation tokens to paginate through results that return greater than the limit. This API is
        /// intended for tooling/automation scenarios and has a reduced RPS with Player Entities limited to 30 requests in 300
        /// seconds and Title Entities limited to 100 requests in 10 seconds.
        /// </summary>
        public static void GetItemContainers(GetItemContainersRequest request, Action<GetItemContainersResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/GetItemContainers", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Gets the moderation state for an item, including the concern category and string reason. More information about
        /// moderation states can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/ugc/moderation
        /// </summary>
        public static void GetItemModerationState(GetItemModerationStateRequest request, Action<GetItemModerationStateResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/GetItemModerationState", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Gets the status of a publish of an item.
        /// </summary>
        public static void GetItemPublishStatus(GetItemPublishStatusRequest request, Action<GetItemPublishStatusResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/GetItemPublishStatus", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Get a paginated set of reviews associated with the specified item. Individual ratings and reviews data update in near
        /// real time with delays within a few seconds.
        /// </summary>
        public static void GetItemReviews(GetItemReviewsRequest request, Action<GetItemReviewsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/GetItemReviews", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Get a summary of all ratings and reviews associated with the specified item. Summary ratings data is cached with update
        /// data coming within 15 minutes.
        /// </summary>
        public static void GetItemReviewSummary(GetItemReviewSummaryRequest request, Action<GetItemReviewSummaryResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/GetItemReviewSummary", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Retrieves items from the public catalog. Up to 50 items can be returned at once. GetItems does not work off a cache of
        /// the Catalog and should be used when trying to get recent item updates. However, please note that item references data is
        /// cached and may take a few moments for changes to propagate.
        /// </summary>
        public static void GetItems(GetItemsRequest request, Action<GetItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/GetItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Gets the access tokens.
        /// </summary>
        public static void GetMicrosoftStoreAccessTokens(GetMicrosoftStoreAccessTokensRequest request, Action<GetMicrosoftStoreAccessTokensResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/GetMicrosoftStoreAccessTokens", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Get transaction history for a player. Up to 50 Events can be returned at once. You can use continuation tokens to
        /// paginate through results that return greater than the limit. Getting transaction history has a lower RPS limit than
        /// getting a Player's inventory with Player Entities having a limit of 30 requests in 300 seconds and Title Entities having
        /// a limit of 100 requests in 10 seconds.
        /// </summary>
        public static void GetTransactionHistory(GetTransactionHistoryRequest request, Action<GetTransactionHistoryResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/GetTransactionHistory", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Initiates a publish of an item from the working catalog to the public catalog. You can use the GetItemPublishStatus API
        /// to track the state of the item publish.
        /// </summary>
        public static void PublishDraftItem(PublishDraftItemRequest request, Action<PublishDraftItemResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/PublishDraftItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Purchase an item or bundle. Up to 3500 stacks of items can be added to a single inventory collection. Stack size is
        /// uncapped.
        /// </summary>
        public static void PurchaseInventoryItems(PurchaseInventoryItemsRequest request, Action<PurchaseInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/PurchaseInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        public static void RedeemAppleAppStoreInventoryItems(RedeemAppleAppStoreInventoryItemsRequest request, Action<RedeemAppleAppStoreInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/RedeemAppleAppStoreInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        public static void RedeemGooglePlayInventoryItems(RedeemGooglePlayInventoryItemsRequest request, Action<RedeemGooglePlayInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/RedeemGooglePlayInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        public static void RedeemMicrosoftStoreInventoryItems(RedeemMicrosoftStoreInventoryItemsRequest request, Action<RedeemMicrosoftStoreInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/RedeemMicrosoftStoreInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        public static void RedeemNintendoEShopInventoryItems(RedeemNintendoEShopInventoryItemsRequest request, Action<RedeemNintendoEShopInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/RedeemNintendoEShopInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        public static void RedeemPlayStationStoreInventoryItems(RedeemPlayStationStoreInventoryItemsRequest request, Action<RedeemPlayStationStoreInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/RedeemPlayStationStoreInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        public static void RedeemSteamInventoryItems(RedeemSteamInventoryItemsRequest request, Action<RedeemSteamInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/RedeemSteamInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Submit a report for an item, indicating in what way the item is inappropriate.
        /// </summary>
        public static void ReportItem(ReportItemRequest request, Action<ReportItemResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/ReportItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Submit a report for a review
        /// </summary>
        public static void ReportItemReview(ReportItemReviewRequest request, Action<ReportItemReviewResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/ReportItemReview", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Creates or updates a review for the specified item. More information around the caching surrounding item ratings and
        /// reviews can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/ratings#ratings-design-and-caching
        /// </summary>
        public static void ReviewItem(ReviewItemRequest request, Action<ReviewItemResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/ReviewItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Executes a search against the public catalog using the provided search parameters and returns a set of paginated
        /// results. SearchItems uses a cache of the catalog with item updates taking up to a few minutes to propagate. You should
        /// use the GetItem API for when trying to immediately get recent item updates. More information about the Search API can be
        /// found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/search
        /// </summary>
        public static void SearchItems(SearchItemsRequest request, Action<SearchItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/SearchItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Sets the moderation state for an item, including the concern category and string reason. More information about
        /// moderation states can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/ugc/moderation
        /// </summary>
        public static void SetItemModerationState(SetItemModerationStateRequest request, Action<SetItemModerationStateResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/SetItemModerationState", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Submit a vote for a review, indicating whether the review was helpful or unhelpful.
        /// </summary>
        public static void SubmitItemReviewVote(SubmitItemReviewVoteRequest request, Action<SubmitItemReviewVoteResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/SubmitItemReviewVote", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Subtract inventory items.
        /// </summary>
        public static void SubtractInventoryItems(SubtractInventoryItemsRequest request, Action<SubtractInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/SubtractInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Submit a request to takedown one or more reviews.
        /// </summary>
        public static void TakedownItemReviews(TakedownItemReviewsRequest request, Action<TakedownItemReviewsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/TakedownItemReviews", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Transfer inventory items. When transferring across collections, a 202 response indicates that the transfer did not
        /// complete within the timeframe of the request. You can identify the pending operations by looking for OperationStatus =
        /// 'InProgress'. You can check on the operation status at anytime within 30 days of the request by passing the
        /// TransactionToken to the GetInventoryOperationStatus API. More information about item transfer scenarios can be found
        /// here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/inventory/?tabs=inventory-game-manager#transfer-inventory-items
        /// </summary>
        public static void TransferInventoryItems(TransferInventoryItemsRequest request, Action<TransferInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/TransferInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Updates the configuration for the catalog. Only Title Entities can call this API. There is a limit of 10 requests in 10
        /// seconds for this API. More information about the Catalog Config can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/settings
        /// </summary>
        public static void UpdateCatalogConfig(UpdateCatalogConfigRequest request, Action<UpdateCatalogConfigResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/UpdateCatalogConfig", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Update the metadata for an item in the working catalog.
        /// </summary>
        public static void UpdateDraftItem(UpdateDraftItemRequest request, Action<UpdateDraftItemResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Catalog/UpdateDraftItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }

        /// <summary>
        /// Update inventory items
        /// </summary>
        public static void UpdateInventoryItems(UpdateInventoryItemsRequest request, Action<UpdateInventoryItemsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? PlayFabSettings.staticPlayer;
            var callSettings = PlayFabSettings.staticSettings;
            if (!context.IsEntityLoggedIn()) throw new PlayFabException(PlayFabExceptionCode.NotLoggedIn,"Must be logged in to call this method");


            PlayFabHttp.MakeApiCall("/Inventory/UpdateInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, callSettings);
        }


    }
}

#endif
