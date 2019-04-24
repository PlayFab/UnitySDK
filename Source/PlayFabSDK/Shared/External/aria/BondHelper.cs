using System;
using System.IO;
using UnityEngine;

// This is part of Aria SDK

namespace Microsoft.Applications.Events
{
    /// <summary>
    /// BondHelper class provides methods to Serialize and get the size of an event
    /// </summary>
    internal static class BondHelper
    {
        /// <summary>
        /// Serialize an object and returns an Stream as a result of the bond serialization
        /// </summary>
        /// <param name="objToSerialize"></param>
        /// <param name="outStream"></param>
        public static void Serialize(DataModels.CsEvent objToSerialize, MemoryStream outStream)
        {
            try
            {
                CompactBinaryProtocolWriter newWriter = new CompactBinaryProtocolWriter();
                MiniBond.Serialize(newWriter, objToSerialize, false);
                outStream.Write(newWriter.Data.ToArray(), 0, newWriter.Data.Count);
            }
            catch
            {
                Debug.LogError("Failed to serialize");
            }
        }
    }
}
