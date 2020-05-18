using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using PlayFab.PfEditor.Json;

namespace PlayFab.PfEditor
{
    [InitializeOnLoad]
    public static partial class PlayFabEditorHelper
    {
        #region EDITOR_STRINGS
        public static string EDEX_NAME = "PlayFab_EditorExtensions";
        public static string EDEX_ROOT = Application.dataPath + "/PlayFabEditorExtensions/Editor";
        public static string DEV_API_ENDPOINT = "https://editor.playfabapi.com";
        public static string TITLE_ENDPOINT = ".playfabapi.com";
        public static string GAMEMANAGER_URL = "https://developer.playfab.com";
        public static string PLAYFAB_SETTINGS_TYPENAME = "PlayFabSettings";
        public static string PLAYFAB_EDEX_MAINFILE = "PlayFabEditor.cs";
        public static string SDK_DOWNLOAD_PATH = "/Resources/PlayFabUnitySdk.unitypackage";
        public static string EDEX_UPGRADE_PATH = "/Resources/PlayFabUnityEditorExtensions.unitypackage";
        public static string EDEX_PACKAGES_PATH = "/Resources/MostRecentPackage.unitypackage";

        public static string CLOUDSCRIPT_FILENAME = ".CloudScript.js";  //prefixed with a '.' to exclude this code from Unity's compiler
        public static string CLOUDSCRIPT_PATH = EDEX_ROOT + "/Resources/" + CLOUDSCRIPT_FILENAME;

        public static string ADMIN_API = "ENABLE_PLAYFABADMIN_API";
        public static string CLIENT_API = "DISABLE_PLAYFABCLIENT_API";
        public static string ENTITY_API = "DISABLE_PLAYFABENTITY_API";
        public static string SERVER_API = "ENABLE_PLAYFABSERVER_API";
        public static string DEBUG_REQUEST_TIMING = "PLAYFAB_REQUEST_TIMING";
        public static string ENABLE_PLAYFABPLAYSTREAM_API = "ENABLE_PLAYFABPLAYSTREAM_API";
        public static string ENABLE_BETA_FETURES = "ENABLE_PLAYFAB_BETA";
        public static string ENABLE_PLAYFABPUBSUB_API = "ENABLE_PLAYFABPUBSUB_API";
        public static Dictionary<string, PfDefineFlag> FLAG_LABELS = new Dictionary<string, PfDefineFlag> {
            { ADMIN_API, new PfDefineFlag { Flag = ADMIN_API, Label = "ENABLE ADMIN API", Category = PfDefineFlag.FlagCategory.Api, isInverted = false, isSafe = true } },
            { CLIENT_API, new PfDefineFlag { Flag = CLIENT_API, Label = "ENABLE CLIENT API", Category = PfDefineFlag.FlagCategory.Api, isInverted = true, isSafe = true } },
            { ENTITY_API, new PfDefineFlag { Flag = ENTITY_API, Label = "ENABLE ENTITY API", Category = PfDefineFlag.FlagCategory.Api, isInverted = true, isSafe = true } },
            { SERVER_API, new PfDefineFlag { Flag = SERVER_API, Label = "ENABLE SERVER API", Category = PfDefineFlag.FlagCategory.Api, isInverted = false, isSafe = true } },

            { DEBUG_REQUEST_TIMING, new PfDefineFlag { Flag = DEBUG_REQUEST_TIMING, Label = "ENABLE REQUEST TIMES", Category = PfDefineFlag.FlagCategory.Feature, isInverted = false, isSafe = true } },
            { ENABLE_BETA_FETURES, new PfDefineFlag { Flag = ENABLE_BETA_FETURES, Label = "ENABLE UNSTABLE FEATURES", Category = PfDefineFlag.FlagCategory.Feature, isInverted = false, isSafe = true } },
            { ENABLE_PLAYFABPUBSUB_API, new PfDefineFlag { Flag = ENABLE_PLAYFABPUBSUB_API, Label = "ENABLE PubSub", Category = PfDefineFlag.FlagCategory.Feature, isInverted = false, isSafe = false } },
        };

        public static string DEFAULT_SDK_LOCATION = "Assets/PlayFabSdk";
        public static string STUDIO_OVERRIDE = "_OVERRIDE_";

        public static string MSG_SPIN_BLOCK = "{\"useSpinner\":true, \"blockUi\":true }";
        #endregion

        private static GUISkin _uiStyle;
        public static GUISkin uiStyle
        {
            get
            {
                if (_uiStyle != null)
                    return _uiStyle;
                _uiStyle = GetUiStyle();
                return _uiStyle;
            }
        }

        static PlayFabEditorHelper()
        {
            // scan for changes to the editor folder / structure.
            if (uiStyle == null)
            {
                string[] rootFiles = new string[0];
                bool relocatedEdEx = false;
                _uiStyle = null;

                try
                {
                    if (!string.IsNullOrEmpty(PlayFabEditorPrefsSO.Instance.EdExPath))
                        EDEX_ROOT = PlayFabEditorPrefsSO.Instance.EdExPath;
                    rootFiles = Directory.GetDirectories(EDEX_ROOT);
                }
                catch
                {

                    if (rootFiles.Length == 0)
                    {
                        // this probably means the editor folder was moved.
                        // see if we can locate the moved root and reload the assets

                        var movedRootFiles = Directory.GetFiles(Application.dataPath, PLAYFAB_EDEX_MAINFILE, SearchOption.AllDirectories);
                        if (movedRootFiles.Length > 0)
                        {
                            relocatedEdEx = true;
                            EDEX_ROOT = movedRootFiles[0].Substring(0, movedRootFiles[0].LastIndexOf(PLAYFAB_EDEX_MAINFILE) - 1);
                            PlayFabEditorPrefsSO.Instance.EdExPath = EDEX_ROOT;
                            PlayFabEditorDataService.SaveEnvDetails();
                        }
                    }
                }
                finally
                {
                    if (relocatedEdEx && rootFiles.Length == 0)
                    {
                        Debug.Log("Found new EdEx root: " + EDEX_ROOT);
                    }
                    else if (rootFiles.Length == 0)
                    {
                        Debug.Log("Could not relocate the PlayFab Editor Extension");
                        EDEX_ROOT = string.Empty;
                    }
                }
            }
        }

        private static GUISkin GetUiStyle()
        {
            var searchRootAssetFolder = Application.dataPath;
            var pfGuiPaths = Directory.GetFiles(searchRootAssetFolder, "PlayFabStyles.guiskin", SearchOption.AllDirectories);
            foreach (var eachPath in pfGuiPaths)
            {
                var loadPath = eachPath.Substring(eachPath.LastIndexOf("Assets"));
                return (GUISkin)AssetDatabase.LoadAssetAtPath(loadPath, typeof(GUISkin));
            }
            return null;
        }

        public static void SharedErrorCallback(EditorModels.PlayFabError error)
        {
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnError, error.GenerateErrorReport());
        }

        public static void SharedErrorCallback(string error)
        {
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnError, "SharedErrorCallback" + error);
        }

        public static EditorModels.PlayFabError GeneratePlayFabError(string json, object customData = null)
        {
            JsonObject errorDict = null;
            Dictionary<string, List<string>> errorDetails = null;
            try
            {
                //deserialize the error
                errorDict = JsonWrapper.DeserializeObject<JsonObject>(json, PlayFabEditorUtil.ApiSerializerStrategy);


                if (errorDict.ContainsKey("errorDetails"))
                {
                    var ed = JsonWrapper.DeserializeObject<Dictionary<string, List<string>>>(errorDict["errorDetails"].ToString());
                    errorDetails = ed;
                }
            }
            catch (Exception e)
            {
                return new EditorModels.PlayFabError()
                {
                    ErrorMessage = e.Message
                };
            }

            //create new error object
            return new EditorModels.PlayFabError
            {
                HttpCode = errorDict.ContainsKey("code") ? Convert.ToInt32(errorDict["code"]) : 400,
                HttpStatus = errorDict.ContainsKey("status")
                    ? (string)errorDict["status"]
                    : "BadRequest",
                Error = errorDict.ContainsKey("errorCode")
                    ? (EditorModels.PlayFabErrorCode)Convert.ToInt32(errorDict["errorCode"])
                    : EditorModels.PlayFabErrorCode.ServiceUnavailable,
                ErrorMessage = errorDict.ContainsKey("errorMessage")
                    ? (string)errorDict["errorMessage"]
                    : string.Empty,
                ErrorDetails = errorDetails,
                CustomData = customData ?? new object()
            };
        }

        #region unused, but could be useful

        /// <summary>
        /// Tool to create a color background texture
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="col"></param>
        /// <returns>Texture2D</returns>
        public static Texture2D MakeTex(int width, int height, Color col)
        {
            var pix = new Color[width * height];

            for (var i = 0; i < pix.Length; i++)
                pix[i] = col;

            var result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();

            return result;
        }

        public static Vector3 GetColorVector(int colorValue)
        {
            return new Vector3((colorValue / 255f), (colorValue / 255f), (colorValue / 255f));
        }
        #endregion
    }

    public class PfDefineFlag
    {
        public enum FlagCategory
        {
            Api,
            Feature,
            Other,
        }

        public string Flag; // Also doubles as the dictionary key
        public string Label;
        public FlagCategory Category;
        public bool isInverted;
        public bool isSafe;
    }
}
