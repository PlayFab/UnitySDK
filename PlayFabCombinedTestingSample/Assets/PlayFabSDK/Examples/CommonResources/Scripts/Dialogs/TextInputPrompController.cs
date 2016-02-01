using UnityEngine;
using UnityEngine.UI;

public class TextInputPrompController : MonoBehaviour {
	public Button ConfirmButton;
	public Button DenyButton;
	public Text Message;
	public Text Title;
	public InputField UserInput;
	
	private System.Action<string> _responseCallback;
	
	// Use this for initialization
	void Start () 
	{
		this.ConfirmButton.onClick.AddListener(()=> { Confirmed(); });
		this.DenyButton.onClick.AddListener(()=> { Denied(); });
	}

	public void Confirmed()
	{
		HideConfirmationPrompt();
		_responseCallback(UserInput.text);
	}
	
	public void Denied()
	{
		HideConfirmationPrompt();
		_responseCallback(null);
	}
	
	public void ShowTextInputPrompt(string title, string message, System.Action<string> callback, string defaultValue)
	{
		this.Message.text = message;
		this.Title.text = title;
		this._responseCallback = callback;

		if(!string.IsNullOrEmpty(defaultValue))
		{
			this.UserInput.text = defaultValue;
		}
		else
		{
			this.UserInput.text = string.Empty;
		}
		
		this.gameObject.SetActive(true);
	}
	
	public void HideConfirmationPrompt()
	{
		this.gameObject.SetActive(false);
	}
}
