package com.playfab.unityplugin.GCM;

import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
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

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.Set;

/**
 * Created by Marco on 8/18/2015.
 */

/**
 * Monitors the Notification channel and listens for and processes incoming GCM notifications
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

        setNotificationPackage(message);
        Log.i(PlayFabUnityAndroidPlugin.TAG, "Message Recieved: " + message);

        if( UnityPlayer.currentActivity != null ){
            try
            {
                //If Unity is running and has focus
                if(!PlayFabUnityAndroidPlugin.RouteToNotificationArea) {
                    Log.i(PlayFabUnityAndroidPlugin.TAG, "Sending Notification to Unity");
                    //Try to send the message to Unity if it is running.
                    UnityPlayer.UnitySendMessage(PlayFabUnityAndroidPlugin.UNITY_EVENT_OBJECT, "GCMMessageReceived", message);
                }else {
                    //Unity doesn't have focus, so send to notification bar.
                    sendNotification();
                }
            }
            catch(Exception e)
            {
                Log.i(PlayFabUnityAndroidPlugin.TAG, "Did not forward to unity since it was not running");
                //If for some strange reason, unity isn't running and the currentActivity is not null, then in this edge case we'll send the notification to the device.
                sendNotification();
            }
        }else{
            Log.i(PlayFabUnityAndroidPlugin.TAG,"Sending Notification to Device");
            sendNotification();
        }
    }
    // [END receive_message]

    /**
     * Create and show a simple notification containing the received GCM message.
     */
    private void sendNotification() {
        PendingIntent pendingIntent = PendingIntent.getActivity(this, REQUEST_CODE_UNITY_ACTIVITY,
                getPackageManager().getLaunchIntentForPackage(getPackageName()),
                PendingIntent.FLAG_UPDATE_CURRENT);

        PlayFabNotificationPackage pushNotificationPackage = PlayFabPushCache.getPushCache();

        String appIcon = pushNotificationPackage.Icon;
        String title = pushNotificationPackage.Title;
        Uri defaultSoundUri = Uri.parse(pushNotificationPackage.Sound);
        String message = pushNotificationPackage.Message;

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

    public void setNotificationPackage(String message){
        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(this);
        PlayFabNotificationPackage mPackage = new PlayFabNotificationPackage();
        mPackage.Title = sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_GAME_TITLE, "");
        mPackage.Icon = sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_APP_ICON, "app_icon");
        mPackage.Message = message;
        mPackage.Sound = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION).toString();

        if(isJSONValid(message)){
            try {
                JSONObject jObj = new JSONObject(message);
                Log.i(PlayFabUnityAndroidPlugin.TAG,"Message was JSON");
                //This is so that the ENTIRE JSON message is not in the notification should someone forget to send the "Message" attribute.
                mPackage.Message = "";

                if (jObj.has("Title")) {
                    mPackage.Title = jObj.getString("Title");
                }

                if(jObj.has("Message")){
                    mPackage.Message = jObj.getString("Message");
                }

                if(jObj.has("Icon")){
                    mPackage.Icon = jObj.getString("Icon");
                }

                if(jObj.has("Sound")){
                    mPackage.Sound = Uri.parse("android.resource://" + getPackageName() + "/" + jObj.getString("Sound")).toString();
                }

                if(jObj.has("CustomData")){
                    mPackage.CustomData = jObj.getString("CustomData");
                }
            }catch(JSONException e){
                //Could not parse json. Shouldn't happen since we checked in the isJSONValid
            }
        }

        PlayFabPushCache.setPushCache(mPackage);
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

    public boolean isJSONValid(String test) {
        try {
            new JSONObject(test);
        } catch (JSONException ex) {
            // edited, to include @Arthur's comment
            // e.g. in case JSONArray is valid as well...
            Log.i(PlayFabUnityAndroidPlugin.TAG,"Could not parse to JSONObject");
            try {
                new JSONArray(test);
            } catch (JSONException ex1) {
                Log.i(PlayFabUnityAndroidPlugin.TAG,"Could not parse to JSONArray");
                return false;
            }
        }
        return true;
    }

}

