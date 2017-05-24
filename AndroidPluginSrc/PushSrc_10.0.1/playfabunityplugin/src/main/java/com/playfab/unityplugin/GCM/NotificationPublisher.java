package com.playfab.unityplugin.GCM;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Parcel;
import android.util.Log;

import java.text.SimpleDateFormat;
import java.util.Date;

public class NotificationPublisher extends BroadcastReceiver {
    public static String NOTIFICATION_JSON = "NOTIFICATION_JSON";

    public void onReceive(Context context, Intent intent) {
        Log.i(PlayFabNotificationSender.TAG, "OnRecieve Notification Publisher Sending Notification..");
        byte[] bytes = intent.getByteArrayExtra(NOTIFICATION_JSON);
        Parcel parcel = ParcelableUtil.unmarshall(bytes);
        PlayFabNotificationPackage notification = new PlayFabNotificationPackage(parcel);
        PlayFabNotificationSender.sendNotification(context, notification);
    }
}
