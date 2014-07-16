using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GetUserDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// specific keys to search for in the custom user data
		/// </summary>
		
		public List<string> Keys { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Keys = JsonUtil.GetList<string>(json, "Keys");
		}
	}
}