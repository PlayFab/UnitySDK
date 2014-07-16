using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class UpdateEmailAddressRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user email address, used for account password recovery
		/// </summary>
		
		public string Email { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Email = (string)JsonUtil.Get<string>(json, "Email");
		}
	}
}