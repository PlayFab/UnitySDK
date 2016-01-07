using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class SharedDialogController : MonoBehaviour {


	public TextInputPrompController textInputPrompt;
	public SelectorPromptController selectorPrompt;
	
	
	public delegate void TextInputPromptHandler(string title, string message, UnityAction<string> responseCallback, string defaultValue = null);
	public static event TextInputPromptHandler RaiseTextInputPromptRequest;
	
	public delegate void SelectorPromptHandler(string title, List<string> options, UnityAction<int> responseCallback);
	public static event SelectorPromptHandler RaiseSelectorPromptRequest;
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnEnable()
	{
		//		PF_Bridge.OnPlayFabCallbackError += HandleCallbackError;
		//		PF_Bridge.OnPlayfabCallbackSuccess += HandleCallbackSuccess;
		//		
		//		PF_Authentication.OnLoginFail += HandleOnLoginFail;
		//		PF_Authentication.OnLoginSuccess += HandleOnLoginSuccess;
		//		
		//		RaiseLoadingPromptRequest += HandleLoadingPromptRequest;
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
		
	}
	
	void HandleRaiseOfferRequest ()
	{
		
	}
	
	
	
	void OnDisable()
	{
		//		PF_Bridge.OnPlayFabCallbackError -= HandleCallbackError;	
		//		PF_Bridge.OnPlayfabCallbackSuccess -= HandleCallbackSuccess;
		//		
		//		PF_Authentication.OnLoginFail -= HandleOnLoginFail;
		//		PF_Authentication.OnLoginSuccess -= HandleOnLoginSuccess;
		//		
		//		RaiseLoadingPromptRequest -= HandleLoadingPromptRequest;
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
	}
	
	public static void RequestTextInputPrompt(string title, string message, UnityAction<string> responseCallback, string defaultValue = null)
	{
		if(RaiseTextInputPromptRequest != null)
		{
			RaiseTextInputPromptRequest(title, message, responseCallback, defaultValue);
		}
	}
	
	public void HandleTextInputRequest(string title, string message, UnityAction<string> responseCallback, string defaultValue)
	{
		//this.ShowTint();
		this.textInputPrompt.ShowTextInputPrompt(title, message, responseCallback, defaultValue);
	}
	
	public void HandleSelectorPromptRequest (string title, List<string> options, UnityAction<int> responseCallback)
	{
		this.selectorPrompt.gameObject.SetActive (true);
		this.selectorPrompt.InitSelector (title, options, responseCallback);
	}

	public static void RequestSelectorPrompt(string title, List<string> options, UnityAction<int> responseCallback)
	{
		if(RaiseSelectorPromptRequest != null)
		{
			RaiseSelectorPromptRequest(title, options, responseCallback);
		}
	}
}
