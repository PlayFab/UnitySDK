#if !DISABLE_PLAYFABENTITY_API
using PlayFab.InsightsModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<InsightsEmptyRequest> OnInsightsGetDetailsRequestEvent;
        public event PlayFabResultEvent<InsightsGetDetailsResponse> OnInsightsGetDetailsResultEvent;
        public event PlayFabRequestEvent<InsightsEmptyRequest> OnInsightsGetLimitsRequestEvent;
        public event PlayFabResultEvent<InsightsGetLimitsResponse> OnInsightsGetLimitsResultEvent;
        public event PlayFabRequestEvent<InsightsGetOperationStatusRequest> OnInsightsGetOperationStatusRequestEvent;
        public event PlayFabResultEvent<InsightsGetOperationStatusResponse> OnInsightsGetOperationStatusResultEvent;
        public event PlayFabRequestEvent<InsightsGetPendingOperationsRequest> OnInsightsGetPendingOperationsRequestEvent;
        public event PlayFabResultEvent<InsightsGetPendingOperationsResponse> OnInsightsGetPendingOperationsResultEvent;
        public event PlayFabRequestEvent<InsightsSetPerformanceRequest> OnInsightsSetPerformanceRequestEvent;
        public event PlayFabResultEvent<InsightsOperationResponse> OnInsightsSetPerformanceResultEvent;
        public event PlayFabRequestEvent<InsightsSetStorageRetentionRequest> OnInsightsSetStorageRetentionRequestEvent;
        public event PlayFabResultEvent<InsightsOperationResponse> OnInsightsSetStorageRetentionResultEvent;
    }
}
#endif
