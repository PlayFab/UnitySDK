#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ProgressionModels
{
    [Serializable]
    public class CreateLeaderboardDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Leaderboard columns describing the sort directions, cannot be changed after creation. A maximum of 5 columns are
        /// allowed.
        /// </summary>
        public List<LeaderboardColumn> Columns;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity type being represented on the leaderboard. If it doesn't correspond to the PlayFab entity types, use
        /// 'external' as the type.
        /// </summary>
        public string EntityType;
        /// <summary>
        /// [In Preview]: The configuration for the events emitted by this leaderboard. If not specified, no events will be emitted.
        /// </summary>
        public LeaderboardEventEmissionConfig EventEmissionConfig;
        /// <summary>
        /// A name for the leaderboard, unique per title.
        /// </summary>
        public string Name;
        /// <summary>
        /// Maximum number of entries on this leaderboard
        /// </summary>
        public int SizeLimit;
        /// <summary>
        /// The version reset configuration for the leaderboard definition.
        /// </summary>
        public VersionConfiguration VersionConfiguration;
    }

    [Serializable]
    public class CreateStatisticDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// [In Preview]: The list of statistic definition names whose scores must be aggregated towards this stat. If
        /// AggregationSource is specified, the entityType of this definition MUST be Title (making it a CommunityStat). Currently,
        /// only one aggregation source can be specified.
        /// </summary>
        public List<string> AggregationSources;
        /// <summary>
        /// The columns for the statistic defining the aggregation method for each column. A maximum of 5 columns are allowed.
        /// </summary>
        public List<StatisticColumn> Columns;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity type allowed to have score(s) for this statistic.
        /// </summary>
        public string EntityType;
        /// <summary>
        /// [In Preview]: Configurations for different Statistics events that can be emitted by the service.
        /// </summary>
        public StatisticsEventEmissionConfig EventEmissionConfig;
        /// <summary>
        /// Name of the statistic. Must be less than 150 characters. Restricted to a-Z, 0-9, '(', ')', '_', '-' and '.'.
        /// </summary>
        public string Name;
        /// <summary>
        /// The version reset configuration for the statistic definition.
        /// </summary>
        public VersionConfiguration VersionConfiguration;
    }

    [Serializable]
    public class DeleteLeaderboardDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the leaderboard definition to delete.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class DeleteLeaderboardEntriesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The unique Ids of the entries to delete from the leaderboard.
        /// </summary>
        public List<string> EntityIds;
        /// <summary>
        /// The name of the leaderboard.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class DeleteStatisticDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Name of the statistic to delete.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class DeleteStatisticsRequest : PlayFabRequestCommon
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
        /// Collection of statistics to remove from this entity.
        /// </summary>
        public List<StatisticDelete> Statistics;
    }

    [Serializable]
    public class DeleteStatisticsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The entity id and type.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class EmptyResponse : PlayFabResultCommon
    {
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

    /// <summary>
    /// Individual rank of an entity in a leaderboard
    /// </summary>
    [Serializable]
    public class EntityLeaderboardEntry : PlayFabBaseModel
    {
        /// <summary>
        /// Entity's display name.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Entity identifier.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The time at which the last update to the entry was recorded on the server.
        /// </summary>
        public DateTime LastUpdated;
        /// <summary>
        /// An opaque blob of data stored on the leaderboard entry. Note that the metadata is not used for ranking purposes.
        /// </summary>
        public string Metadata;
        /// <summary>
        /// Position on the leaderboard.
        /// </summary>
        public int Rank;
        /// <summary>
        /// Scores for the entry.
        /// </summary>
        public List<string> Scores;
    }

    [Serializable]
    public class EntityStatistics : PlayFabBaseModel
    {
        /// <summary>
        /// The entity for which the statistics are returned.
        /// </summary>
        public EntityKey EntityKey;
        /// <summary>
        /// The statistics for the given entity key.
        /// </summary>
        public List<EntityStatisticValue> Statistics;
    }

    [Serializable]
    public class EntityStatisticValue : PlayFabBaseModel
    {
        /// <summary>
        /// Metadata associated with the Statistic.
        /// </summary>
        public string Metadata;
        /// <summary>
        /// Statistic name
        /// </summary>
        public string Name;
        /// <summary>
        /// Statistic scores
        /// </summary>
        public List<string> Scores;
        /// <summary>
        /// Statistic version
        /// </summary>
        public int Version;
    }

    public enum EventType
    {
        None,
        Telemetry,
        PlayStream
    }

    public enum ExternalFriendSources
    {
        None,
        Steam,
        Facebook,
        Xbox,
        Psn,
        All
    }

    /// <summary>
    /// Request to load a leaderboard.
    /// </summary>
    [Serializable]
    public class GetEntityLeaderboardRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Name of the leaderboard.
        /// </summary>
        public string LeaderboardName;
        /// <summary>
        /// Maximum number of results to return from the leaderboard. Minimum 1, maximum 100.
        /// </summary>
        public uint PageSize;
        /// <summary>
        /// Index position to start from. 1 is beginning of leaderboard.
        /// </summary>
        public uint? StartingPosition;
        /// <summary>
        /// Optional version of the leaderboard, defaults to current version.
        /// </summary>
        public uint? Version;
    }

    /// <summary>
    /// Leaderboard response
    /// </summary>
    [Serializable]
    public class GetEntityLeaderboardResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Leaderboard columns describing the sort directions.
        /// </summary>
        public List<LeaderboardColumn> Columns;
        /// <summary>
        /// The number of entries on the leaderboard.
        /// </summary>
        public uint EntryCount;
        /// <summary>
        /// The time the next scheduled reset will occur. Null if the leaderboard does not reset on a schedule.
        /// </summary>
        public DateTime? NextReset;
        /// <summary>
        /// Individual entity rankings in the leaderboard, in sorted order by rank.
        /// </summary>
        public List<EntityLeaderboardEntry> Rankings;
        /// <summary>
        /// Version of the leaderboard being returned.
        /// </summary>
        public uint Version;
    }

    [Serializable]
    public class GetFriendLeaderboardForEntityRequest : PlayFabRequestCommon
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
        /// Indicates which other platforms' friends should be included in the response. In HTTP, it is represented as a
        /// comma-separated list of platforms.
        /// </summary>
        public ExternalFriendSources? ExternalFriendSources;
        /// <summary>
        /// Name of the leaderboard.
        /// </summary>
        public string LeaderboardName;
        /// <summary>
        /// Optional version of the leaderboard, defaults to current version.
        /// </summary>
        public uint? Version;
        /// <summary>
        /// Xbox token if Xbox friends should be included. Requires Xbox be configured on PlayFab.
        /// </summary>
        public string XboxToken;
    }

    /// <summary>
    /// Request to load a section of a leaderboard centered on a specific entity.
    /// </summary>
    [Serializable]
    public class GetLeaderboardAroundEntityRequest : PlayFabRequestCommon
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
        /// Name of the leaderboard.
        /// </summary>
        public string LeaderboardName;
        /// <summary>
        /// Number of surrounding entries to return (in addition to specified entity). In general, the number of ranks above and
        /// below will be split into half. For example, if the specified value is 10, 5 ranks above and 5 ranks below will be
        /// retrieved. However, the numbers will get skewed in either direction when the specified entity is towards the top or
        /// bottom of the leaderboard. Also, the number of entries returned can be lower than the value specified for entries at the
        /// bottom of the leaderboard.
        /// </summary>
        public uint MaxSurroundingEntries;
        /// <summary>
        /// Optional version of the leaderboard, defaults to current.
        /// </summary>
        public uint? Version;
    }

    [Serializable]
    public class GetLeaderboardDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the leaderboard to retrieve the definition for.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class GetLeaderboardDefinitionResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Sort direction of the leaderboard columns, cannot be changed after creation.
        /// </summary>
        public List<LeaderboardColumn> Columns;
        /// <summary>
        /// Created time, in UTC
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// The entity type being represented on the leaderboard. If it doesn't correspond to the PlayFab entity types, use
        /// 'external' as the type.
        /// </summary>
        public string EntityType;
        /// <summary>
        /// [In Preview]: The configuration for the events emitted by this leaderboard. If not specified, no events will be emitted.
        /// </summary>
        public LeaderboardEventEmissionConfig EventEmissionConfig;
        /// <summary>
        /// Last time, in UTC, leaderboard version was incremented.
        /// </summary>
        public DateTime? LastResetTime;
        /// <summary>
        /// A name for the leaderboard, unique per title.
        /// </summary>
        public string Name;
        /// <summary>
        /// Maximum number of entries on this leaderboard
        /// </summary>
        public int SizeLimit;
        /// <summary>
        /// Latest Leaderboard version.
        /// </summary>
        public uint Version;
        /// <summary>
        /// The version reset configuration for the leaderboard definition.
        /// </summary>
        public VersionConfiguration VersionConfiguration;
    }

    /// <summary>
    /// Request a leaderboard limited to a collection of entities.
    /// </summary>
    [Serializable]
    public class GetLeaderboardForEntitiesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Collection of Entity IDs to include in the leaderboard.
        /// </summary>
        public List<string> EntityIds;
        /// <summary>
        /// Name of the leaderboard.
        /// </summary>
        public string LeaderboardName;
        /// <summary>
        /// Optional version of the leaderboard, defaults to current.
        /// </summary>
        public uint? Version;
    }

    [Serializable]
    public class GetStatisticDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Name of the statistic. Must be less than 150 characters.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class GetStatisticDefinitionResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of statistic definitions names this definition aggregates to.
        /// </summary>
        public List<string> AggregationDestinations;
        /// <summary>
        /// The list of statistic definitions names whose values must be aggregated towards this stat. If AggregationSource is
        /// specified, the entityType of this definition MUST be Title (making it a CommunityStat). Currently, only one aggregation
        /// source can be specified.
        /// </summary>
        public List<string> AggregationSources;
        /// <summary>
        /// The columns for the statistic defining the aggregation method for each column.
        /// </summary>
        public List<StatisticColumn> Columns;
        /// <summary>
        /// Created time, in UTC
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// The entity type that can have this statistic.
        /// </summary>
        public string EntityType;
        /// <summary>
        /// [In Preview]: Configurations for different Statistics events that can be emitted by the service.
        /// </summary>
        public StatisticsEventEmissionConfig EventEmissionConfig;
        /// <summary>
        /// Last time, in UTC, statistic version was incremented.
        /// </summary>
        public DateTime? LastResetTime;
        /// <summary>
        /// The list of leaderboards that are linked to this statistic definition.
        /// </summary>
        public List<string> LinkedLeaderboardNames;
        /// <summary>
        /// Name of the statistic.
        /// </summary>
        public string Name;
        /// <summary>
        /// Statistic version.
        /// </summary>
        public uint Version;
        /// <summary>
        /// The version reset configuration for the leaderboard definition.
        /// </summary>
        public VersionConfiguration VersionConfiguration;
    }

    [Serializable]
    public class GetStatisticsForEntitiesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Collection of Entity IDs to retrieve statistics for.
        /// </summary>
        public List<EntityKey> Entities;
        /// <summary>
        /// The list of statistics to return for the user. If set to null, the current version of all statistics are returned.
        /// </summary>
        public List<string> StatisticNames;
    }

    [Serializable]
    public class GetStatisticsForEntitiesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// A mapping of statistic name to the columns defined in the corresponding definition.
        /// </summary>
        public Dictionary<string,StatisticColumnCollection> ColumnDetails;
        /// <summary>
        /// List of entities mapped to their statistics. Only the latest version of a statistic is returned.
        /// </summary>
        public List<EntityStatistics> EntitiesStatistics;
    }

    [Serializable]
    public class GetStatisticsRequest : PlayFabRequestCommon
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
        /// The list of statistics to return for the user. If set to null, the current version of all statistics are returned.
        /// </summary>
        public List<string> StatisticNames;
    }

    [Serializable]
    public class GetStatisticsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// A mapping of statistic name to the columns defined in the corresponding definition.
        /// </summary>
        public Dictionary<string,StatisticColumnCollection> ColumnDetails;
        /// <summary>
        /// The entity id and type.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// List of statistics keyed by Name. Only the latest version of a statistic is returned.
        /// </summary>
        public Dictionary<string,EntityStatisticValue> Statistics;
    }

    [Serializable]
    public class IncrementLeaderboardVersionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the leaderboard to increment the version for.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class IncrementLeaderboardVersionResponse : PlayFabResultCommon
    {
        /// <summary>
        /// New Leaderboard version.
        /// </summary>
        public uint Version;
    }

    [Serializable]
    public class IncrementStatisticVersionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Name of the statistic to increment the version of.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class IncrementStatisticVersionResponse : PlayFabResultCommon
    {
        /// <summary>
        /// New statistic version.
        /// </summary>
        public uint Version;
    }

    [Serializable]
    public class LeaderboardColumn : PlayFabBaseModel
    {
        /// <summary>
        /// If the value for this column is sourced from a statistic, details of the linked column. Null if the leaderboard is not
        /// linked.
        /// </summary>
        public LinkedStatisticColumn LinkedStatisticColumn;
        /// <summary>
        /// A name for the leaderboard column, unique per leaderboard definition.
        /// </summary>
        public string Name;
        /// <summary>
        /// The sort direction for this column.
        /// </summary>
        public LeaderboardSortDirection SortDirection;
    }

    [Serializable]
    public class LeaderboardDefinition : PlayFabBaseModel
    {
        /// <summary>
        /// Sort direction of the leaderboard columns, cannot be changed after creation.
        /// </summary>
        public List<LeaderboardColumn> Columns;
        /// <summary>
        /// Created time, in UTC
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// The entity type being represented on the leaderboard. If it doesn't correspond to the PlayFab entity types, use
        /// 'external' as the type.
        /// </summary>
        public string EntityType;
        /// <summary>
        /// [In Preview]: The configuration for the events emitted by this leaderboard. If not specified, no events will be emitted.
        /// </summary>
        public LeaderboardEventEmissionConfig EventEmissionConfig;
        /// <summary>
        /// Last time, in UTC, leaderboard version was incremented.
        /// </summary>
        public DateTime? LastResetTime;
        /// <summary>
        /// A name for the leaderboard, unique per title.
        /// </summary>
        public string Name;
        /// <summary>
        /// Maximum number of entries on this leaderboard
        /// </summary>
        public int SizeLimit;
        /// <summary>
        /// Latest Leaderboard version.
        /// </summary>
        public uint Version;
        /// <summary>
        /// The version reset configuration for the leaderboard definition.
        /// </summary>
        public VersionConfiguration VersionConfiguration;
    }

    [Serializable]
    public class LeaderboardEntityRankOnVersionEndConfig : PlayFabBaseModel
    {
        /// <summary>
        /// The type of event to emit when the leaderboard version end.
        /// </summary>
        public EventType EventType;
        /// <summary>
        /// The maximum number of entity to return on leaderboard version end. Range is 1 to 1000.
        /// </summary>
        public int RankLimit;
    }

    [Serializable]
    public class LeaderboardEntryUpdate : PlayFabBaseModel
    {
        /// <summary>
        /// The unique Id for the entry. If using PlayFab Entities, this would be the entityId of the entity.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Arbitrary metadata to store along side the leaderboard entry, will be returned by all Leaderboard APIs.
        /// </summary>
        public string Metadata;
        /// <summary>
        /// The scores for the leaderboard. The number of values provided here must match the number of columns in the Leaderboard
        /// definition.
        /// </summary>
        public List<string> Scores;
    }

    [Serializable]
    public class LeaderboardEventEmissionConfig : PlayFabBaseModel
    {
        /// <summary>
        /// This event emits the top ranks of the leaderboard when the leaderboard version end.
        /// </summary>
        public LeaderboardEntityRankOnVersionEndConfig EntityRankOnVersionEndConfig;
        /// <summary>
        /// This event is emitted when the leaderboard version end.
        /// </summary>
        public LeaderboardVersionEndConfig VersionEndConfig;
    }

    public enum LeaderboardSortDirection
    {
        Descending,
        Ascending
    }

    [Serializable]
    public class LeaderboardVersionEndConfig : PlayFabBaseModel
    {
        /// <summary>
        /// The type of event to emit when the leaderboard version end.
        /// </summary>
        public EventType EventType;
    }

    [Serializable]
    public class LinkedStatisticColumn : PlayFabBaseModel
    {
        /// <summary>
        /// The name of the statistic column that this leaderboard column is sourced from.
        /// </summary>
        public string LinkedStatisticColumnName;
        /// <summary>
        /// The name of the statistic.
        /// </summary>
        public string LinkedStatisticName;
    }

    [Serializable]
    public class ListLeaderboardDefinitionsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The page size for the request.
        /// </summary>
        public int? PageSize;
        /// <summary>
        /// The skip token for the paged request.
        /// </summary>
        public string SkipToken;
    }

    [Serializable]
    public class ListLeaderboardDefinitionsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// List of leaderboard definitions for the title.
        /// </summary>
        public List<LeaderboardDefinition> LeaderboardDefinitions;
        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;
        /// <summary>
        /// The skip token for the paged response.
        /// </summary>
        public string SkipToken;
    }

    [Serializable]
    public class ListStatisticDefinitionsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The page size for the request.
        /// </summary>
        public int? PageSize;
        /// <summary>
        /// The skip token for the paged request.
        /// </summary>
        public string SkipToken;
    }

    [Serializable]
    public class ListStatisticDefinitionsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;
        /// <summary>
        /// The skip token for the paged response.
        /// </summary>
        public string SkipToken;
        /// <summary>
        /// List of statistic definitions for the title.
        /// </summary>
        public List<StatisticDefinition> StatisticDefinitions;
    }

    public enum ResetInterval
    {
        Manual,
        Hour,
        Day,
        Week,
        Month
    }

    public enum StatisticAggregationMethod
    {
        Last,
        Min,
        Max,
        Sum
    }

    [Serializable]
    public class StatisticColumn : PlayFabBaseModel
    {
        /// <summary>
        /// Aggregation method for calculating new value of a statistic.
        /// </summary>
        public StatisticAggregationMethod AggregationMethod;
        /// <summary>
        /// Name of the statistic column, as originally configured.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class StatisticColumnCollection : PlayFabBaseModel
    {
        /// <summary>
        /// Columns for the statistic defining the aggregation method for each column.
        /// </summary>
        public List<StatisticColumn> Columns;
    }

    [Serializable]
    public class StatisticDefinition : PlayFabBaseModel
    {
        /// <summary>
        /// The list of statistic definitions names this definition aggregates to.
        /// </summary>
        public List<string> AggregationDestinations;
        /// <summary>
        /// The list of statistic definitions names whose values must be aggregated towards this stat. If AggregationSource is
        /// specified, the entityType of this definition MUST be Title (making it a CommunityStat). Currently, only one aggregation
        /// source can be specified.
        /// </summary>
        public List<string> AggregationSources;
        /// <summary>
        /// The columns for the statistic defining the aggregation method for each column.
        /// </summary>
        public List<StatisticColumn> Columns;
        /// <summary>
        /// Created time, in UTC
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// The entity type that can have this statistic.
        /// </summary>
        public string EntityType;
        /// <summary>
        /// [In Preview]: Configurations for different Statistics events that can be emitted by the service.
        /// </summary>
        public StatisticsEventEmissionConfig EventEmissionConfig;
        /// <summary>
        /// Last time, in UTC, statistic version was incremented.
        /// </summary>
        public DateTime? LastResetTime;
        /// <summary>
        /// The list of leaderboards that are linked to this statistic definition.
        /// </summary>
        public List<string> LinkedLeaderboardNames;
        /// <summary>
        /// Name of the statistic.
        /// </summary>
        public string Name;
        /// <summary>
        /// Statistic version.
        /// </summary>
        public uint Version;
        /// <summary>
        /// The version reset configuration for the leaderboard definition.
        /// </summary>
        public VersionConfiguration VersionConfiguration;
    }

    [Serializable]
    public class StatisticDelete : PlayFabBaseModel
    {
        /// <summary>
        /// Name of the statistic, as originally configured.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class StatisticsEventEmissionConfig : PlayFabBaseModel
    {
        /// <summary>
        /// Emitted when statistics are updated.
        /// </summary>
        public StatisticsUpdateEventConfig UpdateEventConfig;
    }

    [Serializable]
    public class StatisticsUpdateEventConfig : PlayFabBaseModel
    {
        /// <summary>
        /// The event type to emit when statistics are updated.
        /// </summary>
        public EventType EventType;
    }

    [Serializable]
    public class StatisticUpdate : PlayFabBaseModel
    {
        /// <summary>
        /// Arbitrary metadata to store along side the statistic, will be returned by all Leaderboard APIs.
        /// </summary>
        public string Metadata;
        /// <summary>
        /// Name of the statistic, as originally configured.
        /// </summary>
        public string Name;
        /// <summary>
        /// Statistic scores for the entity. This will be used in accordance with the aggregation method configured for the
        /// statistics.The maximum value allowed for each individual score is 9223372036854775807. The minimum value for each
        /// individual score is -9223372036854775807The values are formatted as strings to avoid interop issues with client
        /// libraries unable to handle 64bit integers.
        /// </summary>
        public List<string> Scores;
        /// <summary>
        /// Optional field to indicate the version of the statistic to set. When empty defaults to the statistic's current version.
        /// </summary>
        public uint? Version;
    }

    [Serializable]
    public class UnlinkAggregationSourceFromStatisticRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the statistic to unlink.
        /// </summary>
        public string Name;
        /// <summary>
        /// The name of the aggregation source statistic to unlink.
        /// </summary>
        public string SourceStatisticName;
    }

    [Serializable]
    public class UnlinkLeaderboardFromStatisticRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the leaderboard definition to unlink.
        /// </summary>
        public string Name;
        /// <summary>
        /// The name of the statistic definition to unlink.
        /// </summary>
        public string StatisticName;
    }

    [Serializable]
    public class UpdateLeaderboardDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// [In Preview]: The configuration for the events emitted by this leaderboard. If not specified, no events will be emitted.
        /// </summary>
        public LeaderboardEventEmissionConfig EventEmissionConfig;
        /// <summary>
        /// The name of the leaderboard to update the definition for.
        /// </summary>
        public string Name;
        /// <summary>
        /// Maximum number of entries on this leaderboard
        /// </summary>
        public int? SizeLimit;
        /// <summary>
        /// The version reset configuration for the leaderboard definition.
        /// </summary>
        public VersionConfiguration VersionConfiguration;
    }

    [Serializable]
    public class UpdateLeaderboardEntriesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entries to add or update on the leaderboard.
        /// </summary>
        public List<LeaderboardEntryUpdate> Entries;
        /// <summary>
        /// The name of the leaderboard.
        /// </summary>
        public string LeaderboardName;
    }

    [Serializable]
    public class UpdateStatisticDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// [In Preview]: Configurations for different Statistics events that can be emitted by the service.
        /// </summary>
        public StatisticsEventEmissionConfig EventEmissionConfig;
        /// <summary>
        /// Name of the statistic. Must be less than 150 characters. Restricted to a-Z, 0-9, '(', ')', '_', '-' and '.'.
        /// </summary>
        public string Name;
        /// <summary>
        /// The version reset configuration for the statistic definition.
        /// </summary>
        public VersionConfiguration VersionConfiguration;
    }

    [Serializable]
    public class UpdateStatisticsRequest : PlayFabRequestCommon
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
        /// Collection of statistics to update, maximum 50.
        /// </summary>
        public List<StatisticUpdate> Statistics;
        /// <summary>
        /// Optional transactionId of this update which can be used to ensure idempotence.
        /// </summary>
        public string TransactionId;
    }

    [Serializable]
    public class UpdateStatisticsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// A mapping of statistic name to the columns defined in the corresponding definition.
        /// </summary>
        public Dictionary<string,StatisticColumnCollection> ColumnDetails;
        /// <summary>
        /// The entity id and type.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Updated entity profile statistics.
        /// </summary>
        public Dictionary<string,EntityStatisticValue> Statistics;
    }

    [Serializable]
    public class VersionConfiguration : PlayFabBaseModel
    {
        /// <summary>
        /// The maximum number of versions of this leaderboard/statistic that can be queried.
        /// </summary>
        public int MaxQueryableVersions;
        /// <summary>
        /// Reset interval that statistics or leaderboards will reset on. When using Manual intervalthe reset can only be increased
        /// by calling the Increase version API. When using Hour interval the resetwill occur at the start of the next hour UTC
        /// time. When using Day interval the reset will occur at thestart of the next day in UTC time. When using the Week interval
        /// the reset will occur at the start ofthe next Monday in UTC time. When using Month interval the reset will occur at the
        /// start of the nextmonth in UTC time.
        /// </summary>
        public ResetInterval ResetInterval;
    }
}
#endif
