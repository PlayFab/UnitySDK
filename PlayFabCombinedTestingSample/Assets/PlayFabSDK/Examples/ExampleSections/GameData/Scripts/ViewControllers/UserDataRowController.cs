using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using PlayFab.ClientModels;
public class UserDataRowController : MonoBehaviour, ISelectHandler {

	public InputField keyField;
	public InputField valueField;
	public Toggle permissionToggle;
	public Toggle deleteToggle;
	public Image banding;
	
	public bool isNewRecord = false;
	
	public UserDataController controller;
	public string originalKey { get { return _originalKey; } }
	private string _originalKey = string.Empty;
	
	//private KeyValuePair<string, UserDataRecord> original_udr = new KeyValuePair<string, UserDataRecord>();
	//private KeyValuePair<string, string> original_string = new KeyValuePair<string, string>();
	//private KeyValuePair<string, int> original_stat = new KeyValuePair<string, int>();
	
	private bool isBanded = false;
	
	
	// Use this for initialization
	void Start () 
	{
		deleteToggle.onValueChanged.AddListener((bool value) => { OnDeleteClicked(value); });
		permissionToggle.onValueChanged.AddListener((bool value) => { OnPermissionClicked(value); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Init(KeyValuePair<string, UserDataRecord> kvp, UserDataController controller, bool useBanding = false, bool isReadOnly = false, bool usePermissions = false, bool canDelete = true)
	{
		//this.original_udr = kvp;
		if(string.IsNullOrEmpty(kvp.Key))
		{
			this.isNewRecord = true;
		} 
		this._originalKey = kvp.Key;
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
			this.permissionToggle.interactable = true;
			this.deleteToggle.interactable = true;
		}
				
		this.controller = controller;
		
		if(useBanding == true)
		{
			this.banding.enabled = true;
			this.isBanded = true;
		}
		else
		{
			this.banding.enabled = false;
			this.isBanded = false;
		}
	}
	
	public void Init(KeyValuePair<string, string> kvp, UserDataController controller, bool useBanding = false, bool isReadOnly = false, bool usePermissions = false, bool canDelete = true)
	{
		this._originalKey = kvp.Key;
		this.keyField.text = kvp.Key.Length > 256 ? kvp.Key.Substring(0, 256) : kvp.Key;
		this.valueField.text = string.Format("{0}", kvp.Value.Length > 256 ? kvp.Value.Substring(0, 256) : kvp.Value);
		
		if(usePermissions == true)
		{
			this.permissionToggle.gameObject.SetActive(true);
			//this.permissionToggle.isOn = kvp.Value.Permission != null && kvp.Value.Permission == UserDataPermission.Private ? true : false;
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
		
		this.controller = controller;
		
		if(useBanding == true)
		{
			this.banding.enabled = true;
			this.isBanded = true;
		}
		else
		{
			this.banding.enabled = false;
			this.isBanded = false;
		}
	}
	
	public void Init(KeyValuePair<string, int> kvp, UserDataController controller, bool useBanding = false, bool isReadOnly = false, bool usePermissions = false, bool canDelete = true)
	{
		this._originalKey = kvp.Key;
		this.keyField.text = kvp.Key;
		this.valueField.text = string.Format("{0}", kvp.Value);
	
		
		if(usePermissions == true)
		{
			this.permissionToggle.gameObject.SetActive(true);
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
			DeactivateRow();
		}
		else
		{
			this.keyField.interactable = true;
			this.valueField.interactable = true;
			ActivateRow();
		}
		
		this.controller = controller;
		
		if(useBanding == true)
		{
			this.banding.enabled = true;
			this.isBanded = true;
		}
		else
		{
			this.banding.enabled = false;
			this.isBanded = false;
		}
	}
	
	
	public void OnSelect(BaseEventData eventData)
	{
		Debug.Log(eventData.selectedObject.name);
	}
	
	
	
	public void OnKeyFocusGained()
	{
	
	}
	
	public void OnValueFocusGained()
	{
		
	}
	
	public void OnKeyFocusLost()
	{
		
	}
	
	public void OnValueFocusLost()
	{
		
	}
	
	public void OnPermissionClicked( bool value)
	{
		//Debug.Log("Permission clicked...");
	}
	
	public void OnDeleteClicked(bool value)
	{
		if(value == false)
		{
			this.banding.color = Color.gray;
			this.banding.enabled = this.isBanded;
			ActivateRow();
		}
		else
		{
			DeactivateRow();
			this.banding.enabled = true;
			this.banding.color = Color.red;	
		}
	}
	
	public void DeactivateRow()
	{
		this.keyField.interactable = false;
		this.valueField.interactable = false;
		this.permissionToggle.interactable = false;
	}
	
	public void ActivateRow()
	{
		this.keyField.interactable = true;
		this.valueField.interactable = true;
		this.permissionToggle.interactable = true;
	}
	
	public void ResetRow()
	{
		this.keyField.text = string.Empty;
		this._originalKey = string.Empty;
		this.valueField.text = string.Empty;
		this.permissionToggle.isOn = false;
		this.deleteToggle.isOn = false;
		
		this.keyField.interactable = false;
		this.valueField.interactable = false;
		this.permissionToggle.interactable = false;
	}
}
