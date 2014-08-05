PlayFab Unity Plugin
====================

1. Overview
-----------
This document describes the process of configuring and building the PlayFab Unity plugin binary and distribution package. The document also contains instructions for developers to start using the plugin in their Unity games.


2. Prerequisites
----------------
This document assumes familiarity with the Unity game engine, MonoDevelop Unity .NET programming environment, and Mac OS X operating system environment.


3. Source Code
--------------
The source code repository **playfab-unity** contains two main projects: PlayFabClientSDK and PlayFabServerSDK. The PlayFabClientSDK is the SDK you will integrate into your game project. The Server SDK is less commonly needed and is used to create custom administration tools.

Within the PlayFabClientSDK are the following directories:

PlayFabSDK  Source code to the PlayFabSDK

Examples    A quick and dirty example showing how to call the SDK


4. Installing the Plugin
------------------------
Download PlayFabPackage.unitypackage and unpack in your project.

OR

Create a new Unity project or open an existing Unity project. From the PlayFabClientSDK directory, drag the PlayFabSDK folder into your project's assets (anywhere is ok). This procedure will loose the reference to the Prefabs but you can still put them back manually.

5. Configuring the Plugin
-------------------------
You must configure the SDK with your unique TitleId, as assigned by the PlayFab developer portal. Your TitleId will be a short string that looks something like "8D34" in your Title URL.

Please use 8D34 as a TitleId if you would like to try the various pre-made scenes.

Once the package installed go to PlayFab->GameConfig and type in your TitleId and current CatalogVersion then Click Save.

OR

Somewhere in your game's startup code, add the following:

```
using PlayFab;

PlayFabSettings.UseDevelopmentEnvironment = false;
PlayFabSettings.TitleId = "your title id here";
```

OR

Edit directly PlayFabSettings in Playfab->PlayFabSDK->Public


6. Using the plugin
-------------------
You are now ready to begin making API calls using the PlayFabClientAPI singleton. See the mini example for an idea of how this works, and check out the online documentation at http://api.playfab.com/Documentation/Client for a complete list of available APIs.
