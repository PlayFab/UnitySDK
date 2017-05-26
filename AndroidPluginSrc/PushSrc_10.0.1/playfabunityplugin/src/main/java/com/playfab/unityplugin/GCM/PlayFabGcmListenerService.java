package com.playfab.unityplugin.GCM;

import android.os.Bundle;
import android.util.Log;

import com.google.android.gms.gcm.GcmListenerService;

import java.util.Set;

/**
 * Monitors the Notification channel and listens for and processes incoming GCM notifications
 */
public class PlayFabGcmListenerService extends GcmListenerService {
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

        if (!PlayFabConst.hideLogs)
            Log.i(PlayFabConst.LOG_TAG, "Push Message Received: " + message);

        PlayFabNotificationPackage notification = PlayFabNotificationSender.createNotificationPackage(this, message, id);
        PlayFabNotificationSender.send(this, notification);
    }
}
