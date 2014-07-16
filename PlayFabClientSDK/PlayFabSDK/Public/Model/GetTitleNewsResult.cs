using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GetTitleNewsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of news items
		/// </summary>
		
		public List<TitleNewsItem> News { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			News = JsonUtil.GetObjectList<TitleNewsItem>(json, "News");
		}
	}
}