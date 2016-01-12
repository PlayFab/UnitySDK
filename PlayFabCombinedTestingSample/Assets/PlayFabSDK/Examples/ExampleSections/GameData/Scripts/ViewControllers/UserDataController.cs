using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;

using PlayFab.ClientModels;

public class UserDataController : MonoBehaviour {
	public Button UI_Add;
	public Text UI_PrivateLabel;
	public Text UI_DeleteLabel;
	
	public Transform rowPrefab;
	public Transform listView;
	
	public enum UserDataStates { Data = 0, DataRO = 1, UserPubData = 2, UserPubDataRO = 3, TitleData = 4, PublisherData = 5, Statistics = 6 }
	public UserDataStates CurrentState = UserDataStates.Data;
	
	public List<Button> tabs = new List<Button>();
	public List<UserDataRowController> rows = new List<UserDataRowController>();
	
	public bool isListDirty = false; // for use when knowing to update or not.
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnEnable()
	{
		StartCoroutine(Init ());
		//PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnInventoryLoaded, OnVCChangedEvent);
	}
	
	public void OnDisable()
	{
		//PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnInventoryLoaded, OnVCChangedEvent);
	}
	
	public IEnumerator Init()
	{
		
		RemoveItems();
		yield return new WaitForEndOfFrame();
		switch(this.CurrentState)
		{
			case UserDataStates.Data:
				DrawData();
				break;
			case UserDataStates.DataRO:
				DrawDataRo();
				break;
			case UserDataStates.UserPubData:
				DrawPubData();
				break;
			case UserDataStates.UserPubDataRO:
				DrawPubDataRo();
				break;
			case UserDataStates.TitleData:
				DrawTitleData();
				break;
			case UserDataStates.PublisherData:
				DrawPublisherData();
				break;
			case UserDataStates.Statistics:
				DrawStatistics();
				break;
		}
	}

	public void OnTabClicked(int index)
	{
		this.CurrentState = (UserDataStates)index;
		StartCoroutine(Init ());
	}
	
	void DrawData()
	{
			// setup button states (can add keys or not)
			this.UI_Add.gameObject.SetActive(true);
			this.UI_DeleteLabel.gameObject.SetActive(true);
			this.UI_PrivateLabel.gameObject.SetActive(true);
			
			if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
			{
				// Draw the User Data 
				if(PlayFab.Examples.PfSharedModelEx.currentUser.userData != null && PlayFab.Examples.PfSharedModelEx.currentUser.userData.Count > 0)
				{
					int counter = 0;
					foreach(var item in PlayFab.Examples.PfSharedModelEx.currentUser.userData)
					{
						Transform trans = Instantiate(this.rowPrefab);
						trans.SetParent(this.listView, false);
						
						UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
						
						itemController.Init (item, this, counter % 2 == 0 ? true : false, false, true, true);
						this.rows.Add(itemController); 
						counter++;
					}
				}
			}
			else
			{
				if(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterData != null && PlayFab.Examples.PfSharedModelEx.currentCharacter.characterData.Count > 0)
				{
					int counter = 0;
					foreach(var item in PlayFab.Examples.PfSharedModelEx.currentCharacter.characterData)
					{
						Transform trans = Instantiate(this.rowPrefab);
						trans.SetParent(this.listView, false);
						
						UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
						
						itemController.Init (item, this, counter % 2 == 0 ? true : false, false, true, true);
						this.rows.Add(itemController); 
						counter++;
					}
				}
			}
		}
	
	void DrawDataRo()
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(false);
		this.UI_DeleteLabel.gameObject.SetActive(false);
		this.UI_PrivateLabel.gameObject.SetActive(true);
		
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			// Draw the User Data 
			if(PlayFab.Examples.PfSharedModelEx.currentUser.userReadOnlyData != null && PlayFab.Examples.PfSharedModelEx.currentUser.userReadOnlyData.Count > 0)
			{
				int counter = 0;
				foreach(var item in PlayFab.Examples.PfSharedModelEx.currentUser.userReadOnlyData)
				{
					Transform trans = Instantiate(this.rowPrefab);
					trans.SetParent(this.listView, false);
					
					UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
					
					itemController.Init (item, this, counter % 2 == 0 ? true : false, true, true, false);
					this.rows.Add(itemController); 
					counter++;
				}
			}
		}
		else
		{
			if(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData != null && PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData.Count > 0)
			{
				int counter = 0;
				foreach(var item in PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData)
				{
					Transform trans = Instantiate(this.rowPrefab);
					trans.SetParent(this.listView, false);
					
					UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
					
					itemController.Init (item, this, counter % 2 == 0 ? true : false, true, true, false);
					this.rows.Add(itemController); 
					counter++;
				}
			}
		}
	}
	void DrawPubData()
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(true);
		this.UI_DeleteLabel.gameObject.SetActive(true);
		this.UI_PrivateLabel.gameObject.SetActive(true);
		
		// only a user variant of this data
		//		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		//		{
		// Draw the User Data 
		if(PlayFab.Examples.PfSharedModelEx.currentUser.userPublisherData != null && PlayFab.Examples.PfSharedModelEx.currentUser.userPublisherData.Count > 0)
		{
			int counter = 0;
			foreach(var item in PlayFab.Examples.PfSharedModelEx.currentUser.userPublisherData)
			{
				Transform trans = Instantiate(this.rowPrefab);
				trans.SetParent(this.listView, false);
				
				UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
				
				itemController.Init (item, this, counter % 2 == 0 ? true : false, false, true, true);
				this.rows.Add(itemController); 
				counter++;
			}
		}
		//		}
		//		else
		//		{
		//			if(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData != null && PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData.Count > 0)
		//			{
		//				int counter = 0;
		//				foreach(var item in PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData)
		//				{
		//					Transform trans = Instantiate(this.rowPrefab);
		//					trans.SetParent(this.listView, false);
		//					
		//					UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
		//					
		//					itemController.Init (item, this, counter % 2 == 0 ? true : false, true, true, false);
		//					this.rows.Add(itemController); 
		//					counter++;
		//				}
		//			}
		//		}
	}
	
	void DrawPubDataRo()
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(false);
		this.UI_DeleteLabel.gameObject.SetActive(false);
		this.UI_PrivateLabel.gameObject.SetActive(true);
		
		// only a user variant of this data
		//		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		//		{
		// Draw the User Data 
		if(PlayFab.Examples.PfSharedModelEx.currentUser.userPublisherReadOnlyData != null && PlayFab.Examples.PfSharedModelEx.currentUser.userPublisherReadOnlyData.Count > 0)
		{
			int counter = 0;
			foreach(var item in PlayFab.Examples.PfSharedModelEx.currentUser.userPublisherReadOnlyData)
			{
				Transform trans = Instantiate(this.rowPrefab);
				trans.SetParent(this.listView, false);
				
				UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
				
				itemController.Init (item, this, counter % 2 == 0 ? true : false, true, true, false);
				this.rows.Add(itemController); 
				counter++;
			}
		}
		//		}
		//		else
		//		{
		//			if(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData != null && PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData.Count > 0)
		//			{
		//				int counter = 0;
		//				foreach(var item in PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData)
		//				{
		//					Transform trans = Instantiate(this.rowPrefab);
		//					trans.SetParent(this.listView, false);
		//					
		//					UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
		//					
		//					itemController.Init (item, this, counter % 2 == 0 ? true : false, true, true, false);
		//					this.rows.Add(itemController); 
		//					counter++;
		//				}
		//			}
		//		}
	}
	
	
	void DrawTitleData()
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(false);
		this.UI_DeleteLabel.gameObject.SetActive(false);
		this.UI_PrivateLabel.gameObject.SetActive(false);
		
//		// only a user variant of this data
//		//		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
//		//		{
//		// Draw the User Data 
//		if(PlayFab.Examples.PfSharedModelEx.titleData != null && PlayFab.Examples.PfSharedModelEx.titleData.Count > 0)
//		{
//			int counter = 0;
//			foreach(var item in PlayFab.Examples.PfSharedModelEx.titleData)
//			{
//				Transform trans = Instantiate(this.rowPrefab);
//				trans.SetParent(this.listView, false);
//				
//				UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
//				
//				itemController.Init (item, this, counter % 2 == 0 ? true : false, true, false, false);
//				this.rows.Add(itemController); 
//				counter++;
//			}
//		}
//		//		}
//		//		else
//		//		{
//		//			if(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData != null && PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData.Count > 0)
//		//			{
//		//				int counter = 0;
//		//				foreach(var item in PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData)
//		//				{
//		//					Transform trans = Instantiate(this.rowPrefab);
//		//					trans.SetParent(this.listView, false);
//		//					
//		//					UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
//		//					
//		//					itemController.Init (item, this, counter % 2 == 0 ? true : false, true, true, false);
//		//					this.rows.Add(itemController); 
//		//					counter++;
//		//				}
//		//			}
//		//		}
	}
	
	void DrawPublisherData()
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(false);
		this.UI_DeleteLabel.gameObject.SetActive(false);
		this.UI_PrivateLabel.gameObject.SetActive(false);
		
		// only a user variant of this data
		//		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		//		{
		// Draw the User Data 
//		if(PlayFab.Examples.PfSharedModelEx.publisherData != null && PlayFab.Examples.PfSharedModelEx.publisherData.Count > 0)
//		{
//			int counter = 0;
//			foreach(var item in PlayFab.Examples.PfSharedModelEx.publisherData)
//			{
//				Transform trans = Instantiate(this.rowPrefab);
//				trans.SetParent(this.listView, false);
//				
//				UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
//				
//				itemController.Init (item, this, counter % 2 == 0 ? true : false, true, false, false);
//				this.rows.Add(itemController); 
//				counter++;
//			}
//		}
//		//		}
//		//		else
//		//		{
//		//			if(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData != null && PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData.Count > 0)
//		//			{
//		//				int counter = 0;
//		//				foreach(var item in PlayFab.Examples.PfSharedModelEx.currentCharacter.characterReadOnlyData)
//		//				{
//		//					Transform trans = Instantiate(this.rowPrefab);
//		//					trans.SetParent(this.listView, false);
//		//					
//		//					UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
//		//					
//		//					itemController.Init (item, this, counter % 2 == 0 ? true : false, true, true, false);
//		//					this.rows.Add(itemController); 
//		//					counter++;
//		//				}
//		//			}
//		//		}
	}
	
	
	void DrawStatistics()
	{
		// setup button states (can add keys or not)
		this.UI_Add.gameObject.SetActive(false);
		this.UI_DeleteLabel.gameObject.SetActive(false);
		this.UI_PrivateLabel.gameObject.SetActive(false);
		
		// only a user variant of this data
		//		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		//		{
		// Draw the User Data 
//		if(PlayFab.Examples.PfSharedModelEx.currentUser.userStatistics != null && PlayFab.Examples.PfSharedModelEx.currentUser.userStatistics.Count > 0)
//		{
//			int counter = 0;
//			foreach(var item in PlayFab.Examples.PfSharedModelEx.currentUser.userStatistics)
//			{
//				Transform trans = Instantiate(this.rowPrefab);
//				trans.SetParent(this.listView, false);
//				
//				UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
//				
//				itemController.Init (item, this, counter % 2 == 0 ? true : false, true, false, false);
//				this.rows.Add(itemController); 
//				counter++;
//			}
//		}
//		else
//		{
//			if(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterStatistics != null && PlayFab.Examples.PfSharedModelEx.currentCharacter.characterStatistics.Count > 0)
//			{
//				int counter = 0;
//				foreach(var item in PlayFab.Examples.PfSharedModelEx.currentCharacter.characterStatistics)
//				{
//					Transform trans = Instantiate(this.rowPrefab);
//					trans.SetParent(this.listView, false);
//					
//					UserDataRowController itemController = trans.GetComponent<UserDataRowController>();
//					
//					itemController.Init (item, this, counter % 2 == 0 ? true : false, true, true, false);
//					this.rows.Add(itemController); 
//					counter++;
//				}
//			}
//		}
	}
	
	
	
	void RemoveItems()
	{
		// maybe reuse rows, or reuse if < 15
		for(int z = 0; z < this.rows.Count; z++)
		{
			Destroy(this.rows[z].gameObject);
		}
		this.rows.Clear();
	}
	
	
	public void RefreshActiveData()
	{
		this.gameObject.SetActive(false);
	}
	
	public void AddRowToData()
	{
		this.gameObject.SetActive(false);
		//switch
	}
	
	public void SaveActiveData()
	{
	
	} 
	
	public void Close()
	{
		this.gameObject.SetActive(false);
	}
}
