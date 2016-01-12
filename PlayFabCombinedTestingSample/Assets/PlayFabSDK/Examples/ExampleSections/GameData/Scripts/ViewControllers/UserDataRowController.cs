using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;

using PlayFab.ClientModels;
public class UserDataRowController : MonoBehaviour {

	public InputField keyField;
	public InputField valueField;
	public Toggle permissionToggle;
	public Toggle deleteToggle;
	
	private UserDataController controller;
	private KeyValuePair<string, UserDataRecord> original = new KeyValuePair<string, UserDataRecord>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Init(KeyValuePair<string, UserDataRecord> kvp, UserDataController controller, bool useBanding = false, bool isReadOnly = false, bool usePermissions = false, bool canDelete = true)
	{
		this.keyField.text = kvp.Key;
		this.valueField.text = string.Format("{0}", kvp.Value.Value);
		
		if(usePermissions == true)
		{
			this.permissionToggle.gameObject.SetActive(true);
			this.permissionToggle.isOn = kvp.Value.Permission != null && kvp.Value.Permission == UserDataPermission.Private ? true : false;
		}
		else
		{
			this.permissionToggle.gameObject.SetActive(false);
		}
		
		if(canDelete == true)
		{
			this.deleteToggle.gameObject.SetActive(true);
			this.deleteToggle.isOn =  false;
		}
		else
		{
			this.deleteToggle.gameObject.SetActive(false);
		}
		
		if(isReadOnly)
		{
			this.keyField.interactable = false;
			this.valueField.interactable = false;
		}
		else
		{
			this.keyField.interactable = true;
			this.valueField.interactable = true;
		}
		
//		this._balance = kvp.Value;
//		this._initialBalance = this._balance;
//		
//		this.controller = controller;
//		
//		this.vc_balance.onEndEdit.RemoveAllListeners();
//		this.vc_balance.onEndEdit.AddListener((string input) => { 
//			OnBalanceEdited(this.vc_balance.text);
//		});
//		
//		if(useBanding == true)
//		{
//			this.banding.enabled = true;
//		}
//		else
//		{
//			this.banding.enabled = false;
//		}
	}
	
	
}
