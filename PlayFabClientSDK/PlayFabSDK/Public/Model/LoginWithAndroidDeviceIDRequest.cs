using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class LoginWithAndroidDeviceIDRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// Android device identifier for the user's device
		/// </summary>
		
		public string AndroidDeviceId { get; set;}
		
		/// <summary>
		/// specific Operating System version for the user's device
		/// </summary>
		
		public string OS { get; set;}
		
		/// <summary>
		/// specific model of the user's device
		/// </summary>
		
		public string AndroidDevice { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this iOS device
		/// </summary>
		
		public bool CreateAccount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			AndroidDeviceId = (string)JsonUtil.Get<string>(json, "AndroidDeviceId");
			OS = (string)JsonUtil.Get<string>(json, "OS");
			AndroidDevice = (string)JsonUtil.Get<string>(json, "AndroidDevice");
			CreateAccount = (bool)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
}