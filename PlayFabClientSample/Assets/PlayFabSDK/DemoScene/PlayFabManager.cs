#if UNITY_EDITOR
#elif UNITY_ANDROID
#define PLAYFAB_ANDROID
#elif UNITY_IOS
#define PLAYFAB_IOS
#endif

using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Internal;
using PlayFab.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayFabManager : MonoBehaviour
{
    public string filename = "C:/depot/pf-main/tools/SDKBuildScripts/testTitleData.json";
    public string TitleId;
    public string callStatus = "** PlayFab Console ** \n Run on an Android or iOS device to see automatic device ID authentication.";

    void Awake()
    {
        PlayFabSettings.TitleId = TitleId;
    }

    void Start()
    {
        Debug.Log("Starting Auto-login Process");
#if PLAYFAB_IOS
		PlayFabClientAPI.LoginWithIOSDeviceID (new LoginWithIOSDeviceIDRequest
		{
			DeviceId = SystemInfo.deviceUniqueIdentifier,
			OS = SystemInfo.operatingSystem,
			DeviceModel = SystemInfo.deviceModel,
			CreateAccount = true
		}, OnLoginSuccess, OnLoginError, "LoginWithIOSDeviceID");
#elif PLAYFAB_ANDROID
		PlayFabClientAPI.LoginWithAndroidDeviceID (new LoginWithAndroidDeviceIDRequest
		{
			AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
			OS = SystemInfo.operatingSystem,
			AndroidDevice = SystemInfo.deviceModel,
			CreateAccount = true
		}, OnLoginSuccess, OnLoginError, "LoginWithAndroidDeviceID");
#else
        if (File.Exists(filename))
        {
            string testInputsFile = File.ReadAllText(filename);
            var serializer = JsonSerializer.Create(Util.JsonSettings);
            var testInputs = serializer.Deserialize<Dictionary<string, string>>(new JsonTextReader(new StringReader(testInputsFile)));

            string eachValue, email, password;
            PlayFabHTTP.instance.Awake();
            PlayFabSettings.RequestType = WebRequestType.HttpWebRequest;

            bool loadedTitleInfo = true;
            // Parse all the inputs
            loadedTitleInfo &= testInputs.TryGetValue("titleId", out eachValue);
            PlayFabSettings.TitleId = TitleId = eachValue;

            loadedTitleInfo &= testInputs.TryGetValue("userEmail", out email);
            loadedTitleInfo &= testInputs.TryGetValue("userPassword", out password);

            if (loadedTitleInfo)
                PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest { Email = email, Password = password, TitleId = TitleId }, OnLoginSuccess, OnLoginError, "LoginWithEmailAddress");
        }
#endif
    }

    private void OnLoginSuccess(LoginResult result)
    {
        string advertisingIdType, advertisingIdValue;
        bool disableAdvertising = false;
        PlayFabClientAPI.GetAdvertisingId(out advertisingIdType, out advertisingIdValue, ref disableAdvertising);
        callStatus = string.Format("PlayFab Authentication Successful!\n"
            + "Player ID: " + result.PlayFabId) + "\n"
            + "advertisingIdType: " + advertisingIdType + "\n"
            + "advertisingIdValue: " + advertisingIdValue + "\n"
            + "disableAdvertising: " + disableAdvertising + "\n"
            + "from: " + result.CustomData;
        Debug.Log(callStatus);
    }

    private void OnLoginError(PlayFabError error)
    {
        this.callStatus = string.Format("Error {0}: {1}", error.HttpCode, error.ErrorMessage);
        Debug.Log(callStatus);
    }
}
