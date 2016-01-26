using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using PlayFab.ClientModels;

public class ServerOptionsController : MonoBehaviour {

	public EditVCController VcController;
	public Transform ServerOptionsPanel;
	public string ActiveHelpUrl;
	
	public void CloseOptionsPrompt()
	{
		this.gameObject.SetActive(false);
	}
	
	public void OnAdjustVcBalancesClicked()
	{
		VcController.gameObject.SetActive(true);
		
		StartCoroutine(VcController.Init());
	}
	
	public void OnGrantItemClicked()
	{
		Dictionary<string, string> items = new Dictionary<string, string>();
		List<CatalogItem> catalog = PlayFab.Examples.PfSharedModelEx.GetCatalog(StoreController.ActiveCatalog);
		for(int z = 0; z < catalog.Count; z++)
		{
			items.Add(catalog[z].ItemId, catalog[z].DisplayName);
		}
		
		System.Action<int> afterSelect = (int index) => 
		{
			string idToGive = items.ElementAt(index).Key;
			PlayFab.Examples.Client.InventoryExample.GrantItem(idToGive, StoreController.ActiveCatalog);
		};
		
		SharedDialogController.RequestSelectorPrompt("Select an item to grant", items.Values.ToList(), afterSelect);
	}
	
	public void OnRevokeItemClicked()
	{
		System.Action<int> afterSelect;
		Dictionary<string, string> items = new Dictionary<string, string>();
		
		if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			foreach(var item in PlayFab.Examples.PfSharedModelEx.CurrentUser.UserInventory)
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
			foreach(var item in PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterInventory)
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
		MainExampleController.OpenWebBrowser(this.ActiveHelpUrl);
	}
}
