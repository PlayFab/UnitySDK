using System.Collections.Generic;

namespace PlayFab
{
	/// <summary>
	/// Error codes returned by PlayFabAPIs
	/// </summary>
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
		BuildNotFound = 1031,
		PlayerNotInGame = 1032,
		InvalidTicket = 1033,
		InvalidDeveloper = 1034,
		InvalidOrderInfo = 1035,
		RegistrationIncomplete = 1036,
		InvalidPlatform = 1037,
		UnknownError = 1038,
		SteamApplicationNotOwned = 1039,
		WrongSteamAccount = 1040,
		TitleNotActivated = 1041,
		RegistrationSessionNotFound = 1042,
		NoSuchMod = 1043,
		FileNotFound = 1044,
		DuplicateEmail = 1045,
		ItemNotFound = 1046,
		ItemNotOwned = 1047,
		ItemNotRecycleable = 1048,
		ItemNotAffordable = 1049,
		InvalidVirtualCurrency = 1050,
		WrongVirtualCurrency = 1051,
		WrongPrice = 1052,
		NonPositiveValue = 1053,
		InvalidRegion = 1054,
		RegionAtCapacity = 1055,
		ServerFailedToStart = 1056,
		NameNotAvailable = 1057,
		InsufficientFunds = 1058,
		InvalidDeviceID = 1059,
		InvalidPushNotificationToken = 1060,
		NoRemainingUses = 1061,
		InvalidPaymentProvider = 1062,
		PurchaseInitializationFailure = 1063,
		DuplicateUsername = 1064,
		InvalidBuyerInfo = 1065,
		NoGameModeParamsSet = 1066,
		TooLong = 1067,
		ReservedWord = 1068,
		InvalidBodyValue = 1069,
		InvalidRequest = 1070,
		ReservedEvent = 1071,
		InvalidUserStatistics = 1072
	}
	
	public class PlayFabError
    {
        public int HttpCode;
		public string HttpStatus;
		public PlayFabErrorCode Error;
		public string ErrorMessage;
		public Dictionary<string, List<string> > ErrorDetails;
    };
	
	public delegate void ErrorCallback(PlayFabError error);
	
}