UnitySDK README
========
Welcome to the PlayFab Unity SDK. The quickest way to get started is to import our asset package: [PlayFabClientSDK.unitypackage](https://github.com/PlayFab/UnitySDK/raw/master/PlayFabClientSDK.unitypackage).

1. Overview:
----
This document describes the process of configuring and building the PlayFab Unity plugin binary and distribution package. The document also contains instructions for developers to start using the plugin in their Unity games.


2. Prerequisites:
----
This document assumes familiarity with the Unity game engine, MonoDevelop Unity .NET programming environment, and Mac OS X operating system environment.

* Users should also be very familiar with the topics covered in our [getting started guide](https://playfab.com/getting-started).

To connect to the PlayFab service, your machine must be running TLS v1.1 or better.
* For Windows, this means Windows 7 and above
* [Official Microsoft Documentation](https://msdn.microsoft.com/en-us/library/windows/desktop/aa380516%28v=vs.85%29.aspx)
* [Support for SSL/TLS protocols on Windows](http://blogs.msdn.com/b/kaushal/archive/2011/10/02/support-for-ssl-tls-protocols-on-windows.aspx)

3. Source Code & Key Repository Components:
----
Our repository contians 4 major sections:
  1. PlayFabClientSDK.unitypackage - The fastest way to get started, ready for importing into your Unity project.
  2. PlayFabClientSample - The base Unity project from which the asset package is built. 
  3. PlayFabServerSDK - provides access to the PlayFab Server and Admin API subsets.
  4. PluginSource - Contains the source code for our native Android plugin 


4. Installation & Configuration Instructions:
----
#### Installation via the .unitypackage:
Open your Unity project, open the PlayFabClientSDK.unitypackage and import the entire structure. 

#### Installation via moving folders into your Unity Project:
Create a new Unity project or open an existing Unity project. From the PlayFabClientSDK repository, drag the playfab/PlayFabSDK folder into your project's assets (anywhere is ok). You may optionally also install the Unity Editor tools by dragging the playfab/Editor directory into your project's assets.

After adding the PlayFabSDK directory, you will also want to install our native iOS and Android plugins. To do this, drag the Plugins folder to the root(Assets/Plugins) of the Unity project. 

With projects running on Unity3d < 5.0, you will want to stick to the standard folder structure (Assets/Plugins/iOS & Assets/Plugins/Android). This means that if you are already using plugins, you will need to merge the PlayFab files into your existing folder structure. 

#### Configuration:
You must configure the SDK with your unique TitleId, as assigned by the PlayFab Game Manager and can be found under the Settings > Credentials section.

Use 8D34 as a demonstration TitleId if you would like to try the various pre-made scenes without making and configurating your own title.

If you'd prefer to configure the SDK via code, then somewhere in your game's startup code, add the following:

```
using PlayFab;

PlayFabSettings.TitleId = "your title id here";
```


5. Usage Instructions:
----
You are now ready to begin making API calls using the PlayFabClientAPI class. Check out the online [documentation](https://playfab.com/docs#/menu/1383/1383) for a complete list of available APIs.


6. Troubleshooting:
----
If you run into conflicts When upgrading SDKs, remove all files from previous versions and perform a fresh import of our unitypackage or SDK files. 

When creating web player builds, ensure that you have the proper WWW Security Emulation
  * Configuration variable can be found under Edit > Project Settings > Editor [more](http://docs.unity3d.com/Manual/class-EditorManager.html)
  * Your address will be https://xxxx.playfablogic.com (where xxxx is your title id)
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
