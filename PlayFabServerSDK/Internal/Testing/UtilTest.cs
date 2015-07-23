using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PlayFab.Internal
{
    class uu_Util : UUnitTestCase
    {
        [UUnitTest]
        void TimeStampFormat()
        {
            string actualTimestamp = Util.timeStamp;
            string expectedRegex = "[0-9][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9] [0-9][0-9]:[0-9][0-9]\\.[0-9][0-9]\\.[0-9][0-9]";
            var result = Regex.Match(actualTimestamp, expectedRegex);
            UUnitAssert.True(result.Success, actualTimestamp);
        }
    }
}
