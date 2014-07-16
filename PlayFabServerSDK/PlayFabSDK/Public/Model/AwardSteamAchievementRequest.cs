using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class AwardSteamAchievementRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of achievements to grant and the users to whom they are to be granted
		/// </summary>
		
		public List<AwardSteamAchievementItem> Achievements { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Achievements = JsonUtil.GetObjectList<AwardSteamAchievementItem>(json, "Achievements");
		}
	}
}