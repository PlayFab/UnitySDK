using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using PlayFab.ClientModels;


public class StoreItemController : MonoBehaviour {
	public StoreController MainController;
	
	public Outline PanelOutline;
	public Color32 SelectedColor;
	public Color32 UnselectedColor;
	
	public Button ItemClickArea;
	public Button BuyButton;
	public Text ItemName;
	public Text ItemDescription;
	public Text ItemUses;
	public Text ItemType;
	public Text ItemId;
	public Text ItemExp;
	public Image Icon; 
	
	private CatalogItem _itemRef;
	
	// need to prevent items not sellable from getting created.
	public void Init( CatalogItem item, StoreController sc)
	{
		this.ItemUses.transform.parent.gameObject.SetActive(true);					// enable uses field
		this._itemRef = item;
		this.MainController = sc;
		this.ItemId.text = item.ItemId;
		
		this.ItemName.text = item.DisplayName;
		this.ItemDescription.text = item.Description;
		this.ItemUses.text = item.Consumable != null ? ""+item.Consumable.UsageCount : "0";
		
		if(item.Consumable != null && item.Consumable.UsageCount > 0)
		{
			this.ItemUses.transform.parent.gameObject.SetActive(true); // show uses field
		}
		
		// hide the expiration field
		this.ItemExp.transform.parent.gameObject.SetActive(false);
		
		
		if(this._itemRef.Bundle != null)
		{
			this.ItemType.text = "Bundle";
		}
		else if(this._itemRef.Container != null)
		{
			this.ItemType.text = "Container";
		}
		else if(this._itemRef.Consumable.UsageCount > 0 && this._itemRef.Consumable.UsagePeriod == null)
		{
			this.ItemType.text = "Consumable";
			
		}
		else if(this._itemRef.Consumable.UsageCount > 0 && this._itemRef.Consumable.UsagePeriod != null)
		{
			this.ItemType.text = "Time Bound";
			this.ItemExp.transform.parent.gameObject.SetActive(true);
		}
		else 
		{
			this.ItemType.text = "Durable";
		}
		
		
		// set Icon (eventually)
		this.BuyButton.onClick.RemoveAllListeners();
		this.BuyButton.onClick.AddListener(() => { sc.BuyItem(this._itemRef); });
		
		this.ItemClickArea.onClick.RemoveAllListeners();
		this.ItemClickArea.onClick.AddListener(() => { sc.SelectItem(this); });
		
		
		//item not for sale
		if(this._itemRef.VirtualCurrencyPrices == null || this._itemRef.VirtualCurrencyPrices.Count == 0)
		{
			this.BuyButton.interactable = false;
			
			Text obj = this.BuyButton.GetComponentInChildren<Text>();
			if(obj != null)
			{
				obj.text = "Not For Sale";
			}
			
			this.BuyButton.onClick.RemoveAllListeners();
		}
		else
		{
			string price, vc = string.Empty;
			if(this._itemRef.VirtualCurrencyPrices.ContainsKey("RM"))
			{
				price = string.Format ("{0:C}", (float)this._itemRef.VirtualCurrencyPrices["RM"] / 100f);
			}
			else
			{
			 	price = ""+this._itemRef.VirtualCurrencyPrices.FirstOrDefault().Value;
				vc = this._itemRef.VirtualCurrencyPrices.FirstOrDefault().Key;
			}
			string buyText = string.Format("Buy for ({0} {1})", price, vc);
			
			Text obj = this.BuyButton.GetComponentInChildren<Text>();
			if(obj != null)
			{
				obj.text = buyText;
			}
			this.BuyButton.interactable = true;
		}
	}	
}
