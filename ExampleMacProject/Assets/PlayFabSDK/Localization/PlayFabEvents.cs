#if !DISABLE_PLAYFABENTITY_API
using PlayFab.LocalizationModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<GetLanguageListRequest> OnLocalizationGetLanguageListRequestEvent;
        public event PlayFabResultEvent<GetLanguageListResponse> OnLocalizationGetLanguageListResultEvent;
    }
}
#endif
