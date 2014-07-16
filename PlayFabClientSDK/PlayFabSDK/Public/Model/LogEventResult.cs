using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class LogEventResult : PlayFabModelBase
	{
		
		
		
		public List<string> errors { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			errors = JsonUtil.GetList<string>(json, "errors");
		}
	}
}