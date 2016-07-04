UnitySDK README
========
Welcome to the PlayFab Unity SDK. The quickest way to get started is to import our asset package: [PlayFabClientSDK.unitypackage](https://github.com/PlayFab/UnitySDK/raw/master/PlayFabClientSDK.unitypackage).

1. Overview:
----
This document describes the process of configuring and building the PlayFab Unity plugin binary and distribution package. The document also contains instructions for developers to start using the plugin in their Unity games.

2. Prerequisites:
----
This document assumes familiarity with the Unity game engine, MonoDevelop Unity .NET programming environment, and Mac OS X operating system environment.

* Users should also be familiar with the topics covered in our [getting started guide](https://playfab.com/docs/getting-started-with-playfab/).

To connect to the PlayFab service, your machine must be running TLS v1.2 or better.
* For Windows, this means Windows 7 and above
* [Official Microsoft Documentation](https://msdn.microsoft.com/en-us/library/windows/desktop/aa380516%28v=vs.85%29.aspx)
* [Support for SSL/TLS protocols on Windows](http://blogs.msdn.com/b/kaushal/archive/2011/10/02/support-for-ssl-tls-protocols-on-windows.aspx)

3. Upgrading from previous versions
---
The easist way to stay up-to-date is to install our latest asset package. This will ensure that only new and changed files will be updated. 

You can also manually update by overwriting the entire PlayFabSDK folder as well as the relevant Plugins subdirectories. 

4. Source Code & Key Repository Components:
----
Our repository contains these major sections:

1. **PlayFabClientSDK.unitypackage** - The fastest way to get started, ready for importing into your Unity project
2. **PlayFabClientSample** - The base Unity project from which the asset package is built
	1. This is the minimal subset of files required to use the PlayFab Client API
3. **PlayFabServerSample** - Similar to PlayFabClientSample, but using server APIs
	1. This is the minimal subset of files required to use the PlayFab Server API
	2. This project contains a variable called DeveloperSecretKey - For security reasons you must never expose this value to players
4. **PlayFabCombinedTestingSample** - This sample has a working set of unit tests that make several API calls and verify PlayFab functionality
	1. This project demonstrates how to execute both client and server API calls with the SDK, and minimally analyze the results
	2. This project contains a variable called DeveloperSecretKey - For security reasons you should never expose this value to players
5. **UnityAndroidPluginSource** - Contains the source code for our native Android plugin

5. Installing and Configuring the PlayFab Unity SDK:
----
#### Install the Unity SDK using the Unity Package 
Open your Unity project, open the PlayFabClientSDK.unitypackage, and import the entire structure. 

#### Install the Unity SDK into another Unity project:
 1. Extract the UnitySdk to a location of your choice (described as the UnitySDkFolder for the rest of this example)
 2. Create a new Unity project or open an existing Unity project
 3. Navigate to UnitySDkFolder\PlayFabClientSample\Assets
 4. Copy the PlayFabSDK folder from the example project, into your new/existing project's Assets folder
 6. [Client only] Copy the Plugins from the example project, into your new/existing project's Assets folder
 7. Begin integrating PlayFab calls into your project
   1. UnitySDkFolder\PlayFabCombinedTestingSample\Assets\PlayFabSDK\Internal\Testing\PlayFabApiTest.cs - This file executes some basic API calls, which you can use as an example.

To building your game client, install our native iOS and Android plugins. To do this, drag the Plugins folder to the root(Assets/Plugins) of the Unity project.

With projects running on Unity3d < 5.0, use the standard folder structure (Assets/Plugins/iOS & Assets/Plugins/Android). This means that if you are already using plugins, you must merge the PlayFab files into your existing folder structure. 

#### Configuration:
You must configure the SDK with you unique TitleId.  This is done via the PlayFabSetting object.  Set your Title id at the startup either in an Awake method.

**To configure the SDK in code, add the following code to your game's startup code:**

```C#

	using PlayFab;

	void Awake(){
		PlayFabSettings.TitleId = "AD08"; //your title id goes here.
	} 

```

Use AD08 as a demonstration TitleId if you would like to try the various pre-made scenes without creating and configurating your own title.


To make server API calls, set your DeveloperSecretKey, which can be found in the Settings > Credentials section of the PlayFab dashboard (PlayFab website) - Again, for security reasons, you must never publish this value to your players.


```C#

	using PlayFab;

	void Awake(){
		PlayFabSettings.DeveloperSecretKey = "Find this in your dashboard/settings https://developer.playfab.com/title/properties/{your title Id}"; //your Developer Secret goes here.
		// For security reasons you must never expose this value to players
	} 

```

6. Usage Instructions:
----
You are now ready to begin making API calls using the PlayFabClientAPI class. Check out the online [documentation](https://playfab.com/docs#/menu/1383/1383) for a complete list of available APIs.

#####New Users:
* Check out our Tutorials, Samples and more [here](https://playfab.com/docs/overview/)

#####Using the Push Plugin for Android
  * See [this section](https://github.com/PlayFab/UnitySDK/tree/master/UnityAndroidPluginSource) of the repository for complete details.

7. Troubleshooting:
----

CASE: Serialization errors involving ResultContainer and Generic paramerters
 * Top of the exception log will look like this: System.MemberAccessException: Cannot create an instance of PlayFab.Internal.ResultContainer`1[TResultType] because Type.ContainsGenericParameters is true.
 * This case can't be resolved with the current PlayFab UnitySdk.  We are building a new sdk to address this.  Please see: https://playfab.com/new-and-improved-unity-sdk-beta-preview/ and https://github.com/PlayFab/UnitySDKV2Beta

CASE: Follow these instructions to disable IDFA for your IOS release:
 * In Unity, navigate to and open: {YourUnityProject}/Assets/Plugins/iOS/PlayFabURLRequest.mm
  * Uncomment the first line:  // #define DISABLE_IDFA // If you need to disable IDFA for your game, uncomment this
 * In Unity, view the inspector window when you select (do not open): {YourUnityProject}/Assets/Plugins/iOS/PlayFabURLRequest.mm
  * Uncheck the "AdSupport" option under "Platform settings"
 * In Unity, Edit -> Project Settings -> Player
  * Select the global tab (first tab)
  * Scripting Define Symbols
  * Add this: DISABLE_IDFA

CASE: If you run into conflicts when upgrading SDKs, remove all files from previous versions and perform a fresh import of our unitypackage or SDK files. 

CASE: When creating web player builds, ensure that you have the proper WWW Security Emulation
 * The configuration variable can be found under Edit > Project Settings > Editor [more](http://docs.unity3d.com/Manual/class-EditorManager.html)
 * Your address will be https://xxxx.playfablogic.com, where xxxx is your title ID
 * A good overview of the issue can be found [here](http://answers.unity3d.com/questions/133806/why-is-unity-trying-to-get-a-crossdmain-policy-eve.html)

#### Contact Us
We love to hear from our developer community! 
Do you have ideas on how we can make our products and services better? 

Our Developer Success Team can assist with answering any questions as well as process any feedback you have about PlayFab services.

[Forums, Support and Knowledge Base](https://community.playfab.com/hc/en-us)

8. Copyright and Licensing Information:
----
  Apache License -- 
  Version 2.0, January 2004
  http://www.apache.org/licenses/

  Full details available within the LICENSE file.
