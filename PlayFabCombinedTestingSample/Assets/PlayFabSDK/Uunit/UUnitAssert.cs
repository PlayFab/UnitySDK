/*
 * UUnit system from UnityCommunity
 * Heavily modified
 * 0.4 release by pboechat
 * http://wiki.unity3d.com/index.php?title=UUnit
 * http://creativecommons.org/licenses/by-sa/3.0/
*/

using System;
using System.Collections.Generic;

namespace PlayFab.UUnit
{
    public static class UUnitAssert
    {
        public const float DEFAULT_FLOAT_PRECISION = 0.0001f;
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

        public static void IsNull(object something, string message = null)
        {
            if (something == null)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Not null object";
            throw new UUnitAssertException(message);
        }

        public static void StringEquals(string wanted, string got, string message = null)
        {
            if (wanted == got)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void SbyteEquals(sbyte? wanted, sbyte? got, string message = null)
        {
            if (wanted == got)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void ByteEquals(byte? wanted, byte? got, string message = null)
        {
            if (wanted == got)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void ShortEquals(short? wanted, short? got, string message = null)
        {
            if (wanted == got)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void UshortEquals(ushort? wanted, ushort? got, string message = null)
        {
            if (wanted == got)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void IntEquals(int? wanted, int? got, string message = null)
        {
            if (wanted == got)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void UintEquals(uint? wanted, uint? got, string message = null)
        {
            if (wanted == got)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void LongEquals(long? wanted, long? got, string message = null)
        {
            if (wanted == got)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void ULongEquals(ulong? wanted, ulong? got, string message = null)
        {
            if (wanted == got)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void FloatEquals(float? wanted, float? got, float precision = DEFAULT_FLOAT_PRECISION, string message = null)
        {
            if (wanted == null && got == null)
                return;
            if (wanted != null && got != null && Math.Abs(wanted.Value - got.Value) < precision)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void DoubleEquals(double? wanted, double? got, double precision = DEFAULT_DOUBLE_PRECISION, string message = null)
        {
            if (wanted == null && got == null)
                return;
            if (wanted != null && got != null && Math.Abs(wanted.Value - got.Value) < precision)
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

        public static void SequenceEquals<T>(IEnumerable<T> wanted, IEnumerable<T> got, string message = null)
        {
            var wEnum = wanted.GetEnumerator();
            var gEnum = got.GetEnumerator();

            bool wNext, gNext;
            int count = 0;
            while (true)
            {
                wNext = wEnum.MoveNext();
                gNext = gEnum.MoveNext();
                if (wNext != gNext)
                    throw new UUnitAssertException(wanted, got, "Length mismatch: " + message);
                if (!wNext)
                    break;
                count++;
                ObjEquals(wEnum.Current, gEnum.Current, "Element at " + count + ": " + message);
            }
        }
    }
}
