#if UNITY_EDITOR

#elif UNITY_ANDROID
#define PLAYFAB_ANDROID
#elif UNITY_IOS
#define PLAYFAB_IOS
#endif

using UnityEngine;

using PlayFab;
using PlayFab.ClientModels;

public class PlayFabManager : MonoBehaviour {
	public string TitleId;
	public string callStatus = "** PlayFab Console ** \n Run on an Android or iOS device to see automatic device ID authentication.";

	void Awake () {
		PlayFabSettings.TitleId = TitleId;
	}

	void Start () {
		Debug.Log("Starting Auto-login Process");
		#if PLAYFAB_IOS
		PlayFabClientAPI.LoginWithIOSDeviceID (new LoginWithIOSDeviceIDRequest
		{
			DeviceId = SystemInfo.deviceUniqueIdentifier,
			OS = SystemInfo.operatingSystem,
			DeviceModel = SystemInfo.deviceModel,
			CreateAccount = true
		}, onLoginSuccess, null);
		#elif PLAYFAB_ANDROID
		PlayFabClientAPI.LoginWithAndroidDeviceID (new LoginWithAndroidDeviceIDRequest
		{
			AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
			OS = SystemInfo.operatingSystem,
			AndroidDevice = SystemInfo.deviceModel,
			CreateAccount = true
		}, onLoginSuccess, null);
		#endif
	}
	
	private void onLoginSuccess(LoginResult result)
	{
		this.callStatus = string.Format("PlayFab Authentication Successful! -- Player ID:{0}", result.PlayFabId);
		Debug.Log(callStatus);
		
	}
	
	private void onLoginError(PlayFabError error)
	{
		this.callStatus = string.Format("Error {0}: {1}", error.HttpCode, error.ErrorMessage);
		Debug.Log(callStatus);
	}
}
