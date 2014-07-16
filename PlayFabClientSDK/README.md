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
The plugin source code repository **playfab-unity** contains the following directories.

plugin  Unity project containing PlayFab Unity plugin implementation
sample  Unity project containing PlayFab Unity plugin usage examples
tools   Bash scripts for building and maintaining the plugin



4. Installing the Plugin
------------------------
Create a new Unity project or open an existing Unity project. Double-click on **PlayFab.unitypackage** distribution package file. Click **Import** button in the bottom-right corner of the import package dialog in Unity editor.

After installing the plugin, the Unity project will include **PlayFab** directory containing plugin usage examples and **PlayFab.dll** plugin binary added inside a special Unity **Plugins** directory.


7. Using the Plugin
-------------------
After plugin installation, open a Unity test scene by double-clicking on **TestScene.unity** file located in **PlayFab/Examples/Test/Scenes** directory in your Unity project.

Run the scene by clicking on the **Play** arrow button in Unity editor. The Unity **Console** panel will show plugin configuration log output, indicating successful installation.

Open up **TestScene.cs** source file located in **PlayFab/Examples/Test/Scripts** directory in your Unity project. The file shows an example of configuring PlayFab app ID/token through code and sending a custom event to PlayFab API servers.


8. Configuring the Plugin
-------------------------
Please note the following multiple ways to configure the PlayFab Unity plugin.

### Through Unity editor during plugin development

- Create an empty Unity game object named **PlayFabApiManager**, place **PlayFabApiManager.cs** script onto the game object, select the game object in the Unity scene **Hierarchy** and set app ID/token fields to appropriate values in Unity **Inspector** panel.

### Through PlayFab Unity editor extension after plugin installation

- Open PlayFab Unity editor extension window by selecting **Window/PlayFab/Configure...** menu item in Unity editor.
- Set app ID/token fields and click **Save** button, which will create **PlayFab.json** configuration file inside a special Unity **Resources** directory.

### Through **PlayFab.json** configuration file located inside **Resources** directory

- The plugin will attempt to read **PlayFab.json** configuraton file during its initialization sequence. The file must be in JSON format, and the following parameters can be placed inside.

```
    appId/appToken          app credentials from PlayFab developer portal

    apiEndPoint             PlayFab API server endpoint
                            (used during plugin development and testing)

    requestTimeout          HTTP request timeout
                            (used during plugin development and testing)

    maxRequestRedirects     HTTP request max number of redirects
                            (used during plugin development and testing)
```

### Programmatically by setting app ID/token static properties on PlayFabApi class.

- Programmatic way to configure the plugin is shown in code examples included in the distribution package.

### Please note the following precedence when configuring the PlayFab Unity plugin.

- Programmatic configuration overrides any other configuration.

- PlayFab.json configuration overrides Unity game object configuration.

- Unity editor extension window writes PlayFab.json configuration file.

- Unity game object configuration does not override any other configuration.
