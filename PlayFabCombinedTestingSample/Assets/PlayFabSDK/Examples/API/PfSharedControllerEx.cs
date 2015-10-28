using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFab.Examples
{
    public static class PfSharedControllerEx
    {
        /// <summary>
        /// PlayFab Example Controller event callback
        /// </summary>
        /// <param name="playFabId">playFabId of the user affected by this event</param>
        /// <param name="characterId">characterId affected by this event, null implies plain user</param>
        /// <param name="eventSourceApi">The api that affected this change</param>
        /// <param name="requiresFullRefresh">
        ///     If true, then all data models for all apis need to fully refresh their data to handle this event
        ///     If false, the api-response has handled the local data-updates for this event, but other Api-data probably still needs to refresh
        ///         This is only particularly relevant to the server/client keeping similar data in separate containers with different datatypes (inventory).
        /// </param>
        public delegate void PfControllerDelegate(string playFabId, string characterId, Api eventSourceApi, bool requiresFullRefresh);

        [Flags]
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

            OnInventoryChanged,
            OnVcChanged,
        }

        /// <summary>
        /// A shared StringBuilder that reduces GC use
        /// It should be assumed that it's always filled with garbage
        /// </summary>
        public static StringBuilder sb = new StringBuilder();

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
