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
		
		string price = ""+this.itemRef.VirtualCurrencyPrices.First().Value;
		string vc = this.itemRef.VirtualCurrencyPrices.First().Key;
		string buyText = string.Format("Buy for ({0} {1})", price, vc); 
		this.buyButton.GetComponentInChildren<Text>().text = buyText;
	}	
}
