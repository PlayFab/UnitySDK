/*
 * UUnit system from UnityCommunity
 * Heavily modified
 * 0.4 release by pboechat
 * http://wiki.unity3d.com/index.php?title=UUnit
 * http://creativecommons.org/licenses/by-sa/3.0/
*/

using System;

namespace PlayFab.UUnit
{
    public static class UUnitAssert
    {
        public const double DEFAULT_DOUBLE_PRECISION = 0.000001;

        public static void Skip()
        {
            throw new UUnitSkipException();
        }

        public static void Fail(string message = null)
        {
            if (string.IsNullOrEmpty(message))
                message = "fail";
            throw new UUnitAssertException(message);
        }

        public static void True(bool boolean, string message = null)
        {
            if (boolean)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: true, Actual: false";
            throw new UUnitAssertException(true, false, message);
        }

        public static void False(bool boolean, string message = null)
        {
            if (!boolean)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: false, Actual: true";
            throw new UUnitAssertException(true, false, message);
        }

        public static void NotNull(object something, string message = null)
        {
            if (something != null)
                return; // Success

            if (string.IsNullOrEmpty(message))
                message = "Null object";
            throw new UUnitAssertException(message);
        }

        public static void Null(object something, string message = null)
        {
            if (something == null)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Not null object";
            throw new UUnitAssertException(message);
        }

        public static void Equals(string wanted, string got, string message = null)
        {
            if (wanted == got)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void Equals(int wanted, int got, string message = null)
        {
            if (wanted == got)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void DblEquals(double wanted, double got, double precision = DEFAULT_DOUBLE_PRECISION, string message = null)
        {
            if (Math.Abs(wanted - got) < precision)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void ObjEquals(object wanted, object got, string message = null)
        {
            if (wanted.Equals(got))
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }
    }
}
