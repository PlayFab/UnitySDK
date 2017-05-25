package com.playfab.unityplugin.GCM;

import android.app.Activity;
import android.util.Log;

import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.GoogleApiAvailability;
import com.playfab.unityplugin.PlayFabUnityAndroidPlugin;
import com.unity3d.player.UnityPlayer;

public class PlayServicesUtils {
    /**
     * Check the device to make sure it has the Google Play Services APK. If
     * it doesn't, display a dialog that allows users to download the APK from
     * the Google Play Store or enable it in the device's system settings.
     */
    public static boolean isPlayServicesAvailable() {
        boolean available = false;
        try {
            Activity unityActivity = UnityPlayer.currentActivity;
            GoogleApiAvailability googleAPI = GoogleApiAvailability.getInstance();
            int resultCode = googleAPI.isGooglePlayServicesAvailable(unityActivity);
            available = (resultCode == ConnectionResult.SUCCESS);
            if (!available) {
                if (googleAPI.isUserResolvableError(resultCode)) {
                    googleAPI.getErrorDialog(unityActivity, resultCode, PlayFabConst.PLAY_SERVICES_RESOLUTION_REQUEST).show();
                } else {
                    Log.i(PlayFabUnityAndroidPlugin.TAG, "This device is not supported.");
                }
            }
        } catch (Exception e) {
            Log.e(PlayFabUnityAndroidPlugin.TAG, "PlayFab GCM isPlayServicesAvailable exception: " + e.getMessage());
        }
        return available;
    }
}
