#if ENABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.EntityModels;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.Public;

namespace PlayFab
{
    /// <summary>
    /// PlayFab Entity APIs provide a variety of core PlayFab features and work consistently across a broad set of entities,
    /// such as titles, players, characters, and more.
    /// </summary>
    public static class PlayFabEntityAPI
    {
        static PlayFabEntityAPI() {}

        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabHttp.ForgetAllCredentials();
        }

        /// <summary>
        /// Abort pending file uploads to an entity's profile.
        /// </summary>
        public static void AbortFileUploads(AbortFileUploadsRequest request, Action<AbortFileUploadsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/File/AbortFileUploads", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Accepts an outstanding invitation to to join a group
        /// </summary>
        public static void AcceptGroupApplication(AcceptGroupApplicationRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/AcceptGroupApplication", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Accepts an invitation to join a group
        /// </summary>
        public static void AcceptGroupInvitation(AcceptGroupInvitationRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/AcceptGroupInvitation", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Adds members to a group or role.
        /// </summary>
        public static void AddMembers(AddMembersRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/AddMembers", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Applies to join a group
        /// </summary>
        public static void ApplyToGroup(ApplyToGroupRequest request, Action<ApplyToGroupResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/ApplyToGroup", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Blocks a list of entities from joining a group.
        /// </summary>
        public static void BlockEntity(BlockEntityRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/BlockEntity", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Changes the role membership of a list of entities from one role to another.
        /// </summary>
        public static void ChangeMemberRole(ChangeMemberRoleRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/ChangeMemberRole", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Creates a new group.
        /// </summary>
        public static void CreateGroup(CreateGroupRequest request, Action<CreateGroupResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/CreateGroup", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Creates a new group role.
        /// </summary>
        public static void CreateRole(CreateGroupRoleRequest request, Action<CreateGroupRoleResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/CreateRole", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Delete files on an entity's profile.
        /// </summary>
        public static void DeleteFiles(DeleteFilesRequest request, Action<DeleteFilesResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/File/DeleteFiles", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Deletes a group and all roles, invitations, join requests, and blocks associated with it.
        /// </summary>
        public static void DeleteGroup(DeleteGroupRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/DeleteGroup", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Deletes an existing role in a group.
        /// </summary>
        public static void DeleteRole(DeleteRoleRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/DeleteRole", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Finalize file uploads to an entity's profile.
        /// </summary>
        public static void FinalizeFileUploads(FinalizeFileUploadsRequest request, Action<FinalizeFileUploadsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/File/FinalizeFileUploads", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh a still valid
        /// Entity Token.
        /// </summary>
        public static void GetEntityToken(GetEntityTokenRequest request, Action<GetEntityTokenResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            AuthType authType = AuthType.None;
#if !DISABLE_PLAYFABCLIENT_API
            if (authType == AuthType.None && PlayFabClientAPI.IsClientLoggedIn())
                authType = AuthType.LoginSession;
#endif
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || ENABLE_PLAYFABMATCHMAKER_API || UNITY_EDITOR
            if (authType == AuthType.None && !string.IsNullOrEmpty(PlayFabSettings.DeveloperSecretKey))
                authType = AuthType.DevSecretKey;
#endif

            PlayFabHttp.MakeApiCall("/Authentication/GetEntityToken", request, authType, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Retrieves file metadata from an entity's profile.
        /// </summary>
        public static void GetFiles(GetFilesRequest request, Action<GetFilesResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/File/GetFiles", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Gets the global title access policy
        /// </summary>
        public static void GetGlobalPolicy(GetGlobalPolicyRequest request, Action<GetGlobalPolicyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Profile/GetGlobalPolicy", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Gets information about a group and its roles
        /// </summary>
        public static void GetGroup(GetGroupRequest request, Action<GetGroupResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/GetGroup", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Retrieves objects from an entity's profile.
        /// </summary>
        public static void GetObjects(GetObjectsRequest request, Action<GetObjectsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Object/GetObjects", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Retrieves the entity's profile.
        /// </summary>
        public static void GetProfile(GetEntityProfileRequest request, Action<GetEntityProfileResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Profile/GetProfile", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Initiates file uploads to an entity's profile.
        /// </summary>
        public static void InitiateFileUploads(InitiateFileUploadsRequest request, Action<InitiateFileUploadsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/File/InitiateFileUploads", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Invites a player to join a group
        /// </summary>
        public static void InviteToGroup(InviteToGroupRequest request, Action<InviteToGroupResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/InviteToGroup", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Checks to see if an entity is a member of a group or role within the group
        /// </summary>
        public static void IsMember(IsMemberRequest request, Action<IsMemberResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/IsMember", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists all outstanding requests to join a group
        /// </summary>
        public static void ListGroupApplications(ListGroupApplicationsRequest request, Action<ListGroupApplicationsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/ListGroupApplications", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists all entities blocked from joining a group
        /// </summary>
        public static void ListGroupBlocks(ListGroupBlocksRequest request, Action<ListGroupBlocksResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/ListGroupBlocks", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists all outstanding invitations for a group
        /// </summary>
        public static void ListGroupInvitations(ListGroupInvitationsRequest request, Action<ListGroupInvitationsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/ListGroupInvitations", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists all members for a group
        /// </summary>
        public static void ListGroupMembers(ListGroupMembersRequest request, Action<ListGroupMembersResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/ListGroupMembers", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists all groups and roles for an entity
        /// </summary>
        public static void ListMembership(ListMembershipRequest request, Action<ListMembershipResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/ListMembership", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists all outstanding invitations and group applications for an entity
        /// </summary>
        public static void ListMembershipOpportunities(ListMembershipOpportunitiesRequest request, Action<ListMembershipOpportunitiesResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/ListMembershipOpportunities", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Removes an application to join a group
        /// </summary>
        public static void RemoveGroupApplication(RemoveGroupApplicationRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/RemoveGroupApplication", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Removes an invitation join a group
        /// </summary>
        public static void RemoveGroupInvitation(RemoveGroupInvitationRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/RemoveGroupInvitation", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Removes members from a group.
        /// </summary>
        public static void RemoveMembers(RemoveMembersRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/RemoveMembers", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Sets the global title access policy
        /// </summary>
        public static void SetGlobalPolicy(SetGlobalPolicyRequest request, Action<SetGlobalPolicyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Profile/SetGlobalPolicy", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Sets objects on an entity's profile.
        /// </summary>
        public static void SetObjects(SetObjectsRequest request, Action<SetObjectsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Object/SetObjects", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Sets the profiles access policy
        /// </summary>
        public static void SetProfilePolicy(SetEntityProfilePolicyRequest request, Action<SetEntityProfilePolicyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Profile/SetProfilePolicy", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Unblocks a list of entities from joining a group
        /// </summary>
        public static void UnblockEntity(UnblockEntityRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/UnblockEntity", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Updates non-membership data about a group.
        /// </summary>
        public static void UpdateGroup(UpdateGroupRequest request, Action<UpdateGroupResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/UpdateGroup", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Updates metadata about a role.
        /// </summary>
        public static void UpdateRole(UpdateGroupRoleRequest request, Action<UpdateGroupRoleResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Group/UpdateRole", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }


    }
}
#endif
