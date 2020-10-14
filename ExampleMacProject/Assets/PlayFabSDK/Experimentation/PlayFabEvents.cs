#if !DISABLE_PLAYFABENTITY_API
using PlayFab.ExperimentationModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<CreateExclusionGroupRequest> OnExperimentationCreateExclusionGroupRequestEvent;
        public event PlayFabResultEvent<CreateExclusionGroupResult> OnExperimentationCreateExclusionGroupResultEvent;
        public event PlayFabRequestEvent<CreateExperimentRequest> OnExperimentationCreateExperimentRequestEvent;
        public event PlayFabResultEvent<CreateExperimentResult> OnExperimentationCreateExperimentResultEvent;
        public event PlayFabRequestEvent<DeleteExclusionGroupRequest> OnExperimentationDeleteExclusionGroupRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnExperimentationDeleteExclusionGroupResultEvent;
        public event PlayFabRequestEvent<DeleteExperimentRequest> OnExperimentationDeleteExperimentRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnExperimentationDeleteExperimentResultEvent;
        public event PlayFabRequestEvent<GetExclusionGroupsRequest> OnExperimentationGetExclusionGroupsRequestEvent;
        public event PlayFabResultEvent<GetExclusionGroupsResult> OnExperimentationGetExclusionGroupsResultEvent;
        public event PlayFabRequestEvent<GetExclusionGroupTrafficRequest> OnExperimentationGetExclusionGroupTrafficRequestEvent;
        public event PlayFabResultEvent<GetExclusionGroupTrafficResult> OnExperimentationGetExclusionGroupTrafficResultEvent;
        public event PlayFabRequestEvent<GetExperimentsRequest> OnExperimentationGetExperimentsRequestEvent;
        public event PlayFabResultEvent<GetExperimentsResult> OnExperimentationGetExperimentsResultEvent;
        public event PlayFabRequestEvent<GetLatestScorecardRequest> OnExperimentationGetLatestScorecardRequestEvent;
        public event PlayFabResultEvent<GetLatestScorecardResult> OnExperimentationGetLatestScorecardResultEvent;
        public event PlayFabRequestEvent<GetTreatmentAssignmentRequest> OnExperimentationGetTreatmentAssignmentRequestEvent;
        public event PlayFabResultEvent<GetTreatmentAssignmentResult> OnExperimentationGetTreatmentAssignmentResultEvent;
        public event PlayFabRequestEvent<StartExperimentRequest> OnExperimentationStartExperimentRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnExperimentationStartExperimentResultEvent;
        public event PlayFabRequestEvent<StopExperimentRequest> OnExperimentationStopExperimentRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnExperimentationStopExperimentResultEvent;
        public event PlayFabRequestEvent<UpdateExclusionGroupRequest> OnExperimentationUpdateExclusionGroupRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnExperimentationUpdateExclusionGroupResultEvent;
        public event PlayFabRequestEvent<UpdateExperimentRequest> OnExperimentationUpdateExperimentRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnExperimentationUpdateExperimentResultEvent;
    }
}
#endif
