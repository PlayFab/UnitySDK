#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.GroupsModels
{
    /// <summary>
    /// Accepts an outstanding invitation to to join a group if the invited entity is not blocked by the group. Nothing is
    /// returned in the case of success.
    /// </summary>
    [Serializable]
    public class AcceptGroupApplicationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Type of the entity to accept as. Must be the same entity as the claimant or an entity that is a child of the claimant
        /// entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    /// <summary>
    /// Accepts an outstanding invitation to join the group if the invited entity is not blocked by the group. Only the invited
    /// entity or a parent in its chain (e.g. title) may accept the invitation on the invited entity's behalf. Nothing is
    /// returned in the case of success.
    /// </summary>
    [Serializable]
    public class AcceptGroupInvitationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    /// <summary>
    /// Adds members to a group or role. Existing members of the group will added to roles within the group, but if the user is
    /// not already a member of the group, only title claimants may add them to the group, and others must use the group
    /// application or invite system to add new members to a group. Returns nothing if successful.
    /// </summary>
    [Serializable]
    public class AddMembersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// List of entities to add to the group. Only entities of type title_player_account and character may be added to groups.
        /// </summary>
        public List<EntityKey> Members;
        /// <summary>
        /// Optional: The ID of the existing role to add the entities to. If this is not specified, the default member role for the
        /// group will be used. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string RoleId;
    }

    /// <summary>
    /// Creates an application to join a group. Calling this while a group application already exists will return the same
    /// application instead of an error and will not refresh the time before the application expires. By default, if the entity
    /// has an invitation to join the group outstanding, this will accept the invitation to join the group instead and return an
    /// error indicating such, rather than creating a duplicate application to join that will need to be cleaned up later.
    /// Returns information about the application or an error indicating an invitation was accepted instead.
    /// </summary>
    [Serializable]
    public class ApplyToGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional, default true. Automatically accept an outstanding invitation if one exists instead of creating an application
        /// </summary>
        public bool? AutoAcceptOutstandingInvite;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    /// <summary>
    /// Describes an application to join a group
    /// </summary>
    [Serializable]
    public class ApplyToGroupResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Type of entity that requested membership
        /// </summary>
        public EntityWithLineage Entity;
        /// <summary>
        /// When the application to join will expire and be deleted
        /// </summary>
        public DateTime Expires;
        /// <summary>
        /// ID of the group that the entity requesting membership to
        /// </summary>
        public EntityKey Group;
    }

    /// <summary>
    /// Blocks a list of entities from joining a group. Blocked entities may not create new applications to join, be invited to
    /// join, accept an invitation, or have an application accepted. Failure due to being blocked does not clean up existing
    /// applications or invitations to the group. No data is returned in the case of success.
    /// </summary>
    [Serializable]
    public class BlockEntityRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    /// <summary>
    /// Changes the role membership of a list of entities from one role to another in in a single operation. The destination
    /// role must already exist. This is equivalent to adding the entities to the destination role and removing from the origin
    /// role. Returns nothing if successful.
    /// </summary>
    [Serializable]
    public class ChangeMemberRoleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The ID of the role that the entities will become a member of. This must be an existing role. Role IDs must be between 1
        /// and 64 characters long.
        /// </summary>
        public string DestinationRoleId;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// List of entities to move between roles in the group. All entities in this list must be members of the group and origin
        /// role.
        /// </summary>
        public List<EntityKey> Members;
        /// <summary>
        /// The ID of the role that the entities currently are a member of. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string OriginRoleId;
    }

    /// <summary>
    /// Creates a new group, as well as administration and member roles, based off of a title's group template. Returns
    /// information about the group that was created.
    /// </summary>
    [Serializable]
    public class CreateGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The name of the group. This is unique at the title level by default.
        /// </summary>
        public string GroupName;
    }

    [Serializable]
    public class CreateGroupResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The ID of the administrator role for the group.
        /// </summary>
        public string AdminRoleId;
        /// <summary>
        /// The server date and time the group was created.
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// The name of the group.
        /// </summary>
        public string GroupName;
        /// <summary>
        /// The ID of the default member role for the group.
        /// </summary>
        public string MemberRoleId;
        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// The list of roles and names that belong to the group.
        /// </summary>
        public Dictionary<string,string> Roles;
    }

    /// <summary>
    /// Creates a new role within an existing group, with no members. Both the role ID and role name must be unique within the
    /// group, but the name can be the same as the ID. The role ID is set at creation and cannot be changed. Returns information
    /// about the role that was created.
    /// </summary>
    [Serializable]
    public class CreateGroupRoleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// The ID of the role. This must be unique within the group and cannot be changed. Role IDs must be between 1 and 64
        /// characters long.
        /// </summary>
        public string RoleId;
        /// <summary>
        /// The name of the role. This must be unique within the group and can be changed later. Role names must be between 1 and
        /// 100 characters long
        /// </summary>
        public string RoleName;
    }

    [Serializable]
    public class CreateGroupRoleResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The current version of the group profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// ID for the role
        /// </summary>
        public string RoleId;
        /// <summary>
        /// The name of the role
        /// </summary>
        public string RoleName;
    }

    /// <summary>
    /// Deletes a group and all roles, invitations, join requests, and blocks associated with it. Permission to delete is only
    /// required the group itself to execute this action. The group and data cannot be cannot be recovered once removed, but any
    /// abuse reports about the group will remain. No data is returned in the case of success.
    /// </summary>
    [Serializable]
    public class DeleteGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// ID of the group or role to remove
        /// </summary>
        public EntityKey Group;
    }

    /// <summary>
    /// Returns information about the role
    /// </summary>
    [Serializable]
    public class DeleteRoleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// The ID of the role to delete. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string RoleId;
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
    public class EntityMemberRole : PlayFabBaseModel
    {
        /// <summary>
        /// The list of members in the role
        /// </summary>
        public List<EntityWithLineage> Members;
        /// <summary>
        /// The ID of the role.
        /// </summary>
        public string RoleId;
        /// <summary>
        /// The name of the role
        /// </summary>
        public string RoleName;
    }

    /// <summary>
    /// Entity wrapper class that contains the entity key and the entities that make up the lineage of the entity.
    /// </summary>
    [Serializable]
    public class EntityWithLineage : PlayFabBaseModel
    {
        /// <summary>
        /// The entity key for the specified entity
        /// </summary>
        public EntityKey Key;
        /// <summary>
        /// Dictionary of entity keys for related entities. Dictionary key is entity type.
        /// </summary>
        public Dictionary<string,EntityKey> Lineage;
    }

    /// <summary>
    /// Returns the ID, name, role list and other non-membership related information about a group.
    /// </summary>
    [Serializable]
    public class GetGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// The full name of the group
        /// </summary>
        public string GroupName;
    }

    [Serializable]
    public class GetGroupResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The ID of the administrator role for the group.
        /// </summary>
        public string AdminRoleId;
        /// <summary>
        /// The server date and time the group was created.
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// The name of the group.
        /// </summary>
        public string GroupName;
        /// <summary>
        /// The ID of the default member role for the group.
        /// </summary>
        public string MemberRoleId;
        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// The list of roles and names that belong to the group.
        /// </summary>
        public Dictionary<string,string> Roles;
    }

    /// <summary>
    /// Describes an application to join a group
    /// </summary>
    [Serializable]
    public class GroupApplication : PlayFabBaseModel
    {
        /// <summary>
        /// Type of entity that requested membership
        /// </summary>
        public EntityWithLineage Entity;
        /// <summary>
        /// When the application to join will expire and be deleted
        /// </summary>
        public DateTime Expires;
        /// <summary>
        /// ID of the group that the entity requesting membership to
        /// </summary>
        public EntityKey Group;
    }

    /// <summary>
    /// Describes an entity that is blocked from joining a group.
    /// </summary>
    [Serializable]
    public class GroupBlock : PlayFabBaseModel
    {
        /// <summary>
        /// The entity that is blocked
        /// </summary>
        public EntityWithLineage Entity;
        /// <summary>
        /// ID of the group that the entity is blocked from
        /// </summary>
        public EntityKey Group;
    }

    /// <summary>
    /// Describes an invitation to a group.
    /// </summary>
    [Serializable]
    public class GroupInvitation : PlayFabBaseModel
    {
        /// <summary>
        /// When the invitation will expire and be deleted
        /// </summary>
        public DateTime Expires;
        /// <summary>
        /// The group that the entity invited to
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// The entity that created the invitation
        /// </summary>
        public EntityWithLineage InvitedByEntity;
        /// <summary>
        /// The entity that is invited
        /// </summary>
        public EntityWithLineage InvitedEntity;
        /// <summary>
        /// ID of the role in the group to assign the user to.
        /// </summary>
        public string RoleId;
    }

    /// <summary>
    /// Describes a group role
    /// </summary>
    [Serializable]
    public class GroupRole : PlayFabBaseModel
    {
        /// <summary>
        /// ID for the role
        /// </summary>
        public string RoleId;
        /// <summary>
        /// The name of the role
        /// </summary>
        public string RoleName;
    }

    /// <summary>
    /// Describes a group and the roles that it contains
    /// </summary>
    [Serializable]
    public class GroupWithRoles : PlayFabBaseModel
    {
        /// <summary>
        /// ID for the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// The name of the group
        /// </summary>
        public string GroupName;
        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// The list of roles within the group
        /// </summary>
        public List<GroupRole> Roles;
    }

    /// <summary>
    /// Invites a player to join a group, if they are not blocked by the group. An optional role can be provided to
    /// automatically assign the player to the role if they accept the invitation. By default, if the entity has an application
    /// to the group outstanding, this will accept the application instead and return an error indicating such, rather than
    /// creating a duplicate invitation to join that will need to be cleaned up later. Returns information about the new
    /// invitation or an error indicating an existing application to join was accepted.
    /// </summary>
    [Serializable]
    public class InviteToGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional, default true. Automatically accept an application if one exists instead of creating an invitation
        /// </summary>
        public bool? AutoAcceptOutstandingApplication;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// Optional. ID of an existing a role in the group to assign the user to. The group's default member role is used if this
        /// is not specified. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string RoleId;
    }

    /// <summary>
    /// Describes an invitation to a group.
    /// </summary>
    [Serializable]
    public class InviteToGroupResponse : PlayFabResultCommon
    {
        /// <summary>
        /// When the invitation will expire and be deleted
        /// </summary>
        public DateTime Expires;
        /// <summary>
        /// The group that the entity invited to
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// The entity that created the invitation
        /// </summary>
        public EntityWithLineage InvitedByEntity;
        /// <summary>
        /// The entity that is invited
        /// </summary>
        public EntityWithLineage InvitedEntity;
        /// <summary>
        /// ID of the role in the group to assign the user to.
        /// </summary>
        public string RoleId;
    }

    /// <summary>
    /// Checks to see if an entity is a member of a group or role within the group. A result indicating if the entity is a
    /// member of the group is returned, or a permission error if the caller does not have permission to read the group's member
    /// list.
    /// </summary>
    [Serializable]
    public class IsMemberRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// Optional: ID of the role to check membership of. Defaults to any role (that is, check to see if the entity is a member
        /// of the group in any capacity) if not specified.
        /// </summary>
        public string RoleId;
    }

    [Serializable]
    public class IsMemberResponse : PlayFabResultCommon
    {
        /// <summary>
        /// A value indicating whether or not the entity is a member.
        /// </summary>
        public bool IsMember;
    }

    /// <summary>
    /// Lists all outstanding requests to join a group. Returns a list of all requests to join, as well as when the request will
    /// expire. To get the group applications for a specific entity, use ListMembershipOpportunities.
    /// </summary>
    [Serializable]
    public class ListGroupApplicationsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    [Serializable]
    public class ListGroupApplicationsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The requested list of applications to the group.
        /// </summary>
        public List<GroupApplication> Applications;
    }

    /// <summary>
    /// Lists all entities blocked from joining a group. A list of blocked entities is returned
    /// </summary>
    [Serializable]
    public class ListGroupBlocksRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    [Serializable]
    public class ListGroupBlocksResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The requested list blocked entities.
        /// </summary>
        public List<GroupBlock> BlockedEntities;
    }

    /// <summary>
    /// Lists all outstanding invitations for a group. Returns a list of entities that have been invited, as well as when the
    /// invitation will expire. To get the group invitations for a specific entity, use ListMembershipOpportunities.
    /// </summary>
    [Serializable]
    public class ListGroupInvitationsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    [Serializable]
    public class ListGroupInvitationsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The requested list of group invitations.
        /// </summary>
        public List<GroupInvitation> Invitations;
    }

    /// <summary>
    /// Gets a list of members and the roles they belong to within the group. If the caller does not have permission to view the
    /// role, and the member is in no other role, the member is not displayed. Returns a list of entities that are members of
    /// the group.
    /// </summary>
    [Serializable]
    public class ListGroupMembersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// ID of the group to list the members and roles for
        /// </summary>
        public EntityKey Group;
    }

    [Serializable]
    public class ListGroupMembersResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The requested list of roles and member entity IDs.
        /// </summary>
        public List<EntityMemberRole> Members;
    }

    /// <summary>
    /// Lists all outstanding group applications and invitations for an entity. Anyone may call this for any entity, but data
    /// will only be returned for the entity or a parent of that entity. To list invitations or applications for a group to
    /// check if a player is trying to join, use ListGroupInvitations and ListGroupApplications.
    /// </summary>
    [Serializable]
    public class ListMembershipOpportunitiesRequest : PlayFabRequestCommon
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
    public class ListMembershipOpportunitiesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The requested list of group applications.
        /// </summary>
        public List<GroupApplication> Applications;
        /// <summary>
        /// The requested list of group invitations.
        /// </summary>
        public List<GroupInvitation> Invitations;
    }

    /// <summary>
    /// Lists the groups and roles that an entity is a part of, checking to see if group and role metadata and memberships
    /// should be visible to the caller. If the entity is not in any roles that are visible to the caller, the group is not
    /// returned in the results, even if the caller otherwise has permission to see that the entity is a member of that group.
    /// </summary>
    [Serializable]
    public class ListMembershipRequest : PlayFabRequestCommon
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
    public class ListMembershipResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of groups
        /// </summary>
        public List<GroupWithRoles> Groups;
    }

    public enum OperationTypes
    {
        Created,
        Updated,
        Deleted,
        None
    }

    /// <summary>
    /// Removes an existing application to join the group. This is used for both rejection of an application as well as
    /// withdrawing an application. The applying entity or a parent in its chain (e.g. title) may withdraw the application, and
    /// any caller with appropriate access in the group may reject an application. No data is returned in the case of success.
    /// </summary>
    [Serializable]
    public class RemoveGroupApplicationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    /// <summary>
    /// Removes an existing invitation to join the group. This is used for both rejection of an invitation as well as rescinding
    /// an invitation. The invited entity or a parent in its chain (e.g. title) may reject the invitation by calling this
    /// method, and any caller with appropriate access in the group may rescind an invitation. No data is returned in the case
    /// of success.
    /// </summary>
    [Serializable]
    public class RemoveGroupInvitationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    /// <summary>
    /// Removes members from a group. A member can always remove themselves from a group, regardless of permissions. Returns
    /// nothing if successful.
    /// </summary>
    [Serializable]
    public class RemoveMembersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// List of entities to remove
        /// </summary>
        public List<EntityKey> Members;
        /// <summary>
        /// The ID of the role to remove the entities from.
        /// </summary>
        public string RoleId;
    }

    /// <summary>
    /// Unblocks a list of entities from joining a group. No data is returned in the case of success.
    /// </summary>
    [Serializable]
    public class UnblockEntityRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    /// <summary>
    /// Updates data about a group, such as the name or default member role. Returns information about whether the update was
    /// successful. Only title claimants may modify the administration role for a group.
    /// </summary>
    [Serializable]
    public class UpdateGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional: the ID of an existing role to set as the new administrator role for the group
        /// </summary>
        public string AdminRoleId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Optional field used for concurrency control. By specifying the previously returned value of ProfileVersion from the
        /// GetGroup API, you can ensure that the group data update will only be performed if the group has not been updated by any
        /// other clients since the version you last loaded.
        /// </summary>
        public int? ExpectedProfileVersion;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// Optional: the new name of the group
        /// </summary>
        public string GroupName;
        /// <summary>
        /// Optional: the ID of an existing role to set as the new member role for the group
        /// </summary>
        public string MemberRoleId;
    }

    [Serializable]
    public class UpdateGroupResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Optional reason to explain why the operation was the result that it was.
        /// </summary>
        public string OperationReason;
        /// <summary>
        /// New version of the group data.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// Indicates which operation was completed, either Created, Updated, Deleted or None.
        /// </summary>
        public OperationTypes? SetResult;
    }

    /// <summary>
    /// Updates the role name. Returns information about whether the update was successful.
    /// </summary>
    [Serializable]
    public class UpdateGroupRoleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Optional field used for concurrency control. By specifying the previously returned value of ProfileVersion from the
        /// GetGroup API, you can ensure that the group data update will only be performed if the group has not been updated by any
        /// other clients since the version you last loaded.
        /// </summary>
        public int? ExpectedProfileVersion;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
        /// <summary>
        /// ID of the role to update. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string RoleId;
        /// <summary>
        /// The new name of the role
        /// </summary>
        public string RoleName;
    }

    [Serializable]
    public class UpdateGroupRoleResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Optional reason to explain why the operation was the result that it was.
        /// </summary>
        public string OperationReason;
        /// <summary>
        /// New version of the role data.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// Indicates which operation was completed, either Created, Updated, Deleted or None.
        /// </summary>
        public OperationTypes? SetResult;
    }
}
#endif
