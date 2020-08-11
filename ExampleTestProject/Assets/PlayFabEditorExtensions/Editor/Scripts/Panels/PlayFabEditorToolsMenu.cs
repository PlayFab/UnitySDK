using PlayFab.PfEditor.EditorModels;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    public class PlayFabEditorToolsMenu : UnityEditor.Editor
    {
        public enum ToolSubMenuStates
        {
            CloudScript,
            QuickScript,
        }

        public static ToolSubMenuStates currentState = ToolSubMenuStates.CloudScript;

        public static float buttonWidth = 200;
        public static Vector2 scrollPos = Vector2.zero;
        private static SubMenuComponent _menu = null;

        private static string GetEmitCode(string filename, string lifecyclepoint)
        {
            return "    (new PlayFab.PlayFabClientAPI()).LoginWithCustomID( new PlayFab.ClientModels.LoginWithCustomIDRequest() { CreateAccount = true, CustomId = SystemInfo.deviceUniqueIdentifier, TitleId=PlayFab.PlayFabSettings.TitleId }, result => { PlayFab.PlayFabClientAPI.WriteTitleEvent( new PlayFab.ClientModels.WriteTitleEventRequest() { EventName = \"" + filename + ":" + lifecyclepoint + "\", AuthenticationContext = result.AuthenticationContext }, null, null);}, null);\n";
        }

        private static string GetEmitFunction(string filename, string lifecyclepoint)
        {
            //TODO: return a full function instead.
            return "    (new PlayFab.PlayFabClientAPI()).LoginWithCustomID( new PlayFab.ClientModels.LoginWithCustomIDRequest() { CreateAccount = true, CustomId = SystemInfo.deviceUniqueIdentifier, TitleId=PlayFab.PlayFabSettings.TitleId }, result => { PlayFab.PlayFabClientAPI.WriteTitleEvent( new PlayFab.ClientModels.WriteTitleEventRequest() { EventName = \"" + filename + ":" + lifecyclepoint + "\", AuthenticationContext = result.AuthenticationContext }, null, null);}, null);\n";
        }

        private static bool quickStartActivated = false;

        private static string _StartVoidCode = "void Start()";
        private static string _StartVoidSpaceCode = "void Start ()";
        private static string _StartEnumerableCode = "IEnumerable Start()";
        private static string _StartEnumerableSpaceCode = "IEnumerable Start ()";
        private static bool tagStart = false;

        private static string _EnableVoidCode = "void OnEnable()";
        private static string _EnableVoidSpaceCode = "void OnEnable ()";
        private static string _EnableEnumerableCode = "IEnumerable OnEnable()";
        private static string _EnableEnumerableSpaceCode = "IEnumerable OnEnable ()";
        private static bool tagEnable = false;

        private static List<bool> filesToWriteTo = new List<bool>();

        private static void DrawQuickStart()
        {
            GUILayout.FlexibleSpace();
            if (!quickStartActivated)
            {
                EditorGUILayout.LabelField("Auto-Tagger: Add telemetry calls to Assets you care about.");
                if (GUILayout.Button("AutoTag My Assets!", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.Width(buttonWidth)))
                {
                    GetAssetFiles();
                    quickStartActivated = true;
                }
            }
            else
            {
                // TODO: v2 possibly have to add each of these 3 to all file options... may not look very good.
                // Can we pop out a window instead?

                EditorGUILayout.LabelField("Start, only emits once per session");
                tagStart = GUILayout.Toggle(tagStart, "Tag Start");

                EditorGUILayout.LabelField("On Enable, emits anytime this object come back");
                tagEnable = GUILayout.Toggle(tagEnable, "Tag Enable");

                if (localAssets.Count < 1)
                {
                    EditorGUILayout.LabelField("No MonoBehaviors were found!");
                    if (GUILayout.Button("Back to Add Telemetry", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.Width(buttonWidth)))
                    {
                        quickStartActivated = false;
                    }
                }
                else
                {
                    foreach (var file in localAssets)
                    {
                        //filesToWriteTo.Add(true);
                        //EditorGUILayout.LabelField(file);
                        //filesToWriteTo[filesToWriteTo.Count - 1] = GUILayout.Toggle(filesToWriteTo[filesToWriteTo.Count - 1], file);
                        EditorGUILayout.LabelField(file);
                        GUILayout.Toggle(true, file);
                    }
                    if (GUILayout.Button("Add Telemetry", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.Width(buttonWidth)))
                    {
                        //TODO: Filter out any check boxes that were told to avoid.
                        WriteAssetFiles();
                        localAssets.Clear();
                        quickStartActivated = false;
                    }
                }
            }
            GUILayout.FlexibleSpace();
        }

        private static void DrawCloudScript()
        {
            //scrollPos = GUILayout.BeginScrollView(scrollPos, PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"));
            buttonWidth = EditorGUIUtility.currentViewWidth > 400 ? EditorGUIUtility.currentViewWidth / 2 : 200;

            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
            {
                EditorGUILayout.LabelField("CLOUD SCRIPT:", PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"));
                GUILayout.Space(10);
                if (GUILayout.Button("IMPORT", PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinHeight(30)))
                {
                    ImportCloudScript();
                }
                GUILayout.Space(10);
                if (File.Exists(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath))
                {
                    if (GUILayout.Button("REMOVE", PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinHeight(30)))
                    {
                        PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath = string.Empty;
                        PlayFabEditorDataService.SaveEnvDetails();
                    }
                    GUILayout.Space(10);
                    if (GUILayout.Button("EDIT", PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinHeight(30)))
                    {
                        EditorUtility.OpenWithDefaultApp(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath);
                    }
                }
            }

            if (File.Exists(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath))
            {
                var path = File.Exists(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath) ? PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath : PlayFabEditorHelper.CLOUDSCRIPT_PATH;
                var shortPath = "..." + path.Substring(path.LastIndexOf('/'));

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();

                    if (GUILayout.Button(shortPath, PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinWidth(110), GUILayout.MinHeight(20)))
                    {
                        EditorUtility.RevealInFinder(path);
                    }
                    //                            GUILayout.Space(10);
                    //                            if (GUILayout.Button("EDIT LOCALLY", PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinWidth(90), GUILayout.MinHeight(20)))
                    //                            {
                    //                                EditorUtility.OpenWithDefaultApp(path);
                    //                            }
                    GUILayout.FlexibleSpace();
                }

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("SAVE TO PLAYFAB", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.Width(buttonWidth)))
                    {
                        if (EditorUtility.DisplayDialog("Deployment Confirmation", "This action will upload your local Cloud Script changes to PlayFab?", "Continue", "Cancel"))
                        {
                            BeginCloudScriptUpload();
                        }
                    }
                    GUILayout.FlexibleSpace();
                }
            }
            else
            {
                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();
                    EditorGUILayout.LabelField("No Cloud Script files added. Import your file to get started.", PlayFabEditorHelper.uiStyle.GetStyle("orTxt"));
                    GUILayout.FlexibleSpace();
                }
            }
        }

        public static void DrawToolsPanel()
        {
            if (_menu == null)
            {
                RegisterMenu();
                return;
            }
            scrollPos = GUILayout.BeginScrollView(scrollPos, PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"));

            _menu.DrawMenu();
            switch ((ToolSubMenuStates)PlayFabEditorPrefsSO.Instance.curSubMenuIdx)
            {
                case ToolSubMenuStates.CloudScript:
                    DrawCloudScript();
                    break;
                case ToolSubMenuStates.QuickScript:
                    DrawQuickStart();
                    break;

                default:
                    using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
                    {
                        EditorGUILayout.LabelField("Coming Soon!", PlayFabEditorHelper.uiStyle.GetStyle("titleLabel"), GUILayout.MinWidth(EditorGUIUtility.currentViewWidth));
                    }
                    break;
            }
            GUILayout.EndScrollView();
        }

        private static void WriteAssetFiles()
        {
            if (localAssets.Count > 0)
            {
                // We may want to ask user if they want to add telemetry to Start
                foreach (var file in localAssets)
                {
                    var text = System.IO.File.ReadAllText(file);

                    var filepath = file.Split('\\');
                    var filename = filepath[filepath.Length - 1];

                    if (tagStart)
                    {
                        bool addedLine = TryAddSingleLineOfCode(filename, file, text, _StartVoidCode);
                        if (!addedLine)
                        {
                            bool addedLineWithSpace = TryAddSingleLineOfCode(filename, file, text, _StartVoidSpaceCode);
                            if (!addedLineWithSpace)
                            {
                                bool addedLineInEnumerator = TryAddSingleLineOfCode(filename, file, text, _StartEnumerableCode);
                                if (!addedLineInEnumerator)
                                {
                                    bool addedLineInEnumeratorWithSpace = TryAddSingleLineOfCode(filename, file, text, _StartEnumerableSpaceCode);
                                    if (!addedLineInEnumeratorWithSpace)
                                    {
                                        // We didn't find ANY instance of this method. We will ADD our own to the bottom of the class file
                                        AddTelemetryFunction(filename, file, text, _StartVoidCode);
                                    }
                                }
                            }
                        }
                        // re-read as we have changed the file and we need those changes back.
                        text = System.IO.File.ReadAllText(file);
                    }

                    if (tagEnable)
                    {
                        bool addedLine = TryAddSingleLineOfCode(filename, file, text, _EnableVoidCode);
                        if (!addedLine)
                        {
                            bool addedLineWithSpace = TryAddSingleLineOfCode(filename, file, text, _EnableVoidSpaceCode);
                            if (!addedLineWithSpace)
                            {
                                bool addedLineInEnumerator = TryAddSingleLineOfCode(filename, file, text, _EnableEnumerableCode);
                                if (!addedLineInEnumerator)
                                {
                                    bool addedLineInEnumeratorWithSpace = TryAddSingleLineOfCode(filename, file, text, _EnableEnumerableSpaceCode);
                                    if (!addedLineInEnumeratorWithSpace)
                                    {
                                        // We didn't find ANY instance of this method. We will ADD our own to the bottom of the class
                                        AddTelemetryFunction(filename, file, text, _EnableVoidCode);
                                    }
                                }
                            }
                        }
                        // re-read as we have changed the file and we need those changes back.
                        text = System.IO.File.ReadAllText(file);
                    }
                }
            }
        }

        private static void AddTelemetryFunction(string filename, string file, string text, string functionDecl)
        {
            // We want to find the BOTTOM of this file. (or at least the end of the class)
            // first, find the START of the class (filename without .cs at the end) + : MonoBehaviour
            if (filename.EndsWith(".cs"))
            {
                filename = filename.Substring(0, filename.Length - 3);
            }

            // move current index until the first { (class decl)
            var currentIndex = text.LastIndexOf(filename + " : MonoBehaviour");
            int tabs = 0;
            while (text[currentIndex] != '{')
            {
                currentIndex++;
                if (text[currentIndex] == ' ' || text[currentIndex] == '\t')
                {
                    tabs++;
                }
            }

            int currentBracketCount = 1;
            // Keep iterating until we can find a } BUT if we see a { add 1, and subtract for every } that we see
            while (currentBracketCount > 0)
            {
                currentIndex++;
                if (text[currentIndex] == '{')
                {
                    currentBracketCount++;
                }
                else if (text[currentIndex] == '}')
                {
                    currentBracketCount--;
                }
            }

            // Now we want to back up one line
            currentIndex -= tabs - 1;

            var beforeText = text.Substring(0, currentIndex);
            var endText = text.Substring(currentIndex + 1);

            string tabbing = "";
            for (int i = tabs * 2; i != 0; i--)
            {
                tabbing += " ";
            }

            var emitCode = GetEmitCode(filename, functionDecl);
            //var functionText = "\n\r"+tabbing+functionDecl +"\n"+tabbing+"{\n" + tabbing + emitCode + tabbing + "}\n\r";
            var functionText = "\n" + tabbing + functionDecl + "\n" + tabbing + "{\n" + tabbing + emitCode + tabbing + "}\n";
            var fileText = beforeText + functionText + endText;

            System.IO.File.WriteAllText(file, fileText);
        }

        private static bool TryAddSingleLineOfCode(string fileName, string filePath, string fileText, string lookForCode)
        {
            if (fileText.Contains(lookForCode))
            {
                var originalWhereToStartWriting = fileText.LastIndexOf(lookForCode);
                if (originalWhereToStartWriting > 0)
                {
                    var tabbing = "";
                    var currentIndex = originalWhereToStartWriting + lookForCode.Length;

                    // we don't know how many spaces they may have...
                    while (currentIndex < fileText.Length && fileText[currentIndex] != '{') { tabbing += fileText[currentIndex]; currentIndex++; }
                    if (currentIndex < fileText.Length)
                    {
                        // NOW we should know the START of the function.
                        currentIndex += 4; // for \n\r
                        var emitText = GetEmitCode(fileName, lookForCode);
                        var endText = fileText.Substring(currentIndex);
                        fileText = fileText.Substring(0, currentIndex) + tabbing + emitText + endText;
                        System.IO.File.WriteAllText(filePath, fileText);
                        return true;
                    }
                }
            }
            return false;
        }

        private static void GetAssetFiles()
        {
            List<string> possibleTag = new List<string>();
            var projAssetPath = Application.dataPath;
            DirSearch(projAssetPath);
        }

        private static List<string> localAssets = new List<string>();
        static void DirSearch(string sDir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    if (f.EndsWith(".cs") && !f.Contains("PlayFab")) // Don't care about our own files
                    {
                        string fileText = System.IO.File.ReadAllText(f);
                        if (fileText.Contains(": MonoBehaviour"))
                        {
                            // May be faster to keep a ref to that file itself. 
                            // right now we are loading all text in, which can be severly slow.
                            localAssets.Add(f);
                        }
                    }
                    Console.WriteLine(f);
                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        if (f.EndsWith(".cs") && !f.Contains("PlayFab")) // Don't care about our own files
                        {
                            string fileText = System.IO.File.ReadAllText(f);
                            if (fileText.Contains(": MonoBehaviour"))
                            {
                                // May be faster to keep a ref to that file itself. 
                                // right now we are loading all text in, which can be severly slow.
                                localAssets.Add(f);
                            }
                        }
                        Console.WriteLine(f);
                    }
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        private static void ImportCloudScript()
        {
            var dialogResponse = EditorUtility.DisplayDialogComplex("Selcet an Import Option", "What Cloud Script file do you want to import?", "Use my latest PlayFab revision", "Cancel", "Use my local file");
            switch (dialogResponse)
            {
                case 0:
                    // use PlayFab
                    GetCloudScriptRevision();
                    break;
                case 1:
                    // cancel
                    return;
                case 2:
                    //use local
                    SelectLocalFile();
                    break;
            }
        }

        private static void GetCloudScriptRevision()
        {
            // empty request object gets latest versions
            PlayFabEditorApi.GetCloudScriptRevision(new EditorModels.GetCloudScriptRevisionRequest(), (GetCloudScriptRevisionResult result) =>
            {
                var csPath = PlayFabEditorHelper.CLOUDSCRIPT_PATH;
                var location = Path.GetDirectoryName(csPath);
                try
                {
                    if (!Directory.Exists(location))
                        Directory.CreateDirectory(location);
                    if (!File.Exists(csPath))
                        using (var newfile = File.Create(csPath)) { }
                    File.WriteAllText(csPath, result.Files[0].FileContents);
                    Debug.Log("CloudScript uploaded successfully!");
                    PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath = csPath;
                    PlayFabEditorDataService.SaveEnvDetails();
                    AssetDatabase.Refresh();
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                    // PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnError, ex.Message);
                    return;
                }
            }, PlayFabEditorHelper.SharedErrorCallback);
        }

        private static void SelectLocalFile()
        {
            var starterPath = File.Exists(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath) ? Application.dataPath : PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath;
            var cloudScriptPath = string.Empty;
            cloudScriptPath = EditorUtility.OpenFilePanel("Select your Cloud Script file", starterPath, "js");

            if (!string.IsNullOrEmpty(cloudScriptPath))
            {
                PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath = cloudScriptPath;
                PlayFabEditorDataService.SaveEnvDetails();
            }
        }

        private static void BeginCloudScriptUpload()
        {
            var filePath = File.Exists(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath) ? PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath : PlayFabEditorHelper.CLOUDSCRIPT_PATH;

            if (!File.Exists(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath) && !File.Exists(PlayFabEditorHelper.CLOUDSCRIPT_PATH))
            {
                PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnError, "Cloud Script Upload Failed: null or corrupt file at path(" + filePath + ").");
                return;
            }

            var s = File.OpenText(filePath);
            var contents = s.ReadToEnd();
            s.Close();

            var request = new UpdateCloudScriptRequest();
            request.Publish = EditorUtility.DisplayDialog("Deployment Options", "Do you want to make this Cloud Script live after uploading?", "Yes", "No");
            request.Files = new List<CloudScriptFile>(){
                new CloudScriptFile() {
                    Filename = PlayFabEditorHelper.CLOUDSCRIPT_FILENAME,
                    FileContents = contents
                }
            };

            PlayFabEditorApi.UpdateCloudScript(request, (UpdateCloudScriptResult result) =>
            {
                PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath = filePath;
                PlayFabEditorDataService.SaveEnvDetails();

                Debug.Log("CloudScript uploaded successfully!");

            }, PlayFabEditorHelper.SharedErrorCallback);
        }
        public static void RegisterMenu()
        {
            if (_menu != null)
                return;

            _menu = CreateInstance<SubMenuComponent>();
            _menu.RegisterMenuItem("CloudScript", OnCloudScriptClicked);
            _menu.RegisterMenuItem("QuickStart", OnQuickStartClicked);
        }

        public static void OnCloudScriptClicked()
        {
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnSubmenuItemClicked, ToolSubMenuStates.CloudScript.ToString(), "" + (int)ToolSubMenuStates.CloudScript);
        }

        public static void OnQuickStartClicked()
        {
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnSubmenuItemClicked, ToolSubMenuStates.QuickScript.ToString(), "" + (int)ToolSubMenuStates.QuickScript);
        }
    }
}
