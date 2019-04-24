// More information of original Interlocked you can find here.
// https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked?view=netframework-3.5

namespace System.Threading
{
    /// <summary>
    /// Custom implementation of System.Threading.Interlocked for Nintendo Switch.
    /// Allow thread safe operations.
    /// </summary>
    public static class CustomInterlocked
    {
#if UNITY_SWITCH
        private static object locker = new object();
#endif
        /// <summary>
        /// Increment location1 by one.
        /// </summary>
        /// <param name="location1">The variable whose value is to be incremented.</param>
        /// <returns>The new value stored at location1</returns>
        public static int Increment(ref int location1)
        {
#if UNITY_SWITCH
            return Add(ref location1, 1);
#else
            return Interlocked.Increment(ref location1);
#endif
        }

        /// <summary>
        /// Decrement location1 by one.
        /// </summary>
        /// <param name="location1">The value to be reduced.</param>
        /// <returns>The new value stored at location1</returns>
        public static int Decrement(ref int location1)
        {
#if UNITY_SWITCH
            return Add(ref location1, -1);
#else
            return Interlocked.Decrement(ref location1);
#endif
        }

        /// <summary>
        /// Increment location1 by one.
        /// </summary>
        /// <param name="location1">The variable whose value is to be incremented.</param>
        /// <returns>The new value stored at location1</returns>
        public static long Increment(ref long location1)
        {
#if UNITY_SWITCH
            return Add(ref location1, 1);
#else
            return Interlocked.Increment(ref location1);
#endif
        }

        /// <summary>
        /// Decrement location1 by one.
        /// </summary>
        /// <param name="location1">The value to be reduced.</param>
        /// <returns>The new value stored at location1</returns>
        public static long Decrement(ref long location1)
        {
#if UNITY_SWITCH
            return Add(ref location1, -1);
#else
            return Interlocked.Decrement(ref location1);
#endif
        }

        /// <summary>
        /// Compares two values for equality and, if they are equal, replaces the first value.
        /// </summary>
        /// <param name="location1">The destination, whose value is compared with comparand and possibly replaced.</param>
        /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
        /// <param name="comparand">The value that is compared to the value at location1.</param>
        /// <returns>The original value in location1.</returns>
        /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
        public static int CompareExchange(ref int location1, int value, int comparand)
        {
#if UNITY_SWITCH
            if (IsZeroPtr(location1))
            {
                throw new NullReferenceException("Passed value location1 is null.");
            }

            lock (locker)
            {
                var result = location1;
                if (location1 == comparand)
                {
                    location1 = value;
                }
                return result;
            }
#else
            return Interlocked.CompareExchange(ref location1, value, comparand);
#endif
        }

        /// <summary>
        /// Compares two values for equality and, if they are equal, replaces the first value.
        /// </summary>
        /// <param name="location1">The destination, whose value is compared with comparand and possibly replaced.</param>
        /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
        /// <param name="comparand">The value that is compared to the value at location1.</param>
        /// <returns>The original value in location1.</returns>
        /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
        public static object CompareExchange(ref object location1, object value, object comparand)
        {
#if UNITY_SWITCH
            if (IsZeroPtr(location1))
            {
                throw new NullReferenceException("Passed parameter location1 is null.");
            }

            lock (locker)
            {
                var result = location1;
                if (location1 == comparand)
                {
                    location1 = value;
                }
                return result;
            }
#else
            return Interlocked.CompareExchange(ref location1, value, comparand);
#endif
        }

        /// <summary>
        /// Adds two 32-bit integers and replaces the first integer with the sum.
        /// </summary>
        /// <param name="location1">A variable containing the first value to be added. The sum of the two values is stored in location1.</param>
        /// <param name="value">The value to be added to the integer at location1.</param>
        /// <returns>The new value stored at location1.</returns>
        /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
        public static int Add(ref int location1, int value)
        {
#if UNITY_SWITCH
            if (IsZeroPtr(location1))
            {
                throw new NullReferenceException("Passed value location1 is null.");
            }

            lock (locker)
            {
                location1 += value;
                return location1;
            }
#else
            return Interlocked.Add(ref location1, value);
#endif
        }

        /// <summary>
        /// Adds two 32-bit integers and replaces the first integer with the sum.
        /// </summary>
        /// <param name="location1">A variable containing the first value to be added. The sum of the two values is stored in location1.</param>
        /// <param name="value">The value to be added to the integer at location1.</param>
        /// <returns>The new value stored at location1.</returns>
        /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
        public static long Add(ref long location1, long value)
        {
#if UNITY_SWITCH
            if (IsZeroPtr(location1))
            {
                throw new NullReferenceException("Passed value location1 is null.");
            }

            lock (locker)
            {
                location1 += value;
                return location1;
            }
#else
            return Interlocked.Add(ref location1, value);
#endif
        }

        /// <summary>
        /// Sets a variable to a specified value.
        /// </summary>
        /// <param name="location1">The variable to set to the specified value.</param>
        /// <param name="value">The value to which the location1 parameter is set.</param>
        /// <returns>The original value of location1.</returns>
        /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
        public static int Exchange(ref int location1, int value)
        {
#if UNITY_SWITCH
            if (IsZeroPtr(location1))
            {
                throw new NullReferenceException("Passed value location1 is null.");
            }

            lock (locker)
            {
                var result = location1;
                location1 = value;
                return result;
            }
#else
            return Interlocked.Exchange(ref location1, value);
#endif
        }

        /// <summary>
        /// Sets a variable to a specified value.
        /// </summary>
        /// <param name="location1">The variable to set to the specified value.</param>
        /// <param name="value">The value to which the location1 parameter is set.</param>
        /// <returns>The original value of location1.</returns>
        /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
        public static object Exchange(ref object location1, object value)
        {
#if UNITY_SWITCH
            if (IsZeroPtr(location1))
            {
                throw new NullReferenceException("Passed parameter location1 is null.");
            }

            lock (locker)
            {
                var result = location1;
                location1 = value;
                return result;
            }
#else
            return Interlocked.Exchange(ref location1, value);
#endif
        }
    }
}