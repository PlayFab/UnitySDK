#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.MultiplayerModels
{
    [Serializable]
    public class AssetReference
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
    public class AssetReferenceParams
    {
        /// <summary>
        /// The asset's file name. This must be a filename with the .zip, .tar, or .tar.gz extension.
        /// </summary>
        public string FileName;
        /// <summary>
        /// The asset's mount path.
        /// </summary>
        public string MountPath;
    }

    [Serializable]
    public class AssetSummary
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
        WestUs
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
    public class BuildRegion
    {
        /// <summary>
        /// The maximum number of multiplayer servers for the region.
        /// </summary>
        public int MaxServers;
        /// <summary>
        /// The build region.
        /// </summary>
        public AzureRegion? Region;
        /// <summary>
        /// The number of standby multiplayer servers for the region.
        /// </summary>
        public int StandbyServers;
        /// <summary>
        /// The status of multiplayer servers in the build region. Valid values are - Unknown, Initialized, Deploying, Deployed,
        /// Unhealthy.
        /// </summary>
        public string Status;
    }

    [Serializable]
    public class BuildRegionParams
    {
        /// <summary>
        /// The maximum number of multiplayer servers for the region.
        /// </summary>
        public int MaxServers;
        /// <summary>
        /// The build region.
        /// </summary>
        public AzureRegion Region;
        /// <summary>
        /// The number of standby multiplayer servers for the region.
        /// </summary>
        public int StandbyServers;
    }

    [Serializable]
    public class BuildSummary
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
    }

    [Serializable]
    public class Certificate
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
    public class CertificateSummary
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
    public class ConnectedPlayer
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
    public class ContainerImageReference
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
        /// The name of the container repository.
        /// </summary>
        public string ContainerRepositoryName;
        /// <summary>
        /// The container command to run when the multiplayer server has been allocated, including any arguments.
        /// </summary>
        public string ContainerRunCommand;
        /// <summary>
        /// The tag for the container.
        /// </summary>
        public string ContainerTag;
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
        /// Game Server SDK (GSDK).
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
        /// Metadata to tag the build. The keys are case insensitive. The build metadata is made available to the server through
        /// Game Server SDK (GSDK).
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
        public AzureRegion Region;
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
    /// Deletes a multiplayer server game asset for a title.
    /// </summary>
    [Serializable]
    public class DeleteAssetRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The filename of the asset to delete. This must be a filename with the .zip, .tar, or .tar.gz extension.
        /// </summary>
        public string FileName;
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
        public AzureRegion Region;
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

    [Serializable]
    public class GameCertificateReference
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
    public class GameCertificateReferenceParams
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
        /// The asset's file name to get the upload URL for. This must be a filename with the .zip, .tar, or .tar.gz extension.
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
        /// The asset's file name to get the upload URL for. This must be a filename will be a file with the .zip, .tar, or .tar.gz
        /// extension.
        /// </summary>
        public string FileName;
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
        public AzureRegion Region;
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
        public AzureRegion? Region;
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
        public AzureRegion Region;
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
        public AzureRegion Region;
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
        public AzureRegion Region;
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
    public class MultiplayerServerSummary
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
        public AzureRegion? Region;
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
    public class Port
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
    public class QosServer
    {
        /// <summary>
        /// The region the QoS server is located in.
        /// </summary>
        public AzureRegion? Region;
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
        public List<AzureRegion> PreferredRegions;
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
        public AzureRegion? Region;
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
        public AzureRegion Region;
        /// <summary>
        /// A guid string session ID of the multiplayer server to shut down.
        /// </summary>
        public string SessionId;
    }

    public enum TitleMultiplayerServerEnabledStatus
    {
        Initializing,
        Enabled,
        Disabled
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
    public class VirtualMachineSummary
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
