#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ExperimentationModels
{
    public enum AnalysisTaskState
    {
        Waiting,
        ReadyForSubmission,
        SubmittingToPipeline,
        Running,
        Completed,
        Failed,
        Canceled
    }

    /// <summary>
    /// Given a title entity token and exclusion group details, will create a new exclusion group for the title.
    /// </summary>
    [Serializable]
    public class CreateExclusionGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Description of the exclusion group.
        /// </summary>
        public string Description;
        /// <summary>
        /// Friendly name of the exclusion group.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class CreateExclusionGroupResult : PlayFabResultCommon
    {
        /// <summary>
        /// Identifier of the exclusion group.
        /// </summary>
        public string ExclusionGroupId;
    }

    /// <summary>
    /// Given a title entity token and experiment details, will create a new experiment for the title.
    /// </summary>
    [Serializable]
    public class CreateExperimentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Description of the experiment.
        /// </summary>
        public string Description;
        /// <summary>
        /// When experiment should end.
        /// </summary>
        public DateTime? EndDate;
        /// <summary>
        /// Id of the exclusion group.
        /// </summary>
        public string ExclusionGroupId;
        /// <summary>
        /// Percentage of exclusion group traffic that will see this experiment.
        /// </summary>
        public uint? ExclusionGroupTrafficAllocation;
        /// <summary>
        /// Type of experiment.
        /// </summary>
        public ExperimentType? ExperimentType;
        /// <summary>
        /// Friendly name of the experiment.
        /// </summary>
        public string Name;
        /// <summary>
        /// Id of the segment to which this experiment applies. Defaults to the 'All Players' segment.
        /// </summary>
        public string SegmentId;
        /// <summary>
        /// When experiment should start.
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// List of title player account IDs that automatically receive treatments in the experiment, but are not included when
        /// calculating experiment metrics.
        /// </summary>
        public List<string> TitlePlayerAccountTestIds;
        /// <summary>
        /// List of variants for the experiment.
        /// </summary>
        public List<Variant> Variants;
    }

    [Serializable]
    public class CreateExperimentResult : PlayFabResultCommon
    {
        /// <summary>
        /// The ID of the new experiment.
        /// </summary>
        public string ExperimentId;
    }

    /// <summary>
    /// Given an entity token and an exclusion group ID this API deletes the exclusion group.
    /// </summary>
    [Serializable]
    public class DeleteExclusionGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The ID of the exclusion group to delete.
        /// </summary>
        public string ExclusionGroupId;
    }

    /// <summary>
    /// Given an entity token and an experiment ID this API deletes the experiment. A running experiment must be stopped before
    /// it can be deleted.
    /// </summary>
    [Serializable]
    public class DeleteExperimentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The ID of the experiment to delete.
        /// </summary>
        public string ExperimentId;
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

    [Serializable]
    public class ExclusionGroupTrafficAllocation : PlayFabBaseModel
    {
        /// <summary>
        /// Id of the experiment.
        /// </summary>
        public string ExperimentId;
        /// <summary>
        /// Percentage of exclusion group traffic that will see this experiment.
        /// </summary>
        public uint TrafficAllocation;
    }

    [Serializable]
    public class Experiment : PlayFabBaseModel
    {
        /// <summary>
        /// Description of the experiment.
        /// </summary>
        public string Description;
        /// <summary>
        /// When experiment should end/was ended.
        /// </summary>
        public DateTime? EndDate;
        /// <summary>
        /// Id of the exclusion group for this experiment.
        /// </summary>
        public string ExclusionGroupId;
        /// <summary>
        /// Percentage of exclusion group traffic that will see this experiment.
        /// </summary>
        public uint? ExclusionGroupTrafficAllocation;
        /// <summary>
        /// Type of experiment.
        /// </summary>
        public ExperimentType? ExperimentType;
        /// <summary>
        /// Id of the experiment.
        /// </summary>
        public string Id;
        /// <summary>
        /// Friendly name of the experiment.
        /// </summary>
        public string Name;
        /// <summary>
        /// Id of the segment to which this experiment applies. Defaults to the 'All Players' segment.
        /// </summary>
        public string SegmentId;
        /// <summary>
        /// When experiment should start/was started.
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// State experiment is currently in.
        /// </summary>
        public ExperimentState? State;
        /// <summary>
        /// List of title player account IDs that automatically receive treatments in the experiment, but are not included when
        /// calculating experiment metrics.
        /// </summary>
        public List<string> TitlePlayerAccountTestIds;
        /// <summary>
        /// List of variants for the experiment.
        /// </summary>
        public List<Variant> Variants;
    }

    [Serializable]
    public class ExperimentExclusionGroup : PlayFabBaseModel
    {
        /// <summary>
        /// Description of the exclusion group.
        /// </summary>
        public string Description;
        /// <summary>
        /// Id of the exclusion group.
        /// </summary>
        public string ExclusionGroupId;
        /// <summary>
        /// Friendly name of the exclusion group.
        /// </summary>
        public string Name;
    }

    public enum ExperimentState
    {
        New,
        Started,
        Stopped,
        Deleted
    }

    public enum ExperimentType
    {
        Active,
        Snapshot
    }

    /// <summary>
    /// Given a title entity token will return the list of all exclusion groups for a title.
    /// </summary>
    [Serializable]
    public class GetExclusionGroupsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class GetExclusionGroupsResult : PlayFabResultCommon
    {
        /// <summary>
        /// List of exclusion groups for the title.
        /// </summary>
        public List<ExperimentExclusionGroup> ExclusionGroups;
    }

    /// <summary>
    /// Given a title entity token and an exclusion group ID, will return the list of traffic allocations for the exclusion
    /// group.
    /// </summary>
    [Serializable]
    public class GetExclusionGroupTrafficRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The ID of the exclusion group.
        /// </summary>
        public string ExclusionGroupId;
    }

    [Serializable]
    public class GetExclusionGroupTrafficResult : PlayFabResultCommon
    {
        /// <summary>
        /// List of traffic allocations for the exclusion group.
        /// </summary>
        public List<ExclusionGroupTrafficAllocation> TrafficAllocations;
    }

    /// <summary>
    /// Given a title entity token will return the list of all experiments for a title, including scheduled, started, stopped or
    /// completed experiments.
    /// </summary>
    [Serializable]
    public class GetExperimentsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class GetExperimentsResult : PlayFabResultCommon
    {
        /// <summary>
        /// List of experiments for the title.
        /// </summary>
        public List<Experiment> Experiments;
    }

    /// <summary>
    /// Given a title entity token and experiment details, will return the latest available scorecard.
    /// </summary>
    [Serializable]
    public class GetLatestScorecardRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The ID of the experiment.
        /// </summary>
        public string ExperimentId;
    }

    [Serializable]
    public class GetLatestScorecardResult : PlayFabResultCommon
    {
        /// <summary>
        /// Scorecard for the experiment of the title.
        /// </summary>
        public Scorecard Scorecard;
    }

    /// <summary>
    /// Given a title player or a title entity token, returns the treatment variants and variables assigned to the entity across
    /// all running experiments
    /// </summary>
    [Serializable]
    public class GetTreatmentAssignmentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetTreatmentAssignmentResult : PlayFabResultCommon
    {
        /// <summary>
        /// Treatment assignment for the entity.
        /// </summary>
        public TreatmentAssignment TreatmentAssignment;
    }

    [Serializable]
    public class MetricData : PlayFabBaseModel
    {
        /// <summary>
        /// The upper bound of the confidence interval for the relative delta (Delta.RelativeValue).
        /// </summary>
        public double ConfidenceIntervalEnd;
        /// <summary>
        /// The lower bound of the confidence interval for the relative delta (Delta.RelativeValue).
        /// </summary>
        public double ConfidenceIntervalStart;
        /// <summary>
        /// The absolute delta between TreatmentStats.Average and ControlStats.Average.
        /// </summary>
        public float DeltaAbsoluteChange;
        /// <summary>
        /// The relative delta ratio between TreatmentStats.Average and ControlStats.Average.
        /// </summary>
        public float DeltaRelativeChange;
        /// <summary>
        /// The machine name of the metric.
        /// </summary>
        public string InternalName;
        /// <summary>
        /// Indicates if a movement was detected on that metric.
        /// </summary>
        public string Movement;
        /// <summary>
        /// The readable name of the metric.
        /// </summary>
        public string Name;
        /// <summary>
        /// The expectation that a movement is real
        /// </summary>
        public float PMove;
        /// <summary>
        /// The p-value resulting from the statistical test run for this metric
        /// </summary>
        public float PValue;
        /// <summary>
        /// The threshold for observing sample ratio mismatch.
        /// </summary>
        public float PValueThreshold;
        /// <summary>
        /// Indicates if the movement is statistically significant.
        /// </summary>
        public string StatSigLevel;
        /// <summary>
        /// Observed standard deviation value of the metric.
        /// </summary>
        public float StdDev;
        /// <summary>
        /// Observed average value of the metric.
        /// </summary>
        public float Value;
    }

    [Serializable]
    public class Scorecard : PlayFabBaseModel
    {
        /// <summary>
        /// Represents the date the scorecard was generated.
        /// </summary>
        public string DateGenerated;
        /// <summary>
        /// Represents the duration of scorecard analysis.
        /// </summary>
        public string Duration;
        /// <summary>
        /// Represents the number of events processed for the generation of this scorecard
        /// </summary>
        public double EventsProcessed;
        /// <summary>
        /// Id of the experiment.
        /// </summary>
        public string ExperimentId;
        /// <summary>
        /// Friendly name of the experiment.
        /// </summary>
        public string ExperimentName;
        /// <summary>
        /// Represents the latest compute job status.
        /// </summary>
        public AnalysisTaskState? LatestJobStatus;
        /// <summary>
        /// Represents the presence of a sample ratio mismatch in the scorecard data.
        /// </summary>
        public bool SampleRatioMismatch;
        /// <summary>
        /// Scorecard containing list of analysis.
        /// </summary>
        public List<ScorecardDataRow> ScorecardDataRows;
    }

    [Serializable]
    public class ScorecardDataRow : PlayFabBaseModel
    {
        /// <summary>
        /// Represents whether the variant is control or not.
        /// </summary>
        public bool IsControl;
        /// <summary>
        /// Data of the analysis with the internal name of the metric as the key and an object of metric data as value.
        /// </summary>
        public Dictionary<string,MetricData> MetricDataRows;
        /// <summary>
        /// Represents the player count in the variant.
        /// </summary>
        public uint PlayerCount;
        /// <summary>
        /// Name of the variant of analysis.
        /// </summary>
        public string VariantName;
    }

    /// <summary>
    /// Given a title entity token and an experiment ID, this API starts the experiment.
    /// </summary>
    [Serializable]
    public class StartExperimentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The ID of the experiment to start.
        /// </summary>
        public string ExperimentId;
    }

    /// <summary>
    /// Given a title entity token and an experiment ID, this API stops the experiment if it is running.
    /// </summary>
    [Serializable]
    public class StopExperimentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The ID of the experiment to stop.
        /// </summary>
        public string ExperimentId;
    }

    [Serializable]
    public class TreatmentAssignment : PlayFabBaseModel
    {
        /// <summary>
        /// List of the experiment variables.
        /// </summary>
        public List<Variable> Variables;
        /// <summary>
        /// List of the experiment variants.
        /// </summary>
        public List<string> Variants;
    }

    /// <summary>
    /// Given an entity token and exclusion group details this API updates the exclusion group.
    /// </summary>
    [Serializable]
    public class UpdateExclusionGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Description of the exclusion group.
        /// </summary>
        public string Description;
        /// <summary>
        /// The ID of the exclusion group to update.
        /// </summary>
        public string ExclusionGroupId;
        /// <summary>
        /// Friendly name of the exclusion group.
        /// </summary>
        public string Name;
    }

    /// <summary>
    /// Given a title entity token and experiment details, this API updates the experiment. If an experiment is already running,
    /// only the description and duration properties can be updated.
    /// </summary>
    [Serializable]
    public class UpdateExperimentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Description of the experiment.
        /// </summary>
        public string Description;
        /// <summary>
        /// When experiment should end.
        /// </summary>
        public DateTime? EndDate;
        /// <summary>
        /// Id of the exclusion group.
        /// </summary>
        public string ExclusionGroupId;
        /// <summary>
        /// Percentage of exclusion group traffic that will see this experiment.
        /// </summary>
        public uint? ExclusionGroupTrafficAllocation;
        /// <summary>
        /// Type of experiment.
        /// </summary>
        public ExperimentType? ExperimentType;
        /// <summary>
        /// Id of the experiment.
        /// </summary>
        public string Id;
        /// <summary>
        /// Friendly name of the experiment.
        /// </summary>
        public string Name;
        /// <summary>
        /// Id of the segment to which this experiment applies. Defaults to the 'All Players' segment.
        /// </summary>
        public string SegmentId;
        /// <summary>
        /// When experiment should start.
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// List of title player account IDs that automatically receive treatments in the experiment, but are not included when
        /// calculating experiment metrics.
        /// </summary>
        public List<string> TitlePlayerAccountTestIds;
        /// <summary>
        /// List of variants for the experiment.
        /// </summary>
        public List<Variant> Variants;
    }

    [Serializable]
    public class Variable : PlayFabBaseModel
    {
        /// <summary>
        /// Name of the variable.
        /// </summary>
        public string Name;
        /// <summary>
        /// Value of the variable.
        /// </summary>
        public string Value;
    }

    [Serializable]
    public class Variant : PlayFabBaseModel
    {
        /// <summary>
        /// Description of the variant.
        /// </summary>
        public string Description;
        /// <summary>
        /// Id of the variant.
        /// </summary>
        public string Id;
        /// <summary>
        /// Specifies if variant is control for experiment.
        /// </summary>
        public bool IsControl;
        /// <summary>
        /// Name of the variant.
        /// </summary>
        public string Name;
        /// <summary>
        /// Id of the TitleDataOverride to use with this variant.
        /// </summary>
        public string TitleDataOverrideLabel;
        /// <summary>
        /// Percentage of target audience traffic that will see this variant.
        /// </summary>
        public uint TrafficPercentage;
        /// <summary>
        /// Variables returned by this variant.
        /// </summary>
        public List<Variable> Variables;
    }
}
#endif
