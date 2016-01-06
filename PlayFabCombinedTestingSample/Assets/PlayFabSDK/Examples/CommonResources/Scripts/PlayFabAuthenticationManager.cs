using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;

namespace PlayFab
{
	public enum RegistrationLinkType
	{
		PlayFab = 0,
		Facebook = 1,
		Google = 2,
		Steam = 3,
		Kongregate = 4,
		Custom = 5,
		Ios,
		Android,
		None = -1
	}
	
	public class PlayFabAuthenticationManager : MonoBehaviour
	{
		#region Login Events
		public delegate void PlayFabDRMHandler();
		public static event PlayFabDRMHandler ConnectToSteamEvent;
		public static event PlayFabDRMHandler ConnectToKongregateEvent;
		
		public delegate void LoginViaLinkTypeHandler(RegistrationLinkType linkType);
		public static event LoginViaLinkTypeHandler LoginToPlayFabEvents;
		
		public delegate void OnLoggedInHandler(RegistrationLinkType linkType, LoginResult result);
		public static event OnLoggedInHandler OnLoggedIn;
		
		public delegate void OnLoggedInErrorHandler(RegistrationLinkType linkType, PlayFabError error);
		public static event OnLoggedInErrorHandler OnLoggedInError;
		
		#endregion
		
		public string TitleId = "FFB3";
		public string DeveloperSecretKey = ""; // You should never expose this value in your client code. 
		public WebRequestType PlayFabRequestType = WebRequestType.HttpWebRequest;

		public bool ShowDebug = false;
		public bool TestMode = true; //when test mode is true, it will spoof the custom id everytime it starts up.
		public static UserAccountInfo AccountInfo;
		
		private static string _playFabId = string.Empty;
		private static bool _isLoggedIn = false;
		private static bool _isRegistered = false;
		private static bool _isCustomDRM = false;
		private static RegistrationLinkType _linkType = RegistrationLinkType.None;
		private static string _CustomGuid = string.Empty;
		
		public static PlayFabAuthenticationManager Instance { get; private set; }
		
		void Awake()
		{
			//Singleton behaviour
			Instance = this;
			//If test mode, then create a mini guid that will append to all player prefs.
			_CustomGuid = TestMode ? Guid.NewGuid().ToString().Substring(0, 7) : string.Empty;
			
			//Don't destroy this object
			DontDestroyOnLoad(gameObject);
			
			//bind to login events.
			LoginToPlayFabEvents += HandleLoginToPlayFab;
			
		}
		void Start()
		{
			if (TitleId == null || TitleId.Equals(string.Empty))
			{
				Debug.LogError("To use playfab, you must populate your TitleId on the PlayFabAuthenticationManager GameObject.");
				return;
			}
			
			if(!string.IsNullOrEmpty(this.DeveloperSecretKey))
			{
				PlayFabSettings.DeveloperSecretKey = this.DeveloperSecretKey;
			}
			
			
			PlayFabSettings.TitleId = TitleId;
			//Check to see if the player has been registered before.
			_isRegistered = PlayerPrefs.HasKey(string.Format("{0}_PlayFabIsRegistered", _CustomGuid));
			
			if (ShowDebug) { Debug.Log(string.Format("IsRegistered: {0}", _isRegistered)); }
			
			//We delay the start of this because some frameworks load after the awake and bindings might not occur.
			StartCoroutine("StartManagerAfterASecond");
		}
		
		void OnDestory()
		{
		}
		
		IEnumerator StartManagerAfterASecond()
		{
			yield return new WaitForSeconds(1.0f);
			if (_isRegistered)
			{
				//Okay, check for a stored login.
				_linkType = !PlayerPrefs.HasKey(string.Format("{0}_PlayFabLinkType", _CustomGuid))
					? RegistrationLinkType.None
						: (RegistrationLinkType)PlayerPrefs.GetInt(string.Format("{0}_PlayFabLinkType", _CustomGuid));
				
				if (ShowDebug)
				{
					Debug.Log(string.Format("LinkType: {0}", _linkType));
				}
			}
			
			if (_isRegistered && _linkType != RegistrationLinkType.None)
			{
				//We have already registered and Linked in some way.
				HandleLoginToPlayFab(_linkType);
			}
			else
			{
				#region platform detection(s)
				//We are not registered and are not linked.
				#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR
				Type steamType = System.Reflection.Assembly.GetExecutingAssembly().GetType("SteamManager", false);
				Type kongregateType = System.Reflection.Assembly.GetExecutingAssembly().GetType("KongregateManager", false);
				
				if (steamType != null)
				{
					if (ShowDebug)
					{
						Debug.Log("Not Registered: Establishing LinkType Steam");
					}
					_linkType = RegistrationLinkType.Steam;
					PlayerPrefs.SetInt(string.Format("{0}_PlayFabLinkType", _CustomGuid), (int)_linkType);
					if (ConnectToSteamEvent != null)
					{
						ConnectToSteamEvent();
					}
				}
				else if (kongregateType != null)
				{
					if (ShowDebug)
					{
						Debug.Log("Not Registered: Establishing LinkType Kongregate");
					}
					_linkType = RegistrationLinkType.Kongregate;
					PlayerPrefs.SetInt(string.Format("{0}_PlayFabLinkType", _CustomGuid), (int)_linkType);
					if (ConnectToKongregateEvent != null)
					{
						ConnectToKongregateEvent();
					}
				}
				else
				{
					//This will link / login via CustomID Until another Link Type has been established
					_linkType = RegistrationLinkType.Custom;
					PlayerPrefs.SetInt(string.Format("{0}_PlayFabLinkType", _CustomGuid), (int)_linkType);
					if (ShowDebug)
					{
						Debug.Log("Not Registered: Establishing LinkType Custom");
					}
					HandleLoginToPlayFab(_linkType);
				}
				#endif
				
				#if UNITY_IOS && !UNITY_EDITOR
				//This will link / login via Ios Device Id until another link type has been established
				_linkType = RegistrationLinkType.Ios;
				PlayerPrefs.SetInt(string.Format("{0}_PlayFabLinkType",_CustomGuid), (int)_linkType);
				HandleLoginToPlayFab(_linkType);
				#endif
				
				#if UNITY_ANDROID && !UNITY_EDITOR
				//This will link / login via Android Device Id until another link type has been established
				_linkType = RegistrationLinkType.Android;
				PlayerPrefs.SetInt(string.Format("{0}_PlayFabLinkType",_CustomGuid), (int)_linkType);
				HandleLoginToPlayFab(_linkType);
				#endif
				
				#if UNITY_XBOX360 || UNITY_XBOXONE && !UNITY_EDITOR
				//TODO: Will need to be modified for XBOX Live login and Integration when available.
				//This will link / login via CustomID Until another Link Type has been established
				_linkType = RegistrationLinkType.Custom;
				PlayerPrefs.SetInt(string.Format("{0}_PlayFabLinkType",_CustomGuid), (int)_linkType);
				HandleLoginToPlayFab(_linkType);
				#endif
				
				#if UNITY_PS3 || UNITY_PS4 && !UNITY_EDITOR
				//TODO: I think there is a PS network login that we can handle.
				//This will link / login via CustomID Until another Link Type has been established
				_linkType = RegistrationLinkType.Custom;
				PlayerPrefs.SetInt(string.Format("{0}_PlayFabLinkType",_CustomGuid), (int)_linkType);
				HandleLoginToPlayFab(_linkType);
				#endif
				
				#if UNITY_WP8 || UNITY_BLACKBERRY || UNITY_WINRT || UNITY_WSA || UNITY_TIZEN && !UNITY_EDITOR
				//This will link / login via CustomID Until another Link Type has been established
				_linkType = RegistrationLinkType.Custom;
				PlayerPrefs.SetInt(string.Format("{0}_PlayFabLinkType",_CustomGuid), (int)_linkType);
				HandleLoginToPlayFab(_linkType);
				#endif
				#endregion
			}
		}
		
		private void HandleLoginToPlayFab(RegistrationLinkType linkType)
		{
			switch (linkType)
			{
			case RegistrationLinkType.PlayFab:
				if (PlayerPrefs.HasKey(string.Format("{0}_PlayFabUsername", _CustomGuid)) && PlayerPrefs.HasKey(string.Format("{0}_PlayFabPassword", _CustomGuid)))
				{
					PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest()
					                                  {
						TitleId = PlayFabSettings.TitleId,
						Username = PlayerPrefs.GetString(string.Format("{0}_PlayFabUsername", _CustomGuid)),
						Password = PlayerPrefs.GetString(string.Format("{0}_PlayFabPassword", _CustomGuid))
					}, (result) =>
					{
						HandleLoginResult(result, linkType);
					}, HandleLoginError);
					
				}
				else
				{
					if (ShowDebug)
					{
						Debug.Log("Stored username or password not found.");
					}
				}
				break;
			case RegistrationLinkType.Android:
				#if UNITY_ANDROID && !UNITY_EDITOR
				AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
				AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject>("getContentResolver");
				AndroidJavaClass secure = new AndroidJavaClass("android.provider.Settings$Secure");
				var deviceId = secure.CallStatic<string>("getString", contentResolver, "android_id");
				PlayFabClientAPI.LoginWithAndroidDeviceID(new PlayFab.ClientModels.LoginWithAndroidDeviceIDRequest()
				                                          {
					AndroidDeviceId = deviceId,
					AndroidDevice = SystemInfo.deviceModel,
					OS = SystemInfo.operatingSystem,
					TitleId = PlayFabSettings.TitleId,
					CreateAccount=true
				}, (result)=>{
					HandleLoginResult(result, linkType);
				}, HandleLoginError);
				#endif
				break;
			case RegistrationLinkType.Ios:
				#if UNITY_IOS && !UNITY_EDITOR
				//TODO: get device id from ios (research how to)
				var deviceId = SystemInfo.deviceUniqueIdentifier
					PlayFabClientAPI.LoginWithIOSDeviceID(new PlayFab.ClientModels.LoginWithIOSDeviceIDRequest() { 
						DeviceId = deviceId,
						DeviceModel = SystemInfo.deviceModel,
						OS = SystemInfo.operatingSystem,
						TitleId = PlayFabSettings.TitleId,
						CreateAccount=true
					},  (result)=>{
						HandleLoginResult(result, linkType);
						
					}, HandleLoginError);
				#endif
				break;
			case RegistrationLinkType.Facebook:
				if (!PlayerPrefs.HasKey(string.Format("{0}_PlayFabFacebookAccessToken", _CustomGuid)))
				{
					if (ShowDebug)
					{
						Debug.LogError("Missing FacebookAccess Token in prefs.");
					}
					break;
				}
				PlayFabClientAPI.LoginWithFacebook(new LoginWithFacebookRequest()
				                                   {
					TitleId = PlayFabSettings.TitleId,
					AccessToken = PlayerPrefs.GetString(string.Format("{0}_PlayFabFacebookAccessToken", _CustomGuid)),
					CreateAccount = true
				}, (result) =>
				{
					HandleLoginResult(result, linkType);
				}, HandleLoginError);
				break;
			case RegistrationLinkType.Google:
				if (!PlayerPrefs.HasKey(string.Format("{0}_PlayFabGooglePublisherId", _CustomGuid)) || !PlayerPrefs.HasKey(string.Format("{0}_PlayFabGoogleAccessToken", _CustomGuid)))
				{
					if (ShowDebug)
					{
						Debug.LogError("Missing PublisherId or AccessToken in prefs.");
					}
					break;
				}
				PlayFabClientAPI.LoginWithGoogleAccount(new LoginWithGoogleAccountRequest()
				                                        {
					TitleId = PlayFabSettings.TitleId,
					PublisherId = PlayerPrefs.GetString(string.Format("{0}_PlayFabGooglePublisherId", _CustomGuid)),
					AccessToken = PlayerPrefs.GetString(string.Format("{0}_PlayFabGoogleAccessToken", _CustomGuid)),
					CreateAccount = true
				}, (result) =>
				{
					HandleLoginResult(result, linkType);
				}, HandleLoginError);
				break;
			case RegistrationLinkType.Steam:
				if (!PlayerPrefs.HasKey(string.Format("{0}_PlayFabSteamTicket", _CustomGuid)))
				{
					if (ShowDebug)
					{
						Debug.LogError("Missing Steam Ticket in prefs.");
					}
					break;
				}
				PlayFabClientAPI.LoginWithSteam(new LoginWithSteamRequest()
				                                {
					TitleId = PlayFabSettings.TitleId,
					SteamTicket = PlayerPrefs.GetString(string.Format("{0}_PlayFabSteamTicket", _CustomGuid)),
					CreateAccount = true
				}, (result) =>
				{
					HandleLoginResult(result, linkType);
				}, HandleLoginError);
				break;
			case RegistrationLinkType.Kongregate:
				if (!PlayerPrefs.HasKey(string.Format("{0}_PlayFabKongregateId", _CustomGuid)) || !PlayerPrefs.HasKey(string.Format("{0}_PlayFabKongregateAuthTicket", _CustomGuid)))
				{
					if (ShowDebug)
					{
						Debug.LogError("Missing KongregateId or Auth Ticket in prefs.");
					}
					break;
				}
				PlayFabClientAPI.LoginWithKongregate(new LoginWithKongregateRequest()
				                                     {
					TitleId = PlayFabSettings.TitleId,
					//KongregateId = (ulong)PlayerPrefs.GetInt(string.Format("{0}_PlayFabKongregateId", _CustomGuid)),
					AuthTicket = PlayerPrefs.GetString(string.Format("{0}_PlayFabKongregateAuthTicket", _CustomGuid)),
					CreateAccount = true
				}, (result) =>
				{
					HandleLoginResult(result, linkType);
				}, HandleLoginError);
				break;
			case RegistrationLinkType.Custom:
				
				var customId = SystemInfo.deviceUniqueIdentifier;
				if (TestMode)
				{
					customId = string.Format("{0}{1}", customId, _CustomGuid);
				}
				
				PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest()
				                                   {
					TitleId = PlayFabSettings.TitleId,
					CustomId = customId,
					CreateAccount = true
				}, (result) =>
				{
					HandleLoginResult(result, linkType);
				}, HandleLoginError);
				break;
			}
		}
		
		private void HandleLoginResult(LoginResult result, RegistrationLinkType linkType)
		{
			_playFabId = result.PlayFabId;
			PlayFab.Examples.PfSharedModelEx.globalClientUser.playFabId = result.PlayFabId;
			
			//Get player Account info and store it.
			PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), (accountInfoResult) =>
			{
				Debug.Log("Account Info Received Succesfully!");
				AccountInfo = accountInfoResult.AccountInfo;
				
				//We make this call here to ensure that Account Info is available after login.
				if (OnLoggedIn != null)
				{
					OnLoggedIn(linkType, result);
				}
				
			}, (accountInfoError) =>
			{
				Debug.Log(accountInfoError.ErrorMessage);
				//Note, this should never really happen. Unless, they lost connection between login & making the GetAccountInfo call.
				
				//Set some default info
				AccountInfo = new UserAccountInfo();
				AccountInfo.PlayFabId = result.PlayFabId;
				AccountInfo.TitleInfo = new UserTitleInfo();
				
				//Continue the login, even know we did not get the Account Info.
				if (OnLoggedIn != null)
				{
					OnLoggedIn(linkType, result);
				}
			});
		}
		
		// all login errors will be routed through this signature
		private void HandleLoginError(PlayFabError error)
		{
			if (ShowDebug)
			{
				Debug.Log(string.Format("Login Error: {0}", error.ErrorMessage));
			}
			if (OnLoggedInError != null)
			{
				OnLoggedInError(_linkType, error);
			}
		}
		
		public static string GetTestModeGuid()
		{
			return _CustomGuid;
		}
	}
}