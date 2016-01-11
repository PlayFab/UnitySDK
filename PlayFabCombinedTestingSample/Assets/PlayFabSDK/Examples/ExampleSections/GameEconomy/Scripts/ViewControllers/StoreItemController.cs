using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using PlayFab.ClientModels;


public class StoreItemController : MonoBehaviour {
	public StoreController mainController;
	
	public Outline panelOutline;
	public Color32 selectedColor;
	public Color32 unselectedColor;
	
	public Button itemClickArea;
	public Button buyButton;
	public Text itemName;
	public Text itemDescription;
	public Text itemUses;
	public Text itemType;
	public Text itemId;
	public Image icon; 
	
	private CatalogItem itemRef;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// need to prevent items not sellable from getting created.
	public void Init( CatalogItem item, StoreController sc)
	{
		
		this.itemUses.transform.parent.gameObject.SetActive(true);					// enable uses field
		this.itemRef = item;
		this.mainController = sc;
		this.itemId.text = item.ItemId;
		
		this.itemName.text = item.DisplayName;
		this.itemDescription.text = item.Description;
		this.itemUses.text = item.Consumable != null ? ""+item.Consumable.UsageCount : "0";
		
		if(item.Consumable != null && item.Consumable.UsageCount > 0)
		{
			this.itemUses.transform.parent.gameObject.SetActive(true); // hide uses field
		}
		
		this.itemUses.transform.parent.gameObject.SetActive(true);
		
		if(this.itemRef.Bundle != null)
		{
			this.itemType.text = "Bundle";
		}
		else if(this.itemRef.Container != null)
		{
			this.itemType.text = "Container";
		}
		else if(this.itemRef.Consumable.UsageCount > 0 && this.itemRef.Consumable.UsagePeriod == null)
		{
			this.itemType.text = "Consumable";
			
		}
		else if(this.itemRef.Consumable.UsageCount > 0 && this.itemRef.Consumable.UsagePeriod != null)
		{
			this.itemType.text = "Time Bound";
			 // show uses field
		}
		else 
		{
			this.itemType.text = "Durable";
			this.itemUses.transform.parent.gameObject.SetActive(false); // hide uses field
		}
		
		
		// set icon (eventually)
		this.buyButton.onClick.RemoveAllListeners();
		this.buyButton.onClick.AddListener(() => { sc.BuyItem(this.itemRef); });
		
		this.itemClickArea.onClick.RemoveAllListeners();
		this.itemClickArea.onClick.AddListener(() => { sc.SelectItem(this); });
		
		
		//item not for sale
		if(this.itemRef.VirtualCurrencyPrices == null || this.itemRef.VirtualCurrencyPrices.Count == 0)
		{
			this.buyButton.interactable = false;
			
			Text obj = this.buyButton.GetComponentInChildren<Text>();
			if(obj != null)
			{
				obj.text = "Not For Sale";
			}
			
			this.buyButton.onClick.RemoveAllListeners();
		}
		else
		{
			string price, vc = string.Empty;
			if(this.itemRef.VirtualCurrencyPrices.ContainsKey("RM"))
			{
				price = string.Format ("{0:C}", (float)this.itemRef.VirtualCurrencyPrices["RM"] / 100f);
			}
			else
			{
			 	price = ""+this.itemRef.VirtualCurrencyPrices.FirstOrDefault().Value;
				vc = this.itemRef.VirtualCurrencyPrices.FirstOrDefault().Key;
			}
			string buyText = string.Format("Buy for ({0} {1})", price, vc);
			
			Text obj = this.buyButton.GetComponentInChildren<Text>();
			if(obj != null)
			{
				obj.text = buyText;
			}
			this.buyButton.interactable = true;
		}

	}	
}
