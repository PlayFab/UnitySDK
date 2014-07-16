using System.Collections.Generic;

using System;

namespace PlayFab.Model
{
	
	public class UserTitleInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// displayable game name
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// optional value that details where the user originated
		/// </summary>
		
		public UserOrigination? Origination { get; set;}
		
		/// <summary>
		/// When this object was created. Title specific reporting for user creation time should be done against this rather than the User created field since account creation can differ significantly between title registration.
		/// </summary>
		
		public DateTime? Created { get; set;}
		
		/// <summary>
		/// Last time the user logged in to this title
		/// </summary>
		
		public DateTime? LastLogin { get; set;}
		
		/// <summary>
		///  Time the user first logged in. This can be different from when the UTD was created. For example we create a UTD when issuing a beta key. An arbitrary amount of time can pass before the user actually logs in.
		/// </summary>
		
		public DateTime? FirstLogin { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			Origination = (UserOrigination?)JsonUtil.GetEnum<UserOrigination>(json, "Origination");
			Created = (DateTime?)JsonUtil.GetDateTime(json, "Created");
			LastLogin = (DateTime?)JsonUtil.GetDateTime(json, "LastLogin");
			FirstLogin = (DateTime?)JsonUtil.GetDateTime(json, "FirstLogin");
		}
	}
}