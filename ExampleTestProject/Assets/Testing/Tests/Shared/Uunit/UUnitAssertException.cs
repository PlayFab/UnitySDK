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
    /// The internal uunit exception base class, which you can use to capture all UUnit exceptions
    /// </summary>
    public class UUnitException : Exception
    {
        protected UUnitException(string message) : base(message) { }
    }

    /// <summary>
    /// Throw this exception, via UUnitAssert utility function, in order to define when a test has been skipped.
    /// The only information shown will be the "skipped" notification
    /// </summary>
    public class UUnitSkipException : UUnitException
    {
        public UUnitSkipException(string message) : base(message) { }
    }

    /// <summary>
    /// Throw this exception, via UUnitAssert utility functions, in order to define when a test has failed.
    /// The traceback and Message will automatically be displayed as a failure
    /// </summary>
    public class UUnitAssertException : UUnitException
    {
        public UUnitAssertException(string message) : base(message) { }
    }
}
