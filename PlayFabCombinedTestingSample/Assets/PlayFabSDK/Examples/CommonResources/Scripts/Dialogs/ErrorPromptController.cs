using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ErrorPromptController : MonoBehaviour {
	public Text title;
	public Text body;
	public Button close;

	public void RaiseErrorDialog(string txt)
	{
		this.body.text = txt;
		this.gameObject.SetActive(true);
	}
	
	public void CloseErrorDialog()
	{
		this.gameObject.SetActive(false);
	}
	
}
