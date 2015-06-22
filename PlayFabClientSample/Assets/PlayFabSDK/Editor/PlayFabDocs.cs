using UnityEditor;
using UnityEngine;
using PlayFab;

namespace PlayFab.Editor
{
	public class PlayFabDocs: EditorWindow
    {
		private float titleId;
		private float catalogVersion;

        [MenuItem ("PlayFab/Docs")]
        private static void ShowWindow ()
        {
			Application.OpenURL("http://api.playfab.com/documentation");
        }
      }
}
