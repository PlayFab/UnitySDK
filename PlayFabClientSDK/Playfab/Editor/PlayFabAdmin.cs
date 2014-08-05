using UnityEditor;
using UnityEngine;
using PlayFab;

namespace PlayFab.Editor
{
	public class PlayFabAdmin: EditorWindow
    {
		private float titleId;
		private float catalogVersion;

        [MenuItem ("Playfab/Admin Panel")]
        private static void ShowWindow ()
        {
			Application.OpenURL("https://gsw.uberentdev.com/");
        }
      }
}
