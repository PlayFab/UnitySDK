#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ProfilesModels
{
    public enum EffectType
    {
        Allow,
        Deny
    }

    /// <summary>
    /// An entity object and its associated meta data.
    /// </summary>
    [Serializable]
    public class EntityDataObject
    {
        /// <summary>
        /// Un-escaped JSON object, if DataAsObject is true.
        /// </summary>
        public object DataObject;
        /// <summary>
        /// Escaped string JSON body of the object, if DataAsObject is default or false.
        /// </summary>
        public string EscapedDataObject;
        /// <summary>
        /// Name of this object.
        /// </summary>
        public string ObjectName;
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
    public class EntityLineage
    {
        /// <summary>
        /// The Character Id of the associated entity.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The Group Id of the associated entity.
        /// </summary>
        public string GroupId;
        /// <summary>
        /// The Master Player Account Id of the associated entity.
        /// </summary>
        public string MasterPlayerAccountId;
        /// <summary>
        /// The Namespace Id of the associated entity.
        /// </summary>
        public string NamespaceId;
        /// <summary>
        /// The Title Id of the associated entity.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// The Title Player Account Id of the associated entity.
        /// </summary>
        public string TitlePlayerAccountId;
    }

    [Serializable]
    public class EntityPermissionStatement
    {
        /// <summary>
        /// The action this statement effects. May be 'Read', 'Write' or '*' for both read and write.
        /// </summary>
        public string Action;
        /// <summary>
        /// A comment about the statement. Intended solely for bookkeeping and debugging.
        /// </summary>
        public string Comment;
        /// <summary>
        /// Additional conditions to be applied for entity resources.
        /// </summary>
        public object Condition;
        /// <summary>
        /// The effect this statement will have. It may be either Allow or Deny
        /// </summary>
        public EffectType Effect;
        /// <summary>
        /// The principal this statement will effect.
        /// </summary>
        public object Principal;
        /// <summary>
        /// The resource this statements effects. Similar to 'pfrn:data--title![Title ID]/Profile/*'
        /// </summary>
        public string Resource;
    }

    [Serializable]
    public class EntityProfileBody
    {
        /// <summary>
        /// The entity id and type.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The chain of responsibility for this entity. Use Lineage.
        /// </summary>
        public string EntityChain;
        /// <summary>
        /// The files on this profile.
        /// </summary>
        public Dictionary<string,EntityProfileFileMetadata> Files;
        /// <summary>
        /// The friendly name of the entity. This field may serve different purposes for different entity types. i.e.: for a title
        /// player account it could represent the display name of the player, whereas on a character it could be character's name.
        /// </summary>
        public string FriendlyName;
        /// <summary>
        /// The language on this profile.
        /// </summary>
        public string Language;
        /// <summary>
        /// The lineage of this profile.
        /// </summary>
        public EntityLineage Lineage;
        /// <summary>
        /// The objects on this profile.
        /// </summary>
        public Dictionary<string,EntityDataObject> Objects;
        /// <summary>
        /// The permissions that govern access to this entity profile and its properties. Only includes permissions set on this
        /// profile, not global statements from titles and namespaces.
        /// </summary>
        public List<EntityPermissionStatement> Permissions;
        /// <summary>
        /// The version number of the profile in persistent storage at the time of the read. Used for optional optimistic
        /// concurrency during update.
        /// </summary>
        public int VersionNumber;
    }

    /// <summary>
    /// An entity file's meta data. To get a download URL call File/GetFiles API.
    /// </summary>
    [Serializable]
    public class EntityProfileFileMetadata
    {
        /// <summary>
        /// Checksum value for the file
        /// </summary>
        public string Checksum;
        /// <summary>
        /// Name of the file
        /// </summary>
        public string FileName;
        /// <summary>
        /// Last UTC time the file was modified
        /// </summary>
        public DateTime LastModified;
        /// <summary>
        /// Storage service's reported byte count
        /// </summary>
        public int Size;
    }

    /// <summary>
    /// Given an entity type and entity identifier will retrieve the profile from the entity store. If the profile being
    /// retrieved is the caller's, then the read operation is consistent, if not it is an inconsistent read. An inconsistent
    /// read means that we do not guarantee all committed writes have occurred before reading the profile, allowing for a stale
    /// read. If consistency is important the Version Number on the result can be used to compare which version of the profile
    /// any reader has.
    /// </summary>
    [Serializable]
    public class GetEntityProfileRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Determines whether the objects will be returned as an escaped JSON string or as a un-escaped JSON object. Default is
        /// JSON string.
        /// </summary>
        public bool? DataAsObject;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetEntityProfileResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Entity profile
        /// </summary>
        public EntityProfileBody Profile;
    }

    /// <summary>
    /// Given a set of entity types and entity identifiers will retrieve all readable profiles properties for the caller.
    /// Profiles that the caller is not allowed to read will silently not be included in the results.
    /// </summary>
    [Serializable]
    public class GetEntityProfilesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Determines whether the objects will be returned as an escaped JSON string or as a un-escaped JSON object. Default is
        /// JSON string.
        /// </summary>
        public bool? DataAsObject;
        /// <summary>
        /// Entity keys of the profiles to load. Must be between 1 and 25
        /// </summary>
        public List<EntityKey> Entities;
    }

    [Serializable]
    public class GetEntityProfilesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Entity profiles
        /// </summary>
        public List<EntityProfileBody> Profiles;
    }

    /// <summary>
    /// Retrieves the title access policy that is used before the profile's policy is inspected during a request. If never
    /// customized this will return the default starter policy built by PlayFab.
    /// </summary>
    [Serializable]
    public class GetGlobalPolicyRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class GetGlobalPolicyResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The permissions that govern access to all entities under this title or namespace.
        /// </summary>
        public List<EntityPermissionStatement> Permissions;
    }

    public enum OperationTypes
    {
        Created,
        Updated,
        Deleted,
        None
    }

    /// <summary>
    /// This will set the access policy statements on the given entity profile. This is not additive, any existing statements
    /// will be replaced with the statements in this request.
    /// </summary>
    [Serializable]
    public class SetEntityProfilePolicyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The statements to include in the access policy.
        /// </summary>
        public List<EntityPermissionStatement> Statements;
    }

    [Serializable]
    public class SetEntityProfilePolicyResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The permissions that govern access to this entity profile and its properties. Only includes permissions set on this
        /// profile, not global statements from titles and namespaces.
        /// </summary>
        public List<EntityPermissionStatement> Permissions;
    }

    /// <summary>
    /// Updates the title access policy that is used before the profile's policy is inspected during a request. Policies are
    /// compiled and cached for several minutes so an update here may not be reflected in behavior for a short time.
    /// </summary>
    [Serializable]
    public class SetGlobalPolicyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The permissions that govern access to all entities under this title or namespace.
        /// </summary>
        public List<EntityPermissionStatement> Permissions;
    }

    [Serializable]
    public class SetGlobalPolicyResponse : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Given an entity profile, will update its language to the one passed in if the profile's version is at least the one
    /// passed in.
    /// </summary>
    [Serializable]
    public class SetProfileLanguageRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The expected version of a profile to perform this update on
        /// </summary>
        public int ExpectedVersion;
        /// <summary>
        /// The language to set on the given entity. Deletes the profile's language if passed in a null string.
        /// </summary>
        public string Language;
    }

    [Serializable]
    public class SetProfileLanguageResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The type of operation that occured on the profile's language
        /// </summary>
        public OperationTypes? OperationResult;
        /// <summary>
        /// The updated version of the profile after the language update
        /// </summary>
        public int? VersionNumber;
    }
}
#endif
