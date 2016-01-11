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
	  
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnEnable()
	{
		Init ();
		//PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnInventoryLoaded, OnVCChangedEvent);
	}
	
	public void OnDisable()
	{
		//PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnInventoryLoaded, OnVCChangedEvent);
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
					
					itemController.Init (item, this, counter % 2 == 0 ? true : false );
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
					
					itemController.Init (item, this, counter % 2 == 0 ? true : false );
					this.vcItems.Add(itemController); 
					counter++;
				}
			}
		}
	}
	
	//public delegate void PfControllerDelegate(string playFabId, string characterId, Api eventSourceApi, bool requiresFullRefresh);
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
