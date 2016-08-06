package com.playfab.unityplugin;

/**
 * Created by Marco on 9/16/2015.
 */

/*
  * a container class that holds the data from the last push notification received by the device
*/
public class PlayFabPushCache {
    private static PlayFabNotificationPackage mPushCache;

    public static void setPushCache(PlayFabNotificationPackage notification){
        mPushCache = notification;
    }

    // returns the entire push cache
    public static PlayFabNotificationPackage getPushCache(){
        return mPushCache == null ? null : mPushCache;
    }

    // returns only the custom data portion of the cache
    public static String getPushCacheData(){
        return mPushCache == null ? null : mPushCache.CustomData;
    }

}

