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

| Unity Version | Target Android API Version | Backwards Tested To | Google PlayServices Version | Package Filename |
| --- | --- | --- | --- | --- |
| 5.0+ | Android 7.1.1 'Nougat' (API 25) | Android 5.0 'Lollipop' (API 21) | 10.0.1 | Push_Unity5_GPS10.0.1.unitypackage |
| 5.0+ | Android 7.0 'Nougat' (API 24) | n/a | 8.4.0 | Push_Unity5_GPS8.4.0.unitypackage |

If you have a version combination that is not listed above, then please read [this post](https://community.playfab.com/answers/11374/view.html).  Specifically, our plugin works with the version numbers described above, and you can use our source to rebuild it to use any combination that fits the following limitations: Android API >= 21, Google Play Services >= 8.4.0.  For alternate API versions, you'll have to replace .aar files in Unity to match your target API version, and for alternate Google Play Services versions, you'll need to download, modify, and rebuild our plugin from the [source code](https://github.com/PlayFab/UnitySDK/tree/master/AndroidPluginSrc).

You can post feedback or questions [here](https://community.playfab.com/questions/10840/android-plugin-upgrade-discussion.html)
