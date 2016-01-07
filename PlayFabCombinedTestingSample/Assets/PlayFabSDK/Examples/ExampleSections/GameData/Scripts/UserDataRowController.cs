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
	public Button permissionToggle;
	public Button markForDelete;
	
	private UserDataController controller;
	private KeyValuePair<string, string> original = new KeyValuePair<string, string>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	
}
