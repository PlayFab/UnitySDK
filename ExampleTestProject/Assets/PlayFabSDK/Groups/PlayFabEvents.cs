#if !DISABLE_PLAYFABENTITY_API
using PlayFab.GroupsModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<AcceptGroupApplicationRequest> OnGroupsAcceptGroupApplicationRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnGroupsAcceptGroupApplicationResultEvent;
        public event PlayFabRequestEvent<AcceptGroupInvitationRequest> OnGroupsAcceptGroupInvitationRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnGroupsAcceptGroupInvitationResultEvent;
        public event PlayFabRequestEvent<AddMembersRequest> OnGroupsAddMembersRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnGroupsAddMembersResultEvent;
        public event PlayFabRequestEvent<ApplyToGroupRequest> OnGroupsApplyToGroupRequestEvent;
        public event PlayFabResultEvent<ApplyToGroupResponse> OnGroupsApplyToGroupResultEvent;
        public event PlayFabRequestEvent<BlockEntityRequest> OnGroupsBlockEntityRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnGroupsBlockEntityResultEvent;
        public event PlayFabRequestEvent<ChangeMemberRoleRequest> OnGroupsChangeMemberRoleRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnGroupsChangeMemberRoleResultEvent;
        public event PlayFabRequestEvent<CreateGroupRequest> OnGroupsCreateGroupRequestEvent;
        public event PlayFabResultEvent<CreateGroupResponse> OnGroupsCreateGroupResultEvent;
        public event PlayFabRequestEvent<CreateGroupRoleRequest> OnGroupsCreateRoleRequestEvent;
        public event PlayFabResultEvent<CreateGroupRoleResponse> OnGroupsCreateRoleResultEvent;
        public event PlayFabRequestEvent<DeleteGroupRequest> OnGroupsDeleteGroupRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnGroupsDeleteGroupResultEvent;
        public event PlayFabRequestEvent<DeleteRoleRequest> OnGroupsDeleteRoleRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnGroupsDeleteRoleResultEvent;
        public event PlayFabRequestEvent<GetGroupRequest> OnGroupsGetGroupRequestEvent;
        public event PlayFabResultEvent<GetGroupResponse> OnGroupsGetGroupResultEvent;
        public event PlayFabRequestEvent<InviteToGroupRequest> OnGroupsInviteToGroupRequestEvent;
        public event PlayFabResultEvent<InviteToGroupResponse> OnGroupsInviteToGroupResultEvent;
        public event PlayFabRequestEvent<IsMemberRequest> OnGroupsIsMemberRequestEvent;
        public event PlayFabResultEvent<IsMemberResponse> OnGroupsIsMemberResultEvent;
        public event PlayFabRequestEvent<ListGroupApplicationsRequest> OnGroupsListGroupApplicationsRequestEvent;
        public event PlayFabResultEvent<ListGroupApplicationsResponse> OnGroupsListGroupApplicationsResultEvent;
        public event PlayFabRequestEvent<ListGroupBlocksRequest> OnGroupsListGroupBlocksRequestEvent;
        public event PlayFabResultEvent<ListGroupBlocksResponse> OnGroupsListGroupBlocksResultEvent;
        public event PlayFabRequestEvent<ListGroupInvitationsRequest> OnGroupsListGroupInvitationsRequestEvent;
        public event PlayFabResultEvent<ListGroupInvitationsResponse> OnGroupsListGroupInvitationsResultEvent;
        public event PlayFabRequestEvent<ListGroupMembersRequest> OnGroupsListGroupMembersRequestEvent;
        public event PlayFabResultEvent<ListGroupMembersResponse> OnGroupsListGroupMembersResultEvent;
        public event PlayFabRequestEvent<ListMembershipRequest> OnGroupsListMembershipRequestEvent;
        public event PlayFabResultEvent<ListMembershipResponse> OnGroupsListMembershipResultEvent;
        public event PlayFabRequestEvent<ListMembershipOpportunitiesRequest> OnGroupsListMembershipOpportunitiesRequestEvent;
        public event PlayFabResultEvent<ListMembershipOpportunitiesResponse> OnGroupsListMembershipOpportunitiesResultEvent;
        public event PlayFabRequestEvent<RemoveGroupApplicationRequest> OnGroupsRemoveGroupApplicationRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnGroupsRemoveGroupApplicationResultEvent;
        public event PlayFabRequestEvent<RemoveGroupInvitationRequest> OnGroupsRemoveGroupInvitationRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnGroupsRemoveGroupInvitationResultEvent;
        public event PlayFabRequestEvent<RemoveMembersRequest> OnGroupsRemoveMembersRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnGroupsRemoveMembersResultEvent;
        public event PlayFabRequestEvent<UnblockEntityRequest> OnGroupsUnblockEntityRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnGroupsUnblockEntityResultEvent;
        public event PlayFabRequestEvent<UpdateGroupRequest> OnGroupsUpdateGroupRequestEvent;
        public event PlayFabResultEvent<UpdateGroupResponse> OnGroupsUpdateGroupResultEvent;
        public event PlayFabRequestEvent<UpdateGroupRoleRequest> OnGroupsUpdateRoleRequestEvent;
        public event PlayFabResultEvent<UpdateGroupRoleResponse> OnGroupsUpdateRoleResultEvent;
    }
}
#endif
