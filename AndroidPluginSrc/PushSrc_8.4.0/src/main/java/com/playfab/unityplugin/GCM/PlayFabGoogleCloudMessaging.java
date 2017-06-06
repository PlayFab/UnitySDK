package com.playfab.unityplugin.GCM;

import android.content.SharedPreferences;
import android.util.Log;

import com.google.android.gms.gcm.GcmPubSub;
import com.google.android.gms.gcm.GoogleCloudMessaging;
import com.google.android.gms.iid.InstanceID;
import com.unity3d.player.UnityPlayer;

import java.io.IOException;

/**
 * Used to communicate with the GCM service and obtain GCM tokens
 */
public class PlayFabGoogleCloudMessaging {
    // returns the push GCM token from google
    public static void getToken() {
        if (!PlayFabConst.hideLogs)
            Log.i(PlayFabConst.LOG_TAG, "PlayFab GCM Get token has been requested.");
        SharedPreferences sharedPreferences = null;
        try {
            sharedPreferences = PlayFabRegistrationIntentService.GetInstance().getPluginPreferences();
            // In the (unlikely) event that multiple refresh operations occur simultaneously,
            // ensure that they are processed sequentially.
            synchronized (PlayFabConst.LOG_TAG) {
                //Get Stored Sender Id in prefs.
                String senderId = sharedPreferences.getString(PlayFabConst.PROPERTY_SENDER_ID, "0");
                if (!PlayFabConst.hideLogs)
                    Log.i(PlayFabConst.LOG_TAG, "PlayFab GCM SenderID: " + senderId);
                //Get the InstanceID of Registration Intent Service and get the token.
                InstanceID instanceID = PlayFabRegistrationIntentService.GetInstanceId();
                String token = instanceID.getToken(senderId, GoogleCloudMessaging.INSTANCE_ID_SCOPE, null);

                //Send back to unity, with the token.
                sendRegistrationToServer(token);

                //Subscribe to any GCM topics of interest, as defined by the TOPICS constant.
                //subscribeTopics(token);

                //Google recommends to do this, but we probably don't have to.
                sharedPreferences.edit().putBoolean(PlayFabConst.SENT_TOKEN_TO_SERVER, true).apply();
            }
        } catch (Exception e) {
            Log.d(PlayFabConst.LOG_TAG, "Failed to complete token refresh", e);
            // If an exception happens while fetching the new token or updating our registration data
            // on a third-party server, this ensures that we'll attempt the update at a later time.
            if (sharedPreferences != null)
                sharedPreferences.edit().putBoolean(PlayFabConst.SENT_TOKEN_TO_SERVER, false).apply();
        }
    }

    /**
     * Persist registration to third-party servers.
     * <p>
     * Modify this method to associate the user's GCM registration token with any server-side account
     * maintained by your application.
     *
     * @param token The new token.
     */
    private static void sendRegistrationToServer(String token) {
        //Unity will be responsible for using the PlayFabClientAPI to send the token back to the PlayFab Servers.
        UnityPlayer.UnitySendMessage(PlayFabConst.UNITY_EVENT_OBJECT, "GCMRegistered", token);
    }

    /**
     * Subscribe to any GCM topics of interest, as defined by the TOPICS constant.
     *
     * @param token GCM token
     * @throws IOException if unable to reach the GCM PubSub service
     */
    // [START subscribe_topics]
    private static void subscribeTopics(String token) throws IOException {
        for (String topic : PlayFabConst.TOPICS) {
            GcmPubSub pubSub = GcmPubSub.getInstance(PlayFabRegistrationIntentService.GetInstance());
            pubSub.subscribe(token, "/topics/" + topic, null);
        }
    }
}
