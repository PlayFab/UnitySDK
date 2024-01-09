# UnitySDK README

The PlayFab Unity SDK consists of two packages—PlayFab [UnitySDK](https://aka.ms/PlayFabUnitySdk) and the optional [PlayFab Unity Editor Extensions](https://aka.ms/PlayFabUnityEdEx).

The Editor Extensions package provides a simple user interface to help you download, install, configure, upgrade the PlayFab SDK. It is the simpler way to get set up right away. However, it requires you to include additional files into your project.

If you are an advanced user, consider installing the PlayFab SDK directly by extracting the package and configuring the scriptable-objects using the Unity inspector window. Detailed instructions on how to get started are provided in the section below.

## 1. Overview:

This document describes the process of configuring and building the PlayFab Unity package and distribution package. The document also contains instructions for developers to start using the package in their Unity games.

## 2. Prerequisites:

This document assumes familiarity with the Unity game engine, MonoDevelop Unity .NET programming environment, and Mac OS X operating system environment.

* Users should also be familiar with the topics covered in our [getting started guide](https://learn.microsoft.com/gaming/playfab/what-is-playfab).

## 3. Installing or Upgrading the PlayFab UnitySdk

### Editor Extensions UI Installation

1. Download the [Editor Extensions package](https://aka.ms/PlayFabUnityEdEx)
2. Open and run your Unity project
3. From the Unity editor, go to **Assets** > **Import Package** > **Custom Package** and then select the downloaded PlayFabEditorExtensions package. For latest instructions on how to add a custom package, go to Unity documentation site.
4. A new window pops up displaying all the files that would be imported into your project. Select **Import** to add all of the files.
After a successful installation, you will see the PlayFab panel with the Create account or login UI in the Unity editor.

### Editor Extensions SDK Installation/Update

1. Log in using the Editor Extensions panel
2. If your SDK is missing or out-of-date, you'll see an orange install/update button

### Manual Installation

You can install the SDK directly by downloading the latest [SDK Asset Package](https://aka.ms/PlayFabUnitySdk) directly.

Detailed Manual Instructions:
* Download [UnitySDK.unitypackage](https://aka.ms/PlayFabUnitySdk) to a safe location.
* [Only When updating]: Delete your {ProjectLocation}/assets/PlayFab*/ directories.
 * (Very old SDKs) You may also need to delete PlayFab specific files in your {ProjectLocation}/assets/Plugins/ directory.
 * Failing to do this step may cause compiler errors and/or unexpected runtime errors
* Unpack the .unitypackage file into your project.

Advanced users can copy the contents of https://github.com/PlayFab/UnitySDK/tree/master/ExampleTestProject/Assets into their existing project.

#### PlayFab Configuration:
You must configure the SDK with your unique TitleId.  This is done via the PlayFabSharedSettings ScriptableObject or the PlayFab Editor Extensions panel.

In your Unity Project tab, navigate to: assets/PlayFabSDK/Shared/Public/Resources and select the PlayFabSharedSettings ScriptableObject.

Advanced users can still add this line of code anywhere in their game setup:

```C#
PlayFabSettings.TitleId = "144";
```

#### HTTP Request Configuration:

From the EdEx panel (Settings -> Project), or the PlayFabSharedSettings scriptable object, you can set the web request implementaiton used when making HTTPS REST calls to PlayFab.

UnityWebRequest should be your default choice for any new projects. All other options exist for compatibility or customization. It uses the UnityWebRequest built-in engine class and should be appropriate for most scenarios on most platforms and modern engine versions.

The HttpWebRequest option uses the C# HttpRequest library. This option is multi-threaded, and most of the requests will not execute on the main thread. Additionally, advanced users can use PlayFabSettings to customize their request timeouts and other HttpRequest settings (not documented).

The UnityWww option is only available on older versions of the engine (pre 2018.2). It uses the Unity WWW class to make web requests.

The CustomHttp option exists for those that wish to implement their own ITransportPlugin. If you need to go down this route, you can follow the existing code in either PlayFabUnityHttp.cs or PlayFabWebRequest.cs. When you need to register your custom plugin, call PluginManager.SetPlugin using a PluginContract of PlayFab_Transport.

#### To make server API calls:

The best way to do this is enable it from the PlayFab Editor Extensions Panel (PlayFab Panel -> Settings -> API).

Non EdEx panel users: This guide will direct you how to find the "Scripting Define Symbols": https://docs.unity3d.com/Manual/PlatformDependentCompilation.html, under the heading "Platform Custom Defines".

The Unity setting you need to modify is:
Edit -> Projet Settings -> Player -> "PC & Mac & Linux Standalone" -> "Platform Custom Defines"
Add ENABLE_PLAYFABSERVER_API

You can also choose other platforms in place of "PC & Mac & Linux Standalone", but this is not recommended.

You can now set "Developer Secret Key" in assets/PlayFabSDK/Shared/Public/Resources/PlayFabSharedSettings.asset

Refer to [Secret key Management](https://docs.microsoft.com/gaming/playfab/gamemanager/secret-key-management) to find your secret key, also called a developer key to your PlayFab Title.


Advanced users can still set their secret key anywhere in their game setup:

```C#
    PlayFabSettings.DeveloperSecretKey = "Find this in your dashboard/settings https://developer.playfab.com/title/properties/{your title Id}"; //your Developer Secret goes here.
```

## 4. Usage Instructions:

You are now ready to begin making API calls using the PlayFabClientAPI class. Check out the online [documentation](https://learn.microsoft.com/rest/api/playfab/client/?view=playfab-rest) for a complete list of available APIs.

##### New Users:

* Check out our Tutorials, Samples and more [here](https://learn.microsoft.com/gaming/playfab/resources/playfab-samples)

## 5. Troubleshooting:

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
