# UnitySDK README

The easist way to get started is to use our [EditorExtensions plugin](https://github.com/PlayFab/UnityEditorExtensions). This plugin provides a clean UI for configuring the SDK as well as automatically downloading, installing and upgrading the PlayFab SDK.


## 1. Overview:

This document describes the process of configuring and building the PlayFab Unity plugin binary and distribution package. The document also contains instructions for developers to start using the plugin in their Unity games.


## 2. Prerequisites:

This document assumes familiarity with the Unity game engine, MonoDevelop Unity .NET programming environment, and Mac OS X operating system environment.

* Users should also be familiar with the topics covered in our [getting started guide](https://api.playfab.com/docs/general-getting-started).

To connect to the PlayFab service, your machine must be running TLS v1.2 or better.
* For Windows, this means Windows 7 and above
* [Official Microsoft Documentation](https://msdn.microsoft.com/en-us/library/windows/desktop/aa380516%28v=vs.85%29.aspx)
* [Support for SSL/TLS protocols on Windows](http://blogs.msdn.com/b/kaushal/archive/2011/10/02/support-for-ssl-tls-protocols-on-windows.aspx)


## 3. Installing or Upgrading the PlayFab UnitySdk

The easist way to get started is to use our [EditorExtensions plugin](https://github.com/PlayFab/UnityEditorExtensions). This plugin provides a clean UI for configuring the SDK as well as automatically downloading, installing and upgrading the PlayFab SDK.

Alternatively you can install the latest [Asset Package](https://api.playfab.com/sdks/download/unity-v2ap) directly. 

Detailed Instructions:
* Download [UnitySDK.unitypackage](https://api.playfab.com/sdks/download/unity-v2ap) to a safe location.
* [Only When updating]: Delete your {ProjectLocation}/assets/PlayFab/ directory.
 * You may also need to delete PlayFab specific files in your {ProjectLocation}/assets/Plugins/ directory.
 * Failing to do this step may cause compiler errors and/or unexpected runtime errors
* Unpack the .unitypackage file into your project.

Advanced users can copy the contents of https://github.com/PlayFab/UnitySDK/raw/master/Source into their existing project.

#### Configuration:
You must configure the SDK with you unique TitleId.  This is done via the PlayFabSharedSettings ScriptableObject.

In your Unity Project tab, navigate to: assets/PlayFabSDK/Shared/Public/Resources and select the PlayFabSharedSettings ScriptableObject.

Advanced users can still add this line of code anywhere in their game setup:

```C#
PlayFabSettings.TitleId = "AD08";
```

To make server API calls:
This guide will direct you how to find the "Scripting Define Symbols": https://docs.unity3d.com/Manual/PlatformDependentCompilation.html, under the heading "Platform Custom Defines".

The Unity setting you need to modify is:
Edit -> Projet Settings -> Player -> "PC & Mac & Linux Standalone" -> "Platform Custom Defines"
Add ENABLE_PLAYFABSERVER_API

You can also choose other platforms in place of "PC & Mac & Linux Standalone", but this is not recommended.

You can now set "Developer Secret Key" in assets/PlayFabSDK/Shared/Public/Resources/PlayFabSharedSettings.asset

Advanced users can still set their secret key anywhere in their game setup:

```C#
    PlayFabSettings.DeveloperSecretKey = "Find this in your dashboard/settings https://developer.playfab.com/title/properties/{your title Id}"; //your Developer Secret goes here.
```

## 4. Usage Instructions:

You are now ready to begin making API calls using the PlayFabClientAPI class. Check out the online [documentation](https://api.playfab.com/documentation/client) for a complete list of available APIs.

##### New Users:
* Check out our Tutorials, Samples and more [here](https://api.playfab.com/docs/tutorials)

##### Using the Push Plugin for Android
  * View [this repository](https://github.com/PlayFab/UnitySDK/tree/master/AndroidPluginSrc) for complete details.

## 5. Troubleshooting:

CASE: Follow these instructions to disable IDFA for your IOS release:
 * In Unity, navigate to and open: {YourUnityProject}/Assets/Plugins/iOS/PlayFabURLRequest.mm
  * Uncomment the first line:  // #define DISABLE_IDFA // If you need to disable IDFA for your game, uncomment this
 * In Unity, view the inspector window when you select (do not open): {YourUnityProject}/Assets/Plugins/iOS/PlayFabURLRequest.mm
  * Uncheck the "AdSupport" option under "Platform settings"
 * In Unity, Edit -> Project Settings -> Player
  * Select the iOS tab
  * Scripting Define Symbols
  * Add this: DISABLE_IDFA

CASE: If you run into conflicts when upgrading SDKs, remove all files from previous versions and perform a fresh import of our unitypackage or SDK files. 

#### Contact Us
We love to hear from our developer community! 
Do you have ideas on how we can make our products and services better? 

Our Developer Success Team can assist with answering any questions as well as process any feedback you have about PlayFab services.

[Forums, Support and Knowledge Base](https://community.playfab.com/index.html)

## 6. Copyright and Licensing Information:

  Apache License -- 
  Version 2.0, January 2004
  http://www.apache.org/licenses/

  Full details available within the LICENSE file.
