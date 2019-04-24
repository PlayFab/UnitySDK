using System;
using Microsoft.Applications.Events.DataModels;

// This is part of Aria SDK

namespace Microsoft.Applications.Events
{
    internal static class MiniBond
    {
        public static void Serialize(CompactBinaryProtocolWriter writer, Ingest value, bool isBase)
        {
            writer.WriteStructBegin(null, isBase);

            if (value.time != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 1);
                writer.WriteInt64(value.time);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.clientIp))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 2);
                writer.WriteString(value.clientIp);
                writer.WriteFieldEnd();
            }

            if (value.auth != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 3);
                writer.WriteInt64(value.auth);
                writer.WriteFieldEnd();
            }

            if (value.quality != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 4);
                writer.WriteInt64(value.quality);
                writer.WriteFieldEnd();
            }

            if (value.uploadTime != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 5);
                writer.WriteInt64(value.uploadTime);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.userAgent))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 6);
                writer.WriteString(value.userAgent);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.client))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 7);
                writer.WriteString(value.client);
                writer.WriteFieldEnd();
            }

            writer.WriteStructEnd(isBase);
        }

        public static void Serialize(CompactBinaryProtocolWriter writer, User value, bool isBase)
        {

            if (!String.IsNullOrEmpty(value.id))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 1);
                writer.WriteString(value.id);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.localId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 2);
                writer.WriteString(value.localId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.authId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 3);
                writer.WriteString(value.authId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.locale))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 4);
                writer.WriteString(value.locale);
                writer.WriteFieldEnd();
            }

            writer.WriteStructEnd(isBase);
        }

        public static void Serialize(CompactBinaryProtocolWriter writer, Device value, bool isBase)
        {
            if (!String.IsNullOrEmpty(value.id))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 1);
                writer.WriteString(value.id);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.localId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 2);
                writer.WriteString(value.localId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.authId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 3);
                writer.WriteString(value.authId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.authSecId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 4);
                writer.WriteString(value.authSecId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.deviceClass))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 5);
                writer.WriteString(value.deviceClass);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.orgId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 6);
                writer.WriteString(value.orgId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.orgAuthId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 7);
                writer.WriteString(value.orgAuthId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.make))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 8);
                writer.WriteString(value.make);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.model))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 9);
                writer.WriteString(value.model);
                writer.WriteFieldEnd();
            }

            writer.WriteStructEnd(isBase);
        }

        public static void Serialize(CompactBinaryProtocolWriter writer, Os value, bool isBase)
        {
            if (!String.IsNullOrEmpty(value.locale))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 1);
                writer.WriteString(value.locale);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.expId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 2);
                writer.WriteString(value.expId);
                writer.WriteFieldEnd();
            }

            if (value.bootId != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT32, 3);
                writer.WriteInt32(value.bootId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.name))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 4);
                writer.WriteString(value.name);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.ver))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 5);
                writer.WriteString(value.ver);
                writer.WriteFieldEnd();
            }

            writer.WriteStructEnd(isBase);
        }

        public static void Serialize(CompactBinaryProtocolWriter writer, App value, bool isBase)
        {

            if (!String.IsNullOrEmpty(value.expId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 1);
                writer.WriteString(value.expId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.userId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 2);
                writer.WriteString(value.userId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.env))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 3);
                writer.WriteString(value.env);
                writer.WriteFieldEnd();
            }

            if (value.asId != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT32, 4);
                writer.WriteInt32(value.asId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.id))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 5);
                writer.WriteString(value.id);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.ver))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 6);
                writer.WriteString(value.ver);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.locale))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 7);
                writer.WriteString(value.locale);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.name))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 8);
                writer.WriteString(value.name);
                writer.WriteFieldEnd();
            }

            writer.WriteStructEnd(isBase);
        }


        public static void Serialize(CompactBinaryProtocolWriter writer, Utc value, bool isBase)
        {

            if (!String.IsNullOrEmpty(value.stId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 1);
                writer.WriteString(value.stId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.aId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 2);
                writer.WriteString(value.aId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.raId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 3);
                writer.WriteString(value.raId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.op))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 4);
                writer.WriteString(value.op);
                writer.WriteFieldEnd();
            }

            if (value.cat != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 5);
                writer.WriteInt64(value.cat);
                writer.WriteFieldEnd();
            }

            if (value.flags != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 6);
                writer.WriteInt64(value.flags);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.sqmId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 7);
                writer.WriteString(value.sqmId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.mon))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 9);
                writer.WriteString(value.mon);
                writer.WriteFieldEnd();
            }

            if (value.cpId != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT32, 10);
                writer.WriteInt32(value.cpId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.bSeq))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 11);
                writer.WriteString(value.bSeq);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.epoch))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 12);
                writer.WriteString(value.epoch);
                writer.WriteFieldEnd();
            }

            if (value.seq != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 13);
                writer.WriteInt64(value.seq);
                writer.WriteFieldEnd();
            }

            writer.WriteStructEnd(isBase);
        }


        public static void Serialize(CompactBinaryProtocolWriter writer, Xbl value, bool isBase)
        {

            if (value.claims != null && value.claims.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_MAP, 5);
                writer.WriteMapContainerBegin((UInt16)value.claims.Count, (byte)BondDataType.BT_STRING, (byte)BondDataType.BT_STRING);
                foreach (var item2 in value.claims)
                {
                    writer.WriteString(item2.Key);
                    writer.WriteString(item2.Value);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.nbf))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 10);
                writer.WriteString(value.nbf);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.exp))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 20);
                writer.WriteString(value.exp);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.sbx))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 30);
                writer.WriteString(value.sbx);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.dty))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 40);
                writer.WriteString(value.dty);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.did))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 50);
                writer.WriteString(value.did);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.xid))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 60);
                writer.WriteString(value.xid);
                writer.WriteFieldEnd();
            }

            if (value.uts != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_UINT64, 70);
                writer.WriteUInt64(value.uts);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.pid))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 80);
                writer.WriteString(value.pid);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.dvr))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 90);
                writer.WriteString(value.dvr);
                writer.WriteFieldEnd();
            }

            if (value.tid != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_UINT32, 100);
                writer.WriteUInt32((UInt32)value.tid);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.tvr))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 110);
                writer.WriteString(value.tvr);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.sty))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 120);
                writer.WriteString(value.sty);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.sid))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 130);
                writer.WriteString(value.sid);
                writer.WriteFieldEnd();
            }

            if (value.eid != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 140);
                writer.WriteInt64((Int64)value.eid);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.ip))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 150);
                writer.WriteString(value.ip);
                writer.WriteFieldEnd();
            }

            writer.WriteStructEnd(isBase);
        }


        public static void Serialize(CompactBinaryProtocolWriter writer, Javascript value, bool isBase)
        {

            if (!String.IsNullOrEmpty(value.libVer))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 10);
                writer.WriteString(value.libVer);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.osName))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 15);
                writer.WriteString(value.osName);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.browser))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 20);
                writer.WriteString(value.browser);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.browserVersion))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 21);
                writer.WriteString(value.browserVersion);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.platform))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 25);
                writer.WriteString(value.platform);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.make))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 30);
                writer.WriteString(value.make);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.model))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 35);
                writer.WriteString(value.model);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.screenSize))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 40);
                writer.WriteString(value.screenSize);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.mc1Id))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 50);
                writer.WriteString(value.mc1Id);
                writer.WriteFieldEnd();
            }

            if (value.mc1Lu != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_UINT64, 60);
                writer.WriteUInt64(value.mc1Lu);
                writer.WriteFieldEnd();
            }

            if (value.isMc1New != false)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_BOOL, 70);
                writer.WriteBool(value.isMc1New);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.ms0))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 80);
                writer.WriteString(value.ms0);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.anid))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 90);
                writer.WriteString(value.anid);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.a))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 100);
                writer.WriteString(value.a);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.msResearch))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 110);
                writer.WriteString(value.msResearch);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.csrvc))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 120);
                writer.WriteString(value.csrvc);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.rtCell))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 130);
                writer.WriteString(value.rtCell);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.rtEndAction))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 140);
                writer.WriteString(value.rtEndAction);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.rtPermId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 150);
                writer.WriteString(value.rtPermId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.r))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 160);
                writer.WriteString(value.r);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.wtFpc))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 170);
                writer.WriteString(value.wtFpc);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.omniId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 180);
                writer.WriteString(value.omniId);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.gsfxSession))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 190);
                writer.WriteString(value.gsfxSession);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.domain))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 200);
                writer.WriteString(value.domain);
                writer.WriteFieldEnd();
            }

            if (!String.IsNullOrEmpty(value.dnt))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 999);
                writer.WriteString(value.dnt);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 999);
            }

            writer.WriteStructEnd(isBase);
        }


        public static void Serialize(CompactBinaryProtocolWriter writer, Protocol value, bool isBase)
        {


            if (value.metadataCrc != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT32, 1);
                writer.WriteInt32(value.metadataCrc);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_INT32, 1);
            }

            if (value.ticketKeys != null && value.ticketKeys.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 2);
                writer.WriteContainerBegin((UInt16)value.ticketKeys.Count, (byte)BondDataType.BT_LIST);
                foreach (var item2 in value.ticketKeys)
                {
                    writer.WriteContainerBegin((UInt16)item2.Count, (byte)BondDataType.BT_STRING);
                    foreach (var item3 in item2)
                    {
                        writer.WriteString(item3);
                    }
                    writer.WriteContainerEnd();
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 2);
            }

            writer.WriteStructEnd(isBase);
        }


        public static void Serialize(CompactBinaryProtocolWriter writer, Receipts value, bool isBase)
        {
            if (value.originalTime != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 1);
                writer.WriteInt64(value.originalTime);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_INT64, 1);
            }

            if (value.uploadTime != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 2);
                writer.WriteInt64(value.uploadTime);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_INT64, 2);
            }

            writer.WriteStructEnd(isBase);
        }

        public static void Serialize(CompactBinaryProtocolWriter writer, Net value, bool isBase)
        {
            if (!String.IsNullOrEmpty(value.provider))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 1);
                writer.WriteString(value.provider);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 1);
            }

            if (!String.IsNullOrEmpty(value.cost))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 2);
                writer.WriteString(value.cost);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 2);
            }

            if (!String.IsNullOrEmpty(value.type))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 3);
                writer.WriteString(value.type);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 3);
            }

            writer.WriteStructEnd(isBase);
        }

        public static void Serialize(CompactBinaryProtocolWriter writer, Loc value, bool isBase)
        {
            if (!String.IsNullOrEmpty(value.id))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 1);
                writer.WriteString(value.id);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 1);
            }

            if (!String.IsNullOrEmpty(value.country))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 2);
                writer.WriteString(value.country);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 2);
            }

            if (!String.IsNullOrEmpty(value.timezone))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 3);
                writer.WriteString(value.timezone);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 3);
            }

            writer.WriteStructEnd(isBase);
        }

        public static void Serialize(CompactBinaryProtocolWriter writer, Sdk value, bool isBase)
        {
            if (!String.IsNullOrEmpty(value.libVer))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 1);
                writer.WriteString(value.libVer);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 1);
            }

            if (!String.IsNullOrEmpty(value.epoch))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 2);
                writer.WriteString(value.epoch);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 2);
            }

            if (value.seq != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 3);
                writer.WriteInt64(value.seq);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 3);
            }

            if (!String.IsNullOrEmpty(value.installId))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 4);
                writer.WriteString(value.installId);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 4);
            }

            writer.WriteStructEnd(isBase);
        }

        public static void Serialize(CompactBinaryProtocolWriter writer, PII value, bool isBase)
        {


            if (value.Kind != PIIKind.NotSet)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT32, 1);
                writer.WriteInt32((Int32)(value.Kind));
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_INT32, 1);
            }

            writer.WriteStructEnd(isBase);
        }


        public static void Serialize(CompactBinaryProtocolWriter writer, CustomerContent value, bool isBase)
        {

            if (value.Kind != CustomerContentKind.NotSet)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT32, 1);
                writer.WriteInt32((Int32)(value.Kind));
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_INT32, 1);
            }

            writer.WriteStructEnd(isBase);
        }


        public static void Serialize(CompactBinaryProtocolWriter writer, Attributes value, bool isBase)
        {


            if (value.pii != null)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 1);
                writer.WriteContainerBegin((UInt16)value.pii.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.pii)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 1);
            }

            if (value.customerContent != null)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 2);
                writer.WriteContainerBegin((UInt16)value.customerContent.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.customerContent)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 2);
            }

            writer.WriteStructEnd(isBase);
        }


        public static void Serialize(CompactBinaryProtocolWriter writer, Value value, bool isBase)
        {
            if (value.type != ValueKind.ValueString)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT32, 1);
                writer.WriteInt32((Int32)(value.type));
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_INT32, 1);
            }

            if (value.attributes != null)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 2);
                writer.WriteContainerBegin((UInt16)value.attributes.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.attributes)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 2);
            }

            if (!String.IsNullOrEmpty(value.stringValue))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 3);
                writer.WriteString(value.stringValue);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 3);
            }

            if (value.longValue != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 4);
                writer.WriteInt64(value.longValue);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_INT64, 4);
            }

            if (value.doubleValue != 0.0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_DOUBLE, 5);
                writer.WriteDouble(value.doubleValue);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_DOUBLE, 5);
            }

            if (value.guidValue != null && value.guidValue.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 6);
                writer.WriteContainerBegin((UInt16)value.guidValue.Count, (byte)BondDataType.BT_LIST);
                foreach (var item2 in value.guidValue)
                {
                    writer.WriteContainerBegin((UInt16)item2.Count, (byte)BondDataType.BT_UINT8);
                    foreach (var item3 in item2)
                    {
                        writer.WriteUInt8(item3);
                    }
                    writer.WriteContainerEnd();
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 6);
            }

            if (value.stringArray != null && value.stringArray.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 10);
                writer.WriteContainerBegin((UInt16)value.stringArray.Count, (byte)BondDataType.BT_LIST);
                foreach (var item2 in value.stringArray)
                {
                    writer.WriteContainerBegin((UInt16)item2.Count, (byte)BondDataType.BT_STRING);
                    foreach (var item3 in item2)
                    {
                        writer.WriteString(item3);
                    }
                    writer.WriteContainerEnd();
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 10);
            }

            if (value.longArray != null && value.longArray.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 11);
                writer.WriteContainerBegin((UInt16)value.longArray.Count, (byte)BondDataType.BT_LIST);
                foreach (var item2 in value.longArray)
                {
                    writer.WriteContainerBegin((UInt16)item2.Count, (byte)BondDataType.BT_INT64);
                    foreach (var item3 in item2)
                    {
                        writer.WriteInt64(item3);
                    }
                    writer.WriteContainerEnd();
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 11);
            }

            if (value.doubleArray != null && value.doubleArray.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 12);
                writer.WriteContainerBegin((UInt16)value.doubleArray.Count, (byte)BondDataType.BT_LIST);
                foreach (var item2 in value.doubleArray)
                {
                    writer.WriteContainerBegin((UInt16)item2.Count, (byte)BondDataType.BT_DOUBLE);
                    foreach (var item3 in item2)
                    {
                        writer.WriteDouble(item3);
                    }
                    writer.WriteContainerEnd();
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 12);
            }

            if (value.guidArray != null && value.guidArray.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 13);
                writer.WriteContainerBegin((UInt16)value.guidArray.Count, (byte)BondDataType.BT_LIST);
                foreach (var item2 in value.guidArray)
                {
                    writer.WriteContainerBegin((UInt16)item2.Count, (byte)BondDataType.BT_LIST);
                    foreach (var item3 in item2)
                    {
                        writer.WriteContainerBegin((UInt16)item3.Count, (byte)BondDataType.BT_INT64);
                        foreach (var item4 in item3)
                        {
                            writer.WriteInt64(item4);
                        }
                        writer.WriteContainerEnd();
                    }
                    writer.WriteContainerEnd();
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 13);
            }

            writer.WriteStructEnd(isBase);
        }


        public static void Serialize(CompactBinaryProtocolWriter writer, DataModels.Data value, bool isBase)
        {


            if (value.properties != null && value.properties.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_MAP, 1);
                writer.WriteMapContainerBegin((UInt16)value.properties.Count, (byte)BondDataType.BT_STRING, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.properties)
                {
                    writer.WriteString(item2.Key);
                    Serialize(writer, item2.Value, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_MAP, 1);
            }

            writer.WriteStructEnd(isBase);
        }


        public static void Serialize(CompactBinaryProtocolWriter writer, CsEvent value, bool isBase)
        {
            if (!String.IsNullOrEmpty(value.ver))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 1);
                writer.WriteString(value.ver);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 1);
            }

            if (!String.IsNullOrEmpty(value.name))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 2);
                writer.WriteString(value.name);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 2);
            }

            if (value.time != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 3);
                writer.WriteInt64(value.time);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_INT64, 3);
            }

            if (value.popSample != 100)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_DOUBLE, 4);
                writer.WriteDouble(value.popSample);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_DOUBLE, 4);
            }

            if (!String.IsNullOrEmpty(value.iKey))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 5);
                writer.WriteString(value.iKey);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 5);
            }

            if (value.flags != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_INT64, 6);
                writer.WriteInt64(value.flags);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_INT64, 6);
            }

            if (!String.IsNullOrEmpty(value.cV))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 7);
                writer.WriteString(value.cV);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 7);
            }

            if (value.extIngest != null && value.extIngest.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 20);
                writer.WriteContainerBegin((UInt16)value.extIngest.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extIngest)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 20);
            }

            if (value.extProtocol != null)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 21);
                writer.WriteContainerBegin((UInt16)value.extProtocol.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extProtocol)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 21);
            }

            if (value.extUser != null && value.extUser.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 22);
                writer.WriteContainerBegin((UInt16)value.extUser.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extUser)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 22);
            }

            if (value.extDevice != null && value.extDevice.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 23);
                writer.WriteContainerBegin((UInt16)value.extDevice.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extDevice)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 23);
            }

            if (value.extOs != null && value.extOs.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 24);
                writer.WriteContainerBegin((UInt16)value.extOs.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extOs)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 24);
            }

            if (value.extApp != null && value.extApp.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 25);
                writer.WriteContainerBegin((UInt16)value.extApp.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extApp)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 25);
            }

            if (value.extUtc != null && value.extUtc.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 26);
                writer.WriteContainerBegin((UInt16)value.extUtc.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extUtc)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 26);
            }

            if (value.extXbl != null && value.extXbl.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 27);
                writer.WriteContainerBegin((UInt16)value.extXbl.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extXbl)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 27);
            }

            if (value.extJavascript != null && value.extJavascript.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 28);
                writer.WriteContainerBegin((UInt16)value.extJavascript.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extJavascript)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 28);
            }

            if (value.extReceipts != null && value.extReceipts.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 29);
                writer.WriteContainerBegin((UInt16)value.extReceipts.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extReceipts)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 29);
            }

            if (value.extNet != null && value.extNet.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 31);
                writer.WriteContainerBegin((UInt16)value.extNet.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extNet)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 31);
            }

            if (value.extSdk != null && value.extSdk.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 32);
                writer.WriteContainerBegin((UInt16)value.extSdk.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extSdk)
                    Serialize(writer, item2, false);
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 32);
            }

            if (value.extLoc != null && value.extLoc.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 33);
                writer.WriteContainerBegin((UInt16)value.extLoc.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.extLoc)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 33);
            }

            if (value.ext != null && value.ext.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 41);
                writer.WriteContainerBegin((UInt16)value.ext.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.ext)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 41);
            }

            if (value.tags != null && value.tags.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_MAP, 51);
                writer.WriteMapContainerBegin((UInt16)value.tags.Count, (byte)BondDataType.BT_STRING, (byte)BondDataType.BT_STRING);
                foreach (var item2 in value.tags)
                {
                    writer.WriteString(item2.Key);
                    writer.WriteString(item2.Value);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_MAP, 51);
            }

            if (!String.IsNullOrEmpty(value.baseType))
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_STRING, 60);
                writer.WriteString(value.baseType);
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_STRING, 60);
            }

            if (value.baseData != null && value.baseData.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 61);
                writer.WriteContainerBegin((UInt16)value.baseData.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.baseData)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 61);
            }

            if (value.data != null && value.data.Count != 0)
            {
                writer.WriteFieldBegin((byte)BondDataType.BT_LIST, 70);
                writer.WriteContainerBegin((UInt16)value.data.Count, (byte)BondDataType.BT_STRUCT);
                foreach (var item2 in value.data)
                {
                    Serialize(writer, item2, false);
                }
                writer.WriteContainerEnd();
                writer.WriteFieldEnd();
            }
            else
            {
                writer.WriteFieldOmitted((byte)BondDataType.BT_LIST, 70);
            }

            writer.WriteStructEnd(isBase);
        }

    } // namespace bond_lite

}
