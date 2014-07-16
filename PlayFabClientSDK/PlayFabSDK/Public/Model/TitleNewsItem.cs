using System.Collections.Generic;

using System;

namespace PlayFab.Model
{
	
	public class TitleNewsItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// date and time when the news items was posted
		/// </summary>
		
		public DateTime? Timestamp { get; set;}
		
		/// <summary>
		/// title of the news item
		/// </summary>
		
		public string Title { get; set;}
		
		/// <summary>
		/// news item text
		/// </summary>
		
		public string Body { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Timestamp = (DateTime?)JsonUtil.GetDateTime(json, "Timestamp");
			Title = (string)JsonUtil.Get<string>(json, "Title");
			Body = (string)JsonUtil.Get<string>(json, "Body");
		}
	}
}