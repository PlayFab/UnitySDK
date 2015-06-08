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
	
	void Start () {

		PlayFabSettings.TitleId = TitleId;

		#if PLAYFAB_ANDROID
		PlayFabClientAPI.LoginWithIOSDeviceID (new LoginWithIOSDeviceIDRequest
		{
			DeviceId = SystemInfo.deviceUniqueIdentifier,
			OS = SystemInfo.operatingSystem,
			DeviceModel = SystemInfo.deviceModel,
			CreateAccount = true
		}, onLogin, null);
		#elif PLAYFAB_IOS
		PlayFabClientAPI.LoginWithAndroidDeviceID (new LoginWithAndroidDeviceIDRequest
		{
			AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
			OS = SystemInfo.operatingSystem,
			AndroidDevice = SystemInfo.deviceModel,
			CreateAccount = true
		}, onLogin, null);
		#endif

	}
	
	private void onLogin(LoginResult result)
	{

	}


}
