using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GetMatchmakerGameModesResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of game modes available for the specified build
		/// </summary>
		
		public List<GameModeInfo> GameModes { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			GameModes = JsonUtil.GetObjectList<GameModeInfo>(json, "GameModes");
		}
	}
}