package com.playfab.unityplugin.GCM;


import android.os.Bundle;
import android.util.Log;

import com.google.android.gms.gcm.GcmListenerService;
import com.playfab.unityplugin.PlayFabUnityAndroidPlugin;
import com.unity3d.player.UnityPlayer;

import java.util.Set;

/**
 * Monitors the Notification channel and listens for and processes incoming GCM notifications
 */
public class PlayFabGcmListenerService extends GcmListenerService {
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

        int id = 0;
        if (data.containsKey("Id"))
            data.getInt("Id");

        Log.i(PlayFabUnityAndroidPlugin.TAG, "Push Message Received: " + message);

        PlayFabNotificationPackage notification = PlayFabNotificationSender.createNotificationPackage(this, message, id);
        boolean sendToNotificationBar = PlayFabUnityAndroidPlugin.AlwaysShowOnNotificationBar || UnityPlayer.currentActivity != null;

        if (UnityPlayer.currentActivity != null) {
            try {
                // Try to send the message to Unity if it is running
                UnityPlayer.UnitySendMessage(PlayFabUnityAndroidPlugin.UNITY_EVENT_OBJECT, "GCMMessageReceived", message);
                Log.i(PlayFabUnityAndroidPlugin.TAG, "Sent push to Unity");
            } catch (Exception e) {
                // If it fails, fall back on the Notification Bar
                sendToNotificationBar = true;
            }
        }

        if (sendToNotificationBar) {
            try {
                PlayFabNotificationSender.Send(this, notification);
                Log.i(PlayFabUnityAndroidPlugin.TAG, "Sent push to Device Notification Bar");
            } catch (Exception e) {
                Log.e(PlayFabUnityAndroidPlugin.TAG, "Failed to send push to Notification Bar");
            }
        }
    }
}
