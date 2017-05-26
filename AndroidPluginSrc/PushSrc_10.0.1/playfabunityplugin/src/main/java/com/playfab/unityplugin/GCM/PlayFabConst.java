package com.playfab.unityplugin.GCM;

public class PlayFabConst {
    public static final String LOG_TAG = "PlayFabGCM";
    public static final int REQUEST_CODE_UNITY_ACTIVITY = 1001;
    public static final int PLAY_SERVICES_RESOLUTION_REQUEST = 9000;
    public static String NOTIFICATION_JSON = "NOTIFICATION_JSON";
    public static final String[] TOPICS = {"global"};

    public static final String UNITY_EVENT_OBJECT = "_PlayFabGO";
    public static final String PROPERTY_GAME_TITLE = "_PlayFab_GameTitle";
    public static final String PROPERTY_APP_ICON = "_PlayFab_AppIcon";
    public static final String PROPERTY_SENDER_ID = "_PlayFab_SenderID";
    public static final String SENT_TOKEN_TO_SERVER = "sentTokenToServer";

    public static final String ScheduleTypeNone = "None";
    public static final String ScheduleTypeScheduledUtc = "ScheduledUtc";
    public static final String ScheduleTypeScheduledLocal = "ScheduledLocal";

    public static final String DATE_LOCAL_FORMAT = "yyyy-MM-dd HH:mm:ss";
    public static final String DATE_UTC_FORMAT = "yyyy-MM-ddTHH:mm:ssZ"; // Supported in the PlayFab interface, but not by Java (unused: if it matches DATE_UTC_FORMAT, this plugin explicitly converts to DATE_LOCAL_FORMAT and accounts for the offset)

    // Can be reset, but tends to be a consistent value
    public static boolean hideLogs = true; // Not used consistently yet
    public static boolean AlwaysShowOnNotificationBar = true;
}
