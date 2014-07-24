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
Create a new Unity project or open an existing Unity project. From the PlayFabClientSDK directory, drag the PlayFabSDK folder into your project's assets (anywhere is ok).

5. Configuring the Plugin
-------------------------
You must configure the SDK to us your unique TitleId, as assigned by the PlayFab developer portal. Your TitleId will be a short string that looks something like "5A7F".

Somewhere in your game's startup code, add the following:

```
using PlayFab;

PlayFabSettings.UseDevelopmentEnvironment = true;
PlayFabSettings.TitleId = "your title id here";
```

6. Using the plugin
-------------------
You are now ready to begin making API calls using the PlayFabClientAPI singleton. See the mini example for an idea of how this works, and check out the online documentation at http://api.playfab.com/Documentation/Client for a complete list of available APIs.

