using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PlayFab.Examples
{
	public class CommonController : MonoBehaviour {
		
		public delegate void PfControllerDelegate(string playFabId, string characterId, Api eventSourceApi, bool requiresFullRefresh);
	
		private static Dictionary<EventType, PfControllerDelegate> eventCallbacks = new Dictionary<EventType, PfControllerDelegate>();
		
		public static void RegisterEventMessage(EventType evt, PfControllerDelegate callback)
		{
			PfControllerDelegate storedDelegate;
			eventCallbacks.TryGetValue(evt, out storedDelegate);
			storedDelegate += callback;
			eventCallbacks[evt] = storedDelegate;
		}
		
		public static void PostEventMessage(EventType evt, string playFabId, string characterId, Api eventSourceApi, bool requiresFullRefresh)
		{
			PfControllerDelegate storedDelegate;
			if (eventCallbacks.TryGetValue(evt, out storedDelegate) && storedDelegate != null)
				storedDelegate(playFabId, characterId, eventSourceApi, requiresFullRefresh);
		}
		

		public enum Api
		{
			Client,
			Server,
			Admin,
			Matchmaker,
		}
		public enum EventType
		{
			OnUserLogin,
			OnUserCharactersLoaded,
			OnCatalogLoaded,
			OnUserDataLoaded,
			OnTitleDataLoaded,
			
			OnInventoryChanged,
			OnVcChanged,
			OnUserDataChanged,
			OnTitleDataChanged,
		}
		
		/// <summary>
		/// A generic failure catch-all that simply logs the error to the console.
		/// Does not provide any kind of recovery or automatic re-attempt.
		/// </summary>
		public static ErrorCallback FailCallback(string caller)
		{
			ErrorCallback output = (PlayFabError error) =>
			{
				UnityEngine.Debug.LogError(caller + " failure: " + error.ErrorMessage);
			};
			return output;
		}
	}
}