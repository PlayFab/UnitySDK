using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class PurchaseData : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the catalog item
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// purchase order identifier
		/// </summary>
		
		public string OrderId { get; set;}
		
		/// <summary>
		/// status of the transaction
		/// </summary>
		
		public TransactionStatus? Status { get; set;}
		
		/// <summary>
		/// virtual currency cost of the transaction
		/// </summary>
		
		public Dictionary<string,int> VCAmount { get; set;}
		
		/// <summary>
		/// real world currency for the transaction
		/// </summary>
		
		public string PurchaseCurrency { get; set;}
		
		/// <summary>
		/// real world cost of the transaction
		/// </summary>
		
		public uint PurchasePrice { get; set;}
		
		/// <summary>
		/// local credit applied to the transaction (provider specific)
		/// </summary>
		
		public uint CreditApplied { get; set;}
		
		/// <summary>
		/// provider used for the transaction
		/// </summary>
		
		public string ProviderData { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
			Status = (TransactionStatus?)JsonUtil.GetEnum<TransactionStatus>(json, "Status");
			VCAmount = JsonUtil.GetDictionaryInt32(json, "VCAmount");
			PurchaseCurrency = (string)JsonUtil.Get<string>(json, "PurchaseCurrency");
			PurchasePrice = (uint)JsonUtil.Get<double?>(json, "PurchasePrice");
			CreditApplied = (uint)JsonUtil.Get<double?>(json, "CreditApplied");
			ProviderData = (string)JsonUtil.Get<string>(json, "ProviderData");
		}
	}
}