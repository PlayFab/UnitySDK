using PlayFab.Internal;
using PlayFab.SharedModels;

namespace PlayFab.EventsModels
{
    public class TelemetryIngestionConfigRequest : PlayFabRequestCommon
    {
    }

    public class TelemetryIngestionConfigResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The key used for PlayInsights telemetry ingestion for the specified tenant
        /// </summary>
        public string IngestionKey;

        /// <summary>
        /// The key which should be used to set up the aria Tickets Header
        /// </summary>
        public string TelemetryJwtHeaderKey;

        /// <summary>
        /// The value prefix which should be used to set up the aria Tickets Header
        /// </summary>
        public string TelemetryJwtHeaderPrefix;

        /// <summary>
        /// A signed JWT Token that proves the identity of the data ingester
        /// </summary>
        public string TelemetryJwtToken;

        /// <summary>
        /// The Id of the tenant to which telemetry should be ingested
        /// </summary>
        public string TenantId;

    }
}
