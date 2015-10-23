using UnityEditor;
using UnityEngine;

namespace PlayFab.Editor
{
    public class PlayFabHelp : EditorWindow
    {
        [MenuItem("PlayFab/GettingStarted")]
        private static void GettingStarted()
        {
            Application.OpenURL("https://playfab.com/docs/getting-started-with-playfab/");
        }

        [MenuItem("PlayFab/Docs")]
        private static void Documentation()
        {
            Application.OpenURL("https://api.playfab.com/documentation");
        }

        [MenuItem("PlayFab/Dashboard")]
        private static void Dashboard()
        {
            Application.OpenURL("https://developer.playfab.com/");
        }
    }
}
