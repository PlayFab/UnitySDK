package com.playfab.unityplugin.GCM;

import android.net.Uri;

/**
 * Created by Marco on 9/16/2015.
 */

/**
 * Custom class that maps to the strigified json message sent by push notifications
*/
public class PlayFabNotificationPackage {
    public String Sound;                   // do not set this to use the default device sound; otherwise the sound you provide needs to exist in Android/res/raw/_____.mp3, .wav, .ogg
    public String Title;                // title of this message
    public String Icon;                 // to use the default app icon use app_icon, otherwise send the name of the custom image. Image must be in Android/res/drawable/_____.png, .jpg
    public String Message;              // the actual message to transmit (this is what will be displayed in the notification area
    public String CustomData;           // arbitrary key value pairs for game specific usage
}
