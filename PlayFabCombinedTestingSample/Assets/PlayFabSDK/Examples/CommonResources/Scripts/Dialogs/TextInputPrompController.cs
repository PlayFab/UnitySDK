using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class TextInputPrompController : MonoBehaviour {
	public Button confirmButton;
	public Button denyButton;
	public Text message;
	public Text title;
	public InputField userInput;
	
	private System.Action<string> responseCallback;
	
	// Use this for initialization
	void Start () 
	{
		this.confirmButton.onClick.AddListener(()=> { Confirmed(); });
		this.denyButton.onClick.AddListener(()=> { Denied(); });
	}

	public void Confirmed()
	{
		HideConfirmationPrompt();
		responseCallback(userInput.text);
	}
	
	public void Denied()
	{
		HideConfirmationPrompt();
		responseCallback(null);
	}
	
	public void ShowTextInputPrompt(string title, string message, System.Action<string> callback, string defaultValue)
	{
		this.message.text = message;
		this.title.text = title;
		this.responseCallback = callback;

		if(!string.IsNullOrEmpty(defaultValue))
		{
			this.userInput.text = defaultValue;
		}
		else
		{
			this.userInput.text = string.Empty;
		}
		
		this.gameObject.SetActive(true);
	}
	
	public void HideConfirmationPrompt()
	{
		this.gameObject.SetActive(false);
	}
}
