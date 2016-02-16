using System.Collections.Generic;
using PlayFab.ClientModels;
using PlayFab.Internal;

namespace PlayFab.UUnit
{
    internal class ObjNumFieldTest
    {
        public sbyte SbyteValue; public byte ByteValue;
        public short ShortValue; public ushort UshortValue;
        public int IntValue; public uint UintValue;
        public long LongValue; public ulong UlongValue;
        public float FloatValue; public double DoubleValue;

        public static ObjNumFieldTest Max = new ObjNumFieldTest { SbyteValue = sbyte.MaxValue, ByteValue = byte.MaxValue, ShortValue = short.MaxValue, UshortValue = ushort.MaxValue, IntValue = int.MaxValue, UintValue = uint.MaxValue, LongValue = long.MaxValue, UlongValue = ulong.MaxValue, FloatValue = float.MaxValue, DoubleValue = double.MaxValue };
        public static ObjNumFieldTest Min = new ObjNumFieldTest { SbyteValue = sbyte.MinValue, ByteValue = byte.MinValue, ShortValue = short.MinValue, UshortValue = ushort.MinValue, IntValue = int.MinValue, UintValue = uint.MinValue, LongValue = long.MinValue, UlongValue = ulong.MinValue, FloatValue = float.MinValue, DoubleValue = double.MinValue };
        public static ObjNumFieldTest Zero = new ObjNumFieldTest();
    }
    internal class ObjNumPropTest
    {
        public sbyte SbyteValue { get; set; } public byte ByteValue { get; set; }
        public short ShortValue { get; set; } public ushort UshortValue { get; set; }
        public int IntValue { get; set; } public uint UintValue { get; set; }
        public long LongValue { get; set; } public ulong UlongValue { get; set; }
        public float FloatValue { get; set; } public double DoubleValue { get; set; }

        public static ObjNumPropTest Max = new ObjNumPropTest { SbyteValue = sbyte.MaxValue, ByteValue = byte.MaxValue, ShortValue = short.MaxValue, UshortValue = ushort.MaxValue, IntValue = int.MaxValue, UintValue = uint.MaxValue, LongValue = long.MaxValue, UlongValue = ulong.MaxValue, FloatValue = float.MaxValue, DoubleValue = double.MaxValue };
        public static ObjNumPropTest Min = new ObjNumPropTest { SbyteValue = sbyte.MinValue, ByteValue = byte.MinValue, ShortValue = short.MinValue, UshortValue = ushort.MinValue, IntValue = int.MinValue, UintValue = uint.MinValue, LongValue = long.MinValue, UlongValue = ulong.MinValue, FloatValue = float.MinValue, DoubleValue = double.MinValue };
        public static ObjNumPropTest Zero = new ObjNumPropTest();
    }
    internal struct StructNumFieldTest
    {
        public sbyte SbyteValue; public byte ByteValue;
        public short ShortValue; public ushort UshortValue;
        public int IntValue; public uint UintValue;
        public long LongValue; public ulong UlongValue;
        public float FloatValue; public double DoubleValue;

        public static StructNumFieldTest Max = new StructNumFieldTest { SbyteValue = sbyte.MaxValue, ByteValue = byte.MaxValue, ShortValue = short.MaxValue, UshortValue = ushort.MaxValue, IntValue = int.MaxValue, UintValue = uint.MaxValue, LongValue = long.MaxValue, UlongValue = ulong.MaxValue, FloatValue = float.MaxValue, DoubleValue = double.MaxValue };
        public static StructNumFieldTest Min = new StructNumFieldTest { SbyteValue = sbyte.MinValue, ByteValue = byte.MinValue, ShortValue = short.MinValue, UshortValue = ushort.MinValue, IntValue = int.MinValue, UintValue = uint.MinValue, LongValue = long.MinValue, UlongValue = ulong.MinValue, FloatValue = float.MinValue, DoubleValue = double.MinValue };
        public static StructNumFieldTest Zero = new StructNumFieldTest();
    }
    internal class ObjOptNumFieldTest
    {
        public sbyte? SbyteValue { get; set; } public byte? ByteValue { get; set; }
        public short? ShortValue { get; set; } public ushort? UshortValue { get; set; }
        public int? IntValue { get; set; } public uint? UintValue { get; set; }
        public long? LongValue { get; set; } public ulong? UlongValue { get; set; }
        public float? FloatValue { get; set; } public double? DoubleValue { get; set; }

        public static ObjOptNumFieldTest Max = new ObjOptNumFieldTest { SbyteValue = sbyte.MaxValue, ByteValue = byte.MaxValue, ShortValue = short.MaxValue, UshortValue = ushort.MaxValue, IntValue = int.MaxValue, UintValue = uint.MaxValue, LongValue = long.MaxValue, UlongValue = ulong.MaxValue, FloatValue = float.MaxValue, DoubleValue = double.MaxValue };
        public static ObjOptNumFieldTest Min = new ObjOptNumFieldTest { SbyteValue = sbyte.MinValue, ByteValue = byte.MinValue, ShortValue = short.MinValue, UshortValue = ushort.MinValue, IntValue = int.MinValue, UintValue = uint.MinValue, LongValue = long.MinValue, UlongValue = ulong.MinValue, FloatValue = float.MinValue, DoubleValue = double.MinValue };
        public static ObjOptNumFieldTest Zero = new ObjOptNumFieldTest { SbyteValue = 0, ByteValue = 0, ShortValue = 0, UshortValue = 0, IntValue = 0, UintValue = 0, LongValue = 0, UlongValue = 0, FloatValue = 0, DoubleValue = 0 };
        public static ObjOptNumFieldTest Null = new ObjOptNumFieldTest { SbyteValue = null, ByteValue = null, ShortValue = null, UshortValue = null, IntValue = null, UintValue = null, LongValue = null, UlongValue = null, FloatValue = null, DoubleValue = null };
    }

    internal class OtherSpecificDatatypes
    {
        public Dictionary<string, string> StringDict { get; set; }
        public Dictionary<string, int> IntDict { get; set; }
        public Dictionary<string, uint> UintDict { get; set; }
        public Dictionary<string, Region> EnumDict { get; set; }
        public string TestString { get; set; }
    }

    class JsonUnitTests
    {
        class JsonLongTest : UUnitTestCase
        {
            [UUnitTest]
            public void TestObjNumField()
            {
                var expectedObjects = new[] { ObjNumFieldTest.Max, ObjNumFieldTest.Min, ObjNumFieldTest.Zero };
                for (int i = 0; i < expectedObjects.Length; i++)
                {
                    // Convert the object to json and back, and verify that everything is the same
                    var actualJson = SimpleJson.SerializeObject(expectedObjects[i], Util.ApiSerializerStrategy).Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    var actualObject = SimpleJson.DeserializeObject<ObjNumFieldTest>(actualJson, Util.ApiSerializerStrategy);

                    UUnitAssert.SbyteEquals(expectedObjects[i].SbyteValue, actualObject.SbyteValue);
                    UUnitAssert.ByteEquals(expectedObjects[i].ByteValue, actualObject.ByteValue);
                    UUnitAssert.ShortEquals(expectedObjects[i].ShortValue, actualObject.ShortValue);
                    UUnitAssert.UshortEquals(expectedObjects[i].UshortValue, actualObject.UshortValue);
                    UUnitAssert.IntEquals(expectedObjects[i].IntValue, actualObject.IntValue);
                    UUnitAssert.UintEquals(expectedObjects[i].UintValue, actualObject.UintValue);
                    UUnitAssert.LongEquals(expectedObjects[i].LongValue, actualObject.LongValue);
                    UUnitAssert.ULongEquals(expectedObjects[i].UlongValue, actualObject.UlongValue);
                    UUnitAssert.FloatEquals(expectedObjects[i].FloatValue, actualObject.FloatValue, 0.001f);
                    UUnitAssert.DoubleEquals(expectedObjects[i].DoubleValue, actualObject.DoubleValue, 0.001);
                }
            }

            [UUnitTest]
            public void TestObjNumProp()
            {
                var expectedObjects = new[] { ObjNumPropTest.Max, ObjNumPropTest.Min, ObjNumPropTest.Zero };
                for (int i = 0; i < expectedObjects.Length; i++)
                {
                    // Convert the object to json and back, and verify that everything is the same
                    var actualJson = SimpleJson.SerializeObject(expectedObjects[i], Util.ApiSerializerStrategy).Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    var actualObject = SimpleJson.DeserializeObject<ObjNumPropTest>(actualJson, Util.ApiSerializerStrategy);

                    UUnitAssert.SbyteEquals(expectedObjects[i].SbyteValue, actualObject.SbyteValue);
                    UUnitAssert.ByteEquals(expectedObjects[i].ByteValue, actualObject.ByteValue);
                    UUnitAssert.ShortEquals(expectedObjects[i].ShortValue, actualObject.ShortValue);
                    UUnitAssert.UshortEquals(expectedObjects[i].UshortValue, actualObject.UshortValue);
                    UUnitAssert.IntEquals(expectedObjects[i].IntValue, actualObject.IntValue);
                    UUnitAssert.UintEquals(expectedObjects[i].UintValue, actualObject.UintValue);
                    UUnitAssert.LongEquals(expectedObjects[i].LongValue, actualObject.LongValue);
                    UUnitAssert.ULongEquals(expectedObjects[i].UlongValue, actualObject.UlongValue);
                    UUnitAssert.FloatEquals(expectedObjects[i].FloatValue, actualObject.FloatValue, float.MaxValue * 0.000000001f);
                    UUnitAssert.DoubleEquals(expectedObjects[i].DoubleValue, actualObject.DoubleValue, double.MaxValue * 0.000000001f);
                }
            }

            [UUnitTest]
            public void TestStructNumField()
            {
                var expectedObjects = new[] { StructNumFieldTest.Max, StructNumFieldTest.Min, StructNumFieldTest.Zero };
                for (int i = 0; i < expectedObjects.Length; i++)
                {
                    // Convert the object to json and back, and verify that everything is the same
                    var actualJson = SimpleJson.SerializeObject(expectedObjects[i], Util.ApiSerializerStrategy).Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    var actualObject = SimpleJson.DeserializeObject<ObjNumPropTest>(actualJson, Util.ApiSerializerStrategy);

                    UUnitAssert.SbyteEquals(expectedObjects[i].SbyteValue, actualObject.SbyteValue);
                    UUnitAssert.ByteEquals(expectedObjects[i].ByteValue, actualObject.ByteValue);
                    UUnitAssert.ShortEquals(expectedObjects[i].ShortValue, actualObject.ShortValue);
                    UUnitAssert.UshortEquals(expectedObjects[i].UshortValue, actualObject.UshortValue);
                    UUnitAssert.IntEquals(expectedObjects[i].IntValue, actualObject.IntValue);
                    UUnitAssert.UintEquals(expectedObjects[i].UintValue, actualObject.UintValue);
                    UUnitAssert.LongEquals(expectedObjects[i].LongValue, actualObject.LongValue);
                    UUnitAssert.ULongEquals(expectedObjects[i].UlongValue, actualObject.UlongValue);
                    UUnitAssert.FloatEquals(expectedObjects[i].FloatValue, actualObject.FloatValue, float.MaxValue * 0.000000001f);
                    UUnitAssert.DoubleEquals(expectedObjects[i].DoubleValue, actualObject.DoubleValue, double.MaxValue * 0.000000001f);
                }
            }

            [UUnitTest]
            public void TestObjOptNumField()
            {
                var expectedObjects = new[] { ObjOptNumFieldTest.Max, ObjOptNumFieldTest.Min, ObjOptNumFieldTest.Zero, ObjOptNumFieldTest.Null };
                for (int i = 0; i < expectedObjects.Length; i++)
                {
                    // Convert the object to json and back, and verify that everything is the same
                    var actualJson = SimpleJson.SerializeObject(expectedObjects[i], Util.ApiSerializerStrategy).Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    var actualObject = SimpleJson.DeserializeObject<ObjOptNumFieldTest>(actualJson, Util.ApiSerializerStrategy);

                    UUnitAssert.SbyteEquals(expectedObjects[i].SbyteValue, actualObject.SbyteValue);
                    UUnitAssert.ByteEquals(expectedObjects[i].ByteValue, actualObject.ByteValue);
                    UUnitAssert.ShortEquals(expectedObjects[i].ShortValue, actualObject.ShortValue);
                    UUnitAssert.UshortEquals(expectedObjects[i].UshortValue, actualObject.UshortValue);
                    UUnitAssert.IntEquals(expectedObjects[i].IntValue, actualObject.IntValue);
                    UUnitAssert.UintEquals(expectedObjects[i].UintValue, actualObject.UintValue);
                    UUnitAssert.LongEquals(expectedObjects[i].LongValue, actualObject.LongValue);
                    UUnitAssert.ULongEquals(expectedObjects[i].UlongValue, actualObject.UlongValue);
                    UUnitAssert.FloatEquals(expectedObjects[i].FloatValue, actualObject.FloatValue, float.MaxValue * 0.000000001f);
                    UUnitAssert.DoubleEquals(expectedObjects[i].DoubleValue, actualObject.DoubleValue, double.MaxValue * 0.000000001f);
                }
            }

            [UUnitTest]
            public void OtherSpecificDatatypes()
            {
                var expectedObj = new OtherSpecificDatatypes
                {
                    StringDict = new Dictionary<string, string> { { "stringKey", "stringValue" } },
                    EnumDict = new Dictionary<string, Region> { { "enumKey", Region.Japan } },
                    IntDict = new Dictionary<string, int> { { "intKey", int.MinValue } },
                    UintDict = new Dictionary<string, uint> { { "uintKey", uint.MaxValue } },
                    TestString = "yup",
                };
                // Convert the object to json and back, and verify that everything is the same
                var actualJson = SimpleJson.SerializeObject(expectedObj, Util.ApiSerializerStrategy).Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                actualJson = actualJson.Replace("[", "").Replace("]", "").Replace(",\"Value\"", "").Replace("\"Key\":", "");
                var actualObject = SimpleJson.DeserializeObject<OtherSpecificDatatypes>(actualJson, Util.ApiSerializerStrategy);

                UUnitAssert.ObjEquals(expectedObj.TestString, actualObject.TestString);
                UUnitAssert.SequenceEquals(expectedObj.IntDict, actualObject.IntDict);
                UUnitAssert.SequenceEquals(expectedObj.UintDict, actualObject.UintDict);
                UUnitAssert.SequenceEquals(expectedObj.StringDict, actualObject.StringDict);
                UUnitAssert.SequenceEquals(expectedObj.EnumDict, actualObject.EnumDict);
            }
        }
    }
}
