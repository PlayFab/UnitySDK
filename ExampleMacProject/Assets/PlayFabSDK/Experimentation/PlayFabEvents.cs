#if !DISABLE_PLAYFABENTITY_API
using PlayFab.ExperimentationModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<CreateExperimentRequest> OnExperimentationCreateExperimentRequestEvent;
        public event PlayFabResultEvent<CreateExperimentResult> OnExperimentationCreateExperimentResultEvent;
        public event PlayFabRequestEvent<DeleteExperimentRequest> OnExperimentationDeleteExperimentRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnExperimentationDeleteExperimentResultEvent;
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
        public event PlayFabRequestEvent<UpdateExperimentRequest> OnExperimentationUpdateExperimentRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnExperimentationUpdateExperimentResultEvent;
    }
}
#endif
