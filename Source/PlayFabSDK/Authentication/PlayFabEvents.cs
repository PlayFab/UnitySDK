#if !DISABLE_PLAYFABENTITY_API
using PlayFab.AuthenticationModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<ActivateAPIKeyRequest> OnAuthenticationActivateKeyRequestEvent;
        public event PlayFabResultEvent<ActivateAPIKeyResponse> OnAuthenticationActivateKeyResultEvent;
        public event PlayFabRequestEvent<CreateAPIKeyRequest> OnAuthenticationCreateKeyRequestEvent;
        public event PlayFabResultEvent<CreateAPIKeyResponse> OnAuthenticationCreateKeyResultEvent;
        public event PlayFabRequestEvent<DeactivateAPIKeyRequest> OnAuthenticationDeactivateKeyRequestEvent;
        public event PlayFabResultEvent<DeactivateAPIKeyResponse> OnAuthenticationDeactivateKeyResultEvent;
        public event PlayFabRequestEvent<DeleteAPIKeyRequest> OnAuthenticationDeleteKeyRequestEvent;
        public event PlayFabResultEvent<DeleteAPIKeyResponse> OnAuthenticationDeleteKeyResultEvent;
        public event PlayFabRequestEvent<GetEntityTokenRequest> OnAuthenticationGetEntityTokenRequestEvent;
        public event PlayFabResultEvent<GetEntityTokenResponse> OnAuthenticationGetEntityTokenResultEvent;
        public event PlayFabRequestEvent<GetAPIKeysRequest> OnAuthenticationGetKeysRequestEvent;
        public event PlayFabResultEvent<GetAPIKeysResponse> OnAuthenticationGetKeysResultEvent;
    }
}
#endif
