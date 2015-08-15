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
    public class UUnitAssert
    {
        public static double DEFAULT_DOUBLE_PRECISION = 0.000001;

        private UUnitAssert()
        {
        }

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
            {
                return;
            }
            if (string.IsNullOrEmpty(message))
                throw new UUnitAssertException(true, false);
            else
                throw new UUnitAssertException(true, false, message);
        }

        public static void False(bool boolean, string message = null)
        {
            if (!boolean)
            {
                return;
            }
            if (string.IsNullOrEmpty(message))
                throw new UUnitAssertException(true, false);
            else
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

        public static void Equals(string wanted, string got, string message)
        {
            if (wanted == got)
            {
                return;
            }
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void Equals(string wanted, string got)
        {
            if (wanted == got)
                return;
            throw new UUnitAssertException(wanted, got);
        }

        public static void Equals(int wanted, int got, string message)
        {
            if (wanted == got)
            {
                return;
            }
            throw new UUnitAssertException(wanted, got, message);
        }

        public static void Equals(int wanted, int got)
        {
            if (wanted == got)
            {
                return;
            }
            throw new UUnitAssertException(wanted, got);
        }

        public static void Equals(double wanted, double got, double precision)
        {
            if (Math.Abs(wanted - got) < precision)
            {
                return;
            }
            throw new UUnitAssertException(wanted, got);
        }

        public static void Equals(double wanted, double got)
        {
            Equals(wanted, got, DEFAULT_DOUBLE_PRECISION);
        }

        public static void Equals(char wanted, char got)
        {
            if (wanted == got)
            {
                return;
            }
            throw new UUnitAssertException(wanted, got);
        }

        public static void Equals(object wanted, object got, string message)
        {
            if (wanted == got)
            {
                return;
            }
            throw new UUnitAssertException(wanted, got, message);
        }

        public new static void Equals(object wanted, object got)
        {
            if (wanted == got)
            {
                return;
            }
            throw new UUnitAssertException(wanted, got);
        }
    }
}