using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class UnlockContainerItemResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Unique instance id of the container unlocked
		/// </summary>
		
		public string UnlockedItemInstanceId { get; set;}
		
		/// <summary>
		/// Unique item instance id of the key used to unlock it, if applicable
		/// </summary>
		
		public string UnlockedWithItemInstanceId { get; set;}
		
		/// <summary>
		/// array of items granted to the player as a result of unlocking the container
		/// </summary>
		
		public List<ItemInstance> GrantedItems { get; set;}
		
		/// <summary>
		/// virtual currency granted to the player as a result of unlocking the container
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrency { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UnlockedItemInstanceId = (string)JsonUtil.Get<string>(json, "UnlockedItemInstanceId");
			UnlockedWithItemInstanceId = (string)JsonUtil.Get<string>(json, "UnlockedWithItemInstanceId");
			GrantedItems = JsonUtil.GetObjectList<ItemInstance>(json, "GrantedItems");
			VirtualCurrency = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrency");
		}
	}
}