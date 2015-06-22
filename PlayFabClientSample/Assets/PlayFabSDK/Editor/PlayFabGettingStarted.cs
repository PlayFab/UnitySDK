using UnityEditor;
using UnityEngine;
using PlayFab;

namespace PlayFab.Editor
{
	public class PlayFabGettingStarted: EditorWindow
    {
		private float titleId;
		private float catalogVersion;

        [MenuItem ("PlayFab/GettingStarted")]
        private static void ShowWindow ()
        {
			Application.OpenURL("http://developer.playfab.com/gettingstarted.html");
        }
      }
}
