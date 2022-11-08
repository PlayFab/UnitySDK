using PlayFab.PfEditor.EditorModels;
using System;
using System.Collections.Generic;

namespace PlayFab.PfEditor
{
    public class PlayFabEditorApi
    {
        #region FROM EDITOR API SETS ----------------------------------------------------------------------------------------------------------------------------------------
        public static void RegisterAccount(RegisterAccountRequest request, Action<RegisterAccountResult> resultCallback, Action<EditorModels.PlayFabError> errorCb)
        {
            PlayFabEditorHttp.MakeApiCall("/DeveloperTools/User/RegisterAccount", PlayFabEditorHelper.DEV_API_ENDPOINT, request, resultCallback, errorCb);
        }

        public static void Login(LoginRequest request, Action<LoginResult> resultCallback, Action<EditorModels.PlayFabError> errorCb)
        {
            PlayFabEditorHttp.MakeApiCall("/DeveloperTools/User/Login", PlayFabEditorHelper.DEV_API_ENDPOINT, request, resultCallback, errorCb);
        }

        public static void LoginWithAAD(LoginWithAADRequest request, Action<LoginResult> resultCallback, Action<EditorModels.PlayFabError> errorCb)
        {
            PlayFabEditorHttp.MakeApiCall("/DeveloperTools/User/LoginWithAAD", PlayFabEditorHelper.DEV_API_ENDPOINT, request, resultCallback, errorCb);
        }

        public static void Logout(LogoutRequest request, Action<LogoutResult> resultCallback,
            Action<EditorModels.PlayFabError> errorCb)
        {
            PlayFabEditorHttp.MakeApiCall("/DeveloperTools/User/Logout", PlayFabEditorHelper.DEV_API_ENDPOINT, request, resultCallback, errorCb);
        }

        public static void GetStudios(GetStudiosRequest request, Action<GetStudiosResult> resultCallback, Action<EditorModels.PlayFabError> errorCb)
        {
            var token = PlayFabEditorPrefsSO.Instance.DevAccountToken;
            request.DeveloperClientToken = token;
            PlayFabEditorHttp.MakeApiCall("/DeveloperTools/User/GetStudios", PlayFabEditorHelper.DEV_API_ENDPOINT, request, resultCallback, errorCb);
        }

        public static void CreateTitle(CreateTitleRequest request, Action<RegisterAccountResult> resultCallback, Action<EditorModels.PlayFabError> errorCb)
        {
            var token = PlayFabEditorPrefsSO.Instance.DevAccountToken;
            request.DeveloperClientToken = token;
            PlayFabEditorHttp.MakeApiCall("/DeveloperTools/User/CreateTitle", PlayFabEditorHelper.DEV_API_ENDPOINT, request, resultCallback, errorCb);
        }
        #endregion

        #region FROM ADMIN / SERVER API SETS ----------------------------------------------------------------------------------------------------------------------------------------
        public static void GetTitleData(Action<GetTitleDataResult> resultCb, Action<EditorModels.PlayFabError> errorCb)
        {
            var titleId = PlayFabEditorDataService.SharedSettings.TitleId;
            var apiEndpoint = "https://" + titleId + PlayFabEditorHelper.TITLE_ENDPOINT;
            PlayFabEditorHttp.MakeApiCall("/Admin/GetTitleData", apiEndpoint, new GetTitleDataRequest(), resultCb, errorCb);
        }

        public static void SetTitleData(Dictionary<string, string> keys, Action<SetTitleDataResult> resultCb, Action<EditorModels.PlayFabError> errorCb)
        {
            foreach (var pair in keys)
            {
                var req = new SetTitleDataRequest { Key = pair.Key, Value = pair.Value };

                var titleId = PlayFabEditorDataService.SharedSettings.TitleId;
                var apiEndpoint = "https://" + titleId + PlayFabEditorHelper.TITLE_ENDPOINT;
                PlayFabEditorHttp.MakeApiCall("/Admin/SetTitleData", apiEndpoint, req, resultCb, errorCb);
            }
        }
        public static void GetTitleInternalData(Action<GetTitleDataResult> resultCb, Action<EditorModels.PlayFabError> errorCb)
        {
            var titleId = PlayFabEditorDataService.SharedSettings.TitleId;
            var apiEndpoint = "https://" + titleId + PlayFabEditorHelper.TITLE_ENDPOINT;
            PlayFabEditorHttp.MakeApiCall("/Admin/GetTitleInternalData", apiEndpoint, new GetTitleDataRequest(), resultCb, errorCb);
        }

        public static void SetTitleInternalData(Dictionary<string, string> keys, Action<SetTitleDataResult> resultCb, Action<EditorModels.PlayFabError> errorCb)
        {
            foreach (var pair in keys)
            {
                var req = new SetTitleDataRequest { Key = pair.Key, Value = pair.Value };

                var titleId = PlayFabEditorDataService.SharedSettings.TitleId;
                var apiEndpoint = "https://" + titleId + PlayFabEditorHelper.TITLE_ENDPOINT;
                PlayFabEditorHttp.MakeApiCall("/Admin/SetTitleInternalData", apiEndpoint, req, resultCb, errorCb);
            }
        }

        public static void UpdateCloudScript(UpdateCloudScriptRequest request, Action<UpdateCloudScriptResult> resultCb, Action<EditorModels.PlayFabError> errorCb)
        {
            var titleId = PlayFabEditorDataService.SharedSettings.TitleId;
            var apiEndpoint = "https://" + titleId + PlayFabEditorHelper.TITLE_ENDPOINT;
            PlayFabEditorHttp.MakeApiCall("/Admin/UpdateCloudScript", apiEndpoint, request, resultCb, errorCb);
        }

        public static void GetCloudScriptRevision(GetCloudScriptRevisionRequest request, Action<GetCloudScriptRevisionResult> resultCb, Action<EditorModels.PlayFabError> errorCb)
        {
            var titleId = PlayFabEditorDataService.SharedSettings.TitleId;
            var apiEndpoint = "https://" + titleId + PlayFabEditorHelper.TITLE_ENDPOINT;
            PlayFabEditorHttp.MakeApiCall("/Admin/GetCloudScriptRevision", apiEndpoint, request, resultCb, errorCb);
        }
        #endregion
    }
}
