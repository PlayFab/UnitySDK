using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GetTitleNewsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// limits the results to the last n entries (defaults to 10 if not set)
		/// </summary>
		
		public uint? Count { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Count = (uint?)JsonUtil.Get<double?>(json, "Count");
		}
	}
}