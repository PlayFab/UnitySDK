#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.MultiplayerModels
{
    public enum AccessPolicy
    {
        Public,
        Friends,
        Private
    }

    [Serializable]
    public class AssetReference : PlayFabBaseModel
    {
        /// <summary>
        /// The asset's file name. This is a filename with the .zip, .tar, or .tar.gz extension.
        /// </summary>
        public string FileName;
        /// <summary>
        /// The asset's mount path.
        /// </summary>
        public string MountPath;
    }

    [Serializable]
    public class AssetReferenceParams : PlayFabBaseModel
    {
        /// <summary>
        /// The asset's file name.
        /// </summary>
        public string FileName;
        /// <summary>
        /// The asset's mount path.
        /// </summary>
        public string MountPath;
    }

    [Serializable]
    public class AssetSummary : PlayFabBaseModel
    {
        /// <summary>
        /// The asset's file name. This is a filename with the .zip, .tar, or .tar.gz extension.
        /// </summary>
        public string FileName;
        /// <summary>
        /// The metadata associated with the asset.
        /// </summary>
        public Dictionary<string,string> Metadata;
    }

    public enum AttributeMergeFunction
    {
        Min,
        Max,
        Average
    }

    public enum AttributeNotSpecifiedBehavior
    {
        UseDefault,
        MatchAny
    }

    public enum AttributeSource
    {
        User,
        PlayerEntity
    }

    public enum AzureRegion
    {
        AustraliaEast,
        AustraliaSoutheast,
        BrazilSouth,
        CentralUs,
        EastAsia,
        EastUs,
        EastUs2,
        JapanEast,
        JapanWest,
        NorthCentralUs,
        NorthEurope,
        SouthCentralUs,
        SoutheastAsia,
        WestEurope,
        WestUs,
        SouthAfricaNorth,
        WestCentralUs,
        KoreaCentral,
        FranceCentral,
        WestUs2,
        CentralIndia,
        UaeNorth,
        UkSouth
    }

    public enum AzureVmFamily
    {
        A,
        Av2,
        Dv2,
        Dv3,
        F,
        Fsv2,
        Dasv4,
        Dav4,
        Eav4,
        Easv4,
        Ev4,
        Esv4,
        Dsv3,
        Dsv2,
        NCasT4_v3,
        Ddv4,
        Ddsv4,
        HBv3
    }

    public enum AzureVmSize
    {
        Standard_A1,
        Standard_A2,
        Standard_A3,
        Standard_A4,
        Standard_A1_v2,
        Standard_A2_v2,
        Standard_A4_v2,
        Standard_A8_v2,
        Standard_D1_v2,
        Standard_D2_v2,
        Standard_D3_v2,
        Standard_D4_v2,
        Standard_D5_v2,
        Standard_D2_v3,
        Standard_D4_v3,
        Standard_D8_v3,
        Standard_D16_v3,
        Standard_F1,
        Standard_F2,
        Standard_F4,
        Standard_F8,
        Standard_F16,
        Standard_F2s_v2,
        Standard_F4s_v2,
        Standard_F8s_v2,
        Standard_F16s_v2,
        Standard_D2as_v4,
        Standard_D4as_v4,
        Standard_D8as_v4,
        Standard_D16as_v4,
        Standard_D2a_v4,
        Standard_D4a_v4,
        Standard_D8a_v4,
        Standard_D16a_v4,
        Standard_E2a_v4,
        Standard_E4a_v4,
        Standard_E8a_v4,
        Standard_E16a_v4,
        Standard_E2as_v4,
        Standard_E4as_v4,
        Standard_E8as_v4,
        Standard_E16as_v4,
        Standard_D2s_v3,
        Standard_D4s_v3,
        Standard_D8s_v3,
        Standard_D16s_v3,
        Standard_DS1_v2,
        Standard_DS2_v2,
        Standard_DS3_v2,
        Standard_DS4_v2,
        Standard_DS5_v2,
        Standard_NC4as_T4_v3,
        Standard_D2d_v4,
        Standard_D4d_v4,
        Standard_D8d_v4,
        Standard_D16d_v4,
        Standard_D2ds_v4,
        Standard_D4ds_v4,
        Standard_D8ds_v4,
        Standard_D16ds_v4,
        Standard_HB120_16rs_v3,
        Standard_HB120_32rs_v3,
        Standard_HB120_64rs_v3,
        Standard_HB120_96rs_v3,
        Standard_HB120rs_v3
    }

    [Serializable]
    public class BuildAliasDetailsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The guid string alias Id of the alias to be created or updated.
        /// </summary>
        public string AliasId;
        /// <summary>
        /// The alias name.
        /// </summary>
        public string AliasName;
        /// <summary>
        /// Array of build selection criteria.
        /// </summary>
        public List<BuildSelectionCriterion> BuildSelectionCriteria;
    }

    [Serializable]
    public class BuildAliasParams : PlayFabBaseModel
    {
        /// <summary>
        /// The guid string alias ID to use for the request.
        /// </summary>
        public string AliasId;
    }

    [Serializable]
    public class BuildRegion : PlayFabBaseModel
    {
        /// <summary>
        /// The current multiplayer server stats for the region.
        /// </summary>
        public CurrentServerStats CurrentServerStats;
        /// <summary>
        /// Optional settings to control dynamic adjustment of standby target
        /// </summary>
        public DynamicStandbySettings DynamicStandbySettings;
        /// <summary>
        /// Whether the game assets provided for the build have been replicated to this region.
        /// </summary>
        public bool IsAssetReplicationComplete;
        /// <summary>
        /// The maximum number of multiplayer servers for the region.
        /// </summary>
        public int MaxServers;
        /// <summary>
        /// Regional override for the number of multiplayer servers to host on a single VM of the build.
        /// </summary>
        public int? MultiplayerServerCountPerVm;
        /// <summary>
        /// The build region.
        /// </summary>
        public string Region;
        /// <summary>
        /// Optional settings to set the standby target to specified values during the supplied schedules
        /// </summary>
        public ScheduledStandbySettings ScheduledStandbySettings;
        /// <summary>
        /// The target number of standby multiplayer servers for the region.
        /// </summary>
        public int StandbyServers;
        /// <summary>
        /// The status of multiplayer servers in the build region. Valid values are - Unknown, Initialized, Deploying, Deployed,
        /// Unhealthy, Deleting, Deleted.
        /// </summary>
        public string Status;
        /// <summary>
        /// Regional override for the VM size the build was created on.
        /// </summary>
        public AzureVmSize? VmSize;
    }

    [Serializable]
    public class BuildRegionParams : PlayFabBaseModel
    {
        /// <summary>
        /// Optional settings to control dynamic adjustment of standby target. If not specified, dynamic standby is disabled
        /// </summary>
        public DynamicStandbySettings DynamicStandbySettings;
        /// <summary>
        /// The maximum number of multiplayer servers for the region.
        /// </summary>
        public int MaxServers;
        /// <summary>
        /// Regional override for the number of multiplayer servers to host on a single VM of the build.
        /// </summary>
        public int? MultiplayerServerCountPerVm;
        /// <summary>
        /// The build region.
        /// </summary>
        public string Region;
        /// <summary>
        /// Optional settings to set the standby target to specified values during the supplied schedules
        /// </summary>
        public ScheduledStandbySettings ScheduledStandbySettings;
        /// <summary>
        /// The number of standby multiplayer servers for the region.
        /// </summary>
        public int StandbyServers;
        /// <summary>
        /// Regional override for the VM size the build was created on.
        /// </summary>
        public AzureVmSize? VmSize;
    }

    [Serializable]
    public class BuildSelectionCriterion : PlayFabBaseModel
    {
        /// <summary>
        /// Dictionary of build ids and their respective weights for distribution of allocation requests.
        /// </summary>
        public Dictionary<string,uint> BuildWeightDistribution;
    }

    [Serializable]
    public class BuildSummary : PlayFabBaseModel
    {
        /// <summary>
        /// The guid string build ID of the build.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The build name.
        /// </summary>
        public string BuildName;
        /// <summary>
        /// The time the build was created in UTC.
        /// </summary>
        public DateTime? CreationTime;
        /// <summary>
        /// The metadata of the build.
        /// </summary>
        public Dictionary<string,string> Metadata;
        /// <summary>
        /// The configuration and status for each region in the build.
        /// </summary>
        public List<BuildRegion> RegionConfigurations;
    }

    /// <summary>
    /// Cancels all tickets of which the player is a member in a given queue that are not cancelled or matched. This API is
    /// useful if you lose track of what tickets the player is a member of (if the title crashes for instance) and want to
    /// "reset". The Entity field is optional if the caller is a player and defaults to that player. Players may not cancel
    /// tickets for other people. The Entity field is required if the caller is a server (authenticated as the title).
    /// </summary>
    [Serializable]
    public class CancelAllMatchmakingTicketsForPlayerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity key of the player whose tickets should be canceled.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The name of the queue from which a player's tickets should be canceled.
        /// </summary>
        public string QueueName;
    }

    [Serializable]
    public class CancelAllMatchmakingTicketsForPlayerResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Cancels all backfill tickets of which the player is a member in a given queue that are not cancelled or matched. This
    /// API is useful if you lose track of what tickets the player is a member of (if the server crashes for instance) and want
    /// to "reset".
    /// </summary>
    [Serializable]
    public class CancelAllServerBackfillTicketsForPlayerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity key of the player whose backfill tickets should be canceled.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The name of the queue from which a player's backfill tickets should be canceled.
        /// </summary>
        public string QueueName;
    }

    [Serializable]
    public class CancelAllServerBackfillTicketsForPlayerResult : PlayFabResultCommon
    {
    }

    public enum CancellationReason
    {
        Requested,
        Internal,
        Timeout
    }

    /// <summary>
    /// Only servers and ticket members can cancel a ticket. The ticket can be in five different states when it is cancelled. 1:
    /// the ticket is waiting for members to join it, and it has not started matching. If the ticket is cancelled at this stage,
    /// it will never match. 2: the ticket is matching. If the ticket is cancelled, it will stop matching. 3: the ticket is
    /// matched. A matched ticket cannot be cancelled. 4: the ticket is already cancelled and nothing happens. 5: the ticket is
    /// waiting for a server. If the ticket is cancelled, server allocation will be stopped. A server may still be allocated due
    /// to a race condition, but that will not be reflected in the ticket. There may be race conditions between the ticket
    /// getting matched and the client making a cancellation request. The client must handle the possibility that the cancel
    /// request fails if a match is found before the cancellation request is processed. We do not allow resubmitting a cancelled
    /// ticket because players must consent to enter matchmaking again. Create a new ticket instead.
    /// </summary>
    [Serializable]
    public class CancelMatchmakingTicketRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the queue the ticket is in.
        /// </summary>
        public string QueueName;
        /// <summary>
        /// The Id of the ticket to find a match for.
        /// </summary>
        public string TicketId;
    }

    [Serializable]
    public class CancelMatchmakingTicketResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Only servers can cancel a backfill ticket. The ticket can be in three different states when it is cancelled. 1: the
    /// ticket is matching. If the ticket is cancelled, it will stop matching. 2: the ticket is matched. A matched ticket cannot
    /// be cancelled. 3: the ticket is already cancelled and nothing happens. There may be race conditions between the ticket
    /// getting matched and the server making a cancellation request. The server must handle the possibility that the cancel
    /// request fails if a match is found before the cancellation request is processed. We do not allow resubmitting a cancelled
    /// ticket. Create a new ticket instead.
    /// </summary>
    [Serializable]
    public class CancelServerBackfillTicketRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the queue the ticket is in.
        /// </summary>
        public string QueueName;
        /// <summary>
        /// The Id of the ticket to find a match for.
        /// </summary>
        public string TicketId;
    }

    [Serializable]
    public class CancelServerBackfillTicketResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class Certificate : PlayFabBaseModel
    {
        /// <summary>
        /// Base64 encoded string contents of the certificate.
        /// </summary>
        public string Base64EncodedValue;
        /// <summary>
        /// A name for the certificate. This is used to reference certificates in build configurations.
        /// </summary>
        public string Name;
        /// <summary>
        /// If required for your PFX certificate, use this field to provide a password that will be used to install the certificate
        /// on the container.
        /// </summary>
        public string Password;
    }

    [Serializable]
    public class CertificateSummary : PlayFabBaseModel
    {
        /// <summary>
        /// The name of the certificate.
        /// </summary>
        public string Name;
        /// <summary>
        /// The thumbprint for the certificate.
        /// </summary>
        public string Thumbprint;
    }

    [Serializable]
    public class ConnectedPlayer : PlayFabBaseModel
    {
        /// <summary>
        /// The player ID of the player connected to the multiplayer server.
        /// </summary>
        public string PlayerId;
    }

    public enum ContainerFlavor
    {
        ManagedWindowsServerCore,
        CustomLinux,
        ManagedWindowsServerCorePreview,
        Invalid
    }

    [Serializable]
    public class ContainerImageReference : PlayFabBaseModel
    {
        /// <summary>
        /// The container image name.
        /// </summary>
        public string ImageName;
        /// <summary>
        /// The container tag.
        /// </summary>
        public string Tag;
    }

    [Serializable]
    public class CoreCapacity : PlayFabBaseModel
    {
        /// <summary>
        /// The available core capacity for the (Region, VmFamily)
        /// </summary>
        public int Available;
        /// <summary>
        /// The AzureRegion
        /// </summary>
        public string Region;
        /// <summary>
        /// The total core capacity for the (Region, VmFamily)
        /// </summary>
        public int Total;
        /// <summary>
        /// The AzureVmFamily
        /// </summary>
        public AzureVmFamily? VmFamily;
    }

    [Serializable]
    public class CoreCapacityChange : PlayFabBaseModel
    {
        /// <summary>
        /// New quota core limit for the given vm family/region.
        /// </summary>
        public int NewCoreLimit;
        /// <summary>
        /// Region to change.
        /// </summary>
        public string Region;
        /// <summary>
        /// Virtual machine family to change.
        /// </summary>
        public AzureVmFamily VmFamily;
    }

    /// <summary>
    /// Creates a multiplayer server build alias and returns the created alias.
    /// </summary>
    [Serializable]
    public class CreateBuildAliasRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The alias name.
        /// </summary>
        public string AliasName;
        /// <summary>
        /// Array of build selection criteria.
        /// </summary>
        public List<BuildSelectionCriterion> BuildSelectionCriteria;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    /// <summary>
    /// Creates a multiplayer server build with a custom container and returns information about the build creation request.
    /// </summary>
    [Serializable]
    public class CreateBuildWithCustomContainerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// When true, assets will not be copied for each server inside the VM. All serverswill run from the same set of assets, or
        /// will have the same assets mounted in the container.
        /// </summary>
        public bool? AreAssetsReadonly;
        /// <summary>
        /// The build name.
        /// </summary>
        public string BuildName;
        /// <summary>
        /// The flavor of container to create a build from.
        /// </summary>
        public ContainerFlavor? ContainerFlavor;
        /// <summary>
        /// The container reference, consisting of the image name and tag.
        /// </summary>
        public ContainerImageReference ContainerImageReference;
        /// <summary>
        /// The container command to run when the multiplayer server has been allocated, including any arguments.
        /// </summary>
        public string ContainerRunCommand;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The list of game assets related to the build.
        /// </summary>
        public List<AssetReferenceParams> GameAssetReferences;
        /// <summary>
        /// The game certificates for the build.
        /// </summary>
        public List<GameCertificateReferenceParams> GameCertificateReferences;
        /// <summary>
        /// The Linux instrumentation configuration for the build.
        /// </summary>
        public LinuxInstrumentationConfiguration LinuxInstrumentationConfiguration;
        /// <summary>
        /// Metadata to tag the build. The keys are case insensitive. The build metadata is made available to the server through
        /// Game Server SDK (GSDK).Constraints: Maximum number of keys: 30, Maximum key length: 50, Maximum value length: 100
        /// </summary>
        public Dictionary<string,string> Metadata;
        /// <summary>
        /// The configuration for the monitoring application on the build
        /// </summary>
        public MonitoringApplicationConfigurationParams MonitoringApplicationConfiguration;
        /// <summary>
        /// The number of multiplayer servers to host on a single VM.
        /// </summary>
        public int MultiplayerServerCountPerVm;
        /// <summary>
        /// The ports to map the build on.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The region configurations for the build.
        /// </summary>
        public List<BuildRegionParams> RegionConfigurations;
        /// <summary>
        /// When true, assets will be downloaded and uncompressed in memory, without the compressedversion being written first to
        /// disc.
        /// </summary>
        public bool? UseStreamingForAssetDownloads;
        /// <summary>
        /// The VM size to create the build on.
        /// </summary>
        public AzureVmSize? VmSize;
    }

    [Serializable]
    public class CreateBuildWithCustomContainerResponse : PlayFabResultCommon
    {
        /// <summary>
        /// When true, assets will not be copied for each server inside the VM. All serverswill run from the same set of assets, or
        /// will have the same assets mounted in the container.
        /// </summary>
        public bool? AreAssetsReadonly;
        /// <summary>
        /// The guid string build ID. Must be unique for every build.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The build name.
        /// </summary>
        public string BuildName;
        /// <summary>
        /// The flavor of container of the build.
        /// </summary>
        public ContainerFlavor? ContainerFlavor;
        /// <summary>
        /// The container command to run when the multiplayer server has been allocated, including any arguments.
        /// </summary>
        public string ContainerRunCommand;
        /// <summary>
        /// The time the build was created in UTC.
        /// </summary>
        public DateTime? CreationTime;
        /// <summary>
        /// The custom game container image reference information.
        /// </summary>
        public ContainerImageReference CustomGameContainerImage;
        /// <summary>
        /// The game assets for the build.
        /// </summary>
        public List<AssetReference> GameAssetReferences;
        /// <summary>
        /// The game certificates for the build.
        /// </summary>
        public List<GameCertificateReference> GameCertificateReferences;
        /// <summary>
        /// The Linux instrumentation configuration for this build.
        /// </summary>
        public LinuxInstrumentationConfiguration LinuxInstrumentationConfiguration;
        /// <summary>
        /// The metadata of the build.
        /// </summary>
        public Dictionary<string,string> Metadata;
        /// <summary>
        /// The configuration for the monitoring application for the build
        /// </summary>
        public MonitoringApplicationConfiguration MonitoringApplicationConfiguration;
        /// <summary>
        /// The number of multiplayer servers to host on a single VM of the build.
        /// </summary>
        public int MultiplayerServerCountPerVm;
        /// <summary>
        /// The OS platform used for running the game process.
        /// </summary>
        public string OsPlatform;
        /// <summary>
        /// The ports the build is mapped on.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The region configuration for the build.
        /// </summary>
        public List<BuildRegion> RegionConfigurations;
        /// <summary>
        /// The type of game server being hosted.
        /// </summary>
        public string ServerType;
        /// <summary>
        /// When true, assets will be downloaded and uncompressed in memory, without the compressedversion being written first to
        /// disc.
        /// </summary>
        public bool? UseStreamingForAssetDownloads;
        /// <summary>
        /// The VM size the build was created on.
        /// </summary>
        public AzureVmSize? VmSize;
    }

    /// <summary>
    /// Creates a multiplayer server build with a managed container and returns information about the build creation request.
    /// </summary>
    [Serializable]
    public class CreateBuildWithManagedContainerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// When true, assets will not be copied for each server inside the VM. All serverswill run from the same set of assets, or
        /// will have the same assets mounted in the container.
        /// </summary>
        public bool? AreAssetsReadonly;
        /// <summary>
        /// The build name.
        /// </summary>
        public string BuildName;
        /// <summary>
        /// The flavor of container to create a build from.
        /// </summary>
        public ContainerFlavor? ContainerFlavor;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The list of game assets related to the build.
        /// </summary>
        public List<AssetReferenceParams> GameAssetReferences;
        /// <summary>
        /// The game certificates for the build.
        /// </summary>
        public List<GameCertificateReferenceParams> GameCertificateReferences;
        /// <summary>
        /// The directory containing the game executable. This would be the start path of the game assets that contain the main game
        /// server executable. If not provided, a best effort will be made to extract it from the start game command.
        /// </summary>
        public string GameWorkingDirectory;
        /// <summary>
        /// The instrumentation configuration for the build.
        /// </summary>
        public InstrumentationConfiguration InstrumentationConfiguration;
        /// <summary>
        /// Metadata to tag the build. The keys are case insensitive. The build metadata is made available to the server through
        /// Game Server SDK (GSDK).Constraints: Maximum number of keys: 30, Maximum key length: 50, Maximum value length: 100
        /// </summary>
        public Dictionary<string,string> Metadata;
        /// <summary>
        /// The configuration for the monitoring application on the build
        /// </summary>
        public MonitoringApplicationConfigurationParams MonitoringApplicationConfiguration;
        /// <summary>
        /// The number of multiplayer servers to host on a single VM.
        /// </summary>
        public int MultiplayerServerCountPerVm;
        /// <summary>
        /// The ports to map the build on.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The region configurations for the build.
        /// </summary>
        public List<BuildRegionParams> RegionConfigurations;
        /// <summary>
        /// The command to run when the multiplayer server is started, including any arguments.
        /// </summary>
        public string StartMultiplayerServerCommand;
        /// <summary>
        /// When true, assets will be downloaded and uncompressed in memory, without the compressedversion being written first to
        /// disc.
        /// </summary>
        public bool? UseStreamingForAssetDownloads;
        /// <summary>
        /// The VM size to create the build on.
        /// </summary>
        public AzureVmSize? VmSize;
        /// <summary>
        /// The crash dump configuration for the build.
        /// </summary>
        public WindowsCrashDumpConfiguration WindowsCrashDumpConfiguration;
    }

    [Serializable]
    public class CreateBuildWithManagedContainerResponse : PlayFabResultCommon
    {
        /// <summary>
        /// When true, assets will not be copied for each server inside the VM. All serverswill run from the same set of assets, or
        /// will have the same assets mounted in the container.
        /// </summary>
        public bool? AreAssetsReadonly;
        /// <summary>
        /// The guid string build ID. Must be unique for every build.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The build name.
        /// </summary>
        public string BuildName;
        /// <summary>
        /// The flavor of container of the build.
        /// </summary>
        public ContainerFlavor? ContainerFlavor;
        /// <summary>
        /// The time the build was created in UTC.
        /// </summary>
        public DateTime? CreationTime;
        /// <summary>
        /// The game assets for the build.
        /// </summary>
        public List<AssetReference> GameAssetReferences;
        /// <summary>
        /// The game certificates for the build.
        /// </summary>
        public List<GameCertificateReference> GameCertificateReferences;
        /// <summary>
        /// The directory containing the game executable. This would be the start path of the game assets that contain the main game
        /// server executable. If not provided, a best effort will be made to extract it from the start game command.
        /// </summary>
        public string GameWorkingDirectory;
        /// <summary>
        /// The instrumentation configuration for this build.
        /// </summary>
        public InstrumentationConfiguration InstrumentationConfiguration;
        /// <summary>
        /// The metadata of the build.
        /// </summary>
        public Dictionary<string,string> Metadata;
        /// <summary>
        /// The configuration for the monitoring application for the build
        /// </summary>
        public MonitoringApplicationConfiguration MonitoringApplicationConfiguration;
        /// <summary>
        /// The number of multiplayer servers to host on a single VM of the build.
        /// </summary>
        public int MultiplayerServerCountPerVm;
        /// <summary>
        /// The OS platform used for running the game process.
        /// </summary>
        public string OsPlatform;
        /// <summary>
        /// The ports the build is mapped on.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The region configuration for the build.
        /// </summary>
        public List<BuildRegion> RegionConfigurations;
        /// <summary>
        /// The type of game server being hosted.
        /// </summary>
        public string ServerType;
        /// <summary>
        /// The command to run when the multiplayer server has been allocated, including any arguments.
        /// </summary>
        public string StartMultiplayerServerCommand;
        /// <summary>
        /// When true, assets will be downloaded and uncompressed in memory, without the compressedversion being written first to
        /// disc.
        /// </summary>
        public bool? UseStreamingForAssetDownloads;
        /// <summary>
        /// The VM size the build was created on.
        /// </summary>
        public AzureVmSize? VmSize;
    }

    /// <summary>
    /// Creates a multiplayer server build with the game server running as a process and returns information about the build
    /// creation request.
    /// </summary>
    [Serializable]
    public class CreateBuildWithProcessBasedServerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// When true, assets will not be copied for each server inside the VM. All serverswill run from the same set of assets, or
        /// will have the same assets mounted in the container.
        /// </summary>
        public bool? AreAssetsReadonly;
        /// <summary>
        /// The build name.
        /// </summary>
        public string BuildName;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The list of game assets related to the build.
        /// </summary>
        public List<AssetReferenceParams> GameAssetReferences;
        /// <summary>
        /// The game certificates for the build.
        /// </summary>
        public List<GameCertificateReferenceParams> GameCertificateReferences;
        /// <summary>
        /// The working directory for the game process. If this is not provided, the working directory will be set based on the
        /// mount path of the game server executable.
        /// </summary>
        public string GameWorkingDirectory;
        /// <summary>
        /// The instrumentation configuration for the build.
        /// </summary>
        public InstrumentationConfiguration InstrumentationConfiguration;
        /// <summary>
        /// Indicates whether this build will be created using the OS Preview versionPreview OS is recommended for dev builds to
        /// detect any breaking changes before they are released to retail. Retail builds should set this value to false.
        /// </summary>
        public bool? IsOSPreview;
        /// <summary>
        /// Metadata to tag the build. The keys are case insensitive. The build metadata is made available to the server through
        /// Game Server SDK (GSDK).Constraints: Maximum number of keys: 30, Maximum key length: 50, Maximum value length: 100
        /// </summary>
        public Dictionary<string,string> Metadata;
        /// <summary>
        /// The configuration for the monitoring application on the build
        /// </summary>
        public MonitoringApplicationConfigurationParams MonitoringApplicationConfiguration;
        /// <summary>
        /// The number of multiplayer servers to host on a single VM.
        /// </summary>
        public int MultiplayerServerCountPerVm;
        /// <summary>
        /// The OS platform used for running the game process.
        /// </summary>
        public string OsPlatform;
        /// <summary>
        /// The ports to map the build on.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The region configurations for the build.
        /// </summary>
        public List<BuildRegionParams> RegionConfigurations;
        /// <summary>
        /// The command to run when the multiplayer server is started, including any arguments. The path to any executable should be
        /// relative to the root asset folder when unzipped.
        /// </summary>
        public string StartMultiplayerServerCommand;
        /// <summary>
        /// When true, assets will be downloaded and uncompressed in memory, without the compressedversion being written first to
        /// disc.
        /// </summary>
        public bool? UseStreamingForAssetDownloads;
        /// <summary>
        /// The VM size to create the build on.
        /// </summary>
        public AzureVmSize? VmSize;
    }

    [Serializable]
    public class CreateBuildWithProcessBasedServerResponse : PlayFabResultCommon
    {
        /// <summary>
        /// When true, assets will not be copied for each server inside the VM. All serverswill run from the same set of assets, or
        /// will have the same assets mounted in the container.
        /// </summary>
        public bool? AreAssetsReadonly;
        /// <summary>
        /// The guid string build ID. Must be unique for every build.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The build name.
        /// </summary>
        public string BuildName;
        /// <summary>
        /// The flavor of container of the build.
        /// </summary>
        public ContainerFlavor? ContainerFlavor;
        /// <summary>
        /// The time the build was created in UTC.
        /// </summary>
        public DateTime? CreationTime;
        /// <summary>
        /// The game assets for the build.
        /// </summary>
        public List<AssetReference> GameAssetReferences;
        /// <summary>
        /// The game certificates for the build.
        /// </summary>
        public List<GameCertificateReference> GameCertificateReferences;
        /// <summary>
        /// The working directory for the game process. If this is not provided, the working directory will be set based on the
        /// mount path of the game server executable.
        /// </summary>
        public string GameWorkingDirectory;
        /// <summary>
        /// The instrumentation configuration for this build.
        /// </summary>
        public InstrumentationConfiguration InstrumentationConfiguration;
        /// <summary>
        /// Indicates whether this build will be created using the OS Preview versionPreview OS is recommended for dev builds to
        /// detect any breaking changes before they are released to retail. Retail builds should set this value to false.
        /// </summary>
        public bool? IsOSPreview;
        /// <summary>
        /// The metadata of the build.
        /// </summary>
        public Dictionary<string,string> Metadata;
        /// <summary>
        /// The configuration for the monitoring application for the build
        /// </summary>
        public MonitoringApplicationConfiguration MonitoringApplicationConfiguration;
        /// <summary>
        /// The number of multiplayer servers to host on a single VM of the build.
        /// </summary>
        public int MultiplayerServerCountPerVm;
        /// <summary>
        /// The OS platform used for running the game process.
        /// </summary>
        public string OsPlatform;
        /// <summary>
        /// The ports the build is mapped on.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The region configuration for the build.
        /// </summary>
        public List<BuildRegion> RegionConfigurations;
        /// <summary>
        /// The type of game server being hosted.
        /// </summary>
        public string ServerType;
        /// <summary>
        /// The command to run when the multiplayer server is started, including any arguments. The path to any executable is
        /// relative to the root asset folder when unzipped.
        /// </summary>
        public string StartMultiplayerServerCommand;
        /// <summary>
        /// When true, assets will be downloaded and uncompressed in memory, without the compressedversion being written first to
        /// disc.
        /// </summary>
        public bool? UseStreamingForAssetDownloads;
        /// <summary>
        /// The VM size the build was created on.
        /// </summary>
        public AzureVmSize? VmSize;
    }

    /// <summary>
    /// Request to create a lobby. A Server or client can create a lobby.
    /// </summary>
    [Serializable]
    public class CreateLobbyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The policy indicating who is allowed to join the lobby, and the visibility to queries. May be 'Public', 'Friends' or
        /// 'Private'. Public means the lobby is both visible in queries and any player may join, including invited players. Friends
        /// means that users who are bidirectional friends of members in the lobby may search to find friend lobbies, to retrieve
        /// its connection string. Private means the lobby is not visible in queries, and a player must receive an invitation to
        /// join. Defaults to 'Public' on creation. Can only be changed by the lobby owner.
        /// </summary>
        public AccessPolicy? AccessPolicy;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The private key-value pairs which are only visible to members of the lobby. At most 30 key-value pairs may be stored
        /// here, keys are limited to 30 characters and values to 1000. The total size of all lobbyData values may not exceed 4096
        /// bytes. Keys are case sensitive.
        /// </summary>
        public Dictionary<string,string> LobbyData;
        /// <summary>
        /// The maximum number of players allowed in the lobby. The value must be between 2 and 128.
        /// </summary>
        public uint MaxPlayers;
        /// <summary>
        /// The member initially added to the lobby. Client must specify exactly one member, which is the creator's entity and
        /// member data. Member PubSubConnectionHandle must be null or empty. Game servers must not specify any members.
        /// </summary>
        public List<Member> Members;
        /// <summary>
        /// The lobby owner. Must be the calling entity.
        /// </summary>
        public EntityKey Owner;
        /// <summary>
        /// The policy for how a new owner is chosen. May be 'Automatic', 'Manual' or 'None'. Can only be specified by clients. If
        /// client-owned and 'Automatic' - The Lobby service will automatically assign another connected owner when the current
        /// owner leaves or disconnects. The useConnections property must be true. If client - owned and 'Manual' - Ownership is
        /// protected as long as the current owner is connected. If the current owner leaves or disconnects any member may set
        /// themselves as the current owner. The useConnections property must be true. If client-owned and 'None' - Any member can
        /// set ownership. The useConnections property can be either true or false.
        /// </summary>
        public OwnerMigrationPolicy? OwnerMigrationPolicy;
        /// <summary>
        /// The public key-value pairs which allow queries to differentiate between lobbies. Queries will refer to these key-value
        /// pairs in their filter and order by clauses to retrieve lobbies fitting the specified criteria. At most 30 key-value
        /// pairs may be stored here. Keys are of the format string_key1, string_key2 ... string_key30 for string values, or
        /// number_key1, number_key2, ... number_key30 for numeric values.Numeric values are floats. Values can be at most 256
        /// characters long. The total size of all searchData values may not exceed 1024 bytes.
        /// </summary>
        public Dictionary<string,string> SearchData;
        /// <summary>
        /// A setting to control whether connections are used. Defaults to true. When true, notifications are sent to subscribed
        /// players, disconnect detection removes connectionHandles, only owner migration policies using connections are allowed,
        /// and lobbies must have at least one connected member to be searchable or be a server hosted lobby with a connected
        /// server. If false, then notifications are not sent, connections are not allowed, and lobbies do not need connections to
        /// be searchable.
        /// </summary>
        public bool UseConnections;
    }

    [Serializable]
    public class CreateLobbyResult : PlayFabResultCommon
    {
        /// <summary>
        /// A field which indicates which lobby the user will be joining.
        /// </summary>
        public string ConnectionString;
        /// <summary>
        /// Id to uniquely identify a lobby.
        /// </summary>
        public string LobbyId;
    }

    /// <summary>
    /// The client specifies the creator's attributes and optionally a list of other users to match with.
    /// </summary>
    [Serializable]
    public class CreateMatchmakingTicketRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The User who created this ticket.
        /// </summary>
        public MatchmakingPlayer Creator;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// How long to attempt matching this ticket in seconds.
        /// </summary>
        public int GiveUpAfterSeconds;
        /// <summary>
        /// A list of Entity Keys of other users to match with.
        /// </summary>
        public List<EntityKey> MembersToMatchWith;
        /// <summary>
        /// The Id of a match queue.
        /// </summary>
        public string QueueName;
    }

    [Serializable]
    public class CreateMatchmakingTicketResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Id of the ticket to find a match for.
        /// </summary>
        public string TicketId;
    }

    /// <summary>
    /// Creates a remote user to log on to a VM for a multiplayer server build in a specific region. Returns user credential
    /// information necessary to log on.
    /// </summary>
    [Serializable]
    public class CreateRemoteUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string build ID of to create the remote user for.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The expiration time for the remote user created. Defaults to expiring in one day if not specified.
        /// </summary>
        public DateTime? ExpirationTime;
        /// <summary>
        /// The region of virtual machine to create the remote user for.
        /// </summary>
        public string Region;
        /// <summary>
        /// The username to create the remote user with.
        /// </summary>
        public string Username;
        /// <summary>
        /// The virtual machine ID the multiplayer server is located on.
        /// </summary>
        public string VmId;
    }

    [Serializable]
    public class CreateRemoteUserResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The expiration time for the remote user created.
        /// </summary>
        public DateTime? ExpirationTime;
        /// <summary>
        /// The generated password for the remote user that was created.
        /// </summary>
        public string Password;
        /// <summary>
        /// The username for the remote user that was created.
        /// </summary>
        public string Username;
    }

    /// <summary>
    /// The server specifies all the members, their teams and their attributes, and the server details if applicable.
    /// </summary>
    [Serializable]
    public class CreateServerBackfillTicketRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// How long to attempt matching this ticket in seconds.
        /// </summary>
        public int GiveUpAfterSeconds;
        /// <summary>
        /// The users who will be part of this ticket, along with their team assignments.
        /// </summary>
        public List<MatchmakingPlayerWithTeamAssignment> Members;
        /// <summary>
        /// The Id of a match queue.
        /// </summary>
        public string QueueName;
        /// <summary>
        /// The details of the server the members are connected to.
        /// </summary>
        public ServerDetails ServerDetails;
    }

    [Serializable]
    public class CreateServerBackfillTicketResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Id of the ticket to find a match for.
        /// </summary>
        public string TicketId;
    }

    /// <summary>
    /// The server specifies all the members and their attributes.
    /// </summary>
    [Serializable]
    public class CreateServerMatchmakingTicketRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// How long to attempt matching this ticket in seconds.
        /// </summary>
        public int GiveUpAfterSeconds;
        /// <summary>
        /// The users who will be part of this ticket.
        /// </summary>
        public List<MatchmakingPlayer> Members;
        /// <summary>
        /// The Id of a match queue.
        /// </summary>
        public string QueueName;
    }

    /// <summary>
    /// Creates a request to change a title's multiplayer server quotas.
    /// </summary>
    [Serializable]
    public class CreateTitleMultiplayerServersQuotaChangeRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// A brief description of the requested changes.
        /// </summary>
        public string ChangeDescription;
        /// <summary>
        /// Changes to make to the titles cores quota.
        /// </summary>
        public List<CoreCapacityChange> Changes;
        /// <summary>
        /// Email to be contacted by our team about this request. Only required when a request is not approved.
        /// </summary>
        public string ContactEmail;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Additional information about this request that our team can use to better understand the requirements.
        /// </summary>
        public string Notes;
        /// <summary>
        /// When these changes would need to be in effect. Only required when a request is not approved.
        /// </summary>
        public DateTime? StartDate;
    }

    [Serializable]
    public class CreateTitleMultiplayerServersQuotaChangeResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Id of the change request that was created.
        /// </summary>
        public string RequestId;
        /// <summary>
        /// Determines if the request was approved or not. When false, our team is reviewing and may respond within 2 business days.
        /// </summary>
        public bool WasApproved;
    }

    [Serializable]
    public class CurrentServerStats : PlayFabBaseModel
    {
        /// <summary>
        /// The number of active multiplayer servers.
        /// </summary>
        public int Active;
        /// <summary>
        /// The number of multiplayer servers still downloading game resources (such as assets).
        /// </summary>
        public int Propping;
        /// <summary>
        /// The number of standingby multiplayer servers.
        /// </summary>
        public int StandingBy;
        /// <summary>
        /// The total number of multiplayer servers.
        /// </summary>
        public int Total;
    }

    [Serializable]
    public class CustomDifferenceRuleExpansion : PlayFabBaseModel
    {
        /// <summary>
        /// Manually specify the values to use for each expansion interval (this overrides Difference, Delta, and MaxDifference).
        /// </summary>
        public List<OverrideDouble> DifferenceOverrides;
        /// <summary>
        /// How many seconds before this rule is expanded.
        /// </summary>
        public uint SecondsBetweenExpansions;
    }

    [Serializable]
    public class CustomRegionSelectionRuleExpansion : PlayFabBaseModel
    {
        /// <summary>
        /// Manually specify the maximum latency to use for each expansion interval.
        /// </summary>
        public List<OverrideUnsignedInt> MaxLatencyOverrides;
        /// <summary>
        /// How many seconds before this rule is expanded.
        /// </summary>
        public uint SecondsBetweenExpansions;
    }

    [Serializable]
    public class CustomSetIntersectionRuleExpansion : PlayFabBaseModel
    {
        /// <summary>
        /// Manually specify the values to use for each expansion interval.
        /// </summary>
        public List<OverrideUnsignedInt> MinIntersectionSizeOverrides;
        /// <summary>
        /// How many seconds before this rule is expanded.
        /// </summary>
        public uint SecondsBetweenExpansions;
    }

    [Serializable]
    public class CustomTeamDifferenceRuleExpansion : PlayFabBaseModel
    {
        /// <summary>
        /// Manually specify the team difference value to use for each expansion interval.
        /// </summary>
        public List<OverrideDouble> DifferenceOverrides;
        /// <summary>
        /// How many seconds before this rule is expanded.
        /// </summary>
        public uint SecondsBetweenExpansions;
    }

    [Serializable]
    public class CustomTeamSizeBalanceRuleExpansion : PlayFabBaseModel
    {
        /// <summary>
        /// Manually specify the team size difference to use for each expansion interval.
        /// </summary>
        public List<OverrideUnsignedInt> DifferenceOverrides;
        /// <summary>
        /// How many seconds before this rule is expanded.
        /// </summary>
        public uint SecondsBetweenExpansions;
    }

    /// <summary>
    /// Deletes a multiplayer server game asset for a title.
    /// </summary>
    [Serializable]
    public class DeleteAssetRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The filename of the asset to delete.
        /// </summary>
        public string FileName;
    }

    /// <summary>
    /// Deletes a multiplayer server build alias.
    /// </summary>
    [Serializable]
    public class DeleteBuildAliasRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string alias ID of the alias to perform the action on.
        /// </summary>
        public string AliasId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    /// <summary>
    /// Removes a multiplayer server build's region.
    /// </summary>
    [Serializable]
    public class DeleteBuildRegionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string ID of the build we want to update regions for.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The build region to delete.
        /// </summary>
        public string Region;
    }

    /// <summary>
    /// Deletes a multiplayer server build.
    /// </summary>
    [Serializable]
    public class DeleteBuildRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string build ID of the build to delete.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    /// <summary>
    /// Deletes a multiplayer server game certificate.
    /// </summary>
    [Serializable]
    public class DeleteCertificateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the certificate.
        /// </summary>
        public string Name;
    }

    /// <summary>
    /// Removes the specified container image repository. After this operation, a 'docker pull' will fail for all the tags of
    /// the specified image. Morever, ListContainerImages will not return the specified image.
    /// </summary>
    [Serializable]
    public class DeleteContainerImageRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The container image repository we want to delete.
        /// </summary>
        public string ImageName;
    }

    /// <summary>
    /// Request to delete a lobby. Only servers can delete lobbies.
    /// </summary>
    [Serializable]
    public class DeleteLobbyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The id of the lobby.
        /// </summary>
        public string LobbyId;
    }

    /// <summary>
    /// Deletes a remote user to log on to a VM for a multiplayer server build in a specific region. Returns user credential
    /// information necessary to log on.
    /// </summary>
    [Serializable]
    public class DeleteRemoteUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string build ID of the multiplayer server where the remote user is to delete.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The region of the multiplayer server where the remote user is to delete.
        /// </summary>
        public string Region;
        /// <summary>
        /// The username of the remote user to delete.
        /// </summary>
        public string Username;
        /// <summary>
        /// The virtual machine ID the multiplayer server is located on.
        /// </summary>
        public string VmId;
    }

    [Serializable]
    public class DifferenceRule : PlayFabBaseModel
    {
        /// <summary>
        /// Description of the attribute used by this rule to match tickets.
        /// </summary>
        public QueueRuleAttribute Attribute;
        /// <summary>
        /// Describes the behavior when an attribute is not specified in the ticket creation request or in the user's entity
        /// profile.
        /// </summary>
        public AttributeNotSpecifiedBehavior AttributeNotSpecifiedBehavior;
        /// <summary>
        /// Collection of fields relating to expanding this rule at set intervals. Only one expansion can be set per rule. When this
        /// is set, Difference is ignored.
        /// </summary>
        public CustomDifferenceRuleExpansion CustomExpansion;
        /// <summary>
        /// The default value assigned to tickets that are missing the attribute specified by AttributePath (assuming that
        /// AttributeNotSpecifiedBehavior is false). Optional.
        /// </summary>
        public double? DefaultAttributeValue;
        /// <summary>
        /// The allowed difference between any two tickets at the start of matchmaking.
        /// </summary>
        public double Difference;
        /// <summary>
        /// Collection of fields relating to expanding this rule at set intervals. Only one expansion can be set per rule.
        /// </summary>
        public LinearDifferenceRuleExpansion LinearExpansion;
        /// <summary>
        /// How values are treated when there are multiple players in a single ticket.
        /// </summary>
        public AttributeMergeFunction MergeFunction;
        /// <summary>
        /// Friendly name chosen by developer.
        /// </summary>
        public string Name;
        /// <summary>
        /// How many seconds before this rule is no longer enforced (but tickets that comply with this rule will still be
        /// prioritized over those that don't). Leave blank if this rule is always enforced.
        /// </summary>
        public uint? SecondsUntilOptional;
        /// <summary>
        /// The relative weight of this rule compared to others.
        /// </summary>
        public double Weight;
    }

    [Serializable]
    public class DynamicStandbySettings : PlayFabBaseModel
    {
        /// <summary>
        /// List of auto standing by trigger values and corresponding standing by multiplier. Defaults to 1.5X at 50%, 3X at 25%,
        /// and 4X at 5%
        /// </summary>
        public List<DynamicStandbyThreshold> DynamicFloorMultiplierThresholds;
        /// <summary>
        /// When true, dynamic standby will be enabled
        /// </summary>
        public bool IsEnabled;
        /// <summary>
        /// The time it takes to reduce target standing by to configured floor value after an increase. Defaults to 30 minutes
        /// </summary>
        public int? RampDownSeconds;
    }

    [Serializable]
    public class DynamicStandbyThreshold : PlayFabBaseModel
    {
        /// <summary>
        /// When the trigger threshold is reached, multiply by this value
        /// </summary>
        public double Multiplier;
        /// <summary>
        /// The multiplier will be applied when the actual standby divided by target standby floor is less than this value
        /// </summary>
        public double TriggerThresholdPercentage;
    }

    [Serializable]
    public class EmptyResponse : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Enables the multiplayer server feature for a title and returns the enabled status. The enabled status can be
    /// Initializing, Enabled, and Disabled. It can up to 20 minutes or more for the title to be enabled for the feature. On
    /// average, it can take up to 20 minutes for the title to be enabled for the feature.
    /// </summary>
    [Serializable]
    public class EnableMultiplayerServersForTitleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class EnableMultiplayerServersForTitleResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The enabled status for the multiplayer server features for the title.
        /// </summary>
        public TitleMultiplayerServerEnabledStatus? Status;
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
    /// Request to find friends lobbies. Only a client can find friend lobbies.
    /// </summary>
    [Serializable]
    public class FindFriendLobbiesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Controls whether this query should link to friends made on the Facebook network. Defaults to false
        /// </summary>
        public bool ExcludeFacebookFriends;
        /// <summary>
        /// Controls whether this query should link to friends made on the Steam network. Defaults to false
        /// </summary>
        public bool ExcludeSteamFriends;
        /// <summary>
        /// OData style string that contains one or more filters. Only the following operators are supported: "and" (logical and),
        /// "eq" (equal), "ne" (not equals), "ge" (greater than or equal), "gt" (greater than), "le" (less than or equal), and "lt"
        /// (less than). The left-hand side of each OData logical expression should be either a search property key (e.g.
        /// string_key1, number_key3, etc) or one of the pre-defined search keys: memberCount, membershipLock (must equal 'Unlocked'
        /// or 'Locked'), amOwner (required to equal "true"), amMember (required to equal "true").
        /// </summary>
        public string Filter;
        /// <summary>
        /// OData style string that contains sorting for this query in either ascending ("asc") or descending ("desc") order.
        /// OrderBy clauses are of the form "number_key1 asc" or the pre-defined search key "memberCount desc". To sort by closest,
        /// a moniker `distance{number_key1 = 5}` can be used to sort by distance from the given number. This field only supports
        /// either one sort clause or one distance clause.
        /// </summary>
        public string OrderBy;
        /// <summary>
        /// Request pagination information.
        /// </summary>
        public PaginationRequest Pagination;
        /// <summary>
        /// Xbox token if Xbox friends should be included. Requires Xbox be configured on PlayFab.
        /// </summary>
        public string XboxToken;
    }

    [Serializable]
    public class FindFriendLobbiesResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of lobbies found that matched FindFriendLobbies request.
        /// </summary>
        public List<FriendLobbySummary> Lobbies;
        /// <summary>
        /// Pagination response for FindFriendLobbies request.
        /// </summary>
        public PaginationResponse Pagination;
    }

    /// <summary>
    /// Request to find lobbies.
    /// </summary>
    [Serializable]
    public class FindLobbiesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// OData style string that contains one or more filters. Only the following operators are supported: "and" (logical and),
        /// "eq" (equal), "ne" (not equals), "ge" (greater than or equal), "gt" (greater than), "le" (less than or equal), and "lt"
        /// (less than). The left-hand side of each OData logical expression should be either a search property key (e.g.
        /// string_key1, number_key3, etc) or one of the pre-defined search keys: memberCount, membershipLock (must equal 'Unlocked'
        /// or 'Locked'), amOwner (required to equal "true"), amMember (required to equal "true").
        /// </summary>
        public string Filter;
        /// <summary>
        /// OData style string that contains sorting for this query in either ascending ("asc") or descending ("desc") order.
        /// OrderBy clauses are of the form "number_key1 asc" or the pre-defined search key "memberCount desc". To sort by closest,
        /// a moniker `distance{number_key1 = 5}` can be used to sort by distance from the given number. This field only supports
        /// either one sort clause or one distance clause.
        /// </summary>
        public string OrderBy;
        /// <summary>
        /// Request pagination information.
        /// </summary>
        public PaginationRequest Pagination;
    }

    [Serializable]
    public class FindLobbiesResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of lobbies found that matched FindLobbies request.
        /// </summary>
        public List<LobbySummary> Lobbies;
        /// <summary>
        /// Pagination response for FindLobbies request.
        /// </summary>
        public PaginationResponse Pagination;
    }

    [Serializable]
    public class FriendLobbySummary : PlayFabBaseModel
    {
        /// <summary>
        /// A string used to join the lobby.This field is populated by the Lobby service.Invites are performed by communicating this
        /// connectionString to other players.
        /// </summary>
        public string ConnectionString;
        /// <summary>
        /// The current number of players in the lobby.
        /// </summary>
        public uint CurrentPlayers;
        /// <summary>
        /// Friends in Lobby.
        /// </summary>
        public List<EntityKey> Friends;
        /// <summary>
        /// Id to uniquely identify a lobby.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// The maximum number of players allowed in the lobby.
        /// </summary>
        public uint MaxPlayers;
        /// <summary>
        /// A setting indicating whether members are allowed to join this lobby. When Locked new members are prevented from joining.
        /// </summary>
        public MembershipLock? MembershipLock;
        /// <summary>
        /// The client or server entity which owns this lobby.
        /// </summary>
        public EntityKey Owner;
        /// <summary>
        /// Search data.
        /// </summary>
        public Dictionary<string,string> SearchData;
    }

    [Serializable]
    public class GameCertificateReference : PlayFabBaseModel
    {
        /// <summary>
        /// An alias for the game certificate. The game server will reference this alias via GSDK config to retrieve the game
        /// certificate. This alias is used as an identifier in game server code to allow a new certificate with different Name
        /// field to be uploaded without the need to change any game server code to reference the new Name.
        /// </summary>
        public string GsdkAlias;
        /// <summary>
        /// The name of the game certificate. This name should match the name of a certificate that was previously uploaded to this
        /// title.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class GameCertificateReferenceParams : PlayFabBaseModel
    {
        /// <summary>
        /// An alias for the game certificate. The game server will reference this alias via GSDK config to retrieve the game
        /// certificate. This alias is used as an identifier in game server code to allow a new certificate with different Name
        /// field to be uploaded without the need to change any game server code to reference the new Name.
        /// </summary>
        public string GsdkAlias;
        /// <summary>
        /// The name of the game certificate. This name should match the name of a certificate that was previously uploaded to this
        /// title.
        /// </summary>
        public string Name;
    }

    /// <summary>
    /// Gets a URL that can be used to download the specified asset.
    /// </summary>
    [Serializable]
    public class GetAssetDownloadUrlRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The asset's file name to get the download URL for.
        /// </summary>
        public string FileName;
    }

    [Serializable]
    public class GetAssetDownloadUrlResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The asset's download URL.
        /// </summary>
        public string AssetDownloadUrl;
        /// <summary>
        /// The asset's file name to get the download URL for.
        /// </summary>
        public string FileName;
    }

    /// <summary>
    /// Gets the URL to upload assets to.
    /// </summary>
    [Serializable]
    public class GetAssetUploadUrlRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The asset's file name to get the upload URL for.
        /// </summary>
        public string FileName;
    }

    [Serializable]
    public class GetAssetUploadUrlResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The asset's upload URL.
        /// </summary>
        public string AssetUploadUrl;
        /// <summary>
        /// The asset's file name to get the upload URL for.
        /// </summary>
        public string FileName;
    }

    /// <summary>
    /// Returns the details about a multiplayer server build alias.
    /// </summary>
    [Serializable]
    public class GetBuildAliasRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string alias ID of the alias to perform the action on.
        /// </summary>
        public string AliasId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    /// <summary>
    /// Returns the details about a multiplayer server build.
    /// </summary>
    [Serializable]
    public class GetBuildRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string build ID of the build to get.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class GetBuildResponse : PlayFabResultCommon
    {
        /// <summary>
        /// When true, assets will not be copied for each server inside the VM. All serverswill run from the same set of assets, or
        /// will have the same assets mounted in the container.
        /// </summary>
        public bool? AreAssetsReadonly;
        /// <summary>
        /// The guid string build ID of the build.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The build name.
        /// </summary>
        public string BuildName;
        /// <summary>
        /// The current build status. Valid values are - Deploying, Deployed, DeletingRegion, Unhealthy.
        /// </summary>
        public string BuildStatus;
        /// <summary>
        /// The flavor of container of he build.
        /// </summary>
        public ContainerFlavor? ContainerFlavor;
        /// <summary>
        /// The container command to run when the multiplayer server has been allocated, including any arguments. This only applies
        /// to custom builds. If the build is a managed build, this field will be null.
        /// </summary>
        public string ContainerRunCommand;
        /// <summary>
        /// The time the build was created in UTC.
        /// </summary>
        public DateTime? CreationTime;
        /// <summary>
        /// The custom game container image for a custom build.
        /// </summary>
        public ContainerImageReference CustomGameContainerImage;
        /// <summary>
        /// The game assets for the build.
        /// </summary>
        public List<AssetReference> GameAssetReferences;
        /// <summary>
        /// The game certificates for the build.
        /// </summary>
        public List<GameCertificateReference> GameCertificateReferences;
        /// <summary>
        /// The instrumentation configuration of the build.
        /// </summary>
        public InstrumentationConfiguration InstrumentationConfiguration;
        /// <summary>
        /// Metadata of the build. The keys are case insensitive. The build metadata is made available to the server through Game
        /// Server SDK (GSDK).
        /// </summary>
        public Dictionary<string,string> Metadata;
        /// <summary>
        /// The number of multiplayer servers to hosted on a single VM of the build.
        /// </summary>
        public int MultiplayerServerCountPerVm;
        /// <summary>
        /// The OS platform used for running the game process.
        /// </summary>
        public string OsPlatform;
        /// <summary>
        /// The ports the build is mapped on.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The region configuration for the build.
        /// </summary>
        public List<BuildRegion> RegionConfigurations;
        /// <summary>
        /// The type of game server being hosted.
        /// </summary>
        public string ServerType;
        /// <summary>
        /// The command to run when the multiplayer server has been allocated, including any arguments. This only applies to managed
        /// builds. If the build is a custom build, this field will be null.
        /// </summary>
        public string StartMultiplayerServerCommand;
        /// <summary>
        /// The VM size the build was created on.
        /// </summary>
        public AzureVmSize? VmSize;
    }

    /// <summary>
    /// Gets credentials to the container registry where game developers can upload custom container images to before creating a
    /// new build.
    /// </summary>
    [Serializable]
    public class GetContainerRegistryCredentialsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class GetContainerRegistryCredentialsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The url of the container registry.
        /// </summary>
        public string DnsName;
        /// <summary>
        /// The password for accessing the container registry.
        /// </summary>
        public string Password;
        /// <summary>
        /// The username for accessing the container registry.
        /// </summary>
        public string Username;
    }

    /// <summary>
    /// Request to get a lobby.
    /// </summary>
    [Serializable]
    public class GetLobbyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The id of the lobby.
        /// </summary>
        public string LobbyId;
    }

    [Serializable]
    public class GetLobbyResult : PlayFabResultCommon
    {
        /// <summary>
        /// The information pertaining to the requested lobby.
        /// </summary>
        public Lobby Lobby;
    }

    /// <summary>
    /// Gets the current configuration for a queue.
    /// </summary>
    [Serializable]
    public class GetMatchmakingQueueRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The Id of the matchmaking queue to retrieve.
        /// </summary>
        public string QueueName;
    }

    [Serializable]
    public class GetMatchmakingQueueResult : PlayFabResultCommon
    {
        /// <summary>
        /// The matchmaking queue config.
        /// </summary>
        public MatchmakingQueueConfig MatchmakingQueue;
    }

    /// <summary>
    /// The ticket includes the invited players, their attributes if they have joined, the ticket status, the match Id when
    /// applicable, etc. Only servers, the ticket creator and the invited players can get the ticket.
    /// </summary>
    [Serializable]
    public class GetMatchmakingTicketRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Determines whether the matchmaking attributes will be returned as an escaped JSON string or as an un-escaped JSON
        /// object.
        /// </summary>
        public bool EscapeObject;
        /// <summary>
        /// The name of the queue to find a match for.
        /// </summary>
        public string QueueName;
        /// <summary>
        /// The Id of the ticket to find a match for.
        /// </summary>
        public string TicketId;
    }

    [Serializable]
    public class GetMatchmakingTicketResult : PlayFabResultCommon
    {
        /// <summary>
        /// The reason why the current ticket was canceled. This field is only set if the ticket is in canceled state.
        /// </summary>
        public string CancellationReasonString;
        /// <summary>
        /// Change number used for differentiating older matchmaking status updates from newer ones.
        /// </summary>
        public uint? ChangeNumber;
        /// <summary>
        /// The server date and time at which ticket was created.
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// The Creator's entity key.
        /// </summary>
        public EntityKey Creator;
        /// <summary>
        /// How long to attempt matching this ticket in seconds.
        /// </summary>
        public int GiveUpAfterSeconds;
        /// <summary>
        /// The Id of a match.
        /// </summary>
        public string MatchId;
        /// <summary>
        /// A list of Users that have joined this ticket.
        /// </summary>
        public List<MatchmakingPlayer> Members;
        /// <summary>
        /// A list of PlayFab Ids of Users to match with.
        /// </summary>
        public List<EntityKey> MembersToMatchWith;
        /// <summary>
        /// The Id of a match queue.
        /// </summary>
        public string QueueName;
        /// <summary>
        /// The current ticket status. Possible values are: WaitingForPlayers, WaitingForMatch, WaitingForServer, Canceled and
        /// Matched.
        /// </summary>
        public string Status;
        /// <summary>
        /// The Id of the ticket to find a match for.
        /// </summary>
        public string TicketId;
    }

    /// <summary>
    /// When matchmaking has successfully matched together a collection of tickets, it produces a 'match' with an Id. The match
    /// contains all of the players that were matched together, and their team assigments. Only servers and ticket members can
    /// get the match.
    /// </summary>
    [Serializable]
    public class GetMatchRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Determines whether the matchmaking attributes will be returned as an escaped JSON string or as an un-escaped JSON
        /// object.
        /// </summary>
        public bool EscapeObject;
        /// <summary>
        /// The Id of a match.
        /// </summary>
        public string MatchId;
        /// <summary>
        /// The name of the queue to join.
        /// </summary>
        public string QueueName;
        /// <summary>
        /// Determines whether the matchmaking attributes for each user should be returned in the response for match request.
        /// </summary>
        public bool ReturnMemberAttributes;
    }

    [Serializable]
    public class GetMatchResult : PlayFabResultCommon
    {
        /// <summary>
        /// A string that is used by players that are matched together to join an arranged lobby.
        /// </summary>
        public string ArrangementString;
        /// <summary>
        /// The Id of a match.
        /// </summary>
        public string MatchId;
        /// <summary>
        /// A list of Users that are matched together, along with their team assignments.
        /// </summary>
        public List<MatchmakingPlayerWithTeamAssignment> Members;
        /// <summary>
        /// A list of regions that the match could be played in sorted by preference. This value is only set if the queue has a
        /// region selection rule.
        /// </summary>
        public List<string> RegionPreferences;
        /// <summary>
        /// The details of the server that the match has been allocated to.
        /// </summary>
        public ServerDetails ServerDetails;
    }

    /// <summary>
    /// Gets multiplayer server session details for a build in a specific region.
    /// </summary>
    [Serializable]
    public class GetMultiplayerServerDetailsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string build ID of the multiplayer server to get details for.
        /// </summary>
        [Obsolete("No longer available", false)]
        public string BuildId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The region the multiplayer server is located in to get details for.
        /// </summary>
        [Obsolete("No longer available", false)]
        public string Region;
        /// <summary>
        /// The title generated guid string session ID of the multiplayer server to get details for. This is to keep track of
        /// multiplayer server sessions.
        /// </summary>
        public string SessionId;
    }

    [Serializable]
    public class GetMultiplayerServerDetailsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The identity of the build in which the server was allocated.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The connected players in the multiplayer server.
        /// </summary>
        public List<ConnectedPlayer> ConnectedPlayers;
        /// <summary>
        /// The fully qualified domain name of the virtual machine that is hosting this multiplayer server.
        /// </summary>
        public string FQDN;
        /// <summary>
        /// The IPv4 address of the virtual machine that is hosting this multiplayer server.
        /// </summary>
        public string IPV4Address;
        /// <summary>
        /// The time (UTC) at which a change in the multiplayer server state was observed.
        /// </summary>
        public DateTime? LastStateTransitionTime;
        /// <summary>
        /// The ports the multiplayer server uses.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The region the multiplayer server is located in.
        /// </summary>
        public string Region;
        /// <summary>
        /// The string server ID of the multiplayer server generated by PlayFab.
        /// </summary>
        public string ServerId;
        /// <summary>
        /// The guid string session ID of the multiplayer server.
        /// </summary>
        public string SessionId;
        /// <summary>
        /// The state of the multiplayer server.
        /// </summary>
        public string State;
        /// <summary>
        /// The virtual machine ID that the multiplayer server is located on.
        /// </summary>
        public string VmId;
    }

    /// <summary>
    /// Gets multiplayer server logs for a specific server id in a region. The logs are available only after a server has
    /// terminated.
    /// </summary>
    [Serializable]
    public class GetMultiplayerServerLogsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The server ID of multiplayer server to get logs for.
        /// </summary>
        public string ServerId;
    }

    [Serializable]
    public class GetMultiplayerServerLogsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// URL for logs download.
        /// </summary>
        public string LogDownloadUrl;
    }

    /// <summary>
    /// Gets multiplayer server logs for a specific server id in a region. The logs are available only after a server has
    /// terminated.
    /// </summary>
    [Serializable]
    public class GetMultiplayerSessionLogsBySessionIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The server ID of multiplayer server to get logs for.
        /// </summary>
        public string SessionId;
    }

    /// <summary>
    /// Returns the matchmaking statistics for a queue. These include the number of players matching and the statistics related
    /// to the time to match statistics in seconds (average and percentiles). Statistics are refreshed once every 5 minutes.
    /// Servers can access all statistics no matter what the ClientStatisticsVisibility is configured to. Clients can access
    /// statistics according to the ClientStatisticsVisibility. Client requests are forbidden if all visibility fields are
    /// false.
    /// </summary>
    [Serializable]
    public class GetQueueStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the queue.
        /// </summary>
        public string QueueName;
    }

    [Serializable]
    public class GetQueueStatisticsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The current number of players in the matchmaking queue, who are waiting to be matched.
        /// </summary>
        public uint? NumberOfPlayersMatching;
        /// <summary>
        /// Statistics representing the time (in seconds) it takes for tickets to find a match.
        /// </summary>
        public Statistics TimeToMatchStatisticsInSeconds;
    }

    /// <summary>
    /// Gets a remote login endpoint to a VM that is hosting a multiplayer server build in a specific region.
    /// </summary>
    [Serializable]
    public class GetRemoteLoginEndpointRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string build ID of the multiplayer server to get remote login information for.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The region of the multiplayer server to get remote login information for.
        /// </summary>
        public string Region;
        /// <summary>
        /// The virtual machine ID the multiplayer server is located on.
        /// </summary>
        public string VmId;
    }

    [Serializable]
    public class GetRemoteLoginEndpointResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The remote login IPV4 address of multiplayer server.
        /// </summary>
        public string IPV4Address;
        /// <summary>
        /// The remote login port of multiplayer server.
        /// </summary>
        public int Port;
    }

    /// <summary>
    /// The ticket includes the players, their attributes, their teams, the ticket status, the match Id and the server details
    /// when applicable, etc. Only servers can get the ticket.
    /// </summary>
    [Serializable]
    public class GetServerBackfillTicketRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Determines whether the matchmaking attributes will be returned as an escaped JSON string or as an un-escaped JSON
        /// object.
        /// </summary>
        public bool EscapeObject;
        /// <summary>
        /// The name of the queue to find a match for.
        /// </summary>
        public string QueueName;
        /// <summary>
        /// The Id of the ticket to find a match for.
        /// </summary>
        public string TicketId;
    }

    [Serializable]
    public class GetServerBackfillTicketResult : PlayFabResultCommon
    {
        /// <summary>
        /// The reason why the current ticket was canceled. This field is only set if the ticket is in canceled state.
        /// </summary>
        public string CancellationReasonString;
        /// <summary>
        /// The server date and time at which ticket was created.
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// How long to attempt matching this ticket in seconds.
        /// </summary>
        public int GiveUpAfterSeconds;
        /// <summary>
        /// The Id of a match.
        /// </summary>
        public string MatchId;
        /// <summary>
        /// A list of Users that are part of this ticket, along with their team assignments.
        /// </summary>
        public List<MatchmakingPlayerWithTeamAssignment> Members;
        /// <summary>
        /// The Id of a match queue.
        /// </summary>
        public string QueueName;
        /// <summary>
        /// The details of the server the members are connected to.
        /// </summary>
        public ServerDetails ServerDetails;
        /// <summary>
        /// The current ticket status. Possible values are: WaitingForMatch, Canceled and Matched.
        /// </summary>
        public string Status;
        /// <summary>
        /// The Id of the ticket to find a match for.
        /// </summary>
        public string TicketId;
    }

    /// <summary>
    /// Gets the status of whether a title is enabled for the multiplayer server feature. The enabled status can be
    /// Initializing, Enabled, and Disabled.
    /// </summary>
    [Serializable]
    public class GetTitleEnabledForMultiplayerServersStatusRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class GetTitleEnabledForMultiplayerServersStatusResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The enabled status for the multiplayer server features for the title.
        /// </summary>
        public TitleMultiplayerServerEnabledStatus? Status;
    }

    /// <summary>
    /// Gets a title's server quota change request.
    /// </summary>
    [Serializable]
    public class GetTitleMultiplayerServersQuotaChangeRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Id of the change request to get.
        /// </summary>
        public string RequestId;
    }

    [Serializable]
    public class GetTitleMultiplayerServersQuotaChangeResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The change request for this title.
        /// </summary>
        public QuotaChange Change;
    }

    /// <summary>
    /// Gets the quotas for a title in relation to multiplayer servers.
    /// </summary>
    [Serializable]
    public class GetTitleMultiplayerServersQuotasRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class GetTitleMultiplayerServersQuotasResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The various quotas for multiplayer servers for the title.
        /// </summary>
        public TitleMultiplayerServersQuotas Quotas;
    }

    [Serializable]
    public class InstrumentationConfiguration : PlayFabBaseModel
    {
        /// <summary>
        /// Designates whether windows instrumentation configuration will be enabled for this Build
        /// </summary>
        public bool? IsEnabled;
        /// <summary>
        /// This property is deprecated, use IsEnabled. The list of processes to be monitored on a VM for this build. Providing
        /// processes will turn on performance metrics collection for this build. Process names should not include extensions. If
        /// the game server process is: GameServer.exe; then, ProcessesToMonitor = [ GameServer ]
        /// </summary>
        public List<string> ProcessesToMonitor;
    }

    /// <summary>
    /// Request to invite a player to a lobby the caller is already a member of. Only a client can invite another player to a
    /// lobby.
    /// </summary>
    [Serializable]
    public class InviteToLobbyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity invited to the lobby.
        /// </summary>
        public EntityKey InviteeEntity;
        /// <summary>
        /// The id of the lobby.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// The member entity sending the invite. Must be a member of the lobby.
        /// </summary>
        public EntityKey MemberEntity;
    }

    /// <summary>
    /// Request to join an arranged lobby. Only a client can join an arranged lobby.
    /// </summary>
    [Serializable]
    public class JoinArrangedLobbyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The policy indicating who is allowed to join the lobby, and the visibility to queries. May be 'Public', 'Friends' or
        /// 'Private'. Public means the lobby is both visible in queries and any player may join, including invited players. Friends
        /// means that users who are bidirectional friends of members in the lobby may search to find friend lobbies, to retrieve
        /// its connection string. Private means the lobby is not visible in queries, and a player must receive an invitation to
        /// join. Defaults to 'Public' on creation. Can only be changed by the lobby owner.
        /// </summary>
        public AccessPolicy? AccessPolicy;
        /// <summary>
        /// A field which indicates which lobby the user will be joining. This field is opaque to everyone except the Lobby service
        /// and the creator of the arrangementString (Matchmaking). This string defines a unique identifier for the arranged lobby
        /// as well as the title and member the string is valid for. Arrangement strings have an expiration.
        /// </summary>
        public string ArrangementString;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The maximum number of players allowed in the lobby. The value must be between 2 and 128.
        /// </summary>
        public uint MaxPlayers;
        /// <summary>
        /// The private key-value pairs used by the member to communicate information to other members and the owner. Visible to all
        /// members of the lobby. At most 30 key-value pairs may be stored here, keys are limited to 30 characters and values to
        /// 1000. The total size of all memberData values may not exceed 4096 bytes. Keys are case sensitive.
        /// </summary>
        public Dictionary<string,string> MemberData;
        /// <summary>
        /// The member entity who is joining the lobby. The first member to join will be the lobby owner.
        /// </summary>
        public EntityKey MemberEntity;
        /// <summary>
        /// The policy for how a new owner is chosen. May be 'Automatic', 'Manual' or 'None'. Can only be specified by clients. If
        /// client-owned and 'Automatic' - The Lobby service will automatically assign another connected owner when the current
        /// owner leaves or disconnects. The useConnections property must be true. If client - owned and 'Manual' - Ownership is
        /// protected as long as the current owner is connected. If the current owner leaves or disconnects any member may set
        /// themselves as the current owner. The useConnections property must be true. If client-owned and 'None' - Any member can
        /// set ownership. The useConnections property can be either true or false.
        /// </summary>
        public OwnerMigrationPolicy? OwnerMigrationPolicy;
        /// <summary>
        /// A setting to control whether connections are used. Defaults to true. When true, notifications are sent to subscribed
        /// players, disconnect detection removes connectionHandles, only owner migration policies using connections are allowed,
        /// and lobbies must have at least one connected member to be searchable or be a server hosted lobby with a connected
        /// server. If false, then notifications are not sent, connections are not allowed, and lobbies do not need connections to
        /// be searchable.
        /// </summary>
        public bool UseConnections;
    }

    /// <summary>
    /// Request to join a lobby. Only a client can join a lobby.
    /// </summary>
    [Serializable]
    public class JoinLobbyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// A field which indicates which lobby the user will be joining. This field is opaque to everyone except the Lobby service.
        /// </summary>
        public string ConnectionString;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The private key-value pairs used by the member to communicate information to other members and the owner. Visible to all
        /// members of the lobby. At most 30 key-value pairs may be stored here, keys are limited to 30 characters and values to
        /// 1000. The total size of all memberData values may not exceed 4096 bytes.Keys are case sensitive.
        /// </summary>
        public Dictionary<string,string> MemberData;
        /// <summary>
        /// The member entity who is joining the lobby.
        /// </summary>
        public EntityKey MemberEntity;
    }

    [Serializable]
    public class JoinLobbyResult : PlayFabResultCommon
    {
        /// <summary>
        /// Successfully joined lobby's id.
        /// </summary>
        public string LobbyId;
    }

    /// <summary>
    /// Add the player to a matchmaking ticket and specify all of its matchmaking attributes. Players can join a ticket if and
    /// only if their EntityKeys are already listed in the ticket's Members list. The matchmaking service automatically starts
    /// matching the ticket against other matchmaking tickets once all players have joined the ticket. It is not possible to
    /// join a ticket once it has started matching.
    /// </summary>
    [Serializable]
    public class JoinMatchmakingTicketRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The User who wants to join the ticket. Their Id must be listed in PlayFabIdsToMatchWith.
        /// </summary>
        public MatchmakingPlayer Member;
        /// <summary>
        /// The name of the queue to join.
        /// </summary>
        public string QueueName;
        /// <summary>
        /// The Id of the ticket to find a match for.
        /// </summary>
        public string TicketId;
    }

    [Serializable]
    public class JoinMatchmakingTicketResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Request to leave a lobby. Only a client can leave a lobby.
    /// </summary>
    [Serializable]
    public class LeaveLobbyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The id of the lobby.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// The member entity leaving the lobby.
        /// </summary>
        public EntityKey MemberEntity;
    }

    [Serializable]
    public class LinearDifferenceRuleExpansion : PlayFabBaseModel
    {
        /// <summary>
        /// This value gets added to Difference at every expansion interval.
        /// </summary>
        public double Delta;
        /// <summary>
        /// Once the total difference reaches this value, expansion stops. Optional.
        /// </summary>
        public double? Limit;
        /// <summary>
        /// How many seconds before this rule is expanded.
        /// </summary>
        public uint SecondsBetweenExpansions;
    }

    [Serializable]
    public class LinearRegionSelectionRuleExpansion : PlayFabBaseModel
    {
        /// <summary>
        /// This value gets added to MaxLatency at every expansion interval.
        /// </summary>
        public uint Delta;
        /// <summary>
        /// Once the max Latency reaches this value, expansion stops.
        /// </summary>
        public uint Limit;
        /// <summary>
        /// How many seconds before this rule is expanded.
        /// </summary>
        public uint SecondsBetweenExpansions;
    }

    [Serializable]
    public class LinearSetIntersectionRuleExpansion : PlayFabBaseModel
    {
        /// <summary>
        /// This value gets added to MinIntersectionSize at every expansion interval.
        /// </summary>
        public uint Delta;
        /// <summary>
        /// How many seconds before this rule is expanded.
        /// </summary>
        public uint SecondsBetweenExpansions;
    }

    [Serializable]
    public class LinearTeamDifferenceRuleExpansion : PlayFabBaseModel
    {
        /// <summary>
        /// This value gets added to Difference at every expansion interval.
        /// </summary>
        public double Delta;
        /// <summary>
        /// Once the total difference reaches this value, expansion stops. Optional.
        /// </summary>
        public double? Limit;
        /// <summary>
        /// How many seconds before this rule is expanded.
        /// </summary>
        public uint SecondsBetweenExpansions;
    }

    [Serializable]
    public class LinearTeamSizeBalanceRuleExpansion : PlayFabBaseModel
    {
        /// <summary>
        /// This value gets added to Difference at every expansion interval.
        /// </summary>
        public uint Delta;
        /// <summary>
        /// Once the total difference reaches this value, expansion stops. Optional.
        /// </summary>
        public uint? Limit;
        /// <summary>
        /// How many seconds before this rule is expanded.
        /// </summary>
        public uint SecondsBetweenExpansions;
    }

    [Serializable]
    public class LinuxInstrumentationConfiguration : PlayFabBaseModel
    {
        /// <summary>
        /// Designates whether Linux instrumentation configuration will be enabled for this Build
        /// </summary>
        public bool IsEnabled;
    }

    /// <summary>
    /// Returns a list of multiplayer server game asset summaries for a title.
    /// </summary>
    [Serializable]
    public class ListAssetSummariesRequest : PlayFabRequestCommon
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
    public class ListAssetSummariesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of asset summaries.
        /// </summary>
        public List<AssetSummary> AssetSummaries;
        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;
        /// <summary>
        /// The skip token for the paged response.
        /// </summary>
        public string SkipToken;
    }

    /// <summary>
    /// Returns a list of summarized details of all multiplayer server builds for a title.
    /// </summary>
    [Serializable]
    public class ListBuildAliasesRequest : PlayFabRequestCommon
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
    public class ListBuildAliasesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of build aliases for the title
        /// </summary>
        public List<BuildAliasDetailsResponse> BuildAliases;
        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;
        /// <summary>
        /// The skip token for the paged response.
        /// </summary>
        public string SkipToken;
    }

    /// <summary>
    /// Returns a list of summarized details of all multiplayer server builds for a title.
    /// </summary>
    [Serializable]
    public class ListBuildSummariesRequest : PlayFabRequestCommon
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
    public class ListBuildSummariesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of build summaries for a title.
        /// </summary>
        public List<BuildSummary> BuildSummaries;
        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;
        /// <summary>
        /// The skip token for the paged response.
        /// </summary>
        public string SkipToken;
    }

    /// <summary>
    /// Returns a list of multiplayer server game certificates for a title.
    /// </summary>
    [Serializable]
    public class ListCertificateSummariesRequest : PlayFabRequestCommon
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
    public class ListCertificateSummariesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of game certificates.
        /// </summary>
        public List<CertificateSummary> CertificateSummaries;
        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;
        /// <summary>
        /// The skip token for the paged response.
        /// </summary>
        public string SkipToken;
    }

    /// <summary>
    /// Returns a list of the container images that have been uploaded to the container registry for a title.
    /// </summary>
    [Serializable]
    public class ListContainerImagesRequest : PlayFabRequestCommon
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
    public class ListContainerImagesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of container images.
        /// </summary>
        public List<string> Images;
        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;
        /// <summary>
        /// The skip token for the paged response.
        /// </summary>
        public string SkipToken;
    }

    /// <summary>
    /// Returns a list of the tags for a particular container image that exists in the container registry for a title.
    /// </summary>
    [Serializable]
    public class ListContainerImageTagsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The container images we want to list tags for.
        /// </summary>
        public string ImageName;
    }

    [Serializable]
    public class ListContainerImageTagsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of tags for a particular container image.
        /// </summary>
        public List<string> Tags;
    }

    /// <summary>
    /// Gets a list of all the matchmaking queue configurations for the title.
    /// </summary>
    [Serializable]
    public class ListMatchmakingQueuesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class ListMatchmakingQueuesResult : PlayFabResultCommon
    {
        /// <summary>
        /// The list of matchmaking queue configs for this title.
        /// </summary>
        public List<MatchmakingQueueConfig> MatchMakingQueues;
    }

    /// <summary>
    /// If the caller is a title, the EntityKey in the request is required. If the caller is a player, then it is optional. If
    /// it is provided it must match the caller's entity.
    /// </summary>
    [Serializable]
    public class ListMatchmakingTicketsForPlayerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity key for which to find the ticket Ids.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The name of the queue to find a match for.
        /// </summary>
        public string QueueName;
    }

    [Serializable]
    public class ListMatchmakingTicketsForPlayerResult : PlayFabResultCommon
    {
        /// <summary>
        /// The list of ticket Ids the user is a member of.
        /// </summary>
        public List<string> TicketIds;
    }

    /// <summary>
    /// Returns a list of multiplayer servers for a build in a specific region.
    /// </summary>
    [Serializable]
    public class ListMultiplayerServersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string build ID of the multiplayer servers to list.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The page size for the request.
        /// </summary>
        public int? PageSize;
        /// <summary>
        /// The region the multiplayer servers to list.
        /// </summary>
        public string Region;
        /// <summary>
        /// The skip token for the paged request.
        /// </summary>
        public string SkipToken;
    }

    [Serializable]
    public class ListMultiplayerServersResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of multiplayer server summary details.
        /// </summary>
        public List<MultiplayerServerSummary> MultiplayerServerSummaries;
        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;
        /// <summary>
        /// The skip token for the paged response.
        /// </summary>
        public string SkipToken;
    }

    /// <summary>
    /// Returns a list of quality of service servers for party.
    /// </summary>
    [Serializable]
    public class ListPartyQosServersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class ListPartyQosServersResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;
        /// <summary>
        /// The list of QoS servers.
        /// </summary>
        public List<QosServer> QosServers;
        /// <summary>
        /// The skip token for the paged response.
        /// </summary>
        public string SkipToken;
    }

    /// <summary>
    /// Returns a list of quality of service servers for a title.
    /// </summary>
    [Serializable]
    public class ListQosServersForTitleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Indicates that the response should contain Qos servers for all regions, including those where there are no builds
        /// deployed for the title.
        /// </summary>
        public bool? IncludeAllRegions;
    }

    [Serializable]
    public class ListQosServersForTitleResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;
        /// <summary>
        /// The list of QoS servers.
        /// </summary>
        public List<QosServer> QosServers;
        /// <summary>
        /// The skip token for the paged response.
        /// </summary>
        public string SkipToken;
    }

    /// <summary>
    /// List all server backfill ticket Ids the user is a member of.
    /// </summary>
    [Serializable]
    public class ListServerBackfillTicketsForPlayerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity key for which to find the ticket Ids.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The name of the queue the tickets are in.
        /// </summary>
        public string QueueName;
    }

    [Serializable]
    public class ListServerBackfillTicketsForPlayerResult : PlayFabResultCommon
    {
        /// <summary>
        /// The list of backfill ticket Ids the user is a member of.
        /// </summary>
        public List<string> TicketIds;
    }

    /// <summary>
    /// List all server quota change requests for a title.
    /// </summary>
    [Serializable]
    public class ListTitleMultiplayerServersQuotaChangesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class ListTitleMultiplayerServersQuotaChangesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// All change requests for this title.
        /// </summary>
        public List<QuotaChange> Changes;
    }

    /// <summary>
    /// Returns a list of virtual machines for a title.
    /// </summary>
    [Serializable]
    public class ListVirtualMachineSummariesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string build ID of the virtual machines to list.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The page size for the request.
        /// </summary>
        public int? PageSize;
        /// <summary>
        /// The region of the virtual machines to list.
        /// </summary>
        public string Region;
        /// <summary>
        /// The skip token for the paged request.
        /// </summary>
        public string SkipToken;
    }

    [Serializable]
    public class ListVirtualMachineSummariesResponse : PlayFabResultCommon
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
        /// The list of virtual machine summaries.
        /// </summary>
        public List<VirtualMachineSummary> VirtualMachines;
    }

    [Serializable]
    public class Lobby : PlayFabBaseModel
    {
        /// <summary>
        /// A setting indicating who is allowed to join this lobby, as well as see it in queries.
        /// </summary>
        public AccessPolicy AccessPolicy;
        /// <summary>
        /// A number that increments once for each request that modifies the lobby.
        /// </summary>
        public uint ChangeNumber;
        /// <summary>
        /// A string used to join the lobby. This field is populated by the Lobby service. Invites are performed by communicating
        /// this connectionString to other players.
        /// </summary>
        public string ConnectionString;
        /// <summary>
        /// Lobby data.
        /// </summary>
        public Dictionary<string,string> LobbyData;
        /// <summary>
        /// Id to uniquely identify a lobby.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// The maximum number of players allowed in the lobby.
        /// </summary>
        public uint MaxPlayers;
        /// <summary>
        /// Array of all lobby members.
        /// </summary>
        public List<Member> Members;
        /// <summary>
        /// A setting indicating whether members are allowed to join this lobby. When Locked new members are prevented from joining.
        /// </summary>
        public MembershipLock MembershipLock;
        /// <summary>
        /// The client or server entity which owns this lobby.
        /// </summary>
        public EntityKey Owner;
        /// <summary>
        /// A setting indicating the owner migration policy. If server owned, this field is not present.
        /// </summary>
        public OwnerMigrationPolicy? OwnerMigrationPolicy;
        /// <summary>
        /// An opaque string stored on a SubscribeToLobbyResource call, which indicates the connection an owner or member has with
        /// PubSub.
        /// </summary>
        public string PubSubConnectionHandle;
        /// <summary>
        /// Search data.
        /// </summary>
        public Dictionary<string,string> SearchData;
        /// <summary>
        /// A flag which determines if connections are used. Defaults to true. Only set on create.
        /// </summary>
        public bool UseConnections;
    }

    [Serializable]
    public class LobbyEmptyResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LobbySummary : PlayFabBaseModel
    {
        /// <summary>
        /// A string used to join the lobby.This field is populated by the Lobby service.Invites are performed by communicating this
        /// connectionString to other players.
        /// </summary>
        public string ConnectionString;
        /// <summary>
        /// The current number of players in the lobby.
        /// </summary>
        public uint CurrentPlayers;
        /// <summary>
        /// Id to uniquely identify a lobby.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// The maximum number of players allowed in the lobby.
        /// </summary>
        public uint MaxPlayers;
        /// <summary>
        /// A setting indicating whether members are allowed to join this lobby. When Locked new members are prevented from joining.
        /// </summary>
        public MembershipLock? MembershipLock;
        /// <summary>
        /// The client or server entity which owns this lobby.
        /// </summary>
        public EntityKey Owner;
        /// <summary>
        /// Search data.
        /// </summary>
        public Dictionary<string,string> SearchData;
    }

    /// <summary>
    /// A user in a matchmaking ticket.
    /// </summary>
    [Serializable]
    public class MatchmakingPlayer : PlayFabBaseModel
    {
        /// <summary>
        /// The user's attributes custom to the title.
        /// </summary>
        public MatchmakingPlayerAttributes Attributes;
        /// <summary>
        /// The entity key of the matchmaking user.
        /// </summary>
        public EntityKey Entity;
    }

    /// <summary>
    /// The matchmaking attributes for a user.
    /// </summary>
    [Serializable]
    public class MatchmakingPlayerAttributes : PlayFabBaseModel
    {
        /// <summary>
        /// A data object representing a user's attributes.
        /// </summary>
        public object DataObject;
        /// <summary>
        /// An escaped data object representing a user's attributes.
        /// </summary>
        public string EscapedDataObject;
    }

    /// <summary>
    /// A player in a created matchmaking match with a team assignment.
    /// </summary>
    [Serializable]
    public class MatchmakingPlayerWithTeamAssignment : PlayFabBaseModel
    {
        /// <summary>
        /// The user's attributes custom to the title. These attributes will be null unless the request has ReturnMemberAttributes
        /// flag set to true.
        /// </summary>
        public MatchmakingPlayerAttributes Attributes;
        /// <summary>
        /// The entity key of the matchmaking user.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Id of the team the User is assigned to.
        /// </summary>
        public string TeamId;
    }

    [Serializable]
    public class MatchmakingQueueConfig : PlayFabBaseModel
    {
        /// <summary>
        /// This is the buildId that will be used to allocate the multiplayer server for the match.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// List of difference rules used to find an optimal match.
        /// </summary>
        public List<DifferenceRule> DifferenceRules;
        /// <summary>
        /// List of match total rules used to find an optimal match.
        /// </summary>
        public List<MatchTotalRule> MatchTotalRules;
        /// <summary>
        /// Maximum number of players in a match.
        /// </summary>
        public uint MaxMatchSize;
        /// <summary>
        /// Maximum number of players in a ticket. Optional.
        /// </summary>
        public uint? MaxTicketSize;
        /// <summary>
        /// Minimum number of players in a match.
        /// </summary>
        public uint MinMatchSize;
        /// <summary>
        /// Unique identifier for a Queue. Chosen by the developer.
        /// </summary>
        public string Name;
        /// <summary>
        /// Region selection rule used to find an optimal match.
        /// </summary>
        public RegionSelectionRule RegionSelectionRule;
        /// <summary>
        /// Boolean flag to enable server allocation for the queue.
        /// </summary>
        public bool ServerAllocationEnabled;
        /// <summary>
        /// List of set intersection rules used to find an optimal match.
        /// </summary>
        public List<SetIntersectionRule> SetIntersectionRules;
        /// <summary>
        /// Controls which statistics are visible to players.
        /// </summary>
        public StatisticsVisibilityToPlayers StatisticsVisibilityToPlayers;
        /// <summary>
        /// List of string equality rules used to find an optimal match.
        /// </summary>
        public List<StringEqualityRule> StringEqualityRules;
        /// <summary>
        /// List of team difference rules used to find an optimal match.
        /// </summary>
        public List<TeamDifferenceRule> TeamDifferenceRules;
        /// <summary>
        /// The team configuration for a match. This may be null if there are no teams.
        /// </summary>
        public List<MatchmakingQueueTeam> Teams;
        /// <summary>
        /// Team size balance rule used to find an optimal match.
        /// </summary>
        public TeamSizeBalanceRule TeamSizeBalanceRule;
        /// <summary>
        /// Team ticket size similarity rule used to find an optimal match.
        /// </summary>
        public TeamTicketSizeSimilarityRule TeamTicketSizeSimilarityRule;
    }

    [Serializable]
    public class MatchmakingQueueTeam : PlayFabBaseModel
    {
        /// <summary>
        /// The maximum number of players required for the team.
        /// </summary>
        public uint MaxTeamSize;
        /// <summary>
        /// The minimum number of players required for the team.
        /// </summary>
        public uint MinTeamSize;
        /// <summary>
        /// A name to identify the team. This is case insensitive.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class MatchTotalRule : PlayFabBaseModel
    {
        /// <summary>
        /// Description of the attribute used by this rule to match tickets.
        /// </summary>
        public QueueRuleAttribute Attribute;
        /// <summary>
        /// Collection of fields relating to expanding this rule at set intervals.
        /// </summary>
        public MatchTotalRuleExpansion Expansion;
        /// <summary>
        /// The maximum total value for a group. Must be >= Min.
        /// </summary>
        public double Max;
        /// <summary>
        /// The minimum total value for a group. Must be >=2.
        /// </summary>
        public double Min;
        /// <summary>
        /// Friendly name chosen by developer.
        /// </summary>
        public string Name;
        /// <summary>
        /// How many seconds before this rule is no longer enforced (but tickets that comply with this rule will still be
        /// prioritized over those that don't). Leave blank if this rule is always enforced.
        /// </summary>
        public uint? SecondsUntilOptional;
        /// <summary>
        /// The relative weight of this rule compared to others.
        /// </summary>
        public double Weight;
    }

    [Serializable]
    public class MatchTotalRuleExpansion : PlayFabBaseModel
    {
        /// <summary>
        /// Manually specify the values to use for each expansion interval. When this is set, Max is ignored.
        /// </summary>
        public List<OverrideDouble> MaxOverrides;
        /// <summary>
        /// Manually specify the values to use for each expansion interval. When this is set, Min is ignored.
        /// </summary>
        public List<OverrideDouble> MinOverrides;
        /// <summary>
        /// How many seconds before this rule is expanded.
        /// </summary>
        public uint SecondsBetweenExpansions;
    }

    [Serializable]
    public class Member : PlayFabBaseModel
    {
        /// <summary>
        /// Key-value pairs specific to member.
        /// </summary>
        public Dictionary<string,string> MemberData;
        /// <summary>
        /// The member entity key.
        /// </summary>
        public EntityKey MemberEntity;
        /// <summary>
        /// Opaque string, stored on a Subscribe call, which indicates the connection an owner or member has with PubSub.
        /// </summary>
        public string PubSubConnectionHandle;
    }

    public enum MembershipLock
    {
        Unlocked,
        Locked
    }

    [Serializable]
    public class MonitoringApplicationConfiguration : PlayFabBaseModel
    {
        /// <summary>
        /// Asset which contains the monitoring application files and scripts.
        /// </summary>
        public AssetReference AssetReference;
        /// <summary>
        /// Execution script name, this will be the main executable for the monitoring application.
        /// </summary>
        public string ExecutionScriptName;
        /// <summary>
        /// Installation script name, this will be run before the ExecutionScript.
        /// </summary>
        public string InstallationScriptName;
        /// <summary>
        /// Timespan the monitoring application will be kept alive when running from the start of the VM
        /// </summary>
        public double? OnStartRuntimeInMinutes;
    }

    [Serializable]
    public class MonitoringApplicationConfigurationParams : PlayFabBaseModel
    {
        /// <summary>
        /// Asset which contains the monitoring application files and scripts.
        /// </summary>
        public AssetReferenceParams AssetReference;
        /// <summary>
        /// Execution script name, this will be the main executable for the monitoring application.
        /// </summary>
        public string ExecutionScriptName;
        /// <summary>
        /// Installation script name, this will be run before the ExecutionScript.
        /// </summary>
        public string InstallationScriptName;
        /// <summary>
        /// Timespan the monitoring application will be kept alive when running from the start of the VM
        /// </summary>
        public double? OnStartRuntimeInMinutes;
    }

    [Serializable]
    public class MultiplayerServerSummary : PlayFabBaseModel
    {
        /// <summary>
        /// The connected players in the multiplayer server.
        /// </summary>
        public List<ConnectedPlayer> ConnectedPlayers;
        /// <summary>
        /// The time (UTC) at which a change in the multiplayer server state was observed.
        /// </summary>
        public DateTime? LastStateTransitionTime;
        /// <summary>
        /// The region the multiplayer server is located in.
        /// </summary>
        public string Region;
        /// <summary>
        /// The string server ID of the multiplayer server generated by PlayFab.
        /// </summary>
        public string ServerId;
        /// <summary>
        /// The title generated guid string session ID of the multiplayer server.
        /// </summary>
        public string SessionId;
        /// <summary>
        /// The state of the multiplayer server.
        /// </summary>
        public string State;
        /// <summary>
        /// The virtual machine ID that the multiplayer server is located on.
        /// </summary>
        public string VmId;
    }

    public enum OsPlatform
    {
        Windows,
        Linux
    }

    [Serializable]
    public class OverrideDouble : PlayFabBaseModel
    {
        /// <summary>
        /// The custom expansion value.
        /// </summary>
        public double Value;
    }

    [Serializable]
    public class OverrideUnsignedInt : PlayFabBaseModel
    {
        /// <summary>
        /// The custom expansion value.
        /// </summary>
        public uint Value;
    }

    public enum OwnerMigrationPolicy
    {
        None,
        Automatic,
        Manual,
        Server
    }

    [Serializable]
    public class PaginationRequest : PlayFabBaseModel
    {
        /// <summary>
        /// Continuation token returned as a result in a previous FindLobbies call. Cannot be specified by clients.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// The number of lobbies that should be retrieved. Cannot be specified by servers, clients may specify any value up to 50
        /// </summary>
        public uint? PageSizeRequested;
    }

    [Serializable]
    public class PaginationResponse : PlayFabBaseModel
    {
        /// <summary>
        /// Continuation token returned by server call. Not returned for clients
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// The number of lobbies that matched the search request.
        /// </summary>
        public uint? TotalMatchedLobbyCount;
    }

    [Serializable]
    public class Port : PlayFabBaseModel
    {
        /// <summary>
        /// The name for the port.
        /// </summary>
        public string Name;
        /// <summary>
        /// The number for the port.
        /// </summary>
        public int Num;
        /// <summary>
        /// The protocol for the port.
        /// </summary>
        public ProtocolType Protocol;
    }

    public enum ProtocolType
    {
        TCP,
        UDP
    }

    [Serializable]
    public class QosServer : PlayFabBaseModel
    {
        /// <summary>
        /// The region the QoS server is located in.
        /// </summary>
        public string Region;
        /// <summary>
        /// The QoS server URL.
        /// </summary>
        public string ServerUrl;
    }

    [Serializable]
    public class QueueRuleAttribute : PlayFabBaseModel
    {
        /// <summary>
        /// Specifies which attribute in a ticket to use.
        /// </summary>
        public string Path;
        /// <summary>
        /// Specifies which source the attribute comes from.
        /// </summary>
        public AttributeSource Source;
    }

    [Serializable]
    public class QuotaChange : PlayFabBaseModel
    {
        /// <summary>
        /// A brief description of the requested changes.
        /// </summary>
        public string ChangeDescription;
        /// <summary>
        /// Requested changes to make to the titles cores quota.
        /// </summary>
        public List<CoreCapacityChange> Changes;
        /// <summary>
        /// Whether or not this request is pending a review.
        /// </summary>
        public bool IsPendingReview;
        /// <summary>
        /// Additional information about this request that our team can use to better understand the requirements.
        /// </summary>
        public string Notes;
        /// <summary>
        /// Id of the change request.
        /// </summary>
        public string RequestId;
        /// <summary>
        /// Comments by our team when a request is reviewed.
        /// </summary>
        public string ReviewComments;
        /// <summary>
        /// Whether or not this request was approved.
        /// </summary>
        public bool WasApproved;
    }

    [Serializable]
    public class RegionSelectionRule : PlayFabBaseModel
    {
        /// <summary>
        /// Controls how the Max Latency parameter expands over time. Only one expansion can be set per rule. When this is set,
        /// MaxLatency is ignored.
        /// </summary>
        public CustomRegionSelectionRuleExpansion CustomExpansion;
        /// <summary>
        /// Controls how the Max Latency parameter expands over time. Only one expansion can be set per rule.
        /// </summary>
        public LinearRegionSelectionRuleExpansion LinearExpansion;
        /// <summary>
        /// Specifies the maximum latency that is allowed between the client and the selected server. The value is in milliseconds.
        /// </summary>
        public uint MaxLatency;
        /// <summary>
        /// Friendly name chosen by developer.
        /// </summary>
        public string Name;
        /// <summary>
        /// Specifies which attribute in a ticket to use.
        /// </summary>
        public string Path;
        /// <summary>
        /// How many seconds before this rule is no longer enforced (but tickets that comply with this rule will still be
        /// prioritized over those that don't). Leave blank if this rule is always enforced.
        /// </summary>
        public uint? SecondsUntilOptional;
        /// <summary>
        /// The relative weight of this rule compared to others.
        /// </summary>
        public double Weight;
    }

    /// <summary>
    /// Deletes the configuration for a queue. This will permanently delete the configuration and players will no longer be able
    /// to match in the queue. All outstanding matchmaking tickets will be cancelled.
    /// </summary>
    [Serializable]
    public class RemoveMatchmakingQueueRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The Id of the matchmaking queue to remove.
        /// </summary>
        public string QueueName;
    }

    [Serializable]
    public class RemoveMatchmakingQueueResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Request to remove a member from a lobby. Owners may remove other members from a lobby. Members cannot remove themselves
    /// (use LeaveLobby instead).
    /// </summary>
    [Serializable]
    public class RemoveMemberFromLobbyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The id of the lobby.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// The member entity to be removed from the lobby.
        /// </summary>
        public EntityKey MemberEntity;
        /// <summary>
        /// If true, removed member can never rejoin this lobby.
        /// </summary>
        public bool PreventRejoin;
    }

    /// <summary>
    /// Requests a multiplayer server session from a particular build in any of the given preferred regions.
    /// </summary>
    [Serializable]
    public class RequestMultiplayerServerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The identifiers of the build alias to use for the request.
        /// </summary>
        public BuildAliasParams BuildAliasParams;
        /// <summary>
        /// The guid string build ID of the multiplayer server to request.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Initial list of players (potentially matchmade) allowed to connect to the game. This list is passed to the game server
        /// when requested (via GSDK) and can be used to validate players connecting to it.
        /// </summary>
        public List<string> InitialPlayers;
        /// <summary>
        /// The preferred regions to request a multiplayer server from. The Multiplayer Service will iterate through the regions in
        /// the specified order and allocate a server from the first one that has servers available.
        /// </summary>
        public List<string> PreferredRegions;
        /// <summary>
        /// Data encoded as a string that is passed to the game server when requested. This can be used to to communicate
        /// information such as game mode or map through the request flow.
        /// </summary>
        public string SessionCookie;
        /// <summary>
        /// A guid string session ID created track the multiplayer server session over its life.
        /// </summary>
        public string SessionId;
    }

    [Serializable]
    public class RequestMultiplayerServerResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The identity of the build in which the server was allocated.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The connected players in the multiplayer server.
        /// </summary>
        public List<ConnectedPlayer> ConnectedPlayers;
        /// <summary>
        /// The fully qualified domain name of the virtual machine that is hosting this multiplayer server.
        /// </summary>
        public string FQDN;
        /// <summary>
        /// The IPv4 address of the virtual machine that is hosting this multiplayer server.
        /// </summary>
        public string IPV4Address;
        /// <summary>
        /// The time (UTC) at which a change in the multiplayer server state was observed.
        /// </summary>
        public DateTime? LastStateTransitionTime;
        /// <summary>
        /// The ports the multiplayer server uses.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The region the multiplayer server is located in.
        /// </summary>
        public string Region;
        /// <summary>
        /// The string server ID of the multiplayer server generated by PlayFab.
        /// </summary>
        public string ServerId;
        /// <summary>
        /// The guid string session ID of the multiplayer server.
        /// </summary>
        public string SessionId;
        /// <summary>
        /// The state of the multiplayer server.
        /// </summary>
        public string State;
        /// <summary>
        /// The virtual machine ID that the multiplayer server is located on.
        /// </summary>
        public string VmId;
    }

    /// <summary>
    /// Gets new credentials to the container registry where game developers can upload custom container images to before
    /// creating a new build.
    /// </summary>
    [Serializable]
    public class RolloverContainerRegistryCredentialsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class RolloverContainerRegistryCredentialsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The url of the container registry.
        /// </summary>
        public string DnsName;
        /// <summary>
        /// The password for accessing the container registry.
        /// </summary>
        public string Password;
        /// <summary>
        /// The username for accessing the container registry.
        /// </summary>
        public string Username;
    }

    [Serializable]
    public class Schedule : PlayFabBaseModel
    {
        /// <summary>
        /// A short description about this schedule. For example, "Game launch on July 15th".
        /// </summary>
        public string Description;
        /// <summary>
        /// The date and time in UTC at which the schedule ends. If IsRecurringWeekly is true, this schedule will keep renewing for
        /// future weeks until disabled or removed.
        /// </summary>
        public DateTime EndTime;
        /// <summary>
        /// Disables the schedule.
        /// </summary>
        public bool IsDisabled;
        /// <summary>
        /// If true, the StartTime and EndTime will get renewed every week.
        /// </summary>
        public bool IsRecurringWeekly;
        /// <summary>
        /// The date and time in UTC at which the schedule starts.
        /// </summary>
        public DateTime StartTime;
        /// <summary>
        /// The standby target to maintain for the duration of the schedule.
        /// </summary>
        public int TargetStandby;
    }

    [Serializable]
    public class ScheduledStandbySettings : PlayFabBaseModel
    {
        /// <summary>
        /// When true, scheduled standby will be enabled
        /// </summary>
        public bool IsEnabled;
        /// <summary>
        /// A list of non-overlapping schedules
        /// </summary>
        public List<Schedule> ScheduleList;
    }

    [Serializable]
    public class ServerDetails : PlayFabBaseModel
    {
        /// <summary>
        /// The fully qualified domain name of the virtual machine that is hosting this multiplayer server.
        /// </summary>
        public string Fqdn;
        /// <summary>
        /// The IPv4 address of the virtual machine that is hosting this multiplayer server.
        /// </summary>
        public string IPV4Address;
        /// <summary>
        /// The ports the multiplayer server uses.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The server's region.
        /// </summary>
        public string Region;
    }

    public enum ServerType
    {
        Container,
        Process
    }

    [Serializable]
    public class SetIntersectionRule : PlayFabBaseModel
    {
        /// <summary>
        /// Description of the attribute used by this rule to match tickets.
        /// </summary>
        public QueueRuleAttribute Attribute;
        /// <summary>
        /// Describes the behavior when an attribute is not specified in the ticket creation request or in the user's entity
        /// profile.
        /// </summary>
        public AttributeNotSpecifiedBehavior AttributeNotSpecifiedBehavior;
        /// <summary>
        /// Collection of fields relating to expanding this rule at set intervals. Only one expansion can be set per rule. When this
        /// is set, MinIntersectionSize is ignored.
        /// </summary>
        public CustomSetIntersectionRuleExpansion CustomExpansion;
        /// <summary>
        /// The default value assigned to tickets that are missing the attribute specified by AttributePath (assuming that
        /// AttributeNotSpecifiedBehavior is UseDefault). Values must be unique.
        /// </summary>
        public List<string> DefaultAttributeValue;
        /// <summary>
        /// Collection of fields relating to expanding this rule at set intervals. Only one expansion can be set per rule.
        /// </summary>
        public LinearSetIntersectionRuleExpansion LinearExpansion;
        /// <summary>
        /// The minimum number of values that must match between sets.
        /// </summary>
        public uint MinIntersectionSize;
        /// <summary>
        /// Friendly name chosen by developer.
        /// </summary>
        public string Name;
        /// <summary>
        /// How many seconds before this rule is no longer enforced (but tickets that comply with this rule will still be
        /// prioritized over those that don't). Leave blank if this rule is always enforced.
        /// </summary>
        public uint? SecondsUntilOptional;
        /// <summary>
        /// The relative weight of this rule compared to others.
        /// </summary>
        public double Weight;
    }

    /// <summary>
    /// Use this API to create or update matchmaking queue configurations. The queue configuration defines the matchmaking
    /// rules. The matchmaking service will match tickets together according to the configured rules. Queue resources are not
    /// spun up by calling this API. Queues are created when the first ticket is submitted.
    /// </summary>
    [Serializable]
    public class SetMatchmakingQueueRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The matchmaking queue config.
        /// </summary>
        public MatchmakingQueueConfig MatchmakingQueue;
    }

    [Serializable]
    public class SetMatchmakingQueueResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Executes the shutdown callback from the GSDK and terminates the multiplayer server session. The callback in the GSDK
    /// will allow for graceful shutdown with a 15 minute timeoutIf graceful shutdown has not been completed before 15 minutes
    /// have elapsed, the multiplayer server session will be forcefully terminated on it's own.
    /// </summary>
    [Serializable]
    public class ShutdownMultiplayerServerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// A guid string session ID of the multiplayer server to shut down.
        /// </summary>
        public string SessionId;
    }

    [Serializable]
    public class Statistics : PlayFabBaseModel
    {
        /// <summary>
        /// The average.
        /// </summary>
        public double Average;
        /// <summary>
        /// The 50th percentile.
        /// </summary>
        public double Percentile50;
        /// <summary>
        /// The 90th percentile.
        /// </summary>
        public double Percentile90;
        /// <summary>
        /// The 99th percentile.
        /// </summary>
        public double Percentile99;
    }

    [Serializable]
    public class StatisticsVisibilityToPlayers : PlayFabBaseModel
    {
        /// <summary>
        /// Whether to allow players to view the current number of players in the matchmaking queue.
        /// </summary>
        public bool ShowNumberOfPlayersMatching;
        /// <summary>
        /// Whether to allow players to view statistics representing the time it takes for tickets to find a match.
        /// </summary>
        public bool ShowTimeToMatch;
    }

    [Serializable]
    public class StringEqualityRule : PlayFabBaseModel
    {
        /// <summary>
        /// Description of the attribute used by this rule to match tickets.
        /// </summary>
        public QueueRuleAttribute Attribute;
        /// <summary>
        /// Describes the behavior when an attribute is not specified in the ticket creation request or in the user's entity
        /// profile.
        /// </summary>
        public AttributeNotSpecifiedBehavior AttributeNotSpecifiedBehavior;
        /// <summary>
        /// The default value assigned to tickets that are missing the attribute specified by AttributePath (assuming that
        /// AttributeNotSpecifiedBehavior is false).
        /// </summary>
        public string DefaultAttributeValue;
        /// <summary>
        /// Collection of fields relating to expanding this rule at set intervals. For StringEqualityRules, this is limited to
        /// turning the rule off or on during different intervals.
        /// </summary>
        public StringEqualityRuleExpansion Expansion;
        /// <summary>
        /// Friendly name chosen by developer.
        /// </summary>
        public string Name;
        /// <summary>
        /// How many seconds before this rule is no longer enforced (but tickets that comply with this rule will still be
        /// prioritized over those that don't). Leave blank if this rule is always enforced.
        /// </summary>
        public uint? SecondsUntilOptional;
        /// <summary>
        /// The relative weight of this rule compared to others.
        /// </summary>
        public double Weight;
    }

    [Serializable]
    public class StringEqualityRuleExpansion : PlayFabBaseModel
    {
        /// <summary>
        /// List of bools specifying whether the rule is applied during this expansion.
        /// </summary>
        public List<bool> EnabledOverrides;
        /// <summary>
        /// How many seconds before this rule is expanded.
        /// </summary>
        public uint SecondsBetweenExpansions;
    }

    /// <summary>
    /// Request to subscribe to lobby resource notifications.
    /// </summary>
    [Serializable]
    public class SubscribeToLobbyResourceRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity performing the subscription.
        /// </summary>
        public EntityKey EntityKey;
        /// <summary>
        /// Opaque string, given to a client upon creating a connection with PubSub.
        /// </summary>
        public string PubSubConnectionHandle;
        /// <summary>
        /// The name of the resource to subscribe to.
        /// </summary>
        public string ResourceId;
        /// <summary>
        /// Version number for the subscription of this resource.
        /// </summary>
        public uint SubscriptionVersion;
        /// <summary>
        /// Subscription type.
        /// </summary>
        public SubscriptionType Type;
    }

    [Serializable]
    public class SubscribeToLobbyResourceResult : PlayFabResultCommon
    {
        /// <summary>
        /// Topic will be returned in all notifications that are the result of this subscription.
        /// </summary>
        public string Topic;
    }

    /// <summary>
    /// Subscribe to match resource notifications. Match subscriptions have two types; MatchInvite and MatchTicketStatusChange
    /// </summary>
    [Serializable]
    public class SubscribeToMatchResourceRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity performing the subscription. The entity must be authorized to use this connectionHandle.
        /// </summary>
        public EntityKey EntityKey;
        /// <summary>
        /// Opaque string, given to a client upon creating a connection with PubSub. Notifications will be sent to the connection
        /// associated with this handle.
        /// </summary>
        public string PubSubConnectionHandle;
        /// <summary>
        /// The name of the resource to subscribe to.
        /// </summary>
        public string ResourceId;
        /// <summary>
        /// Version number for the subscription of this resource. Current supported version must be 1.
        /// </summary>
        public uint SubscriptionVersion;
        /// <summary>
        /// Subscription type. MatchInvite subscriptions are per-player. MatchTicketStatusChange subscriptions are per-ticket.
        /// Subscribe calls are idempotent. Subscribing on the same resource for the same connection results in success.
        /// </summary>
        public string Type;
    }

    [Serializable]
    public class SubscribeToMatchResourceResult : PlayFabResultCommon
    {
        /// <summary>
        /// Matchmaking resource
        /// </summary>
        public string Topic;
    }

    public enum SubscriptionType
    {
        LobbyChange,
        LobbyInvite
    }

    [Serializable]
    public class TeamDifferenceRule : PlayFabBaseModel
    {
        /// <summary>
        /// Description of the attribute used by this rule to match teams.
        /// </summary>
        public QueueRuleAttribute Attribute;
        /// <summary>
        /// Collection of fields relating to expanding this rule at set intervals. Only one expansion can be set per rule. When this
        /// is set, Difference is ignored.
        /// </summary>
        public CustomTeamDifferenceRuleExpansion CustomExpansion;
        /// <summary>
        /// The default value assigned to tickets that are missing the attribute specified by AttributePath (assuming that
        /// AttributeNotSpecifiedBehavior is false).
        /// </summary>
        public double DefaultAttributeValue;
        /// <summary>
        /// The allowed difference between any two teams at the start of matchmaking.
        /// </summary>
        public double Difference;
        /// <summary>
        /// Collection of fields relating to expanding this rule at set intervals. Only one expansion can be set per rule.
        /// </summary>
        public LinearTeamDifferenceRuleExpansion LinearExpansion;
        /// <summary>
        /// Friendly name chosen by developer.
        /// </summary>
        public string Name;
        /// <summary>
        /// How many seconds before this rule is no longer enforced (but tickets that comply with this rule will still be
        /// prioritized over those that don't). Leave blank if this rule is always enforced.
        /// </summary>
        public uint? SecondsUntilOptional;
    }

    [Serializable]
    public class TeamSizeBalanceRule : PlayFabBaseModel
    {
        /// <summary>
        /// Controls how the Difference parameter expands over time. Only one expansion can be set per rule. When this is set,
        /// Difference is ignored.
        /// </summary>
        public CustomTeamSizeBalanceRuleExpansion CustomExpansion;
        /// <summary>
        /// The allowed difference in team size between any two teams.
        /// </summary>
        public uint Difference;
        /// <summary>
        /// Controls how the Difference parameter expands over time. Only one expansion can be set per rule.
        /// </summary>
        public LinearTeamSizeBalanceRuleExpansion LinearExpansion;
        /// <summary>
        /// Friendly name chosen by developer.
        /// </summary>
        public string Name;
        /// <summary>
        /// How many seconds before this rule is no longer enforced (but tickets that comply with this rule will still be
        /// prioritized over those that don't). Leave blank if this rule is always enforced.
        /// </summary>
        public uint? SecondsUntilOptional;
    }

    [Serializable]
    public class TeamTicketSizeSimilarityRule : PlayFabBaseModel
    {
        /// <summary>
        /// Friendly name chosen by developer.
        /// </summary>
        public string Name;
        /// <summary>
        /// How many seconds before this rule is no longer enforced (but tickets that comply with this rule will still be
        /// prioritized over those that don't). Leave blank if this rule is always enforced.
        /// </summary>
        public uint? SecondsUntilOptional;
    }

    public enum TitleMultiplayerServerEnabledStatus
    {
        Initializing,
        Enabled,
        Disabled
    }

    [Serializable]
    public class TitleMultiplayerServersQuotas : PlayFabBaseModel
    {
        /// <summary>
        /// The core capacity for the various regions and VM Family
        /// </summary>
        public List<CoreCapacity> CoreCapacities;
    }

    /// <summary>
    /// Request to unsubscribe from lobby notifications. Only a client can unsubscribe from notifications.
    /// </summary>
    [Serializable]
    public class UnsubscribeFromLobbyResourceRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity which performed the subscription.
        /// </summary>
        public EntityKey EntityKey;
        /// <summary>
        /// Opaque string, given to a client upon creating a connection with PubSub.
        /// </summary>
        public string PubSubConnectionHandle;
        /// <summary>
        /// The name of the resource to unsubscribe from.
        /// </summary>
        public string ResourceId;
        /// <summary>
        /// Version number passed for the subscription of this resource.
        /// </summary>
        public uint SubscriptionVersion;
        /// <summary>
        /// Subscription type.
        /// </summary>
        public SubscriptionType Type;
    }

    /// <summary>
    /// Unsubscribe from a Match resource's notifications. For MatchInvite, players are expected to unsubscribe once they can no
    /// longer accept invites. For MatchTicketStatusChange, players are expected to unsusbcribe once the ticket has reached a
    /// canceled or matched state.
    /// </summary>
    [Serializable]
    public class UnsubscribeFromMatchResourceRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity performing the unsubscription. The entity must be authorized to use this connectionHandle.
        /// </summary>
        public EntityKey EntityKey;
        /// <summary>
        /// Opaque string, given to a client upon creating a connection with PubSub.
        /// </summary>
        public string PubSubConnectionHandle;
        /// <summary>
        /// The resource to unsubscribe from.
        /// </summary>
        public string ResourceId;
        /// <summary>
        /// Version number for the unsubscription from this resource.
        /// </summary>
        public uint SubscriptionVersion;
        /// <summary>
        /// Type of the subscription to be canceled.
        /// </summary>
        public string Type;
    }

    [Serializable]
    public class UnsubscribeFromMatchResourceResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Removes the specified tag from the image. After this operation, a 'docker pull' will fail for the specified image and
    /// tag combination. Morever, ListContainerImageTags will not return the specified tag.
    /// </summary>
    [Serializable]
    public class UntagContainerImageRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The container image which tag we want to remove.
        /// </summary>
        public string ImageName;
        /// <summary>
        /// The tag we want to remove.
        /// </summary>
        public string Tag;
    }

    /// <summary>
    /// Creates a multiplayer server build alias and returns the created alias.
    /// </summary>
    [Serializable]
    public class UpdateBuildAliasRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string alias Id of the alias to be updated.
        /// </summary>
        public string AliasId;
        /// <summary>
        /// The alias name.
        /// </summary>
        public string AliasName;
        /// <summary>
        /// Array of build selection criteria.
        /// </summary>
        public List<BuildSelectionCriterion> BuildSelectionCriteria;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    /// <summary>
    /// Updates a multiplayer server build's name.
    /// </summary>
    [Serializable]
    public class UpdateBuildNameRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string ID of the build we want to update the name of.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The build name.
        /// </summary>
        public string BuildName;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    /// <summary>
    /// Updates a multiplayer server build's region.
    /// </summary>
    [Serializable]
    public class UpdateBuildRegionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string ID of the build we want to update regions for.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The updated region configuration that should be applied to the specified build.
        /// </summary>
        public BuildRegionParams BuildRegion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    /// <summary>
    /// Updates a multiplayer server build's regions.
    /// </summary>
    [Serializable]
    public class UpdateBuildRegionsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string ID of the build we want to update regions for.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The updated region configuration that should be applied to the specified build.
        /// </summary>
        public List<BuildRegionParams> BuildRegions;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    /// <summary>
    /// Request to update a lobby.
    /// </summary>
    [Serializable]
    public class UpdateLobbyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The policy indicating who is allowed to join the lobby, and the visibility to queries. May be 'Public', 'Friends' or
        /// 'Private'. Public means the lobby is both visible in queries and any player may join, including invited players. Friends
        /// means that users who are bidirectional friends of members in the lobby may search to find friend lobbies, to retrieve
        /// its connection string. Private means the lobby is not visible in queries, and a player must receive an invitation to
        /// join. Defaults to 'Public' on creation. Can only be changed by the lobby owner.
        /// </summary>
        public AccessPolicy? AccessPolicy;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The private key-value pairs which are only visible to members of the lobby. Optional. Sets or updates key-value pairs on
        /// the lobby. Only the current lobby owner can set lobby data. Keys may be an arbitrary string of at most 30 characters.
        /// The total size of all lobbyData values may not exceed 4096 bytes. Values are not individually limited. There can be up
        /// to 30 key-value pairs stored here. Keys are case sensitive.
        /// </summary>
        public Dictionary<string,string> LobbyData;
        /// <summary>
        /// The keys to delete from the lobby LobbyData. Optional. Behaves similar to searchDataToDelete, but applies to lobbyData.
        /// </summary>
        public List<string> LobbyDataToDelete;
        /// <summary>
        /// The id of the lobby.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// The maximum number of players allowed in the lobby. Updates the maximum allowed number of players in the lobby. Only the
        /// current lobby owner can set this. If set, the value must be greater than or equal to the number of members currently in
        /// the lobby.
        /// </summary>
        public uint? MaxPlayers;
        /// <summary>
        /// The private key-value pairs used by the member to communicate information to other members and the owner. Optional. Sets
        /// or updates new key-value pairs on the caller's member data. New keys will be added with their values and existing keys
        /// will be updated with the new values. Visible to all members of the lobby. At most 30 key-value pairs may be stored here,
        /// keys are limited to 30 characters and values to 1000. The total size of all memberData values may not exceed 4096 bytes.
        /// Keys are case sensitive. Servers cannot specifiy this.
        /// </summary>
        public Dictionary<string,string> MemberData;
        /// <summary>
        /// The keys to delete from the lobby MemberData. Optional. Deletes key-value pairs on the caller's member data. All the
        /// specified keys will be removed from the caller's member data. Keys that do not exist are a no-op. If the key to delete
        /// exists in the memberData (same request) it will result in a bad request. Servers cannot specifiy this.
        /// </summary>
        public List<string> MemberDataToDelete;
        /// <summary>
        /// The member entity whose data is being modified. Servers cannot specify this.
        /// </summary>
        public EntityKey MemberEntity;
        /// <summary>
        /// A setting indicating whether the lobby is locked. May be 'Unlocked' or 'Locked'. When Locked new members are not allowed
        /// to join. Defaults to 'Unlocked' on creation. Can only be changed by the lobby owner.
        /// </summary>
        public MembershipLock? MembershipLock;
        /// <summary>
        /// The lobby owner. Optional. Set to transfer ownership of the lobby. If client - owned and 'Automatic' - The Lobby service
        /// will automatically assign another connected owner when the current owner leaves or disconnects. useConnections must be
        /// true. If client - owned and 'Manual' - Ownership is protected as long as the current owner is connected. If the current
        /// owner leaves or disconnects any member may set themselves as the current owner. The useConnections property must be
        /// true. If client-owned and 'None' - Any member can set ownership. The useConnections property can be either true or
        /// false. For all client-owned lobbies when the owner leaves and a new owner can not be automatically selected - The owner
        /// field is set to null. For all client-owned lobbies when the owner disconnects and a new owner can not be automatically
        /// selected - The owner field remains unchanged and the current owner retains all owner abilities for the lobby. If
        /// server-owned (must be 'Server') - Any server can set ownership. The useConnections property must be true.
        /// </summary>
        public EntityKey Owner;
        /// <summary>
        /// The public key-value pairs which allow queries to differentiate between lobbies. Optional. Sets or updates key-value
        /// pairs on the lobby for use with queries. Only the current lobby owner can set search data. New keys will be added with
        /// their values and existing keys will be updated with the new values. There can be up to 30 key-value pairs stored here.
        /// Keys are of the format string_key1, string_key2... string_key30 for string values, or number_key1, number_key2, ...
        /// number_key30 for numeric values. Numeric values are floats. Values can be at most 256 characters long. The total size of
        /// all searchData values may not exceed 1024 bytes.Keys are case sensitive.
        /// </summary>
        public Dictionary<string,string> SearchData;
        /// <summary>
        /// The keys to delete from the lobby SearchData. Optional. Deletes key-value pairs on the lobby. Only the current lobby
        /// owner can delete search data. All the specified keys will be removed from the search data. Keys that do not exist in the
        /// lobby are a no-op.If the key to delete exists in the searchData (same request) it will result in a bad request.
        /// </summary>
        public List<string> SearchDataToDelete;
    }

    /// <summary>
    /// Uploads a multiplayer server game certificate.
    /// </summary>
    [Serializable]
    public class UploadCertificateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The game certificate to upload.
        /// </summary>
        public Certificate GameCertificate;
    }

    [Serializable]
    public class VirtualMachineSummary : PlayFabBaseModel
    {
        /// <summary>
        /// The virtual machine health status.
        /// </summary>
        public string HealthStatus;
        /// <summary>
        /// The virtual machine state.
        /// </summary>
        public string State;
        /// <summary>
        /// The virtual machine ID.
        /// </summary>
        public string VmId;
    }

    [Serializable]
    public class WindowsCrashDumpConfiguration : PlayFabBaseModel
    {
        /// <summary>
        /// See https://docs.microsoft.com/en-us/windows/win32/wer/collecting-user-mode-dumps for valid values.
        /// </summary>
        public int? CustomDumpFlags;
        /// <summary>
        /// See https://docs.microsoft.com/en-us/windows/win32/wer/collecting-user-mode-dumps for valid values.
        /// </summary>
        public int? DumpType;
        /// <summary>
        /// Designates whether automatic crash dump capturing will be enabled for this Build.
        /// </summary>
        public bool IsEnabled;
    }
}
#endif
