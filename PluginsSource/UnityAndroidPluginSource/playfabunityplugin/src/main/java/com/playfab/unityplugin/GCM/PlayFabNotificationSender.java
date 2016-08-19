package com.playfab.unityplugin.GCM;

import android.app.AlarmManager;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.media.RingtoneManager;
import android.net.Uri;
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

/**
 * Created by Marco on 8/1/2016.
 */
public class PlayFabNotificationSender {
    private static final String TAG = "PlayFabGCM";
    private static final int REQUEST_CODE_UNITY_ACTIVITY = 1001;

    public static void sendNotification(Context intent) {
        //PlayFabRegistrationIntentService intent = PlayFabRegistrationIntentService.GetInstance();
        PendingIntent pendingIntent = PendingIntent.getActivity(intent, REQUEST_CODE_UNITY_ACTIVITY,
                intent.getPackageManager().getLaunchIntentForPackage(intent.getPackageName()),
                PendingIntent.FLAG_UPDATE_CURRENT);

        PlayFabNotificationPackage pushNotificationPackage = PlayFabPushCache.getPushCache();

        String appIcon = pushNotificationPackage.Icon;
        String title = pushNotificationPackage.Title;
        Uri defaultSoundUri = Uri.parse(pushNotificationPackage.Sound);
        String message = pushNotificationPackage.Message;

        NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(intent)
                .setSmallIcon(intent.getResources().getIdentifier(appIcon, "drawable", intent.getPackageName()))
                .setContentTitle(title)
                .setStyle(new NotificationCompat.BigTextStyle().bigText(message))
                .setContentText(message)
                .setSound(defaultSoundUri)
                .setPriority(NotificationCompat.PRIORITY_HIGH)
                .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
                .setAutoCancel(true)
                .setContentIntent(pendingIntent);

        NotificationManager notificationManager = (NotificationManager) intent.getSystemService(Context.NOTIFICATION_SERVICE);
        int notificationId = getNotificationId(intent);
        notificationManager.notify(notificationId, notificationBuilder.build()); //ID_NOTIFICATION
    }


    public static PlayFabNotificationPackage createNotificationPackage(Context intent, String message){
        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(intent);
        PlayFabNotificationPackage mPackage = new PlayFabNotificationPackage();
        mPackage.Title = sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_GAME_TITLE, "");
        mPackage.Icon = sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_APP_ICON, "app_icon");
        mPackage.Message = message;
        mPackage.Sound = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION).toString();

        if(isJSONValid(message)){
            try {
                JSONObject jObj = new JSONObject(message);
                Log.i(PlayFabUnityAndroidPlugin.TAG,"Message was JSON");
                //This is so that the ENTIRE JSON message is not in the notification should someone forget to send the "Message" attribute.
                mPackage.Message = "";

                if(jObj.has("ScheduledType")){
                    mPackage.ScheduleType = PlayFabNotificationPackage.ScheduleTypes.values()[jObj.getInt("ScheduledType")];
                    Log.i(TAG, "Schedule Detected: Type: " + mPackage.ScheduleType);
                    if(mPackage.ScheduleType == PlayFabNotificationPackage.ScheduleTypes.ScheduledDate) {
                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM/dd hh:mm:ss");
                        try {
                            mPackage.ScheduleDate = sdf.parse(jObj.getString("ScheduledDate"));
                        } catch (Exception e) {
                            mPackage.ScheduleType = PlayFabNotificationPackage.ScheduleTypes.None;
                            Log.i(TAG, "Scheduled Date could not be parsed, invalided format.");
                        }
                    }
                }

                if (jObj.has("Title")) {
                    mPackage.Title = jObj.getString("Title");
                }

                if(jObj.has("Message")){
                    mPackage.Message = jObj.getString("Message");
                }

                if(jObj.has("Icon")){
                    mPackage.Icon = jObj.getString("Icon");
                }

                if(jObj.has("Sound")){
                    mPackage.Sound = Uri.parse("android.resource://" + intent.getPackageName() + "/" + jObj.getString("Sound")).toString();
                }

                if(jObj.has("CustomData")){
                    mPackage.CustomData = jObj.getString("CustomData");
                }
            }catch(JSONException e){
                //Could not parse json. Shouldn't happen since we checked in the isJSONValid
            }
        }

        return mPackage;
    }

    public static void setNotificationPackage(Context intent, String message){
        //PlayFabRegistrationIntentService intent = PlayFabRegistrationIntentService.GetInstance();
        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(intent);
        PlayFabNotificationPackage mPackage = new PlayFabNotificationPackage();
        mPackage.Title = sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_GAME_TITLE, "");
        mPackage.Icon = sharedPreferences.getString(PlayFabUnityAndroidPlugin.PROPERTY_APP_ICON, "app_icon");
        mPackage.Message = message;
        mPackage.Sound = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION).toString();

        if(isJSONValid(message)){
            try {
                JSONObject jObj = new JSONObject(message);
                Log.i(PlayFabUnityAndroidPlugin.TAG,"Message was JSON");
                //This is so that the ENTIRE JSON message is not in the notification should someone forget to send the "Message" attribute.
                mPackage.Message = "";

                if(jObj.has("ScheduledType")){
                    mPackage.ScheduleType = PlayFabNotificationPackage.ScheduleTypes.values()[jObj.getInt("ScheduleType")];
                    if(mPackage.ScheduleType == PlayFabNotificationPackage.ScheduleTypes.ScheduledDate) {
                        SimpleDateFormat sdf = new SimpleDateFormat("dd-M-yyyy hh:mm:ss");
                        try {
                            mPackage.ScheduleDate = sdf.parse(jObj.getString("ScheduleDate"));
                        } catch (Exception e) {
                            mPackage.ScheduleType = PlayFabNotificationPackage.ScheduleTypes.None;
                            Log.i(TAG, "Scheduled Date could not be parsed, invalided format.");
                        }
                    }
                }

                if (jObj.has("Title")) {
                    mPackage.Title = jObj.getString("Title");
                }

                if(jObj.has("Message")){
                    mPackage.Message = jObj.getString("Message");
                }

                if(jObj.has("Icon")){
                    mPackage.Icon = jObj.getString("Icon");
                }

                if(jObj.has("Sound")){
                    mPackage.Sound = Uri.parse("android.resource://" + intent.getPackageName() + "/" + jObj.getString("Sound")).toString();
                }

                if(jObj.has("CustomData")){
                    mPackage.CustomData = jObj.getString("CustomData");
                }
            }catch(JSONException e){
                //Could not parse json. Shouldn't happen since we checked in the isJSONValid
            }
        }

        PlayFabPushCache.setPushCache(mPackage);
    }

    public static synchronized int getNotificationId(Context intent) {
        SharedPreferences prefs = PreferenceManager.getDefaultSharedPreferences(intent);
        int id = 1;
        int nextId = 1;
        if(prefs.contains(PlayFabGcmListenerService.PROPERTY_NOTIFICATION_ID)) {
            id = prefs.getInt(PlayFabGcmListenerService.PROPERTY_NOTIFICATION_ID, 1);
            nextId = id + 1;
        }
        SharedPreferences.Editor editor = prefs.edit();
        editor.putInt(PlayFabGcmListenerService.PROPERTY_NOTIFICATION_ID, nextId);
        editor.commit();
        return id;
    }

    private static boolean isJSONValid(String test) {
        try {
            new JSONObject(test);
        } catch (JSONException ex) {
            // edited, to include @Arthur's comment
            // e.g. in case JSONArray is valid as well...
            Log.i(PlayFabUnityAndroidPlugin.TAG,"Could not parse to JSONObject");
            try {
                new JSONArray(test);
            } catch (JSONException ex1) {
                Log.i(PlayFabUnityAndroidPlugin.TAG,"Could not parse to JSONArray");
                return false;
            }
        }
        return true;
    }

    public static void Send(Context intent, PlayFabNotificationPackage notifyPackage ){
        Intent notificationIntent = new Intent(intent, NotificationPublisher.class);
        notificationIntent.putExtra(NotificationPublisher.NOTIFICATION, notifyPackage);

        PendingIntent pendingIntent = PendingIntent.getBroadcast(intent, 0,
                notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT );

        try {
            if(notifyPackage.ScheduleType == PlayFabNotificationPackage.ScheduleTypes.ScheduledDate){
                ScheduleNotification(intent,  notifyPackage.ScheduleDate, notifyPackage);
            }else {
                long futureMillis = 0;
                AlarmManager alarmManager = (AlarmManager) intent.getSystemService(intent.ALARM_SERVICE);
                alarmManager.set(AlarmManager.ELAPSED_REALTIME_WAKEUP, futureMillis, pendingIntent);
            }
        }catch (Exception e){
            Log.d(TAG, e.getMessage());
        }

    }

    public static void ScheduleNotification(Context intent, Date date, PlayFabNotificationPackage notifyPackage ){
        Log.i(TAG,"Scheduling future notification");
        Intent notificationIntent = new Intent(intent, NotificationPublisher.class);

        notificationIntent.putExtra(NotificationPublisher.NOTIFICATION, notifyPackage);

        PendingIntent pendingIntent = PendingIntent.getBroadcast(intent, 0,
                notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT );
        try{
            Calendar c = Calendar.getInstance();
            c.setTime(date);
            long futureMillis = c.getTimeInMillis();
            AlarmManager alarmManager = (AlarmManager)intent.getSystemService(intent.ALARM_SERVICE);
            alarmManager.set(AlarmManager.RTC_WAKEUP, futureMillis, pendingIntent);
            Log.i(TAG, "Alarm was set to: " + date.toString() + " : " + futureMillis);
        }catch(Exception e){
            Log.d(TAG, e.getMessage());
        }
    }

    public static void CancelScheduledNotification(Context intent, PlayFabNotificationPackage notifyPackage){
        Intent notificationIntent = new Intent(intent, NotificationPublisher.class);
        notificationIntent.putExtra(NotificationPublisher.NOTIFICATION, notifyPackage);
        PendingIntent pendingIntent = PendingIntent.getBroadcast(intent, PlayFabNotificationSender.getNotificationId(intent),
                notificationIntent, PendingIntent.FLAG_UPDATE_CURRENT );

        try{
            AlarmManager alarmManager = (AlarmManager)intent.getSystemService(intent.ALARM_SERVICE);
            alarmManager.cancel(pendingIntent);
        }catch(Exception e){
            Log.d(TAG, e.getMessage());
        }
    }

}
