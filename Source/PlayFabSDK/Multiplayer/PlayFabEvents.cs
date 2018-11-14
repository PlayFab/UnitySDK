#if !DISABLE_PLAYFABENTITY_API
using PlayFab.MultiplayerModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<CreateBuildWithCustomContainerRequest> OnMultiplayerCreateBuildWithCustomContainerRequestEvent;
        public event PlayFabResultEvent<CreateBuildWithCustomContainerResponse> OnMultiplayerCreateBuildWithCustomContainerResultEvent;
        public event PlayFabRequestEvent<CreateBuildWithManagedContainerRequest> OnMultiplayerCreateBuildWithManagedContainerRequestEvent;
        public event PlayFabResultEvent<CreateBuildWithManagedContainerResponse> OnMultiplayerCreateBuildWithManagedContainerResultEvent;
        public event PlayFabRequestEvent<CreateRemoteUserRequest> OnMultiplayerCreateRemoteUserRequestEvent;
        public event PlayFabResultEvent<CreateRemoteUserResponse> OnMultiplayerCreateRemoteUserResultEvent;
        public event PlayFabRequestEvent<DeleteAssetRequest> OnMultiplayerDeleteAssetRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerDeleteAssetResultEvent;
        public event PlayFabRequestEvent<DeleteBuildRequest> OnMultiplayerDeleteBuildRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerDeleteBuildResultEvent;
        public event PlayFabRequestEvent<DeleteCertificateRequest> OnMultiplayerDeleteCertificateRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerDeleteCertificateResultEvent;
        public event PlayFabRequestEvent<DeleteRemoteUserRequest> OnMultiplayerDeleteRemoteUserRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerDeleteRemoteUserResultEvent;
        public event PlayFabRequestEvent<EnableMultiplayerServersForTitleRequest> OnMultiplayerEnableMultiplayerServersForTitleRequestEvent;
        public event PlayFabResultEvent<EnableMultiplayerServersForTitleResponse> OnMultiplayerEnableMultiplayerServersForTitleResultEvent;
        public event PlayFabRequestEvent<GetAssetUploadUrlRequest> OnMultiplayerGetAssetUploadUrlRequestEvent;
        public event PlayFabResultEvent<GetAssetUploadUrlResponse> OnMultiplayerGetAssetUploadUrlResultEvent;
        public event PlayFabRequestEvent<GetBuildRequest> OnMultiplayerGetBuildRequestEvent;
        public event PlayFabResultEvent<GetBuildResponse> OnMultiplayerGetBuildResultEvent;
        public event PlayFabRequestEvent<GetContainerRegistryCredentialsRequest> OnMultiplayerGetContainerRegistryCredentialsRequestEvent;
        public event PlayFabResultEvent<GetContainerRegistryCredentialsResponse> OnMultiplayerGetContainerRegistryCredentialsResultEvent;
        public event PlayFabRequestEvent<GetMultiplayerServerDetailsRequest> OnMultiplayerGetMultiplayerServerDetailsRequestEvent;
        public event PlayFabResultEvent<GetMultiplayerServerDetailsResponse> OnMultiplayerGetMultiplayerServerDetailsResultEvent;
        public event PlayFabRequestEvent<GetRemoteLoginEndpointRequest> OnMultiplayerGetRemoteLoginEndpointRequestEvent;
        public event PlayFabResultEvent<GetRemoteLoginEndpointResponse> OnMultiplayerGetRemoteLoginEndpointResultEvent;
        public event PlayFabRequestEvent<GetTitleEnabledForMultiplayerServersStatusRequest> OnMultiplayerGetTitleEnabledForMultiplayerServersStatusRequestEvent;
        public event PlayFabResultEvent<GetTitleEnabledForMultiplayerServersStatusResponse> OnMultiplayerGetTitleEnabledForMultiplayerServersStatusResultEvent;
        public event PlayFabRequestEvent<ListMultiplayerServersRequest> OnMultiplayerListArchivedMultiplayerServersRequestEvent;
        public event PlayFabResultEvent<ListMultiplayerServersResponse> OnMultiplayerListArchivedMultiplayerServersResultEvent;
        public event PlayFabRequestEvent<ListAssetSummariesRequest> OnMultiplayerListAssetSummariesRequestEvent;
        public event PlayFabResultEvent<ListAssetSummariesResponse> OnMultiplayerListAssetSummariesResultEvent;
        public event PlayFabRequestEvent<ListBuildSummariesRequest> OnMultiplayerListBuildSummariesRequestEvent;
        public event PlayFabResultEvent<ListBuildSummariesResponse> OnMultiplayerListBuildSummariesResultEvent;
        public event PlayFabRequestEvent<ListCertificateSummariesRequest> OnMultiplayerListCertificateSummariesRequestEvent;
        public event PlayFabResultEvent<ListCertificateSummariesResponse> OnMultiplayerListCertificateSummariesResultEvent;
        public event PlayFabRequestEvent<ListContainerImagesRequest> OnMultiplayerListContainerImagesRequestEvent;
        public event PlayFabResultEvent<ListContainerImagesResponse> OnMultiplayerListContainerImagesResultEvent;
        public event PlayFabRequestEvent<ListContainerImageTagsRequest> OnMultiplayerListContainerImageTagsRequestEvent;
        public event PlayFabResultEvent<ListContainerImageTagsResponse> OnMultiplayerListContainerImageTagsResultEvent;
        public event PlayFabRequestEvent<ListMultiplayerServersRequest> OnMultiplayerListMultiplayerServersRequestEvent;
        public event PlayFabResultEvent<ListMultiplayerServersResponse> OnMultiplayerListMultiplayerServersResultEvent;
        public event PlayFabRequestEvent<ListQosServersRequest> OnMultiplayerListQosServersRequestEvent;
        public event PlayFabResultEvent<ListQosServersResponse> OnMultiplayerListQosServersResultEvent;
        public event PlayFabRequestEvent<ListVirtualMachineSummariesRequest> OnMultiplayerListVirtualMachineSummariesRequestEvent;
        public event PlayFabResultEvent<ListVirtualMachineSummariesResponse> OnMultiplayerListVirtualMachineSummariesResultEvent;
        public event PlayFabRequestEvent<RequestMultiplayerServerRequest> OnMultiplayerRequestMultiplayerServerRequestEvent;
        public event PlayFabResultEvent<RequestMultiplayerServerResponse> OnMultiplayerRequestMultiplayerServerResultEvent;
        public event PlayFabRequestEvent<RolloverContainerRegistryCredentialsRequest> OnMultiplayerRolloverContainerRegistryCredentialsRequestEvent;
        public event PlayFabResultEvent<RolloverContainerRegistryCredentialsResponse> OnMultiplayerRolloverContainerRegistryCredentialsResultEvent;
        public event PlayFabRequestEvent<ShutdownMultiplayerServerRequest> OnMultiplayerShutdownMultiplayerServerRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerShutdownMultiplayerServerResultEvent;
        public event PlayFabRequestEvent<UpdateBuildRegionsRequest> OnMultiplayerUpdateBuildRegionsRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerUpdateBuildRegionsResultEvent;
        public event PlayFabRequestEvent<UploadCertificateRequest> OnMultiplayerUploadCertificateRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerUploadCertificateResultEvent;
    }
}
#endif
