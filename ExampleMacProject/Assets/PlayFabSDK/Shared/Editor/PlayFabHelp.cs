using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    public static class PlayFabHelp
    {
        [MenuItem("PlayFab/GettingStarted")]
        private static void GettingStarted()
        {
            Application.OpenURL("https://docs.microsoft.com/en-us/gaming/playfab/index#pivot=documentation&panel=quickstarts");
        }

        [MenuItem("PlayFab/Docs")]
        private static void Documentation()
        {
            Application.OpenURL("https://docs.microsoft.com/en-us/gaming/playfab/api-references/");
        }

        [MenuItem("PlayFab/Dashboard")]
        private static void Dashboard()
        {
            Application.OpenURL("https://developer.playfab.com/");
        }

        [MenuItem("PlayFab/Forum")]
        private static void Forum()
        {
            Application.OpenURL("https://community.playfab.com/index.html");
        }

        [MenuItem("PlayFab/Provide Feedback")]
        private static void Feedback()
        {
            Application.OpenURL("https://playfab.com/contact/");
        }
    }
}
