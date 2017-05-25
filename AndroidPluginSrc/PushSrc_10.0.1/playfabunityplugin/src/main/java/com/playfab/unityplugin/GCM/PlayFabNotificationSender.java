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

import com.playfab.unityplugin.PlayFabUnityAndroidPlugin;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class PlayFabNotificationSender {
    public static void sendNotification(Context intent, PlayFabNotificationPackage pushNotificationPackage) {
        try {
            PendingIntent pendingIntent = PendingIntent.getActivity(intent, PlayFabConst.REQUEST_CODE_UNITY_ACTIVITY,
                    intent.getPackageManager().getLaunchIntentForPackage(intent.getPackageName()), PendingIntent.FLAG_UPDATE_CURRENT);
            NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(intent);

            // Grab some strings from the message, or fall back on defaults
            SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(intent);
            String appIcon = pushNotificationPackage.Icon == null || pushNotificationPackage.Icon.isEmpty() ? sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_APP_ICON, "app_icon") : pushNotificationPackage.Icon;
            Uri defaultSoundUri = Uri.parse(pushNotificationPackage.Sound == null || pushNotificationPackage.Sound.isEmpty() ? RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION).toString() : pushNotificationPackage.Sound);
            String title = pushNotificationPackage.Title == null || pushNotificationPackage.Title.isEmpty() ? sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_GAME_TITLE, "") : pushNotificationPackage.Title;

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
                    .setStyle(new NotificationCompat.BigTextStyle().bigText(pushNotificationPackage.Message))
                    .setContentText(pushNotificationPackage.Message)
                    .setSound(defaultSoundUri)
                    .setPriority(NotificationCompat.PRIORITY_HIGH)
                    .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
                    .setAutoCancel(true)
                    .setContentIntent(pendingIntent);

            NotificationManager notificationManager = (NotificationManager) intent.getSystemService(Context.NOTIFICATION_SERVICE);
            notificationManager.notify(pushNotificationPackage.Id, notificationBuilder.build());
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
                Log.i(PlayFabConst.LOG_TAG, "Schedule Msg: " + notifyPackage.Message + ", Alarm was set to: " + notifyPackage.ScheduleDate + ", delayMillis: " + delayMillis);
            } else {
                sendNotification(intent, notifyPackage);
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
