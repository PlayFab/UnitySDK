using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class UserDataController : MonoBehaviour {
	public Color DefaultButtonColor;
	public Color SelectedButtonColor;
	public Color ActiveFieldBorderColor;
	
	public Button AddButton;
	public Text PrivateLabel;
	public Text DeleteLabel;
	public Text PanelTitle;
	public Text PanelDesc;
	public Text EmptySet;
	
	public string ActiveHelpUrl;
	
	public Transform RowPrefab;
	public Transform ListView;
	
	public enum UserDataStates 
	{ 
		Deactivated = -1, 
		TitleData = 0,
		UserData = 1, 
		CharData = 2,
		UserDataRO = 3,
		CharDataRO = 4,
		UserStatistics = 5,
		CharStatistics = 6,
		PublisherData = 7, 
		UserPubData = 8, 
		UserPubDataRO = 9
	}
	
	public UserDataStates CurrentState = UserDataStates.Deactivated;
	
	public List<Button> Tabs = new List<Button>();
	public List<UserDataRowController> Rows = new List<UserDataRowController>();
	
	//public bool isListDirty = false; // for use when knowing to update or not.
	private int _minRows = 5;
	
	
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
		
		switch(this.CurrentState)
		{
			case UserDataStates.UserData:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserData.Count));
				DrawData(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserData);
				break;
				
			case UserDataStates.CharData:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterData.Count));
				DrawData(PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterData);
				break;
				
			case UserDataStates.UserDataRO:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserReadOnlyData.Count));
				DrawDataRo(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserReadOnlyData);
				break;
			
			case UserDataStates.CharDataRO:	
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterReadOnlyData.Count));
				DrawDataRo(PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterReadOnlyData);
				break;
				
			case UserDataStates.UserPubData:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserPublisherData.Count));
				DrawPubData(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserPublisherData);
				break;
				
			case UserDataStates.UserPubDataRO:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserPublisherReadOnlyData.Count));
			    DrawPubDataRo(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserPublisherReadOnlyData);
				break;
				
			case UserDataStates.TitleData:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.TitleData.Count));
			    DrawTitleData(PlayFab.Examples.PfSharedModelEx.TitleData);
				break;
				
			case UserDataStates.PublisherData:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.PublisherData.Count));
			    DrawPublisherData(PlayFab.Examples.PfSharedModelEx.PublisherData);
				break;
				
			case UserDataStates.UserStatistics:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserStatistics.Count));
				DrawStatistics(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserStatistics);
				break;
			
			case UserDataStates.CharStatistics:
				yield return StartCoroutine(AdjustItems(PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterStatistics.Count));
				DrawStatistics(PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterStatistics);
				break;
		 }
	}

	public void OnTabClicked(int index)
	{
		ResetTabs();
		
		bool useCharacter = false;
		if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PlayFab.Examples.PfSharedModelEx.ModelModes.Character)
		{
			useCharacter = true;
		}
		
		switch(index)
		{
			//TitleData
			case 0:
				this.CurrentState = UserDataStates.TitleData;
			break;
			
			//UserData
			case 1:
				this.CurrentState = useCharacter ? UserDataStates.CharData : UserDataStates.UserData;
			break;
			
			//UserDataRO
			case 2:
				this.CurrentState = useCharacter ? UserDataStates.CharDataRO : UserDataStates.UserDataRO;
			break;		
			
			//Statistics
			case 3:
				this.CurrentState = useCharacter ? UserDataStates.CharStatistics : UserDataStates.UserStatistics;
			break;
			
			//PublisherData
			case 4:
				this.CurrentState = UserDataStates.PublisherData;
			break;
			
			//UserPublisherData
			case 5:
				this.CurrentState = UserDataStates.UserPubData;
			break;
			
			//UserPublisherDataRO
			case 6:
				this.CurrentState = UserDataStates.UserPubDataRO;
			break;
		}	
		
		DataTabInfo info = Tabs[index].GetComponent<DataTabInfo>();
		this.PanelTitle.text = info.Title + " Description";
		this.PanelDesc.text = info.Description;
		this.ActiveHelpUrl = info.HelpUrl;
		
		Tabs[index].GetComponent<Image>().color = this.SelectedButtonColor;
		
		StartCoroutine(Init ());
	}
	
	public void ResetTabs()
	{
		foreach(var tab in Tabs)
		{
			tab.GetComponent<Image>().color = this.DefaultButtonColor;
		}
	}
	
	void DrawData(Dictionary<string, UserDataRecord> data)
	{
		// setup button states (can add keys or not)
		this.AddButton.gameObject.SetActive(true);
		this.DeleteLabel.gameObject.SetActive(true);
		this.PrivateLabel.gameObject.SetActive(true);
	
		bool hideObj = (data == null || data.Count == 0);
		this.EmptySet.gameObject.SetActive(hideObj);
		if (hideObj) return;
		
		int counter = 0;
		foreach(KeyValuePair<string, UserDataRecord> item in data)
		{
			this.Rows[counter].gameObject.SetActive(true);
			this.Rows[counter].Init(item, this, counter % 2 == 0 ? true : false, false, true, true);
			counter++;
		}
	}
	
	void DrawDataRo(Dictionary<string, UserDataRecord> data)
	{
		// setup button states (can add keys or not)
		this.AddButton.gameObject.SetActive(false);
		this.DeleteLabel.gameObject.SetActive(false);
		this.PrivateLabel.gameObject.SetActive(true);
		
		bool hideObj = (data == null || data.Count == 0);
		this.EmptySet.gameObject.SetActive(hideObj);
		if (hideObj) return;
		
		int counter = 0;
		foreach(KeyValuePair<string, UserDataRecord> item in data)
		{
			this.Rows[counter].gameObject.SetActive(true);
			this.Rows[counter].Init(item, this, counter % 2 == 0 ? true : false, true, true, false);
			counter++;
		}
	}
	
	void DrawPubData(Dictionary<string, UserDataRecord> data)
	{
		// setup button states (can add keys or not)
		this.AddButton.gameObject.SetActive(true);
		this.DeleteLabel.gameObject.SetActive(true);
		this.PrivateLabel.gameObject.SetActive(true);
		
		bool hideObj = (data == null || data.Count == 0);
		this.EmptySet.gameObject.SetActive(hideObj);
		if (hideObj) return;
		
		int counter = 0;
		foreach(KeyValuePair<string, UserDataRecord> item in data)
		{
			this.Rows[counter].gameObject.SetActive(true);
			this.Rows[counter].Init(item, this, counter % 2 == 0 ? true : false, false, true, true);
			counter++;
		}
	}
	
	void DrawPubDataRo(Dictionary<string, UserDataRecord> data)
	{
		// setup button states (can add keys or not)
		this.AddButton.gameObject.SetActive(false);
		this.DeleteLabel.gameObject.SetActive(false);
		this.PrivateLabel.gameObject.SetActive(true);
		 
		bool hideObj = (data == null || data.Count == 0);
		this.EmptySet.gameObject.SetActive(hideObj);
		if (hideObj) return;
		
		int counter = 0;
		foreach(KeyValuePair<string, UserDataRecord> item in data)
		{
			this.Rows[counter].gameObject.SetActive(true);
			this.Rows[counter].Init(item, this, counter % 2 == 0 ? true : false, true, true, false);
			counter++;
		}
	}
	
	void DrawTitleData(Dictionary<string, string> data)
	{
		// setup button states (can add keys or not)
		this.AddButton.gameObject.SetActive(false);
		this.DeleteLabel.gameObject.SetActive(false);
		this.PrivateLabel.gameObject.SetActive(false);
		
		bool hideObj = (data == null || data.Count == 0);
		this.EmptySet.gameObject.SetActive(hideObj);
		if (hideObj) return;
		
		int counter = 0;
		foreach(KeyValuePair<string, string> item in data)
		{
			this.Rows[counter].gameObject.SetActive(true);
			this.Rows[counter].Init(item, this, counter % 2 == 0 ? true : false, true, false, false);
			counter++;
		}
	}
	
	void DrawPublisherData(Dictionary<string, string> data)
	{
		// setup button states (can add keys or not)
		this.AddButton.gameObject.SetActive(false);
		this.DeleteLabel.gameObject.SetActive(false);
		this.PrivateLabel.gameObject.SetActive(false);
	}
	
	
	void DrawStatistics(Dictionary<string, int> data)
	{
		// setup button states (can add keys or not)
		this.AddButton.gameObject.SetActive(false);
		this.DeleteLabel.gameObject.SetActive(false);
		this.PrivateLabel.gameObject.SetActive(false);
		
		bool hideObj = (data == null || data.Count == 0);
		this.EmptySet.gameObject.SetActive(hideObj);
		if (hideObj) return;
		
		int counter = 0;
		foreach(KeyValuePair<string, int> item in data)
		{
			this.Rows[counter].gameObject.SetActive(true);
			this.Rows[counter].Init(item, this, counter % 2 == 0 ? true : false, true, false, false);
			counter++;
		}
	}
	
	
	IEnumerator AdjustItems(int count)
	{
		if(Rows.Count > count)
		{
			for(int z = 0; z < this.Rows.Count - count; z++)
			{
				if(this.Rows.Count > this._minRows)
				{
			   		Destroy(this.Rows[z].gameObject);
			   		this.Rows.RemoveAt(z);
			   	}
			}
		}
		else if (Rows.Count < count)
		{
			int rowsCreated = 0;
			while(this.Rows.Count < count)
			{
				Transform trans = Instantiate(this.RowPrefab);
				trans.SetParent(this.ListView, false);
				
				UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
				
				itemController.Init (new KeyValuePair<string, UserDataRecord>("____", new UserDataRecord()), this, rowsCreated % 2 == 0 ? true : false, false, false, false);
				this.Rows.Add(itemController); 
				rowsCreated++;
				
			}
			Debug.Log("Row Created: " + rowsCreated);
		}
		
		// hide objects, will turn on when they are needed
		for(int z = 0; z < this.Rows.Count; z++)
		{
			this.Rows[z].ResetRow();
			this.Rows[z].gameObject.SetActive(false);
		}
		yield break;
	}
	
	
	public void RefreshActiveData()
	{
		switch(this.CurrentState)
		{
			case UserDataStates.UserData:
				PlayFab.Examples.Client.UserDataExample.GetUserData();
				break;
			case UserDataStates.CharData:
				PlayFab.Examples.Client.UserDataExample.GetActiveCharacterData();
				break;
			case UserDataStates.UserDataRO:
				PlayFab.Examples.Client.UserDataExample.GetUserReadOnlyData();
				break;
			case UserDataStates.CharDataRO:
				PlayFab.Examples.Client.UserDataExample.GetActiveCharacterReadOnlyData();
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
			case UserDataStates.UserStatistics:
				PlayFab.Examples.Client.StatsExample.GetUserStatistics();
				break;
			case UserDataStates.CharStatistics:
				PlayFab.Examples.Client.StatsExample.GetCharacterStatistics();
				break;
		}
	}
	
	public void AddRowToData()
	{
		Transform trans = Instantiate(this.RowPrefab);
		trans.SetParent(this.ListView, false);
		
		UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
		bool usePermissions = true;
		bool enableDelete = true;
		
		if(this.CurrentState == UserDataStates.UserStatistics || this.CurrentState == UserDataStates.CharStatistics || this.CurrentState == UserDataStates.TitleData || this.CurrentState == UserDataStates.PublisherData )
		{
			enableDelete = false;
			usePermissions = false;
		}
		else if(this.CurrentState == UserDataStates.UserDataRO || this.CurrentState == UserDataStates.CharDataRO || this.CurrentState == UserDataStates.UserPubDataRO)
		{
			enableDelete = false;
		}
		
		itemController.Init (new KeyValuePair<string, UserDataRecord>("",new UserDataRecord()), this, this.Rows.Count % 2 == 0 ? true : false, false, usePermissions, enableDelete);
		this.Rows.Add(itemController); 
	}
	
	public void SaveActiveData()
	{
		List<string> keysToDelete = new List<string>();
		Dictionary<string, string> publicKeysToSave = new Dictionary<string, string>(); 
		Dictionary<string, string> privateKeysToSave = new Dictionary<string, string>(); 
		
		for(var z = 0; z < this.Rows.Count; z++)
		{
			// get deletes
			if(Rows[z].deleteToggle.isOn)
			{
				keysToDelete.Add(Rows[z].originalKey);
				continue;
			}
			
			//ignore deactivated rows
			if(Rows[z].gameObject.activeInHierarchy == false)
			{
				continue;
			}
			
			//remove blank keys & build the save dict
			if(!string.IsNullOrEmpty(Rows[z].keyField.text))
			{
				if(Rows[z].keyField.text != Rows[z].originalKey && Rows[z].isNewRecord != true)
				{
					// the key has been changed, delete the old one and add new one.
					Debug.Log(string.Format("Key:{0}, deleted due to mismatch, {1} added in it's place.", Rows[z].originalKey, Rows[z].keyField.text));
					keysToDelete.Add(Rows[z].originalKey);
					
					if(Rows[z].permissionToggle.isOn)
					{
						privateKeysToSave.Add(Rows[z].keyField.text, Rows[z].valueField.text);
					}
					else
					{
						publicKeysToSave.Add(Rows[z].keyField.text, Rows[z].valueField.text);
					}
				}
				else
				{
					if(Rows[z].permissionToggle.isOn)
					{
						privateKeysToSave.Add(Rows[z].keyField.text, Rows[z].valueField.text);
					}
					else
					{
						publicKeysToSave.Add(Rows[z].keyField.text, Rows[z].valueField.text);
					}
				}
			}
		}
		
		
		if(this.CurrentState == UserDataStates.UserData || this.CurrentState== UserDataStates.CharData)
		{
			SaveData(publicKeysToSave, privateKeysToSave, keysToDelete);
		}
		else if(this.CurrentState == UserDataStates.UserPubData)
		{
			SavePubData(publicKeysToSave, privateKeysToSave, keysToDelete);
		}
		else if(this.CurrentState == UserDataStates.UserStatistics || this.CurrentState== UserDataStates.CharStatistics)
		{
			SaveStatistics(publicKeysToSave, privateKeysToSave, keysToDelete);
		}
	} 
	
	//
	public void SaveData(Dictionary<string, string> publicData,  Dictionary<string, string> privateData, List<string> deleteKeys = null)
	{
		if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
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
		if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			if(privateData.Count > 0)
			{
				PlayFab.Examples.Client.UserDataExample.UpdateUserPublisherData(privateData, true, deleteKeys);
				deleteKeys.Clear(); // clear so that we do not try and delete these keys twice
			}
			
			PlayFab.Examples.Client.UserDataExample.UpdateUserPublisherData(publicData, false, deleteKeys);
		}
	}
	
	public void GetHelp()
	{
		PlayFab.Examples.PfSharedControllerEx.OpenHelpUrl(this.ActiveHelpUrl);
	}
	
	
	//
	public void SaveStatistics(Dictionary<string, string> publicData,  Dictionary<string, string> privateData, List<string> deleteKeys = null)
	{
		throw new System.NotImplementedException();
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
