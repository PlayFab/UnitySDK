UnitySDK README
========
Welcome to the PlayFab Unity Android Plugin

1. Overview:
----
This document describes the process of configuring and building the PlayFab Unity plugin using Android Studio. The document also contains instructions for developers to start using the plugin in their Unity games.

2. Prerequisites:
----
This document assumes familiarity with the Unity game engine, Java, Gradle & Using Android Studio.  However, there is not much you'll have to do with Gradle since we've done all the work for you.  

* Devices cannot receive push notification until you have done the proper setup.
	* Login to GameManager and then go to GameManager --> Settings --> Secret Keys
	* Enter your Google App Package Id  (example:  com.playfab.unicornbattle)
	* Enter your Google App License Key - this is in your https://play.google.com/apps/publish  Service & API's section.
	* You will also need to enable push notifications in you Google Play account for your application and acquire your **SenderId** (aka ProjectId, aka ProjectNumber).  Follow the instructions for this here: https://developers.google.com/cloud-messaging/
	* You will also need your API key from https://console.developers.google.com/project
		* Select or create your project
		* Expand APIs & auth --> Credentials
		* Add a new API Key.
	* We also require you to use a PlayFab Admin API call to initailly setup your title.  In the future you won't have to do this, but for now you need to make a call to admin/SetupPushNotification
		* https://api.playfab.com/Documentation/Admin/method/SetupPushNotification

Setup Push notification via Admin API
---
I like using postman for this.  You can get postman (which is a chrome plugin) at http://www.getpostman.com

*	headers - 
	*	Content-Type =  application/json
	*	X-SecretKey =  [ GameManager --> Settings --Credentials --> PlayFab API Secret Key ]
*	body - This holds the key/value attributes sent to PlayFab Server. 

```JSON

{
    "Name":"Unicorn_Battle_GCM",
    "Platform":"GCM",
    "Credential":"[Insert your Google API Key here]"
}

```

3. Compiling, Jar files & Key Source code 
---
*	**PlayFabUnityAndroidPlugin.java**
	*	This is primarily used for initialization of the plugin.
*	**GCM.PlayFabRegistrationIntentService.java**
	*	This class is used to gain access to the service that allows you to acquire the GCM Token.
*	**GCM.PlayFabGcmListenerService.java**
	*	This class receives messages and sends them either to Unity or to the notification bar.
*	**PlayFabGoogleCloudMessaging.java**
	*	Allows you to call .getToken() to receive the GCM token and send it back to Unity.
*	**PlayFabPushCache.java**	
	*	Allows you to get the Cached push notification after it has been sent / received.
*	**PlayFabNotificationPackage.java**
	*	Data model for holding push notification data


Compiling in Android Studio
--- 
*	Open the project in Android Studio
*	On the far right of the editor there is a Gradle tab.  Click that and then click the "refresh all gradle projects" button.
*	In the gradle projects window you should see two entries.  UnityAndroidPluginSouce & :playfabunityplugin. Expand :playfabunityplugin --> Tasks --> other
*	Look for exportJar function
*	Double clicking exportJar will compile the plugin and export the UnityAndroidPlugin.jar file into the /releases folder in the root of your project.  This file needs to be copied into your unity /assets/plugins/Android/  folder.

4. Plugin usage in Unity:
----
The source code is fairly simple and this version of the PlayFab Unity Android Plugin makes use of the new token based **GCM** (Google Cloud Messaging) service.  

* **PlayFabUnityAndroidPlugin** -  We have created this class as a Service rather than an activity. It's purpose is to allow you to initialize the Plugin from within Unity.  You can accomplish this by making a call to the Android plugin as shown below from within unity.

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

Now that you have acquired a token, you can use it after  you've loggeded in like below.

	```C#

    AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
    AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject>("getContentResolver");
    AndroidJavaClass secure = new AndroidJavaClass("android.provider.Settings$Secure");
    var deviceId = secure.CallStatic<string>("getString", contentResolver, "android_id");
    PlayFabClientAPI.LoginWithAndroidDeviceID(new PlayFab.ClientModels.LoginWithAndroidDeviceIDRequest()
    {
        AndroidDeviceId = deviceId,
        AndroidDevice = SystemInfo.deviceModel,
        OS = SystemInfo.operatingSystem,
        TitleId = PlayFabSettings.TitleId,
        CreateAccount=true
    }, (result) =>
    {
        
		PlayFabClientAPI.AndroidDevicePushNotificationRegistration(new AndroidDevicePushNotificationRegistrationRequest()
		{
		    DeviceToken = _PushToken
		}, null,
		(pushError) =>
		{
		    if (ShowDebug)
		    {
		        Debug.Log(pushError.ErrorMessage);
		    }
		});		

    }, HandleLoginError);

	```

5. Advanced: CustomData via Push Notifications
----

Playfab supports custom notifications,  allowing you ultimate flexability on the type of messaging you want to send from the server to your game client.  

To make use of CustomData, you'll need to send JSON data from the PlayFab Server through the GCM to the game client.  However, it is really not that complicated to accomplish.

First off you'll need to prepare some JSON that you will send via the SendNotification API. 

Example:
 
	```
	{
	    "Title": "Message from Game",
	    "Icon": "app_icon",
	    "Message": "You've gained gold!",
	    "CustomData":{
	        "gold":"5",
	        "currency":"G"
	    }
	}

	```

There is a new **PlayFabNotifiationPackage** object which holds the following fields:

*	Title -  String
	*	Assigns a title to the Push if passed
*	Sound - Uri
	*	Assigns a custom sound to the Push if passed
*	Icon - String
	*   Assigns a custom Icon from "Drawable" if passed
*	Message - String
	*	Assigns a message to be displayed (required), if the message is not JSON then the all other attributes are not existing and reverts to defaults and the message is a straight passthrough
*	CustomData - String
	*	Holds a custom JSON data structure that can be accessed via  PlayFabPushCache static getPushCacheData() method.

**See the diagram for Push Notification flow below**

![](http://i.imgur.com/zp6vHiu.png)

When an event is received either to the device or from within Unity,  you can make a call to "getPushCacheData()" method to retrieve the CustomData that was sent via the Push Notification. 

**Please note:** that you will need to deserialize the CustomData and what your getting is Raw JSON.
