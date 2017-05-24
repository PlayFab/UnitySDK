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
    public static final String TAG = "PlayFabGCM";
    private static final int REQUEST_CODE_UNITY_ACTIVITY = 1001;

    public static void sendNotification(Context intent, PlayFabNotificationPackage pushNotificationPackage) {
        try {
            PendingIntent pendingIntent = PendingIntent.getActivity(intent, REQUEST_CODE_UNITY_ACTIVITY,
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
            Log.d(TAG, e.getMessage());
        }
    }

    public static PlayFabNotificationPackage createNotificationPackage(Context intent, String message, int id) {
        PlayFabNotificationPackage mPackage = new PlayFabNotificationPackage();
        if (isJSONValid(message)) {
            try {
                JSONObject jObj = new JSONObject(message);
                // This is so that the ENTIRE JSON message is not in the notification should someone forget to send the "Message" attribute.
                mPackage.SetMessage("", 0);

                if (jObj.has("ScheduleDate")) {
                    mPackage.SetScheduleDate(jObj.getString("ScheduleDate"));
                }

                if (jObj.has("Title")) {
                    mPackage.Title = jObj.getString("Title");
                }

                if (jObj.has("Message")) {
                    if (jObj.has("Id"))
                        id = jObj.getInt("Id");
                    mPackage.SetMessage(jObj.getString("Message"), id);
                }

                if (jObj.has("Icon") && jObj.getString("Icon") != null && !jObj.getString("Icon").isEmpty() && jObj.getString("Icon") != "null") {
                    mPackage.Icon = jObj.getString("Icon");
                }

                if (jObj.has("Sound") && jObj.getString("Sound") != null && !jObj.getString("Sound").isEmpty() && jObj.getString("Sound") != "null") {
                    mPackage.Sound = Uri.parse("android.resource://" + intent.getPackageName() + "/" + jObj.getString("Sound")).toString();
                }

                if (jObj.has("CustomData") && jObj.getString("CustomData") != null && !jObj.getString("CustomData").isEmpty() && jObj.getString("CustomData") != "null") {
                    mPackage.CustomData = jObj.getString("CustomData");
                }
            } catch (JSONException e) {
                //Could not parse json. Shouldn't happen since we checked in the isJSONValid
            }
        } else {
            mPackage.SetMessage(message, id);
        }
        return mPackage;
    }

    private static boolean isJSONValid(String test) {
        try {
            new JSONObject(test);
        } catch (JSONException ex) {
            // edited, to include @Arthur's comment
            // e.g. in case JSONArray is valid as well...
            Log.i(PlayFabUnityAndroidPlugin.TAG, "Could not parse to JSONObject");
            try {
                new JSONArray(test);
            } catch (JSONException ex1) {
                Log.i(PlayFabUnityAndroidPlugin.TAG, "Could not parse to JSONArray");
                return false;
            }
        }
        return true;
    }

    public static void Send(Context intent, PlayFabNotificationPackage notifyPackage) {
        try {
            Intent notificationIntent = new Intent(intent, NotificationPublisher.class);
            byte[] bytes = ParcelableUtil.marshall(notifyPackage);
            notificationIntent.putExtra(NotificationPublisher.NOTIFICATION_JSON, bytes);
            PendingIntent pendingIntent = PendingIntent.getBroadcast(intent, notifyPackage.Id, notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT);

            long delayMillis = notifyPackage.GetMsgDelayInMillis();
            if (delayMillis > 0) {
                AlarmManager alarmManager = (AlarmManager) intent.getSystemService(intent.ALARM_SERVICE);
                alarmManager.set(AlarmManager.RTC_WAKEUP, System.currentTimeMillis() + delayMillis, pendingIntent);
                Log.i(TAG, "Schedule Msg: " + notifyPackage.Message + ", Alarm was set to: " + notifyPackage.ScheduleDate + ", delayMillis: " + delayMillis);
            } else {
                sendNotification(intent, notifyPackage);
            }
        } catch (Exception e) {
            Log.d(TAG, e.getMessage());
        }
    }

    public static void CancelScheduledNotification(Context intent, PlayFabNotificationPackage notifyPackage) {
        try {
            Intent notificationIntent = new Intent(intent, NotificationPublisher.class);
            notificationIntent.putExtra(NotificationPublisher.NOTIFICATION_JSON, notifyPackage);
            PendingIntent pendingIntent = PendingIntent.getBroadcast(intent, notifyPackage.Id, notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT);
            AlarmManager alarmManager = (AlarmManager) intent.getSystemService(intent.ALARM_SERVICE);
            alarmManager.cancel(pendingIntent);
        } catch (Exception e) {
            Log.d(TAG, e.getMessage());
        }
    }
}
