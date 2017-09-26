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