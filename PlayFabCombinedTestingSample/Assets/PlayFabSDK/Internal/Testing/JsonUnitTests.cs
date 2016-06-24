using System;
using System.Collections.Generic;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.UUnit;

namespace PlayFab.UUnit
{
    public enum Region
    {
        USCentral,
        USEast,
        EUWest,
        Singapore,
        Japan,
        Brazil,
        Australia
    }

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
            public void TestObjNumField(UUnitTestContext testContext)
            {
                var expectedObjects = new[] { ObjNumFieldTest.Max, ObjNumFieldTest.Min, ObjNumFieldTest.Zero };
                for (int i = 0; i < expectedObjects.Length; i++)
                {
                    // Convert the object to json and back, and verify that everything is the same
                    var actualJson = JsonWrapper.SerializeObject(expectedObjects[i], PlayFabUtil.ApiSerializerStrategy).Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    var actualObject = JsonWrapper.DeserializeObject<ObjNumFieldTest>(actualJson, PlayFabUtil.ApiSerializerStrategy);

                    testContext.SbyteEquals(expectedObjects[i].SbyteValue, actualObject.SbyteValue);
                    testContext.ByteEquals(expectedObjects[i].ByteValue, actualObject.ByteValue);
                    testContext.ShortEquals(expectedObjects[i].ShortValue, actualObject.ShortValue);
                    testContext.UshortEquals(expectedObjects[i].UshortValue, actualObject.UshortValue);
                    testContext.IntEquals(expectedObjects[i].IntValue, actualObject.IntValue);
                    testContext.UintEquals(expectedObjects[i].UintValue, actualObject.UintValue);
                    testContext.LongEquals(expectedObjects[i].LongValue, actualObject.LongValue);
                    testContext.ULongEquals(expectedObjects[i].UlongValue, actualObject.UlongValue);
                    testContext.FloatEquals(expectedObjects[i].FloatValue, actualObject.FloatValue, 0.001f);
                    testContext.DoubleEquals(expectedObjects[i].DoubleValue, actualObject.DoubleValue, 0.001);
                }
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }

            [UUnitTest]
            public void TestObjNumProp(UUnitTestContext testContext)
            {
                var expectedObjects = new[] { ObjNumPropTest.Max, ObjNumPropTest.Min, ObjNumPropTest.Zero };
                for (int i = 0; i < expectedObjects.Length; i++)
                {
                    // Convert the object to json and back, and verify that everything is the same
                    var actualJson = JsonWrapper.SerializeObject(expectedObjects[i], PlayFabUtil.ApiSerializerStrategy).Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    var actualObject = JsonWrapper.DeserializeObject<ObjNumPropTest>(actualJson, PlayFabUtil.ApiSerializerStrategy);

                    testContext.SbyteEquals(expectedObjects[i].SbyteValue, actualObject.SbyteValue);
                    testContext.ByteEquals(expectedObjects[i].ByteValue, actualObject.ByteValue);
                    testContext.ShortEquals(expectedObjects[i].ShortValue, actualObject.ShortValue);
                    testContext.UshortEquals(expectedObjects[i].UshortValue, actualObject.UshortValue);
                    testContext.IntEquals(expectedObjects[i].IntValue, actualObject.IntValue);
                    testContext.UintEquals(expectedObjects[i].UintValue, actualObject.UintValue);
                    testContext.LongEquals(expectedObjects[i].LongValue, actualObject.LongValue);
                    testContext.ULongEquals(expectedObjects[i].UlongValue, actualObject.UlongValue);
                    testContext.FloatEquals(expectedObjects[i].FloatValue, actualObject.FloatValue, float.MaxValue * 0.000000001f);
                    testContext.DoubleEquals(expectedObjects[i].DoubleValue, actualObject.DoubleValue, double.MaxValue * 0.000000001f);
                }
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }

            [UUnitTest]
            public void TestStructNumField(UUnitTestContext testContext)
            {
                var expectedObjects = new[] { StructNumFieldTest.Max, StructNumFieldTest.Min, StructNumFieldTest.Zero };
                for (int i = 0; i < expectedObjects.Length; i++)
                {
                    // Convert the object to json and back, and verify that everything is the same
                    var actualJson = JsonWrapper.SerializeObject(expectedObjects[i], PlayFabUtil.ApiSerializerStrategy).Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    var actualObject = JsonWrapper.DeserializeObject<ObjNumPropTest>(actualJson, PlayFabUtil.ApiSerializerStrategy);

                    testContext.SbyteEquals(expectedObjects[i].SbyteValue, actualObject.SbyteValue);
                    testContext.ByteEquals(expectedObjects[i].ByteValue, actualObject.ByteValue);
                    testContext.ShortEquals(expectedObjects[i].ShortValue, actualObject.ShortValue);
                    testContext.UshortEquals(expectedObjects[i].UshortValue, actualObject.UshortValue);
                    testContext.IntEquals(expectedObjects[i].IntValue, actualObject.IntValue);
                    testContext.UintEquals(expectedObjects[i].UintValue, actualObject.UintValue);
                    testContext.LongEquals(expectedObjects[i].LongValue, actualObject.LongValue);
                    testContext.ULongEquals(expectedObjects[i].UlongValue, actualObject.UlongValue);
                    testContext.FloatEquals(expectedObjects[i].FloatValue, actualObject.FloatValue, float.MaxValue * 0.000000001f);
                    testContext.DoubleEquals(expectedObjects[i].DoubleValue, actualObject.DoubleValue, double.MaxValue * 0.000000001f);
                }
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }

            [UUnitTest]
            public void TestObjOptNumField(UUnitTestContext testContext)
            {
                var expectedObjects = new[] { ObjOptNumFieldTest.Max, ObjOptNumFieldTest.Min, ObjOptNumFieldTest.Zero, ObjOptNumFieldTest.Null };
                for (int i = 0; i < expectedObjects.Length; i++)
                {
                    // Convert the object to json and back, and verify that everything is the same
                    var actualJson = JsonWrapper.SerializeObject(expectedObjects[i], PlayFabUtil.ApiSerializerStrategy).Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    var actualObject = JsonWrapper.DeserializeObject<ObjOptNumFieldTest>(actualJson, PlayFabUtil.ApiSerializerStrategy);

                    testContext.SbyteEquals(expectedObjects[i].SbyteValue, actualObject.SbyteValue);
                    testContext.ByteEquals(expectedObjects[i].ByteValue, actualObject.ByteValue);
                    testContext.ShortEquals(expectedObjects[i].ShortValue, actualObject.ShortValue);
                    testContext.UshortEquals(expectedObjects[i].UshortValue, actualObject.UshortValue);
                    testContext.IntEquals(expectedObjects[i].IntValue, actualObject.IntValue);
                    testContext.UintEquals(expectedObjects[i].UintValue, actualObject.UintValue);
                    testContext.LongEquals(expectedObjects[i].LongValue, actualObject.LongValue);
                    testContext.ULongEquals(expectedObjects[i].UlongValue, actualObject.UlongValue);
                    testContext.FloatEquals(expectedObjects[i].FloatValue, actualObject.FloatValue, float.MaxValue * 0.000000001f);
                    testContext.DoubleEquals(expectedObjects[i].DoubleValue, actualObject.DoubleValue, double.MaxValue * 0.000000001f);
                }
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }

            [UUnitTest]
            public void OtherSpecificDatatypes(UUnitTestContext testContext)
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
                var actualJson = JsonWrapper.SerializeObject(expectedObj, PlayFabUtil.ApiSerializerStrategy).Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                var actualObject = JsonWrapper.DeserializeObject<OtherSpecificDatatypes>(actualJson, PlayFabUtil.ApiSerializerStrategy);

                testContext.ObjEquals(expectedObj.TestString, actualObject.TestString);
                testContext.SequenceEquals(expectedObj.IntDict, actualObject.IntDict);
                testContext.SequenceEquals(expectedObj.UintDict, actualObject.UintDict);
                testContext.SequenceEquals(expectedObj.StringDict, actualObject.StringDict);
                testContext.SequenceEquals(expectedObj.EnumDict, actualObject.EnumDict);

                testContext.EndTest(UUnitFinishState.PASSED, null);
            }
        }
    }
}

#region Delete this whole section after a few months
namespace PlayFab.Json
{
    [Obsolete("Use PlayFab.SimpleJson")]
    public static class JsonConvert
    {
        [Obsolete("Use PlayFab.JsonWrapper.SerializeObject()")]
        public static string SerializeObject(object obj)
        {
            return JsonWrapper.SerializeObject(obj, PlayFabUtil.ApiSerializerStrategy);
        }

        [Obsolete("Use PlayFab.JsonWrapper.DeserializeObject<t>()")]
        public static T DeserializeObject<T>(string json)
        {
            return JsonWrapper.DeserializeObject<T>(json, PlayFabUtil.ApiSerializerStrategy);
        }
    }

    public static class SimpleJson
    {
        [Obsolete("Use PlayFab.JsonWrapper.SerializeObject()")]
        public static string SerializeObject(object obj)
        {
            return JsonWrapper.SerializeObject(obj, PlayFabUtil.ApiSerializerStrategy);
        }

        [Obsolete("Use PlayFab.JsonWrapper.DeserializeObject<t>()")]
        public static T DeserializeObject<T>(string json)
        {
            return JsonWrapper.DeserializeObject<T>(json, PlayFabUtil.ApiSerializerStrategy);
        }
    }
}

namespace PlayFab
{
    public static class SimpleJson
    {
        [Obsolete("Use PlayFab.JsonWrapper.SerializeObject()")]
        public static string SerializeObject(object obj)
        {
            return JsonWrapper.SerializeObject(obj, PlayFabUtil.ApiSerializerStrategy);
        }

        [Obsolete("Use PlayFab.JsonWrapper.DeserializeObject<t>()")]
        public static T DeserializeObject<T>(string json)
        {
            return JsonWrapper.DeserializeObject<T>(json, PlayFabUtil.ApiSerializerStrategy);
        }
    }
}

namespace PlayFab.UUnit
{
    public class JsonLegacyTest : UUnitTestCase
    {
        private class JsonTest { public bool TestBool; }

        [UUnitTest]
        public void TestLegacyJsonNetSignature(UUnitTestContext testContext)
        {
            var expectedObj = new JsonTest { TestBool = true };
#pragma warning disable 0618
            var actualJson = PlayFab.Json.JsonConvert.SerializeObject(expectedObj);
            JsonTest actualObj = PlayFab.Json.JsonConvert.DeserializeObject<JsonTest>(actualJson);
            PlayFab.Json.JsonConvert.DeserializeObject<JsonTest>(actualJson);
#pragma warning restore 0618
            testContext.True(actualObj.TestBool);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        [UUnitTest]
        public void TestLegacySimpleJsonSignature(UUnitTestContext testContext)
        {
            var expectedObj = new JsonTest { TestBool = true };
#pragma warning disable 0618
            var actualJson = PlayFab.SimpleJson.SerializeObject(expectedObj);
            JsonTest actualObj = PlayFab.SimpleJson.DeserializeObject<JsonTest>(actualJson);
            PlayFab.SimpleJson.DeserializeObject<JsonTest>(actualJson);
#pragma warning restore 0618
            testContext.True(actualObj.TestBool);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        [UUnitTest]
        public void TestLegacySimpleJsonSignature2(UUnitTestContext testContext)
        {
            var expectedObj = new JsonTest { TestBool = true };
#pragma warning disable 0618
            var actualJson = PlayFab.Json.SimpleJson.SerializeObject(expectedObj);
            JsonTest actualObj = PlayFab.Json.SimpleJson.DeserializeObject<JsonTest>(actualJson);
            PlayFab.Json.SimpleJson.DeserializeObject<JsonTest>(actualJson);
#pragma warning restore 0618
            testContext.True(actualObj.TestBool);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }
    }
}
#endregion Delete this whole section after a few months
