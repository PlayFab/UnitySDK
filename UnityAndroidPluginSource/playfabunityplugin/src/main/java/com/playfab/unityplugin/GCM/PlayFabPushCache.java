package com.playfab.unityplugin.GCM;

/**
 * Created by Marco on 9/16/2015.
 */
public class PlayFabPushCache {
    private static PlayFabNotificationPackage mPushCache;

    public static void setPushCache(PlayFabNotificationPackage notification){
        mPushCache = notification;
    }

    public static PlayFabNotificationPackage getPushCache(){
        return mPushCache;
    }

    public static String getPushCacheData(){
        return mPushCache.CustomData;
    }

}

