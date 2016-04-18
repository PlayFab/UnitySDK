package com.playfab.unityplugin.GCM;

/**
 * Created by Marco on 8/19/2015.
 */

import android.app.Activity;
import android.util.Log;

import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.GoogleApiAvailability;
import com.google.android.gms.common.GooglePlayServicesUtil;
import com.playfab.unityplugin.PlayFabUnityAndroidPlugin;
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
        GoogleApiAvailability googleAPI = GoogleApiAvailability.getInstance();
        int resultCode = googleAPI.isGooglePlayServicesAvailable(unityActivity);
        if (resultCode != ConnectionResult.SUCCESS) {
            if (GooglePlayServicesUtil.isUserRecoverableError(resultCode)) {
                GooglePlayServicesUtil.getErrorDialog(resultCode, unityActivity,
                        PLAY_SERVICES_RESOLUTION_REQUEST).show();
            } else {
                Log.i(PlayFabUnityAndroidPlugin.TAG, "This device is not supported.");
            }
            return false;
        }
        return true;
    }

}
