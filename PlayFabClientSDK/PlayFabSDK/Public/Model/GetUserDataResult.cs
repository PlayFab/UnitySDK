using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GetUserDataResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user specific data for this title
		/// </summary>
		
		public Dictionary<string,string> Data { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Data = JsonUtil.GetDictionary<string>(json, "Data");
		}
	}
}