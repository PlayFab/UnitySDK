package com.playfab.unityplugin.GCM;

public class PlayFabConst {
    public static final String LOG_TAG = "PlayFabGCM";
    public static final int REQUEST_CODE_UNITY_ACTIVITY = 1001;
    public static final int PLAY_SERVICES_RESOLUTION_REQUEST = 9000;
    public static String NOTIFICATION_JSON = "NOTIFICATION_JSON";
    public static final String[] TOPICS = {"global"};

    public static final String ScheduleTypeNone = "None";
    public static final String ScheduleTypeScheduledUtc = "ScheduledUtc";
    public static final String ScheduleTypeScheduledLocal = "ScheduledLocal";

    public static boolean hideLogs = false; // Only used in a couple places
    public static final String DATE_LOCAL_FORMAT = "yyyy-MM-dd HH:mm:ss";
    public static final String DATE_UTC_FORMAT = "yyyy-MM-ddTHH:mm:ssZ"; // Supported in the PlayFab interface, but not by Java (unused: if it matches DATE_UTC_FORMAT, this plugin explicitly converts to DATE_LOCAL_FORMAT and accounts for the offset)
}
