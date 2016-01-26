using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditVCController : MonoBehaviour {
	public Transform VcItemPrefab;
	public Transform ListView;
	public List<VCItemController> VcItems = new List<VCItemController>();
	
	public void OnEnable()
	{
		PlayFab.PlayFabSettings.RegisterForResponses(null, GetType().GetMethod("OnDataRetrieved", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
		StartCoroutine(Init ());
	}
	
	public void OnDisable()
	{
		PlayFab.PlayFabSettings.UnregisterForResponses(null, GetType().GetMethod("OnDataRetrieved", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
	}
	
	public void OnDataRetrieved(string url, int callId, object request, object result, PlayFab.PlayFabError error, object customData)
	{
		if(this.gameObject.activeInHierarchy == true && PlayFab.Examples.PfSharedModelEx.ActiveMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			switch(url)
			{
				case "/Client/GetUserInventory":
					Debug.Log("InventoryViewer: GotData:" + url);
					StartCoroutine (Init());
					break;
			}
		}
		else if(this.gameObject.activeInHierarchy == true && PlayFab.Examples.PfSharedModelEx.ActiveMode == PlayFab.Examples.PfSharedModelEx.ModelModes.Character)
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
		RemoveVcItems();
		yield return new WaitForEndOfFrame();
		if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			if(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserVc != null && PlayFab.Examples.PfSharedModelEx.CurrentUser.UserVc.Count > 0)
			{
				int counter = 0;
				foreach(var item in PlayFab.Examples.PfSharedModelEx.CurrentUser.UserVc)
				{
					Transform trans = Instantiate(this.VcItemPrefab);
					trans.SetParent(this.ListView, false);
					
					VCItemController itemController = trans.GetComponent<VCItemController>();
					
					itemController.Init (item, counter % 2 == 0 ? true : false );
					this.VcItems.Add(itemController); 
					counter++;
				}
			}
		}
		else
		{
			if(PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterVc != null && PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterVc.Count > 0)
			{
				int counter = 0;
				foreach(var item in PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterVc)
				{
					Transform trans = Instantiate(this.VcItemPrefab);
					trans.SetParent(this.ListView, false);
					
					VCItemController itemController = trans.GetComponent<VCItemController>();
					
					itemController.Init (item, counter % 2 == 0 ? true : false );
					this.VcItems.Add(itemController); 
					counter++;
				}
			}
		}
	}
	
	public void OnVcChangedEvent(string playFabId, string characterId, PlayFab.Examples.PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh )
	{
		StartCoroutine(Init ());
	}
	
	void RemoveVcItems()
	{
		for(int z = 0; z < this.VcItems.Count; z++)
		{
			Destroy(this.VcItems[z].gameObject);
		}
		this.VcItems.Clear();
	}
	
	
	public void CloseDialog()
	{
		this.gameObject.SetActive(false);
	}
}
