using UnityEngine;
using System.Collections;
using PlayFab;
using PlayFab.ClientModels;

public class MiniExample : MonoBehaviour {


	void Start () {
		PlayFabSettings.UseDevelopmentEnvironment = true;
		PlayFabSettings.TitleId = "AAA";
		PlayFabSettings.GlobalErrorHandler = OnPlayFabError;

		PlayFabClientAPI.LoginWithPlayFab (new LoginWithPlayFabRequest
		{
			Username = "Bob",
			Password = "nose"
		}, OnLoginResult, null);
	}

	void OnLoginResult(LoginResult result)
	{
		Debug.Log ("Yay, logged in in session token: " + result.SessionTicket);
	}

	void OnPlayFabError(PlayFabError error)
	{
		Debug.Log ("Got an error: " + error.ErrorMessage);
	}


}
