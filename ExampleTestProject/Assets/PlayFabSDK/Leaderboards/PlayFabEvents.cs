#if !DISABLE_PLAYFABENTITY_API
using PlayFab.LeaderboardsModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<CreateLeaderboardDefinitionRequest> OnLeaderboardsCreateLeaderboardDefinitionRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnLeaderboardsCreateLeaderboardDefinitionResultEvent;
        public event PlayFabRequestEvent<CreateStatisticDefinitionRequest> OnLeaderboardsCreateStatisticDefinitionRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnLeaderboardsCreateStatisticDefinitionResultEvent;
        public event PlayFabRequestEvent<DeleteLeaderboardDefinitionRequest> OnLeaderboardsDeleteLeaderboardDefinitionRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnLeaderboardsDeleteLeaderboardDefinitionResultEvent;
        public event PlayFabRequestEvent<DeleteLeaderboardEntriesRequest> OnLeaderboardsDeleteLeaderboardEntriesRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnLeaderboardsDeleteLeaderboardEntriesResultEvent;
        public event PlayFabRequestEvent<DeleteStatisticDefinitionRequest> OnLeaderboardsDeleteStatisticDefinitionRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnLeaderboardsDeleteStatisticDefinitionResultEvent;
        public event PlayFabRequestEvent<DeleteStatisticsRequest> OnLeaderboardsDeleteStatisticsRequestEvent;
        public event PlayFabResultEvent<DeleteStatisticsResponse> OnLeaderboardsDeleteStatisticsResultEvent;
        public event PlayFabRequestEvent<GetFriendLeaderboardForEntityRequest> OnLeaderboardsGetFriendLeaderboardForEntityRequestEvent;
        public event PlayFabResultEvent<GetEntityLeaderboardResponse> OnLeaderboardsGetFriendLeaderboardForEntityResultEvent;
        public event PlayFabRequestEvent<GetEntityLeaderboardRequest> OnLeaderboardsGetLeaderboardRequestEvent;
        public event PlayFabResultEvent<GetEntityLeaderboardResponse> OnLeaderboardsGetLeaderboardResultEvent;
        public event PlayFabRequestEvent<GetLeaderboardAroundEntityRequest> OnLeaderboardsGetLeaderboardAroundEntityRequestEvent;
        public event PlayFabResultEvent<GetEntityLeaderboardResponse> OnLeaderboardsGetLeaderboardAroundEntityResultEvent;
        public event PlayFabRequestEvent<GetLeaderboardDefinitionRequest> OnLeaderboardsGetLeaderboardDefinitionRequestEvent;
        public event PlayFabResultEvent<GetLeaderboardDefinitionResponse> OnLeaderboardsGetLeaderboardDefinitionResultEvent;
        public event PlayFabRequestEvent<GetLeaderboardForEntitiesRequest> OnLeaderboardsGetLeaderboardForEntitiesRequestEvent;
        public event PlayFabResultEvent<GetEntityLeaderboardResponse> OnLeaderboardsGetLeaderboardForEntitiesResultEvent;
        public event PlayFabRequestEvent<GetStatisticDefinitionRequest> OnLeaderboardsGetStatisticDefinitionRequestEvent;
        public event PlayFabResultEvent<GetStatisticDefinitionResponse> OnLeaderboardsGetStatisticDefinitionResultEvent;
        public event PlayFabRequestEvent<GetStatisticDefinitionsRequest> OnLeaderboardsGetStatisticDefinitionsRequestEvent;
        public event PlayFabResultEvent<GetStatisticDefinitionsResponse> OnLeaderboardsGetStatisticDefinitionsResultEvent;
        public event PlayFabRequestEvent<GetStatisticsRequest> OnLeaderboardsGetStatisticsRequestEvent;
        public event PlayFabResultEvent<GetStatisticsResponse> OnLeaderboardsGetStatisticsResultEvent;
        public event PlayFabRequestEvent<GetStatisticsForEntitiesRequest> OnLeaderboardsGetStatisticsForEntitiesRequestEvent;
        public event PlayFabResultEvent<GetStatisticsForEntitiesResponse> OnLeaderboardsGetStatisticsForEntitiesResultEvent;
        public event PlayFabRequestEvent<IncrementLeaderboardVersionRequest> OnLeaderboardsIncrementLeaderboardVersionRequestEvent;
        public event PlayFabResultEvent<IncrementLeaderboardVersionResponse> OnLeaderboardsIncrementLeaderboardVersionResultEvent;
        public event PlayFabRequestEvent<IncrementStatisticVersionRequest> OnLeaderboardsIncrementStatisticVersionRequestEvent;
        public event PlayFabResultEvent<IncrementStatisticVersionResponse> OnLeaderboardsIncrementStatisticVersionResultEvent;
        public event PlayFabRequestEvent<ListLeaderboardDefinitionsRequest> OnLeaderboardsListLeaderboardDefinitionsRequestEvent;
        public event PlayFabResultEvent<ListLeaderboardDefinitionsResponse> OnLeaderboardsListLeaderboardDefinitionsResultEvent;
        public event PlayFabRequestEvent<ListStatisticDefinitionsRequest> OnLeaderboardsListStatisticDefinitionsRequestEvent;
        public event PlayFabResultEvent<ListStatisticDefinitionsResponse> OnLeaderboardsListStatisticDefinitionsResultEvent;
        public event PlayFabRequestEvent<UnlinkLeaderboardFromStatisticRequest> OnLeaderboardsUnlinkLeaderboardFromStatisticRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnLeaderboardsUnlinkLeaderboardFromStatisticResultEvent;
        public event PlayFabRequestEvent<UpdateLeaderboardEntriesRequest> OnLeaderboardsUpdateLeaderboardEntriesRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnLeaderboardsUpdateLeaderboardEntriesResultEvent;
        public event PlayFabRequestEvent<UpdateStatisticsRequest> OnLeaderboardsUpdateStatisticsRequestEvent;
        public event PlayFabResultEvent<UpdateStatisticsResponse> OnLeaderboardsUpdateStatisticsResultEvent;
    }
}
#endif
