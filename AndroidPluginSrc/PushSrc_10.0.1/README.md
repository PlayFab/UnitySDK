# PlayFab Push Notification Plugin

## For Android build targets

We support multiple versions of Unity and Android Google Play Services (GPS) and Android appcompat/support.  Look [here](https://github.com/PlayFab/UnitySDK/tree/master/Packages), and search for the plugin folder that best describes your requirements. We intend to expand version support over time.


# 1. Overview:

This section of the repository contains the source code and documentation for building our Android push notification plugin using Android Studio. 

The document also contains instructions for developers to start using the plugin in their Unity games.


# 2. Prerequisites:

This document assumes familiarity with PlayFab, Unity3D, Java, Gradle & using Android Studio.  However, most of the work is done for you in all cases, and likely you only have to write code in Unity3D.

* Devices will not receive push notification until properly configured.

#### PlayFab Title Setup:
  * Login to game manager and navigate to your title > Settings > Push Notifications.
  * Follow the instructions for linking your title to the GCM channel
  * Optionally, this can also be achieved via [SetupPushNotification](https://api.playfab.com/Documentation/Admin/method/SetupPushNotification) in our Admin API.
  * SetupPushNotification will reset your subscribed devices. After calling SetupPushNotification each device will need to re-subscribe. 

#### Unity Project Setup:
By default the Android Push plugin is not installed by default with Unity, PlayFab Editor Extensions, or UnitySDK. It is a separate AssetPackage and must be installed separately (see first section of this doc).

Once unpacked you will need to initialize the plugin prior to use. These details are covered in the guides below.

#### For Additional Push-related information, see our guides:
  * [Push Notification Basics](https://api.playfab.com/docs/tutorials/landing-players/push-notification-basics)
  * [Push Notifications for Android](https://api.playfab.com/docs/tutorials/landing-players/push-notification-basics/push-notifications-for-android)


# 3. Plugin Component Overview:

The source code is fairly simple and this version of the PlayFab Unity Android Plugin makes use of the new token based **GCM** (Google Cloud Messaging) service.  

* **PlayFabAndroidPushPlugin** -  This is the single access point for the plugin.

### Most users will need very little Unity code:

* [Constant somewhere in your code] const string ANDROID_PUSH_SENDER_ID = "000000000000"; // NOTE: Use your own FCM SenderId
* [Every program start, before login] PlayFabAndroidPushPlugin.Setup(ANDROID_PUSH_SENDER_ID);
* [After Login, EXACTLY ONCE for each user] PlayFabAndroidPushPlugin.TriggerManualRegistration();

This sequence will satisfy most developers needs. The value for ANDROID_PUSH_SENDER_ID comes from Google/FCM (see the [Push Notifications for Android](https://api.playfab.com/docs/tutorials/landing-players/push-notification-basics/push-notifications-for-android) guide for details).

Setup activates the PlayFab Android Push Plugin, and generates a unique token for the user (you do not need to access this token directly). TriggerManualRegistration makes a PlayFab API call to [AndroidDevicePushNotificationRegistration] (https://api.playfab.com/documentation/client/method/AndroidDevicePushNotificationRegistration) with the token.

### Advanced Unity setup:

The following situation is atypical: Some users store their senderId in titleData. In this case, you will have to fetch that id for yourself, and your startup sequence will change slightly:

* string androidPushSenderId; // Not defined until after login
* [Every program start, before login] PlayFabAndroidPushPlugin.Init();
* [After every login] PlayFabAndroidPushPlugin.Setup(androidPushSenderId);
* [After Login, EXACTLY ONCE for each user] PlayFabAndroidPushPlugin.TriggerManualRegistration();

### AutoMagic registration on login

COMING SOON: In the most ideal scenario, PlayFag can automatically detect if a device is not registered, removing the requirement to call TriggerManualRegistration.  This feature is incomplete, but will be available soon.


# 4. Android Studio Source Build Instructions

### Compiling in Android Studio
*	Open the project in Android Studio
*	On the far right of the editor there is a Gradle tab.  Click that and then click the "refresh all gradle projects" button.
*	In the gradle projects window you should see two entries.  *UnityAndroidPluginSouce* & *:playfabunityplugin*. 
* Expand *:playfabunityplugin --> Tasks --> other* and find the **exportJar** function.
*	Double-click exportJar. This will compile the plugin and export the UnityAndroidPlugin.jar & the Android.manifest files into the /releases folder in the root of your project.  These files need to be copied into your unity /assets/plugins/Android/  folder.


# 5. Resolving .JAR & .AAR Conflicts

If your project is using multiple Android plugins, there is a good chance that you could have multiple copies of a given Android library. Having multiple copies of .JARs and .AARs will cause your builds to fail during the DEX compilation. 

Review our Android SDK dependencies below. Some version of these files must be included before for push to work. We have not tested all permutations of libraries within the Android SDK. Please let us know if you run into any compatibility issues.

#### Android SDK dependencies (Unity 5.0+)
The 5.0+ version of our plugin can be found [here](https://github.com/PlayFab/UnitySDK/raw/master/PlayFabClientSample/Assets/Plugins/Android/PushNotification_Unity5_0/AndroidPushPlugin.unitypackage).

Included Archive | Class Location
--- |  ---
appcompat-v7-25.1.1.aar | com.android.support.appcompat-v7 
support-v4-25.1.1.aar | com.android.support.support-v4
play-services-base-10.0.1.aar | com.google.android.gms.play-services-base
play-services-basement-10.0.1.aar | com.google.android.gms.play-services-basement 
play-services-gcm-10.0.1.aar | com.google.android.gms.play-services.gcm
play-services-iid-10.0.1.aar | com.google.android.gms.play-services.iid


#### Android SDK dependencies (Unity 4.7)
Projects built using Unity versions < 5.0 do not support android .AAR files. Due to this fact, our plugin has the following .JAR dependencies. The 4.7 version of our plugin can be found [here](https://github.com/PlayFab/UnitySDK/raw/master/PlayFabClientSample/Assets/Plugins/Android/PushNotification_Unity4_7/AndroidPushPlugin.unitypackage).

Included Archive | Class Location
--- |  ---
play-services-7.8.0.jar | com.google.android.gms.play-services
support-v4.jar | com.android.support.support-v4
support-v7-appcompat-7.22.0.jar | com.android.support.appcompat-v7 


#### To resolve conflicts follow these steps:
Find duplicate copies of .AAR / .JAR files and remove them. There should be at most 1 copy of a given android library. Older .JAR files often map to multiple .AAR files. 

Double-check your plug-in support resources to determine what dependencies your plug-ins are using and if they conflict with any of the above libraries, you should be able to remove either copy to resolve your DEX issues. 

After modifying any .JAR / .AAR files, thoroughly test your plug-in capabilities to ensure that no other issues were introduced. This can be an involved process requiring careful deliberation to identify and resolve conflicts.

Please let us know if you run into any issues and we will do our best to help.
