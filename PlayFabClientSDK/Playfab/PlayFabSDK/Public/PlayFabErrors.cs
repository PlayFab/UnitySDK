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
		BuildNotFound = 1027,
		PlayerNotInGame = 1028,
		InvalidTicket = 1029,
		InvalidOrderInfo = 1030,
		RegistrationIncomplete = 1031,
		InvalidPlatform = 1032,
		SteamApplicationNotOwned = 1033,
		WrongSteamAccount = 1034,
		TitleNotActivated = 1035,
		RegistrationSessionNotFound = 1036,
		NoSuchMod = 1037,
		FileNotFound = 1038,
		DuplicateEmail = 1039,
		ItemNotFound = 1040,
		ItemNotOwned = 1041,
		ItemNotRecycleable = 1042,
		ItemNotAffordable = 1043,
		InvalidVirtualCurrency = 1044,
		WrongVirtualCurrency = 1045,
		WrongPrice = 1046,
		NonPositiveValue = 1047,
		InvalidRegion = 1048,
		RegionAtCapacity = 1049,
		ServerFailedToStart = 1050,
		NameNotAvailable = 1051,
		InsufficientFunds = 1052,
		InvalidDeviceID = 1053,
		InvalidPushNotificationToken = 1054,
		NoRemainingUses = 1055,
		InvalidPaymentProvider = 1056,
		PurchaseInitializationFailure = 1057,
		DuplicateUsername = 1058,
		InvalidBuyerInfo = 1059,
		NoGameModeParamsSet = 1060
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