using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class LogEventRequest : PlayFabModelBase
	{
		
		
		
		public string eventName { get; set;}
		
		
		public Dictionary<string,object> Body { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			eventName = (string)JsonUtil.Get<string>(json, "eventName");
			Body = JsonUtil.GetDictionary<object>(json, "Body");
		}
	}
}