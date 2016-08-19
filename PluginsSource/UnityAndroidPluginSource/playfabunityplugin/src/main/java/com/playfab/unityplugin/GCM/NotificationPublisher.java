package com.playfab.unityplugin.GCM;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.util.Log;

/**
 * Created by Marco on 8/5/2016.
 */

public class NotificationPublisher extends BroadcastReceiver{
    private static final String TAG = "PlayFabGCM";
    public static String NOTIFICATION_ID = "notification-id";
    public static String NOTIFICATION = "notification";

    public void onReceive(Context context, Intent intent) {
        Log.i(TAG,"OnRecieve Notification Publisher Sending Notification..");
        PlayFabNotificationPackage notification = intent.getParcelableExtra(NOTIFICATION);
        PlayFabPushCache.setPushCache(notification);
        PlayFabNotificationSender.sendNotification(context);

    }
}
