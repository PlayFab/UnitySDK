#if !DISABLE_PLAYFABENTITY_API
using PlayFab.AuthenticationModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<GetEntityTokenRequest> OnAuthenticationGetEntityTokenRequestEvent;
        public event PlayFabResultEvent<GetEntityTokenResponse> OnAuthenticationGetEntityTokenResultEvent;
    }
}
#endif
