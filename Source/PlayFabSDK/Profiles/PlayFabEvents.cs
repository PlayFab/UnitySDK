#if !DISABLE_PLAYFABENTITY_API
using PlayFab.ProfilesModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<GetGlobalPolicyRequest> OnProfilesGetGlobalPolicyRequestEvent;
        public event PlayFabResultEvent<GetGlobalPolicyResponse> OnProfilesGetGlobalPolicyResultEvent;
        public event PlayFabRequestEvent<GetEntityProfileRequest> OnProfilesGetProfileRequestEvent;
        public event PlayFabResultEvent<GetEntityProfileResponse> OnProfilesGetProfileResultEvent;
        public event PlayFabRequestEvent<GetEntityProfilesRequest> OnProfilesGetProfilesRequestEvent;
        public event PlayFabResultEvent<GetEntityProfilesResponse> OnProfilesGetProfilesResultEvent;
        public event PlayFabRequestEvent<GetTitlePlayersFromMasterPlayerAccountIdsRequest> OnProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequestEvent;
        public event PlayFabResultEvent<GetTitlePlayersFromMasterPlayerAccountIdsResponse> OnProfilesGetTitlePlayersFromMasterPlayerAccountIdsResultEvent;
        public event PlayFabRequestEvent<SetGlobalPolicyRequest> OnProfilesSetGlobalPolicyRequestEvent;
        public event PlayFabResultEvent<SetGlobalPolicyResponse> OnProfilesSetGlobalPolicyResultEvent;
        public event PlayFabRequestEvent<SetProfileLanguageRequest> OnProfilesSetProfileLanguageRequestEvent;
        public event PlayFabResultEvent<SetProfileLanguageResponse> OnProfilesSetProfileLanguageResultEvent;
        public event PlayFabRequestEvent<SetEntityProfilePolicyRequest> OnProfilesSetProfilePolicyRequestEvent;
        public event PlayFabResultEvent<SetEntityProfilePolicyResponse> OnProfilesSetProfilePolicyResultEvent;
    }
}
#endif
