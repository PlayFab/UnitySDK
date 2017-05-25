package com.playfab.test;

import android.os.Parcel;

import com.playfab.unityplugin.GCM.ParcelableUtil;
import com.playfab.unityplugin.GCM.PlayFabConst;
import com.playfab.unityplugin.GCM.PlayFabNotificationPackage;

import java.text.SimpleDateFormat;
import java.util.Date;

import org.junit.Test;

import static org.junit.Assert.assertTrue;

public class PlayFabPluginTest {
    private SimpleDateFormat localSdf = new SimpleDateFormat(PlayFabConst.DATE_LOCAL_FORMAT);

    // These strings should represent the same time, sufficiently far in the future that the test will not fail
    private final String localTestTime = "2117-05-22 19:10:22"; // Assumes Pacific Daylight-Savings Timezone (and that DST hasn't changed in 100 years)
    private final String utcTestTime1 = "2117-05-23T02:10:22Z"; // ISO 8601 Standard
    private final String utcTestTime2 = "2117-05-23 02:10:22Z"; // ISO 8601 Standard without "T" (accepted by standard)
    private final long testMillis = 10000; // Create a timestanp that is only this far into the future

    private PlayFabNotificationPackage MakeTestPackage() {
        PlayFabNotificationPackage pkg = new PlayFabNotificationPackage();
        pkg.setMessage("test message", 123);
        pkg.setScheduleDate(localTestTime);
        pkg.Sound = "";
        pkg.Title = "";
        pkg.Icon = "";
        pkg.CustomData = "";
        return pkg;
    }

    @Test
    public void NotifyPackageCanParseLocalTimestamp() {
        PlayFabConst.hideLogs = true;

        PlayFabNotificationPackage pkg = new PlayFabNotificationPackage();
        assertTrue(pkg.getMsgDelayInMillis() == 0);
        pkg.setScheduleDate(localTestTime);
        assertTrue(pkg.getMsgDelayInMillis() > 0);
    }

    @Test
    public void NotifyPackageCanParseUtcTimestamp() {
        PlayFabConst.hideLogs = true;

        PlayFabNotificationPackage pkg = new PlayFabNotificationPackage();
        long nowMillis = new Date().getTime() + PlayFabNotificationPackage.getUtcOffset();
        Date utcPast = new Date(nowMillis - testMillis);
        Date utcNow = new Date(nowMillis);
        Date utcFuture = new Date(nowMillis + testMillis);
        pkg.setScheduleDate(null);
        assertTrue(pkg.ScheduleType == PlayFabConst.ScheduleTypeNone);
        assertTrue(pkg.getMsgDelayInMillis() == 0);
        pkg.setScheduleDate(localSdf.format(utcPast) + "Z");
        assertTrue(pkg.ScheduleType == PlayFabConst.ScheduleTypeScheduledUtc);
        assertTrue(pkg.getMsgDelayInMillis() == 0);
        pkg.setScheduleDate(localSdf.format(utcNow) + "Z");
        assertTrue(pkg.ScheduleType == PlayFabConst.ScheduleTypeScheduledUtc);
        assertTrue(pkg.getMsgDelayInMillis() == 0);
        pkg.setScheduleDate(localSdf.format(utcFuture) + "Z");
        assertTrue(pkg.ScheduleType == PlayFabConst.ScheduleTypeScheduledUtc);
        assertTrue(testMillis * 1.1 > pkg.getMsgDelayInMillis() && pkg.getMsgDelayInMillis() > testMillis * 0.9);
    }

    @Test
    public void NotifyPackageAccurateLocalTimestamp() {
        PlayFabConst.hideLogs = true;

        PlayFabNotificationPackage pkg = new PlayFabNotificationPackage();
        long nowMillis = new Date().getTime();
        Date past = new Date(nowMillis - testMillis);
        Date now = new Date(nowMillis);
        Date future = new Date(nowMillis + testMillis);
        pkg.setScheduleDate(null);
        assertTrue(pkg.ScheduleType == PlayFabConst.ScheduleTypeNone);
        assertTrue(pkg.getMsgDelayInMillis() == 0);
        pkg.setScheduleDate(localSdf.format(past));
        assertTrue(pkg.ScheduleType == PlayFabConst.ScheduleTypeScheduledLocal);
        assertTrue(pkg.getMsgDelayInMillis() == 0);
        pkg.setScheduleDate(localSdf.format(now));
        assertTrue(pkg.ScheduleType == PlayFabConst.ScheduleTypeScheduledLocal);
        assertTrue(pkg.getMsgDelayInMillis() == 0);
        pkg.setScheduleDate(localSdf.format(future));
        assertTrue(pkg.ScheduleType == PlayFabConst.ScheduleTypeScheduledLocal);
        assertTrue(testMillis * 1.1 > pkg.getMsgDelayInMillis() && pkg.getMsgDelayInMillis() > testMillis * 0.9);
    }

    @Test
    public void NotifyPackageParsesTimezonesCorrectly() {
        PlayFabConst.hideLogs = true;

        PlayFabNotificationPackage pkg = new PlayFabNotificationPackage();
        assertTrue(pkg.getMsgDelayInMillis() == 0);

        pkg.setScheduleDate(localTestTime);
        long localMillis = pkg.getMsgDelayInMillis();
        pkg.setScheduleDate(utcTestTime1);
        long utcMillis = pkg.getMsgDelayInMillis();
        assertTrue("Expected (nearly) Zero, Got: " + (utcMillis - localMillis), Math.abs(utcMillis - localMillis) < 10);
    }

    // @Test // This isn't an actual test
    public void DebugJsonOutput() {
        PlayFabNotificationPackage testPkg = MakeTestPackage();
        assertTrue(testPkg.toJson(), false);
    }

    // @Test // Can't test the stupid parcel package in tests
    public void NotifyPackageParcelSerialization() {
        PlayFabNotificationPackage expectedPkg = MakeTestPackage();
        byte[] bytes = ParcelableUtil.marshall(expectedPkg);
        Parcel parcel = ParcelableUtil.unmarshall(bytes);
        PlayFabNotificationPackage actualPkg = new PlayFabNotificationPackage(parcel);

        assertTrue(expectedPkg.Id == actualPkg.Id);
        assertTrue(expectedPkg.Message == actualPkg.Message);
        assertTrue(expectedPkg.ScheduleDate == actualPkg.ScheduleDate);
        assertTrue(expectedPkg.ScheduleType == actualPkg.ScheduleType);
        assertTrue(expectedPkg.Sound == actualPkg.Sound);
        assertTrue(expectedPkg.Title == actualPkg.Title);
        assertTrue(expectedPkg.Icon == actualPkg.Icon);
        assertTrue(expectedPkg.CustomData == actualPkg.CustomData);
    }

    // @Test // Can't test the stupid Json package in tests
    public void NotifyPackageJsonSerialization() {
        PlayFabNotificationPackage expectedPkg = MakeTestPackage();
        String testJson = expectedPkg.toJson();
        PlayFabNotificationPackage actualPkg = PlayFabNotificationPackage.fromJson(testJson);

        assertTrue(expectedPkg.Id == actualPkg.Id);
        assertTrue(expectedPkg.Message == actualPkg.Message);
        assertTrue(expectedPkg.ScheduleDate == actualPkg.ScheduleDate);
        assertTrue(expectedPkg.ScheduleType == actualPkg.ScheduleType);
        assertTrue(expectedPkg.Sound == actualPkg.Sound);
        assertTrue(expectedPkg.Title == actualPkg.Title);
        assertTrue(expectedPkg.Icon == actualPkg.Icon);
        assertTrue(expectedPkg.CustomData == actualPkg.CustomData);
    }
}
