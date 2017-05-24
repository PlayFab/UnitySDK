package com.playfab.unityplugin.GCM;

import android.os.Parcel;
import android.os.Parcelable;
import android.util.Log;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.TimeZone;
import java.util.GregorianCalendar;

/**
 * Custom class that maps to the strigified json message sent by push notifications
 */
public class PlayFabNotificationPackage implements Parcelable {
    public static final String ScheduleTypeNone = "None";
    public static final String ScheduleTypeScheduledUtc = "ScheduledUtc";
    public static final String ScheduleTypeScheduledLocal = "ScheduledLocal";

    public static boolean hideLogs = false;
    public static final String DATE_LOCAL_FORMAT = "yyyy-MM-dd HH:mm:ss";
    public static final String DATE_UTC_FORMAT = "yyyy-MM-ddTHH:mm:ssZ"; // Supported in the PlayFab interface, but not by Java (unused: if it matches DATE_UTC_FORMAT, this plugin explicitly converts to DATE_LOCAL_FORMAT and accounts for the offset)

    public Date ScheduleDate;
    public String ScheduleType = ScheduleTypeNone;
    public String Sound;                // do not set this to use the default device sound; otherwise the sound you provide needs to exist in Android/res/raw/_____.mp3, .wav, .ogg
    public String Title;                // title of this message
    public String Icon;                 // to use the default app icon use app_icon, otherwise send the name of the custom image. Image must be in Android/res/drawable/_____.png, .jpg
    public String Message;              // the actual message to transmit (this is what will be displayed in the notification area
    public String CustomData;           // arbitrary key value pairs for game specific usage
    public int Id = 0;
    public boolean Delivered;

    public PlayFabNotificationPackage() {
    }

    public PlayFabNotificationPackage(Parcel in) {
        String[] data = new String[5];
        in.readStringArray(data);
        this.Sound = data[0];
        this.Title = data[1];
        this.Icon = data[2];
        SetMessage(data[3], 0);
        this.CustomData = data[4];
        this.Delivered = false;
    }

    @Override
    public int describeContents() {
        return Id;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeStringArray(new String[]{
                this.Sound,
                this.Title,
                this.Icon,
                this.Message,
                this.CustomData
        });
    }

    public void SetMessage(String message, int id) {
        this.Message = message;
        this.Id = (id == 0) ? message.hashCode() : id;
        // if (!hideLogs)
        Log.i(PlayFabNotificationSender.TAG, "Setting message and id, Message: " + this.Message + ", Id: " + this.Id);
    }

    public void ClearScheduleDate() {
        ScheduleType = PlayFabNotificationPackage.ScheduleTypeNone;
        ScheduleDate = new Date();
    }

    public static long getUtcOffset() {
        TimeZone tz1 = TimeZone.getTimeZone("UTC");
        TimeZone tz2 = TimeZone.getDefault();
        return tz1.getRawOffset() - tz2.getRawOffset() + tz1.getDSTSavings() - tz2.getDSTSavings();
    }

    public void SetScheduleDate(String dateString) {
        if (!hideLogs)
            Log.i(PlayFabNotificationSender.TAG, "SetScheduleDate dateString: " + dateString);

        if (dateString == null)
        {
            ScheduleType = ScheduleTypeNone;
            ScheduleDate = new Date();
            return;
        }

        boolean isUtc = dateString.endsWith("Z");
        ScheduleType = isUtc ? ScheduleTypeScheduledUtc : ScheduleTypeScheduledLocal;
        Calendar c = Calendar.getInstance();
        long offset = 0;
        String dateFormat;
        if (isUtc) {
            dateString = dateString.substring(0, dateString.length() - 1).replace("T", " ");
            offset = getUtcOffset();
        }

        SimpleDateFormat sdf = new SimpleDateFormat(DATE_LOCAL_FORMAT);
        try {
            Date parsedDate = new Date(sdf.parse(dateString).getTime() - offset);
            c.setTime(parsedDate);
            long futureMillis = c.getTimeInMillis();
            long nowMillis = System.currentTimeMillis();
            if (futureMillis <= nowMillis) {
                ScheduleDate = parsedDate;
            } else {
                if (!hideLogs)
                    Log.i(PlayFabNotificationSender.TAG, "SetScheduleDate Id: " + this.Id + ", delayMillis: " + (futureMillis - nowMillis) + ", input:" + dateString);
                ScheduleDate = parsedDate;
            }
        } catch (Exception e) {
            ScheduleType = PlayFabNotificationPackage.ScheduleTypeNone;
            ScheduleDate = new Date();
            if (!hideLogs)
                Log.i(PlayFabNotificationSender.TAG, "Could not parse date. Expected: " + DATE_LOCAL_FORMAT + ", Actual: " + dateString);
        }
    }

    public String GetScheduleDate() {
        SimpleDateFormat sdf = new SimpleDateFormat(DATE_LOCAL_FORMAT);
        switch (ScheduleType) {
            case ScheduleTypeScheduledLocal:
                return sdf.format(ScheduleDate);
            case ScheduleTypeScheduledUtc:
                return sdf.format(new Date(ScheduleDate.getTime() + getUtcOffset())).replace(" ", "T") + "Z";
            case ScheduleTypeNone:
                return null;
            default:
                throw new IllegalArgumentException("Invalid ScheduleType: " + ScheduleType);
        }
    }

    public long GetMsgDelayInMillis() {
        if (ScheduleType == ScheduleTypeNone)
            return 0;

        Calendar c = Calendar.getInstance(TimeZone.getTimeZone("UTC"));
        c.setTime(ScheduleDate);
        long futureMillis = c.getTimeInMillis();
        long nowMillis = System.currentTimeMillis();
        return Math.max(futureMillis - nowMillis, 0);
    }

    public static final Parcelable.Creator CREATOR = new Parcelable.Creator() {
        public PlayFabNotificationPackage createFromParcel(Parcel in) {
            return new PlayFabNotificationPackage(in);
        }

        public PlayFabNotificationPackage[] newArray(int size) {
            return new PlayFabNotificationPackage[size];
        }
    };
}
