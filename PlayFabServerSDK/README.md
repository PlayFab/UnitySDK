PlayFab Server and Admin SDK
============================


1. Overview
-----------

This SDK is intended for customers developing a server in Unity who wish to interact with PlayFab APIs. It is not intended to be included in a game client, and doing so would compromise your title's security.


2. Installing the Server SDK
----------------------------

Drag the entire PlayFabServerSDK directory into your project's assets (anywhere is ok). This will copy the SDK into your project.


3. Configuring the SDK
-------------------------
You must configure the server SDK with your unique TitleId, as assigned by the PlayFab developer portal. Your TitleId will be a short string that looks something like "8D34" in your Title URL.

Use 8D34 as a demonstration TitleId if you would like to try the various pre-made scenes without making and configurating your own title.

You must also set your title's secret key, as assigned by the PlayFab developer portal. Your secret key is a string of characters that looks something like "S07CDBJ3DBZ7ISLDDESJZ1UFSAFCID7A5XBK8SPXCSBA54P1FA".

To configure the SDK via code, then somewhere in your game's startup code, add the following:

```
using PlayFab;

PlayFabSettings.TitleId = "your title id here";
PlayFabSettings.DeveloperSecretKey = "your secret key here";
```

IMPORTANT: Do not reveal your developer secret key, expose it anywhere in your game, or ship it in your public client. It must only be included in a pure server project that is not intended for public distribution.


4.  Combining both Client and Server SDKs in a single project
-------------------------------------------------------------

Combining the SDKs in a single project is not recommended, since the server SDK requires your developer secret key, and should never be released to the public. However, if you wish to create a project containing both SDKs for testing or tool purposes, you can do so as following:

First unpack the PlayFab Client SDK into the project following the normal client SDK README. Then copy the contents of the server SDK over top of the client SDK, overwriting any shared files. This will result in a combined SDK with all API calls available.
