using UnityEngine;
using System.Collections.Generic;

namespace PlayFab.Examples
{
    public class UserDataDoc : PfExampleGui
    {
        public override void OnExampleGUI(ref int rowIndex)
        {
            Button(true, rowIndex, 0, "GetReadOnly", GetUserReadOnlyData);
            Button(true, rowIndex, 1, "UpdateReadOnly", UpdateUserReadOnlyData);
            rowIndex++;
            Button(true, rowIndex, 0, "GetInternal", GetUserInternalData);
            Button(true, rowIndex, 1, "UpdateInternal", UpdateUserInternalData);
            rowIndex++;
            Button(true, rowIndex, 0, "CloudSetup", CloudSetup);
            Button(true, rowIndex, 1, "CloudIncrement", CloudIncrement);
        }

        public void UpdateUserReadOnlyData()
        {
            var updateRequest = new ServerModels.UpdateUserDataRequest()
            {
                PlayFabId = PfSharedModelEx.playFabId,
                Data = new Dictionary<string, string>()
        {
            {"Father", "Fred"},
            {"Mother", "Alice"},
            {"Sister", "Lucy"},
            {"Brother", "Doug"}
        },
                Permission = PlayFab.ServerModels.UserDataPermission.Public
            };

            PlayFabServerAPI.UpdateUserReadOnlyData(updateRequest,
                (result) =>
                {
                    Debug.Log("Set read-only user data successful");
                },
                (error) =>
                {
                    Debug.Log("Got error updating read-only user data:");
                    Debug.Log(error.ErrorMessage);
                }
            );
        }

        public void GetUserReadOnlyData()
        {
            var getRequest = new ServerModels.GetUserDataRequest()
            {
                PlayFabId = PfSharedModelEx.playFabId,
            };

            PlayFabServerAPI.GetUserReadOnlyData(getRequest,
                (result) =>
                {
                    Debug.Log("Got the following user read-only data:");
                    foreach (var entry in result.Data)
                        Debug.Log(entry.Key + ": " + entry.Value.Value);
                },
                (error) =>
                {
                    Debug.Log("Got error getting read-only user data:");
                    Debug.Log(error.ErrorMessage);
                }
            );
        }

        public void UpdateUserInternalData()
        {
            var updateRequest = new ServerModels.UpdateUserInternalDataRequest()
            {
                PlayFabId = PfSharedModelEx.playFabId,
                Data = new Dictionary<string, string>()
        {
            {"Class", "Fighter"},
            {"Race", "Human"},
        },
            };

            PlayFabServerAPI.UpdateUserInternalData(updateRequest,
                (result) =>
                {
                    Debug.Log("Set internal user data successful");
                },
                (error) =>
                {
                    Debug.Log("Got error updating internal user data:");
                    Debug.Log(error.ErrorMessage);
                }
            );
        }

        public void GetUserInternalData()
        {
            var getUserDataRequest = new ServerModels.GetUserDataRequest()
            {
                PlayFabId = PfSharedModelEx.playFabId,
            };

            PlayFabServerAPI.GetUserInternalData(getUserDataRequest,
                (result) =>
                {
                    Debug.Log("Got the following user internal data:");
                    foreach (var entry in result.Data)
                        Debug.Log(entry.Key + ": " + entry.Value.Value);
                },
                (error) =>
                {
                    Debug.Log("Got error getting internal user data:");
                    Debug.Log(error.ErrorMessage);
                }
            );
        }

        public void CloudSetup()
        {
            var cloudSetUpRequest = new ClientModels.GetCloudScriptUrlRequest();
            PlayFabClientAPI.GetCloudScriptUrl(cloudSetUpRequest,
                (result) =>
                {
                    Debug.Log("CloudScript setup complete");
                },
                (error) =>
                {
                    Debug.Log("CloudScript setup failed");
                    Debug.Log(error.ErrorMessage);
                }
            );
        }

        public void CloudIncrement()
        {
            var cloudIncrementRequest = new ClientModels.RunCloudScriptRequest();
            cloudIncrementRequest.ActionId = "IncrementReadOnlyUserData";

            PlayFabClientAPI.RunCloudScript(cloudIncrementRequest,
                (result) =>
                {
                    Debug.Log("CloudScript call successful");
                },
                (error) =>
                {
                    Debug.Log("CloudScript call failed");
                    Debug.Log(error.ErrorMessage);
                }
            );
        }
    }
}
