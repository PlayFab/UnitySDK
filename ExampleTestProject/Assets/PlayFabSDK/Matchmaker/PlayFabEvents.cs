#if ENABLE_PLAYFABSERVER_API
using PlayFab.MatchmakerModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<AuthUserRequest> OnMatchmakerAuthUserRequestEvent;
        public event PlayFabResultEvent<AuthUserResponse> OnMatchmakerAuthUserResultEvent;
        public event PlayFabRequestEvent<PlayerJoinedRequest> OnMatchmakerPlayerJoinedRequestEvent;
        public event PlayFabResultEvent<PlayerJoinedResponse> OnMatchmakerPlayerJoinedResultEvent;
        public event PlayFabRequestEvent<PlayerLeftRequest> OnMatchmakerPlayerLeftRequestEvent;
        public event PlayFabResultEvent<PlayerLeftResponse> OnMatchmakerPlayerLeftResultEvent;
        public event PlayFabRequestEvent<StartGameRequest> OnMatchmakerStartGameRequestEvent;
        public event PlayFabResultEvent<StartGameResponse> OnMatchmakerStartGameResultEvent;
        public event PlayFabRequestEvent<UserInfoRequest> OnMatchmakerUserInfoRequestEvent;
        public event PlayFabResultEvent<UserInfoResponse> OnMatchmakerUserInfoResultEvent;
    }
}
#endif
