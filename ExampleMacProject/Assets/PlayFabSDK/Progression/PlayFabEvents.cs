#if !DISABLE_PLAYFABENTITY_API
using PlayFab.ProgressionModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<CreateLeaderboardDefinitionRequest> OnProgressionCreateLeaderboardDefinitionRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnProgressionCreateLeaderboardDefinitionResultEvent;
        public event PlayFabRequestEvent<CreateStatisticDefinitionRequest> OnProgressionCreateStatisticDefinitionRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnProgressionCreateStatisticDefinitionResultEvent;
        public event PlayFabRequestEvent<DeleteLeaderboardDefinitionRequest> OnProgressionDeleteLeaderboardDefinitionRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnProgressionDeleteLeaderboardDefinitionResultEvent;
        public event PlayFabRequestEvent<DeleteLeaderboardEntriesRequest> OnProgressionDeleteLeaderboardEntriesRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnProgressionDeleteLeaderboardEntriesResultEvent;
        public event PlayFabRequestEvent<DeleteStatisticDefinitionRequest> OnProgressionDeleteStatisticDefinitionRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnProgressionDeleteStatisticDefinitionResultEvent;
        public event PlayFabRequestEvent<DeleteStatisticsRequest> OnProgressionDeleteStatisticsRequestEvent;
        public event PlayFabResultEvent<DeleteStatisticsResponse> OnProgressionDeleteStatisticsResultEvent;
        public event PlayFabRequestEvent<GetFriendLeaderboardForEntityRequest> OnProgressionGetFriendLeaderboardForEntityRequestEvent;
        public event PlayFabResultEvent<GetEntityLeaderboardResponse> OnProgressionGetFriendLeaderboardForEntityResultEvent;
        public event PlayFabRequestEvent<GetEntityLeaderboardRequest> OnProgressionGetLeaderboardRequestEvent;
        public event PlayFabResultEvent<GetEntityLeaderboardResponse> OnProgressionGetLeaderboardResultEvent;
        public event PlayFabRequestEvent<GetLeaderboardAroundEntityRequest> OnProgressionGetLeaderboardAroundEntityRequestEvent;
        public event PlayFabResultEvent<GetEntityLeaderboardResponse> OnProgressionGetLeaderboardAroundEntityResultEvent;
        public event PlayFabRequestEvent<GetLeaderboardDefinitionRequest> OnProgressionGetLeaderboardDefinitionRequestEvent;
        public event PlayFabResultEvent<GetLeaderboardDefinitionResponse> OnProgressionGetLeaderboardDefinitionResultEvent;
        public event PlayFabRequestEvent<GetLeaderboardForEntitiesRequest> OnProgressionGetLeaderboardForEntitiesRequestEvent;
        public event PlayFabResultEvent<GetEntityLeaderboardResponse> OnProgressionGetLeaderboardForEntitiesResultEvent;
        public event PlayFabRequestEvent<GetStatisticDefinitionRequest> OnProgressionGetStatisticDefinitionRequestEvent;
        public event PlayFabResultEvent<GetStatisticDefinitionResponse> OnProgressionGetStatisticDefinitionResultEvent;
        public event PlayFabRequestEvent<GetStatisticsRequest> OnProgressionGetStatisticsRequestEvent;
        public event PlayFabResultEvent<GetStatisticsResponse> OnProgressionGetStatisticsResultEvent;
        public event PlayFabRequestEvent<GetStatisticsForEntitiesRequest> OnProgressionGetStatisticsForEntitiesRequestEvent;
        public event PlayFabResultEvent<GetStatisticsForEntitiesResponse> OnProgressionGetStatisticsForEntitiesResultEvent;
        public event PlayFabRequestEvent<IncrementLeaderboardVersionRequest> OnProgressionIncrementLeaderboardVersionRequestEvent;
        public event PlayFabResultEvent<IncrementLeaderboardVersionResponse> OnProgressionIncrementLeaderboardVersionResultEvent;
        public event PlayFabRequestEvent<IncrementStatisticVersionRequest> OnProgressionIncrementStatisticVersionRequestEvent;
        public event PlayFabResultEvent<IncrementStatisticVersionResponse> OnProgressionIncrementStatisticVersionResultEvent;
        public event PlayFabRequestEvent<ListLeaderboardDefinitionsRequest> OnProgressionListLeaderboardDefinitionsRequestEvent;
        public event PlayFabResultEvent<ListLeaderboardDefinitionsResponse> OnProgressionListLeaderboardDefinitionsResultEvent;
        public event PlayFabRequestEvent<ListStatisticDefinitionsRequest> OnProgressionListStatisticDefinitionsRequestEvent;
        public event PlayFabResultEvent<ListStatisticDefinitionsResponse> OnProgressionListStatisticDefinitionsResultEvent;
        public event PlayFabRequestEvent<UnlinkLeaderboardFromStatisticRequest> OnProgressionUnlinkLeaderboardFromStatisticRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnProgressionUnlinkLeaderboardFromStatisticResultEvent;
        public event PlayFabRequestEvent<UpdateLeaderboardDefinitionRequest> OnProgressionUpdateLeaderboardDefinitionRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnProgressionUpdateLeaderboardDefinitionResultEvent;
        public event PlayFabRequestEvent<UpdateLeaderboardEntriesRequest> OnProgressionUpdateLeaderboardEntriesRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnProgressionUpdateLeaderboardEntriesResultEvent;
        public event PlayFabRequestEvent<UpdateStatisticDefinitionRequest> OnProgressionUpdateStatisticDefinitionRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnProgressionUpdateStatisticDefinitionResultEvent;
        public event PlayFabRequestEvent<UpdateStatisticsRequest> OnProgressionUpdateStatisticsRequestEvent;
        public event PlayFabResultEvent<UpdateStatisticsResponse> OnProgressionUpdateStatisticsResultEvent;
    }
}
#endif
