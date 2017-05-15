package com.playfab.unityplugin.GCM;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Parcel;
import android.util.Log;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by Marco on 8/5/2016.
 */

public class NotificationPublisher extends BroadcastReceiver {
    private static final String TAG = "PlayFabGCM";
    public static String NOTIFICATION_ID = "notification-id";
    public static String NOTIFICATION = "notification";

    public void onReceive(Context context, Intent intent) {
        Log.i(TAG, "OnRecieve Notification Publisher Sending Notification..");
        String notificationId = intent.getParcelableExtra(NOTIFICATION_ID);
        byte[] bytes = intent.getByteArrayExtra(NOTIFICATION);
        Parcel parcel = ParcelableUtil.unmarshall(bytes);
        PlayFabNotificationPackage notification = new PlayFabNotificationPackage(parcel);
        notification.SetDeliveryDate(new Date());
        notification.SetDelivered();
        PlayFabPushCache.setPushCache(notification);
        PlayFabNotificationSender.sendNotificationById(context, notification.Id);
    }
}
