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
using System.IO;
using System.Text;

#if WINDOWS_STORE
using TP = System.Reflection.TypeInfo;
#else
using TP = System.Type;
#endif

namespace PlayFab.Serialization.JsonFx
{
	/// <summary>
	/// An <see cref="IDataWriter"/> adapter for <see cref="JsonWriter"/>
	/// </summary>
	public class JsonDataWriter : IDataWriter
	{
		#region Constants

		public const string JsonMimeType = JsonWriter.JsonMimeType;
		public const string JsonFileExtension = JsonWriter.JsonFileExtension;

		#endregion Constants

		#region Fields

		private readonly JsonWriterSettings Settings;

		#endregion Fields

		#region Init

		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="settings">JsonWriterSettings</param>
		public JsonDataWriter(JsonWriterSettings settings)
		{
			if (settings == null)
			{
				throw new ArgumentNullException("settings");
			}
			this.Settings = settings;
		}

		#endregion Init

		#region IDataSerializer Members

		/// <summary>
		/// Gets the content encoding
		/// </summary>
		public Encoding ContentEncoding
		{
			get { return Encoding.UTF8; }
		}

		/// <summary>
		/// Gets the content type
		/// </summary>
		public string ContentType
		{
			get { return JsonDataWriter.JsonMimeType; }
		}

		/// <summary>
		/// Gets the file extension
		/// </summary>
		public string FileExtension
		{
			get { return JsonDataWriter.JsonFileExtension; }
		}

		/// <summary>
		/// Serializes the data object to the output
		/// </summary>
		/// <param name="output"></param>
		/// <param name="data"></param>
		public void Serialize(TextWriter output, object data)
		{
			new JsonWriter(output, this.Settings).Write(data);
		}

		#endregion IDataSerializer Members

		#region Methods

		/// <summary>
		/// Builds a common settings objects
		/// </summary>
		/// <param name="prettyPrint"></param>
		/// <returns></returns>
		public static JsonWriterSettings CreateSettings(bool prettyPrint)
		{
			JsonWriterSettings settings = new JsonWriterSettings();

			settings.PrettyPrint = prettyPrint;

			return settings;
		}

		#endregion Methods
	}
}
