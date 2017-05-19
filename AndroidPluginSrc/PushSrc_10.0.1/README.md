# PlayFab Push Notification Plugin

## For Android build targets

  * The 5.0+ version of our plugin can be found [here](https://github.com/PlayFab/UnitySDK/raw/master/PlayFabClientSample/Assets/Plugins/Android/PushNotification_Unity5_0/AndroidPushPlugin.unitypackage)
  * The 4.7 version of our plugin can be found [here](https://github.com/PlayFab/UnitySDK/raw/master/PlayFabClientSample/Assets/Plugins/Android/PushNotification_Unity4_7/AndroidPushPlugin.unitypackage)

# 1. Overview:

This section of the repository contains the source code and documentation for building our Android push notification plugin using Android Studio. 

The document also contains instructions for developers to start using the plugin in their Unity games.

# 2. Prerequisites:

This document assumes familiarity with PlayFab, Unity3D, Java, Gradle & using Android Studio.  However, there is not much you'll have to do with Gradle since we've done all the work for you.  

* Devices will not receive push notification until properly configured.

#### PlayFab Title Setup:
  * Login to game manager and navigate to your title > Settings > Push Notifications.
  * Follow the instructions for linking your title to the GCM channel
  * Optionally, this can also be achieved via [SetupPushNotification](https://api.playfab.com/Documentation/Admin/method/SetupPushNotification) in our Admin API.
  * SetupPushNotification will reset your subscribed devices. After calling SetupPushNotification each device will need to re-subscribe. 

#### Unity Project Setup:
By default the Android Push plugin is not installed by default. It is included with the UnitySDK as an AssetPackage and must be manually unpacked after installing the UnitySDK. 

Once unpacked you will need to initialize the plugin prior to use. These details are covered in the guides below.

#### For Additional Push-related information, see our guides:
  * [Push Notification Basics](https://api.playfab.com/docs/push-basics)
  * [Push Notifications for Android](https://api.playfab.com/docs/push-for-android)

# 3. Plugin Component Overview:

The source code is fairly simple and this version of the PlayFab Unity Android Plugin makes use of the new token based **GCM** (Google Cloud Messaging) service.  

* **PlayFabUnityAndroidPlugin** -  We have created this class as a Service rather than an activity. Its purpose is to allow you to initialize the Plugin from within Unity.  You can accomplish this by making a call to the Android plugin as shown below from within unity.

```C#

	var senderId = "123456"; //put your sender id here.
	PlayFabAndroidPlugin.init(senderId);

``` 

This makes a call to PlayFabUnityAndroidPlugin.initGCM()  and passes the SenderId & Game Title (Application.productName).  This sets up everything so that you can make a call to get the GCM Token.

PlayFabUnityAndroidPlugin is a service that is started and stopped when you open and close your unity application. It is bound to the Unity Activity so that it can only be accessed by Unity.  We choose to use a service so that we are not overriding the Main Activity of your project and will have no conflicts with other plugins that you wish to use. 

*  **GCM.PlayFabRegistrationIntentService** - This class get's and stores an instance of it's self.  It is our link to the InstanceID which is how you get a token from GCM.  Once you've called .initGCM, this service is started up and it will then send a message back to unity.  Messages are handled in the **UnityPluginEventHandler.cs**.
    
```C#

    public void GCMRegistrationReady(string status)
    {
        bool statusParam; 
        bool.TryParse(status,out statusParam);
        PlayFabGoogleCloudMessaging.RegistrationReady(statusParam);
    }

```

Once a ready message has been received we are free to make a call to **PlayFabGoogleCloudMessaging.GetToken()** , you don't have to worry about using the UnityPluginEventHanlder.cs directly.  Simply subscribe to the event delegates.

```C#

    PlayFabGoogleCloudMessaging._RegistrationReadyCallback += OnGCMReady;
    PlayFabGoogleCloudMessaging._RegistrationCallback += OnGCMRegistration;

```
GCMReady Event get called automatically.


```C# 

	private void OnGCMReady(bool status)
    {
        Debug.Log("GCM Ready!");
        PlayFabGoogleCloudMessaging.GetToken();
    }

```

Once a token has been acquired, then the registration callback will be triggered.  We recommend that you store this token (short term) until you have logged into the API.   

```C#

	private void OnGCMRegistration(string token, string error)
	{
	    Debug.Log(string.Format("GCM Token Recieved: {0}", token));
	    if (token != null)
	    {
	        _PushToken = token;
	    }
	}

```

**See the diagram for Push Notification flow below**

![](http://i.imgur.com/zp6vHiu.png)

# 4. Source Code Overview and Build Instructions


Source File | Description
--- |  ---
PlayFabUnityAndroidPlugin.java | This is primarily used for initialization of the plugin.
GCM.PlayFabRegistrationIntentService.java | This class is used to gain access to the service that allows you to acquire the GCM Token.
GCM.PlayFabGcmListenerService.java | This class receives messages and sends them either to Unity or to the notification bar.
PlayFabGoogleCloudMessaging.java | Allows you to call .getToken() to receive the GCM token and send it back to Unity.
PlayFabPushCache.java | Allows you to get the Cached push notification after it has been sent / received.
PlayFabNotificationPackage.java | Data model for holding push notification data
PlayFabNotificationSender.java | **new** Helper class for sending notifications both from java & JNI via Unity, supports scheduled push notifications using the Alarm Manager and local notifications set via Unity.
NotificationPublisher.java | **new** broadcast receiver for sending notifications (required manifest change)

### Compiling in Android Studio
*	Open the project in Android Studio
*	On the far right of the editor there is a Gradle tab.  Click that and then click the "refresh all gradle projects" button.
*	In the gradle projects window you should see two entries.  *UnityAndroidPluginSouce* & *:playfabunityplugin*. 
* Expand *:playfabunityplugin --> Tasks --> other* and find the **exportJar** function.
*	Double-click exportJar. This will compile the plugin and export the UnityAndroidPlugin.jar & the Android.manifest files into the /releases folder in the root of your project.  These files need to be copied into your unity /assets/plugins/Android/  folder.


# 5. Sending local push notifications

new methods have been added to the C# side of the plugin that calls into the Java side via JNI.  Similar to how we are registering the device and get the GCM token for push notifications.  Local notifications do not need to be registered with GCM and allows the developer to send & schedule a local push notification.

Here is how that works. We have three new methods in the PlayFabAndroid.cs file ( not included in the java source project, but it is included with the plugin package.

* ScheduleNotification - This allows you to pass in a date and a json string representing the PlayFabNotificationPackage.
* SendNotificationNow - Allows you to send a notification instantly, accepts a json string representing the PlayFabNotificationPackage.
* CancelNotification - Allows you to cancel a scheduled notification, accepts a json string representing the previously created PlayFabNotificationPackage.

```C#

        public static void ScheduleNotification(string notification, DateTime date)
        {
            AndroidJavaClass clsUnity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject objActivity = clsUnity.GetStatic<AndroidJavaObject>("currentActivity");

            var package = NotificationSender.CallStatic<AndroidJavaObject>("createNotificationPackage", new object[]
            {
                objActivity,
                notification
            });

            var dateString = date.ToString("MM-dd-yyyy HH:mm:ss");
            Debug.LogFormat("Setting Scheduled Date: {0}", dateString);
            package.Call("SetScheduleDate", dateString);
            
            NotificationSender.CallStatic("Send", new object[]
            {
                objActivity,
                package
            });
        }

        public static void SendNotificationNow(string notification)
        {
            AndroidJavaClass clsUnity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject objActivity = clsUnity.GetStatic<AndroidJavaObject>("currentActivity");
            
            //AndroidJavaObject package = new AndroidJavaObject("com.playfab.unityplugin.GCM.PlayFabNotificationPackage");
            var package = NotificationSender.CallStatic<AndroidJavaObject>("createNotificationPackage", new object[]
            {
                objActivity,
                notification
            });

            NotificationSender.CallStatic("Send", new object[]
            {
                objActivity,
                package
            });
        }

        public static void CancelNotification(string notification)
        {
            AndroidJavaClass clsUnity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject objActivity = clsUnity.GetStatic<AndroidJavaObject>("currentActivity");
            var package = NotificationSender.CallStatic<AndroidJavaObject>("createNotificationPackage", new object[]
            {
                objActivity,
                notification
            });
            NotificationSender.CallStatic("CancelScheduledNotification", new object[]
            {
                objActivity,
                package
            });
        }

```

# 6. Pushing a scheduled notification from Game Manager

Since we have the ability to schedule a notification for a future date,  you can now do this via a Push Notification.  The PlayFabNotificationPackage has the following fields and you can easily turn this into a json string.

```C#

    public DateTime ScheduleDate;
    public ScheduleTypes ScheduleType; // 0=none | 1=ScheduledDate
    public string Sound; // do not set this to use the default device sound; otherwise the sound you provide needs to exist in Android/res/raw/_____.mp3, .wav, .ogg
	public string Title; // title of this message
	public string Icon; // to use the default app icon use app_icon, otherwise send the name of the custom image. Image must be in Android/res/drawable/_____.png, .jpg
	public string Message; // the actual message to transmit (this is what will be displayed in the notification area
	public string CustomData; // arbitrary key value pairs for game specific usage
    public string Id;
    public Boolean Delivered;

```

As a json string, this would look like the following.

```c#

{
	"ScheduleDate":"26-08-2016 13:00:00",
	"ScheduleType":1,
	"Title":"This is a scheduled Push",
	"Message":"You will get gold if you click me now!",
	"Id":12345
}

```

Note we left out Sound & Icon to use the Default values.

We can use this format in [Game Manager](http://developer.playfab.com) and / or cloudscript to send a push notification to a device.  The json above would go in the message field.  Title is still required, but is overridden by the values in the json.


# 7. Resolving .JAR & .AAR Conflicts

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
