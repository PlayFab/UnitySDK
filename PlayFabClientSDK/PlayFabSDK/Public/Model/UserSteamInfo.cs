using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class UserSteamInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// steam id
		/// </summary>
		
		public string SteamId { get; set;}
		
		/// <summary>
		/// if account is linked to steam, this is the country that steam reports the player being in
		/// </summary>
		
		public string SteamCountry { get; set;}
		
		/// <summary>
		/// Currency set in the user's steam account
		/// </summary>
		
		public Currency? SteamCurrency { get; set;}
		
		/// <summary>
		/// STEAM specific - what stage of game ownership is the user at with Steam
		/// </summary>
		
		public TitleActivationStatus? SteamActivationStatus { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SteamId = (string)JsonUtil.Get<string>(json, "SteamId");
			SteamCountry = (string)JsonUtil.Get<string>(json, "SteamCountry");
			SteamCurrency = (Currency?)JsonUtil.GetEnum<Currency>(json, "SteamCurrency");
			SteamActivationStatus = (TitleActivationStatus?)JsonUtil.GetEnum<TitleActivationStatus>(json, "SteamActivationStatus");
		}
	}
}