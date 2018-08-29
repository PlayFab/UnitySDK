#if !DISABLE_PLAYFABENTITY_API
using PlayFab.EventsModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<WriteEventsRequest> OnEventsWriteEventsRequestEvent;
        public event PlayFabResultEvent<WriteEventsResponse> OnEventsWriteEventsResultEvent;
    }
}
#endif
