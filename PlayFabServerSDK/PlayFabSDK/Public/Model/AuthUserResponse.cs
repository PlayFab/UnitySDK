using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class AuthUserResponse : PlayFabModelBase
	{
		
		
		/// <summary>
		/// boolean indicating if the user has been authorized to use the external match-making service
		/// </summary>
		
		public bool Authorized { get; set;}
		
		/// <summary>
		/// PlayFab unique identifier of the account that has been authorized
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Authorized = (bool)JsonUtil.Get<bool?>(json, "Authorized");
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
}