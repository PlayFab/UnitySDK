#if !DISABLE_PLAYFABENTITY_API
using PlayFab.EconomyModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<CreateDraftItemRequest> OnEconomyCreateDraftItemRequestEvent;
        public event PlayFabResultEvent<CreateDraftItemResponse> OnEconomyCreateDraftItemResultEvent;
        public event PlayFabRequestEvent<CreateUploadUrlsRequest> OnEconomyCreateUploadUrlsRequestEvent;
        public event PlayFabResultEvent<CreateUploadUrlsResponse> OnEconomyCreateUploadUrlsResultEvent;
        public event PlayFabRequestEvent<DeleteEntityItemReviewsRequest> OnEconomyDeleteEntityItemReviewsRequestEvent;
        public event PlayFabResultEvent<DeleteEntityItemReviewsResponse> OnEconomyDeleteEntityItemReviewsResultEvent;
        public event PlayFabRequestEvent<DeleteItemRequest> OnEconomyDeleteItemRequestEvent;
        public event PlayFabResultEvent<DeleteItemResponse> OnEconomyDeleteItemResultEvent;
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
        public event PlayFabRequestEvent<GetItemRequest> OnEconomyGetItemRequestEvent;
        public event PlayFabResultEvent<GetItemResponse> OnEconomyGetItemResultEvent;
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
        public event PlayFabRequestEvent<PublishDraftItemRequest> OnEconomyPublishDraftItemRequestEvent;
        public event PlayFabResultEvent<PublishDraftItemResponse> OnEconomyPublishDraftItemResultEvent;
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
        public event PlayFabRequestEvent<TakedownItemReviewsRequest> OnEconomyTakedownItemReviewsRequestEvent;
        public event PlayFabResultEvent<TakedownItemReviewsResponse> OnEconomyTakedownItemReviewsResultEvent;
        public event PlayFabRequestEvent<UpdateCatalogConfigRequest> OnEconomyUpdateCatalogConfigRequestEvent;
        public event PlayFabResultEvent<UpdateCatalogConfigResponse> OnEconomyUpdateCatalogConfigResultEvent;
        public event PlayFabRequestEvent<UpdateDraftItemRequest> OnEconomyUpdateDraftItemRequestEvent;
        public event PlayFabResultEvent<UpdateDraftItemResponse> OnEconomyUpdateDraftItemResultEvent;
    }
}
#endif
