using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;

using PlayFab.ClientModels;

public class ServerOptionsController : MonoBehaviour {

	public EditVCController vcController;
	public Transform serverOptionsPanel;
	public string activeHelpUrl;
	
	void Awake()
	{}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnEnable()
	{}
	
	
	
	public void OnDisable()
	{}
	
	public void CloseOptionsPrompt()
	{
		this.gameObject.SetActive(false);
	}
	
	
	public void OnAdjustVCBalancesClicked()
	{
		vcController.gameObject.SetActive(true);
		
		StartCoroutine(vcController.Init());
	}
	
	public void OnGrantItemClicked()
	{
		Dictionary<string, string> items = new Dictionary<string, string>();
		List<CatalogItem> catalog = PlayFab.Examples.PfSharedModelEx.GetCatalog(StoreController.activeCatalog);
		for(int z = 0; z < catalog.Count; z++)
		{
			items.Add(catalog[z].ItemId, catalog[z].DisplayName);
		}
		
		System.Action<int> afterSelect = (int index) => 
		{
			string idToGive = items.ElementAt(index).Key;
			PlayFab.Examples.Client.InventoryExample.GrantItem(idToGive, StoreController.activeCatalog);
		};
		
		SharedDialogController.RequestSelectorPrompt("Select an item to grant", items.Values.ToList(), afterSelect);
	}
	
	public void OnRevokeItemClicked()
	{
		System.Action<int> afterSelect;
		Dictionary<string, string> items = new Dictionary<string, string>();
		
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			foreach(var item in PlayFab.Examples.PfSharedModelEx.currentUser.userInventory)
			{
				items.Add (item.ItemInstanceId, item.DisplayName);
			}
			
			afterSelect = (int index) => 
			{
				string idToRevoke = items.ElementAt(index).Key;
				PlayFab.Examples.Client.InventoryExample.RevokeItem(idToRevoke);
			};
		}
		else
		{
			foreach(var item in PlayFab.Examples.PfSharedModelEx.currentCharacter.characterInventory)
			{
				items.Add (item.ItemInstanceId, item.DisplayName);
			}
			
			afterSelect = (int index) => 
			{
				string idToRevoke = items.ElementAt(index).Key;
				PlayFab.Examples.Client.InventoryExample.RevokeItem(idToRevoke);
			};
		}
		SharedDialogController.RequestSelectorPrompt("Select an item to revoke", items.Values.ToList(), afterSelect);
	}
	
	public void OpenHelpUrl()
	{
		MainExampleController.OpenWebBrowser(this.activeHelpUrl);
	}
}
