#region License
/*---------------------------------------------------------------------------------*\

	Distributed under the terms of an MIT-style license:

	The MIT License

	Copyright (c) 2006-2009 Stephen M. McKamey

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in
	all copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.

\*---------------------------------------------------------------------------------*/
#endregion License

using System;
using System.Collections.Generic;

#if WINDOWS_STORE
using TP = System.Reflection.TypeInfo;
#else
using TP = System.Type;
#endif

namespace PlayFab.Serialization.JsonFx
{

	public interface IDataReaderProvider
	{
		IDataReader Find(string contentTypeHeader);
	}

	/// <summary>
	/// Provides lookup capabilities for finding an IDataReader
	/// </summary>
	public class DataReaderProvider : IDataReaderProvider
	{
		#region Fields

		private readonly IDictionary<string, IDataReader> ReadersByMime = new Dictionary<string, IDataReader>(StringComparer.OrdinalIgnoreCase);

		#endregion Fields

		#region Init

		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="readers">inject with all possible readers</param>
		public DataReaderProvider(IEnumerable<IDataReader> readers)
		{
			if (readers != null)
			{
				foreach (IDataReader reader in readers)
				{
					if (!String.IsNullOrEmpty(reader.ContentType))
					{
						this.ReadersByMime[reader.ContentType] = reader;
					}
				}
			}
		}

		#endregion Init

		#region Methods

		/// <summary>
		/// Finds an IDataReader by content-type header
		/// </summary>
		/// <param name="contentTypeHeader"></param>
		/// <returns></returns>
		public IDataReader Find(string contentTypeHeader)
		{
			string type = DataWriterProvider.ParseMediaType(contentTypeHeader);

			if (this.ReadersByMime.ContainsKey(type))
			{
				return ReadersByMime[type];
			}

			return null;
		}

		#endregion Methods
	}
}
