UnitySDK README
========
Welcome to the PlayFab Unity SDK. The quickest way to get started is to import our asset package: [PlayFabClientSDK.unitypackage](https://github.com/PlayFab/UnitySDK/raw/master/PlayFabClientSDK.unitypackage).

1. Overview:
----
This document describes the process of configuring and building the PlayFab Unity plugin binary and distribution package. The document also contains instructions for developers to start using the plugin in their Unity games.

2. Prerequisites:
----
This document assumes familiarity with the Unity game engine, MonoDevelop Unity .NET programming environment, and Mac OS X operating system environment.

* Users should also be familiar with the topics covered in our [getting started guide](https://playfab.com/getting-started).

To connect to the PlayFab service, your machine must be running TLS v1.2 or better.
* For Windows, this means Windows 7 and above
* [Official Microsoft Documentation](https://msdn.microsoft.com/en-us/library/windows/desktop/aa380516%28v=vs.85%29.aspx)
* [Support for SSL/TLS protocols on Windows](http://blogs.msdn.com/b/kaushal/archive/2011/10/02/support-for-ssl-tls-protocols-on-windows.aspx)

3. Source Code & Key Repository Components:
----
Our repository contians these major sections:
 #. PlayFabClientSDK.unitypackage - The fastest way to get started, ready for importing into your Unity project
 #. PlayFabClientSample - The base Unity project from which the asset package is built
  #. This is the minimal subset of files required to use the PlayFab Client API
 #. PlayFabServerSample - Similar to PlayFabClientSample, but using server APIs
  #. This is the minimal subset of files required to use the PlayFab Server API
  #. This project contains a variable called DeveloperSecretKey - For security reasons you must never expose this value to players
 #. PlayFabCombinedTestingSample - This sample has a working set of unit tests that make several API calls and verify PlayFab functionality
  #. This project demonstrates how to execute both client and server API calls with the SDK, and minimally analyze the results
  #. This project contains a variable called DeveloperSecretKey - For security reasons you should never expose this value to players
 #. PluginSource - Contains the source code for our native Android plugin

4. Installing and Configuring the PlayFab Unity SDK:
----
#### Install the Unity SDK using the Unity Package 
Open your Unity project, open the PlayFabClientSDK.unitypackage, and import the entire structure. 

#### Install the Unity SDK into another Unity project:
 #. Extract the UnitySdk to a location of your choice (described as the UnitySDkFolder for the rest of this example)
 #. Create a new Unity project or open an existing Unity project
 #. Navigate to  UnitySDkFolder\PlayFabClientSample\Assets
 #. Copy the PlayFabSDK folder from the example project, into your new/existing project's Assets folder
 #. Begin integrating PlayFab calls into your project
   #. UnitySDkFolder\PlayFabCombinedTestingSample\Assets\PlayFabSDK\Internal\Testing\PlayFabApiTest.cs - This file executes some basic API calls, which you can use as an example.

To building your game client, install our native iOS and Android plugins. To do this, drag the Plugins folder to the root(Assets/Plugins) of the Unity project.

With projects running on Unity3d < 5.0, use the standard folder structure (Assets/Plugins/iOS & Assets/Plugins/Android). This means that if you are already using plugins, you must merge the PlayFab files into your existing folder structure. 

#### Configuration:
You must configure the SDK with your unique TitleId, as assigned by the PlayFab Game Manager. This value can be found in the Settings > Credentials section of the PlayFab dashboard (PlayFab website).

Use AD08 as a demonstration TitleId if you would like to try the various pre-made scenes without creating and configurating your own title.

To configure the SDK in code, add the following code to your game's startup code:

```
using PlayFab;

PlayFabSettings.TitleId = "your title id here";
```

To make server API calls, set your DeveloperSecretKey, which can be found in the Settings > Credentials section of the PlayFab dashboard (PlayFab website) - Again, for security reasons, you must never publish this value to your players.

5. Usage Instructions:
----
You are now ready to begin making API calls using the PlayFabClientAPI class. Check out the online [documentation](https://playfab.com/docs#/menu/1383/1383) for a complete list of available APIs.

#####New Users:
* Check out our PlayFabSDK/DemoScene to see how to get started with device ID authentication and calling into Cloud Script.
* Additional Examples:
  * [Login Pathways](https://github.com/PlayFab/Unity3d_Login_Example_Project)
  * [Photon Integration](https://github.com/PlayFab/Photon-Cloud-Integration)
  * [MOBA Starter Project](https://github.com/PlayFab/UNION-OpenSource-MOBA)
  * [Cloud Script Samples](https://github.com/PlayFab/CloudScriptSamples) 


6. Troubleshooting:
----
If you run into conflicts when upgrading SDKs, remove all files from previous versions and perform a fresh import of our unitypackage or SDK files. 

When creating web player builds, ensure that you have the proper WWW Security Emulation
  * The configuration variable can be found under Edit > Project Settings > Editor [more](http://docs.unity3d.com/Manual/class-EditorManager.html)
  * Your address will be https://xxxx.playfablogic.com, where xxxx is your title ID
  * A good overview of the issue can be found [here](http://answers.unity3d.com/questions/133806/why-is-unity-trying-to-get-a-crossdmain-policy-eve.html)


#### Contact Us
We love to hear from our developer community! 
Do you have ideas on how we can make our products and services better? 

Our Developer Success Team can assist with answering any questions as well as process any feedback you have about PlayFab services.

[Forums, Support and Knowledge Base](https://support.playfab.com/support/home)

7. Copyright and Licensing Information:
----
  Apache License -- 
  Version 2.0, January 2004
  http://www.apache.org/licenses/

  Full details available within the LICENSE file.
