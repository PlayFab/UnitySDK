package com.playfab.unityplugin.GCM;

/**
 * Created by Marco on 9/16/2015.
 */

import android.os.Parcel;
import android.os.Parcelable;
import android.util.Log;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Custom class that maps to the strigified json message sent by push notifications
*/
public class PlayFabNotificationPackage implements Parcelable {
    public enum ScheduleTypes {
        None,
        ScheduledDate
    }

    public Date ScheduleDate;
    public ScheduleTypes ScheduleType = ScheduleTypes.None;
    public String Sound;                   // do not set this to use the default device sound; otherwise the sound you provide needs to exist in Android/res/raw/_____.mp3, .wav, .ogg
    public String Title;                // title of this message
    public String Icon;                 // to use the default app icon use app_icon, otherwise send the name of the custom image. Image must be in Android/res/drawable/_____.png, .jpg
    public String Message;              // the actual message to transmit (this is what will be displayed in the notification area
    public String CustomData;           // arbitrary key value pairs for game specific usage
    public String Id;
    public boolean Delivered;
    private Date DeliveryDate;

    public PlayFabNotificationPackage(){}

    public PlayFabNotificationPackage(String id, Date scheduleDate, ScheduleTypes scheduleType, String scheduleInterval , String sound, String title, String icon, String message, String customData){
        this.ScheduleDate  = scheduleDate;
        this.ScheduleType = scheduleType;
        this.Sound = sound;
        this.Title = title;
        this.Icon = icon;
        this.Message = message;
        this.CustomData = customData;
        this.Id = id;
        this.Delivered = false;
    }

    public PlayFabNotificationPackage(Parcel in){
        String[] data = new String[5];
        in.readStringArray(data);
        this.Sound = data[0];
        this.Title = data[1];
        this.Icon = data[2];
        this.Message = data[3];
        this.CustomData = data[4];
        this.Delivered = false;
    }

    @Override
    public int describeContents(){
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags){
        dest.writeStringArray(new String[] {
            this.Sound,
            this.Title,
            this.Icon,
            this.Message,
            this.CustomData
        });
    }

    public void SetDelivered(){
        this.Delivered = true;
    }

    public void SetDeliveryDate(Date date){
        this.DeliveryDate = date;
    }

    public void SetScheduleDate(String date){
        SimpleDateFormat sdf = new SimpleDateFormat("MM-dd-yyyy hh:mm:ss");
        try {
            Date parsedDate = sdf.parse(date);
            Log.i("PlayFabGCM","Id: " + this.Id + " - " + parsedDate.toString());
            this.ScheduleDate = parsedDate;
        }catch(Exception e){
            Log.i("PlayFabGCM", "Could not parse date.  use format  MM-dd-yyy hh:mm:ss");
        }
    }

    public static final Parcelable.Creator CREATOR = new Parcelable.Creator() {
      public PlayFabNotificationPackage createFromParcel(Parcel in){
        return new PlayFabNotificationPackage(in);
      }

      public PlayFabNotificationPackage[] newArray(int size){
          return new PlayFabNotificationPackage[size];
      }
    };

}

