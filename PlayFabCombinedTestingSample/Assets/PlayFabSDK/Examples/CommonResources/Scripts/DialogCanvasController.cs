using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using PlayFab.ClientModels;

public class DialogCanvasController : MonoBehaviour{
//	public ErrorPromptController errorPrompt;
//	// public Transform contextPrompt;
//	public ConfirmationPromptController confirmPrompt;
//	public LoadingPromptController loadingPrompt;
//	public TextInputPrompController textInputPrompt;
//	public InterstitialController interstitialPrompt;
//	public SelectorPromptController selectorPrompt;
//
//	public ItemViewerController itemViewerPrompt;
//	public FloatingStoreController floatingStorePrompt;
//	public FloatingInventoryController floatingInvPrompt; 
//
//	public OfferPromptController offerPrompt;
//	public LeaderboardPaneController socialPrompt;
//	public AccountStatusController accountSettingsPrompt;
	
	public enum InventoryFilters { AllItems, UsableInCombat, Keys, Containers } 
	
	
//	public delegate void LoadingPromptHandler(PlayFabAPIMethods method);
//	public static event LoadingPromptHandler RaiseLoadingPromptRequest;
//	
//	public delegate void ConfirmationPromptHandler(string title, string message, Action<bool> responseCallback);
//	public static event ConfirmationPromptHandler RaiseConfirmationPromptRequest;
//	
//	public delegate void TextInputPromptHandler(string title, string message, Action<string> responseCallback, string defaultValue = null);
//	public static event TextInputPromptHandler RaiseTextInputPromptRequest;
//
//	public delegate void SelectorPromptHandler(string title, List<string> options, UnityAction<int> responseCallback);
//	public static event SelectorPromptHandler RaiseSelectorPromptRequest;
//
//	public delegate void InterstitialRequestHandler();
//	public static event InterstitialRequestHandler RaiseInterstitialRequest;
//
//	public delegate void StoreRequestHandler(string storeID);
//	public static event StoreRequestHandler RaiseStoreRequest;
//
//	public delegate void ItemViewRequestHandler(List<string> items, bool unpackToPlayer);
//	public static event ItemViewRequestHandler RaiseItemViewRequest;
//
//	public delegate void InventoryPromptHandler(Action<string> responseCallback, InventoryFilters filter);
//	public static event InventoryPromptHandler RaiseInventoryPromptRequest;
//
//	public delegate void RequestAccountSettingsHandler();
//	public static event RequestAccountSettingsHandler RaiseAccountSettingsRequest;
//	
//	public delegate void RequestSocialHandler();
//	public static event RequestSocialHandler RaiseSocialRequest;
//
//	public delegate void RequestOfferPromptHandler();
//	public static event RequestOfferPromptHandler RaiseOfferRequest;
//
//	private List<PlayFabAPIMethods> waitingOnRequests = new List<PlayFabAPIMethods>();
	
	
	
	//public str
	
	//TODO things to display
	// modal dialogs
	// errors
	// special stores
	// battle reports 
	// interstitials / tool tips / sales info
	

	
	
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
//		RaiseTextInputPromptRequest += HandleTextInputRequest; 
//		RaiseInterstitialRequest += HandleInterstitialRequest;
//		RaiseStoreRequest += HandleStoreRequest;
//		RaiseItemViewRequest += HandleItemViewerRequest;
//		RaiseInventoryPromptRequest += HandleInventoryRequest;
//		RaiseAccountSettingsRequest += HandleRaiseAccountSettingsRequest;
//		RaiseSelectorPromptRequest += HandleSelectorPromptRequest;
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
//		RaiseTextInputPromptRequest -= HandleTextInputRequest; 
//		RaiseInterstitialRequest -= HandleInterstitialRequest;
//		RaiseStoreRequest -= HandleStoreRequest;
//		RaiseItemViewRequest -= HandleItemViewerRequest;
//		RaiseInventoryPromptRequest -= HandleInventoryRequest;
//		RaiseAccountSettingsRequest -= HandleRaiseAccountSettingsRequest;
//		RaiseSelectorPromptRequest -= HandleSelectorPromptRequest;
//		RaiseSocialRequest -= HandleSocialRequest;
//		RaiseOfferRequest -= HandleOfferPromptRequest;
	}


//	void HandleSelectorPromptRequest (string title, List<string> options, UnityAction<int> responseCallback)
//	{
//		this.selectorPrompt.gameObject.SetActive (true);
//		this.selectorPrompt.InitSelector (title, options, responseCallback);
//	}
//
//	public static void RequestSelectorPrompt(string title, List<string> options, UnityAction<int> responseCallback)
//	{
//		if(RaiseSelectorPromptRequest != null)
//		{
//			RaiseSelectorPromptRequest(title, options, responseCallback);
//		}
//	}
	
	void OnGUI()
	{
/*		if (GUI.Button (new Rect(5, 200, 150, 50), "Test Selector")) 
		{
			UnityAction<int> afterSelect = ( int  response) => 
			{
				Debug.Log("" + response);
			};
			List<string> options = new List<string>()
			{
				"Gold",
				"Gems",
				"Potions",
				"Sale Items"
			};
			DialogCanvasController.RaiseSelectorPromptRequest(options, afterSelect);
		} */
		
	}
	
//	public static void RequestTextInputPrompt(string title, string message, Action<string> responseCallback, string defaultValue = null)
//	{
//		if(RaiseTextInputPromptRequest != null)
//		{
//			RaiseTextInputPromptRequest(title, message, responseCallback, defaultValue);
//		}
//	}
//	
//	public void HandleTextInputRequest(string title, string message, Action<string> responseCallback, string defaultValue)
//	{
//		//this.ShowTint();
//		this.textInputPrompt.ShowTextInputPrompt(title, message, responseCallback, defaultValue);
//	}
//	
//	
//	public static void RequestConfirmationPrompt(string title, string message, Action<bool> responseCallback)
//	{
//		if(RaiseConfirmationPromptRequest != null)
//		{
//			RaiseConfirmationPromptRequest(title, message, responseCallback);
//		}
//	}
//	
//	public void HandleConfirmationPromptRequest(string title, string message, Action<bool> responseCallback)
//	{
//		//this.ShowTint();
//		this.confirmPrompt.ShowConfirmationPrompt(title, message, responseCallback, this.HideTint);
//	}
//	
//	
//	public static void RequestLoadingPrompt(PlayFabAPIMethods method)
//	{
//		if(RaiseLoadingPromptRequest != null)
//		{
//			RaiseLoadingPromptRequest(method);
//		}
//	}
//	
//	public void HandleLoadingPromptRequest(PlayFabAPIMethods method)
//	{
//		if(this.waitingOnRequests.Count == 0)
//		{
//			//ShowTint();
//			this.loadingPrompt.RaiseLoadingPrompt();
//		}
//		this.waitingOnRequests.Add(method);
//	}
//	
//	public void CloseLoadingPrompt(PlayFabAPIMethods method)
//	{
//		PlayFabAPIMethods waiting = this.waitingOnRequests.Find((i) => { return i == method; });
//		
//		if(waiting != PlayFabAPIMethods.Null)
//		{
//			this.waitingOnRequests.Remove(method);
//			if(this.waitingOnRequests.Count == 0)
//			{
//				this.loadingPrompt.CloseLoadingPrompt();
//			}
//		}
//	}
//	
//	public void CloseLoadingPromptAfterError()
//	{
//		this.waitingOnRequests.Clear();
//		this.loadingPrompt.CloseLoadingPrompt();
//	}
//	
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
