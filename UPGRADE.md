UnitySDK Upgrade from v1 to v2 guide
========

Note: This is a guide and not necessarily a step by step solution.  Therefore each upgrade scenario might be slightly different.

1. Overview:
----
Upgrading to the new  Unity SDK v2 is not difficult at all.  However, depending on how you were using the previous SDK and what usage and features of the previous JSON serializer there could be some pain points.  This guide's intent is to identify these potential pain points and give you (the developer) a clear path to upgrade.

2. Prerequisites:
----

This document assumes familiarity with the Unity game engine, MonoDevelop Unity .NET programming environment, and Mac OS X operating system environment.

-  Users should also be familiar with the topics covered in our [getting started guide](https://playfab.com/docs/getting-started-with-playfab/).

To connect to the PlayFab service, your machine must be running TLS v1.2 or better.

- For Windows, this means Windows 7 and above
- [Official Microsoft Documentation](https://msdn.microsoft.com/en-us/library/windows/desktop/aa380516%28v=vs.85%29.aspx)
- [Support for SSL/TLS protocols on Windows](http://blogs.msdn.com/b/kaushal/archive/2011/10/02/support-for-ssl-tls-protocols-on-windows.aspx)

3. Installing or Upgrading the PlayFab UnitySdk
---
The most important part about upgrading to the new SDK is that you MUST remove the old SDK first.  **DO NOT**   just copy or import the new SDK over top of the old sdk.   That will not work at all.  

So what do you need to remove?  Depending on which version of the SDK you have there are a few different file locations you should check for files.  In the future we will have a tool that will do this clean-up for you, but for now you have to do it manually.

1. First, look for  PlayFabSDK folder and nuke it ( delete it ).
2. Next, look for Plugins Folder and here it becomes a little more tricky.  You can't just delete the Plugins folder because you might have other Plugins installed ( like Facebook, or Google Play Services etc.. ) so we need to be very specific as to what you can delete. Below are a list of files that are safe to delete

	1. Folder - PlayFabShared
	2. Android - Any of these files


