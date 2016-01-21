using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;

using PlayFab.ClientModels;

public class EditVCController : MonoBehaviour {
	public Transform vcItemPrefab;
	public Transform listView;
	public List<VCItemController> vcItems = new List<VCItemController>();
	
	public void OnEnable()
	{
		PlayFab.PlayFabSettings.RegisterForResponses(null, GetType().GetMethod("OnDataRetrieved", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
		Init ();
	}
	
	public void OnDisable()
	{
		PlayFab.PlayFabSettings.UnregisterForResponses(null, GetType().GetMethod("OnDataRetrieved", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
	}
	
	public void OnDataRetrieved(string url, int callId, object request, object result, PlayFab.PlayFabError error, object customData)
	{
		if(this.gameObject.activeInHierarchy == true && PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			switch(url)
			{
				case "/Client/GetUserInventory":
					Debug.Log("InventoryViewer: GotData:" + url);
					StartCoroutine (Init());
					break;
			}
		}
		else if(this.gameObject.activeInHierarchy == true && PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.Character)
		{
			switch(url)
			{
				case "/Client/GetCharacterInventory":
					Debug.Log("InventoryViewer: GotData:" + url);
					StartCoroutine (Init());
					break;
			}
		}
	}
	
	
	public IEnumerator Init()
	{
		RemoveVCItems();
		yield return new WaitForEndOfFrame();
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			if(PlayFab.Examples.PfSharedModelEx.currentUser.userVC != null && PlayFab.Examples.PfSharedModelEx.currentUser.userVC.Count > 0)
			{
				int counter = 0;
				foreach(var item in PlayFab.Examples.PfSharedModelEx.currentUser.userVC)
				{
					Transform trans = Instantiate(this.vcItemPrefab);
					trans.SetParent(this.listView, false);
					
					VCItemController itemController = trans.GetComponent<VCItemController>();
					
					itemController.Init (item, counter % 2 == 0 ? true : false );
					this.vcItems.Add(itemController); 
					counter++;
				}
			}
		}
		else
		{
			if(PlayFab.Examples.PfSharedModelEx.currentCharacter.characterVC != null && PlayFab.Examples.PfSharedModelEx.currentCharacter.characterVC.Count > 0)
			{
				int counter = 0;
				foreach(var item in PlayFab.Examples.PfSharedModelEx.currentCharacter.characterVC)
				{
					Transform trans = Instantiate(this.vcItemPrefab);
					trans.SetParent(this.listView, false);
					
					VCItemController itemController = trans.GetComponent<VCItemController>();
					
					itemController.Init (item, counter % 2 == 0 ? true : false );
					this.vcItems.Add(itemController); 
					counter++;
				}
			}
		}
	}
	
	public void OnVCChangedEvent(string playFabId, string characterId, PlayFab.Examples.PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh )
	{
		StartCoroutine(Init ());
	}
	
	void RemoveVCItems()
	{
		for(int z = 0; z < this.vcItems.Count; z++)
		{
			Destroy(this.vcItems[z].gameObject);
		}
		this.vcItems.Clear();
	}
	
	
	public void CloseDialog()
	{
		this.gameObject.SetActive(false);
	}
}
