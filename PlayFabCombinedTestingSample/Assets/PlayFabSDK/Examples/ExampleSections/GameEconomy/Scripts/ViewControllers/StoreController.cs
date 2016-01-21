using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;
using PlayFab.ClientModels;
using PlayFab.Examples;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreController : MonoBehaviour {
	public enum StoreControllerStates { GetCatalog, GetStore }
	public StoreControllerStates DisplayState;

	public GameObject storePanel;
	public GameObject overlayTint;
	
	public Text panelTitleBar;
	private List<Transform> itemSceneObjects = new List<Transform>();
	public Transform panelListView;
	public Transform itemPrefab;
	public string activeHelpUrl;
	
	
	public WalletController wallet;

	public StoreItemController selectedItem;

	// SET catalog and store name defaults here.
	public static string activeCatalog = string.Empty;
	public static string activeStore = string.Empty;
	public static string pendingCatalog = string.Empty;
	public static string pendingStore = string.Empty;
	
	// Use this for initialization
	void Awake () {
		activeCatalog = PfSharedModelEx.primaryCatalogVersion;
	}
	
	void OnEnable()
	{
		
		PlayFab.PlayFabSettings.RegisterForResponses(null, GetType().GetMethod("OnDataRetrieved", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
		HideStorePane();
		
		if(this.DisplayState == StoreControllerStates.GetCatalog)
		{
			if(PfSharedModelEx.isCatalogCached(activeCatalog))
			{
				ShowCatalog();
			}
			else
			{
				ChangeCatalog();
			}
		}
		else
		{
			if(PfSharedModelEx.isStoreCached(activeStore))
			{
				ShowStore();
			}
			else
			{
				ChangeStore();
			}
		}
	}
	
	public void OnDisable()
	{
		PlayFab.PlayFabSettings.UnregisterForResponses(null, GetType().GetMethod("OnDataRetrieved", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
	}
	
	public void OnDataRetrieved(string url, int callId, object request, object result, PlayFab.PlayFabError error, object customData)
	{
		if(this.gameObject.activeInHierarchy == true && this.DisplayState == StoreControllerStates.GetCatalog)
		{
			switch(url)
			{
				case "/Client/GetCatalogItems":
					Debug.Log("Catalog Viewer: GotData:" + url);
					
					if(!string.IsNullOrEmpty(pendingCatalog))
					{
						activeCatalog = pendingCatalog;
						pendingCatalog = string.Empty;
					}
					ShowCatalog();
					break;
			}
		}
		else if(this.gameObject.activeInHierarchy == true && this.DisplayState == StoreControllerStates.GetStore)
		{
			switch(url)
			{
				case "/Client/GetStoreItems":
					Debug.Log("Store Viewer: GotData:" + url);
					
					if(!string.IsNullOrEmpty(pendingStore))
					{
						activeStore = pendingStore;
						pendingStore = string.Empty;
					}
					ShowStore();
					break;
			}
		}
	}
	
	public void ChangeCatalog()
	{
		System.Action<string> afterInput = (string response) =>
		{
			if(!string.IsNullOrEmpty(response))
			{
				if(PfSharedModelEx.isCatalogCached(response))
				{
					// store already retrived, draw it
					activeCatalog = response;
					ShowCatalog();
				}
				else
				{
					// need to wait on store to load before drawing it
					pendingCatalog = response;
					PlayFab.Examples.Client.InventoryExample.LoadCatalogFromPlayFab(response);  
				}
			}
			else
			{
				activeCatalog = PfSharedModelEx.primaryCatalogVersion;
				ShowCatalog();
			}
		};
		

		SharedDialogController.RequestTextInputPrompt("Catalog Mode:","Enter the name of the catalog you wish to retrieve. (Leave blank for the primary catalog)", afterInput, pendingCatalog);

	}
	
	public void ChangeStore()
	{
		System.Action<string> afterInput = (string response) =>
		{
			if(!string.IsNullOrEmpty(response))
			{
				if(PfSharedModelEx.isStoreCached(response))
				{
					// store already retrived, draw it
					activeStore = response;
					ShowStore();
				}
				else
				{
					// need to wait on store to load before drawing it
					pendingStore = response;
					PlayFab.Examples.Client.InventoryExample.LoadStoreFromPlayFab(response, activeCatalog); 
				}
			}
			else
			{
				// enables recovery of state on the first try if the dialog is canceled
				if(this.storePanel.gameObject.activeInHierarchy == false)
				{
					this.gameObject.SetActive(false);
				}
			}
		};
		
		SharedDialogController.RequestTextInputPrompt("Store Mode:","Enter the name of the store you wish to retrieve.", afterInput, pendingStore);
	}
	
	

	
	
	/// <summary>
	/// This is a decent store system. This will not scale well with larger catalogs.
	/// </summary>
	/// <param name="stock">Stock.</param>
	public void InitStore(List<StoreItem> stock = null)
	{
		if(stock != null && stock.Count > 0)
		{
			AdjustItemPrefabs(stock.Count);
			
			int counter = 0;
			foreach(var item in stock)
			{
				StoreItemController itemController = this.itemSceneObjects[counter].GetComponent<StoreItemController>();
				
				// need to look at the corresponding catalogItem, as it has more details to display.
				CatalogItem cItem = PlayFab.Examples.PfSharedModelEx.GetCatalogItemById(item.ItemId, activeCatalog);
				
				if(cItem != null)
				{
					// swap our catalog prices with the selected store prices, because our store could have a discount or penalty.
					cItem.VirtualCurrencyPrices = item.VirtualCurrencyPrices;
					cItem.RealCurrencyPrices = item.RealCurrencyPrices;
					itemController.Init(cItem, this);
				}
				counter++;
			}
			
		}
	}
	
	public void InitCatalog(List<CatalogItem> stock = null)
	{
		//adjust item prefabs (ensure the correct # of preabs exist)
		if(stock != null)
		{
			AdjustItemPrefabs(stock.Count);
			
			int counter = 0;
			foreach(var item in stock)
			{
				StoreItemController itemController = this.itemSceneObjects[counter].GetComponent<StoreItemController>();
				itemController.Init(item, this);
				counter++;
			}
		}
	}
	
	
	
	public void AdjustItemPrefabs(int itemCount)
	{
		DeselectItems();
		if(this.itemSceneObjects.Count > itemCount)
		{
			int numToRemove = this.itemSceneObjects.Count - itemCount;
			for(int z = 0; z < numToRemove; z++)
			{
				DestroyImmediate(this.itemSceneObjects[z].gameObject);
			}
			this.itemSceneObjects.RemoveRange(0, numToRemove);
		}
		else if(this.itemSceneObjects.Count < itemCount)
		{
			int numToAdd = itemCount - this.itemSceneObjects.Count;
			for(int z = 0; z < numToAdd; z++)
			{
				Transform go = Instantiate(this.itemPrefab);
				go.SetParent(this.panelListView, false);
				
				this.itemSceneObjects.Add(go);
			}
		}
	}
	
	public void ShowStore()
	{
		this.panelTitleBar.text = string.Format("Store: \"{0}\"", activeStore);
		this.overlayTint.SetActive(true);
		this.storePanel.SetActive(true);
		InitStore(PfSharedModelEx.GetStore(activeStore));
		
		if(wallet.gameObject.activeInHierarchy)
		{
			StartCoroutine(wallet.Init());
		}
	}
		
	public void HideStorePane()
	{
		this.selectedItem = null;
		this.overlayTint.SetActive(false);
		this.storePanel.SetActive(false);
	}
	
	public void ShowCatalog()
	{
		if(string.IsNullOrEmpty(activeCatalog))
		{
			activeCatalog = PfSharedModelEx.primaryCatalogVersion; 
		}
		
		this.panelTitleBar.text = string.Format("Catalog: \"{0}\"", activeCatalog);
		this.overlayTint.SetActive(true);
		this.storePanel.SetActive(true);
		InitCatalog(PfSharedModelEx.GetCatalog(activeCatalog));
		StartCoroutine(wallet.Init());
	}
	
	public void SelectItem(StoreItemController item)
	{
		DeselectItems();
		
		this.selectedItem = item;
		this.selectedItem.buyButton.interactable = true;
		this.selectedItem.panelOutline.effectColor = this.selectedItem.selectedColor;
	}
	
	public void DeselectItems()
	{
		this.selectedItem = null;
		foreach(var item in this.itemSceneObjects)
		{
			StoreItemController sic = item.GetComponent<StoreItemController>();
			sic.buyButton.interactable = false;
			sic.panelOutline.effectColor = sic.unselectedColor;
		}
		
	}
	
	public void BuyItem(CatalogItem item)
	{
		Debug.Log("Buying: " + item.ItemId);
		var vcKvp = item.VirtualCurrencyPrices.First(); 
		
		// TODO file bug on the VC price info being a uint rather than an int.		
		if(this.DisplayState == StoreControllerStates.GetStore)
		{
			PlayFab.Examples.Client.InventoryExample.PurchaseItem(item.ItemId, vcKvp.Key, (int)vcKvp.Value, activeStore, activeCatalog);
		}
		else if(this.DisplayState == StoreControllerStates.GetCatalog)
		{
			PlayFab.Examples.Client.InventoryExample.PurchaseItem(item.ItemId, vcKvp.Key, (int)vcKvp.Value, null, activeCatalog);
		}
	}
	

	public void OpenHelpUrl()
	{
		MainExampleController.OpenWebBrowser(this.activeHelpUrl);
	}
	
	public void CloseStore()
	{
		this.gameObject.SetActive(false);
	}
	
	public void Refresh()
	{
		if(this.DisplayState == StoreControllerStates.GetCatalog)
		{
			PlayFab.Examples.Client.InventoryExample.LoadCatalogFromPlayFab(activeCatalog);
		}
		else
		{
			PlayFab.Examples.Client.InventoryExample.LoadStoreFromPlayFab(activeStore, activeCatalog);	
		}
	}
	
	public void Change()
	{
		if(this.DisplayState == StoreControllerStates.GetCatalog)
		{
			ChangeCatalog();
		}
		else
		{
			ChangeStore();	
		}
	}
}
