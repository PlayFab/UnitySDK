using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    public static class PlayFabHelp
    {
        [MenuItem("PlayFab/GettingStarted")]
        private static void GettingStarted()
        {
            Application.OpenURL("https://api.playfab.com/docs/beginners-guide");
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
