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

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Random;

/**
 * Created by Marco on 8/1/2016.
 */
public class PlayFabNotificationSender {
    private static final String TAG = "PlayFabGCM";
    private static final int REQUEST_CODE_UNITY_ACTIVITY = 1001;
    private static final String DATE_FORMAT_STRING = "MM-dd-yyyy HH:mm:ss";

    public static void sendNotificationById(Context intent, int id) {
        PendingIntent pendingIntent = PendingIntent.getActivity(intent, REQUEST_CODE_UNITY_ACTIVITY,
                intent.getPackageManager().getLaunchIntentForPackage(intent.getPackageName()),
                PendingIntent.FLAG_UPDATE_CURRENT);

        List<PlayFabNotificationPackage> notificationList = PlayFabPushCache.getPushCache();
        PlayFabNotificationPackage pushNotificationPackage = null;
        for (PlayFabNotificationPackage p : notificationList) {
            if (p.Id == id) {
                pushNotificationPackage = p;
            }
        }
        if (pushNotificationPackage == null) {
            Log.i(TAG, "Push Notification Package not found.");
            return;
        }

        String appIcon = pushNotificationPackage.Icon;
        //Log.i(TAG,"Setting App Icon: " + appIcon); //Intentionally commented for debug purpose.
        //Log.i(TAG,"Setting Title: " + pushNotificationPackage.Title); //Intentionally commented for debug purpose.
        Uri defaultSoundUri = Uri.parse(pushNotificationPackage.Sound);
        //Log.i(TAG,"Setting Sound Uri: " + defaultSoundUri); //Intentionally commented for debug purpose.

        NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(intent);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
            notificationBuilder.setSmallIcon(intent.getResources().getIdentifier(appIcon + "_transparent", "drawable", intent.getPackageName()));
        } else {
            notificationBuilder.setSmallIcon(intent.getResources().getIdentifier(appIcon, "drawable", intent.getPackageName()));
        }
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
            Bitmap icon = BitmapFactory.decodeResource(intent.getResources(), intent.getResources().getIdentifier(appIcon, "drawable", intent.getPackageName()));
            notificationBuilder.setLargeIcon(icon);
        }
        notificationBuilder.setContentTitle(pushNotificationPackage.Title)
                .setStyle(new NotificationCompat.BigTextStyle().bigText(pushNotificationPackage.Message))
                .setContentText(pushNotificationPackage.Message)
                .setSound(defaultSoundUri)
                .setPriority(NotificationCompat.PRIORITY_HIGH)
                .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
                .setAutoCancel(true)
                .setContentIntent(pendingIntent);

        NotificationManager notificationManager = (NotificationManager) intent.getSystemService(Context.NOTIFICATION_SERVICE);
        notificationManager.notify(pushNotificationPackage.Id, notificationBuilder.build()); //ID_NOTIFICATION
        pushNotificationPackage.SetDelivered();
    }

    public static void sendNotification(Context intent) {
        PendingIntent pendingIntent = PendingIntent.getActivity(intent, REQUEST_CODE_UNITY_ACTIVITY,
                intent.getPackageManager().getLaunchIntentForPackage(intent.getPackageName()),
                PendingIntent.FLAG_UPDATE_CURRENT);

        List<PlayFabNotificationPackage> notificationList = PlayFabPushCache.getPushCache();
        PlayFabNotificationPackage pushNotificationPackage = notificationList.get(notificationList.size() - 1);

        String appIcon = pushNotificationPackage.Icon;
        Uri defaultSoundUri = Uri.parse(pushNotificationPackage.Sound);

        NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(intent)
                .setSmallIcon(intent.getResources().getIdentifier(appIcon, "drawable", intent.getPackageName()))
                .setContentTitle(pushNotificationPackage.Title)
                .setStyle(new NotificationCompat.BigTextStyle().bigText(pushNotificationPackage.Message))
                .setContentText(pushNotificationPackage.Message)
                .setSound(defaultSoundUri)
                .setPriority(NotificationCompat.PRIORITY_HIGH)
                .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
                .setAutoCancel(true)
                .setContentIntent(pendingIntent);

        NotificationManager notificationManager = (NotificationManager) intent.getSystemService(Context.NOTIFICATION_SERVICE);
        notificationManager.notify(pushNotificationPackage.Id, notificationBuilder.build()); //ID_NOTIFICATION
        pushNotificationPackage.SetDelivered();
    }

    public static PlayFabNotificationPackage createNotificationPackage(Context intent, String message) {
        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(intent);
        PlayFabNotificationPackage mPackage = new PlayFabNotificationPackage();
        mPackage.Title = sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_GAME_TITLE, "");
        mPackage.Icon = sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_APP_ICON, "app_icon");
        mPackage.SetMessage(message);
        mPackage.Sound = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION).toString();

        //Log.i(TAG, mPackage.Sound); //Intentionally commented for debug purpose.
        //Log.i(TAG, mPackage.Icon); //Intentionally commented for debug purpose.

        SetPackageFromJson(intent, message, mPackage);
        return mPackage;
    }

    public static void setNotificationPackage(Context intent, String message) {
        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(intent);
        PlayFabNotificationPackage mPackage = new PlayFabNotificationPackage();
        mPackage.Title = sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_GAME_TITLE, "");
        mPackage.Icon = sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_APP_ICON, "app_icon");
        mPackage.SetMessage(message);
        mPackage.Sound = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION).toString();

        SetPackageFromJson(intent, message, mPackage);
        PlayFabPushCache.setPushCache(mPackage);
    }

    private static void SetPackageFromJson(Context intent, String message, PlayFabNotificationPackage mPackage) {
        if (isJSONValid(message)) {
            try {
                JSONObject jObj = new JSONObject(message);
                //Log.i(TAG,message); //Intentionally commented for debug purpose.
                Log.i(PlayFabUnityAndroidPlugin.TAG, "Message was JSON");
                //This is so that the ENTIRE JSON message is not in the notification should someone forget to send the "Message" attribute.
                mPackage.SetMessage("");

                if (jObj.has("ScheduleType") && jObj.getInt("ScheduleType") > 0) {
                    mPackage.ScheduleType = PlayFabNotificationPackage.ScheduleTypes.values()[jObj.getInt("ScheduleType")];
                }

                if (jObj.has("ScheduleDate")) {
                    try {
                        SimpleDateFormat sdf = new SimpleDateFormat(DATE_FORMAT_STRING);
                        Date date = sdf.parse(jObj.getString("ScheduleDate"));
                        Calendar c = Calendar.getInstance();
                        c.setTime(date);
                        long futureMillis = c.getTimeInMillis();
                        long nowMillis = System.currentTimeMillis();
                        if (futureMillis < nowMillis) {
                            mPackage.ScheduleType = PlayFabNotificationPackage.ScheduleTypes.None;
                            mPackage.ScheduleDate = new Date();
                        } else {
                            mPackage.ScheduleDate = date;
                        }
                    } catch (Exception e) {
                        Log.i(TAG, "Could not parse date time from Push Notification: use format: " + DATE_FORMAT_STRING);
                    }
                }

                if (jObj.has("Title")) {
                    mPackage.Title = jObj.getString("Title");
                }

                if (jObj.has("Message")) {
                    mPackage.SetMessage(jObj.getString("Message"));
                }

                if (jObj.has("Icon") && jObj.getString("Icon") != null && !jObj.getString("Icon").isEmpty() && jObj.getString("Icon") != "null") {
                    //Log.i(TAG,jObj.getString("Icon"));
                    mPackage.Icon = jObj.getString("Icon");
                }

                if (jObj.has("Sound") && jObj.getString("Sound") != null && !jObj.getString("Sound").isEmpty() && jObj.getString("Sound") != "null") {
                    //Log.i(TAG,jObj.getString("Sound"));
                    mPackage.Sound = Uri.parse("android.resource://" + intent.getPackageName() + "/" + jObj.getString("Sound")).toString();
                }

                if (jObj.has("CustomData") && jObj.getString("CustomData") != null && !jObj.getString("CustomData").isEmpty() && jObj.getString("CustomData") != "null") {
                    mPackage.CustomData = jObj.getString("CustomData");
                }
            } catch (JSONException e) {
                //Could not parse json. Shouldn't happen since we checked in the isJSONValid
            }
        }
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
        Intent notificationIntent = new Intent(intent, NotificationPublisher.class);

        byte[] bytes = ParcelableUtil.marshall(notifyPackage);
        notificationIntent.putExtra(NotificationPublisher.NOTIFICATION, bytes);

        PendingIntent pendingIntent = PendingIntent.getBroadcast(intent, notifyPackage.Id,
                notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT);
        try {
            Log.i(TAG, "Schedule Type: " + notifyPackage.ScheduleType);
            if (notifyPackage.ScheduleType == PlayFabNotificationPackage.ScheduleTypes.ScheduledDate) {
                String formattedDate = new SimpleDateFormat(DATE_FORMAT_STRING).format(notifyPackage.ScheduleDate);
                ScheduleNotification(intent, formattedDate, notifyPackage);
            } else {
                long futureMillis = 0;
                AlarmManager alarmManager = (AlarmManager) intent.getSystemService(intent.ALARM_SERVICE);
                alarmManager.set(AlarmManager.ELAPSED_REALTIME_WAKEUP, futureMillis, pendingIntent);
            }
        } catch (Exception e) {
            Log.d(TAG, e.getMessage());
        }

    }

    public static void ScheduleNotification(Context intent, String dateString, PlayFabNotificationPackage notifyPackage) {
        Log.i(TAG, "Scheduling future notification");
        try {
            Intent notificationIntent = new Intent(intent, NotificationPublisher.class);
            byte[] bytes = ParcelableUtil.marshall(notifyPackage);
            notificationIntent.putExtra(NotificationPublisher.NOTIFICATION, bytes);

            SimpleDateFormat sdf = new SimpleDateFormat(DATE_FORMAT_STRING);
            Date date = sdf.parse(dateString);

            Calendar c = Calendar.getInstance();
            c.setTime(date);
            long futureMillis = c.getTimeInMillis();
            long nowMillis = System.currentTimeMillis();

            PendingIntent pendingIntent = PendingIntent.getBroadcast(intent, notifyPackage.Id, notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT);
            AlarmManager alarmManager = (AlarmManager) intent.getSystemService(intent.ALARM_SERVICE);
            alarmManager.set(AlarmManager.RTC_WAKEUP, futureMillis, pendingIntent);
            Log.i(TAG, "Alarm was set to: " + date.toString() + " : future - " + futureMillis + ": now - " + nowMillis);
        } catch (Exception e) {
            Log.d(TAG, e.getMessage());
        }
    }

    public static void CancelScheduledNotification(Context intent, PlayFabNotificationPackage notifyPackage) {
        try {
            Intent notificationIntent = new Intent(intent, NotificationPublisher.class);
            notificationIntent.putExtra(NotificationPublisher.NOTIFICATION, notifyPackage);
            PendingIntent pendingIntent = PendingIntent.getBroadcast(intent, notifyPackage.Id, notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT);
            AlarmManager alarmManager = (AlarmManager) intent.getSystemService(intent.ALARM_SERVICE);
            alarmManager.cancel(pendingIntent);
        } catch (Exception e) {
            Log.d(TAG, e.getMessage());
        }
    }
}
