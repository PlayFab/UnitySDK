using System;
using UnityEngine;

namespace PlayFab.PfEditor
{
    public class PlayFabEditorPackages : UnityEditor.Editor
    {
        private const int buttonWidth = 150;

        public static bool IsPubSubPresent { get { return GetIsPubSubTypePresent(); } }

        public static void DrawPackagesMenu()
        {
#if ENABLE_PLAYFABPUBSUB_API
            var labelStyle = new GUIStyle(PlayFabEditorHelper.uiStyle.GetStyle("label"));
            if (Environment.Version.Major < 4)
            {
                EditorGUILayout.LabelField(" PersistentSockets is only supported with dot Net 4\n\n Please change your Project build settings", labelStyle, GUILayout.MinWidth(EditorGUIUtility.currentViewWidth));
            }
            else if (!IsPubSubPresent)
            {
                DrawPubSubPrivatePreviewWarning();
                GUILayout.BeginHorizontal();
                GUILayout.Label(" PubSub: ");
                if (GUILayout.Button("Install From GitHub", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MaxWidth(buttonWidth), GUILayout.MinHeight(32)))
                {
                    string possibleNewtonsoftPath = "";
                    if (GetIsNewtonsoftInstalled(out possibleNewtonsoftPath))
                    {
                        EditorUtility.DisplayDialog("Newtonsoft is already installed.",
                            "Please delete your version of Netwonsoft.json.dll in \n\n" + possibleNewtonsoftPath + " \n and retry the install.\n\n Compiler conflicts will occur if this package is installed and Newtonsoft already exists.", "Continue", "Cancel");
                    }
                    else
                    {
                        ImportPubSubSDK();
                    }
                }

                GUILayout.EndHorizontal();
            }
            else
            {
                EditorGUILayout.LabelField(" PersistentSockets is Installed", labelStyle, GUILayout.MinWidth(EditorGUIUtility.currentViewWidth));
            }
#endif
        }

        private static void DrawPubSubPrivatePreviewWarning()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(" PUBSUB IS IN PRIVATE PREVIEW.");
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label(" If you are a Professional or Enterprise tier customer and wish to try this feature out, Please contact helloplayfab@microsoft.com for more information.");
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label(" User MUST be currently signed into GitHub (with their default browser) to successfully install the unitypackage");
            GUILayout.EndHorizontal();
        }

        public static void ImportPubSubSDK()
        {
            var link = "https://api.playfab.com/downloads/unity-signalr";
            System.Diagnostics.Process.Start(link);
        }

        public static bool GetIsNewtonsoftInstalled(out string path)
        {
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in allAssemblies)
            {
                if (assembly.FullName.Contains("Newtonsoft.Json"))
                {
                    path = assembly.Location;
                    return true;
                }

                foreach (var eachType in assembly.GetTypes())
                {
                    if (eachType.Name.Contains("Newtonsoft"))
                    {
                        path = assembly.Location;
                        return true;
                    }
                }
            }
            path = "N/A";
            return false;
        }

        // TODO: move this function to a shared location
        // and CACHE the results so we don't need to loop multiple times.
        public static bool GetIsPubSubTypePresent()
        {
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in allAssemblies)
            {
                foreach (var eachType in assembly.GetTypes())
                {
                    if (eachType.Name.Contains("PubSub"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
