UnitySDK
========

You can check out our Angry Bots sample app here: https://github.com/PlayFab/UnityPlayFab_AngryBots. It includes PlayFab player authentication, catalog items, player inventory, and virtual currency.


1. Overview
-----------
This document describes the process of configuring and building the PlayFab Unity plugin binary and distribution package. The document also contains instructions for developers to start using the plugin in their Unity games.


2. Prerequisites
----------------
This document assumes familiarity with the Unity game engine, MonoDevelop Unity .NET programming environment, and Mac OS X operating system environment.


3. Source Code
--------------
The source code repository **playfab-unity** contains two main projects: PlayFabClientSDK and PlayFabServerSDK. The PlayFabClientSDK is the SDK you will integrate into your game project. The Server SDK is less commonly needed and is used to create custom administration tools.


4. Installing the Plugin
------------------------

Create a new Unity project or open an existing Unity project. From the PlayFabClientSDK directory, drag the playfab/PlayFabSDK folder into your project's assets (anywhere is ok). You may optionally also install the Unity Editor tools by dragging the playfab/Editor directory into your project's assets.

5. Configuring the Plugin
-------------------------
You must configure the SDK with your unique TitleId, as assigned by the PlayFab developer portal. Your TitleId will be a short string that looks something like "8D34" in your Title URL.

Use 8D34 as a demonstration TitleId if you would like to try the various pre-made scenes without making and configurating your own title.

If you have installed the PlayFab editor tools, go to PlayFab->GameConfig and type in your TitleId and current CatalogVersion then Click Save.

If you'd prefer to configure the SDK via code, then somewhere in your game's startup code, add the following:

```
using PlayFab;

PlayFabSettings.TitleId = "your title id here";
```


6. Using the plugin
-------------------
You are now ready to begin making API calls using the PlayFabClientAPI singleton. See the mini example for an idea of how this works, and check out the online documentation at http://api.playfab.com/Documentation/Client for a complete list of available APIs.
