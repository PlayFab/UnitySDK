using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using PlayFab.ClientModels;
using PlayFab.Examples;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreController : MonoBehaviour {
	public enum StoreControllerStates { GetCatalog, GetStore }
	public StoreControllerStates DisplayState;
	public bool useCachedItems = false;

	public GameObject storePanel;
	public GameObject overlayTint;
	
	public Text panelTitleBar;
	private List<Transform> itemSceneObjects = new List<Transform>();
	public Transform panelListView;
	public Transform itemPrefab;
	
	public WalletController wallet;

	public StoreItemController selectedItem;

	// SET catalog and store name defaults here.
	public string storeName = "default";
	public string catalogName = "1";
	public string lastCatalogUsed = string.Empty;
	public string lastStoreUsed = string.Empty;
	
	private bool usePrimaryCatalog = true;
	
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
	
	void OnEnable()
	{
		HideStore();
		//PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnStoreLoaded, HandleOnStoreLoad);
		//PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnCatalogLoaded, HandleOnCatalogLoad);
		//PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnInventoryLoaded, HandleOnInventoryLoaded);
		
		
		// based on settings, we want to fetch new store / catalog and build our store view.
		// if we are using alt catalog or store, we should prompt for what store / catalog to load.
		// 
		if(this.DisplayState == StoreControllerStates.GetStore)
		{
			System.Action<string> afterInput = (string response) =>
			{
				if(!string.IsNullOrEmpty(response))
				{
//					if(response == this.storeName && this.useCachedItems == true && PlayFab.Examples.PfSharedModelEx.cachedStoreItems.Count > 0)
//					{
//						// store already retrived, draw it
//						ShowStore();
//					}
//					else
//					{
//						// need to wait on store to load before drawing it
//						this.storeName = response;
//						PlayFab.Examples.Client.InventoryExample.GetStoreItems(response); 
//					}
				}
				else
				{
					this.gameObject.SetActive(false);
				}
			};
			
			
			if(!string.IsNullOrEmpty(this.storeName))
			{
				SharedDialogController.RequestTextInputPrompt("Store Mode:","Enter the name of the store you wish to retrieve.", afterInput, this.storeName);
			}
			else
			{
				SharedDialogController.RequestTextInputPrompt("title","msg", afterInput);
			}
			
		}
		else if(DisplayState == StoreControllerStates.GetCatalog)
		{

			if(this.usePrimaryCatalog == true && PfSharedModelEx.isCatalogCached())
			{
				ShowCatalog();
			}
			else if(PfSharedModelEx.isCatalogCached(lastCatalogUsed))
			{
				ShowCatalog();
			}
			else
			{
				// TODO request & wait on a new catalog?
				
				this.gameObject.SetActive(false);
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
					ShowCatalog();
				}
				else
				{
					// need to wait on store to load before drawing it
					this.catalogName = response;
					//PlayFab.Examples.Client.InventoryExample.GetCatalogItems(response); 
				}
			}
		};
		
		if(!string.IsNullOrEmpty(this.storeName))
		{
			SharedDialogController.RequestTextInputPrompt("Catalog Mode:","Enter the name of the catalog you wish to retrieve.", afterInput, this.catalogName);
		}
		else
		{
			SharedDialogController.RequestTextInputPrompt("title","msg", afterInput);
		}
	}
	
	public void OnDisable()
	{
//		PlayFab.Examples.PfSharedControllerEx.UnregisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnStoreLoaded, HandleOnStoreLoad);
//		PlayFab.Examples.PfSharedControllerEx.UnregisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnCatalogLoaded, HandleOnCatalogLoad);
//		PlayFab.Examples.PfSharedControllerEx.UnregisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnInventoryLoaded, HandleOnInventoryLoaded);
	}
	
	public void InitStore(List<StoreItem> stock = null)
	{
//		if(stock != null && PlayFab.Examples.PfSharedModelEx.titleCatalog.Count > 0)
//		{
//			AdjustItemPrefabs(stock.Count);
//			
//			int counter = 0;
//			foreach(var item in stock)
//			{
//				StoreItemController itemController = this.itemSceneObjects[counter].GetComponent<StoreItemController>();
//				//this.itemSceneObjects[counter].gameObject.SetActive(true);
//				
//				CatalogItem cItem = null;
//				PlayFab.Examples.PfSharedModelEx.titleCatalog.TryGetValue(item.ItemId, out cItem);
//				if(cItem != null)
//				{
//					// swap our catalog prices with the selected store prices.
//					cItem.VirtualCurrencyPrices = item.VirtualCurrencyPrices;
//					cItem.RealCurrencyPrices = item.RealCurrencyPrices;
//					itemController.Init(cItem, this);
//				}
//				counter++;
//			}
//		}
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
				// only show items that can be purchases, i.e. ones that have a price			
				if( (item.VirtualCurrencyPrices != null && item.VirtualCurrencyPrices.Count > 0) || (item.RealCurrencyPrices != null && item.RealCurrencyPrices.Count > 0))
				{
					StoreItemController itemController = this.itemSceneObjects[counter].GetComponent<StoreItemController>();
					//this.itemSceneObjects[counter].gameObject.SetActive(true);
					itemController.Init(item, this);
					counter++;
				}
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
				Destroy(this.itemSceneObjects[z].gameObject);
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
	
	
	public void HandleOnInventoryLoaded(string playFabId, string characterId, PlayFab.Examples.PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
	{
		StartCoroutine(this.wallet.Init());
	}
	
	
	public void HandleOnStoreLoad(string playFabId, string characterId, PlayFab.Examples.PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
	{
		if(this.DisplayState == StoreControllerStates.GetStore)
		{
			StartCoroutine(this.wallet.Init());
			ShowStore();
		}
	}
	
	public void HandleOnCatalogLoad(string playFabId, string characterId, PlayFab.Examples.PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
	{
		if(this.DisplayState == StoreControllerStates.GetCatalog)
		{
			StartCoroutine(this.wallet.Init());
			ShowCatalog();
		}

	}		
		
	public void ShowStore()
	{
		this.panelTitleBar.text = string.Format("Store: \"{0}\"", this.storeName);
		this.overlayTint.SetActive(true);
		this.storePanel.SetActive(true);
		InitStore(PfSharedModelEx.GetStore(lastStoreUsed));
		//var count = PlayFab.Examples.PfSharedModelEx.cachedStoreItems.Count;
	}
		
	public void HideStore()
	{
		this.selectedItem = null;
		this.overlayTint.SetActive(false);
		this.storePanel.SetActive(false);
	}
	
	public void ShowCatalog()
	{
		this.panelTitleBar.text = string.Format("Catalog: \"{0}\"", this.catalogName);
		this.overlayTint.SetActive(true);
		this.storePanel.SetActive(true);
		if(usePrimaryCatalog == true)
		{
			InitCatalog(PfSharedModelEx.GetPrimaryCatalog());
		}
		else
		{
			InitCatalog(PfSharedModelEx.GetCatalog(lastCatalogUsed));
		}

	}
	
//	public void AfterStoreRetrieved(GetStoreItemsRequest request)
//	{
//		
//	}
	
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
		
		if(this.DisplayState == StoreControllerStates.GetStore)
		{
			//System.Action buyAction = PlayFab.Examples.Client.InventoryExample.PurchaseUserItem(item.ItemId);
			//buyAction();
		}
		else if(this.DisplayState == StoreControllerStates.GetCatalog)
		{
			//System.Action buyAction = PlayFab.Examples.Client.InventoryExample.PurchaseUserItem(item.ItemId);
			//buyAction();
		}
	}
	
	
	public void CloseStore()
	{
		this.gameObject.SetActive(false);
	}
}
