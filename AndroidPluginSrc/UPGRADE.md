# PlayFab Unity Android Push - Upgrade guide

## Class Overview

The previous plugin class-objects that you used in Unity include:

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
      * New Functionality: By default, messages are delivered to both your app and the device tray
        * If you wish to hide notifications when they are received by your app, call AlwaysShowOnNotificationBar(false)
        * They will still (always) display in the device tray when your app is closed or out of focus
    * IsPlayServicesAvailable - Unchanged in purpose and signature

PlayFabNotificationPackage existed in the previous version and the current
* The same parameters exist, but with slight differences:
  * Id is now an int
  * ScheduleDate - is now nullable (use null for immediate messages)
  * ScheduleType - Enum options slightly changed
    * None is only used if ScheduleDate is null
    * Scheduled is replaced with ScheduledUtc and ScheduledLocal, which define whether the timestamp represents local time or UTC time

## Upgrade Instructions

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

