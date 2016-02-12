using System;
using System.Collections.Generic;
using System.IO;
using PlayFab.Internal;
using UnityEngine;

namespace PlayFab.Examples.Client
{
    public class C_LoginExampleGui : PfExampleGui
    {
        public string titleDataFileName = "C:/depot/pf-main/tools/SDKBuildScripts/testTitleData.json";

        [Tooltip("Set your titleId here")]
        public string titleId;
        [Tooltip("Set your title secret key here")]
        public string devSecretKey;

        [Tooltip("Login username")]
        public string userName; // Pick an existing valid username for this title
        [Tooltip("Valid email for above user")]
        public string email; // The email assigned to the user above
        [Tooltip("Valid password for above user")]
        public string password; // The password for the user above

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();

            // Login
            Button(!isLoggedIn, rowIndex, 0, "Login", Login);
        }

        public void Login()
        {
            if (string.IsNullOrEmpty(titleId) || string.IsNullOrEmpty(devSecretKey))
            {
                Debug.Log("Logging in using TitleData info");

                bool success = true;
                if (!File.Exists(titleDataFileName))
                {
                    Console.WriteLine("Loading testSettings file failed: " + titleDataFileName);
                    Console.WriteLine("From: " + Directory.GetCurrentDirectory());
                    return;
                }

                string hiddenSecretKey; // Don't want to display this to the inspector if we use this mode
                string testInputsFile = File.ReadAllText(titleDataFileName);

                var testInputs = SimpleJson.DeserializeObject<Dictionary<string, string>>(testInputsFile, Util.ApiSerializerStrategy);

                success &= testInputs.TryGetValue("titleId", out titleId);
                success &= testInputs.TryGetValue("developerSecretKey", out hiddenSecretKey);

                success &= testInputs.TryGetValue("userName", out userName);
                success &= testInputs.TryGetValue("userEmail", out email);
                success &= testInputs.TryGetValue("userPassword", out password);

                if (success)
                    LoginExample.LoginWithEmail(titleId, hiddenSecretKey, email, password);
                else
                    Debug.Log("TitleData file not formatted correctly.");
            }
            else
            {
                Debug.Log("Logging in using provided info");
                LoginExample.LoginWithEmail(titleId, devSecretKey, email, password);
            }
        }
        #endregion Unity GUI
    }
}
