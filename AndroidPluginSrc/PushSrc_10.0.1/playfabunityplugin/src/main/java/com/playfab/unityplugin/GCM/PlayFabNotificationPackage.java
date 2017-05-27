package com.playfab.unityplugin.GCM;

import android.os.Parcel;
import android.os.Parcelable;
import android.util.Log;

import org.json.JSONException;
import org.json.JSONObject;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.TimeZone;

/**
 * Custom class that maps to the strigified json message sent by push notifications
 */
public class PlayFabNotificationPackage implements Parcelable {
    public String ScheduleDate;
    public String ScheduleType = PlayFabConst.ScheduleTypeNone;
    public String Sound;                // do not set this to use the default device sound; otherwise the sound you provide needs to exist in Android/res/raw/_____.mp3, .wav, .ogg
    public String Title;                // title of this message
    public String Icon;                 // to use the default app icon use app_icon, otherwise send the name of the custom image. Image must be in Android/res/drawable/_____.png, .jpg
    public String Message;              // the actual message to transmit (this is what will be displayed in the notification area
    public String CustomData;           // arbitrary key value pairs for game specific usage
    public int Id = 0;

    public PlayFabNotificationPackage() {
    }

    public PlayFabNotificationPackage(Parcel in) {
        String[] data = new String[8];
        in.readStringArray(data);
        this.Sound = data[0];
        this.Title = data[1];
        this.Icon = data[2];
        this.CustomData = data[3];
        this.ScheduleDate = data[4];
        this.ScheduleType = data[5];
        setMessage(data[6], Integer.parseInt(data[7]));

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
                this.CustomData,
                this.ScheduleDate,
                this.ScheduleType,
                this.Message,
                Integer.toString(this.Id)
        });
    }

    public String toJson() {
        // This makes me sad, because I can't find a better option without taking on other huge dependencies:
        return "{"
                + "\"ScheduleDate\": " + stringFieldToJson(ScheduleDate) + ", "
                + "\"ScheduleType\": " + stringFieldToJson(ScheduleType) + ", "
                + "\"Sound\": " + stringFieldToJson(Sound) + ", "
                + "\"Title\": " + stringFieldToJson(Title) + ", "
                + "\"Icon\": " + stringFieldToJson(Icon) + ", "
                + "\"Message\": " + stringFieldToJson(Message) + ", "
                + "\"CustomData\": " + stringFieldToJson(CustomData) + ", "
                + "\"Id\": " + Id + "}";
    }

    private String stringFieldToJson(String field) {
        if (field == null)
            return "null";
        return "\"" + field + "\"";
    }

    public static PlayFabNotificationPackage fromJson(String json) {
        PlayFabNotificationPackage output = null;
        try {
            JSONObject jObj = new JSONObject(json);
            output = new PlayFabNotificationPackage();

            String message = getJsonStringField(jObj, "Message");
            int id = 0;
            if (jObj.has("Id"))
                id = jObj.getInt("Id");
            output.setMessage(message, id);

            output.setScheduleDate(getJsonStringField(jObj, "ScheduleDate"));
            output.Title = getJsonStringField(jObj, "Title");
            output.Icon = getJsonStringField(jObj, "Icon");
            output.Sound = getJsonStringField(jObj, "Sound");
            output.CustomData = getJsonStringField(jObj, "CustomData");
        } catch (Exception e) {
            Log.e(PlayFabConst.LOG_TAG, e.getMessage());
            return null;
        }
        return output;
    }

    private static String getJsonStringField(JSONObject jObj, String fieldName) {
        String fieldValue = null;
        try {
            fieldValue = jObj.getString(fieldName);
        } catch (JSONException e) {
            return null;
        }
        if (jObj.isNull(fieldName) || fieldValue == null || fieldValue == "null")
            return null;
        return fieldValue;
    }

    public void setMessage(String message, int id) {
        this.Message = message;
        this.Id = (id == 0) ? (message == null ? 0 : message.hashCode()) : id;
        if (!PlayFabConst.hideLogs)
            Log.i(PlayFabConst.LOG_TAG, "Setting message and id, Message: " + this.Message + ", Id: " + this.Id);
    }

    public static long getUtcOffset() {
        TimeZone tz1 = TimeZone.getTimeZone("UTC");
        TimeZone tz2 = TimeZone.getDefault();
        return tz1.getRawOffset() - tz2.getRawOffset() + tz1.getDSTSavings() - tz2.getDSTSavings();
    }

    public void setScheduleDate(String dateString) {
        if (dateString == null) {
            ScheduleType = PlayFabConst.ScheduleTypeNone;
            ScheduleDate = null;
        } else {
            boolean isUtc = dateString.endsWith("Z");
            ScheduleType = isUtc ? PlayFabConst.ScheduleTypeScheduledUtc : PlayFabConst.ScheduleTypeScheduledLocal;
            ScheduleDate = dateString;
        }
    }

    public long getMsgDelayInMillis() {
        if (ScheduleDate == null || ScheduleType == PlayFabConst.ScheduleTypeNone)
            return 0;

        String dateString = ScheduleDate;
        boolean isUtc = dateString.endsWith("Z");
        long offset = 0;
        if (isUtc) {
            dateString = dateString.substring(0, dateString.length() - 1).replace("T", " ");
            offset = getUtcOffset();
        }

        SimpleDateFormat sdf = new SimpleDateFormat(PlayFabConst.DATE_LOCAL_FORMAT);
        Date parsedDate;
        try {
            parsedDate = new Date(sdf.parse(dateString).getTime() - offset);
        } catch (Exception e) {
            return 0;
        }

        Calendar c = Calendar.getInstance();
        c.setTime(parsedDate);
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
