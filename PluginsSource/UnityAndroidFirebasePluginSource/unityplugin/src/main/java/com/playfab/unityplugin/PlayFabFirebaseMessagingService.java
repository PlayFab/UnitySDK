package com.playfab.unityplugin;
import android.util.Log;

import com.google.firebase.messaging.*;
import com.google.firebase.iid.FirebaseInstanceId;
import com.unity3d.player.UnityPlayer;

/**
 * Created by Marco on 8/1/2016.
 */
public class PlayFabFirebaseMessagingService extends FirebaseMessagingService  {
    public static final String TAG = "PlayFabFCM";
    private static final String[] TOPICS = {"/topics/global"};  //Should we pass this in?
    private static String UNITY_EVENT_OBJECT = "_PlayFabGO";
    private static final int REQUEST_CODE_UNITY_ACTIVITY = 1001;
    public static final String PROPERTY_NOTIFICATION_ID = "_PlayFab_notificationId";

    public static void getToken() {
        Log.i(TAG,"PlayFab GCM Get token has been requested.");

        try{

            synchronized (TAG){
                String token = FirebaseInstanceId.getInstance().getToken();
                sendRegistrationToServer(token);
                subscribeToTopics(TOPICS);
            }

        }catch (Exception e){
            Log.d(TAG, "Failed to complete token refresh", e);
        }

    }

    public static void subscribeToTopics(String[] topics){
        for(String topic : topics){
            Log.i(TAG, "Subscribing to Topic: " + topic);
            FirebaseMessaging.getInstance().subscribeToTopic(topic);
        }
    }

    public static void sendRegistrationToServer(String token) {
        //Unity will be responsible for using the PlayFabClientAPI to send the token back to the PlayFab Servers.
        UnityPlayer.UnitySendMessage(UNITY_EVENT_OBJECT, "GCMRegistered", token);
    }

    @Override
    public void onMessageReceived(RemoteMessage remoteMessage) {
        Log.d(TAG, "From: " + remoteMessage.getFrom());
    }



}
