package com.playfab.unityplugin.GCM;

import android.app.AlarmManager;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.media.RingtoneManager;
import android.net.Uri;
import android.os.Build;
import android.preference.PreferenceManager;
import android.support.v4.app.NotificationCompat;
import android.util.Log;

import com.unity3d.player.UnityPlayer;

public class PlayFabNotificationSender {
    /*
     * Send the notification to Unity and/or the device
     */
    public static void sendNotificationNow(Context intent, PlayFabNotificationPackage notification) {
        boolean sendToNotificationBar = PlayFabConst.AlwaysShowOnNotificationBar || UnityPlayer.currentActivity == null;
        if (UnityPlayer.currentActivity != null) {
            try {
                // Try to send the message to Unity if it is running
                UnityPlayer.UnitySendMessage(PlayFabConst.UNITY_EVENT_OBJECT, "GCMMessageReceived", notification.toJson());
                if (!PlayFabConst.hideLogs) Log.i(PlayFabConst.LOG_TAG, "Sent push to Unity");
            } catch (Exception e) {
                // If it fails, fall back on the Notification Bar
                sendToNotificationBar = true;
            }
        } else if (!PlayFabConst.hideLogs) Log.i(PlayFabConst.LOG_TAG, "Unity Context null");

        if (sendToNotificationBar)
            sendNotificationToDevice(intent, notification);
    }

    private static void sendNotificationToDevice(Context intent, PlayFabNotificationPackage notification) {
        try {
            PendingIntent pendingIntent = PendingIntent.getActivity(intent, PlayFabConst.REQUEST_CODE_UNITY_ACTIVITY,
                    intent.getPackageManager().getLaunchIntentForPackage(intent.getPackageName()), PendingIntent.FLAG_UPDATE_CURRENT);
            NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(intent);

            // Grab some strings from the message, or fall back on defaults
            SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(intent);
            String appIcon = notification.Icon == null || notification.Icon.isEmpty() ? sharedPreferences.getString(PlayFabConst.PROPERTY_APP_ICON, "app_icon") : notification.Icon;
            Uri defaultSoundUri = Uri.parse(notification.Sound == null || notification.Sound.isEmpty() ? RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION).toString() : notification.Sound);
            String title = notification.Title == null || notification.Title.isEmpty() ? sharedPreferences.getString(PlayFabConst.PROPERTY_GAME_TITLE, "") : notification.Title;

            // Try to set small icon
            int iconIntT = intent.getResources().getIdentifier(appIcon + "_transparent", "drawable", intent.getPackageName());
            int iconInt = intent.getResources().getIdentifier(appIcon, "drawable", intent.getPackageName());
            if (iconIntT != 0 && Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP)
                notificationBuilder.setSmallIcon(iconIntT);
            else if (iconInt != 0)
                notificationBuilder.setSmallIcon(iconInt);
            else
                notificationBuilder.setSmallIcon(android.R.color.transparent);

            // Set large icon
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP && iconInt != 0) {
                Bitmap bigIcon = BitmapFactory.decodeResource(intent.getResources(), iconInt);
                notificationBuilder.setLargeIcon(bigIcon);
            }

            notificationBuilder.setContentTitle(title)
                    .setStyle(new NotificationCompat.BigTextStyle().bigText(notification.Message))
                    .setContentText(notification.Message)
                    .setSound(defaultSoundUri)
                    .setPriority(NotificationCompat.PRIORITY_HIGH)
                    .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
                    .setAutoCancel(true)
                    .setContentIntent(pendingIntent);

            NotificationManager notificationManager = (NotificationManager) intent.getSystemService(Context.NOTIFICATION_SERVICE);
            notificationManager.notify(notification.Id, notificationBuilder.build());
        } catch (Exception e) {
            Log.d(PlayFabConst.LOG_TAG, e.getMessage());
        }
    }

    public static PlayFabNotificationPackage createNotificationPackage(Context intent, String message, int id) {
        PlayFabNotificationPackage output = PlayFabNotificationPackage.fromJson(message);
        if (output == null) {
            output = new PlayFabNotificationPackage();
            output.setMessage(message, id);
        }
        return output;
    }

    public static void send(Context intent, PlayFabNotificationPackage notifyPackage) {
        try {
            Intent notificationIntent = new Intent(intent, NotificationPublisher.class);
            byte[] bytes = ParcelableUtil.marshall(notifyPackage);
            notificationIntent.putExtra(PlayFabConst.NOTIFICATION_JSON, bytes);
            PendingIntent pendingIntent = PendingIntent.getBroadcast(intent, notifyPackage.Id, notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT);

            long delayMillis = notifyPackage.getMsgDelayInMillis();
            if (delayMillis > 0) {
                AlarmManager alarmManager = (AlarmManager) intent.getSystemService(intent.ALARM_SERVICE);
                alarmManager.set(AlarmManager.RTC_WAKEUP, System.currentTimeMillis() + delayMillis, pendingIntent);
                if (!PlayFabConst.hideLogs)
                    Log.i(PlayFabConst.LOG_TAG, "Schedule Msg: " + notifyPackage.Message + ", Alarm was set to: " + notifyPackage.ScheduleDate + ", delayMillis: " + delayMillis);
            } else {
                sendNotificationNow(intent, notifyPackage);
            }
        } catch (Exception e) {
            Log.d(PlayFabConst.LOG_TAG, e.getMessage());
        }
    }

    public static void cancelScheduledNotification(Context intent, PlayFabNotificationPackage notifyPackage) {
        try {
            Intent notificationIntent = new Intent(intent, NotificationPublisher.class);
            notificationIntent.putExtra(PlayFabConst.NOTIFICATION_JSON, notifyPackage);
            PendingIntent pendingIntent = PendingIntent.getBroadcast(intent, notifyPackage.Id, notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT);
            AlarmManager alarmManager = (AlarmManager) intent.getSystemService(intent.ALARM_SERVICE);
            alarmManager.cancel(pendingIntent);
        } catch (Exception e) {
            Log.d(PlayFabConst.LOG_TAG, e.getMessage());
        }
    }
}
