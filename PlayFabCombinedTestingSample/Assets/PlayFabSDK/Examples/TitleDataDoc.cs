using UnityEngine;
using System.Collections.Generic;

namespace PlayFab.Examples
{
    public class TitleDataDoc : PfExampleGui
    {
        public override void OnExampleGUI(ref int rowIndex)
        {
            Button(true, rowIndex, 0, "ClientGetTitleData", ClientGetTitleData);
            rowIndex++;
            Button(true, rowIndex, 0, "ServerGetTitleData", ServerGetTitleData);
            Button(true, rowIndex, 1, "SetTitleData", SetTitleData);
            rowIndex++;
            Button(true, rowIndex, 0, "GetTitleInternalData", GetTitleInternalData);
            Button(true, rowIndex, 1, "SetTitleInternalData", SetTitleInternalData);
        }

        public void ClientGetTitleData()
        {
            var getRequest = new ClientModels.GetTitleDataRequest();
            PlayFabClientAPI.GetTitleData(getRequest,
                (result) =>
                {
                    Debug.Log("Got the following titleData:");
                    foreach (var entry in result.Data)
                        Debug.Log(entry.Key + ": " + entry.Value);
                },
                (error) =>
                {
                    Debug.Log("Got error getting titleData:");
                    Debug.Log(error.ErrorMessage);
                }
            );
        }

        public void SetTitleData()
        {
            var updateRequest = new ServerModels.SetTitleDataRequest();
            updateRequest.Key = "MonsterName";
            updateRequest.Value = "Dorf";

            PlayFabServerAPI.SetTitleData(updateRequest,
                (result) =>
                {
                    Debug.Log("Set titleData successful");
                },
                (error) =>
                {
                    Debug.Log("Got error setting titleData:");
                    Debug.Log(error.ErrorMessage);
                }
            );
        }

        public void ServerGetTitleData()
        {
            var getRequest = new ServerModels.GetTitleDataRequest();
            PlayFabServerAPI.GetTitleData(getRequest,
                (result) =>
                {
                    Debug.Log("Got the following titleData:");
                    foreach (var entry in result.Data)
                        Debug.Log(entry.Key + ": " + entry.Value);
                },
                (error) =>
                {
                    Debug.Log("Got error getting titleData:");
                    Debug.Log(error.ErrorMessage);
                }
            );
        }

        public void GetTitleInternalData()
        {
            var getRequest = new ServerModels.GetTitleDataRequest();
            PlayFabServerAPI.GetTitleInternalData(getRequest,
                (result) =>
                {
                    Debug.Log("Got the following titleData:");
                    foreach (var entry in result.Data)
                        Debug.Log(entry.Key + ": " + entry.Value);
                },
                (error) =>
                {
                    Debug.Log("Got error getting titleData:");
                    Debug.Log(error.ErrorMessage);
                }
            );
        }

        public void SetTitleInternalData()
        {
            var updateRequest = new ServerModels.SetTitleDataRequest();
            updateRequest.Key = "PlayFab";
            updateRequest.Value = "{ \"Status\": \"Secretly Awesome\" }";

            PlayFabServerAPI.SetTitleInternalData(updateRequest,
                (result) =>
                {
                    Debug.Log("Set titleData successful");
                },
                (error) =>
                {
                    Debug.Log("Got error setting titleData:");
                    Debug.Log(error.ErrorMessage);
                }
            );
        }
    }
}
