#if !DISABLE_PLAYFABENTITY_API
using PlayFab.EventsModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<CreateTelemetryKeyRequest> OnEventsCreateTelemetryKeyRequestEvent;
        public event PlayFabResultEvent<CreateTelemetryKeyResponse> OnEventsCreateTelemetryKeyResultEvent;
        public event PlayFabRequestEvent<DeleteTelemetryKeyRequest> OnEventsDeleteTelemetryKeyRequestEvent;
        public event PlayFabResultEvent<DeleteTelemetryKeyResponse> OnEventsDeleteTelemetryKeyResultEvent;
        public event PlayFabRequestEvent<GetTelemetryKeyRequest> OnEventsGetTelemetryKeyRequestEvent;
        public event PlayFabResultEvent<GetTelemetryKeyResponse> OnEventsGetTelemetryKeyResultEvent;
        public event PlayFabRequestEvent<ListTelemetryKeysRequest> OnEventsListTelemetryKeysRequestEvent;
        public event PlayFabResultEvent<ListTelemetryKeysResponse> OnEventsListTelemetryKeysResultEvent;
        public event PlayFabRequestEvent<SetTelemetryKeyActiveRequest> OnEventsSetTelemetryKeyActiveRequestEvent;
        public event PlayFabResultEvent<SetTelemetryKeyActiveResponse> OnEventsSetTelemetryKeyActiveResultEvent;
        public event PlayFabRequestEvent<WriteEventsRequest> OnEventsWriteEventsRequestEvent;
        public event PlayFabResultEvent<WriteEventsResponse> OnEventsWriteEventsResultEvent;
        public event PlayFabRequestEvent<WriteEventsRequest> OnEventsWriteTelemetryEventsRequestEvent;
        public event PlayFabResultEvent<WriteEventsResponse> OnEventsWriteTelemetryEventsResultEvent;
    }
}
#endif
