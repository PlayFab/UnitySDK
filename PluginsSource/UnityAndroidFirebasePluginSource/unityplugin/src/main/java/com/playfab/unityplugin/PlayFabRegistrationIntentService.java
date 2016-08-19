/**
 * Created by Marco on 8/19/2015.
 */

package com.playfab.unityplugin;

import android.app.IntentService;
import android.content.Intent;
import android.content.SharedPreferences;
import android.preference.PreferenceManager;
import android.util.Log;

import com.google.android.gms.iid.InstanceID;
import com.playfab.unityplugin.PlayFabUnityAndroidPlugin;
import com.unity3d.player.UnityPlayer;

public class PlayFabRegistrationIntentService extends IntentService{

    private static final String TAG = "RegIntentService";
    private static InstanceID mInstanceID;
    private static PlayFabRegistrationIntentService mInstance;

    public PlayFabRegistrationIntentService() {
        super(TAG);
    }

    public static PlayFabRegistrationIntentService GetInstance(){
        return mInstance;
    }

    public static InstanceID GetInstanceId(){
        return mInstanceID;
    }

    @Override
    protected void onHandleIntent(Intent intent) {
        Log.i(TAG, "PlayFab GCM Registration Intent Service has been started.");
        //We are getting the instanceId and saving it for later and that is all we care about for now.
        mInstanceID = InstanceID.getInstance(this);
        mInstance = this;
        notifyRegistrationReady();
    }


    private void notifyRegistrationReady() {
        Log.i(TAG,"PlayFab GCM Registration Ready, sending event to Unity GCMRegistrationReady");
        UnityPlayer.UnitySendMessage(PlayFabUnityAndroidPlugin.UNITY_EVENT_OBJECT, "GCMRegistrationReady", "true");
    }

    public SharedPreferences getPluginPreferences() {
        // This sample app persists the registration ID in shared preferences, but
        // how you store the regID in your app is up to you.
        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(this);
        //Activity unityActivity = UnityPlayer.currentActivity;
        //unityActivity.getSharedPreferences(SHARED_PREFS_TAG, Context.MODE_PRIVATE);
        return sharedPreferences;
    }

}
