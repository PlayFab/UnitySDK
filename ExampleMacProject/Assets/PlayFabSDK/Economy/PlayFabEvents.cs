#if !DISABLE_PLAYFABENTITY_API
using PlayFab.EconomyModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<AddInventoryItemsRequest> OnEconomyAddInventoryItemsRequestEvent;
        public event PlayFabResultEvent<AddInventoryItemsResponse> OnEconomyAddInventoryItemsResultEvent;
        public event PlayFabRequestEvent<CreateDraftItemRequest> OnEconomyCreateDraftItemRequestEvent;
        public event PlayFabResultEvent<CreateDraftItemResponse> OnEconomyCreateDraftItemResultEvent;
        public event PlayFabRequestEvent<CreateUploadUrlsRequest> OnEconomyCreateUploadUrlsRequestEvent;
        public event PlayFabResultEvent<CreateUploadUrlsResponse> OnEconomyCreateUploadUrlsResultEvent;
        public event PlayFabRequestEvent<DeleteEntityItemReviewsRequest> OnEconomyDeleteEntityItemReviewsRequestEvent;
        public event PlayFabResultEvent<DeleteEntityItemReviewsResponse> OnEconomyDeleteEntityItemReviewsResultEvent;
        public event PlayFabRequestEvent<DeleteInventoryCollectionRequest> OnEconomyDeleteInventoryCollectionRequestEvent;
        public event PlayFabResultEvent<DeleteInventoryCollectionResponse> OnEconomyDeleteInventoryCollectionResultEvent;
        public event PlayFabRequestEvent<DeleteInventoryItemsRequest> OnEconomyDeleteInventoryItemsRequestEvent;
        public event PlayFabResultEvent<DeleteInventoryItemsResponse> OnEconomyDeleteInventoryItemsResultEvent;
        public event PlayFabRequestEvent<DeleteItemRequest> OnEconomyDeleteItemRequestEvent;
        public event PlayFabResultEvent<DeleteItemResponse> OnEconomyDeleteItemResultEvent;
        public event PlayFabRequestEvent<ExecuteInventoryOperationsRequest> OnEconomyExecuteInventoryOperationsRequestEvent;
        public event PlayFabResultEvent<ExecuteInventoryOperationsResponse> OnEconomyExecuteInventoryOperationsResultEvent;
        public event PlayFabRequestEvent<GetCatalogConfigRequest> OnEconomyGetCatalogConfigRequestEvent;
        public event PlayFabResultEvent<GetCatalogConfigResponse> OnEconomyGetCatalogConfigResultEvent;
        public event PlayFabRequestEvent<GetDraftItemRequest> OnEconomyGetDraftItemRequestEvent;
        public event PlayFabResultEvent<GetDraftItemResponse> OnEconomyGetDraftItemResultEvent;
        public event PlayFabRequestEvent<GetDraftItemsRequest> OnEconomyGetDraftItemsRequestEvent;
        public event PlayFabResultEvent<GetDraftItemsResponse> OnEconomyGetDraftItemsResultEvent;
        public event PlayFabRequestEvent<GetEntityDraftItemsRequest> OnEconomyGetEntityDraftItemsRequestEvent;
        public event PlayFabResultEvent<GetEntityDraftItemsResponse> OnEconomyGetEntityDraftItemsResultEvent;
        public event PlayFabRequestEvent<GetEntityItemReviewRequest> OnEconomyGetEntityItemReviewRequestEvent;
        public event PlayFabResultEvent<GetEntityItemReviewResponse> OnEconomyGetEntityItemReviewResultEvent;
        public event PlayFabRequestEvent<GetInventoryCollectionIdsRequest> OnEconomyGetInventoryCollectionIdsRequestEvent;
        public event PlayFabResultEvent<GetInventoryCollectionIdsResponse> OnEconomyGetInventoryCollectionIdsResultEvent;
        public event PlayFabRequestEvent<GetInventoryItemsRequest> OnEconomyGetInventoryItemsRequestEvent;
        public event PlayFabResultEvent<GetInventoryItemsResponse> OnEconomyGetInventoryItemsResultEvent;
        public event PlayFabRequestEvent<GetItemRequest> OnEconomyGetItemRequestEvent;
        public event PlayFabResultEvent<GetItemResponse> OnEconomyGetItemResultEvent;
        public event PlayFabRequestEvent<GetItemContainersRequest> OnEconomyGetItemContainersRequestEvent;
        public event PlayFabResultEvent<GetItemContainersResponse> OnEconomyGetItemContainersResultEvent;
        public event PlayFabRequestEvent<GetItemModerationStateRequest> OnEconomyGetItemModerationStateRequestEvent;
        public event PlayFabResultEvent<GetItemModerationStateResponse> OnEconomyGetItemModerationStateResultEvent;
        public event PlayFabRequestEvent<GetItemPublishStatusRequest> OnEconomyGetItemPublishStatusRequestEvent;
        public event PlayFabResultEvent<GetItemPublishStatusResponse> OnEconomyGetItemPublishStatusResultEvent;
        public event PlayFabRequestEvent<GetItemReviewsRequest> OnEconomyGetItemReviewsRequestEvent;
        public event PlayFabResultEvent<GetItemReviewsResponse> OnEconomyGetItemReviewsResultEvent;
        public event PlayFabRequestEvent<GetItemReviewSummaryRequest> OnEconomyGetItemReviewSummaryRequestEvent;
        public event PlayFabResultEvent<GetItemReviewSummaryResponse> OnEconomyGetItemReviewSummaryResultEvent;
        public event PlayFabRequestEvent<GetItemsRequest> OnEconomyGetItemsRequestEvent;
        public event PlayFabResultEvent<GetItemsResponse> OnEconomyGetItemsResultEvent;
        public event PlayFabRequestEvent<GetMicrosoftStoreAccessTokensRequest> OnEconomyGetMicrosoftStoreAccessTokensRequestEvent;
        public event PlayFabResultEvent<GetMicrosoftStoreAccessTokensResponse> OnEconomyGetMicrosoftStoreAccessTokensResultEvent;
        public event PlayFabRequestEvent<PublishDraftItemRequest> OnEconomyPublishDraftItemRequestEvent;
        public event PlayFabResultEvent<PublishDraftItemResponse> OnEconomyPublishDraftItemResultEvent;
        public event PlayFabRequestEvent<PurchaseInventoryItemsRequest> OnEconomyPurchaseInventoryItemsRequestEvent;
        public event PlayFabResultEvent<PurchaseInventoryItemsResponse> OnEconomyPurchaseInventoryItemsResultEvent;
        public event PlayFabRequestEvent<RedeemAppleAppStoreInventoryItemsRequest> OnEconomyRedeemAppleAppStoreInventoryItemsRequestEvent;
        public event PlayFabResultEvent<RedeemAppleAppStoreInventoryItemsResponse> OnEconomyRedeemAppleAppStoreInventoryItemsResultEvent;
        public event PlayFabRequestEvent<RedeemGooglePlayInventoryItemsRequest> OnEconomyRedeemGooglePlayInventoryItemsRequestEvent;
        public event PlayFabResultEvent<RedeemGooglePlayInventoryItemsResponse> OnEconomyRedeemGooglePlayInventoryItemsResultEvent;
        public event PlayFabRequestEvent<RedeemMicrosoftStoreInventoryItemsRequest> OnEconomyRedeemMicrosoftStoreInventoryItemsRequestEvent;
        public event PlayFabResultEvent<RedeemMicrosoftStoreInventoryItemsResponse> OnEconomyRedeemMicrosoftStoreInventoryItemsResultEvent;
        public event PlayFabRequestEvent<RedeemNintendoEShopInventoryItemsRequest> OnEconomyRedeemNintendoEShopInventoryItemsRequestEvent;
        public event PlayFabResultEvent<RedeemNintendoEShopInventoryItemsResponse> OnEconomyRedeemNintendoEShopInventoryItemsResultEvent;
        public event PlayFabRequestEvent<RedeemPlayStationStoreInventoryItemsRequest> OnEconomyRedeemPlayStationStoreInventoryItemsRequestEvent;
        public event PlayFabResultEvent<RedeemPlayStationStoreInventoryItemsResponse> OnEconomyRedeemPlayStationStoreInventoryItemsResultEvent;
        public event PlayFabRequestEvent<RedeemSteamInventoryItemsRequest> OnEconomyRedeemSteamInventoryItemsRequestEvent;
        public event PlayFabResultEvent<RedeemSteamInventoryItemsResponse> OnEconomyRedeemSteamInventoryItemsResultEvent;
        public event PlayFabRequestEvent<ReportItemRequest> OnEconomyReportItemRequestEvent;
        public event PlayFabResultEvent<ReportItemResponse> OnEconomyReportItemResultEvent;
        public event PlayFabRequestEvent<ReportItemReviewRequest> OnEconomyReportItemReviewRequestEvent;
        public event PlayFabResultEvent<ReportItemReviewResponse> OnEconomyReportItemReviewResultEvent;
        public event PlayFabRequestEvent<ReviewItemRequest> OnEconomyReviewItemRequestEvent;
        public event PlayFabResultEvent<ReviewItemResponse> OnEconomyReviewItemResultEvent;
        public event PlayFabRequestEvent<SearchItemsRequest> OnEconomySearchItemsRequestEvent;
        public event PlayFabResultEvent<SearchItemsResponse> OnEconomySearchItemsResultEvent;
        public event PlayFabRequestEvent<SetItemModerationStateRequest> OnEconomySetItemModerationStateRequestEvent;
        public event PlayFabResultEvent<SetItemModerationStateResponse> OnEconomySetItemModerationStateResultEvent;
        public event PlayFabRequestEvent<SubmitItemReviewVoteRequest> OnEconomySubmitItemReviewVoteRequestEvent;
        public event PlayFabResultEvent<SubmitItemReviewVoteResponse> OnEconomySubmitItemReviewVoteResultEvent;
        public event PlayFabRequestEvent<SubtractInventoryItemsRequest> OnEconomySubtractInventoryItemsRequestEvent;
        public event PlayFabResultEvent<SubtractInventoryItemsResponse> OnEconomySubtractInventoryItemsResultEvent;
        public event PlayFabRequestEvent<TakedownItemReviewsRequest> OnEconomyTakedownItemReviewsRequestEvent;
        public event PlayFabResultEvent<TakedownItemReviewsResponse> OnEconomyTakedownItemReviewsResultEvent;
        public event PlayFabRequestEvent<TransferInventoryItemsRequest> OnEconomyTransferInventoryItemsRequestEvent;
        public event PlayFabResultEvent<TransferInventoryItemsResponse> OnEconomyTransferInventoryItemsResultEvent;
        public event PlayFabRequestEvent<UpdateCatalogConfigRequest> OnEconomyUpdateCatalogConfigRequestEvent;
        public event PlayFabResultEvent<UpdateCatalogConfigResponse> OnEconomyUpdateCatalogConfigResultEvent;
        public event PlayFabRequestEvent<UpdateDraftItemRequest> OnEconomyUpdateDraftItemRequestEvent;
        public event PlayFabResultEvent<UpdateDraftItemResponse> OnEconomyUpdateDraftItemResultEvent;
        public event PlayFabRequestEvent<UpdateInventoryItemsRequest> OnEconomyUpdateInventoryItemsRequestEvent;
        public event PlayFabResultEvent<UpdateInventoryItemsResponse> OnEconomyUpdateInventoryItemsResultEvent;
    }
}
#endif
