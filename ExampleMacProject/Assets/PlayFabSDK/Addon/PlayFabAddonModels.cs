#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.AddonModels
{
    [Serializable]
    public class CreateOrUpdateAppleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// iOS App Bundle ID obtained after setting up your app in the App Store.
        /// </summary>
        public string AppBundleId;
        /// <summary>
        /// iOS App Shared Secret obtained after setting up your app in the App Store.
        /// </summary>
        public string AppSharedSecret;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists;
        /// <summary>
        /// Ignore expiration date for identity tokens. Be aware that when set to true this can invalidate expired tokens in the
        /// case where Apple rotates their signing keys.
        /// </summary>
        public bool? IgnoreExpirationDate;
        /// <summary>
        /// Require secure authentication only for this app.
        /// </summary>
        public bool? RequireSecureAuthentication;
    }

    [Serializable]
    public class CreateOrUpdateAppleResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class CreateOrUpdateFacebookInstantGamesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Facebook App ID obtained after setting up your app in Facebook Instant Games.
        /// </summary>
        public string AppID;
        /// <summary>
        /// Facebook App Secret obtained after setting up your app in Facebook Instant Games.
        /// </summary>
        public string AppSecret;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists;
    }

    [Serializable]
    public class CreateOrUpdateFacebookInstantGamesResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class CreateOrUpdateFacebookRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Facebook App ID obtained after setting up your app in Facebook.
        /// </summary>
        public string AppID;
        /// <summary>
        /// Facebook App Secret obtained after setting up your app in Facebook.
        /// </summary>
        public string AppSecret;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists;
        /// <summary>
        /// Email address for purchase dispute notifications.
        /// </summary>
        public string NotificationEmail;
    }

    [Serializable]
    public class CreateOrUpdateFacebookResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class CreateOrUpdateGoogleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Google App License Key obtained after setting up your app in the Google Play developer portal. Required if using Google
        /// receipt validation.
        /// </summary>
        public string AppLicenseKey;
        /// <summary>
        /// Google App Package ID obtained after setting up your app in the Google Play developer portal. Required if using Google
        /// receipt validation.
        /// </summary>
        public string AppPackageID;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists;
        /// <summary>
        /// Google OAuth Client ID obtained through the Google Developer Console by creating a new set of "OAuth Client ID".
        /// Required if using Google Authentication.
        /// </summary>
        public string OAuthClientID;
        /// <summary>
        /// Google OAuth Client Secret obtained through the Google Developer Console by creating a new set of "OAuth Client ID".
        /// Required if using Google Authentication.
        /// </summary>
        public string OAuthClientSecret;
        /// <summary>
        /// Authorized Redirect Uri obtained through the Google Developer Console. This currently defaults to
        /// https://oauth.playfab.com/oauth2/google. If you are authenticating players via browser, please update this to your own
        /// domain.
        /// </summary>
        public string OAuthCustomRedirectUri;
        /// <summary>
        /// Needed to enable pending purchase handling and subscription processing.
        /// </summary>
        public string ServiceAccountKey;
    }

    [Serializable]
    public class CreateOrUpdateGoogleResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class CreateOrUpdateKongregateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists;
        /// <summary>
        /// Kongregate Secret API Key obtained after setting up your game in your Kongregate developer account.
        /// </summary>
        public string SecretAPIKey;
    }

    [Serializable]
    public class CreateOrUpdateKongregateResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class CreateOrUpdateNintendoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Nintendo Switch Application ID, without the "0x" prefix.
        /// </summary>
        public string ApplicationID;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// List of Nintendo Environments, currently supporting up to 4. Needs Catalog enabled.
        /// </summary>
        public List<NintendoEnvironment> Environments;
        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists;
    }

    [Serializable]
    public class CreateOrUpdateNintendoResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class CreateOrUpdatePSNRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Client ID obtained after setting up your game with Sony. This one is associated with the existing PS4 marketplace.
        /// </summary>
        public string ClientID;
        /// <summary>
        /// Client secret obtained after setting up your game with Sony. This one is associated with the existing PS4 marketplace.
        /// </summary>
        public string ClientSecret;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists;
        /// <summary>
        /// Client ID obtained after setting up your game with Sony. This one is associated with the modern marketplace, which
        /// includes PS5, cross-generation for PS4, and unified entitlements.
        /// </summary>
        public string NextGenClientID;
        /// <summary>
        /// Client secret obtained after setting up your game with Sony. This one is associated with the modern marketplace, which
        /// includes PS5, cross-generation for PS4, and unified entitlements.
        /// </summary>
        public string NextGenClientSecret;
    }

    [Serializable]
    public class CreateOrUpdatePSNResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class CreateOrUpdateSteamRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Application ID obtained after setting up your app in Valve's developer portal.
        /// </summary>
        public string ApplicationId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Enforce usage of AzurePlayFab identity in user authentication tickets.
        /// </summary>
        public bool? EnforceServiceSpecificTickets;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists;
        /// <summary>
        /// Sercet Key obtained after setting up your app in Valve's developer portal.
        /// </summary>
        public string SecretKey;
        /// <summary>
        /// Use Steam Payments sandbox endpoint for test transactions.
        /// </summary>
        public bool? UseSandbox;
    }

    [Serializable]
    public class CreateOrUpdateSteamResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class CreateOrUpdateTwitchRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Client ID obtained after creating your Twitch developer account.
        /// </summary>
        public string ClientID;
        /// <summary>
        /// Client Secret obtained after creating your Twitch developer account.
        /// </summary>
        public string ClientSecret;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// If an error should be returned if the addon already exists.
        /// </summary>
        public bool? ErrorIfExists;
    }

    [Serializable]
    public class CreateOrUpdateTwitchResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteAppleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class DeleteAppleResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteFacebookInstantGamesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class DeleteFacebookInstantGamesResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteFacebookRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class DeleteFacebookResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteGoogleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class DeleteGoogleResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteKongregateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class DeleteKongregateResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteNintendoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class DeleteNintendoResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeletePSNRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class DeletePSNResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteSteamRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class DeleteSteamResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteTwitchRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class DeleteTwitchResponse : PlayFabResultCommon
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
    public class GetAppleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetAppleResponse : PlayFabResultCommon
    {
        /// <summary>
        /// iOS App Bundle ID obtained after setting up your app in the App Store.
        /// </summary>
        public string AppBundleId;
        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created;
        /// <summary>
        /// Ignore expiration date for identity tokens.
        /// </summary>
        public bool? IgnoreExpirationDate;
        /// <summary>
        /// Require secure authentication only for this app.
        /// </summary>
        public bool? RequireSecureAuthentication;
    }

    [Serializable]
    public class GetFacebookInstantGamesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetFacebookInstantGamesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Facebook App ID obtained after setting up your app in Facebook Instant Games.
        /// </summary>
        public string AppID;
        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created;
    }

    [Serializable]
    public class GetFacebookRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetFacebookResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Facebook App ID obtained after setting up your app in Facebook.
        /// </summary>
        public string AppID;
        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created;
        /// <summary>
        /// Email address for purchase dispute notifications.
        /// </summary>
        public string NotificationEmail;
    }

    [Serializable]
    public class GetGoogleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetGoogleResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Google App Package ID obtained after setting up your app in the Google Play developer portal. Required if using Google
        /// receipt validation.
        /// </summary>
        public string AppPackageID;
        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created;
        /// <summary>
        /// Google OAuth Client ID obtained through the Google Developer Console by creating a new set of "OAuth Client ID".
        /// Required if using Google Authentication.
        /// </summary>
        public string OAuthClientID;
        /// <summary>
        /// Authorized Redirect Uri obtained through the Google Developer Console. This currently defaults to
        /// https://oauth.playfab.com/oauth2/google. If you are authenticating players via browser, please update this to your own
        /// domain.
        /// </summary>
        public string OauthCustomRedirectUri;
    }

    [Serializable]
    public class GetKongregateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetKongregateResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created;
    }

    [Serializable]
    public class GetNintendoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetNintendoResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Nintendo Switch Application ID, without the "0x" prefix.
        /// </summary>
        public string ApplicationID;
        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created;
        /// <summary>
        /// List of Nintendo Environments, currently supporting up to 4.
        /// </summary>
        public List<NintendoEnvironment> Environments;
    }

    [Serializable]
    public class GetPSNRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetPSNResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Client ID obtained after setting up your game with Sony. This one is associated with the existing PS4 marketplace.
        /// </summary>
        public string ClientID;
        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created;
        /// <summary>
        /// Client ID obtained after setting up your game with Sony. This one is associated with the modern marketplace, which
        /// includes PS5, cross-generation for PS4, and unified entitlements.
        /// </summary>
        public string NextGenClientID;
    }

    [Serializable]
    public class GetSteamRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetSteamResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Application ID obtained after setting up your game in Valve's developer portal.
        /// </summary>
        public string ApplicationId;
        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created;
        /// <summary>
        /// Enforce usage of AzurePlayFab identity in user authentication tickets.
        /// </summary>
        public bool? EnforceServiceSpecificTickets;
        /// <summary>
        /// Use Steam Payments sandbox endpoint for test transactions.
        /// </summary>
        public bool? UseSandbox;
    }

    [Serializable]
    public class GetTwitchRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetTwitchResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Client ID obtained after creating your Twitch developer account.
        /// </summary>
        public string ClientID;
        /// <summary>
        /// Addon status.
        /// </summary>
        public bool Created;
    }

    [Serializable]
    public class NintendoEnvironment : PlayFabBaseModel
    {
        /// <summary>
        /// Client ID for the Nintendo Environment.
        /// </summary>
        public string ClientID;
        /// <summary>
        /// Client Secret for the Nintendo Environment.
        /// </summary>
        public string ClientSecret;
        /// <summary>
        /// ID for the Nintendo Environment.
        /// </summary>
        public string ID;
    }
}
#endif
