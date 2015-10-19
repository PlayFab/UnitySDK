using System.Collections.Generic;
using System.Text;

namespace PlayFab.Examples
{
    public static class PfSharedControllerEx
    {
        public delegate void PfControllerDelegate(string identifier);
        public enum EventType
        {
            OnUserLogin,
            OnAllCharactersLoaded,
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

        public static void PostEventMessage(EventType evt, string context)
        {
            PfControllerDelegate storedDelegate;
            if (eventCallbacks.TryGetValue(evt, out storedDelegate) && storedDelegate != null)
                storedDelegate(context);
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
