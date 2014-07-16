using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class UpdatePasswordRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// password for the account to be signed in (6-24 characters)
		/// </summary>
		
		public string Password { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Password = (string)JsonUtil.Get<string>(json, "Password");
		}
	}
}