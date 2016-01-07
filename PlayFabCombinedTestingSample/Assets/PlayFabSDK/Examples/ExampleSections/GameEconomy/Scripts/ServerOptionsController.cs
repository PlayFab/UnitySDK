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
	
	void Awake()
	{
		//PlayFab.Examples.Client.VirtualCurrencyExample.SetUp();
		//PlayFab.Examples.Client.InventoryExample.SetUp();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnEnable()
	{
		
		//PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnInventoryLoaded, CheckToContinue);
		//PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnCatalogLoaded, CheckToContinue);
		
		// not currenty fetching a new inv.
		//Init();

			
	}
	
	
	
	public void OnDisable()
	{
		//PlayFab.Examples.PfSharedControllerEx.UnregisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnInventoryLoaded, CheckToContinue);
		//PlayFab.Examples.PfSharedControllerEx.UnregisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnCatalogLoaded, CheckToContinue);
	}
	
	public void CloseOptionsPrompt()
	{
		//this.serverOptionsPanel.gameObject.SetActive(false);
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
		foreach(var item in PlayFab.Examples.PfSharedModelEx.clientCatalog)
		{
			items.Add (item.Key, item.Value.DisplayName);
		}
		
		UnityAction<int> afterSelect = (int index) => 
		{
			string idToGive = items.ElementAt(index).Key;
			System.Action grant = PlayFab.Examples.Server.InventoryExample.GrantUserItem(PlayFab.Examples.PfSharedModelEx.globalClientUser.playFabId, idToGive);
			grant();
		};
		
		SharedDialogController.RequestSelectorPrompt("Select an item to grant", items.Values.ToList(), afterSelect);
	}
	
	public void OnRevokeItemClicked()
	{
		Dictionary<string, string> items = new Dictionary<string, string>();
		foreach(var item in PlayFab.Examples.PfSharedModelEx.globalClientUser.clientUserItems)
		{
			items.Add (item.ItemInstanceId, item.DisplayName);
		}
		
		UnityAction<int> afterSelect = (int index) => 
		{
			string idToGive = items.ElementAt(index).Key;
			System.Action revoke = PlayFab.Examples.Server.InventoryExample.RevokeUserItem(PlayFab.Examples.PfSharedModelEx.globalClientUser.playFabId, idToGive);
			revoke();
		};
		
		SharedDialogController.RequestSelectorPrompt("Select an item to revoke", items.Values.ToList(), afterSelect);
	}
	
	
	
}
