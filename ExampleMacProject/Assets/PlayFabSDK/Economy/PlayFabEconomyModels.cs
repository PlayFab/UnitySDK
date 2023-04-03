#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.EconomyModels
{
    [Serializable]
    public class AddInventoryItemsOperation : PlayFabBaseModel
    {
        /// <summary>
        /// The amount to add to the current item amount.
        /// </summary>
        public int? Amount;
        /// <summary>
        /// The duration to add to the current item expiration date.
        /// </summary>
        public double? DurationInSeconds;
        /// <summary>
        /// The inventory item the operation applies to.
        /// </summary>
        public InventoryItemReference Item;
        /// <summary>
        /// The values to apply to a stack newly created by this operation.
        /// </summary>
        public InitialValues NewStackValues;
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will add the specified inventory items.
    /// </summary>
    [Serializable]
    public class AddInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The amount to add for the current item.
        /// </summary>
        public int? Amount;
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default"). The number of inventory collections is
        /// unlimited.
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The duration to add to the current item expiration date.
        /// </summary>
        public double? DurationInSeconds;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
        /// <summary>
        /// The Idempotency ID for this request. Idempotency IDs can be used to prevent operation replay in the medium term but will
        /// be garbage collected eventually.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The inventory item the request applies to.
        /// </summary>
        public InventoryItemReference Item;
        /// <summary>
        /// The values to apply to a stack newly created by this request.
        /// </summary>
        public InitialValues NewStackValues;
    }

    [Serializable]
    public class AddInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
        /// <summary>
        /// The idempotency id used in the request.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The ids of transactions that occurred as a result of the request.
        /// </summary>
        public List<string> TransactionIds;
    }

    [Serializable]
    public class AlternateId : PlayFabBaseModel
    {
        /// <summary>
        /// Type of the alternate ID.
        /// </summary>
        public string Type;
        /// <summary>
        /// Value of the alternate ID.
        /// </summary>
        public string Value;
    }

    [Serializable]
    public class CatalogAlternateId : PlayFabBaseModel
    {
        /// <summary>
        /// Type of the alternate ID.
        /// </summary>
        public string Type;
        /// <summary>
        /// Value of the alternate ID.
        /// </summary>
        public string Value;
    }

    [Serializable]
    public class CatalogConfig : PlayFabBaseModel
    {
        /// <summary>
        /// A list of player entity keys that will have admin permissions. There is a maximum of 64 entities that can be added.
        /// </summary>
        public List<EntityKey> AdminEntities;
        /// <summary>
        /// The set of configuration that only applies to catalog items.
        /// </summary>
        public CatalogSpecificConfig Catalog;
        /// <summary>
        /// A list of deep link formats. Up to 10 can be added.
        /// </summary>
        public List<DeepLinkFormat> DeepLinkFormats;
        /// <summary>
        /// A list of display properties to index. Up to 5 mappings can be added per Display Property Type. More info on display
        /// properties can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/content-types-tags-and-properties#displayproperties
        /// </summary>
        public List<DisplayPropertyIndexInfo> DisplayPropertyIndexInfos;
        /// <summary>
        /// The set of configuration that only applies to Files.
        /// </summary>
        public FileConfig File;
        /// <summary>
        /// The set of configuration that only applies to Images.
        /// </summary>
        public ImageConfig Image;
        /// <summary>
        /// Flag defining whether catalog is enabled.
        /// </summary>
        public bool IsCatalogEnabled;
        /// <summary>
        /// A list of Platforms that can be applied to catalog items. Each platform can have a maximum character length of 40 and up
        /// to 128 platforms can be listed.
        /// </summary>
        public List<string> Platforms;
        /// <summary>
        /// A set of player entity keys that are allowed to review content. There is a maximum of 64 entities that can be added.
        /// </summary>
        public List<EntityKey> ReviewerEntities;
        /// <summary>
        /// The set of configuration that only applies to user generated contents.
        /// </summary>
        public UserGeneratedContentSpecificConfig UserGeneratedContent;
    }

    [Serializable]
    public class CatalogItem : PlayFabBaseModel
    {
        /// <summary>
        /// The alternate IDs associated with this item. An alternate ID can be set to 'FriendlyId' or any of the supported
        /// marketplace names.
        /// </summary>
        public List<CatalogAlternateId> AlternateIds;
        /// <summary>
        /// The set of content/files associated with this item. Up to 100 files can be added to an item.
        /// </summary>
        public List<Content> Contents;
        /// <summary>
        /// The client-defined type of the item.
        /// </summary>
        public string ContentType;
        /// <summary>
        /// The date and time when this item was created.
        /// </summary>
        public DateTime? CreationDate;
        /// <summary>
        /// The ID of the creator of this catalog item.
        /// </summary>
        public EntityKey CreatorEntity;
        /// <summary>
        /// The set of platform specific deep links for this item.
        /// </summary>
        public List<DeepLink> DeepLinks;
        /// <summary>
        /// The Stack Id that will be used as default for this item in Inventory when an explicit one is not provided. This
        /// DefaultStackId can be a static stack id or '{guid}', which will generate a unique stack id for the item. If null,
        /// Inventory's default stack id will be used.
        /// </summary>
        public string DefaultStackId;
        /// <summary>
        /// A dictionary of localized descriptions. Key is language code and localized string is the value. The NEUTRAL locale is
        /// required. Descriptions have a 10000 character limit per country code.
        /// </summary>
        public Dictionary<string,string> Description;
        /// <summary>
        /// Game specific properties for display purposes. This is an arbitrary JSON blob. The Display Properties field has a 10000
        /// byte limit per item.
        /// </summary>
        public object DisplayProperties;
        /// <summary>
        /// The user provided version of the item for display purposes. Maximum character length of 50.
        /// </summary>
        public string DisplayVersion;
        /// <summary>
        /// The date of when the item will cease to be available. If not provided then the product will be available indefinitely.
        /// </summary>
        public DateTime? EndDate;
        /// <summary>
        /// The current ETag value that can be used for optimistic concurrency in the If-None-Match header.
        /// </summary>
        public string ETag;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
        /// <summary>
        /// The images associated with this item. Images can be thumbnails or screenshots. Up to 100 images can be added to an item.
        /// Only .png, .jpg, .gif, and .bmp file types can be uploaded
        /// </summary>
        public List<Image> Images;
        /// <summary>
        /// Indicates if the item is hidden.
        /// </summary>
        public bool? IsHidden;
        /// <summary>
        /// The item references associated with this item. For example, the items in a Bundle/Store/Subscription. Every item can
        /// have up to 50 item references.
        /// </summary>
        public List<CatalogItemReference> ItemReferences;
        /// <summary>
        /// A dictionary of localized keywords. Key is language code and localized list of keywords is the value. Keywords have a 50
        /// character limit per keyword and up to 32 keywords can be added per country code.
        /// </summary>
        public Dictionary<string,KeywordSet> Keywords;
        /// <summary>
        /// The date and time this item was last updated.
        /// </summary>
        public DateTime? LastModifiedDate;
        /// <summary>
        /// The moderation state for this item.
        /// </summary>
        public ModerationState Moderation;
        /// <summary>
        /// The platforms supported by this item.
        /// </summary>
        public List<string> Platforms;
        /// <summary>
        /// The prices the item can be purchased for.
        /// </summary>
        public CatalogPriceOptions PriceOptions;
        /// <summary>
        /// Rating summary for this item.
        /// </summary>
        public Rating Rating;
        /// <summary>
        /// The date of when the item will be available. If not provided then the product will appear immediately.
        /// </summary>
        public DateTime? StartDate;
        /// <summary>
        /// Optional details for stores items.
        /// </summary>
        public StoreDetails StoreDetails;
        /// <summary>
        /// The list of tags that are associated with this item. Up to 32 tags can be added to an item.
        /// </summary>
        public List<string> Tags;
        /// <summary>
        /// A dictionary of localized titles. Key is language code and localized string is the value. The NEUTRAL locale is
        /// required. Titles have a 512 character limit per country code.
        /// </summary>
        public Dictionary<string,string> Title;
        /// <summary>
        /// The high-level type of the item. The following item types are supported: bundle, catalogItem, currency, store, ugc.
        /// </summary>
        public string Type;
    }

    [Serializable]
    public class CatalogItemReference : PlayFabBaseModel
    {
        /// <summary>
        /// The amount of the catalog item.
        /// </summary>
        public int? Amount;
        /// <summary>
        /// The unique ID of the catalog item.
        /// </summary>
        public string Id;
        /// <summary>
        /// The prices the catalog item can be purchased for.
        /// </summary>
        public CatalogPriceOptions PriceOptions;
    }

    [Serializable]
    public class CatalogPrice : PlayFabBaseModel
    {
        /// <summary>
        /// The amounts of the catalog item price. Each price can have up to 15 item amounts.
        /// </summary>
        public List<CatalogPriceAmount> Amounts;
        /// <summary>
        /// The per-unit duration this price can be used to purchase. The maximum duration is 100 years.
        /// </summary>
        public double? UnitDurationInSeconds;
    }

    [Serializable]
    public class CatalogPriceAmount : PlayFabBaseModel
    {
        /// <summary>
        /// The amount of the price.
        /// </summary>
        public int Amount;
        /// <summary>
        /// The Item Id of the price.
        /// </summary>
        public string ItemId;
    }

    [Serializable]
    public class CatalogPriceAmountOverride : PlayFabBaseModel
    {
        /// <summary>
        /// The exact value that should be utilized in the override.
        /// </summary>
        public int? FixedValue;
        /// <summary>
        /// The id of the item this override should utilize.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The multiplier that will be applied to the base Catalog value to determine what value should be utilized in the
        /// override.
        /// </summary>
        public double? Multiplier;
    }

    [Serializable]
    public class CatalogPriceOptions : PlayFabBaseModel
    {
        /// <summary>
        /// Prices of the catalog item. An item can have up to 15 prices
        /// </summary>
        public List<CatalogPrice> Prices;
    }

    [Serializable]
    public class CatalogPriceOptionsOverride : PlayFabBaseModel
    {
        /// <summary>
        /// The prices utilized in the override.
        /// </summary>
        public List<CatalogPriceOverride> Prices;
    }

    [Serializable]
    public class CatalogPriceOverride : PlayFabBaseModel
    {
        /// <summary>
        /// The currency amounts utilized in the override for a singular price.
        /// </summary>
        public List<CatalogPriceAmountOverride> Amounts;
    }

    [Serializable]
    public class CatalogSpecificConfig : PlayFabBaseModel
    {
        /// <summary>
        /// The set of content types that will be used for validation. Each content type can have a maximum character length of 40
        /// and up to 128 types can be listed.
        /// </summary>
        public List<string> ContentTypes;
        /// <summary>
        /// The set of tags that will be used for validation. Each tag can have a maximum character length of 32 and up to 1024 tags
        /// can be listed.
        /// </summary>
        public List<string> Tags;
    }

    public enum ConcernCategory
    {
        None,
        OffensiveContent,
        ChildExploitation,
        MalwareOrVirus,
        PrivacyConcerns,
        MisleadingApp,
        PoorPerformance,
        ReviewResponse,
        SpamAdvertising,
        Profanity
    }

    [Serializable]
    public class Content : PlayFabBaseModel
    {
        /// <summary>
        /// The content unique ID.
        /// </summary>
        public string Id;
        /// <summary>
        /// The maximum client version that this content is compatible with. Client Versions can be up to 3 segments separated by
        /// periods(.) and each segment can have a maximum value of 65535.
        /// </summary>
        public string MaxClientVersion;
        /// <summary>
        /// The minimum client version that this content is compatible with. Client Versions can be up to 3 segments separated by
        /// periods(.) and each segment can have a maximum value of 65535.
        /// </summary>
        public string MinClientVersion;
        /// <summary>
        /// The list of tags that are associated with this content. Tags must be defined in the Catalog Config before being used in
        /// content.
        /// </summary>
        public List<string> Tags;
        /// <summary>
        /// The client-defined type of the content. Content Types must be defined in the Catalog Config before being used.
        /// </summary>
        public string Type;
        /// <summary>
        /// The Azure CDN URL for retrieval of the catalog item binary content.
        /// </summary>
        public string Url;
    }

    [Serializable]
    public class ContentFeed : PlayFabBaseModel
    {
    }

    public enum CountryCode
    {
        AF,
        AX,
        AL,
        DZ,
        AS,
        AD,
        AO,
        AI,
        AQ,
        AG,
        AR,
        AM,
        AW,
        AU,
        AT,
        AZ,
        BS,
        BH,
        BD,
        BB,
        BY,
        BE,
        BZ,
        BJ,
        BM,
        BT,
        BO,
        BQ,
        BA,
        BW,
        BV,
        BR,
        IO,
        BN,
        BG,
        BF,
        BI,
        KH,
        CM,
        CA,
        CV,
        KY,
        CF,
        TD,
        CL,
        CN,
        CX,
        CC,
        CO,
        KM,
        CG,
        CD,
        CK,
        CR,
        CI,
        HR,
        CU,
        CW,
        CY,
        CZ,
        DK,
        DJ,
        DM,
        DO,
        EC,
        EG,
        SV,
        GQ,
        ER,
        EE,
        ET,
        FK,
        FO,
        FJ,
        FI,
        FR,
        GF,
        PF,
        TF,
        GA,
        GM,
        GE,
        DE,
        GH,
        GI,
        GR,
        GL,
        GD,
        GP,
        GU,
        GT,
        GG,
        GN,
        GW,
        GY,
        HT,
        HM,
        VA,
        HN,
        HK,
        HU,
        IS,
        IN,
        ID,
        IR,
        IQ,
        IE,
        IM,
        IL,
        IT,
        JM,
        JP,
        JE,
        JO,
        KZ,
        KE,
        KI,
        KP,
        KR,
        KW,
        KG,
        LA,
        LV,
        LB,
        LS,
        LR,
        LY,
        LI,
        LT,
        LU,
        MO,
        MK,
        MG,
        MW,
        MY,
        MV,
        ML,
        MT,
        MH,
        MQ,
        MR,
        MU,
        YT,
        MX,
        FM,
        MD,
        MC,
        MN,
        ME,
        MS,
        MA,
        MZ,
        MM,
        NA,
        NR,
        NP,
        NL,
        NC,
        NZ,
        NI,
        NE,
        NG,
        NU,
        NF,
        MP,
        NO,
        OM,
        PK,
        PW,
        PS,
        PA,
        PG,
        PY,
        PE,
        PH,
        PN,
        PL,
        PT,
        PR,
        QA,
        RE,
        RO,
        RU,
        RW,
        BL,
        SH,
        KN,
        LC,
        MF,
        PM,
        VC,
        WS,
        SM,
        ST,
        SA,
        SN,
        RS,
        SC,
        SL,
        SG,
        SX,
        SK,
        SI,
        SB,
        SO,
        ZA,
        GS,
        SS,
        ES,
        LK,
        SD,
        SR,
        SJ,
        SZ,
        SE,
        CH,
        SY,
        TW,
        TJ,
        TZ,
        TH,
        TL,
        TG,
        TK,
        TO,
        TT,
        TN,
        TR,
        TM,
        TC,
        TV,
        UG,
        UA,
        AE,
        GB,
        US,
        UM,
        UY,
        UZ,
        VU,
        VE,
        VN,
        VG,
        VI,
        WF,
        EH,
        YE,
        ZM,
        ZW
    }

    /// <summary>
    /// The item will not be published to the public catalog until the PublishItem API is called for the item.
    /// </summary>
    [Serializable]
    public class CreateDraftItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Metadata describing the new catalog item to be created.
        /// </summary>
        public CatalogItem Item;
        /// <summary>
        /// Whether the item should be published immediately. This value is optional, defaults to false.
        /// </summary>
        public bool Publish;
    }

    [Serializable]
    public class CreateDraftItemResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Updated metadata describing the catalog item just created.
        /// </summary>
        public CatalogItem Item;
    }

    /// <summary>
    /// Upload URLs point to Azure Blobs; clients must follow the Microsoft Azure Storage Blob Service REST API pattern for
    /// uploading content. The response contains upload URLs and IDs for each file. The IDs and URLs returned must be added to
    /// the item metadata and committed using the CreateDraftItem or UpdateDraftItem Item APIs.
    /// </summary>
    [Serializable]
    public class CreateUploadUrlsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Description of the files to be uploaded by the client.
        /// </summary>
        public List<UploadInfo> Files;
    }

    [Serializable]
    public class CreateUploadUrlsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// List of URLs metadata for the files to be uploaded by the client.
        /// </summary>
        public List<UploadUrlMetadata> UploadUrls;
    }

    [Serializable]
    public class DeepLink : PlayFabBaseModel
    {
        /// <summary>
        /// Target platform for this deep link.
        /// </summary>
        public string Platform;
        /// <summary>
        /// The deep link for this platform.
        /// </summary>
        public string Url;
    }

    [Serializable]
    public class DeepLinkFormat : PlayFabBaseModel
    {
        /// <summary>
        /// The format of the deep link to return. The format should contain '{id}' to represent where the item ID should be placed.
        /// </summary>
        public string Format;
        /// <summary>
        /// The target platform for the deep link.
        /// </summary>
        public string Platform;
    }

    [Serializable]
    public class DeleteEntityItemReviewsRequest : PlayFabRequestCommon
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
    public class DeleteEntityItemReviewsResponse : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Delete an Inventory Collection by the specified Id for an Entity
    /// </summary>
    [Serializable]
    public class DeleteInventoryCollectionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The inventory collection id the request applies to.
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity the request is about. Set to the caller by default.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
    }

    [Serializable]
    public class DeleteInventoryCollectionResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteInventoryItemsOperation : PlayFabBaseModel
    {
        /// <summary>
        /// The inventory item the operation applies to.
        /// </summary>
        public InventoryItemReference Item;
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will delete the entity's inventory items
    /// </summary>
    [Serializable]
    public class DeleteInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default"). The number of inventory collections is
        /// unlimited.
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
        /// <summary>
        /// The Idempotency ID for this request. Idempotency IDs can be used to prevent operation replay in the medium term but will
        /// be garbage collected eventually.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The inventory item the request applies to.
        /// </summary>
        public InventoryItemReference Item;
    }

    [Serializable]
    public class DeleteInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// ETags are used for concurrency checking when updating resources.
        /// </summary>
        public string ETag;
        /// <summary>
        /// The idempotency id used in the request.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The ids of transactions that occurred as a result of the request.
        /// </summary>
        public List<string> TransactionIds;
    }

    [Serializable]
    public class DeleteItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
    }

    [Serializable]
    public class DeleteItemResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DisplayPropertyIndexInfo : PlayFabBaseModel
    {
        /// <summary>
        /// The property name in the 'DisplayProperties' property to be indexed.
        /// </summary>
        public string Name;
        /// <summary>
        /// The type of the property to be indexed.
        /// </summary>
        public DisplayPropertyType? Type;
    }

    public enum DisplayPropertyType
    {
        None,
        QueryDateTime,
        QueryDouble,
        QueryString,
        SearchString
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
    /// Execute a list of Inventory Operations for an Entity
    /// </summary>
    [Serializable]
    public class ExecuteInventoryOperationsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default"). The number of inventory collections is
        /// unlimited.
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
        /// <summary>
        /// The Idempotency ID for this request. Idempotency IDs can be used to prevent operation replay in the medium term but will
        /// be garbage collected eventually.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The operations to run transactionally. The operations will be executed in-order sequentially and will succeed or fail as
        /// a batch. Up to 10 operations can be added.
        /// </summary>
        public List<InventoryOperation> Operations;
    }

    [Serializable]
    public class ExecuteInventoryOperationsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
        /// <summary>
        /// The idempotency id used in the request.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The ids of the transactions that occurred as a result of the request.
        /// </summary>
        public List<string> TransactionIds;
    }

    [Serializable]
    public class FileConfig : PlayFabBaseModel
    {
        /// <summary>
        /// The set of content types that will be used for validation. Each content type can have a maximum character length of 40
        /// and up to 128 types can be listed.
        /// </summary>
        public List<string> ContentTypes;
        /// <summary>
        /// The set of tags that will be used for validation. Each tag can have a maximum character length of 32 and up to 1024 tags
        /// can be listed.
        /// </summary>
        public List<string> Tags;
    }

    [Serializable]
    public class FilterOptions : PlayFabBaseModel
    {
        /// <summary>
        /// The OData filter utilized. Mutually exclusive with 'IncludeAllItems'. More info about Filter Complexity limits can be
        /// found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/search#limits
        /// </summary>
        public string Filter;
        /// <summary>
        /// The flag that overrides the filter and allows for returning all catalog items. Mutually exclusive with 'Filter'.
        /// </summary>
        public bool? IncludeAllItems;
    }

    [Serializable]
    public class GetCatalogConfigRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class GetCatalogConfigResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The catalog configuration.
        /// </summary>
        public CatalogConfig Config;
    }

    [Serializable]
    public class GetDraftItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
    }

    [Serializable]
    public class GetDraftItemResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Full metadata of the catalog item requested.
        /// </summary>
        public CatalogItem Item;
    }

    [Serializable]
    public class GetDraftItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of item alternate IDs.
        /// </summary>
        public List<CatalogAlternateId> AlternateIds;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// List of Item Ids.
        /// </summary>
        public List<string> Ids;
    }

    [Serializable]
    public class GetDraftItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// A set of items created by the entity.
        /// </summary>
        public List<CatalogItem> Items;
    }

    [Serializable]
    public class GetEntityDraftItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items created by the caller, if any are available. Should be null on
        /// initial request.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// Number of items to retrieve. This value is optional. Default value is 10.
        /// </summary>
        public int Count;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// OData Filter to refine the items returned. CatalogItem properties 'type' can be used in the filter. For example: "type
        /// eq 'ugc'"
        /// </summary>
        public string Filter;
    }

    [Serializable]
    public class GetEntityDraftItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// A set of items created by the entity.
        /// </summary>
        public List<CatalogItem> Items;
    }

    [Serializable]
    public class GetEntityItemReviewRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
    }

    [Serializable]
    public class GetEntityItemReviewResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The review the entity submitted for the requested item.
        /// </summary>
        public Review Review;
    }

    /// <summary>
    /// Get a list of Inventory Collection Ids for the specified Entity
    /// </summary>
    [Serializable]
    public class GetInventoryCollectionIdsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of collection ids, if any are available.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// Number of items to retrieve. This value is optional. The default value is 10
        /// </summary>
        public int Count;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity the request is about. Set to the caller by default.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetInventoryCollectionIdsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The requested inventory collection ids.
        /// </summary>
        public List<string> CollectionIds;
        /// <summary>
        /// An opaque token used to retrieve the next page of collection ids, if any are available.
        /// </summary>
        public string ContinuationToken;
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will get the entity's inventory items.
    /// </summary>
    [Serializable]
    public class GetInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default")
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// An opaque token used to retrieve the next page of items in the inventory, if any are available. Should be null on
        /// initial request.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// Number of items to retrieve. This value is optional. Maximum page size is 50. The default value is 10
        /// </summary>
        public int Count;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// OData Filter to refine the items returned. InventoryItem properties 'type', 'id', and 'stackId' can be used in the
        /// filter. For example: "type eq 'currency'"
        /// </summary>
        public string Filter;
    }

    [Serializable]
    public class GetInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
        /// <summary>
        /// The requested inventory items.
        /// </summary>
        public List<InventoryItem> Items;
    }

    /// <summary>
    /// Given an item, return a set of bundles and stores containing the item.
    /// </summary>
    [Serializable]
    public class GetItemContainersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// An opaque token used to retrieve the next page of items in the inventory, if any are available. Should be null on
        /// initial request.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// Number of items to retrieve. This value is optional. Default value is 10.
        /// </summary>
        public int Count;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
    }

    [Serializable]
    public class GetItemContainersResponse : PlayFabResultCommon
    {
        /// <summary>
        /// List of Bundles and Stores containing the requested items.
        /// </summary>
        public List<CatalogItem> Containers;
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken;
    }

    [Serializable]
    public class GetItemModerationStateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
    }

    [Serializable]
    public class GetItemModerationStateResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The current moderation state for the requested item.
        /// </summary>
        public ModerationState State;
    }

    [Serializable]
    public class GetItemPublishStatusRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
    }

    [Serializable]
    public class GetItemPublishStatusResponse : PlayFabResultCommon
    {
        /// <summary>
        /// High level status of the published item.
        /// </summary>
        public PublishResult? Result;
        /// <summary>
        /// Descriptive message about the current status of the publish.
        /// </summary>
        public string StatusMessage;
    }

    [Serializable]
    public class GetItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
    }

    /// <summary>
    /// Get item result.
    /// </summary>
    [Serializable]
    public class GetItemResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The item result.
        /// </summary>
        public CatalogItem Item;
    }

    [Serializable]
    public class GetItemReviewsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// Number of items to retrieve. This value is optional. Default value is 10.
        /// </summary>
        public int Count;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
        /// <summary>
        /// An OData orderBy used to order the results of the query. Possible values are Helpfulness, Rating, and Submitted (For
        /// example: "Submitted desc")
        /// </summary>
        public string OrderBy;
    }

    [Serializable]
    public class GetItemReviewsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// The paginated set of results.
        /// </summary>
        public List<Review> Reviews;
    }

    [Serializable]
    public class GetItemReviewSummaryRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
    }

    [Serializable]
    public class GetItemReviewSummaryResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The least favorable review for this item.
        /// </summary>
        public Review LeastFavorableReview;
        /// <summary>
        /// The most favorable review for this item.
        /// </summary>
        public Review MostFavorableReview;
        /// <summary>
        /// The summary of ratings associated with this item.
        /// </summary>
        public Rating Rating;
        /// <summary>
        /// The total number of reviews associated with this item.
        /// </summary>
        public int ReviewsCount;
    }

    [Serializable]
    public class GetItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of item alternate IDs.
        /// </summary>
        public List<CatalogAlternateId> AlternateIds;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// List of Item Ids.
        /// </summary>
        public List<string> Ids;
    }

    [Serializable]
    public class GetItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Metadata of set of items.
        /// </summary>
        public List<CatalogItem> Items;
    }

    /// <summary>
    /// Gets the access tokens for Microsoft Store authentication.
    /// </summary>
    [Serializable]
    public class GetMicrosoftStoreAccessTokensRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class GetMicrosoftStoreAccessTokensResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The collections access token for calling https://onestore.microsoft.com/b2b/keys/create/collections to obtain a
        /// CollectionsIdKey for the user
        /// </summary>
        public string CollectionsAccessToken;
        /// <summary>
        /// The date the collections access token expires
        /// </summary>
        public DateTime CollectionsAccessTokenExpirationDate;
    }

    /// <summary>
    /// Get transaction history for specified entity and collection.
    /// </summary>
    [Serializable]
    public class GetTransactionHistoryRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default")
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available. Should be null on initial request.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// Number of items to retrieve. This value is optional. The default value is 10
        /// </summary>
        public int Count;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// An OData filter used to refine the TransactionHistory. Transaction property 'timestamp' can be used in the filter. For
        /// example: "timestamp ge 'timestamp ge'" By default, a 6 month timespan from the current date is used.
        /// </summary>
        public string Filter;
    }

    [Serializable]
    public class GetTransactionHistoryResponse : PlayFabResultCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available. Should be null on initial request.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// The requested inventory transactions.
        /// </summary>
        public List<Transaction> Transactions;
    }

    [Serializable]
    public class GooglePlayProductPurchase : PlayFabBaseModel
    {
        /// <summary>
        /// The Product ID (SKU) of the InApp product purchased from the Google Play store.
        /// </summary>
        public string ProductId;
        /// <summary>
        /// The token provided to the player's device when the product was purchased
        /// </summary>
        public string Token;
    }

    public enum HelpfulnessVote
    {
        None,
        UnHelpful,
        Helpful
    }

    [Serializable]
    public class Image : PlayFabBaseModel
    {
        /// <summary>
        /// The image unique ID.
        /// </summary>
        public string Id;
        /// <summary>
        /// The client-defined tag associated with this image. Tags must be defined in the Catalog Config before being used in
        /// images
        /// </summary>
        public string Tag;
        /// <summary>
        /// Images can be defined as either a "thumbnail" or "screenshot". There can only be one "thumbnail" image per item.
        /// </summary>
        public string Type;
        /// <summary>
        /// The URL for retrieval of the image.
        /// </summary>
        public string Url;
    }

    [Serializable]
    public class ImageConfig : PlayFabBaseModel
    {
        /// <summary>
        /// The set of tags that will be used for validation. Each tag can have a maximum character length of 32 and up to 1024 tags
        /// can be listed.
        /// </summary>
        public List<string> Tags;
    }

    [Serializable]
    public class InitialValues : PlayFabBaseModel
    {
        /// <summary>
        /// Game specific properties for display purposes. The Display Properties field has a 1000 byte limit.
        /// </summary>
        public object DisplayProperties;
    }

    [Serializable]
    public class InventoryItem : PlayFabBaseModel
    {
        /// <summary>
        /// The amount of the item.
        /// </summary>
        public int? Amount;
        /// <summary>
        /// Game specific properties for display purposes. This is an arbitrary JSON blob. The Display Properties field has a 1000
        /// byte limit.
        /// </summary>
        public object DisplayProperties;
        /// <summary>
        /// Only used for subscriptions. The date of when the item will expire in UTC.
        /// </summary>
        public DateTime? ExpirationDate;
        /// <summary>
        /// The id of the item. This should correspond to the item id in the catalog.
        /// </summary>
        public string Id;
        /// <summary>
        /// The stack id of the item.
        /// </summary>
        public string StackId;
        /// <summary>
        /// The type of the item. This should correspond to the item type in the catalog.
        /// </summary>
        public string Type;
    }

    [Serializable]
    public class InventoryItemReference : PlayFabBaseModel
    {
        /// <summary>
        /// The inventory item alternate id the request applies to.
        /// </summary>
        public AlternateId AlternateId;
        /// <summary>
        /// The inventory item id the request applies to.
        /// </summary>
        public string Id;
        /// <summary>
        /// The inventory stack id the request should redeem to. (Default="default")
        /// </summary>
        public string StackId;
    }

    [Serializable]
    public class InventoryOperation : PlayFabBaseModel
    {
        /// <summary>
        /// The add operation.
        /// </summary>
        public AddInventoryItemsOperation Add;
        /// <summary>
        /// The delete operation.
        /// </summary>
        public DeleteInventoryItemsOperation Delete;
        /// <summary>
        /// The purchase operation.
        /// </summary>
        public PurchaseInventoryItemsOperation Purchase;
        /// <summary>
        /// The subtract operation.
        /// </summary>
        public SubtractInventoryItemsOperation Subtract;
        /// <summary>
        /// The transfer operation.
        /// </summary>
        public TransferInventoryItemsOperation Transfer;
        /// <summary>
        /// The update operation.
        /// </summary>
        public UpdateInventoryItemsOperation Update;
    }

    [Serializable]
    public class KeywordSet : PlayFabBaseModel
    {
        /// <summary>
        /// A list of localized keywords.
        /// </summary>
        public List<string> Values;
    }

    [Serializable]
    public class ModerationState : PlayFabBaseModel
    {
        /// <summary>
        /// The date and time this moderation state was last updated.
        /// </summary>
        public DateTime? LastModifiedDate;
        /// <summary>
        /// The current stated reason for the associated item being moderated.
        /// </summary>
        public string Reason;
        /// <summary>
        /// The current moderation status for the associated item.
        /// </summary>
        public ModerationStatus? Status;
    }

    public enum ModerationStatus
    {
        Unknown,
        AwaitingModeration,
        Approved,
        Rejected
    }

    [Serializable]
    public class PayoutDetails : PlayFabBaseModel
    {
    }

    /// <summary>
    /// The call kicks off a workflow to publish the item to the public catalog. The Publish Status API should be used to
    /// monitor the publish job.
    /// </summary>
    [Serializable]
    public class PublishDraftItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ETag of the catalog item to published from the working catalog to the public catalog. Used for optimistic concurrency.
        /// If the provided ETag does not match the ETag in the current working catalog, the request will be rejected. If not
        /// provided, the current version of the document in the working catalog will be published.
        /// </summary>
        public string ETag;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
    }

    [Serializable]
    public class PublishDraftItemResponse : PlayFabResultCommon
    {
    }

    public enum PublishResult
    {
        Unknown,
        Pending,
        Succeeded,
        Failed,
        Canceled
    }

    [Serializable]
    public class PurchaseInventoryItemsOperation : PlayFabBaseModel
    {
        /// <summary>
        /// The amount to purchase.
        /// </summary>
        public int? Amount;
        /// <summary>
        /// Indicates whether stacks reduced to an amount of 0 during the operation should be deleted from the inventory. (Default =
        /// false)
        /// </summary>
        public bool DeleteEmptyStacks;
        /// <summary>
        /// The duration to purchase.
        /// </summary>
        public double? DurationInSeconds;
        /// <summary>
        /// The inventory item the operation applies to.
        /// </summary>
        public InventoryItemReference Item;
        /// <summary>
        /// The values to apply to a stack newly created by this operation.
        /// </summary>
        public InitialValues NewStackValues;
        /// <summary>
        /// The per-item price the item is expected to be purchased at. This must match a value configured in the Catalog or
        /// specified Store.
        /// </summary>
        public List<PurchasePriceAmount> PriceAmounts;
        /// <summary>
        /// The id of the Store to purchase the item from.
        /// </summary>
        public string StoreId;
    }

    /// <summary>
    /// Purchase a single item or bundle, paying the associated price.
    /// </summary>
    [Serializable]
    public class PurchaseInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The amount to purchase.
        /// </summary>
        public int? Amount;
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default"). The number of inventory collections is
        /// unlimited.
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Indicates whether stacks reduced to an amount of 0 during the request should be deleted from the inventory.
        /// (Default=false)
        /// </summary>
        public bool DeleteEmptyStacks;
        /// <summary>
        /// The duration to purchase.
        /// </summary>
        public double? DurationInSeconds;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
        /// <summary>
        /// The Idempotency ID for this request. Idempotency IDs can be used to prevent operation replay in the medium term but will
        /// be garbage collected eventually.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The inventory item the request applies to.
        /// </summary>
        public InventoryItemReference Item;
        /// <summary>
        /// The values to apply to a stack newly created by this request.
        /// </summary>
        public InitialValues NewStackValues;
        /// <summary>
        /// The per-item price the item is expected to be purchased at. This must match a value configured in the Catalog or
        /// specified Store.
        /// </summary>
        public List<PurchasePriceAmount> PriceAmounts;
        /// <summary>
        /// The id of the Store to purchase the item from.
        /// </summary>
        public string StoreId;
    }

    [Serializable]
    public class PurchaseInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
        /// <summary>
        /// The idempotency id used in the request.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The ids of transactions that occurred as a result of the request.
        /// </summary>
        public List<string> TransactionIds;
    }

    [Serializable]
    public class PurchaseOverride : PlayFabBaseModel
    {
    }

    [Serializable]
    public class PurchasePriceAmount : PlayFabBaseModel
    {
        /// <summary>
        /// The amount of the inventory item to use in the purchase .
        /// </summary>
        public int Amount;
        /// <summary>
        /// The inventory item id to use in the purchase .
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The inventory stack id the to use in the purchase. Set to "default" by default
        /// </summary>
        public string StackId;
    }

    [Serializable]
    public class Rating : PlayFabBaseModel
    {
        /// <summary>
        /// The average rating for this item.
        /// </summary>
        public float? Average;
        /// <summary>
        /// The total count of 1 star ratings for this item.
        /// </summary>
        public int? Count1Star;
        /// <summary>
        /// The total count of 2 star ratings for this item.
        /// </summary>
        public int? Count2Star;
        /// <summary>
        /// The total count of 3 star ratings for this item.
        /// </summary>
        public int? Count3Star;
        /// <summary>
        /// The total count of 4 star ratings for this item.
        /// </summary>
        public int? Count4Star;
        /// <summary>
        /// The total count of 5 star ratings for this item.
        /// </summary>
        public int? Count5Star;
        /// <summary>
        /// The total count of ratings for this item.
        /// </summary>
        public int? TotalCount;
    }

    /// <summary>
    /// Redeem items from the Apple App Store.
    /// </summary>
    [Serializable]
    public class RedeemAppleAppStoreInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default")
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The receipt provided by the Apple marketplace upon successful purchase.
        /// </summary>
        public string Receipt;
    }

    [Serializable]
    public class RedeemAppleAppStoreInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of failed redemptions from the external marketplace.
        /// </summary>
        public List<RedemptionFailure> Failed;
        /// <summary>
        /// The list of successful redemptions from the external marketplace.
        /// </summary>
        public List<RedemptionSuccess> Succeeded;
        /// <summary>
        /// The Transaction IDs associated with the inventory modifications
        /// </summary>
        public List<string> TransactionIds;
    }

    /// <summary>
    /// Redeem items from the Google Play Store.
    /// </summary>
    [Serializable]
    public class RedeemGooglePlayInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default")
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The list of purchases to redeem
        /// </summary>
        public List<GooglePlayProductPurchase> Purchases;
    }

    [Serializable]
    public class RedeemGooglePlayInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of failed redemptions from the external marketplace.
        /// </summary>
        public List<RedemptionFailure> Failed;
        /// <summary>
        /// The list of successful redemptions from the external marketplace.
        /// </summary>
        public List<RedemptionSuccess> Succeeded;
        /// <summary>
        /// The Transaction IDs associated with the inventory modifications
        /// </summary>
        public List<string> TransactionIds;
    }

    /// <summary>
    /// Redeem items from the Microsoft Store.
    /// </summary>
    [Serializable]
    public class RedeemMicrosoftStoreInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default")
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The OneStore Collections Id Key used for AAD authentication.
        /// </summary>
        public string CollectionsIdKey;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Xbox Token used for delegated business partner authentication.
        /// </summary>
        public string XboxToken;
    }

    [Serializable]
    public class RedeemMicrosoftStoreInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of failed redemptions from the external marketplace.
        /// </summary>
        public List<RedemptionFailure> Failed;
        /// <summary>
        /// The list of successful redemptions from the external marketplace.
        /// </summary>
        public List<RedemptionSuccess> Succeeded;
        /// <summary>
        /// The Transaction IDs associated with the inventory modifications
        /// </summary>
        public List<string> TransactionIds;
    }

    /// <summary>
    /// Redeem items from the Nintendo EShop.
    /// </summary>
    [Serializable]
    public class RedeemNintendoEShopInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default")
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Nintendo provided token authorizing redemption
        /// </summary>
        public string NintendoServiceAccountIdToken;
    }

    [Serializable]
    public class RedeemNintendoEShopInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of failed redemptions from the external marketplace.
        /// </summary>
        public List<RedemptionFailure> Failed;
        /// <summary>
        /// The list of successful redemptions from the external marketplace.
        /// </summary>
        public List<RedemptionSuccess> Succeeded;
        /// <summary>
        /// The Transaction IDs associated with the inventory modifications
        /// </summary>
        public List<string> TransactionIds;
    }

    /// <summary>
    /// Redeem items from the PlayStation Store.
    /// </summary>
    [Serializable]
    public class RedeemPlayStationStoreInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Auth code returned by PlayStation :tm: Network OAuth system.
        /// </summary>
        public string AuthorizationCode;
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default")
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Redirect URI supplied to PlayStation :tm: Network when requesting an auth code
        /// </summary>
        public string RedirectUri;
        /// <summary>
        /// Optional Service Label to pass into the request.
        /// </summary>
        public string ServiceLabel;
    }

    [Serializable]
    public class RedeemPlayStationStoreInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of failed redemptions from the external marketplace.
        /// </summary>
        public List<RedemptionFailure> Failed;
        /// <summary>
        /// The list of successful redemptions from the external marketplace.
        /// </summary>
        public List<RedemptionSuccess> Succeeded;
        /// <summary>
        /// The Transaction IDs associated with the inventory modifications
        /// </summary>
        public List<string> TransactionIds;
    }

    /// <summary>
    /// Redeem inventory items from Steam.
    /// </summary>
    [Serializable]
    public class RedeemSteamInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default")
        /// </summary>
        public string CollectionId;
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
    public class RedeemSteamInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of failed redemptions from the external marketplace.
        /// </summary>
        public List<RedemptionFailure> Failed;
        /// <summary>
        /// The list of successful redemptions from the external marketplace.
        /// </summary>
        public List<RedemptionSuccess> Succeeded;
        /// <summary>
        /// The Transaction IDs associated with the inventory modifications
        /// </summary>
        public List<string> TransactionIds;
    }

    [Serializable]
    public class RedemptionFailure : PlayFabBaseModel
    {
        /// <summary>
        /// The marketplace failure code.
        /// </summary>
        public string FailureCode;
        /// <summary>
        /// The marketplace error details explaining why the offer failed to redeem.
        /// </summary>
        public string FailureDetails;
        /// <summary>
        /// The transaction id in the external marketplace.
        /// </summary>
        public string MarketplaceTransactionId;
        /// <summary>
        /// The ID of the offer being redeemed.
        /// </summary>
        public string OfferId;
    }

    [Serializable]
    public class RedemptionSuccess : PlayFabBaseModel
    {
        /// <summary>
        /// The transaction id in the external marketplace.
        /// </summary>
        public string MarketplaceTransactionId;
        /// <summary>
        /// The ID of the offer being redeemed.
        /// </summary>
        public string OfferId;
        /// <summary>
        /// The timestamp for when the redeem was completed.
        /// </summary>
        public DateTime SuccessTimestamp;
    }

    [Serializable]
    public class ReportItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// Category of concern for this report.
        /// </summary>
        public ConcernCategory? ConcernCategory;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
        /// <summary>
        /// The string reason for this report.
        /// </summary>
        public string Reason;
    }

    [Serializable]
    public class ReportItemResponse : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Submit a report for an inappropriate review, allowing the submitting user to specify their concern.
    /// </summary>
    [Serializable]
    public class ReportItemReviewRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID of the item associated with the review.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The reason this review is being reported.
        /// </summary>
        public ConcernCategory? ConcernCategory;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The string ID of the item associated with the review.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The string reason for this report.
        /// </summary>
        public string Reason;
        /// <summary>
        /// The ID of the review to submit a report for.
        /// </summary>
        public string ReviewId;
    }

    [Serializable]
    public class ReportItemReviewResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class Review : PlayFabBaseModel
    {
        /// <summary>
        /// The number of negative helpfulness votes for this review.
        /// </summary>
        public int HelpfulNegative;
        /// <summary>
        /// The number of positive helpfulness votes for this review.
        /// </summary>
        public int HelpfulPositive;
        /// <summary>
        /// Indicates whether the review author has the item installed.
        /// </summary>
        public bool IsInstalled;
        /// <summary>
        /// The ID of the item being reviewed.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The version of the item being reviewed.
        /// </summary>
        public string ItemVersion;
        /// <summary>
        /// The locale for which this review was submitted in.
        /// </summary>
        public string Locale;
        /// <summary>
        /// Star rating associated with this review.
        /// </summary>
        public int Rating;
        /// <summary>
        /// The ID of the author of the review.
        /// </summary>
        public EntityKey ReviewerEntity;
        /// <summary>
        /// Deprecated. Use ReviewerEntity instead. This property will be removed in a future release.
        /// </summary>
        public string ReviewerId;
        /// <summary>
        /// The ID of the review.
        /// </summary>
        public string ReviewId;
        /// <summary>
        /// The full text of this review.
        /// </summary>
        public string ReviewText;
        /// <summary>
        /// The date and time this review was last submitted.
        /// </summary>
        public DateTime Submitted;
        /// <summary>
        /// The title of this review.
        /// </summary>
        public string Title;
    }

    [Serializable]
    public class ReviewItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
        /// <summary>
        /// The review to submit.
        /// </summary>
        public Review Review;
    }

    [Serializable]
    public class ReviewItemResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ReviewTakedown : PlayFabBaseModel
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The ID of the item associated with the review to take down.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The ID of the review to take down.
        /// </summary>
        public string ReviewId;
    }

    [Serializable]
    public class ScanResult : PlayFabBaseModel
    {
        /// <summary>
        /// The URL of the item which failed the scan.
        /// </summary>
        public string Url;
    }

    [Serializable]
    public class SearchItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// Number of items to retrieve. This value is optional. Maximum page size is 50. Default value is 10.
        /// </summary>
        public int Count;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// An OData filter used to refine the search query (For example: "type eq 'ugc'"). More info about Filter Complexity limits
        /// can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/search#limits
        /// </summary>
        public string Filter;
        /// <summary>
        /// An OData orderBy used to order the results of the search query. For example: "rating/average asc"
        /// </summary>
        public string OrderBy;
        /// <summary>
        /// The text to search for.
        /// </summary>
        public string Search;
        /// <summary>
        /// An OData select query option used to augment the search results. If not defined, the default search result metadata will
        /// be returned.
        /// </summary>
        public string Select;
        /// <summary>
        /// The store to restrict the search request to.
        /// </summary>
        public StoreReference Store;
    }

    [Serializable]
    public class SearchItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// The paginated set of results for the search query.
        /// </summary>
        public List<CatalogItem> Items;
    }

    [Serializable]
    public class SetItemModerationStateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID associated with this item.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public string Id;
        /// <summary>
        /// The reason for the moderation state change for the associated item.
        /// </summary>
        public string Reason;
        /// <summary>
        /// The status to set for the associated item.
        /// </summary>
        public ModerationStatus? Status;
    }

    [Serializable]
    public class SetItemModerationStateResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class StoreDetails : PlayFabBaseModel
    {
        /// <summary>
        /// The options for the filter in filter-based stores. These options are mutually exclusive with item references.
        /// </summary>
        public FilterOptions FilterOptions;
        /// <summary>
        /// The global prices utilized in the store. These options are mutually exclusive with price options in item references.
        /// </summary>
        public CatalogPriceOptionsOverride PriceOptionsOverride;
    }

    [Serializable]
    public class StoreReference : PlayFabBaseModel
    {
        /// <summary>
        /// An alternate ID of the store.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The unique ID of the store.
        /// </summary>
        public string Id;
    }

    [Serializable]
    public class SubmitItemReviewVoteRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An alternate ID of the item associated with the review.
        /// </summary>
        public CatalogAlternateId AlternateId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The string ID of the item associated with the review.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The ID of the review to submit a helpfulness vote for.
        /// </summary>
        public string ReviewId;
        /// <summary>
        /// The helpfulness vote of the review.
        /// </summary>
        public HelpfulnessVote? Vote;
    }

    [Serializable]
    public class SubmitItemReviewVoteResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class SubscriptionDetails : PlayFabBaseModel
    {
        /// <summary>
        /// The length of time that the subscription will last in seconds.
        /// </summary>
        public double DurationInSeconds;
    }

    [Serializable]
    public class SubtractInventoryItemsOperation : PlayFabBaseModel
    {
        /// <summary>
        /// The amount to subtract from the current item amount.
        /// </summary>
        public int? Amount;
        /// <summary>
        /// Indicates whether stacks reduced to an amount of 0 during the request should be deleted from the inventory. (Default =
        /// false).
        /// </summary>
        public bool DeleteEmptyStacks;
        /// <summary>
        /// The duration to subtract from the current item expiration date.
        /// </summary>
        public double? DurationInSeconds;
        /// <summary>
        /// The inventory item the operation applies to.
        /// </summary>
        public InventoryItemReference Item;
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will subtract the specified inventory items.
    /// </summary>
    [Serializable]
    public class SubtractInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The amount to subtract for the current item.
        /// </summary>
        public int? Amount;
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default"). The number of inventory collections is
        /// unlimited.
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Indicates whether stacks reduced to an amount of 0 during the request should be deleted from the inventory.
        /// (Default=false)
        /// </summary>
        public bool DeleteEmptyStacks;
        /// <summary>
        /// The duration to subtract from the current item expiration date.
        /// </summary>
        public double? DurationInSeconds;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
        /// <summary>
        /// The Idempotency ID for this request. Idempotency IDs can be used to prevent operation replay in the medium term but will
        /// be garbage collected eventually.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The inventory item the request applies to.
        /// </summary>
        public InventoryItemReference Item;
    }

    [Serializable]
    public class SubtractInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
        /// <summary>
        /// The idempotency id used in the request.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The ids of transactions that occurred as a result of the request.
        /// </summary>
        public List<string> TransactionIds;
    }

    /// <summary>
    /// Submit a request to takedown one or more reviews, removing them from public view. Authors will still be able to see
    /// their reviews after being taken down.
    /// </summary>
    [Serializable]
    public class TakedownItemReviewsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The set of reviews to take down.
        /// </summary>
        public List<ReviewTakedown> Reviews;
    }

    [Serializable]
    public class TakedownItemReviewsResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class Transaction : PlayFabBaseModel
    {
        /// <summary>
        /// The API call that caused this transaction.
        /// </summary>
        public string ApiName;
        /// <summary>
        /// The type of item that the the operation occurred on.
        /// </summary>
        public string ItemType;
        /// <summary>
        /// The operations that occurred.
        /// </summary>
        public List<TransactionOperation> Operations;
        /// <summary>
        /// The type of operation that was run.
        /// </summary>
        public string OperationType;
        /// <summary>
        /// Additional details about the transaction. Null if it was not a purchase operation.
        /// </summary>
        public TransactionPurchaseDetails PurchaseDetails;
        /// <summary>
        /// Additional details about the transaction. Null if it was not a redeem operation.
        /// </summary>
        public TransactionRedeemDetails RedeemDetails;
        /// <summary>
        /// The time this transaction occurred in UTC.
        /// </summary>
        public DateTime Timestamp;
        /// <summary>
        /// The id of the transaction. This should be treated like an opaque token.
        /// </summary>
        public string TransactionId;
        /// <summary>
        /// Additional details about the transaction. Null if it was not a transfer operation.
        /// </summary>
        public TransactionTransferDetails TransferDetails;
    }

    [Serializable]
    public class TransactionOperation : PlayFabBaseModel
    {
        /// <summary>
        /// The amount of items in this transaction.
        /// </summary>
        public int? Amount;
        /// <summary>
        /// The duration modified in this transaction.
        /// </summary>
        public double? DurationInSeconds;
        /// <summary>
        /// The item id of the items in this transaction.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The type of item that the operation occurred on.
        /// </summary>
        public string ItemType;
        /// <summary>
        /// The stack id of the items in this transaction.
        /// </summary>
        public string StackId;
        /// <summary>
        /// The type of the operation that occurred.
        /// </summary>
        public string Type;
    }

    [Serializable]
    public class TransactionPurchaseDetails : PlayFabBaseModel
    {
        /// <summary>
        /// The id of the Store the item was purchased from or null.
        /// </summary>
        public string StoreId;
    }

    [Serializable]
    public class TransactionRedeemDetails : PlayFabBaseModel
    {
        /// <summary>
        /// The marketplace that the offer is being redeemed from.
        /// </summary>
        public string Marketplace;
        /// <summary>
        /// The transaction Id returned from the marketplace.
        /// </summary>
        public string MarketplaceTransactionId;
        /// <summary>
        /// The offer Id of the item being redeemed.
        /// </summary>
        public string OfferId;
    }

    [Serializable]
    public class TransactionTransferDetails : PlayFabBaseModel
    {
        /// <summary>
        /// The collection id the items were transferred from or null if it was the current collection.
        /// </summary>
        public string GivingCollectionId;
        /// <summary>
        /// The entity the items were transferred from or null if it was the current entity.
        /// </summary>
        public EntityKey GivingEntity;
        /// <summary>
        /// The collection id the items were transferred to or null if it was the current collection.
        /// </summary>
        public string ReceivingCollectionId;
        /// <summary>
        /// The entity the items were transferred to or null if it was the current entity.
        /// </summary>
        public EntityKey ReceivingEntity;
        /// <summary>
        /// The id of the transfer that occurred.
        /// </summary>
        public string TransferId;
    }

    [Serializable]
    public class TransferInventoryItemsOperation : PlayFabBaseModel
    {
        /// <summary>
        /// The amount to transfer.
        /// </summary>
        public int? Amount;
        /// <summary>
        /// Indicates whether stacks reduced to an amount of 0 during the operation should be deleted from the inventory. (Default =
        /// false)
        /// </summary>
        public bool DeleteEmptyStacks;
        /// <summary>
        /// The inventory item the operation is transferring from.
        /// </summary>
        public InventoryItemReference GivingItem;
        /// <summary>
        /// The values to apply to a stack newly created by this operation.
        /// </summary>
        public InitialValues NewStackValues;
        /// <summary>
        /// The inventory item the operation is transferring to.
        /// </summary>
        public InventoryItemReference ReceivingItem;
    }

    /// <summary>
    /// Transfer the specified inventory items of an entity's container Id to another entity's container Id.
    /// </summary>
    [Serializable]
    public class TransferInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The amount to transfer .
        /// </summary>
        public int? Amount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Indicates whether stacks reduced to an amount of 0 during the request should be deleted from the inventory. (Default =
        /// false)
        /// </summary>
        public bool DeleteEmptyStacks;
        /// <summary>
        /// The inventory collection id the request is transferring from. (Default="default")
        /// </summary>
        public string GivingCollectionId;
        /// <summary>
        /// The entity the request is transferring from. Set to the caller by default.
        /// </summary>
        public EntityKey GivingEntity;
        /// <summary>
        /// ETags are used for concurrency checking when updating resources (before transferring from). More information about using
        /// ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string GivingETag;
        /// <summary>
        /// The inventory item the request is transferring from.
        /// </summary>
        public InventoryItemReference GivingItem;
        /// <summary>
        /// The idempotency id for the request.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The values to apply to a stack newly created by this request.
        /// </summary>
        public InitialValues NewStackValues;
        /// <summary>
        /// The inventory collection id the request is transferring to. (Default="default")
        /// </summary>
        public string ReceivingCollectionId;
        /// <summary>
        /// The entity the request is transferring to. Set to the caller by default.
        /// </summary>
        public EntityKey ReceivingEntity;
        /// <summary>
        /// The inventory item the request is transferring to.
        /// </summary>
        public InventoryItemReference ReceivingItem;
    }

    [Serializable]
    public class TransferInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// ETags are used for concurrency checking when updating resources (after transferring from). More information about using
        /// ETags can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string GivingETag;
        /// <summary>
        /// The ids of transactions that occurred as a result of the request's giving action.
        /// </summary>
        public List<string> GivingTransactionIds;
        /// <summary>
        /// The idempotency id for the request.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The ids of transactions that occurred as a result of the request's receiving action.
        /// </summary>
        public List<string> ReceivingTransactionIds;
    }

    [Serializable]
    public class UpdateCatalogConfigRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The updated catalog configuration.
        /// </summary>
        public CatalogConfig Config;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UpdateCatalogConfigResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UpdateDraftItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Updated metadata describing the catalog item to be updated.
        /// </summary>
        public CatalogItem Item;
        /// <summary>
        /// Whether the item should be published immediately. This value is optional, defaults to false.
        /// </summary>
        public bool Publish;
    }

    [Serializable]
    public class UpdateDraftItemResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Updated metadata describing the catalog item just updated.
        /// </summary>
        public CatalogItem Item;
    }

    [Serializable]
    public class UpdateInventoryItemsOperation : PlayFabBaseModel
    {
        /// <summary>
        /// The inventory item to update with the specified values.
        /// </summary>
        public InventoryItem Item;
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will update the entity's inventory items
    /// </summary>
    [Serializable]
    public class UpdateInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The id of the entity's collection to perform this action on. (Default="default"). The number of inventory collections is
        /// unlimited.
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
        /// <summary>
        /// The Idempotency ID for this request. Idempotency IDs can be used to prevent operation replay in the medium term but will
        /// be garbage collected eventually.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The inventory item to update with the specified values.
        /// </summary>
        public InventoryItem Item;
    }

    [Serializable]
    public class UpdateInventoryItemsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// ETags are used for concurrency checking when updating resources. More information about using ETags can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/etags
        /// </summary>
        public string ETag;
        /// <summary>
        /// The idempotency id used in the request.
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The ids of transactions that occurred as a result of the request.
        /// </summary>
        public List<string> TransactionIds;
    }

    [Serializable]
    public class UploadInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Name of the file to be uploaded.
        /// </summary>
        public string FileName;
    }

    [Serializable]
    public class UploadUrlMetadata : PlayFabBaseModel
    {
        /// <summary>
        /// Name of the file for which this upload URL was requested.
        /// </summary>
        public string FileName;
        /// <summary>
        /// Unique ID for the binary content to be uploaded to the target URL.
        /// </summary>
        public string Id;
        /// <summary>
        /// URL for the binary content to be uploaded to.
        /// </summary>
        public string Url;
    }

    [Serializable]
    public class UserGeneratedContentSpecificConfig : PlayFabBaseModel
    {
        /// <summary>
        /// The set of content types that will be used for validation.
        /// </summary>
        public List<string> ContentTypes;
        /// <summary>
        /// The set of tags that will be used for validation.
        /// </summary>
        public List<string> Tags;
    }
}
#endif
