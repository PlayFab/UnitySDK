#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.InsightsModels
{
    [Serializable]
    public class InsightsEmptyRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class InsightsGetDetailsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Amount of data (in MB) currently used by Insights.
        /// </summary>
        public uint DataUsageMb;
        /// <summary>
        /// Details of any error that occurred while retrieving Insights details.
        /// </summary>
        public string ErrorMessage;
        /// <summary>
        /// Allowed range of values for performance level and data storage retention.
        /// </summary>
        public InsightsGetLimitsResponse Limits;
        /// <summary>
        /// List of pending Insights operations for the title.
        /// </summary>
        public List<InsightsGetOperationStatusResponse> PendingOperations;
        /// <summary>
        /// Current Insights performance level setting.
        /// </summary>
        public int PerformanceLevel;
        /// <summary>
        /// Current Insights data storage retention value in days.
        /// </summary>
        public int RetentionDays;
    }

    [Serializable]
    public class InsightsGetLimitsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Default Insights performance level.
        /// </summary>
        public int DefaultPerformanceLevel;
        /// <summary>
        /// Default Insights data storage retention days.
        /// </summary>
        public int DefaultStorageRetentionDays;
        /// <summary>
        /// Maximum allowed data storage retention days.
        /// </summary>
        public int StorageMaxRetentionDays;
        /// <summary>
        /// Minimum allowed data storage retention days.
        /// </summary>
        public int StorageMinRetentionDays;
        /// <summary>
        /// List of Insights submeter limits for the allowed performance levels.
        /// </summary>
        public List<InsightsPerformanceLevel> SubMeters;
    }

    /// <summary>
    /// Returns the current status for the requested operation id.
    /// </summary>
    [Serializable]
    public class InsightsGetOperationStatusRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Id of the Insights operation.
        /// </summary>
        public string OperationId;
    }

    [Serializable]
    public class InsightsGetOperationStatusResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Optional message related to the operation details.
        /// </summary>
        public string Message;
        /// <summary>
        /// Time the operation was completed.
        /// </summary>
        public DateTime OperationCompletedTime;
        /// <summary>
        /// Id of the Insights operation.
        /// </summary>
        public string OperationId;
        /// <summary>
        /// Time the operation status was last updated.
        /// </summary>
        public DateTime OperationLastUpdated;
        /// <summary>
        /// Time the operation started.
        /// </summary>
        public DateTime OperationStartedTime;
        /// <summary>
        /// The type of operation, SetPerformance or SetStorageRetention.
        /// </summary>
        public string OperationType;
        /// <summary>
        /// The value requested for the operation.
        /// </summary>
        public int OperationValue;
        /// <summary>
        /// Current status of the operation.
        /// </summary>
        public string Status;
    }

    /// <summary>
    /// Returns a list of operations that are in the pending state for the requested operation type.
    /// </summary>
    [Serializable]
    public class InsightsGetPendingOperationsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The type of pending operations requested, or blank for all operation types.
        /// </summary>
        public string OperationType;
    }

    [Serializable]
    public class InsightsGetPendingOperationsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// List of pending Insights operations.
        /// </summary>
        public List<InsightsGetOperationStatusResponse> PendingOperations;
    }

    [Serializable]
    public class InsightsOperationResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Optional message related to the operation details.
        /// </summary>
        public string Message;
        /// <summary>
        /// Id of the Insights operation.
        /// </summary>
        public string OperationId;
        /// <summary>
        /// The type of operation, SetPerformance or SetStorageRetention.
        /// </summary>
        public string OperationType;
    }

    [Serializable]
    public class InsightsPerformanceLevel : PlayFabBaseModel
    {
        /// <summary>
        /// Number of allowed active event exports.
        /// </summary>
        public int ActiveEventExports;
        /// <summary>
        /// Maximum cache size.
        /// </summary>
        public int CacheSizeMB;
        /// <summary>
        /// Maximum number of concurrent queries.
        /// </summary>
        public int Concurrency;
        /// <summary>
        /// Number of Insights credits consumed per minute.
        /// </summary>
        public double CreditsPerMinute;
        /// <summary>
        /// Maximum events per second.
        /// </summary>
        public int EventsPerSecond;
        /// <summary>
        /// Performance level.
        /// </summary>
        public int Level;
        /// <summary>
        /// Maximum amount of memory allowed per query.
        /// </summary>
        public int MaxMemoryPerQueryMB;
        /// <summary>
        /// Amount of compute power allocated for queries and operations.
        /// </summary>
        public int VirtualCpuCores;
    }

    /// <summary>
    /// Sets the performance level to the requested value. Use the GetLimits method to get the allowed values.
    /// </summary>
    [Serializable]
    public class InsightsSetPerformanceRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The Insights performance level to apply to the title.
        /// </summary>
        public int PerformanceLevel;
    }

    /// <summary>
    /// Sets the data storage retention to the requested value. Use the GetLimits method to get the range of allowed values.
    /// </summary>
    [Serializable]
    public class InsightsSetStorageRetentionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The Insights data storage retention value (in days) to apply to the title.
        /// </summary>
        public int RetentionDays;
    }
}
#endif
