using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class SetTitleDataResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// key that was set
		/// </summary>
		
		public string Key { get; set;}
		
		/// <summary>
		/// new value set for key
		/// </summary>
		
		public string Value { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Key = (string)JsonUtil.Get<string>(json, "Key");
			Value = (string)JsonUtil.Get<string>(json, "Value");
		}
	}
}