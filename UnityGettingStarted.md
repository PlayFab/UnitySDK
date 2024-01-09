Unity3d Getting Started Guide
----

This guide will help you make your first API call in Unity3d.

Unity Project Setup
----

* OS: This guide is written for Windows 10, however it should also work fine with a Mac
* Download Unity3d
  * https://store.unity.com/download
  * We support all recent versions of Unity, some features work better with 5.3 or higher
  * Unity requires a license.  Pick personal or professional based on your preferences
  * Keep going until you can start a new project
  * ![Unity image](/images/Unity/UnityCreateProject.png)
  * Finish creating a new empty project with a name and location of your choice
* Download PlayFab UnitySdk Unitypackage
  * https://aka.ms/PlayFabUnitySdk
  * Find the "Project" window in the Unity editor
  * Import the PlayFab unitypackage one of two ways:
    * From Windows, Drag the PlayFab UnitySDK.unitypackage file onto the Project panel in Unity
    * Right click empty space in the Project panel in Unity -> Import Package -> Custom Package...
      * Find and select the PlayFab UnitySDK.unitypackage
  * Once you see this window, click Import:
  * ![Unity image](/images/Unity/UnityImport.png)
* PlayFab installation complete

Set up your first API call
----

This guide will provide the minimum steps to make your first PlayFab API call, without any GUI or on-screen feedback.  Confirmation will be done with the Console log.

* Find the Project panel
* Create a new C# script named "PlayFabLogin"
  * ![Unity image](/images/Unity/FirstScript.png)
* In Unity, Double click this file to open it in a code-editor
  * Depending on your settings/installed-programs, this will likely be Visual Studio or MonoDevelop
* Replace the contents of PlayFabLogin.cs with the following:

```C#
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    public void Start()
    {
        PlayFabSettings.TitleId = "144"; // Please change this value to your own titleId from PlayFab Game Manager

        var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true};
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
}
```

* Create a new gameobject, and attach this script to this gameobject
* In PlayFab Game Manager (via the PlayFab website), you should be able to create your own account, and game title
  * See the first half of this guide for details:
  * [PlayFab Getting Started](https://learn.microsoft.com/gaming/playfab/gamemanager/quickstart)
* Once you have done this, please find this line in PlayFabLogin.cs created above:
  * PlayFabSettings.TitleId = "144"; // Please change this value to your own titleId from PlayFab Game Manager
  * Replace "144" with your own titleId, from Game Manager

Finish and Execute
----

* Save all files, and return to the Unity Editor
* Press the Play button at the top of the editor
* Ideally you should see the following in your Unity Console panel:
  * ![Unity image](/images/Unity/FirstCallLog.png)
* At this point, you can start making other API calls, and building your game
* For a list of all available client API calls, see our documentation:
  * https://learn.microsoft.com/rest/api/playfab/client/?view=playfab-rest
* Happy coding!

Deconstruct the code
----

This optional last section describes each part of PlayFabLogin.cs in detail.

* There are 3 functions in PlayFabLogin
  * Setup, OnLoginSuccess, OnLoginFailure
  * Setup is a Unity function which is automatically called for every MonoBehaviour object
    * See the [Unity Monobehavour Guide](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html) for more information about MonoBehavour
  * OnLoginSuccess, OnLoginFailure are callback functions asynchronously invoked by PlayFabClientAPI.LoginWithCustomID
    * These callbacks do not happen immediately.  API calls take anywhere from 50-200 ms for a desktop on a fast connection.  Mobile devices with a poor connection can take significantly longer.  Your game will continue running normally while PlayFab API calls happen in the background.  Your callback functions will be called in a Unity Coroutine once the server response is parsed.
    * See the [Unity Coroutine Guide](https://docs.unity3d.com/Manual/Coroutines.html) for more information about Coroutines

Inside of Setup:

* PlayFabSettings.TitleId = "xxxx";
  * Every PlayFab developer creates a title in Game Manager.  When you publish your game, you must code that titleId into your game.  This lets the client know how to access the correct data within PlayFab.  For most users, just consider it a mandatory step that makes PlayFab work.
* var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true};
  * Most PlayFab API methods require input parameters, and those input parameters are packed into a request object
  * Every API method requires a unique request object, with a mix of optional and mandatory parameters
    * For LoginWithCustomIDRequest, there is a mandatory parameter of CustomId, which uniquely identifies a player and CreateAccount, which allows the creation of a new account with this call.
  * For login, most developers will want to use a more appropriate login method
    * See the [PlayFab Login Documentation](https://learn.microsoft.com/rest/api/playfab/client/authentication?view=playfab-rest) for a list of all login methods, and input parameters.  Common choices are:
      * [LoginWithAndroidDeviceID](https://learn.microsoft.com/rest/api/playfab/client/authentication/login-with-android-device-id?view=playfab-rest)
      * [LoginWithIOSDeviceID](https://learn.microsoft.com/rest/api/playfab/client/authentication/login-with-ios-device-id?view=playfab-rest)
      * [LoginWithEmailAddress](https://learn.microsoft.com/rest/api/playfab/client/authentication/login-with-email-address?view=playfab-rest)
* Inside of OnLoginSuccess:
  * The result object of many API success callbacks will contain the requested information
  * LoginResult contains some basic information about the player, but for most users, login is simply a mandatory step before calling other APIs
* Inside of OnLoginFailure:
  * API calls can fail for many reasons, and you should always attempt to handle failure
  * Why API calls fail (In order of likelihood)
    * PlayFabSettings.TitleId is not set.  If you forget to set titleId to your title, then nothing will work
    * Request parameters.  If you have not provided the correct or required information for a particular API call, then it will fail.  See error.errorMessage, error.errorDetails, or error.GenerateErrorReport() for more info
    * Device connectivity issue.  Cell-phones lose/regain connectivity constantly, and so any API call at any time can fail randomly, and then work immediately after.  Going into a tunnel can disconnect you completely
    * PlayFab server issue.  As with all software, there can be issues.  See our [release notes](https://learn.microsoft.com/gaming/playfab/release-notes/) for updates
    * The internet is not 100% reliable.  Sometimes the message is corrupted or fails to reach the PlayFab server
  * If you are having difficulty debugging an issue, and the information within the error callback is not sufficient, please visit us on our [forums](https://community.playfab.com/index.html)
