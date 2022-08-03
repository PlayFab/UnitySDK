#if !DISABLE_PLAYFABENTITY_API
using PlayFab.AuthenticationModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<DeleteRequest> OnAuthenticationDeleteRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnAuthenticationDeleteResultEvent;
        public event PlayFabRequestEvent<GetEntityTokenRequest> OnAuthenticationGetEntityTokenRequestEvent;
        public event PlayFabResultEvent<GetEntityTokenResponse> OnAuthenticationGetEntityTokenResultEvent;
        public event PlayFabRequestEvent<ValidateEntityTokenRequest> OnAuthenticationValidateEntityTokenRequestEvent;
        public event PlayFabResultEvent<ValidateEntityTokenResponse> OnAuthenticationValidateEntityTokenResultEvent;
    }
}
#endif
