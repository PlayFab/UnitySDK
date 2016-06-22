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
    /// <summary>
    /// Throw this exception, via UUnitAssert utility function, in order to define when a test has been skipped.
    /// The only information shown will be the "skipped" notification
    /// </summary>
    public class UUnitSkipException : Exception { }

        /// <summary>
    /// Throw this exception, via UUnitAssert utility functions, in order to define when a test has failed.
    /// The traceback and message will automatically be displayed as a failure
    /// </summary>
    public class UUnitAssertException : Exception
    {
        public object expected;
        public object received;
        public string message;

        public UUnitAssertException(string message)
            : base(message)
        {
            this.message = message;
        }

        public UUnitAssertException(object expected, object received, string message)
            : base("[UUnit] - Assert Failed - Expected: " + expected + " Received: " + received + "\n\t\t(" + message + ")")
        {
            this.expected = (expected == null) ? "null" : expected;
            this.received = (received == null) ? "null" : received;
            this.message = (message == null) ? "" : message;
        }

        public UUnitAssertException(object expected, object received)
            : base("[UUnit] - Assert Failed - Expected: " + expected + " Received: " + received)
        {
            this.expected = (expected == null) ? "null" : expected;
            this.received = (received == null) ? "null" : received;
        }
    }
}