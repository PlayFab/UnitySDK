using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using PlayFab.ClientModels;
using PlayFab.Examples;
using UnityEngine.UI;


public class StoreController : MonoBehaviour {
	public enum StoreControllerStates { GetCatalog, GetStore }
	public StoreControllerStates DisplayState;

	public GameObject StorePanel;
	public GameObject OverlayTint;
	
	public Text PanelTitleBar;
	private readonly List<Transform> _itemSceneObjects = new List<Transform>();
	public Transform PanelListView;
	public Transform ItemPrefab;
	public string ActiveHelpUrl;
	
	
	public WalletController Wallet;

	public StoreItemController SelectedItem;

	// SET catalog and store name defaults here.
	public static string ActiveCatalog = string.Empty;
	public static string ActiveStore = string.Empty;
	public static string PendingCatalog = string.Empty;
	public static string PendingStore = string.Empty;
	
	// Use this for initialization
	void Awake () {
		ActiveCatalog = PfSharedModelEx.PrimaryCatalogVersion;
	}
	
	void OnEnable()
	{
		
		PlayFab.PlayFabSettings.RegisterForResponses(null, GetType().GetMethod("OnDataRetrieved", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
		HideStorePane();
		
		if(this.DisplayState == StoreControllerStates.GetCatalog)
		{
			if(PfSharedModelEx.IsCatalogCached(ActiveCatalog))
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
			if(PfSharedModelEx.IsStoreCached(ActiveStore))
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
					
					if(!string.IsNullOrEmpty(PendingCatalog))
					{
						ActiveCatalog = PendingCatalog;
						PendingCatalog = string.Empty;
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
					
					if(!string.IsNullOrEmpty(PendingStore))
					{
						ActiveStore = PendingStore;
						PendingStore = string.Empty;
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
				if(PfSharedModelEx.IsCatalogCached(response))
				{
					// store already retrived, draw it
					ActiveCatalog = response;
					ShowCatalog();
				}
				else
				{
					// need to wait on store to load before drawing it
					PendingCatalog = response;
					PlayFab.Examples.Client.InventoryExample.LoadCatalogFromPlayFab(response);  
				}
			}
			else
			{
				ActiveCatalog = PfSharedModelEx.PrimaryCatalogVersion;
				ShowCatalog();
			}
		};
		

		SharedDialogController.RequestTextInputPrompt("Catalog Mode:","Enter the name of the catalog you wish to retrieve. (Leave blank for the primary catalog)", afterInput, PendingCatalog);

	}
	
	public void ChangeStore()
	{
		System.Action<string> afterInput = (string response) =>
		{
			if(!string.IsNullOrEmpty(response))
			{
				if(PfSharedModelEx.IsStoreCached(response))
				{
					// store already retrived, draw it
					ActiveStore = response;
					ShowStore();
				}
				else
				{
					// need to wait on store to load before drawing it
					PendingStore = response;
					PlayFab.Examples.Client.InventoryExample.LoadStoreFromPlayFab(response, ActiveCatalog); 
				}
			}
			else
			{
				// enables recovery of state on the first try if the dialog is canceled
				if(this.StorePanel.gameObject.activeInHierarchy == false)
				{
					this.gameObject.SetActive(false);
				}
			}
		};
		
		SharedDialogController.RequestTextInputPrompt("Store Mode:","Enter the name of the store you wish to retrieve.", afterInput, PendingStore);
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
				StoreItemController itemController = this._itemSceneObjects[counter].GetComponent<StoreItemController>();
				
				// need to look at the corresponding catalogItem, as it has more details to display.
				CatalogItem cItem = PlayFab.Examples.PfSharedModelEx.GetCatalogItemById(item.ItemId, ActiveCatalog);
				
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
				StoreItemController itemController = this._itemSceneObjects[counter].GetComponent<StoreItemController>();
				itemController.Init(item, this);
				counter++;
			}
		}
	}
	
	
	
	public void AdjustItemPrefabs(int itemCount)
	{
		DeselectItems();
		if(this._itemSceneObjects.Count > itemCount)
		{
			int numToRemove = this._itemSceneObjects.Count - itemCount;
			for(int z = 0; z < numToRemove; z++)
			{
				DestroyImmediate(this._itemSceneObjects[z].gameObject);
			}
			this._itemSceneObjects.RemoveRange(0, numToRemove);
		}
		else if(this._itemSceneObjects.Count < itemCount)
		{
			int numToAdd = itemCount - this._itemSceneObjects.Count;
			for(int z = 0; z < numToAdd; z++)
			{
				Transform go = Instantiate(this.ItemPrefab);
				go.SetParent(this.PanelListView, false);
				
				this._itemSceneObjects.Add(go);
			}
		}
	}
	
	public void ShowStore()
	{
		this.PanelTitleBar.text = string.Format("Store: \"{0}\"", ActiveStore);
		this.OverlayTint.SetActive(true);
		this.StorePanel.SetActive(true);
		InitStore(PfSharedModelEx.GetStore(ActiveStore));
		
		if(Wallet.gameObject.activeInHierarchy)
		{
			StartCoroutine(Wallet.Init());
		}
	}
		
	public void HideStorePane()
	{
		this.SelectedItem = null;
		this.OverlayTint.SetActive(false);
		this.StorePanel.SetActive(false);
	}
	
	public void ShowCatalog()
	{
		if(string.IsNullOrEmpty(ActiveCatalog))
		{
			ActiveCatalog = PfSharedModelEx.PrimaryCatalogVersion; 
		}
		
		this.PanelTitleBar.text = string.Format("Catalog: \"{0}\"", ActiveCatalog);
		this.OverlayTint.SetActive(true);
		this.StorePanel.SetActive(true);
		InitCatalog(PfSharedModelEx.GetCatalog(ActiveCatalog));
		StartCoroutine(Wallet.Init());
	}
	
	public void SelectItem(StoreItemController item)
	{
		DeselectItems();
		
		this.SelectedItem = item;
		this.SelectedItem.BuyButton.interactable = true;
		this.SelectedItem.PanelOutline.effectColor = this.SelectedItem.SelectedColor;
	}
	
	public void DeselectItems()
	{
		this.SelectedItem = null;
		foreach(var item in this._itemSceneObjects)
		{
			StoreItemController sic = item.GetComponent<StoreItemController>();
			sic.BuyButton.interactable = false;
			sic.PanelOutline.effectColor = sic.UnselectedColor;
		}
		
	}
	
	public void BuyItem(CatalogItem item)
	{
		Debug.Log("Buying: " + item.ItemId);
		var vcKvp = item.VirtualCurrencyPrices.First(); 
		
		// TODO file bug on the VC price info being a uint rather than an int.		
		if(this.DisplayState == StoreControllerStates.GetStore)
		{
			PlayFab.Examples.Client.InventoryExample.PurchaseItem(item.ItemId, vcKvp.Key, (int)vcKvp.Value, ActiveStore, ActiveCatalog);
		}
		else if(this.DisplayState == StoreControllerStates.GetCatalog)
		{
			PlayFab.Examples.Client.InventoryExample.PurchaseItem(item.ItemId, vcKvp.Key, (int)vcKvp.Value, null, ActiveCatalog);
		}
	}
	

	public void OpenHelpUrl()
	{
		MainExampleController.OpenWebBrowser(this.ActiveHelpUrl);
	}
	
	public void CloseStore()
	{
		this.gameObject.SetActive(false);
	}
	
	public void Refresh()
	{
		if(this.DisplayState == StoreControllerStates.GetCatalog)
		{
			PlayFab.Examples.Client.InventoryExample.LoadCatalogFromPlayFab(ActiveCatalog);
		}
		else
		{
			PlayFab.Examples.Client.InventoryExample.LoadStoreFromPlayFab(ActiveStore, ActiveCatalog);	
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
