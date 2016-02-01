using UnityEngine;
using System.Collections.Generic;

public class SharedDialogController : MonoBehaviour {
	public TextInputPrompController TextInputPrompController;
	public SelectorPromptController SelectorPrompt;
	public Transform LoadingPrompt;
	
	public delegate void TextInputPromptHandler(string title, string message, System.Action<string> responseCallback, string defaultValue = null);
	public static event TextInputPromptHandler RaiseTextInputPromptRequest;
	
	public delegate void SelectorPromptHandler(string title, List<string> options, System.Action<int> responseCallback);
	public static event SelectorPromptHandler RaiseSelectorPromptRequest;
	
	private readonly Dictionary<int, System.DateTime> _activeCalls = new Dictionary<int, System.DateTime>();
	private float _timeOutAfter = 0;
	
	// Use this for initialization
	void Start () 
	{
		if(Time.time > _timeOutAfter && _activeCalls.Count > 0)
		{
			//request timed out...
			Debug.LogError("Request(s) Timed Out...");
			_activeCalls.Clear();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnEnable()
	{
		RaiseTextInputPromptRequest += HandleTextInputRequest; 
		RaiseSelectorPromptRequest += HandleSelectorPromptRequest;
		
		PlayFab.PlayFabSettings.RegisterForRequests(null, GetType().GetMethod("OnOutgoingApi", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
		PlayFab.PlayFabSettings.RegisterForResponses(null, GetType().GetMethod("OnIncomingApi", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
	}
	
	void OnDisable()
	{
		RaiseTextInputPromptRequest -= HandleTextInputRequest; 
		RaiseSelectorPromptRequest -= HandleSelectorPromptRequest;
		
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
		this.TextInputPrompController.ShowTextInputPrompt(title, message, responseCallback, defaultValue);
	}
	
	public void HandleSelectorPromptRequest (string title, List<string> options, System.Action<int> responseCallback)
	{
		this.SelectorPrompt.gameObject.SetActive (true);
		this.SelectorPrompt.InitSelector (title, options, responseCallback);
	}

	public static void RequestSelectorPrompt(string title, List<string> options, System.Action<int> responseCallback)
	{
		if(RaiseSelectorPromptRequest != null)
		{
			RaiseSelectorPromptRequest(title, options, responseCallback);
		}
	}
	
	public void CloseLoadingPromptAfterError()
	{
		_activeCalls.Clear();
		this.LoadingPrompt.gameObject.SetActive(true);
	}
	
	
	
	public void OnOutgoingApi(string url, int callId, object request, object customData)
	{
		_activeCalls[callId] = System.DateTime.UtcNow;
		_timeOutAfter = Time.time + 30;
		LoadingPrompt.gameObject.SetActive(true);

        Debug.Log(url + " Out");
	}
	
	
	public void OnIncomingApi(string url, int callId, object request, object result, PlayFab.PlayFabError error, object customData)
	{
		if(_activeCalls.ContainsKey(callId))
		{
			var delta = System.DateTime.UtcNow - _activeCalls[callId];
			Debug.Log(url + " completed in " + delta.TotalMilliseconds + " - _StGl");
			_activeCalls.Remove(callId);
			
			if(this._activeCalls.Count == 0)
			{
				//ShowTint();
				LoadingPrompt.gameObject.SetActive(false);
			}
		}
	}	
}
