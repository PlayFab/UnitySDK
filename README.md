UnitySDK
========

You can check out our Angry Bots sample app here: https://github.com/PlayFab/UnityPlayFab_AngryBots. It includes PlayFab player authentication, catalog items, player inventory, and virtual currency.


1. Overview
-----------
This document describes the process of configuring and building the PlayFab Unity plugin binary and distribution package. The document also contains instructions for developers to start using the plugin in their Unity games.


2. Prerequisites
----------------
This document assumes familiarity with the Unity game engine and the MonoDevelop Unity .NET programming environment.


3. SDK orgnanization
--------------
PlayFabClientSDK.unitypackage - Unity package containing the PlayFab client SDK. This has everything you need to add to your project to get started
PlayFabClientSample - A sample project you can open and run to try out PlayFab wihout adding it to your project
PlayFabServerSDK - Source to the less commonly needed PlayFab server SDK. This allows you to access PlayFab server APIs if you write a game server in Unity.
PluginSource - Source code to the PlayFab native plugin in case you need to debug or modify it
README.md - This file


4. Installing the Client SDK
------------------------
Create a new Unity project or open an existing Unity project. From the PlayFabClientSDK directory, drag PlayFabClientSDK.unitypackage into your project's assets (anywhere is ok). This will unpack the SDK into your project.


5. Configuring the SDK
-------------------------
You must configure the SDK with your unique TitleId, as assigned by the PlayFab developer portal. Your TitleId will be a short string that looks something like "8D34" in your Title URL.

Use 8D34 as a demonstration TitleId if you would like to try the various pre-made scenes without making and configurating your own title.

If you have installed the SDK via PlayFabClientSDK.unitypackage, go to PlayFab->GameConfig and type in your TitleId and current CatalogVersion then Click Save.

If you'd prefer to configure the SDK via code, then somewhere in your game's startup code, add the following:

```
using PlayFab;

PlayFabSettings.TitleId = "your title id here";
```

If your project has an Android target, make sure to set your Bundle Identifier in the Player Settings panel.


6. Using the plugin
-------------------
You are now ready to begin making API calls using the PlayFabClientAPI singleton. See the mini example for an idea of how this works, and check out the online documentation at http://api.playfab.com/Documentation/Client for a complete list of available APIs.
