## SDK Packages

This directory contains the following Unity Packages:

* UnitySDK.unitypackage
  * This is the core SDK used for accessing the PlayFab Service.  Whatever you're doing, it's pretty certain that this is mandatory
* UnityPlayFabPaperTrail.unitypackage
  * This is an out-of-date package which integrates Papertrail logging into PlayFab
  * It was a beta demonstration from 2016, exact usage and capabilities are not documented, but theoretically works
* JsonDotNetWrapper.unitypackage
  * Once upon a time, Json.net was a required package for PlayFab SDK.  That requirement was removed, because Json.net is not a free product and it wasn't fully compatible with all the device options in Unity
  * Our JsonWrapper system allows you to swap out any alternate JSON implementation into the PlayFab SDK, and in particular, this unitypackage specifically lets you continue to use Json.net with the PlayFab UnitySDK

## Push Plugins:

There are several push plugins for Unity+Android+Push-Notifications, based on the version of Google Play Services, and which Android API you're using.  We are building several versions for multiple platforms to make it easier to support older devices.  This list will expand, but for now, try to pick a plugin that best matches your existing project requirements:

| Unity Version | Android API Version | Google PlayServices Version | Package Filename |
| --- | --- | --- | --- |
| 5.0+ | Tested Android 5.0 'Lollipop' (API 21) thru Android 7.1.1 'Nougat' (API 25) | 10.0.1 | Push_Unity5_GPS10.0.1.unitypackage |
| 5.0+ | Android 7.0 'Nougat' (API 24) | 8.4.0 | Push_Unity5_GPS8.4.0.unitypackage |

If you have a version combination that is not listed above, then please post [here](https://community.playfab.com/questions/10840/android-plugin-upgrade-discussion.html)
