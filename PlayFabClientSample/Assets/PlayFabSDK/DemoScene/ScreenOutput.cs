using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using PlayFab.Json;

public class ScreenOutput : MonoBehaviour {
	
	// link to our other scene object.
	public PlayFabManager pf_manager;
	
	// other UI elements
	public Text LoginResponse;
	public Button testCloudScript;
	public Text cloudScriptResponse;
	
	// Use this for initialization
	void Start () 
	{
		testCloudScript.onClick.RemoveAllListeners();
		testCloudScript.onClick.AddListener(() => { TestCloudScript(); });
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(pf_manager != null && !string.Equals(LoginResponse.text, pf_manager.callStatus))
		{
			LoginResponse.text = pf_manager.callStatus;
			EnableTestCSButton();
		}
	}
	
	/// <summary>
	/// Enables the test CS button.
	/// </summary>
	void EnableTestCSButton()
	{
		// check to see if our player is authenticated
		if(testCloudScript.interactable == false && PlayFabClientAPI.IsClientLoggedIn())
		{
			testCloudScript.interactable = true;
		}
	}
	
	/// <summary>
	/// Get the cloud script endpoint and callback after
	/// </summary>
	/// <returns><c>true</c>, if cloud script endpoint was gotten, <c>false</c> otherwise.</returns>
	/// <param name="cb">Cb.</param>
	public void GetCloudScriptEndpoint(UnityAction callback = null)
	{
		// quick check to verify that we have an endpoint. This should only need to be ran once.
		if(string.IsNullOrEmpty(PlayFabSettings.LogicServerURL))
		{
			PlayFabClientAPI.GetCloudScriptUrl(new GetCloudScriptUrlRequest(), (GetCloudScriptUrlResult result) => 
			{ 
				if(callback != null)
				{
					callback();
				}
			}, 
			OnPlayFabError);
		} 
		else
		{
			callback();
		}
	}
	
	// An example of how to access Cloud Script methods.
	void TestCloudScript()
	{
		// this will be called after we have an API endpoint
		UnityAction RunAfterEndpoint = () => 
		{
			RunCloudScriptRequest request = new RunCloudScriptRequest();
			request.ActionId = "helloWorld";
			
			PlayFabClientAPI.RunCloudScript(request, (RunCloudScriptResult result) => 
			{
				// we are expecting a string,string keyvaluepair, so here we are capturing the kvp with a dictionary due to it being easier to work with.
				Dictionary<string, string> deserializedResults = new Dictionary<string, string>();
				deserializedResults = JsonConvert.DeserializeObject<Dictionary<string, string>>(result.ResultsEncoded);
				
				string message = string.Empty;
				if(deserializedResults.TryGetValue("messageValue", out message))
				{
					cloudScriptResponse.text = string.Format("Cloud Script -- Version: {0}, Revision: {1} \nResponse: {2}", result.Version, result.Revision, message);
				}
				else
				{
					cloudScriptResponse.text = "Cloud Script call was successful, but there was an error deserializing the messageValue";
				}
			}, OnPlayFabError);
		};
		
		// we need to supply the SDK with the endpoint before our RunCloudScriptRequests will succeed
		GetCloudScriptEndpoint(RunAfterEndpoint);
	}
	
	
	// A standard error callback that prints out any errors to the screen and to the console.
	void OnPlayFabError(PlayFabError error)
	{
		string message = string.Format("Error {0}: {1}", error.HttpCode, error.ErrorMessage);
		this.cloudScriptResponse.text = message;
		Debug.Log(message);
	}
	
	
}
