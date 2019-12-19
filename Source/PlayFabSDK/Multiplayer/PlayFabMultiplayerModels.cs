#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.MultiplayerModels
{
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
        ChinaEast2,
        ChinaNorth2,
        SouthAfricaNorth
    }

    public enum AzureVmFamily
    {
        A,
        Av2,
        Dv2,
        F,
        Fsv2
    }

    public enum AzureVmSize
    {
        Standard_D1_v2,
        Standard_D2_v2,
        Standard_D3_v2,
        Standard_D4_v2,
        Standard_D5_v2,
        Standard_A1_v2,
        Standard_A2_v2,
        Standard_A4_v2,
        Standard_A8_v2,
        Standard_F1,
        Standard_F2,
        Standard_F4,
        Standard_F8,
        Standard_F16,
        Standard_F2s_v2,
        Standard_F4s_v2,
        Standard_F8s_v2,
        Standard_F16s_v2,
        Standard_A1,
        Standard_A2,
        Standard_A3,
        Standard_A4
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
        /// The maximum number of multiplayer servers for the region.
        /// </summary>
        public int MaxServers;
        /// <summary>
        /// The build region.
        /// </summary>
        public string Region;
        /// <summary>
        /// The target number of standby multiplayer servers for the region.
        /// </summary>
        public int StandbyServers;
        /// <summary>
        /// The status of multiplayer servers in the build region. Valid values are - Unknown, Initialized, Deploying, Deployed,
        /// Unhealthy.
        /// </summary>
        public string Status;
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
        /// The build region.
        /// </summary>
        public string Region;
        /// <summary>
        /// The number of standby multiplayer servers for the region.
        /// </summary>
        public int StandbyServers;
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
        ManagedWindowsServerCorePreview
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
    }

    /// <summary>
    /// Creates a multiplayer server build with a custom container and returns information about the build creation request.
    /// </summary>
    [Serializable]
    public class CreateBuildWithCustomContainerRequest : PlayFabRequestCommon
    {
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
        /// The list of game assets related to the build.
        /// </summary>
        public List<AssetReferenceParams> GameAssetReferences;
        /// <summary>
        /// The game certificates for the build.
        /// </summary>
        public List<GameCertificateReferenceParams> GameCertificateReferences;
        /// <summary>
        /// Metadata to tag the build. The keys are case insensitive. The build metadata is made available to the server through
        /// Game Server SDK (GSDK).Constraints: Maximum number of keys: 30, Maximum key length: 50, Maximum value length: 100
        /// </summary>
        public Dictionary<string,string> Metadata;
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
        /// The VM size to create the build on.
        /// </summary>
        public AzureVmSize? VmSize;
    }

    [Serializable]
    public class CreateBuildWithCustomContainerResponse : PlayFabResultCommon
    {
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
        /// The metadata of the build.
        /// </summary>
        public Dictionary<string,string> Metadata;
        /// <summary>
        /// The number of multiplayer servers to host on a single VM of the build.
        /// </summary>
        public int MultiplayerServerCountPerVm;
        /// <summary>
        /// The ports the build is mapped on.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The region configuration for the build.
        /// </summary>
        public List<BuildRegion> RegionConfigurations;
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
        /// The build name.
        /// </summary>
        public string BuildName;
        /// <summary>
        /// The flavor of container to create a build from.
        /// </summary>
        public ContainerFlavor? ContainerFlavor;
        /// <summary>
        /// The list of game assets related to the build.
        /// </summary>
        public List<AssetReferenceParams> GameAssetReferences;
        /// <summary>
        /// The game certificates for the build.
        /// </summary>
        public List<GameCertificateReferenceParams> GameCertificateReferences;
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
        /// The VM size to create the build on.
        /// </summary>
        public AzureVmSize? VmSize;
    }

    [Serializable]
    public class CreateBuildWithManagedContainerResponse : PlayFabResultCommon
    {
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
        /// The instrumentation configuration for this build.
        /// </summary>
        public InstrumentationConfiguration InstrumentationConfiguration;
        /// <summary>
        /// The metadata of the build.
        /// </summary>
        public Dictionary<string,string> Metadata;
        /// <summary>
        /// The number of multiplayer servers to host on a single VM of the build.
        /// </summary>
        public int MultiplayerServerCountPerVm;
        /// <summary>
        /// The ports the build is mapped on.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The region configuration for the build.
        /// </summary>
        public List<BuildRegion> RegionConfigurations;
        /// <summary>
        /// The command to run when the multiplayer server has been allocated, including any arguments.
        /// </summary>
        public string StartMultiplayerServerCommand;
        /// <summary>
        /// The VM size the build was created on.
        /// </summary>
        public AzureVmSize? VmSize;
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
    /// The server specifies all the members and their attributes.
    /// </summary>
    [Serializable]
    public class CreateServerMatchmakingTicketRequest : PlayFabRequestCommon
    {
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

    /// <summary>
    /// Deletes a multiplayer server game asset for a title.
    /// </summary>
    [Serializable]
    public class DeleteAssetRequest : PlayFabRequestCommon
    {
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
    }

    /// <summary>
    /// Deletes a multiplayer server game certificate.
    /// </summary>
    [Serializable]
    public class DeleteCertificateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The name of the certificate.
        /// </summary>
        public string Name;
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
    /// Gets the URL to upload assets to.
    /// </summary>
    [Serializable]
    public class GetAssetUploadUrlRequest : PlayFabRequestCommon
    {
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
    }

    [Serializable]
    public class GetBuildResponse : PlayFabResultCommon
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
        /// The ports the build is mapped on.
        /// </summary>
        public List<Port> Ports;
        /// <summary>
        /// The region configuration for the build.
        /// </summary>
        public List<BuildRegion> RegionConfigurations;
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
    /// The ticket includes the invited players, their attributes if they have joined, the ticket status, the match Id when
    /// applicable, etc. Only servers, the ticket creator and the invited players can get the ticket.
    /// </summary>
    [Serializable]
    public class GetMatchmakingTicketRequest : PlayFabRequestCommon
    {
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
        [Obsolete("Use 'CancellationReasonString' instead", true)]
        public CancellationReason? CancellationReason;
        /// <summary>
        /// The reason why the current ticket was canceled. This field is only set if the ticket is in canceled state.
        /// </summary>
        public string CancellationReasonString;
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
        public string BuildId;
        /// <summary>
        /// The region the multiplayer server is located in to get details for.
        /// </summary>
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
        /// The region of the multiplayer server to get logs for.
        /// </summary>
        public string Region;
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
    /// Gets the status of whether a title is enabled for the multiplayer server feature. The enabled status can be
    /// Initializing, Enabled, and Disabled.
    /// </summary>
    [Serializable]
    public class GetTitleEnabledForMultiplayerServersStatusRequest : PlayFabRequestCommon
    {
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
    /// Gets the quotas for a title in relation to multiplayer servers.
    /// </summary>
    [Serializable]
    public class GetTitleMultiplayerServersQuotasRequest : PlayFabRequestCommon
    {
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
        /// The list of processes to be monitored on a VM for this build. Providing processes will turn on performance metrics
        /// collection for this build. Process names should not include extensions. If the game server process is: GameServer.exe;
        /// then, ProcessesToMonitor = [ GameServer ]
        /// </summary>
        public List<string> ProcessesToMonitor;
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
    /// Returns a list of multiplayer server game asset summaries for a title.
    /// </summary>
    [Serializable]
    public class ListAssetSummariesRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class ListBuildAliasesForTitleResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of build aliases for the title
        /// </summary>
        public List<BuildAliasDetailsResponse> BuildAliases;
    }

    /// <summary>
    /// Returns a list of summarized details of all multiplayer server builds for a title.
    /// </summary>
    [Serializable]
    public class ListBuildSummariesRequest : PlayFabRequestCommon
    {
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
    /// If the caller is a title, the EntityKey in the request is required. If the caller is a player, then it is optional. If
    /// it is provided it must match the caller's entity.
    /// </summary>
    [Serializable]
    public class ListMatchmakingTicketsForPlayerRequest : PlayFabRequestCommon
    {
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
        /// Qos servers version
        /// </summary>
        public string Version;
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
    /// Returns a list of quality of service servers.
    /// </summary>
    [Serializable]
    public class ListQosServersRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class ListQosServersResponse : PlayFabResultCommon
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

    /// <summary>
    /// Returns a list of summarized details of all multiplayer server builds for a title.
    /// </summary>
    [Serializable]
    public class MultiplayerEmptyRequest : PlayFabRequestCommon
    {
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
    public class ServerDetails : PlayFabBaseModel
    {
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

    /// <summary>
    /// Executes the shutdown callback from the GSDK and terminates the multiplayer server session. The callback in the GSDK
    /// will allow for graceful shutdown with a 15 minute timeoutIf graceful shutdown has not been completed before 15 minutes
    /// have elapsed, the multiplayer server session will be forcefully terminated on it's own.
    /// </summary>
    [Serializable]
    public class ShutdownMultiplayerServerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The guid string build ID of the multiplayer server to delete.
        /// </summary>
        public string BuildId;
        /// <summary>
        /// The region of the multiplayer server to shut down.
        /// </summary>
        public string Region;
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
    /// Removes the specified tag from the image. After this operation, a 'docker pull' will fail for the specified image and
    /// tag combination. Morever, ListContainerImageTags will not return the specified tag.
    /// </summary>
    [Serializable]
    public class UntagContainerImageRequest : PlayFabRequestCommon
    {
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
    }

    /// <summary>
    /// Uploads a multiplayer server game certificate.
    /// </summary>
    [Serializable]
    public class UploadCertificateRequest : PlayFabRequestCommon
    {
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
}
#endif
