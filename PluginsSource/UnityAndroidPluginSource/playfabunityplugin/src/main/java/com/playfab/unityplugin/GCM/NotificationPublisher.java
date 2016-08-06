package com.playfab.unityplugin.GCM;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;

/**
 * Created by Marco on 8/5/2016.
 */

public class NotificationPublisher extends BroadcastReceiver{
    public static String NOTIFICATION_ID = "notification-id";
    public static String NOTIFICATION = "notification";

    public void onReceive(Context context, Intent intent) {
        //int nid = PlayFabNotificationSender.getNotificationId();
        //String notifyId = intent.getStringExtra(NOTIFICATION_ID);
        PlayFabNotificationPackage notification = intent.getParcelableExtra(NOTIFICATION);
        PlayFabPushCache.setPushCache(notification);
        PlayFabNotificationSender.sendNotification();
    }
}
