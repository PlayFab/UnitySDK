#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.GroupsModels
{
    [Serializable]
    public class AcceptGroupApplicationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional. Type of the entity to accept as. If specified, must be the same entity as the claimant or an entity that is a
        /// child of the claimant entity. Defaults to the claimant entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    [Serializable]
    public class AcceptGroupInvitationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    [Serializable]
    public class AddMembersRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class ApplyToGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional, default true. Automatically accept an outstanding invitation if one exists instead of creating an application
        /// </summary>
        public bool? AutoAcceptOutstandingInvite;
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

    [Serializable]
    public class BlockEntityRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    [Serializable]
    public class ChangeMemberRoleRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class CreateGroupRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class CreateGroupRoleRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class DeleteGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// ID of the group or role to remove
        /// </summary>
        public EntityKey Group;
    }

    [Serializable]
    public class DeleteRoleRequest : PlayFabRequestCommon
    {
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
    public class EntityKey
    {
        /// <summary>
        /// Unique ID of the entity.
        /// </summary>
        public string Id;
        /// <summary>
        /// Entity type. See https://api.playfab.com/docs/tutorials/entities/entitytypes
        /// </summary>
        public string Type;
    }

    [Serializable]
    public class EntityMemberRole
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
    public class EntityWithLineage
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

    [Serializable]
    public class GetGroupRequest : PlayFabRequestCommon
    {
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
    public class GroupApplication
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
    public class GroupBlock
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
    public class GroupInvitation
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
    public class GroupRole
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
    public class GroupWithRoles
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

    [Serializable]
    public class InviteToGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional, default true. Automatically accept an application if one exists instead of creating an invitation
        /// </summary>
        public bool? AutoAcceptOutstandingApplication;
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

    [Serializable]
    public class IsMemberRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class ListGroupApplicationsRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class ListGroupBlocksRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class ListGroupInvitationsRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class ListGroupMembersRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class ListMembershipOpportunitiesRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class ListMembershipRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class RemoveGroupApplicationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    [Serializable]
    public class RemoveGroupInvitationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    [Serializable]
    public class RemoveMembersRequest : PlayFabRequestCommon
    {
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

    [Serializable]
    public class UnblockEntityRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The identifier of the group
        /// </summary>
        public EntityKey Group;
    }

    [Serializable]
    public class UpdateGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional: the ID of an existing role to set as the new administrator role for the group
        /// </summary>
        public string AdminRoleId;
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

    [Serializable]
    public class UpdateGroupRoleRequest : PlayFabRequestCommon
    {
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
