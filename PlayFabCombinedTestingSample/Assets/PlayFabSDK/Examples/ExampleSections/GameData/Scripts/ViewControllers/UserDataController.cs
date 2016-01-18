using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;


using PlayFab;
using PlayFab.ClientModels;
using System.Reflection;

public class UserDataController : MonoBehaviour {
	public Color defaultButtonColor;
	public Color selectedButtonColor;
	public Color activeFieldBorderColor;
	
	public Button UI_Add;
	public Text UI_PrivateLabel;
	public Text UI_DeleteLabel;
	public Text UI_PanelTitle;
	public Text UI_PanelDesc;
	public Text UI_EmptySet;
	
	public Transform rowPrefab;
	public Transform listView;
	
	public enum UserDataStates { Deactivated = -1, TitleData = 0, Data = 1, DataRO = 2, Statistics = 3, PublisherData = 4, UserPubData = 5, UserPubDataRO = 6}
	public UserDataStates CurrentState = UserDataStates.Deactivated;
	
	public List<Button> tabs = new List<Button>();
	public List<UserDataRowController> rows = new List<UserDataRowController>();
	
	public bool isListDirty = false; // for use when knowing to update or not.
	private int minRows = 5;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnEnable()
	{
		OnTabClicked(0);
		PlayFabSettings.RegisterForResponses(null, GetType().GetMethod("OnDataRetrieved", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
	}
	
	
	public void OnDisable()
	{
		PlayFabSettings.UnregisterForResponses(null, GetType().GetMethod("OnDataRetrieved", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
		this.CurrentState = UserDataStates.Deactivated;
	}
	
	public void OnDataRetrieved(string url, int callId, object request, object result, PlayFabError error, object customData)
	{
		//"/Client/LoginWithCustomID"
		if(this.gameObject.activeInHierarchy == true)
		{
			switch(url)
			{
				case "/Client/GetUserData":
					Debug.Log("DataViewer: GotData:" + url);
					StartCoroutine (Init());
				break;
				
				case "/Client/GetUserReadOnlyData":
					Debug.Log("DataViewer: GotData:" + url);
					StartCoroutine(Init ());
				break;
				
				case "/Client/UpdateUserData":
					Debug.Log("DataViewer: GotData:" + url);
					StartCoroutine(Init ());
				break;	
				
				case "/Client/GetUserPublisherData":
					Debug.Log("DataViewer: GotData:" + url);
					StartCoroutine(Init ());
				break;
				
				case "/Client/GetUserPublisherDataReadOnly":
					Debug.Log("DataViewer: GotData:" + url);
					StartCoroutine(Init ());
				break;
				
				case "/Client/UpdateUserPublisherData":
					Debug.Log("DataViewer: GotData:" + url);
					StartCoroutine(Init ());
				break;
				
				case "/Client/GetTitleData":
					Debug.Log("DataViewer: GotData:" + url);
					StartCoroutine(Init ());
				break;
				
				case "/Client/GetPublisherData":
					Debug.Log("DataViewer: GotData:" + url);
					StartCoroutine(Init ());
				break;
				
				case "/Client/GetUserStatistics":
					Debug.Log("DataViewer: GotData:" + url);
					StartCoroutine(Init ());
				break;
			}
		}
	}
	
	
	public IEnumerator Init()
	{
		yield return new WaitForEndOfFrame();
		
		int number;
		switch(this.CurrentState)
		{
			case UserDataStates.Data:
				if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
				{
					yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.currentUser.userData.Count));
					DrawData(PlayFab.Examples.PfSharedModelEx.currentUser.userData);
				}
				else
				{
					yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterData.Count));
					DrawData(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterData);
				}
				break;
			case UserDataStates.DataRO:
				if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
				{
					yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.currentUser.userReadOnlyData.Count));
					DrawDataRo(PlayFab.Examples.PfSharedModelEx.currentUser.userReadOnlyData);
				}
				else
				{
					yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData.Count));
					DrawDataRo(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData);
				}
				break;
			case UserDataStates.UserPubData:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.currentUser.userPublisherData.Count));
				DrawPubData(PlayFab.Examples.PfSharedModelEx.currentUser.userPublisherData);
				break;
			case UserDataStates.UserPubDataRO:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.currentUser.userPublisherReadOnlyData.Count));
			    DrawPubDataRo(PlayFab.Examples.PfSharedModelEx.currentUser.userPublisherReadOnlyData);
				break;
			case UserDataStates.TitleData:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.titleData.Count));
			    DrawTitleData(PlayFab.Examples.PfSharedModelEx.titleData);
				break;
			case UserDataStates.PublisherData:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.publisherData.Count));
			    DrawPublisherData(PlayFab.Examples.PfSharedModelEx.publisherData);
				break;
			case UserDataStates.Statistics:
				if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
				{
					yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.currentUser.userStatistics.Count));
					DrawStatistics(PlayFab.Examples.PfSharedModelEx.currentUser.userStatistics);
				}
				else
				{
					yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterStatistics.Count));
					DrawStatistics(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterStatistics);
				}
				break;
		}
	}

	public void OnTabClicked(int index)
	{
		if(index == (int)this.CurrentState)
			return;
			
		ResetTabs();
		this.CurrentState = (UserDataStates)index;
		
		tabs[index].GetComponent<Image>().color = this.selectedButtonColor;
		//Debug.Log("Tab: " + index);
		
		Text btnTxt =  tabs[index].GetComponentInChildren<Text>();
		this.UI_PanelTitle.text = btnTxt == null ? "Description" :  btnTxt.text + " Description";
		
		StartCoroutine(Init ());
	}
	
	public void ResetTabs()
	{
		foreach(var tab in tabs)
		{
			tab.GetComponent<Image>().color = this.defaultButtonColor;
		}
	}
	
	void DrawData(Dictionary<string, UserDataRecord> data)
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(true);
		this.UI_DeleteLabel.gameObject.SetActive(true);
		this.UI_PrivateLabel.gameObject.SetActive(true);
	
		if(data == null || data.Count == 0)
		{
			this.UI_EmptySet.gameObject.SetActive(true);
			return;
		}
		else
		{
			this.UI_EmptySet.gameObject.SetActive(false);
		}
		
		int counter = 0;
		foreach(KeyValuePair<string, UserDataRecord> item in data)
		{
			this.rows[counter].gameObject.SetActive(true);
			this.rows[counter].Init(item, this, counter % 2 == 0 ? true : false, false, true, true);
			counter++;
		}
	}
	
	void DrawDataRo(Dictionary<string, UserDataRecord> data)
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(false);
		this.UI_DeleteLabel.gameObject.SetActive(false);
		this.UI_PrivateLabel.gameObject.SetActive(true);
		
		if(data == null|| data.Count == 0)
		{
			this.UI_EmptySet.gameObject.SetActive(true);
			return;
		}
		else
		{
			this.UI_EmptySet.gameObject.SetActive(false);
		}
		
		int counter = 0;
		foreach(KeyValuePair<string, UserDataRecord> item in data)
		{
			this.rows[counter].gameObject.SetActive(true);
			this.rows[counter].Init(item, this, counter % 2 == 0 ? true : false, true, true, false);
			counter++;
		}
	}
	
	void DrawPubData(Dictionary<string, UserDataRecord> data)
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(true);
		this.UI_DeleteLabel.gameObject.SetActive(true);
		this.UI_PrivateLabel.gameObject.SetActive(true);
		
		if(data == null|| data.Count == 0)
		{
			this.UI_EmptySet.gameObject.SetActive(true);
			return;
		}
		else
		{
			this.UI_EmptySet.gameObject.SetActive(false);
		}
		
		int counter = 0;
		foreach(KeyValuePair<string, UserDataRecord> item in data)
		{
			this.rows[counter].gameObject.SetActive(true);
			this.rows[counter].Init(item, this, counter % 2 == 0 ? true : false, false, true, true);
			counter++;
		}
	}
	
	void DrawPubDataRo(Dictionary<string, UserDataRecord> data)
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(false);
		this.UI_DeleteLabel.gameObject.SetActive(false);
		this.UI_PrivateLabel.gameObject.SetActive(true);
		 
		if(data == null|| data.Count == 0)
		{
			this.UI_EmptySet.gameObject.SetActive(true);
			return;
		}
		else
		{
			this.UI_EmptySet.gameObject.SetActive(false);
		}
		
		int counter = 0;
		foreach(KeyValuePair<string, UserDataRecord> item in data)
		{
			this.rows[counter].gameObject.SetActive(true);
			this.rows[counter].Init(item, this, counter % 2 == 0 ? true : false, true, true, false);
			counter++;
		}
	}
	
	void DrawTitleData(Dictionary<string, string> data)
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(false);
		this.UI_DeleteLabel.gameObject.SetActive(false);
		this.UI_PrivateLabel.gameObject.SetActive(false);
		
		if(data == null|| data.Count == 0)
		{
			this.UI_EmptySet.gameObject.SetActive(true);
			return;
		}
		else
		{
			this.UI_EmptySet.gameObject.SetActive(false);
		}
		
		int counter = 0;
		foreach(KeyValuePair<string, string> item in data)
		{
			this.rows[counter].gameObject.SetActive(true);
			this.rows[counter].Init(item, this, counter % 2 == 0 ? true : false, true, false, false);
			counter++;
		}
	}
	
	void DrawPublisherData(Dictionary<string, string> data)
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(false);
		this.UI_DeleteLabel.gameObject.SetActive(false);
		this.UI_PrivateLabel.gameObject.SetActive(false);
	}
	
	
	void DrawStatistics(Dictionary<string, int> data)
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(false);
		this.UI_DeleteLabel.gameObject.SetActive(false);
		this.UI_PrivateLabel.gameObject.SetActive(false);
		
		if(data == null|| data.Count == 0)
		{
			this.UI_EmptySet.gameObject.SetActive(true);
			return;
		}
		else
		{
			this.UI_EmptySet.gameObject.SetActive(false);
		}
		
		int counter = 0;
		foreach(KeyValuePair<string, int> item in data)
		{
			this.rows[counter].gameObject.SetActive(true);
			this.rows[counter].Init(item, this, counter % 2 == 0 ? true : false, true, false, false);
			counter++;
		}
	}
	
	
	IEnumerator AdjustItems(int count)
	{
		if(rows.Count > count)
		{
			for(int z = 0; z < this.rows.Count - count; z++)
			{
				if(this.rows.Count > this.minRows)
				{
			   		Destroy(this.rows[z].gameObject);
			   		this.rows.RemoveAt(z);
			   	}
			}
		}
		else if (rows.Count < count)
		{
			int rowsCreated = 0;
			while(this.rows.Count < count)
			{
				Transform trans = Instantiate(this.rowPrefab);
				trans.SetParent(this.listView, false);
				
				UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
				
				itemController.Init (new KeyValuePair<string, UserDataRecord>("____", new UserDataRecord()), this, rowsCreated % 2 == 0 ? true : false, false, false, false);
				this.rows.Add(itemController); 
				rowsCreated++;
				
			}
			Debug.Log("Row Created: " + rowsCreated);
		}
		
		// hide objects, will turn on when they are needed
		for(int z = 0; z < this.rows.Count; z++)
		{
			this.rows[z].ResetRow();
			this.rows[z].gameObject.SetActive(false);
		}
		yield break;
	}
	
	
	public void RefreshActiveData()
	{
		switch(this.CurrentState)
		{
			case UserDataStates.Data:
				if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
				{
					PlayFab.Examples.Client.UserDataExample.GetUserData();
				}
				else
				{
					PlayFab.Examples.Client.UserDataExample.GetActiveCharacterData();
				}
				break;
			case UserDataStates.DataRO:
				if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
				{
					PlayFab.Examples.Client.UserDataExample.GetUserReadOnlyData();
				}
				else
				{
					PlayFab.Examples.Client.UserDataExample.GetActiveCharacterReadOnlyData();
				}
				break;
			case UserDataStates.UserPubData:
				PlayFab.Examples.Client.UserDataExample.GetUserPublisherData();
				break;
			case UserDataStates.UserPubDataRO:
				PlayFab.Examples.Client.UserDataExample.GetUserPublisherReadOnlyData();
				break;
			case UserDataStates.TitleData:
				PlayFab.Examples.Client.TitleDataExample.GetTitleData();
				break;
			case UserDataStates.PublisherData:
				PlayFab.Examples.Client.TitleDataExample.GetPublisherData();
				break;
			case UserDataStates.Statistics:
				if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
				{
					PlayFab.Examples.Client.StatsExample.GetUserStatistics();
				}
				else
				{
					PlayFab.Examples.Client.StatsExample.GetCharacterStatistics();
				}
				break;
		}
	}
	
	public void AddRowToData()
	{
		Transform trans = Instantiate(this.rowPrefab);
		trans.SetParent(this.listView, false);
		
		UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
		bool usePermissions = true;
		bool enableDelete = true;
		
		if(this.CurrentState == UserDataStates.Statistics || this.CurrentState == UserDataStates.TitleData || this.CurrentState == UserDataStates.PublisherData )
		{
			enableDelete = false;
			usePermissions = false;
		}
		else if(this.CurrentState == UserDataStates.DataRO || this.CurrentState == UserDataStates.UserPubDataRO)
		{
			enableDelete = false;
		}
		
		itemController.Init (new KeyValuePair<string, UserDataRecord>("",new UserDataRecord()), this, this.rows.Count % 2 == 0 ? true : false, false, usePermissions, enableDelete);
		this.rows.Add(itemController); 
	}
	
	public void SaveActiveData()
	{
		List<string> keysToDelete = new List<string>();
		Dictionary<string, string> publicKeysToSave = new Dictionary<string, string>(); 
		Dictionary<string, string> privateKeysToSave = new Dictionary<string, string>(); 
		
		for(var z = 0; z < this.rows.Count; z++)
		{
			// get deletes
			if(rows[z].deleteToggle.isOn)
			{
				keysToDelete.Add(rows[z].originalKey);
				continue;
			}
			
			//ignore deactivated rows
			if(rows[z].gameObject.activeInHierarchy == false)
			{
				continue;
			}
			
			//remove blank keys & build the save dict
			if(!string.IsNullOrEmpty(rows[z].keyField.text))
			{
				if(rows[z].keyField.text != rows[z].originalKey && rows[z].isNewRecord != true)
				{
					// the key has been changed, delete the old one and add new one.
					Debug.Log(string.Format("Key:{0}, deleted due to mismatch, {1} added in it's place.", rows[z].originalKey, rows[z].keyField.text));
					keysToDelete.Add(rows[z].originalKey);
					
					if(rows[z].permissionToggle.isOn)
					{
						privateKeysToSave.Add(rows[z].keyField.text, rows[z].valueField.text);
					}
					else
					{
						publicKeysToSave.Add(rows[z].keyField.text, rows[z].valueField.text);
					}
				}
				else
				{
					if(rows[z].permissionToggle.isOn)
					{
						privateKeysToSave.Add(rows[z].keyField.text, rows[z].valueField.text);
					}
					else
					{
						publicKeysToSave.Add(rows[z].keyField.text, rows[z].valueField.text);
					}
				}
			}
		}
		
		switch(this.CurrentState)
		{
			case UserDataStates.Data:
				SaveData(publicKeysToSave, privateKeysToSave, keysToDelete);
				break;
			case UserDataStates.UserPubData:
				SavePubData(publicKeysToSave, privateKeysToSave, keysToDelete);
				break;
			case UserDataStates.Statistics:
				SaveStatistics(publicKeysToSave, privateKeysToSave, keysToDelete);
				break;
		}
	} 
	
	//
	public void SaveData(Dictionary<string, string> publicData,  Dictionary<string, string> privateData, List<string> deleteKeys = null)
	{
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			if(privateData.Count > 0)
			{
				PlayFab.Examples.Client.UserDataExample.UpdateUserData(privateData, true, deleteKeys);
				deleteKeys.Clear(); // clear so that we do not try and delete these keys twice
			}

			PlayFab.Examples.Client.UserDataExample.UpdateUserData(publicData, false, deleteKeys);
		}
		else
		{
			if(privateData.Count > 0)
			{
				PlayFab.Examples.Client.UserDataExample.UpdateActiveCharacterData(privateData, true, deleteKeys);
				deleteKeys.Clear(); // clear so that we do not try and delete these keys twice
			}
			
			PlayFab.Examples.Client.UserDataExample.UpdateActiveCharacterData(publicData, false, deleteKeys);
		}
	}
	
	//
	public void SavePubData(Dictionary<string, string> publicData,  Dictionary<string, string> privateData, List<string> deleteKeys = null)
	{
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			if(privateData.Count > 0)
			{
				PlayFab.Examples.Client.UserDataExample.UpdateUserPublisherData(privateData, true, deleteKeys);
				deleteKeys.Clear(); // clear so that we do not try and delete these keys twice
			}
			
			PlayFab.Examples.Client.UserDataExample.UpdateUserPublisherData(publicData, false, deleteKeys);
		}
	}
	
	//
	public void SaveStatistics(Dictionary<string, string> publicData,  Dictionary<string, string> privateData, List<string> deleteKeys = null)
	{
		// not setting this up yet... but will take place in cloud script
		//		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		//		{
		//			PlayFab.Examples.Client.UserDataExample.UpdateStatistics(data, deleteKeys);
		//		}
		//		else
		//		{
		//			PlayFab.Examples.Client.UserDataExample.UpdateStatistics(data, deleteKeys);
		//		}
	}
	
	
	//
	public void Close()
	{
		this.gameObject.SetActive(false);
	}
}
