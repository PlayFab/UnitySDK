#if ENABLE_PLAYFABENTITY_API
using PlayFab.EntityModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<AbortFileUploadsRequest> OnEntityAbortFileUploadsRequestEvent;
        public event PlayFabResultEvent<AbortFileUploadsResponse> OnEntityAbortFileUploadsResultEvent;
        public event PlayFabRequestEvent<AcceptGroupApplicationRequest> OnEntityAcceptGroupApplicationRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityAcceptGroupApplicationResultEvent;
        public event PlayFabRequestEvent<AcceptGroupInvitationRequest> OnEntityAcceptGroupInvitationRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityAcceptGroupInvitationResultEvent;
        public event PlayFabRequestEvent<AddMembersRequest> OnEntityAddMembersRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityAddMembersResultEvent;
        public event PlayFabRequestEvent<ApplyToGroupRequest> OnEntityApplyToGroupRequestEvent;
        public event PlayFabResultEvent<ApplyToGroupResponse> OnEntityApplyToGroupResultEvent;
        public event PlayFabRequestEvent<BlockEntityRequest> OnEntityBlockEntityRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityBlockEntityResultEvent;
        public event PlayFabRequestEvent<ChangeMemberRoleRequest> OnEntityChangeMemberRoleRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityChangeMemberRoleResultEvent;
        public event PlayFabRequestEvent<CreateGroupRequest> OnEntityCreateGroupRequestEvent;
        public event PlayFabResultEvent<CreateGroupResponse> OnEntityCreateGroupResultEvent;
        public event PlayFabRequestEvent<CreateGroupRoleRequest> OnEntityCreateRoleRequestEvent;
        public event PlayFabResultEvent<CreateGroupRoleResponse> OnEntityCreateRoleResultEvent;
        public event PlayFabRequestEvent<DeleteFilesRequest> OnEntityDeleteFilesRequestEvent;
        public event PlayFabResultEvent<DeleteFilesResponse> OnEntityDeleteFilesResultEvent;
        public event PlayFabRequestEvent<DeleteGroupRequest> OnEntityDeleteGroupRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityDeleteGroupResultEvent;
        public event PlayFabRequestEvent<DeleteRoleRequest> OnEntityDeleteRoleRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityDeleteRoleResultEvent;
        public event PlayFabRequestEvent<FinalizeFileUploadsRequest> OnEntityFinalizeFileUploadsRequestEvent;
        public event PlayFabResultEvent<FinalizeFileUploadsResponse> OnEntityFinalizeFileUploadsResultEvent;
        public event PlayFabRequestEvent<GetEntityTokenRequest> OnEntityGetEntityTokenRequestEvent;
        public event PlayFabResultEvent<GetEntityTokenResponse> OnEntityGetEntityTokenResultEvent;
        public event PlayFabRequestEvent<GetFilesRequest> OnEntityGetFilesRequestEvent;
        public event PlayFabResultEvent<GetFilesResponse> OnEntityGetFilesResultEvent;
        public event PlayFabRequestEvent<GetGlobalPolicyRequest> OnEntityGetGlobalPolicyRequestEvent;
        public event PlayFabResultEvent<GetGlobalPolicyResponse> OnEntityGetGlobalPolicyResultEvent;
        public event PlayFabRequestEvent<GetGroupRequest> OnEntityGetGroupRequestEvent;
        public event PlayFabResultEvent<GetGroupResponse> OnEntityGetGroupResultEvent;
        public event PlayFabRequestEvent<GetObjectsRequest> OnEntityGetObjectsRequestEvent;
        public event PlayFabResultEvent<GetObjectsResponse> OnEntityGetObjectsResultEvent;
        public event PlayFabRequestEvent<GetEntityProfileRequest> OnEntityGetProfileRequestEvent;
        public event PlayFabResultEvent<GetEntityProfileResponse> OnEntityGetProfileResultEvent;
        public event PlayFabRequestEvent<InitiateFileUploadsRequest> OnEntityInitiateFileUploadsRequestEvent;
        public event PlayFabResultEvent<InitiateFileUploadsResponse> OnEntityInitiateFileUploadsResultEvent;
        public event PlayFabRequestEvent<InviteToGroupRequest> OnEntityInviteToGroupRequestEvent;
        public event PlayFabResultEvent<InviteToGroupResponse> OnEntityInviteToGroupResultEvent;
        public event PlayFabRequestEvent<IsMemberRequest> OnEntityIsMemberRequestEvent;
        public event PlayFabResultEvent<IsMemberResponse> OnEntityIsMemberResultEvent;
        public event PlayFabRequestEvent<ListGroupApplicationsRequest> OnEntityListGroupApplicationsRequestEvent;
        public event PlayFabResultEvent<ListGroupApplicationsResponse> OnEntityListGroupApplicationsResultEvent;
        public event PlayFabRequestEvent<ListGroupBlocksRequest> OnEntityListGroupBlocksRequestEvent;
        public event PlayFabResultEvent<ListGroupBlocksResponse> OnEntityListGroupBlocksResultEvent;
        public event PlayFabRequestEvent<ListGroupInvitationsRequest> OnEntityListGroupInvitationsRequestEvent;
        public event PlayFabResultEvent<ListGroupInvitationsResponse> OnEntityListGroupInvitationsResultEvent;
        public event PlayFabRequestEvent<ListGroupMembersRequest> OnEntityListGroupMembersRequestEvent;
        public event PlayFabResultEvent<ListGroupMembersResponse> OnEntityListGroupMembersResultEvent;
        public event PlayFabRequestEvent<ListMembershipRequest> OnEntityListMembershipRequestEvent;
        public event PlayFabResultEvent<ListMembershipResponse> OnEntityListMembershipResultEvent;
        public event PlayFabRequestEvent<ListMembershipOpportunitiesRequest> OnEntityListMembershipOpportunitiesRequestEvent;
        public event PlayFabResultEvent<ListMembershipOpportunitiesResponse> OnEntityListMembershipOpportunitiesResultEvent;
        public event PlayFabRequestEvent<RemoveGroupApplicationRequest> OnEntityRemoveGroupApplicationRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityRemoveGroupApplicationResultEvent;
        public event PlayFabRequestEvent<RemoveGroupInvitationRequest> OnEntityRemoveGroupInvitationRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityRemoveGroupInvitationResultEvent;
        public event PlayFabRequestEvent<RemoveMembersRequest> OnEntityRemoveMembersRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityRemoveMembersResultEvent;
        public event PlayFabRequestEvent<SetGlobalPolicyRequest> OnEntitySetGlobalPolicyRequestEvent;
        public event PlayFabResultEvent<SetGlobalPolicyResponse> OnEntitySetGlobalPolicyResultEvent;
        public event PlayFabRequestEvent<SetObjectsRequest> OnEntitySetObjectsRequestEvent;
        public event PlayFabResultEvent<SetObjectsResponse> OnEntitySetObjectsResultEvent;
        public event PlayFabRequestEvent<SetEntityProfilePolicyRequest> OnEntitySetProfilePolicyRequestEvent;
        public event PlayFabResultEvent<SetEntityProfilePolicyResponse> OnEntitySetProfilePolicyResultEvent;
        public event PlayFabRequestEvent<UnblockEntityRequest> OnEntityUnblockEntityRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityUnblockEntityResultEvent;
        public event PlayFabRequestEvent<UpdateGroupRequest> OnEntityUpdateGroupRequestEvent;
        public event PlayFabResultEvent<UpdateGroupResponse> OnEntityUpdateGroupResultEvent;
        public event PlayFabRequestEvent<UpdateGroupRoleRequest> OnEntityUpdateRoleRequestEvent;
        public event PlayFabResultEvent<UpdateGroupRoleResponse> OnEntityUpdateRoleResultEvent;
    }
}
#endif
