package com.playfab.unityplugin;
import android.util.Log;
import com.google.firebase.iid.*;

/**
 * Created by Marco on 8/1/2016.
 */
public class PlayFabFirebaseInstanceIdService extends FirebaseInstanceIdService {
    private final static String TAG = "PFFirebaseIID";

    @Override
    public void onTokenRefresh() {
        // Get updated InstanceID token.
        String refreshedToken = FirebaseInstanceId.getInstance().getToken();
        Log.d(TAG, "Refreshed token: " + refreshedToken);

        // If you want to send messages to this application instance or
        // manage this apps subscriptions on the server side, send the
        // Instance ID token to your app server.
        PlayFabFirebaseMessagingService.sendRegistrationToServer(refreshedToken);
    }

}
