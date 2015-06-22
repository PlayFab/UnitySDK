using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class LoginExample : MonoBehaviour {
	

	public Text LogText;
	

	void Start () {
		
		log ("Starting login example");
		PlayFabSettings.GlobalErrorHandler = OnPlayFabError;
		
		// First, log in to playfab
		PlayFabClientAPI.LoginWithIOSDeviceID (new LoginWithIOSDeviceIDRequest
		{
			DeviceId = "SDKSampleDevice",
			OS = "UnityOS",
			CreateAccount = true
		}, OnLoginResult, null);
		
	}
	
	public void log(string text)
	{
		Debug.Log (text);
		if (LogText != null)
		{
			LogText.text += text+"\n";
		}
		
	}
	
	void OnLoginResult(LoginResult result)
	{
		log ("Logged in");

	
		PlayFabClientAPI.GetTitleData (new GetTitleDataRequest
		{
			Keys = new List<string>{"HoldOn"}
		}, OnGetTitleData, null);

	}
	

	void OnGetTitleData(GetTitleDataResult result)
	{
		log ("Got title data");
		
		

		
	}

	
	void OnPlayFabError(PlayFabError error)
	{
		log("Got an error: " + error.ErrorMessage);
	}
}
