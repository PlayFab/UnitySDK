package com.playfab.unity.plugin;

import com.unity3d.player.UnityPlayer;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager.NameNotFoundException;
import android.content.res.Resources;
import android.util.Log;

public class AndroidPlugin {

	static final String TAG = "PlayFabUnityAndroidPlugin";
	public static final String UNITY_EVENT_OBJECT = "_PlayFabGO";

	public static final String PROPERTY_APP_VERSION = "_PlayFab_appVersion";
	public static final String PROPERTY_NOTIFICATION_ID = "_PlayFab_notificationId";
	public static int APP_ICON=0;
	
	public static void init()
	{
		Context context = UnityPlayer.currentActivity;
		Resources res = context.getResources();
		APP_ICON = res.getIdentifier("app_icon", "drawable", context.getPackageName());
		Log.i(AndroidPlugin.TAG, "Initialized with app icon: " + APP_ICON);
		
		GoogleCloudMessaging.init();
	}
	
	/**
	 * @return Application's {@code SharedPreferences}.
	 */
	public static SharedPreferences getPluginPreferences() {
	    // This sample app persists the registration ID in shared preferences, but
	    // how you store the regID in your app is up to you.
		Activity unityActivity = UnityPlayer.currentActivity;
	    return unityActivity.getSharedPreferences("PlayFabUnityPluginPrefs",
	            Context.MODE_PRIVATE);
	}
	
	public static synchronized int getNotificationId()
	{
		SharedPreferences prefs = getPluginPreferences();
		int id = prefs.getInt(PROPERTY_NOTIFICATION_ID, 1);
		int nextId = id+1;
		SharedPreferences.Editor editor = prefs.edit();
	    editor.putInt(AndroidPlugin.PROPERTY_NOTIFICATION_ID, nextId);
	    editor.commit();
		return id;
	}
	
	/**
	 * @return Application's version code from the {@code PackageManager}.
	 */
	public static int getAppVersion() {
	    try {
	    	Context context = UnityPlayer.currentActivity;
	        PackageInfo packageInfo = context.getPackageManager()
	                .getPackageInfo(context.getPackageName(), 0);
	        return packageInfo.versionCode;
	    } catch (NameNotFoundException e) {
	        // should never happen
	        throw new RuntimeException("Could not get package name: " + e);
	    }
	}
}
