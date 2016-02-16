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

            Util.timeStamp,
            Util.utcTimeStamp,
            // The standard DateTime.ToString() uses slashes instead of dashes, and is currently unsupported
        };

        [UUnitTest]
        void TimeStampHandlesAllFormats()
        {
            DateTime actualTime;
            var formats = Util._defaultDateTimeFormats;

            for (int i = 0; i < _examples.Length; i++)
            {
                string expectedFormat = i < formats.Length ? formats[i] : "default";
                UUnitAssert.True(DateTime.TryParseExact(_examples[i], formats, CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out actualTime), "Index: " + i + "/" + _examples.Length + ", " + _examples[i] + " with " + expectedFormat);
            }

            DateTime expectedTime = DateTime.Now;
            for (int i = 0; i < formats.Length; i++)
            {
                string timeString = expectedTime.ToString(formats[i], CultureInfo.CurrentCulture);
                UUnitAssert.True(DateTime.TryParseExact(timeString, formats, CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out actualTime), "Index: " + i + "/" + formats.Length + ", " + formats[i] + " with " + timeString);
                UUnitAssert.True((actualTime - expectedTime).TotalSeconds < 1, "Expected: " + expectedTime + " vs actual:" + actualTime);
            }
        }

        [UUnitTest]
        void JsonTimeStampHandlesAllFormats()
        {
            string expectedJson, actualJson;
            DateTime expectedTime;
            ObjWithTimes actualObj = new ObjWithTimes();

            for (int i = 0; i < _examples.Length; i++)
            {
                // Define the time deserialization expectation
                UUnitAssert.True(DateTime.TryParseExact(_examples[i], Util._defaultDateTimeFormats, CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out expectedTime), "Index: " + i + "/" + _examples.Length + ", " + _examples[i]);

                // De-serialize the time using json
                expectedJson = "{\"timestamp\":\"" + _examples[i] + "\"}"; // We are provided a json string with every random time format
                actualObj = SimpleJson.DeserializeObject<ObjWithTimes>(expectedJson, Util.ApiSerializerStrategy);
                actualJson = SimpleJson.SerializeObject(actualObj, Util.ApiSerializerStrategy);

                if (i == Util.DEFAULT_UTC_OUTPUT_INDEX) // This is the only case where the json input will match the json output
                    UUnitAssert.StringEquals(expectedJson, actualJson);

                // Verify that the times match
                double diff = (expectedTime - actualObj.timestamp).TotalSeconds; // We expect that we have parsed the time correctly according to expectations
                UUnitAssert.True(diff < 1,
                    "\nActual time: " + actualObj.timestamp + " vs expected time: " + expectedTime + ", diff: " + diff +
                    "\nActual json: " + actualJson + " vs expected json: " + expectedJson
                );
            }
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
                if (object.ReferenceEquals(obj, null) || !(obj is EnumConversionTestClass))
                    return false;
                EnumConversionTestClass other = (EnumConversionTestClass)obj;
                if (enumList.Count != other.enumList.Count || enumArray.Length != other.enumArray.Length)
                    return false;

                for (int i = 0; i < enumList.Count; i++)
                    if (enumList[i] != other.enumList[i])
                        return false;
                for (int i = 0; i < enumArray.Length; i++)
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
        [UUnitTest]
        void EnumConversionTest_Serialize()
        {
            string expectedJson, actualJson;
            EnumConversionTestClass expectedObj = new EnumConversionTestClass(), actualObj;
            expectedObj.enumList = new List<testRegion>() { testRegion.USEast, testRegion.USCentral, testRegion.Japan };
            expectedObj.enumArray = new testRegion[] { testRegion.USEast, testRegion.USCentral, testRegion.Japan };
            expectedObj.enumValue = testRegion.Australia;
            expectedObj.optEnumValue = null;

            expectedJson = "{\"enumList\":[\"USEast\",\"USCentral\",\"Japan\"],\"enumArray\":[\"USEast\",\"USCentral\",\"Japan\"],\"enumValue\":\"Australia\",\"optEnumValue\":null}";

            actualObj = SimpleJson.DeserializeObject<EnumConversionTestClass>(expectedJson, Util.ApiSerializerStrategy);
            actualJson = SimpleJson.SerializeObject(actualObj, Util.ApiSerializerStrategy);

            UUnitAssert.StringEquals(expectedJson.Replace(" ", "").Replace("\n", ""), actualJson.Replace(" ", "").Replace("\n", ""));
            UUnitAssert.ObjEquals(expectedObj, actualObj);
        }

        /// <summary>
        /// Test that enum lists json-serialize and de-serialize correctly
        /// </summary>
        [UUnitTest]
        void EnumConversionTest_Deserialize()
        {
            EnumConversionTestClass expectedObj = new EnumConversionTestClass(), actualObj;
            expectedObj.enumList = new List<testRegion>() { testRegion.USEast, testRegion.USCentral, testRegion.Japan };
            expectedObj.enumArray = new testRegion[] { testRegion.USEast, testRegion.USCentral, testRegion.Japan };
            expectedObj.enumValue = testRegion.Australia;
            expectedObj.optEnumValue = null;

            string inputJson = "{\"enumList\":[" + ((int)testRegion.USEast) + "," + ((int)testRegion.USCentral) + "," + ((int)testRegion.Japan) + "],\"enumArray\":[" + ((int)testRegion.USEast) + "," + ((int)testRegion.USCentral) + "," + ((int)testRegion.Japan) + "],\"enumValue\":" + ((int)testRegion.Australia) + "}";
            actualObj = SimpleJson.DeserializeObject<EnumConversionTestClass>(inputJson, Util.ApiSerializerStrategy);
            UUnitAssert.ObjEquals(expectedObj, actualObj);
        }

        [UUnitTest]
        void EnumConversionTest_OptionalEnum()
        {
            EnumConversionTestClass expectedObj = new EnumConversionTestClass();
            expectedObj.enumList = new List<testRegion>() { testRegion.USEast, testRegion.USCentral, testRegion.Japan };
            expectedObj.enumArray = new testRegion[] { testRegion.USEast, testRegion.USCentral, testRegion.Japan };
            expectedObj.enumValue = testRegion.Australia;
            expectedObj.optEnumValue = null;

            var actualJson = SimpleJson.SerializeObject(expectedObj, Util.ApiSerializerStrategy);
            var actualObj = SimpleJson.DeserializeObject<EnumConversionTestClass>(actualJson, Util.ApiSerializerStrategy);
            UUnitAssert.ObjEquals(expectedObj, actualObj);

            expectedObj.optEnumValue = testRegion.Brazil;
            actualJson = SimpleJson.SerializeObject(expectedObj, Util.ApiSerializerStrategy);
            actualObj = SimpleJson.DeserializeObject<EnumConversionTestClass>(actualJson, Util.ApiSerializerStrategy);
            UUnitAssert.ObjEquals(expectedObj, actualObj);
        }
    }
}
