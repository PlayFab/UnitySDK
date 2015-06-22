package com.playfab.unity.plugin;

import android.app.Activity;
import android.util.Log;

import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.GooglePlayServicesUtil;
import com.unity3d.player.UnityPlayer;

public class PlayServicesUtils {
	
	private final static int PLAY_SERVICES_RESOLUTION_REQUEST = 9000;
	
	
	
	/**
	 * Check the device to make sure it has the Google Play Services APK. If
	 * it doesn't, display a dialog that allows users to download the APK from
	 * the Google Play Store or enable it in the device's system settings.
	 */
	public static boolean isPlayServicesAvailable() {
		Activity unityActivity = UnityPlayer.currentActivity;
	    int resultCode = GooglePlayServicesUtil.isGooglePlayServicesAvailable(unityActivity);
	    if (resultCode != ConnectionResult.SUCCESS) {
	        if (GooglePlayServicesUtil.isUserRecoverableError(resultCode)) {
	            GooglePlayServicesUtil.getErrorDialog(resultCode, unityActivity,
	                    PLAY_SERVICES_RESOLUTION_REQUEST).show();
	        } else {
	            Log.i(AndroidPlugin.TAG, "This device is not supported.");
	        }
	        return false;
	    }
	    return true;
	}
}
