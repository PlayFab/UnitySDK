using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class SharedDialogController : MonoBehaviour {
	//public ErrorPromptController errorPrompt;

	public TextInputPrompController textInputPrompt;
	public SelectorPromptController selectorPrompt;
	public Transform loadingPrompt;
	
	public delegate void TextInputPromptHandler(string title, string message, System.Action<string> responseCallback, string defaultValue = null);
	public static event TextInputPromptHandler RaiseTextInputPromptRequest;
	
	public delegate void SelectorPromptHandler(string title, List<string> options, System.Action<int> responseCallback);
	public static event SelectorPromptHandler RaiseSelectorPromptRequest;
	
	public delegate void LoadingPromptHandler(string api);
	public static event LoadingPromptHandler RaiseLoadingPromptRequest;
	
	//private List<string> waitingOnRequests = new List<string>();
	private readonly Dictionary<int, System.DateTime> activeCalls = new Dictionary<int, System.DateTime>();
	private float timeOutAfter = 0;
	
	// Use this for initialization
	void Start () 
	{
		if(Time.time > timeOutAfter && activeCalls.Count > 0)
		{
			//request timed out...
			Debug.LogError("Request(s) Timed Out...");
			activeCalls.Clear();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnEnable()
	{
				//PF_Bridge.OnPlayFabCallbackError += HandleCallbackError;
				//PF_Bridge.OnPlayfabCallbackSuccess += HandleCallbackSuccess;
		//		
		//		PF_Authentication.OnLoginFail += HandleOnLoginFail;
		//		PF_Authentication.OnLoginSuccess += HandleOnLoginSuccess;
		//		
				//RaiseLoadingPromptRequest += HandleLoadingPromptRequest;
		//		RaiseConfirmationPromptRequest += HandleConfirmationPromptRequest;
				RaiseTextInputPromptRequest += HandleTextInputRequest; 
		//		RaiseInterstitialRequest += HandleInterstitialRequest;
		//		RaiseStoreRequest += HandleStoreRequest;
		//		RaiseItemViewRequest += HandleItemViewerRequest;
		//		RaiseInventoryPromptRequest += HandleInventoryRequest;
		//		RaiseAccountSettingsRequest += HandleRaiseAccountSettingsRequest;
				RaiseSelectorPromptRequest += HandleSelectorPromptRequest;
		//		RaiseSocialRequest += HandleSocialRequest;
		//		RaiseOfferRequest += HandleOfferPromptRequest;
		
		PlayFab.PlayFabSettings.RegisterForRequests(null, GetType().GetMethod("OnOutgoingApi", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
		PlayFab.PlayFabSettings.RegisterForResponses(null, GetType().GetMethod("OnIncomingApi", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
	}
	
	void HandleRaiseOfferRequest ()
	{
		
	}
	
	
	
	void OnDisable()
	{
				//PF_Bridge.OnPlayFabCallbackError -= HandleCallbackError;	
				//PF_Bridge.OnPlayfabCallbackSuccess -= HandleCallbackSuccess;
		//		
		//		PF_Authentication.OnLoginFail -= HandleOnLoginFail;
		//		PF_Authentication.OnLoginSuccess -= HandleOnLoginSuccess;
		//		
				//RaiseLoadingPromptRequest -= HandleLoadingPromptRequest;
		//		RaiseConfirmationPromptRequest -= HandleConfirmationPromptRequest;
				RaiseTextInputPromptRequest -= HandleTextInputRequest; 
		//		RaiseInterstitialRequest -= HandleInterstitialRequest;
		//		RaiseStoreRequest -= HandleStoreRequest;
		//		RaiseItemViewRequest -= HandleItemViewerRequest;
		//		RaiseInventoryPromptRequest -= HandleInventoryRequest;
		//		RaiseAccountSettingsRequest -= HandleRaiseAccountSettingsRequest;
				RaiseSelectorPromptRequest -= HandleSelectorPromptRequest;
		//		RaiseSocialRequest -= HandleSocialRequest;
		//		RaiseOfferRequest -= HandleOfferPromptRequest;
		
		PlayFab.PlayFabSettings.UnregisterForRequests(null, GetType().GetMethod("OnOutgoingApi", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
		PlayFab.PlayFabSettings.UnregisterForResponses(null, GetType().GetMethod("OnIncomingApi", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
	}
	
	public static void RequestTextInputPrompt(string title, string message, System.Action<string> responseCallback, string defaultValue = null)
	{
		if(RaiseTextInputPromptRequest != null)
		{
			RaiseTextInputPromptRequest(title, message, responseCallback, defaultValue);
		}
	}
	
	public void HandleTextInputRequest(string title, string message, System.Action<string> responseCallback, string defaultValue)
	{
		//this.ShowTint();
		this.textInputPrompt.ShowTextInputPrompt(title, message, responseCallback, defaultValue);
	}
	
	public void HandleSelectorPromptRequest (string title, List<string> options, System.Action<int> responseCallback)
	{
		this.selectorPrompt.gameObject.SetActive (true);
		this.selectorPrompt.InitSelector (title, options, responseCallback);
	}

	public static void RequestSelectorPrompt(string title, List<string> options, System.Action<int> responseCallback)
	{
		if(RaiseSelectorPromptRequest != null)
		{
			RaiseSelectorPromptRequest(title, options, responseCallback);
		}
	}
	
//	public static void RequestLoadingPrompt(string api)
//	{
//		if(RaiseLoadingPromptRequest != null)
//		{
//			RaiseLoadingPromptRequest(api);
//		}
//	}
//	
//	public void HandleLoadingPromptRequest(string api)
//	{
//		loadingPrompt.gameObject.SetActive(true);
//	}
//	
//	public void CloseLoadingPrompt(string api)
//	{
//		loadingPrompt.gameObject.SetActive(false);
//	}
	
	public void CloseLoadingPromptAfterError()
	{
		activeCalls.Clear();
		this.loadingPrompt.gameObject.SetActive(true);
	}
	
	
	
	public void OnOutgoingApi(string url, int callId, object request, object customData)
	{
		activeCalls[callId] = System.DateTime.UtcNow;
		timeOutAfter = Time.time + 30;
		loadingPrompt.gameObject.SetActive(true);
		
	}
	
	
	public void OnIncomingApi(string url, int callId, object request, object result, PlayFab.PlayFabError error, object customData)
	{
		if(activeCalls.ContainsKey(callId))
		{
			var delta = System.DateTime.UtcNow - activeCalls[callId];
			Debug.Log(url + " completed in " + delta.TotalMilliseconds + " - _StGl");
			activeCalls.Remove(callId);
			
			if(this.activeCalls.Count == 0)
			{
				//ShowTint();
				loadingPrompt.gameObject.SetActive(false);
			}
		}
	}
	
	
	
	
	//	void HandleOnLoginSuccess(string message, MessageDisplayStyle style)
	//	{
	//		HandleCallbackSuccess(message, PlayFabAPIMethods.GenericLogin, style);
	//	}
	//	
	//	void HandleOnLoginFail(string message, MessageDisplayStyle style)
	//	{
	//		HandleCallbackError(message, PlayFabAPIMethods.GenericLogin, style);
	//	}
	//	
	//
	//	public void HandleCallbackError(string details, PlayFabAPIMethods method, MessageDisplayStyle style)
	//	{
	//		switch(style)
	//		{
	//			case MessageDisplayStyle.error:
	//				string errorMessage = string.Format("CALLBACK ERROR: {0}: {1}", method, details);
	//				//ShowTint();
	//				this.errorPrompt.RaiseErrorDialog(errorMessage);
	//				CloseLoadingPromptAfterError();
	//			break;
	//			
	//			default:
	//				CloseLoadingPrompt(method);
	//				Debug.Log(string.Format("CALLBACK ERROR: {0}: {1}", method, details));
	//				break;
	//			
	//		}
	//		
	//	}
	//	
	//	public void HandleCallbackSuccess(string details, PlayFabAPIMethods method, MessageDisplayStyle style)
	//	{
	//		CloseLoadingPrompt(method);
	//		//Debug.Log(string.Format("{0} completed successfully.", method.ToString()));
	//	}
	//	
	//	
	//	public void CloseErrorDialog()
	//	{	
	//		this.errorPrompt.CloseErrorDialog();
	//		
	//	}
}
