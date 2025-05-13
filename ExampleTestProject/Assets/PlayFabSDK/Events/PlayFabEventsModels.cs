#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.EventsModels
{
    [Serializable]
    public class CreateTelemetryKeyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The name of the new key. Telemetry key names must be unique within the scope of the title.
        /// </summary>
        public string KeyName;
    }

    [Serializable]
    public class CreateTelemetryKeyResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Details about the newly created telemetry key.
        /// </summary>
        public TelemetryKeyDetails NewKeyDetails;
    }

    [Serializable]
    public class DataConnectionAzureBlobSettings : PlayFabBaseModel
    {
        /// <summary>
        /// Name of the storage account.
        /// </summary>
        public string AccountName;
        /// <summary>
        /// Name of the container.
        /// </summary>
        public string ContainerName;
        /// <summary>
        /// Azure Entra Tenant Id.
        /// </summary>
        public string TenantId;
    }

    [Serializable]
    public class DataConnectionAzureDataExplorerSettings : PlayFabBaseModel
    {
        /// <summary>
        /// The URI of the ADX cluster.
        /// </summary>
        public string ClusterUri;
        /// <summary>
        /// The database to write to.
        /// </summary>
        public string Database;
        /// <summary>
        /// The table to write to.
        /// </summary>
        public string Table;
    }

    [Serializable]
    public class DataConnectionDetails : PlayFabBaseModel
    {
        /// <summary>
        /// Settings of the data connection.
        /// </summary>
        public DataConnectionSettings ConnectionSettings;
        /// <summary>
        /// Whether or not the connection is currently active.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// The name of the data connection.
        /// </summary>
        public string Name;
        /// <summary>
        /// Current status of the data connection, if any.
        /// </summary>
        public DataConnectionStatusDetails Status;
        /// <summary>
        /// The type of data connection.
        /// </summary>
        public DataConnectionType Type;
    }

    public enum DataConnectionErrorState
    {
        OK,
        Error
    }

    [Serializable]
    public class DataConnectionFabricKQLSettings : PlayFabBaseModel
    {
        /// <summary>
        /// The URI of the Fabric cluster.
        /// </summary>
        public string ClusterUri;
        /// <summary>
        /// The database to write to.
        /// </summary>
        public string Database;
        /// <summary>
        /// The table to write to.
        /// </summary>
        public string Table;
    }

    [Serializable]
    public class DataConnectionSettings : PlayFabBaseModel
    {
        /// <summary>
        /// Settings if the type of connection is AzureBlobStorage.
        /// </summary>
        public DataConnectionAzureBlobSettings AzureBlobSettings;
        /// <summary>
        /// Settings if the type of connection is AzureDataExplorer.
        /// </summary>
        public DataConnectionAzureDataExplorerSettings AzureDataExplorerSettings;
        /// <summary>
        /// Settings if the type of connection is FabricKQL.
        /// </summary>
        public DataConnectionFabricKQLSettings AzureFabricKQLSettings;
    }

    [Serializable]
    public class DataConnectionStatusDetails : PlayFabBaseModel
    {
        /// <summary>
        /// The name of the error affecting the data connection, if any.
        /// </summary>
        public string Error;
        /// <summary>
        /// A description of the error affecting the data connection, if any. This may be empty for some errors.
        /// </summary>
        public string ErrorMessage;
        /// <summary>
        /// The most recent time of the error affecting the data connection, if any.
        /// </summary>
        public DateTime? MostRecentErrorTime;
        /// <summary>
        /// Indicates if the connection is in a normal state or error state.
        /// </summary>
        public DataConnectionErrorState? State;
    }

    public enum DataConnectionType
    {
        AzureBlobStorage,
        AzureDataExplorer,
        FabricKQL
    }

    [Serializable]
    public class DeleteDataConnectionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the data connection to delete.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class DeleteDataConnectionResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Indicates whether or not the connection was deleted as part of the request.
        /// </summary>
        public bool WasDeleted;
    }

    [Serializable]
    public class DeleteTelemetryKeyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The name of the key to delete.
        /// </summary>
        public string KeyName;
    }

    [Serializable]
    public class DeleteTelemetryKeyResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Indicates whether or not the key was deleted. If false, no key with that name existed.
        /// </summary>
        public bool WasKeyDeleted;
    }

    /// <summary>
    /// Combined entity type and ID structure which uniquely identifies a single entity.
    /// </summary>
    [Serializable]
    public class EntityKey : PlayFabBaseModel
    {
        /// <summary>
        /// Unique ID of the entity.
        /// </summary>
        public string Id;
        /// <summary>
        /// Entity type. See https://docs.microsoft.com/gaming/playfab/features/data/entities/available-built-in-entity-types
        /// </summary>
        public string Type;
    }

    [Serializable]
    public class EventContents : PlayFabBaseModel
    {
        /// <summary>
        /// The optional custom tags associated with the event (e.g. build number, external trace identifiers, etc.). Before an
        /// event is written, this collection and the base request custom tags will be merged, but not overriden. This enables the
        /// caller to specify static tags and per event tags.
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Entity associated with the event. If null, the event will apply to the calling entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The namespace in which the event is defined. Allowed namespaces can vary by API.
        /// </summary>
        public string EventNamespace;
        /// <summary>
        /// The name of this event.
        /// </summary>
        public string Name;
        /// <summary>
        /// The original unique identifier associated with this event before it was posted to PlayFab. The value might differ from
        /// the EventId value, which is assigned when the event is received by the server.
        /// </summary>
        public string OriginalId;
        /// <summary>
        /// The time (in UTC) associated with this event when it occurred. If specified, this value is stored in the
        /// OriginalTimestamp property of the PlayStream event.
        /// </summary>
        public DateTime? OriginalTimestamp;
        /// <summary>
        /// Arbitrary data associated with the event. Only one of Payload or PayloadJSON is allowed.
        /// </summary>
        public object Payload;
        /// <summary>
        /// Arbitrary data associated with the event, represented as a JSON serialized string. Only one of Payload or PayloadJSON is
        /// allowed.
        /// </summary>
        public string PayloadJSON;
    }

    [Serializable]
    public class GetDataConnectionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the data connection to retrieve.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class GetDataConnectionResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The details of the queried Data Connection.
        /// </summary>
        public DataConnectionDetails DataConnection;
    }

    [Serializable]
    public class GetTelemetryKeyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The name of the key to retrieve.
        /// </summary>
        public string KeyName;
    }

    [Serializable]
    public class GetTelemetryKeyResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Details about the requested telemetry key.
        /// </summary>
        public TelemetryKeyDetails KeyDetails;
    }

    [Serializable]
    public class ListDataConnectionsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class ListDataConnectionsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of existing Data Connections.
        /// </summary>
        public List<DataConnectionDetails> DataConnections;
    }

    [Serializable]
    public class ListTelemetryKeysRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class ListTelemetryKeysResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The telemetry keys configured for the title.
        /// </summary>
        public List<TelemetryKeyDetails> KeyDetails;
    }

    [Serializable]
    public class SetDataConnectionActiveRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Whether to set the data connection to active (true) or deactivated (false).
        /// </summary>
        public bool Active;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the data connection to update.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class SetDataConnectionActiveResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The most current details about the data connection that was to be updated.
        /// </summary>
        public DataConnectionDetails DataConnection;
        /// <summary>
        /// Indicates whether or not the data connection was updated. If false, the data connection was already in the desired
        /// state.
        /// </summary>
        public bool WasUpdated;
    }

    [Serializable]
    public class SetDataConnectionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Settings of the data connection.
        /// </summary>
        public DataConnectionSettings ConnectionSettings;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Whether or not the connection is currently active.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// The name of the data connection to update or create.
        /// </summary>
        public string Name;
        /// <summary>
        /// The type of data connection.
        /// </summary>
        public DataConnectionType Type;
    }

    [Serializable]
    public class SetDataConnectionResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The details of the Data Connection to be created or updated.
        /// </summary>
        public DataConnectionDetails DataConnection;
    }

    [Serializable]
    public class SetTelemetryKeyActiveRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Whether to set the key to active (true) or deactivated (false).
        /// </summary>
        public bool Active;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The name of the key to update.
        /// </summary>
        public string KeyName;
    }

    [Serializable]
    public class SetTelemetryKeyActiveResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The most current details about the telemetry key that was to be updated.
        /// </summary>
        public TelemetryKeyDetails KeyDetails;
        /// <summary>
        /// Indicates whether or not the key was updated. If false, the key was already in the desired state.
        /// </summary>
        public bool WasKeyUpdated;
    }

    [Serializable]
    public class TelemetryKeyDetails : PlayFabBaseModel
    {
        /// <summary>
        /// When the key was created.
        /// </summary>
        public DateTime CreateTime;
        /// <summary>
        /// Whether or not the key is currently active. Deactivated keys cannot be used for telemetry ingestion.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// The key that can be distributed to clients for use during telemetry ingestion.
        /// </summary>
        public string KeyValue;
        /// <summary>
        /// When the key was last updated.
        /// </summary>
        public DateTime LastUpdateTime;
        /// <summary>
        /// The name of the key. Telemetry key names are unique within the scope of the title.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class WriteEventsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The collection of events to write. Up to 200 events can be written per request.
        /// </summary>
        public List<EventContents> Events;
    }

    [Serializable]
    public class WriteEventsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The unique identifiers assigned by the server to the events, in the same order as the events in the request. Only
        /// returned if FlushToPlayStream option is true.
        /// </summary>
        public List<string> AssignedEventIds;
    }
}
#endif
