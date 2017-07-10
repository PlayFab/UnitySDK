# PlayFab Unity Android Push - Upgrade guide

## Upgrade Instructions - Quick

This section has the fastest set of instructions, but with less detail:

Most users will want to "burn everything with fire" and start from scratch.

[See our guide for details](https://api.playfab.com/docs/tutorials/landing-players/push-notification-basics/push-notifications-for-android)

Quick Reference:

MANDATORY:

* Always call before PlayFab Login: PlayFabAndroidPushPlugin.Setup(pushSenderId);
* Call once per player after PlayFab Login: PlayFabAndroidPushPlugin.TriggerManualRegistration();
* If you were calling UpdateRouting, just delete it.  It's automatic now.
  * The plugin does not require any updates to determine if the app is in focus.

OPTIONAL:

* If you wish to be notified when push messages arrive:
  * PlayFabAndroidPushPlugin.OnGcmMessage += MyCustomOnGcmMessageHandler
  * Your old callback needs to be converted from a string parameter to PlayFabNotificationPackage
  * Remove any calls to UpdateRouting for this use case. It's automatic now.
* If you were calling UpdateRouting with the intention of hiding a message from the device tray (capturing only to the game)
  * Add a call: PlayFabAndroidPushPlugin.AlwaysShowOnNotificationBar(false)
  * You only need to call it once at program start
  * You can reset it whenever you like: PlayFabAndroidPushPlugin.AlwaysShowOnNotificationBar(true/false)
    * It's highly suggested you just call it once at program start with your preference


## Upgrade Instructions - Detailed

This portion of the guide provides a step-by-step for deleting an older PlayFab Plugin, and replacing it with a new one.

* First, you will want to find the Assets/Plugins Folder.
* In that folder, there are two folders used by PlayFab: Android and PlayFabShared
  * PlayFabShared should contain exactly one file: PlayFabErrors
    * Do not delete this file - It is a PlayFab SDK file, and is not part of the Push Plugin
  * Everything in the Android folder gets mixed with every other Android Plugin you may have, and all the dependencies become undefined
    * If you have other plugins, then you want to be EXTREMELY careful, and backup everything
      * Upgrading the PlayFab Push Plugin will be extremely risky, because of how Android dependencies work - Proceed at your own risk
      * Carefully delete any PlayFab related .cs source files, and try to determine if any Jar/Aar files are no longer used/required
    * If PlayFab Push is your only Android Plugin, then just delete the Assets/Plugins/Android folder
* Go back to your code, and look for compile errors pertaining to the classes below
  * Most users will delete almost all references to those classes, and add ONLY two new lines:
    * When you set PlayFabSettings.TitleID, or somewhere very early in your project start up:
      * PlayFabAndroidPushPlugin.Setup(pushSenderId); // This initializes the plugin
    * After PlayFab login, and verifying that user wants push notifications:
      * PlayFabAndroidPushPlugin.TriggerManualRegistration();
      * That user verification step is important, as it's a contract violation between you and Google if you don't get the user's permission

## Class Overview

This is a more detailed overview, but less direct instructions. The previous plugin class-objects that you used in Unity include:

* CLASS: PlayFabAndroidPlugin
  * FUNTIONS: Init, IsPlayServicesAvailable, *StopPlugin, UpdateRouting, ScheduleNotification, SendNotificationNow, CancelNotification
* CLASS: PlayFabGoogleCloudMessaging
 * FUNTIONS: Init, GetToken, ClearPushCache, GetPushCacheData, GetPushCache
 * EVENTS: _RegistrationReadyCallback, _RegistrationCallback, _MessageCallback
* CLASS: PlayFabPluginEventHandler
  * (No useful public functions)

All of the classes are replaced with a single class. Most events have been replaced with more useful ones, but this is a significant change. Most of the same functions exist in similar form.

* CLASS: PlayFabAndroidPushPlugin
  * FIELDS:
    * LogMessagesToUnity - By default, some logs will display in Unity. Set to false to disable them
    * SendConfirmationMessage and ConfirmationMessage - By default, registration is automatic and silent. Set to true, and fill in the message to get an automatic confirmation push message on registration
  * EVENTS:
    * OnGcmMessage - Replaces _MessageCallback. Now receives a PlayFabNotificationPackage object instead of a string
    * OnGcmSetupStep - New. Used for debugging, lets you track what setup steps have occurred in the plugin
    * OnGcmLog - New. Allows you to receive some log messages directly
  * Initialization Functions:
    * Setup(pushSenderId) - REQUIRED. Replaces Init function(s) in previous plugin. Usually called before PlayFab Login
    * Init() - Only required if you call Setup after PlayFab Login (Required before login in this case)
    * TriggerManualRegistration() - New. Formerly, we required that you call [AndroidDevicePushNotificationRegistration](https://api.playfab.com/documentation/client/method/AndroidDevicePushNotificationRegistration) manually. TriggerManualRegistration will do that for you. Requires successful PlayFab Login before calling.
  * Local Notification functions
    * SendNotificationNow - Functionally identical to previous version
    * ScheduleNotification, SendNotification - Replaces ScheduleNotification. Parameters changed
      * SendNotification accepts a full PlayFabNotificationPackage, which lets you set all values and options
        * Use this instead of manually passing JSON into the message string field
      * ScheduleNotification accepts a message, a timestamp, and an optional id
        * More closely matches the previous ScheduleNotification call
    * CancelNotification - function overload option added
      * Can accept the message string (like before), or an Id (new)
        * If you scheduled a message with an Id, you must cancel by Id
        * If you scheduled a message without specifying an Id, cancel by Message string like before
    * StopPlugin - *unchanged
      * previous version crashed the app if called, this one works.  Call Setup() again to re-initialize.
      * Unneccessary in most cases
    * AlwaysShowOnNotificationBar - Replaces UpdateRouting
      * Delete any previous calls to UpdateRouting, as this serves an entirely different purpose
      * New Functionality: By default, messages are delivered to both your app AND the device tray
        * If you wish to hide notifications when they are received by your app, call AlwaysShowOnNotificationBar(false)
        * They will still (always) display in the device tray when your app is closed or out of focus
    * IsPlayServicesAvailable - Unchanged in purpose and signature.  (Also doesn't crash the app if called before initialization)

PlayFabNotificationPackage existed in the previous version and the current
* The same fields exist, but with slight differences:
  * Id is now an int
  * ScheduleDate - is now nullable (use null for immediate messages)
  * ScheduleType - Enum options slightly changed
    * None is only used if ScheduleDate is null
    * Scheduled is replaced with ScheduledUtc and ScheduledLocal, which define whether the timestamp represents local time or UTC time
