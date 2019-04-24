using System;
using System.Collections.Generic;
using System.Text;

// This is part of Aria SDK

namespace Microsoft.Applications.Events
{
    internal enum BondDataType
    {
        BT_STOP = 0,
        BT_STOP_BASE = 1,
        BT_BOOL = 2,
        BT_UINT8 = 3,
        BT_UINT16 = 4,
        BT_UINT32 = 5,
        BT_UINT64 = 6,
        BT_FLOAT = 7,
        BT_DOUBLE = 8,
        BT_STRING = 9,
        BT_STRUCT = 10,
        BT_LIST = 11,
        BT_SET = 12,
        BT_MAP = 13,
        BT_INT8 = 14,
        BT_INT16 = 15,
        BT_INT32 = 16,
        BT_INT64 = 17,
        BT_WSTRING = 18,
        BT_UNAVAILABLE = 127
    };

    internal enum ProtocolType
    {
        MARSHALED_PROTOCOL = 0,
        FAST_PROTOCOL = 17997,
        COMPACT_PROTOCOL = 16963,
        SIMPLE_JSON_PROTOCOL = 19027,
        SIMPLE_PROTOCOL = 20563
    };

    internal class CompactBinaryProtocolWriter
    {
        private List<byte> _output = null;
        public List<byte> Data
        {
            get { return _output; }
        }

        public CompactBinaryProtocolWriter()
        {
            _output = new List<byte>();
        }

        public CompactBinaryProtocolWriter(List<byte> output)
        {
            _output = output;
        }

        public void WriteStructBegin(object nullptr, bool isBase)
        {
        }

        public void writeVarint(UInt16 value)
        {
            while ((UInt16)value > 127)
            {
                _output.Add((byte)((value & 127) | 128));
                value >>= 7;
            }
            _output.Add((byte)(value & 127));
        }

        public void writeVarint(Int16 value)
        {
            while ((Int16)value > 127)
            {
                _output.Add((byte)((value & 127) | 128));
                value >>= 7;
            }
            _output.Add((byte)(value & 127));
        }

        public void writeVarint(Int32 value)
        {
            while ((Int32)value > 127)
            {
                _output.Add((byte)((value & 127) | 128));
                value >>= 7;
            }
            _output.Add((byte)(value & 127));
        }

        public void writeVarint(UInt32 value)
        {
            while ((UInt32)value > 127)
            {
                _output.Add((byte)((value & 127) | 128));
                value >>= 7;
            }
            _output.Add((byte)(value & 127));
        }

        public void writeVarint(Int64 value)
        {
            while ((Int64)value > 127)
            {
                _output.Add((byte)((value & 127) | 128));
                value >>= 7;
            }
            _output.Add((byte)(value & 127));
        }
        public void writeVarint(UInt64 value)
        {
            while ((UInt64)value > 127)
            {
                _output.Add((byte)((value & 127) | 128));
                value >>= 7;
            }
            _output.Add((byte)(value & 127));
        }

        public void WriteBlob(List<byte> data, int size)
        {
            _output.AddRange(data);
        }

        public void WriteBlob(byte[] data, int size)
        {
            _output.AddRange(data);
        }

        public void WriteBool(bool value)
        {
            _output.Add((byte)(value ? 1 : 0));
        }

        public void WriteUInt8(byte value)
        {
            _output.Add(value);
        }

        public void WriteUInt16(UInt16 value)
        {
            writeVarint(value);
        }

        public void WriteUInt32(UInt32 value)
        {
            writeVarint(value);
        }

        public void WriteUInt64(UInt64 value)
        {
            writeVarint(value);
        }

        public void WriteInt8(sbyte value)
        {
            byte uValue = (byte)value;
            WriteUInt8(uValue);
        }

        public void WriteInt16(Int16 value)
        {
            UInt16 uValue = (UInt16)((value << 1) ^ (value >> 15));
            WriteUInt16(uValue);
        }

        public void WriteInt32(Int32 value)
        {
            UInt32 uValue = (UInt32)((value << 1) ^ (value >> 31));
            WriteUInt32(uValue);
        }

        public void WriteInt64(Int64 value)
        {
            UInt64 uValue = (UInt64)((value << 1) ^ (value >> 63));
            WriteUInt64(uValue);
        }

        public void WriteDouble(double value)
        {
            WriteBlob(BitConverter.GetBytes(value), 8);
        }

        public void WriteString(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                WriteUInt32(0);
            }
            else
            {
                byte[] toBytes = Encoding.UTF8.GetBytes(value);
                WriteUInt32((UInt32)(toBytes.Length));
                WriteBlob(toBytes, toBytes.Length);
            }
        }

        public void WriteWString(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                WriteUInt32(0);
            }
            else
            {
                byte[] toBytes = Encoding.UTF8.GetBytes(value);
                WriteUInt32((UInt32)(toBytes.Length));
                WriteBlob(toBytes, toBytes.Length);
            }
        }

        public void WriteContainerBegin(UInt16 size, byte elementType)
        {
            WriteUInt8(elementType);
            WriteUInt32((UInt32)(size));
        }

        public void WriteMapContainerBegin(UInt16 size, byte keyType, byte valueType)
        {
            WriteUInt8(keyType);
            WriteUInt8(valueType);
            WriteUInt32((UInt32)(size));
        }

        public void WriteContainerEnd()
        {
        }

        public void WriteFieldBegin(byte type, UInt16 id)
        {
            if (id <= 5)
            {
                _output.Add((byte)(type | ((byte)id << 5)));
            }
            else if (id <= 0xff)
            {
                _output.Add((byte)(type | (6 << 5)));
                _output.Add((byte)(id & 255));
            }
            else
            {
                _output.Add((byte)(type | (7 << 5)));
                _output.Add((byte)(id & 255));
                _output.Add((byte)(id >> 8));
            }
        }

        public void WriteFieldEnd()
        {
        }

        public void WriteStructEnd(bool isBase)
        {
            WriteUInt8((byte)((isBase == true) ? 1 : 0));
        }

        internal void WriteFieldOmitted(byte bT_STRING, int v)
        {
            return;
        }
    }

}
