using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class AwardSteamAchievementItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user who is to be granted the specified Steam achievement
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique Steam achievement name
		/// </summary>
		
		public string AchievementName { get; set;}
		
		/// <summary>
		/// result of the award attempt (only valid on response, not on request)
		/// </summary>
		
		public bool Result { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			AchievementName = (string)JsonUtil.Get<string>(json, "AchievementName");
			Result = (bool)JsonUtil.Get<bool?>(json, "Result");
		}
	}
}