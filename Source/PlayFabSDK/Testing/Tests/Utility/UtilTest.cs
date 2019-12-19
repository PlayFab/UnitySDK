using PlayFab.UUnit;
using System;
using System.Globalization;
using System.Collections.Generic;

namespace PlayFab.Internal
{
    class GMFB_327 : UUnitTestCase
    {
        private class ObjWithTimes
        {
            public DateTime timestamp = DateTime.UtcNow;
        }

        private readonly string[] _examples = {
            "2015-08-25T10:22:01.654321Z",
            "2015-08-25T10:22:01.8642Z",
            "2015-08-25T10:22:01.753Z",
            "2015-08-25T10:22:01.71Z",
            "2015-08-25T10:22:01Z",

            "2015-08-25 10:22:01.654321",
            "2015-08-25 10:22:01.8642",
            "2015-08-25 10:22:01.753",
            "2015-08-25 10:22:01.71",
            "2015-08-25 10:22:01",

            "2015-08-25 10:22.01.8642",
            "2015-08-25 10:22.01.753",
            "2015-08-25 10:22.01.71",
            "2015-08-25 10:22.01",

            PlayFabUtil.timeStamp,
            PlayFabUtil.utcTimeStamp,
            // The standard DateTime.ToString() uses slashes instead of dashes, and is currently unsupported
        };

        //[UUnitTest]
        void TimeStampHandlesAllFormats(UUnitTestContext testContext)
        {
            DateTime actualTime;
            var formats = PlayFabUtil._defaultDateTimeFormats;

            for (var i = 0; i < _examples.Length; i++)
            {
                var expectedFormat = i < formats.Length ? formats[i] : "default";
                testContext.True(DateTime.TryParseExact(_examples[i], formats, CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out actualTime), "Index: " + i + "/" + _examples.Length + ", " + _examples[i] + " with " + expectedFormat);
            }

            var expectedTime = DateTime.Now;
            for (var i = 0; i < formats.Length; i++)
            {
                var timeString = expectedTime.ToString(formats[i], CultureInfo.CurrentCulture);
                testContext.True(DateTime.TryParseExact(timeString, formats, CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out actualTime), "Index: " + i + "/" + formats.Length + ", " + formats[i] + " with " + timeString);
                testContext.True((actualTime - expectedTime).TotalSeconds < 1, "Expected: " + expectedTime + " vs actual:" + actualTime);
            }
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        //[UUnitTest]
        void JsonTimeStampHandlesAllFormats(UUnitTestContext testContext)
        {
            string expectedJson, actualJson;
            DateTime expectedTime;
            ObjWithTimes actualObj;

            for (var i = 0; i < _examples.Length; i++)
            {
                // Define the time deserialization expectation
                testContext.True(DateTime.TryParseExact(_examples[i], PlayFabUtil._defaultDateTimeFormats, CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out expectedTime), "Index: " + i + "/" + _examples.Length + ", " + _examples[i]);

                // De-serialize the time using json
                expectedJson = "{\"timestamp\":\"" + _examples[i] + "\"}"; // We are provided a json string with every random time format
                actualObj = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<ObjWithTimes>(expectedJson);
                actualJson = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(actualObj);

                if (i == PlayFabUtil.DEFAULT_UTC_OUTPUT_INDEX) // This is the only case where the json input will match the json output
                    testContext.StringEquals(expectedJson, actualJson);

                // Verify that the times match
                var diff = (expectedTime - actualObj.timestamp).TotalSeconds; // We expect that we have parsed the time correctly according to expectations
                testContext.True(diff < 1,
                    "\nActual time: " + actualObj.timestamp + " vs Expected time: " + expectedTime + ", diff: " + diff +
                    "\nActual json: " + actualJson + " vs Expected json: " + expectedJson
                );
            }
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        private enum testRegion
        {
            USCentral,
            USEast,
            EUWest,
            Singapore,
            Japan,
            Brazil,
            Australia
        }
        private class EnumConversionTestClass
        {
            public List<testRegion> enumList;
            public testRegion[] enumArray;
            public testRegion enumValue;
            public testRegion? optEnumValue;

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(obj, null) || !(obj is EnumConversionTestClass))
                    return false;
                var other = (EnumConversionTestClass)obj;
                if (enumList.Count != other.enumList.Count || enumArray.Length != other.enumArray.Length)
                    return false;

                for (var i = 0; i < enumList.Count; i++)
                    if (enumList[i] != other.enumList[i])
                        return false;
                for (var i = 0; i < enumArray.Length; i++)
                    if (enumArray[i] != other.enumArray[i])
                        return false;
                if (enumValue != other.enumValue || optEnumValue != other.optEnumValue)
                    return false;

                return true;
            }

            public override int GetHashCode()
            {
                throw new NotImplementedException("EnumListTest is a test class, and not designed to be hashed.");
            }
        }
        /// <summary>
        /// Test that enum lists json-serialize and de-serialize correctly
        /// </summary>
        //[UUnitTest]
        public void EnumConversionTest_Serialize(UUnitTestContext testContext)
        {
            string expectedJson, actualJson;
            EnumConversionTestClass expectedObj = new EnumConversionTestClass(), actualObj;
            expectedObj.enumList = new List<testRegion>() { testRegion.USEast, testRegion.USCentral, testRegion.Japan };
            expectedObj.enumArray = new testRegion[] { testRegion.USEast, testRegion.USCentral, testRegion.Japan };
            expectedObj.enumValue = testRegion.Australia;
            expectedObj.optEnumValue = null;

            expectedJson = "{\"enumList\":[\"USEast\",\"USCentral\",\"Japan\"],\"enumArray\":[\"USEast\",\"USCentral\",\"Japan\"],\"enumValue\":\"Australia\",\"optEnumValue\":null}";

            actualObj = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<EnumConversionTestClass>(expectedJson);
            actualJson = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(actualObj);

            testContext.StringEquals(expectedJson.Replace(" ", "").Replace("\n", ""), actualJson.Replace(" ", "").Replace("\n", ""));
            testContext.ObjEquals(expectedObj, actualObj);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// Test that enum lists json-serialize and de-serialize correctly
        /// </summary>
        //[UUnitTest]
        public void EnumConversionTest_Deserialize(UUnitTestContext testContext)
        {
            EnumConversionTestClass expectedObj = new EnumConversionTestClass(), actualObj;
            expectedObj.enumList = new List<testRegion>() { testRegion.USEast, testRegion.USCentral, testRegion.Japan };
            expectedObj.enumArray = new testRegion[] { testRegion.USEast, testRegion.USCentral, testRegion.Japan };
            expectedObj.enumValue = testRegion.Australia;
            expectedObj.optEnumValue = null;

            var inputJson = "{\"enumList\":[" + ((int)testRegion.USEast) + "," + ((int)testRegion.USCentral) + "," + ((int)testRegion.Japan) + "],\"enumArray\":[" + ((int)testRegion.USEast) + "," + ((int)testRegion.USCentral) + "," + ((int)testRegion.Japan) + "],\"enumValue\":" + ((int)testRegion.Australia) + "}";
            actualObj = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<EnumConversionTestClass>(inputJson);
            testContext.ObjEquals(expectedObj, actualObj);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        //[UUnitTest]
        public void EnumConversionTest_OptionalEnum(UUnitTestContext testContext)
        {
            var expectedObj = new EnumConversionTestClass
            {
                enumList = new List<testRegion>() { testRegion.USEast, testRegion.USCentral, testRegion.Japan },
                enumArray = new testRegion[] { testRegion.USEast, testRegion.USCentral, testRegion.Japan },
                enumValue = testRegion.Australia,
                optEnumValue = null,
            };

            var actualJson = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(expectedObj);
            var actualObj = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<EnumConversionTestClass>(actualJson);
            testContext.ObjEquals(expectedObj, actualObj);

            expectedObj.optEnumValue = testRegion.Brazil;
            actualJson = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(expectedObj);
            actualObj = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<EnumConversionTestClass>(actualJson);
            testContext.ObjEquals(expectedObj, actualObj);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }
    }
}
