using System;
using UnityEngine;

// This is part of Aria SDK

namespace Microsoft.Applications.Events
{
    class Utils
    {
        private static readonly long TICKS_AT_1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

        /// <summary>
        /// Calculates milliseconds since 1970
        /// </summary>
        /// <returns>Milliseconds since 1970</returns>
        public static long MsFrom1970()
        {
            return (DateTime.UtcNow.Ticks - TICKS_AT_1970) / 10000;
        }

        /// <summary>
        /// Calculates milliseconds since 1970
        /// </summary>
        /// <returns>Milliseconds since 1970</returns>
        public static long TimestampNowTicks()
        {
            return DateTime.UtcNow.Ticks;
        }

        public static string TenantID(string tenant)
        {
            try
            {
                var endIndex = tenant.IndexOf("-", StringComparison.Ordinal);
                if (endIndex > 0)
                    return tenant.Substring(0, endIndex);
            }
            catch
            {
                Debug.LogError("Failed to convert tenantId");
            }

            return string.Empty;
        }
    }
}
