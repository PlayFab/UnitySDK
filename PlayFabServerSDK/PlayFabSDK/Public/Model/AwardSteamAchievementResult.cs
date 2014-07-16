using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class AwardSteamAchievementResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of achievements granted
		/// </summary>
		
		public List<AwardSteamAchievementItem> AchievementResults { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AchievementResults = JsonUtil.GetObjectList<AwardSteamAchievementItem>(json, "AchievementResults");
		}
	}
}