package com.playfab.test;

import com.playfab.unityplugin.GCM.PlayFabNotificationPackage;

import java.text.SimpleDateFormat;
import java.util.Date;

import org.junit.Test;

import static org.junit.Assert.assertTrue;

public class PlayFabPluginTest {
    private SimpleDateFormat localSdf = new SimpleDateFormat(PlayFabNotificationPackage.DATE_LOCAL_FORMAT);

    // These strings should represent the same time, sufficiently far in the future that the test will not fail
    private final String localTestTime = "2117-05-22 19:10:22"; // Assumes Pacific Daylight-Savings Timezone (and that DST hasn't changed in 100 years)
    private final String utcTestTime1 = "2117-05-23T02:10:22Z"; // ISO 8601 Standard
    private final String utcTestTime2 = "2117-05-23 02:10:22Z"; // ISO 8601 Standard without "T" (accepted by standard)
    private final long testMillis = 10000; // Create a timestanp that is only this far into the future

    @Test
    public void NotifyPackageCanParseLocalTimestamp() {
        PlayFabNotificationPackage.hideLogs = true;

        PlayFabNotificationPackage pkg = new PlayFabNotificationPackage();
        assertTrue(pkg.GetMsgDelayInMillis() == 0);
        pkg.SetScheduleDate(localTestTime);
        assertTrue(pkg.GetMsgDelayInMillis() > 0);
    }

    @Test
    public void NotifyPackageCanParseUtcTimestamp() {
        PlayFabNotificationPackage.hideLogs = true;

        PlayFabNotificationPackage pkg = new PlayFabNotificationPackage();
        long nowMillis = new Date().getTime() + PlayFabNotificationPackage.getUtcOffset();
        Date utcPast = new Date(nowMillis - testMillis);
        Date utcNow = new Date(nowMillis);
        Date utcFuture = new Date(nowMillis + testMillis);
        pkg.SetScheduleDate(null);
        assertTrue(pkg.ScheduleType == PlayFabNotificationPackage.ScheduleTypeNone);
        assertTrue(pkg.GetMsgDelayInMillis() == 0);
        pkg.SetScheduleDate(localSdf.format(utcPast) + "Z");
        assertTrue(pkg.ScheduleType == PlayFabNotificationPackage.ScheduleTypeScheduledUtc);
        assertTrue(pkg.GetMsgDelayInMillis() == 0);
        pkg.SetScheduleDate(localSdf.format(utcNow) + "Z");
        assertTrue(pkg.ScheduleType == PlayFabNotificationPackage.ScheduleTypeScheduledUtc);
        assertTrue(pkg.GetMsgDelayInMillis() == 0);
        pkg.SetScheduleDate(localSdf.format(utcFuture) + "Z");
        assertTrue(pkg.ScheduleType == PlayFabNotificationPackage.ScheduleTypeScheduledUtc);
        assertTrue(testMillis * 1.1 > pkg.GetMsgDelayInMillis() && pkg.GetMsgDelayInMillis() > testMillis * 0.9);    }

    @Test
    public void NotifyPackageAccurateLocalTimestamp() {
        PlayFabNotificationPackage.hideLogs = true;

        PlayFabNotificationPackage pkg = new PlayFabNotificationPackage();
        long nowMillis = new Date().getTime();
        Date past = new Date(nowMillis - testMillis);
        Date now = new Date(nowMillis);
        Date future = new Date(nowMillis + testMillis);
        pkg.SetScheduleDate(null);
        assertTrue(pkg.ScheduleType == PlayFabNotificationPackage.ScheduleTypeNone);
        assertTrue(pkg.GetMsgDelayInMillis() == 0);
        pkg.SetScheduleDate(localSdf.format(past));
        assertTrue(pkg.ScheduleType == PlayFabNotificationPackage.ScheduleTypeScheduledLocal);
        assertTrue(pkg.GetMsgDelayInMillis() == 0);
        pkg.SetScheduleDate(localSdf.format(now));
        assertTrue(pkg.ScheduleType == PlayFabNotificationPackage.ScheduleTypeScheduledLocal);
        assertTrue(pkg.GetMsgDelayInMillis() == 0);
        pkg.SetScheduleDate(localSdf.format(future));
        assertTrue(pkg.ScheduleType == PlayFabNotificationPackage.ScheduleTypeScheduledLocal);
        assertTrue(testMillis * 1.1 > pkg.GetMsgDelayInMillis() && pkg.GetMsgDelayInMillis() > testMillis * 0.9);
    }

    @Test
    public void NotifyPackageParsesTimezonesCorrectly() {
        PlayFabNotificationPackage.hideLogs = true;

        PlayFabNotificationPackage pkg = new PlayFabNotificationPackage();
        assertTrue(pkg.GetMsgDelayInMillis() == 0);

        pkg.SetScheduleDate(localTestTime);
        long localMillis = pkg.GetMsgDelayInMillis();
        pkg.SetScheduleDate(utcTestTime1);
        long utcMillis = pkg.GetMsgDelayInMillis();
        assertTrue("Expected (nearly) Zero, Got: " + (utcMillis - localMillis), Math.abs(utcMillis - localMillis) < 10);
    }
}
