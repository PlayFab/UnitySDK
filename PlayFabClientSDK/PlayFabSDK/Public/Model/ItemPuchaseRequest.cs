using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class ItemPuchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// ItemId of the item to purchase
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// How many to buy
		/// </summary>
		
		public uint Quantity { get; set;}
		
		/// <summary>
		/// Annotation text about this purchase
		/// </summary>
		
		public string Annotation { get; set;}
		
		/// <summary>
		/// What items to upgrade
		/// </summary>
		
		public List<string> UpgradeFromItems { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			Quantity = (uint)JsonUtil.Get<double?>(json, "Quantity");
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
			UpgradeFromItems = JsonUtil.GetList<string>(json, "UpgradeFromItems");
		}
	}
}