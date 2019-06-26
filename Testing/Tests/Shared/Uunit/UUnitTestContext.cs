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
    public enum UUnitActiveState
    {
        PENDING, // Not started
        ACTIVE, // Currently testing
        READY, // An answer is sent by the http thread, but the main thread hasn't finalized the test yet
        COMPLETE, // Test is finalized and recorded
        ABORTED // todo
    };

    public class UUnitTestContext
    {
        public const float DefaultFloatPrecision = 0.0001f;
        public const double DefaultDoublePrecision = 0.000001;

        public UUnitActiveState ActiveState;
        public UUnitFinishState FinishState;
        public readonly Action<UUnitTestContext> TestDelegate;
        public readonly UUnitTestCase TestInstance;
        public DateTime StartTime;
        public DateTime EndTime;
        public string TestResultMsg;
        public readonly string Name;

        public UUnitTestContext(UUnitTestCase testInstance, Action<UUnitTestContext> testDelegate, string name)
        {
            TestInstance = testInstance;
            TestDelegate = testDelegate;
            ActiveState = UUnitActiveState.PENDING;
            Name = name;
        }

        public void EndTest(UUnitFinishState finishState, string resultMsg)
        {
            // When a test is declared finished for the first time, apply it and return
            if (FinishState == UUnitFinishState.PENDING)
            {
                EndTime = DateTime.UtcNow;
                TestResultMsg = resultMsg;
                FinishState = finishState;
                ActiveState = UUnitActiveState.READY;
                return;
            }

            // Otherwise describe the additional end-state and fail the test
            TestResultMsg += "\n" + FinishState + "->" + finishState + " - Cannot declare test finished twice.";
            if (finishState == UUnitFinishState.FAILED && FinishState == UUnitFinishState.FAILED)
                TestResultMsg += "\nSecond message: " + resultMsg;
            FinishState = UUnitFinishState.FAILED;
        }

        public void Skip(string message = "")
        {
            EndTime = DateTime.UtcNow;
            EndTest(UUnitFinishState.SKIPPED, message);
            throw new UUnitSkipException(message);
        }

        public void Fail(string message = null)
        {
            if (string.IsNullOrEmpty(message))
                message = "fail";
            EndTest(UUnitFinishState.FAILED, message);
            throw new UUnitAssertException(message);
        }

        public void True(bool boolean, string message = null)
        {
            if (boolean)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: true, Actual: false";
            Fail(message);
        }

        public void False(bool boolean, string message = null)
        {
            if (!boolean)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: false, Actual: true";
            Fail(message);
        }

        public void NotNull(object something, string message = null)
        {
            if (something != null)
                return; // Success

            if (string.IsNullOrEmpty(message))
                message = "Null object";
            Fail(message);
        }

        public void IsNull(object something, string message = null)
        {
            if (something == null)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Not null object";
            Fail(message);
        }

        public void StringEquals(string wanted, string got, string message = null)
        {
            if (wanted == got)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void SbyteEquals(sbyte? wanted, sbyte? got, string message = null)
        {
            if (NullableEquals(wanted, got))
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void ByteEquals(byte? wanted, byte? got, string message = null)
        {
            if (NullableEquals(wanted, got))
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void ShortEquals(short? wanted, short? got, string message = null)
        {
            if (NullableEquals(wanted, got))
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void UshortEquals(ushort? wanted, ushort? got, string message = null)
        {
            if (NullableEquals(wanted, got))
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void IntEquals(int? wanted, int? got, string message = null)
        {
            if (NullableEquals(wanted, got))
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void UintEquals(uint? wanted, uint? got, string message = null)
        {
            if (NullableEquals(wanted, got))
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void LongEquals(long? wanted, long? got, string message = null)
        {
            if (NullableEquals(wanted, got))
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void ULongEquals(ulong? wanted, ulong? got, string message = null)
        {
            if (NullableEquals(wanted, got))
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void FloatEquals(float? wanted, float? got, float precision = DefaultFloatPrecision, string message = null)
        {
            if (!wanted.HasValue && !got.HasValue)
                return;
            if (wanted.HasValue && got.HasValue && Math.Abs(wanted.Value - got.Value) < precision)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void DoubleEquals(double? wanted, double? got, double precision = DefaultDoublePrecision, string message = null)
        {
            if (!wanted.HasValue && !got.HasValue)
                return;
            if (wanted.HasValue && got.HasValue && Math.Abs(wanted.Value - got.Value) < precision)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void DateTimeEquals(DateTime? wanted, DateTime? got, TimeSpan precision, string message = null)
        {
            if (!wanted.HasValue && !got.HasValue)
                return;
            if (wanted.HasValue && got.HasValue
                && wanted + precision > got
                && got + precision > wanted)
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void ObjEquals(object wanted, object got, string message = null)
        {
            if (wanted == null && got == null)
                return;
            if (wanted != null && got != null && wanted.Equals(got))
                return;

            if (string.IsNullOrEmpty(message))
                message = "Expected: " + wanted + ", Actual: " + got;
            Fail(message);
        }

        public void SequenceEquals<T>(IEnumerable<T> wanted, IEnumerable<T> got, string message = null)
        {
            var wEnum = wanted.GetEnumerator();
            var gEnum = got.GetEnumerator();

            bool wNext, gNext;
            var count = 0;
            while (true)
            {
                wNext = wEnum.MoveNext();
                gNext = gEnum.MoveNext();
                if (wNext != gNext)
                    Fail(message);
                if (!wNext)
                    break;
                count++;
                ObjEquals(wEnum.Current, gEnum.Current, "Element at " + count + ": " + message);
            }
        }

        private static bool NullableEquals<T>(T? left, T? right) where T : struct
        {
            // If both have a value, return whether the values match.
            if (left.HasValue && right.HasValue)
                return left.Value.Equals(right.Value);

            // If neither has a value, return true. If only one does, return false.
            return !left.HasValue && !right.HasValue;
        }
    }
}
