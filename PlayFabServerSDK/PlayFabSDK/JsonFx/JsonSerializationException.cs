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

#if WINDOWS_STORE
using TP = System.Reflection.TypeInfo;
#else
using TP = System.Type;
#endif

namespace Pathfinding.Serialization.JsonFx
{
	public class JsonSerializationException : InvalidOperationException
	{
		#region Init

		public JsonSerializationException() : base() { }

		public JsonSerializationException(string message) : base(message) { }

		public JsonSerializationException(string message, Exception innerException) : base(message, innerException) { }

		#endregion Init
	}

	public class JsonDeserializationException : JsonSerializationException
	{
		#region Fields

		private int index = -1;

		#endregion Fields

		#region Init

		public JsonDeserializationException(string message, int index) : base(message)
		{
			this.index = index;
		}

		public JsonDeserializationException(string message, Exception innerException, int index)
			: base(message, innerException)
		{
			this.index = index;
		}

		#endregion Init

		#region Properties

		/// <summary>
		/// Gets the character position in the stream where the error occurred.
		/// </summary>
		public int Index
		{
			get { return this.index; }
		}

		#endregion Properties

		#region Methods

		/// <summary>
		/// Helper method which converts the index into Line and Column numbers
		/// </summary>
		/// <param name="source"></param>
		/// <param name="line"></param>
		/// <param name="col"></param>
		public void GetLineAndColumn(string source, out int line, out int col)
		{
			if (source == null)
			{
				throw new ArgumentNullException();
			}

			col = 1;
			line = 1;

			bool foundLF = false;
			int i = Math.Min(this.index, source.Length);
			for (; i>0; i--)
			{
				if (!foundLF)
				{
					col++;
				}
				if (source[i-1] == '\n')
				{
					line++;
					foundLF = true;
				}
			}
		}

		#endregion Methods
	}

	public class JsonTypeCoercionException : ArgumentException
	{
		#region Init

		public JsonTypeCoercionException() : base() { }

		public JsonTypeCoercionException(string message) : base(message) { }

		public JsonTypeCoercionException(string message, Exception innerException) : base(message, innerException) { }

		#endregion Init
	}
}
