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
using System.IO;

#if WINDOWS_STORE
using TP = System.Reflection.TypeInfo;
#else
using TP = System.Type;
#endif

namespace PlayFab.Serialization.JsonFx
{
	public interface IDataWriterProvider
	{
		IDataWriter DefaultDataWriter { get; }

		IDataWriter Find(string extension);

		IDataWriter Find(string acceptHeader, string contentTypeHeader);
	}

	/// <summary>
	/// Provides lookup capabilities for finding an IDataWriter
	/// </summary>
	public class DataWriterProvider : IDataWriterProvider
	{
		#region Fields

		private readonly IDataWriter DefaultWriter;
		private readonly IDictionary<string, IDataWriter> WritersByExt = new Dictionary<string, IDataWriter>(StringComparer.OrdinalIgnoreCase);
		private readonly IDictionary<string, IDataWriter> WritersByMime = new Dictionary<string, IDataWriter>(StringComparer.OrdinalIgnoreCase);

		#endregion Fields

		#region Init

		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="writers">inject with all possible writers</param>
		public DataWriterProvider(IEnumerable<IDataWriter> writers)
		{
			if (writers != null)
			{
				foreach (IDataWriter writer in writers)
				{
					if (this.DefaultWriter == null)
					{
						// TODO: decide less arbitrary way to choose default
						// without hardcoding value into IDataWriter
						this.DefaultWriter = writer;
					}

					if (!String.IsNullOrEmpty(writer.ContentType))
					{
						this.WritersByMime[writer.ContentType] = writer;
					}

					if (!String.IsNullOrEmpty(writer.ContentType))
					{
						string ext = DataWriterProvider.NormalizeExtension(writer.FileExtension);
						this.WritersByExt[ext] = writer;
					}
				}
			}
		}

		#endregion Init

		#region Properties

		public IDataWriter DefaultDataWriter
		{
			get { return this.DefaultWriter; }
		}

		#endregion Properties

		#region Methods

		public IDataWriter Find(string extension)
		{
			extension = DataWriterProvider.NormalizeExtension(extension);

			if (this.WritersByExt.ContainsKey(extension))
			{
				return WritersByExt[extension];
			}

			return null;
		}

		public IDataWriter Find(string acceptHeader, string contentTypeHeader)
		{
			foreach (string type in DataWriterProvider.ParseHeaders(acceptHeader, contentTypeHeader))
			{
				if (this.WritersByMime.ContainsKey(type))
				{
					return WritersByMime[type];
				}
			}

			return null;
		}

		#endregion Methods

		#region Utility Methods

		/// <summary>
		/// Parses HTTP headers for Media-Types
		/// </summary>
		/// <param name="accept">HTTP Accept header</param>
		/// <param name="contentType">HTTP Content-Type header</param>
		/// <returns>sequence of Media-Types</returns>
		/// <remarks>
		/// http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html
		/// </remarks>
		public static IEnumerable<string> ParseHeaders(string accept, string contentType)
		{
			string mime;

			// check for a matching accept type
			foreach (string type in DataWriterProvider.SplitTrim(accept, ','))
			{
				mime = DataWriterProvider.ParseMediaType(type);
				if (!String.IsNullOrEmpty(mime))
				{
					yield return mime;
				}
			}

			// fallback on content-type
			mime = DataWriterProvider.ParseMediaType(contentType);
			if (!String.IsNullOrEmpty(mime))
			{
				yield return mime;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static string ParseMediaType(string type)
		{
			foreach (string mime in DataWriterProvider.SplitTrim(type, ';'))
			{
				// only return first part
				return mime;
			}

			// if no parts then was empty
			return String.Empty;
		}

		private static IEnumerable<string> SplitTrim(string source, char ch)
		{
			if (String.IsNullOrEmpty(source))
			{
				yield break;
			}

			int length = source.Length;
			for (int prev=0, next=0; prev<length && next>=0; prev=next+1)
			{
				next = source.IndexOf(ch, prev);
				if (next < 0)
				{
					next = length;
				}

				string part = source.Substring(prev, next-prev).Trim();
				if (part.Length > 0)
				{
					yield return part;
				}
			}
		}

		private static string NormalizeExtension(string extension)
		{
			if (String.IsNullOrEmpty(extension))
			{
				return String.Empty;
			}

			// ensure is only extension with leading dot
			return Path.GetExtension(extension);
		}

		#endregion Utility Methods
	}
}
