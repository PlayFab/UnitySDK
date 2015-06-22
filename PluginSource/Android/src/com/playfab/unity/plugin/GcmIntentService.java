package com.playfab.unity.plugin;

import org.json.JSONObject;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerProxyActivity;

import android.app.IntentService;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.media.RingtoneManager;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.NotificationCompat;
import android.util.Log;

public class GcmIntentService extends IntentService {
    
    private NotificationManager mNotificationManager;
    NotificationCompat.Builder builder;

    private static final int REQUEST_CODE_UNITY_ACTIVITY = 1001;
    
    public GcmIntentService() {
        super("GcmIntentService");
    }

    @Override
    protected void onHandleIntent(Intent intent) {
        Bundle extras = intent.getExtras();
        com.google.android.gms.gcm.GoogleCloudMessaging gcm = com.google.android.gms.gcm.GoogleCloudMessaging.getInstance(this);
        // The getMessageType() intent parameter must be the intent you received
        // in your BroadcastReceiver.
        String messageType = gcm.getMessageType(intent);
        
        if (!extras.isEmpty()) {  // has effect of unparcelling Bundle
            /*
             * Filter messages based on message type. Since it is likely that GCM
             * will be extended in the future with new message types, just ignore
             * any message types you're not interested in, or that you don't
             * recognize.
             */
            if (com.google.android.gms.gcm.GoogleCloudMessaging.MESSAGE_TYPE_SEND_ERROR.equals(messageType)) {
                //sendNotification("Send error: " + extras.toString());
            } else if (com.google.android.gms.gcm.GoogleCloudMessaging.MESSAGE_TYPE_DELETED.equals(messageType)) {
                //sendNotification("Deleted messages on server: " + extras.toString());
            
            } else if (com.google.android.gms.gcm.GoogleCloudMessaging.MESSAGE_TYPE_MESSAGE.equals(messageType)) {
                // Post notification of received message.
            	Log.i(AndroidPlugin.TAG, "Received: " + extras.toString());
            	String defaultMessage = extras.getString("default");
            	String subject = "Notification";
            	int notificationId = AndroidPlugin.getNotificationId();
            	sendNotification(notificationId, subject, defaultMessage);
            	String encodedMessage = null;
            	try
            	{
	            	JSONObject encoder = new JSONObject();
	            	encoder.put("id", notificationId);
	            	encoder.put("message", defaultMessage);
	            	encodedMessage = encoder.toString();
            	}
            	catch(Exception e)
            	{
            		Log.e(AndroidPlugin.TAG, "Error encoding GCM into json ", e);
            	}
            	try
            	{
            		if(encodedMessage != null)
            			UnityPlayer.UnitySendMessage(AndroidPlugin.UNITY_EVENT_OBJECT, "GCMMessageReceived", defaultMessage);
            	}
            	catch(Exception e)
            	{
            		Log.i(AndroidPlugin.TAG, "Did not forward to unity since it was not running");
            	}
            }
        }
        // Release the wake lock provided by the WakefulBroadcastReceiver.
        GcmBroadcastReceiver.completeWakefulIntent(intent);
    }

    // Put the message into a notification and post it.
    // This is just one simple example of what you might choose to do with
    // a GCM message.
    private void sendNotification(int id, String title, String msg) {
    	
        mNotificationManager = (NotificationManager)
                this.getSystemService(Context.NOTIFICATION_SERVICE);

        PendingIntent contentIntent = PendingIntent.getActivity(this, REQUEST_CODE_UNITY_ACTIVITY,
                new Intent(this, UnityPlayerProxyActivity.class), PendingIntent.FLAG_UPDATE_CURRENT);
        
        Uri alarmSound = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);
        
        NotificationCompat.Builder mBuilder =
                new NotificationCompat.Builder(this)
        .setSmallIcon(AndroidPlugin.APP_ICON)
        .setContentTitle(title)
        .setStyle(new NotificationCompat.BigTextStyle()
        .bigText(msg))
        .setContentText(msg)
        .setSound(alarmSound)
        .setPriority(NotificationCompat.PRIORITY_HIGH)
        .setVisibility(NotificationCompat.VISIBILITY_PUBLIC);

        mBuilder.setContentIntent(contentIntent);
        mNotificationManager.notify(id, mBuilder.build());
    }
}