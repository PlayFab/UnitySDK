# UnitySDK Upgrade from v1 to v2 guide

Note: This is a guide and not necessarily a step by step solution.  Therefore each upgrade scenario might be slightly different.


## 1. Overview:

Upgrading to the new  Unity SDK v2 is not difficult at all.  However, depending on how you were using the previous SDK and what usage and features of the previous JSON serializer there could be some pain points.  This guide's intent is to identify these potential pain points and give you (the developer) a clear path to upgrade.


## 2. Prerequisites:

This document assumes familiarity with the Unity game engine, MonoDevelop Unity .NET programming environment, and Mac OS X operating system environment.

-  Users should also be familiar with the topics covered in our [getting started guide](https://playfab.com/docs/getting-started-with-playfab/).

To connect to the PlayFab service, your machine must be running TLS v1.2 or better.

- For Windows, this means Windows 7 and above
- [Official Microsoft Documentation](https://msdn.microsoft.com/library/windows/desktop/aa380516%28v=vs.85%29.aspx)
- [Support for SSL/TLS protocols on Windows](http://blogs.msdn.com/b/kaushal/archive/2011/10/02/support-for-ssl-tls-protocols-on-windows.aspx)


## 3. Installing or Upgrading the PlayFab UnitySdk

The most important part about upgrading to the new SDK is that you MUST remove the old SDK first.  **DO NOT**   just copy or import the new SDK over top of the old sdk.   That will not work at all.  In addition, I highly advise that you make a backup of your project prior to doin the upgrade.  Do this either with a repository, or the old fashioned way by copy & pasting your project to another location. But the last thing you want to do is try this upgrade and have no way to revert back. 

So what do you need to remove?  Depending on which version of the SDK you have there are a few different file locations you should check for files.  In the future we will have a tool that will do this clean-up for you, but for now you have to do it manually.

1. First, look for  PlayFabSDK folder and nuke it ( delete it ).

2. Next, look for Plugins Folder and here it becomes a little more tricky.  You can't just delete the Plugins folder because you might have other Plugins installed ( like Facebook, or Google Play Services etc.. ) so we need to be very specific as to what you can delete. Below are a list of files that are safe to delete

	1. Folder - PlayFabShared
	2. Android - Any of these files/folders mentioned.
		1. Folder - PlayFab
		2. Folder - res (only if you know for a fact that nothing else is using this)
		3. PlayFabUnityAndroid.jar
		4. play-services-7.8.0.jar
		5. support-v4.jar
		6. support-v7-appcompat-7.22.0.jar
		7. PlayFabAdInfo.jar
		8. Folder - PushNotification_Unity4_7
		9. Folder - PushNotification_Unity5_0
	3. Folder - iOS
		1. PlayFabUrlRequest.mm
		2. PlayFabiOS.cs

3. 	Now that you have essentially cleaned out the previous installation,  you will need to import the new SDK which you can get from the [Packages folder of this repository](https://github.com/PlayFab/UnitySDK/tree/versioned/Packages), or via our website at https://learn.microsoft.com/gaming/playfab/sdks/unity3d/, or click this link for a [direct download to the unity package](https://github.com/PlayFab/UnitySDK/raw/versioned/Packages/UnitySDK.unitypackage).
	1. 	Once downloaded, import the unitypackage.  This can be done by double clicking on the file, or using the context menu in the unity project view - Import Package --> Custom Package [(read more about asset packages)](https://docs.unity3d.com/Manual/AssetPackages.html).


## 4. ISerializer, SimpleJson & Json Libraries changed.		  

So up until now, the instructions for upgrading have been fairly trivial.  Back up, nuke and replace files.  But depending on how extensively you were using the internal JSON libs that we provide you in previous versions of our SDK you may still have errors in the project. Don't worry this is normal and below I'll explain what to do. Yay!

First, however, let me explain what we did.  

While JSON.net for Unity is a very good product which we were able to provide free as part of our SDK previously, this required some extra maintenance work from the JSON.net for Unity team which wasn’t really sustainable, so we’ve elected to move off the JSON.net serializer in order to remove that burden (but you can still purchase it via the Unity Asset Store).  Instead, we took the time to evaluate the available JSON serializers and find one that we could integrate and maintain going forward.

As a result, we chose SimpleJson.  It is a lightweight, easily maintained library which, while not perfect, does have the key functionality needed – and we will continue to make updates and fixes in that code going forward.  But that said, it was still important for us to provide a way to allow developers to continue using JSON.net if they chose to.  So with our latest release, we have introduced the ISerializer.  Our current SimpleJson serializer is an implementation of ISerializer and with minimal effort you can create your own wrapper for any JSON serializer of choice, including JSON.net.

Before we get into usage examples and what changes you’ll need to make.  I wanted to share with you a couple of the benefits that you will gain as a developer.  You will get ultimate flexibility on what type of serializer is used in our SDK.  In addition, we know that overall file size of your game or application is important. JSON.net is quite a large library, so the overall footprint is smaller using our new SimpleJson solution.  The last benefit I want to mention about the new serializer is the added cross platform stability.  We know cross platform issues are difficult to deal with and we have gone through great lengths through hard work and testing to ensure that our serializer works on all platforms.


With that said, let's get started addressing issues.

1. Deserialization & Serialization -  This is now simplified.  All you have to do to serialize or deserialize is the following.

        ```
			public class SomeObject {
				public string SomeField;
			}
			var myObject = new SomeObject(){ SomeField="Test" }
			var json = PlayFab.Json.JsonWrapper.serializeObject(myObject);
			var myDeserializedObject = PlayFab.Json.JsonWrapper.deserializeObject<SomeObject>(json);
        ``` 


2. For developers updating projects from an older PlayFab SDK version, there are a couple of changes that you will need to make. 

	1. First, the serialization strategy is a different object, so in places were you were making calls like this:
        ```
			JsonConvert.DeserializeObject<[SomeType]>([string of json], Util.JsonSettings)
        ```

	2. You will need to replace those with calls to PlayFab SimpleJson like so:

        ```
			JsonWrapper.DeserializeObject<[SomeType]>([string of json], Util.ApiSerializerStrategy);
        ```

	3. Also if you were using JsonUtils,  that is no longer part of the SDK.  To update that, you will need to either create your own converters, or do basic type casting. For example, this line:

        ```
			var bool = JsonUtil.Get<bool>( myBooleanValue.toString() );
        ```

		Could be re-written like this:

        ```
			var bool = bool.parse( myBooleanValue.toString() );
        ```

But as I said, you can also continue using JSON.net if you prefer, via the ISerializer. To do so, you would:

- [Purchase JSON.net from the Unity Asset Store](https://www.assetstore.unity3d.com/en/#!/content/11347)
- [Download the ISerializer package for JSON.net](https://github.com/PlayFab/UnitySDKV2Beta/tree/master/Packages)


For other JSON serializers, the ISerializer package for JSON.net can be used as the framework & example for integration of any other library.


## 5.Conclusion

So hopefully the information above is just what you needed to help you convert over to the new SDK.  There are always other scenarios that I probably have not covered here and we want to hear about them. The best thing to do for you is to post a question in our [Community Forum](http://community.playfab.com) and we will help you through your issues.  For bug reports, please post an issue on the respository and /or send an email to devrel@playfab.com.  
