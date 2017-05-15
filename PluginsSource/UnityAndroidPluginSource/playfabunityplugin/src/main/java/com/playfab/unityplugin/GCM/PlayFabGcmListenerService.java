package com.playfab.unityplugin.GCM;


import android.os.Bundle;
import android.util.Log;

import com.google.android.gms.gcm.GcmListenerService;
import com.playfab.unityplugin.PlayFabUnityAndroidPlugin;
import com.unity3d.player.UnityPlayer;
import java.util.Set;

/**
 * Created by Marco on 8/18/2015.
 */

/**
 * Monitors the Notification channel and listens for and processes incoming GCM notifications
 */
public class PlayFabGcmListenerService extends GcmListenerService {
    private static final String TAG = "PlayFabGCM";
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
        for (String key : keys) {
            Object o = data.get(key);
            //String output = String.format("Push Received: %1$", o.toString());
            //Log.i("PlayFabPushMessage",output);
            Log.i("PlayFabPushMessage", key);
            Log.i("PlayFabPushMessage", o.getClass().toString());
            if (o.getClass().getName().contains("String")) {
                String msg = data.getString(key);
                Log.i("PlayFabPushMessage", msg);
            }
        }

        String message = "";
        //Check for message first, if this message was sent via GCM API then it will contain "message"
        //otherwise it might have been sent via AWS Simple Notification Service, in which the message is in the default key.
        if (data.containsKey("message")) {
            message = data.getString("message");
        } else if (data.containsKey("default")) {
            message = data.getString("default");
        }

        PlayFabNotificationPackage notification = PlayFabNotificationSender.createNotificationPackage(this, message);

        Log.i(PlayFabUnityAndroidPlugin.TAG, "Message Recieved: " + message);

        if (UnityPlayer.currentActivity != null) {
            try {
                //If Unity is running and has focus
                if (!PlayFabUnityAndroidPlugin.RouteToNotificationArea) {
                    Log.i(PlayFabUnityAndroidPlugin.TAG, "Sending Notification to Unity");
                    //Try to send the message to Unity if it is running.
                    UnityPlayer.UnitySendMessage(PlayFabUnityAndroidPlugin.UNITY_EVENT_OBJECT, "GCMMessageReceived", message);
                } else {
                    //Unity doesn't have focus, so send to notification bar.
                    //PlayFabNotificationSender.sendNotification();
                    PlayFabNotificationSender.Send(this, notification);
                }
            } catch (Exception e) {
                Log.i(PlayFabUnityAndroidPlugin.TAG, "Did not forward to unity since it was not running");
                //If for some strange reason, unity isn't running and the currentActivity is not null, then in this edge case we'll send the notification to the device.
                //PlayFabNotificationSender.sendNotification();
                PlayFabNotificationSender.Send(this, notification);

            }
        } else {
            Log.i(PlayFabUnityAndroidPlugin.TAG, "Sending Notification to Device");
            //PlayFabNotificationSender.sendNotification();
            PlayFabNotificationSender.Send(this, notification);
            //PlayFabNotificationSender.sendNotification(this);

        }
    }
    // [END receive_message]

}

