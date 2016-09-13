/**
 * Created by Marco on 8/19/2015.
 */
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

import com.playfab.unityplugin.GCM.PlayFabRegistrationIntentService;
import com.playfab.unityplugin.GCM.PlayServicesUtils;
import com.unity3d.player.UnityPlayer;

/**
 * The main class for interfacing with the Unity environment
 */
public class PlayFabUnityAndroidPlugin extends Service{
    public static final String TAG = "PlayFabUAP"; //PlayFabUnityAndroidPlugin
    public static final String UNITY_EVENT_OBJECT = "_PlayFabGO";
    public static final String PROPERTY_GAME_TITLE = "_PlayFab_GameTitle";
    public static final String PROPERTY_APP_ICON = "_PlayFab_AppIcon";
    public static final String PROPERTY_SENDER_ID = "_PlayFab_SenderID";
    public static final String SENT_TOKEN_TO_SERVER = "sentTokenToServer";
    public static boolean RouteToNotificationArea = true;

    private static boolean mServiceBound = false;
    private static PlayFabUnityAndroidPlugin mBoundService;
    private static String mGameTitle;
    private static String mSenderId;
    private static String mAppIcon;

    private IBinder mBinder = new LocalPlayFabBinder();

    public class LocalPlayFabBinder extends Binder {
        PlayFabUnityAndroidPlugin getService(){
            return PlayFabUnityAndroidPlugin.this;
        }
    }

    @Override
    public void onCreate(){
        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(this);
        SharedPreferences.Editor editor = sharedPreferences.edit();
        editor.putString(PROPERTY_SENDER_ID, mSenderId);
        editor.putString(PROPERTY_GAME_TITLE, mGameTitle);
        if(mAppIcon != null){
            editor.putString(PROPERTY_APP_ICON,mAppIcon);
        }
        editor.commit();

        if(PlayServicesUtils.isPlayServicesAvailable()){
            Intent mThisIntent = new Intent(this,PlayFabRegistrationIntentService.class);
            startService(mThisIntent);
        }
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId){
        return START_NOT_STICKY;
    }

    @Override
    public IBinder onBind(Intent intent){
        Log.i("TAG", "PlayFabUnityAndroidPlugin Service onBind");
        return mBinder;
    }

    @Override
    public void onRebind(Intent intent){
        Log.i("TAG", "PlayFabUnityAndroidPlugin Service onRebind");
        super.onRebind(intent);
    }

    @Override
    public boolean onUnbind(Intent intent){
        Log.i("TAG", "PlayFabUnityAndroidPlugin Service onUnbind");
        return true;
    }

    private static ServiceConnection mServiceConnection = new ServiceConnection(){
        @Override
        public void onServiceDisconnected(ComponentName name){
            Log.i(TAG,"Service Connection Disconnected.");
            mServiceBound = false;
        }

        @Override
        public void onServiceConnected(ComponentName name, IBinder service){
            Log.i(TAG,"Service Connection Connected.");
            LocalPlayFabBinder localPlayFabBinder = (LocalPlayFabBinder) service;
            mBoundService = localPlayFabBinder.getService();
            mServiceBound = true;
        }
    };

    public static void initGCM(String senderId, String gameTitle) {
        Log.i(TAG, "PlayFab GCM Init, saving prefs.");
        Log.i(TAG, "Setting SenderId: " + senderId);
        mSenderId = senderId;
        mGameTitle = gameTitle;

        Context mUnityService = UnityPlayer.currentActivity.getApplication().getApplicationContext();
        Intent intent = new Intent(mUnityService, PlayFabUnityAndroidPlugin.class);
        mUnityService.startService(intent);
        //Binding to the Unity Activity so that no one else can use this service class but our calling game.
        Log.i(TAG, "PlayFabUnityAndroidPlugin Service, Binding to Unity Activity");
        mUnityService.bindService(intent, mServiceConnection, Context.BIND_AUTO_CREATE);
    }

    public static void initGCM(String senderId, String gameTitle, String appIcon) {
        mAppIcon = appIcon;
        initGCM(senderId,gameTitle);
    }

    public static void stopPluginService(){
        if(mServiceBound && mServiceConnection != null){
            UnityPlayer.currentActivity.unbindService(mServiceConnection);
        }
    }

    public static void updateRouting(boolean state){
        RouteToNotificationArea = state;
    }

}