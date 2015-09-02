package com.playfab.unityplugin.GCM;

import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.media.RingtoneManager;
import android.net.Uri;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.v4.app.NotificationCompat;
import android.util.Log;

import com.google.android.gms.gcm.GcmListenerService;
import com.playfab.unityplugin.PlayFabUnityAndroidPlugin;
import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerProxyActivity;

import java.util.Set;

/**
 * Created by Marco on 8/18/2015.
 */
public class PlayFabGcmListenerService extends GcmListenerService{
    private static final int REQUEST_CODE_UNITY_ACTIVITY = 1001;
    public static final String PROPERTY_NOTIFICATION_ID = "_PlayFab_notificationId";

    /**
     * Called when message is received.
     *
     * @param from SenderID of the sender.
     * @param data Data bundle containing message data as key/value pairs.
     *             For Set of keys use data.keySet().
     */
    // [START receive_message]
    @Override
    public void onMessageReceived(String from, Bundle data) {

        Set<String> keys = data.keySet();
        for(String key : keys){
            Object o = data.get(key);
            //String output = String.format("Push Received: %1$", o.toString());
            //Log.i("PlayFabPushMessage",output);
            Log.i("PlayFabPushMessage",key);
            Log.i("PlayFabPushMessage",o.getClass().toString());
            if(o.getClass().getName().contains("String")) {
                String msg = data.getString(key);
                Log.i("PlayFabPushMessage",msg);
            }
        }

        String message = "";
        //Check for message first, if this message was sent via GCM API then it will contain "message"
        //otherwise it might have been sent via AWS Simple Notification Service, in which the message is in the default key.
        if(data.containsKey("message")){
            message = data.getString("message");
        }else if(data.containsKey("default")){
            message = data.getString("default");
        }
        Log.i(PlayFabUnityAndroidPlugin.TAG, "Message Recieved: " + message);

        if( UnityPlayer.currentActivity != null ){
            try
            {
                Log.i(PlayFabUnityAndroidPlugin.TAG,"Sending Notification to Unity");
                //Try to send the message to Unity if it is running.
                UnityPlayer.UnitySendMessage(PlayFabUnityAndroidPlugin.UNITY_EVENT_OBJECT, "GCMMessageReceived", message);
            }
            catch(Exception e)
            {
                Log.i(PlayFabUnityAndroidPlugin.TAG, "Did not forward to unity since it was not running");
                //If for some strange reason, unity isn't running and the currentActivity is not null, then in this edge case we'll send the notification to the device.
                sendNotification(message);
            }
        }else{
            Log.i(PlayFabUnityAndroidPlugin.TAG,"Sending Notification to Device");
            sendNotification(message);
        }
    }
    // [END receive_message]

    /**
     * Create and show a simple notification containing the received GCM message.
     *
     * @param message GCM message received.
     */
    private void sendNotification(String message) {
        PendingIntent pendingIntent = PendingIntent.getActivity(this, REQUEST_CODE_UNITY_ACTIVITY,
                getPackageManager().getLaunchIntentForPackage(getPackageName()),
                PendingIntent.FLAG_UPDATE_CURRENT);

        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(this);
        String title = sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_GAME_TITLE, "");
        String appIcon = sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_APP_ICON, "app_icon");

        Uri defaultSoundUri= RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);
        NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(this)
                .setSmallIcon(getResources().getIdentifier(appIcon, "drawable", getPackageName()))
                .setContentTitle(title)
                .setStyle(new NotificationCompat.BigTextStyle().bigText(message))
                .setContentText(message)
                .setSound(defaultSoundUri)
                .setPriority(NotificationCompat.PRIORITY_HIGH)
                .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
                .setAutoCancel(true)
                .setContentIntent(pendingIntent);

        NotificationManager notificationManager = (NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);
        int notificationId = getNotificationId();
        notificationManager.notify(notificationId, notificationBuilder.build()); //ID_NOTIFICATION
    }

    public synchronized int getNotificationId()
    {
        SharedPreferences prefs = PreferenceManager.getDefaultSharedPreferences(this);
        int id = 1;
        int nextId = 1;
        if(prefs.contains(PROPERTY_NOTIFICATION_ID)) {
            id = prefs.getInt(PROPERTY_NOTIFICATION_ID, 1);
            nextId = id + 1;
        }
        SharedPreferences.Editor editor = prefs.edit();
        editor.putInt(PROPERTY_NOTIFICATION_ID, nextId);
        editor.commit();
        return id;
    }

}

