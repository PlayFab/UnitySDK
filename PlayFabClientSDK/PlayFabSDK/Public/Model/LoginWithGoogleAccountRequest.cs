using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class LoginWithGoogleAccountRequest : PlayFabModelBase
	{
		
		
		
		public string TitleId { get; set;}
		
		
		public string AccessToken { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			AccessToken = (string)JsonUtil.Get<string>(json, "AccessToken");
		}
	}
}