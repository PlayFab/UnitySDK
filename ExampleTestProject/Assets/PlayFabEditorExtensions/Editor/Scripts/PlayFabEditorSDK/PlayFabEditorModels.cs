using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFab.PfEditor.EditorModels
{
    public class RegisterAccountRequest
    {
        public string Email;
        public string Password;
        public string StudioName;
        public string DeveloperToolProductName;
        public string DeveloperToolProductVersion;
    }

    public class RegisterAccountResult
    {
        public string DeveloperClientToken;
    }

    public class LoginRequest
    {
        public string Email;
        public string Password;
        public string TwoFactorAuth;
        public string DeveloperToolProductName;
        public string DeveloperToolProductVersion;
    }

    public class LoginWithAADRequest
    {
        public string DeveloperToolProductName;
        public string DeveloperToolProductVersion;
    }

    public class LoginResult
    {
        public string DeveloperClientToken;
    }

    public class LogoutRequest
    {
        public string DeveloperClientToken;
    }

    public class LogoutResult
    {
    }

    public class GetStudiosRequest
    {
        public string DeveloperClientToken;
    }

    public class GetStudiosResult
    {
        public Studio[] Studios;
    }

    public class CreateTitleRequest
    {
        public string DeveloperClientToken;
        public string Name;
        public string StudioId;
    }

    public class CreateTitleResult
    {
        public Title Title;
    }

    public class Title
    {
        public string Id;
        public string Name;
        public string SecretKey;
        public string GameManagerUrl;
    }

    public class Studio
    {
        public static Studio OVERRIDE = new Studio { Id = "", Name = PlayFabEditorHelper.STUDIO_OVERRIDE, Titles = null };

        public string Id;
        public string Name;

        public Title[] Titles;

        public Title GetTitle(string titleId)
        {
            if (Titles == null)
                return null;
            for (var i = 0; i < Titles.Length; i++)
                if (Titles[i].Id == titleId)
                    return Titles[i];
            return null;
        }

        public string GetTitleSecretKey(string titleId)
        {
            var title = GetTitle(titleId);
            return title == null ? "" : title.SecretKey;
        }
    }

    public class GetTitleDataRequest
    {
        public List<string> Keys;
    }

    public class GetTitleDataResult
    {
        public Dictionary<string, string> Data;
    }

    public class SetTitleDataRequest
    {
        public string Key;
        public string Value;
    }

    public class SetTitleDataResult
    {
    }

    public class CloudScriptFile
    {
        public string Filename;
        public string FileContents;
    }

    public class UpdateCloudScriptRequest
    {
        public List<CloudScriptFile> Files;
        public bool Publish;
        public string DeveloperPlayFabId;
    }

    public class UpdateCloudScriptResult
    {
        public int Version;
        public int Revision;
    }

    public class GetCloudScriptRevisionRequest
    {
        public int? Version;
        public int? Revision;
    }

    public class GetCloudScriptRevisionResult
    {
        public int Version;
        public int Revision;
        public System.DateTime CreatedAt;
        public List<CloudScriptFile> Files;
        public bool IsPublished;
    }

    public class PlayFabError
    {
        public int HttpCode;
        public string HttpStatus;
        public PlayFabErrorCode Error;
        public string ErrorMessage;
        public Dictionary<string, List<string>> ErrorDetails;
        public object CustomData;
        public uint? RetryAfterSeconds = null;

        [ThreadStatic]
        private static StringBuilder _tempSb;
        public string GenerateErrorReport()
        {
            if (_tempSb == null)
                _tempSb = new StringBuilder();
            _tempSb.Length = 0;
            _tempSb.Append(ErrorMessage);
            if (ErrorDetails != null)
                foreach (var pair in ErrorDetails)
                    foreach (var msg in pair.Value)
                        _tempSb.Append("\n").Append(pair.Key).Append(": ").Append(msg);
            return _tempSb.ToString();
        }
    }

    public class HttpResponseObject
    {
        public int code;
        public string status;
        public object data;
    }

    public enum PlayFabErrorCode
    {
        Unknown = 1,
        Success = 0,
        InvalidParams = 1000,
        AccountNotFound = 1001,
        AccountBanned = 1002,
        InvalidUsernameOrPassword = 1003,
        InvalidTitleId = 1004,
        InvalidEmailAddress = 1005,
        EmailAddressNotAvailable = 1006,
        InvalidUsername = 1007,
        InvalidPassword = 1008,
        UsernameNotAvailable = 1009,
        InvalidSteamTicket = 1010,
        AccountAlreadyLinked = 1011,
        LinkedAccountAlreadyClaimed = 1012,
        InvalidFacebookToken = 1013,
        AccountNotLinked = 1014,
        FailedByPaymentProvider = 1015,
        CouponCodeNotFound = 1016,
        InvalidContainerItem = 1017,
        ContainerNotOwned = 1018,
        KeyNotOwned = 1019,
        InvalidItemIdInTable = 1020,
        InvalidReceipt = 1021,
        ReceiptAlreadyUsed = 1022,
        ReceiptCancelled = 1023,
        GameNotFound = 1024,
        GameModeNotFound = 1025,
        InvalidGoogleToken = 1026,
        UserIsNotPartOfDeveloper = 1027,
        InvalidTitleForDeveloper = 1028,
        TitleNameConflicts = 1029,
        UserisNotValid = 1030,
        ValueAlreadyExists = 1031,
        BuildNotFound = 1032,
        PlayerNotInGame = 1033,
        InvalidTicket = 1034,
        InvalidDeveloper = 1035,
        InvalidOrderInfo = 1036,
        RegistrationIncomplete = 1037,
        InvalidPlatform = 1038,
        UnknownError = 1039,
        SteamApplicationNotOwned = 1040,
        WrongSteamAccount = 1041,
        TitleNotActivated = 1042,
        RegistrationSessionNotFound = 1043,
        NoSuchMod = 1044,
        FileNotFound = 1045,
        DuplicateEmail = 1046,
        ItemNotFound = 1047,
        ItemNotOwned = 1048,
        ItemNotRecycleable = 1049,
        ItemNotAffordable = 1050,
        InvalidVirtualCurrency = 1051,
        WrongVirtualCurrency = 1052,
        WrongPrice = 1053,
        NonPositiveValue = 1054,
        InvalidRegion = 1055,
        RegionAtCapacity = 1056,
        ServerFailedToStart = 1057,
        NameNotAvailable = 1058,
        InsufficientFunds = 1059,
        InvalidDeviceID = 1060,
        InvalidPushNotificationToken = 1061,
        NoRemainingUses = 1062,
        InvalidPaymentProvider = 1063,
        PurchaseInitializationFailure = 1064,
        DuplicateUsername = 1065,
        InvalidBuyerInfo = 1066,
        NoGameModeParamsSet = 1067,
        BodyTooLarge = 1068,
        ReservedWordInBody = 1069,
        InvalidTypeInBody = 1070,
        InvalidRequest = 1071,
        ReservedEventName = 1072,
        InvalidUserStatistics = 1073,
        NotAuthenticated = 1074,
        StreamAlreadyExists = 1075,
        ErrorCreatingStream = 1076,
        StreamNotFound = 1077,
        InvalidAccount = 1078,
        PurchaseDoesNotExist = 1080,
        InvalidPurchaseTransactionStatus = 1081,
        APINotEnabledForGameClientAccess = 1082,
        NoPushNotificationARNForTitle = 1083,
        BuildAlreadyExists = 1084,
        BuildPackageDoesNotExist = 1085,
        CustomAnalyticsEventsNotEnabledForTitle = 1087,
        InvalidSharedGroupId = 1088,
        NotAuthorized = 1089,
        MissingTitleGoogleProperties = 1090,
        InvalidItemProperties = 1091,
        InvalidPSNAuthCode = 1092,
        InvalidItemId = 1093,
        PushNotEnabledForAccount = 1094,
        PushServiceError = 1095,
        ReceiptDoesNotContainInAppItems = 1096,
        ReceiptContainsMultipleInAppItems = 1097,
        InvalidBundleID = 1098,
        JavascriptException = 1099,
        InvalidSessionTicket = 1100,
        UnableToConnectToDatabase = 1101,
        InternalServerError = 1110,
        InvalidReportDate = 1111,
        ReportNotAvailable = 1112,
        DatabaseThroughputExceeded = 1113,
        InvalidLobbyId = 1114,
        InvalidGameTicket = 1115,
        ExpiredGameTicket = 1116,
        GameTicketDoesNotMatchLobby = 1117,
        LinkedDeviceAlreadyClaimed = 1118,
        DeviceAlreadyLinked = 1119,
        DeviceNotLinked = 1120,
        PartialFailure = 1121,
        PublisherNotSet = 1122,
        ServiceUnavailable = 1123,
        VersionNotFound = 1124,
        RevisionNotFound = 1125,
        InvalidPublisherId = 1126,
        DownstreamServiceUnavailable = 1127,
        APINotIncludedInTitleUsageTier = 1128,
        DAULimitExceeded = 1129,
        APIRequestLimitExceeded = 1130,
        InvalidAPIEndpoint = 1131,
        BuildNotAvailable = 1132,
        ConcurrentEditError = 1133,
        ContentNotFound = 1134,
        CharacterNotFound = 1135,
        CloudScriptNotFound = 1136,
        ContentQuotaExceeded = 1137,
        InvalidCharacterStatistics = 1138,
        PhotonNotEnabledForTitle = 1139,
        PhotonApplicationNotFound = 1140,
        PhotonApplicationNotAssociatedWithTitle = 1141,
        InvalidEmailOrPassword = 1142,
        FacebookAPIError = 1143,
        InvalidContentType = 1144,
        KeyLengthExceeded = 1145,
        DataLengthExceeded = 1146,
        TooManyKeys = 1147,
        FreeTierCannotHaveVirtualCurrency = 1148,
        MissingAmazonSharedKey = 1149,
        AmazonValidationError = 1150,
        InvalidPSNIssuerId = 1151,
        PSNInaccessible = 1152,
        ExpiredAuthToken = 1153,
        FailedToGetEntitlements = 1154,
        FailedToConsumeEntitlement = 1155,
        TradeAcceptingUserNotAllowed = 1156,
        TradeInventoryItemIsAssignedToCharacter = 1157,
        TradeInventoryItemIsBundle = 1158,
        TradeStatusNotValidForCancelling = 1159,
        TradeStatusNotValidForAccepting = 1160,
        TradeDoesNotExist = 1161,
        TradeCancelled = 1162,
        TradeAlreadyFilled = 1163,
        TradeWaitForStatusTimeout = 1164,
        TradeInventoryItemExpired = 1165,
        TradeMissingOfferedAndAcceptedItems = 1166,
        TradeAcceptedItemIsBundle = 1167,
        TradeAcceptedItemIsStackable = 1168,
        TradeInventoryItemInvalidStatus = 1169,
        TradeAcceptedCatalogItemInvalid = 1170,
        TradeAllowedUsersInvalid = 1171,
        TradeInventoryItemDoesNotExist = 1172,
        TradeInventoryItemIsConsumed = 1173,
        TradeInventoryItemIsStackable = 1174,
        TradeAcceptedItemsMismatch = 1175,
        InvalidKongregateToken = 1176,
        FeatureNotConfiguredForTitle = 1177,
        NoMatchingCatalogItemForReceipt = 1178,
        InvalidCurrencyCode = 1179,
        NoRealMoneyPriceForCatalogItem = 1180,
        TradeInventoryItemIsNotTradable = 1181,
        TradeAcceptedCatalogItemIsNotTradable = 1182,
        UsersAlreadyFriends = 1183,
        LinkedIdentifierAlreadyClaimed = 1184,
        CustomIdNotLinked = 1185,
        TotalDataSizeExceeded = 1186,
        DeleteKeyConflict = 1187,
        InvalidXboxLiveToken = 1188,
        ExpiredXboxLiveToken = 1189,
        ResettableStatisticVersionRequired = 1190,
        NotAuthorizedByTitle = 1191,
        NoPartnerEnabled = 1192,
        InvalidPartnerResponse = 1193,
        APINotEnabledForGameServerAccess = 1194,
        StatisticNotFound = 1195,
        StatisticNameConflict = 1196,
        StatisticVersionClosedForWrites = 1197,
        StatisticVersionInvalid = 1198,
        APIClientRequestRateLimitExceeded = 1199,
        InvalidJSONContent = 1200,
        InvalidDropTable = 1201,
        StatisticVersionAlreadyIncrementedForScheduledInterval = 1202,
        StatisticCountLimitExceeded = 1203,
        StatisticVersionIncrementRateExceeded = 1204,
        ContainerKeyInvalid = 1205,
        CloudScriptExecutionTimeLimitExceeded = 1206,
        NoWritePermissionsForEvent = 1207,
        CloudScriptFunctionArgumentSizeExceeded = 1208,
        CloudScriptAPIRequestCountExceeded = 1209,
        CloudScriptAPIRequestError = 1210,
        CloudScriptHTTPRequestError = 1211,
        InsufficientGuildRole = 1212,
        GuildNotFound = 1213,
        OverLimit = 1214,
        EventNotFound = 1215,
        InvalidEventField = 1216,
        InvalidEventName = 1217,
        CatalogNotConfigured = 1218,
        OperationNotSupportedForPlatform = 1219,
        SegmentNotFound = 1220,
        StoreNotFound = 1221,
        InvalidStatisticName = 1222,
        TitleNotQualifiedForLimit = 1223,
        InvalidServiceLimitLevel = 1224,
        ServiceLimitLevelInTransition = 1225,
        CouponAlreadyRedeemed = 1226,
        GameServerBuildSizeLimitExceeded = 1227,
        GameServerBuildCountLimitExceeded = 1228,
        VirtualCurrencyCountLimitExceeded = 1229,
        VirtualCurrencyCodeExists = 1230,
        TitleNewsItemCountLimitExceeded = 1231,
        InvalidTwitchToken = 1232,
        TwitchResponseError = 1233,
        ProfaneDisplayName = 1234,
        TwoFactorAuthenticationTokenRequired = 1246
    }

    #region Misc UI Models
    public class StudioDisplaySet
    {
        public PlayFab.PfEditor.EditorModels.Studio Studio;
        public bool isCollapsed = true;
        public Dictionary<string, TitleDisplaySet> titleFoldOutStates = new Dictionary<string, TitleDisplaySet>();
    }

    public class TitleDisplaySet
    {
        public PlayFab.PfEditor.EditorModels.Title Title;
        public bool isCollapsed = true;
    }

    public class KvpItem
    {
        public string Key;
        public string Value;
        public string _prvKey;
        public string _prvValue;
        public bool isDirty;

        public KvpItem(string k, string v)
        {
            Key = k;
            Value = v;

            _prvKey = k;
            _prvValue = v;
        }

        public void CleanItem()
        {
            _prvKey = Key;
            _prvValue = Value;
            isDirty = false;
        }

        public void DataEditedCheck()
        {
            if (Key != _prvKey || Value != _prvValue)
                isDirty = true;
        }
    }
    #endregion
}
