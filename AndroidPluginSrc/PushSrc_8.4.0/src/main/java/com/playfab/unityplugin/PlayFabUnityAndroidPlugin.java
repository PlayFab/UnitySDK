package com.playfab.unityplugin;

import android.app.Service;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.ServiceConnection;
import android.content.SharedPreferences;
import android.os.Binder;
import android.os.IBinder;
import android.preference.PreferenceManager;
import android.util.Log;

import com.playfab.unityplugin.GCM.PlayFabConst;
import com.playfab.unityplugin.GCM.PlayFabRegistrationIntentService;
import com.playfab.unityplugin.GCM.PlayServicesUtils;
import com.unity3d.player.UnityPlayer;

/**
 * The main class for interfacing with the Unity environment
 */
public class PlayFabUnityAndroidPlugin extends Service {
    private static PlayFabUnityAndroidPlugin mBoundService;
    private static String mGameTitle;
    private static String mSenderId;
    private static String mAppIcon;

    private IBinder mBinder = new LocalPlayFabBinder();

    public class LocalPlayFabBinder extends Binder {
        PlayFabUnityAndroidPlugin getService() {
            return PlayFabUnityAndroidPlugin.this;
        }
    }

    @Override
    public void onCreate() {
        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(this);
        SharedPreferences.Editor editor = sharedPreferences.edit();
        editor.putString(PlayFabConst.PROPERTY_SENDER_ID, mSenderId);
        editor.putString(PlayFabConst.PROPERTY_GAME_TITLE, mGameTitle);
        if (mAppIcon != null) {
            editor.putString(PlayFabConst.PROPERTY_APP_ICON, mAppIcon);
        }
        editor.commit();

        if (PlayServicesUtils.isPlayServicesAvailable()) {
            Intent mThisIntent = new Intent(this, PlayFabRegistrationIntentService.class);
            startService(mThisIntent);
        }
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        return START_NOT_STICKY;
    }

    @Override
    public IBinder onBind(Intent intent) {
        Log.i(PlayFabConst.LOG_TAG, "PlayFabUnityAndroidPlugin Service onBind");
        return mBinder;
    }

    @Override
    public void onRebind(Intent intent) {
        Log.i(PlayFabConst.LOG_TAG, "PlayFabUnityAndroidPlugin Service onRebind");
        super.onRebind(intent);
    }

    @Override
    public boolean onUnbind(Intent intent) {
        Log.i(PlayFabConst.LOG_TAG, "PlayFabUnityAndroidPlugin Service onUnbind");
        return true;
    }

    private static ServiceConnection mServiceConnection = new ServiceConnection() {
        @Override
        public void onServiceDisconnected(ComponentName name) {
            if (!PlayFabConst.hideLogs)
                Log.i(PlayFabConst.LOG_TAG, "Service Connection Disconnected.");
        }

        @Override
        public void onServiceConnected(ComponentName name, IBinder service) {
            if (!PlayFabConst.hideLogs)
                Log.i(PlayFabConst.LOG_TAG, "Service Connection Connected.");
            LocalPlayFabBinder localPlayFabBinder = (LocalPlayFabBinder) service;
            mBoundService = localPlayFabBinder.getService();
        }
    };

    public static void initGCM(String senderId, String gameTitle) {
        try {
            if (!PlayFabConst.hideLogs)
                Log.i(PlayFabConst.LOG_TAG, "PlayFab GCM Init, Setting SenderId: " + senderId);
            mSenderId = senderId;
            mGameTitle = gameTitle;

            Context mUnityService = UnityPlayer.currentActivity.getApplication().getApplicationContext();
            Intent intent = new Intent(mUnityService, PlayFabUnityAndroidPlugin.class);
            mUnityService.startService(intent);
            //Binding to the Unity Activity so that no one else can use this service class but our calling game.
            if (!PlayFabConst.hideLogs)
                Log.i(PlayFabConst.LOG_TAG, "PlayFabUnityAndroidPlugin Service, Binding to Unity Activity");
            mUnityService.bindService(intent, mServiceConnection, Context.BIND_AUTO_CREATE);
        } catch (Exception e) {
            Log.e(PlayFabConst.LOG_TAG, "PlayFab GCM initGCM exception: " + e.getMessage());
        }
    }

    public static void initGCM(String senderId, String gameTitle, String appIcon) {
        try {
            mAppIcon = appIcon;
            initGCM(senderId, gameTitle);
        } catch (Exception e) {
            Log.e(PlayFabConst.LOG_TAG, "PlayFab GCM initGCM exception: " + e.getMessage());
        }
    }

    public static void stopPluginService() {
        try {
            if (mServiceConnection != null) {
                Context mUnityService = UnityPlayer.currentActivity.getApplication().getApplicationContext();
                Intent intent = new Intent(mUnityService, PlayFabUnityAndroidPlugin.class);
                mUnityService.stopService(intent);
                mUnityService.unbindService(mServiceConnection);
            }
        } catch (Exception e) {
            Log.e(PlayFabConst.LOG_TAG, "PlayFab GCM stopPluginService exception: " + e.getMessage());
        }
    }

    public static void alwaysShowOnNotificationBar(boolean showAlways) {
        PlayFabConst.AlwaysShowOnNotificationBar = showAlways;
    }
}