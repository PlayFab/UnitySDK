using PlayFab.Json;
using PlayFab.Json.Converters;
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

        private string[] examples = new string[]{
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
            DateTime expectedTime, actualTime;
            var formats = IsoDateTimeConverter._defaultDateTimeFormats;

            for (int i = 0; i < examples.Length; i++)
            {
                string expectedFormat = i < formats.Length ? formats[i] : "default";
                UUnitAssert.True(DateTime.TryParseExact(examples[i], formats, CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out actualTime), "Index: " + i + "/" + examples.Length + ", " + examples[i] + " with " + expectedFormat);
            }

            expectedTime = DateTime.Now;
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

            for (int i = 0; i < examples.Length; i++)
            {
                // Define the time deserialization expectation
                UUnitAssert.True(DateTime.TryParseExact(examples[i], IsoDateTimeConverter._defaultDateTimeFormats, CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out expectedTime), "Index: " + i + "/" + examples.Length + ", " + examples[i]);

                // De-serialize the time using json
                expectedJson = "{\"timestamp\":\"" + examples[i] + "\"}"; // We are provided a json string with every random time format
                JsonConvert.PopulateObject(expectedJson, actualObj, Util.JsonSettings);
                actualJson = JsonConvert.SerializeObject(actualObj, Util.JsonFormatting, Util.JsonSettings);

                if (i == IsoDateTimeConverter.DEFAULT_UTC_OUTPUT_INDEX) // This is the only case where the json input will match the json output
                    UUnitAssert.Equals(expectedJson, actualJson);

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
        void EnumConversionTest()
        {
            string expectedJson, actualJson;
            EnumConversionTestClass expectedObj = new EnumConversionTestClass(), actualObj = new EnumConversionTestClass();
            expectedObj.enumList = new List<testRegion>() { testRegion.USEast, testRegion.USCentral, testRegion.Japan };
            expectedObj.enumArray = new testRegion[] { testRegion.USEast, testRegion.USCentral, testRegion.Japan };
            expectedObj.enumValue = testRegion.Australia;

            expectedJson = "{\"enumList\":[\"USEast\",\"USCentral\",\"Japan\"],\"enumArray\":[\"USEast\",\"USCentral\",\"Japan\"],\"enumValue\":\"Australia\"}";

            JsonConvert.PopulateObject(expectedJson, actualObj, Util.JsonSettings);
            actualJson = JsonConvert.SerializeObject(actualObj, Util.JsonFormatting, Util.JsonSettings);

            UUnitAssert.Equals(expectedJson.Replace(" ", "").Replace("\n", ""), actualJson.Replace(" ", "").Replace("\n", ""));
            UUnitAssert.ObjEquals(expectedObj, actualObj);
        }
    }
}
