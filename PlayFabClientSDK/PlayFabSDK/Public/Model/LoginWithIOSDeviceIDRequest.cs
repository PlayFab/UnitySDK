using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class LoginWithIOSDeviceIDRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// vendor-specific iOS identifier for the user's device
		/// </summary>
		
		public string DeviceId { get; set;}
		
		/// <summary>
		/// specific Operating System version for the user's device
		/// </summary>
		
		public string OS { get; set;}
		
		/// <summary>
		/// specific model of the user's device
		/// </summary>
		
		public string DeviceModel { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this iOS device
		/// </summary>
		
		public bool CreateAccount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			DeviceId = (string)JsonUtil.Get<string>(json, "DeviceId");
			OS = (string)JsonUtil.Get<string>(json, "OS");
			DeviceModel = (string)JsonUtil.Get<string>(json, "DeviceModel");
			CreateAccount = (bool)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
}