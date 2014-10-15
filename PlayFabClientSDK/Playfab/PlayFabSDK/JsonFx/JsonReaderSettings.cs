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
	/// <summary>
	/// Controls the deserialization settings for JsonReader
	/// </summary>
	public class JsonReaderSettings
	{
		#region Fields

		internal readonly TypeCoercionUtility Coercion = new TypeCoercionUtility();
		private bool allowUnquotedObjectKeys = false;
		private string typeHintName;

		#endregion Fields

		#region Properties

		/// <summary>
		/// Gets or sets a value indicating whether this to handle cyclic references.
		/// </summary>
		/// <remarks>
		/// Handling cyclic references is slightly more expensive and needs to keep a list
		/// of all deserialized objects, but it will not crash or go into infinite loops
		/// when trying to serialize an object graph with cyclic references and after
		/// deserialization all references will point to the correct objects even if
		/// it was used in different places (this can be good even if you do not have
		/// cyclic references in your data).
		/// 
		/// More specifically, if your object graph (where one reference is a directed edge) 
		/// is a tree, this should be false, otherwise it should be true.
		/// 
		/// Note also that the deserialization methods which take a start position
		/// will not work with this setting enabled.
		/// </remarks>
		/// <value>
		/// <c>true</c> if handle cyclic references; otherwise, <c>false</c>.
		/// </value>
		public bool HandleCyclicReferences {get; set;}

		/// <summary>
		/// Gets and sets if ValueTypes can accept values of null
		/// </summary>
		/// <remarks>
		/// Only affects deserialization: if a ValueType is assigned the
		/// value of null, it will receive the value default(TheType).
		/// Setting this to false, throws an exception if null is
		/// specified for a ValueType member.
		/// </remarks>
		public bool AllowNullValueTypes
		{
			get { return this.Coercion.AllowNullValueTypes; }
			set { this.Coercion.AllowNullValueTypes = value; }
		}

		/// <summary>
		/// Gets and sets if objects can have unquoted property names
		/// </summary>
		public bool AllowUnquotedObjectKeys
		{
			get { return this.allowUnquotedObjectKeys; }
			set { this.allowUnquotedObjectKeys = value; }
		}

		/// <summary>
		/// Gets and sets the property name used for type hinting.
		/// </summary>
		public string TypeHintName
		{
			get { return this.typeHintName; }
			set { this.typeHintName = value; }
		}

		public bool AllNumbersAsDouble = false;

		#endregion Properties

		#region Methods

		/// <summary>
		/// Determines if the specified name is the TypeHint property
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		internal bool IsTypeHintName(string name)
		{
			return
				!String.IsNullOrEmpty(name) &&
				!String.IsNullOrEmpty(this.typeHintName) &&
				StringComparer.Ordinal.Equals(this.typeHintName, name);
		}
	
		protected List<JsonConverter> converters = new List<JsonConverter>();
		
		public virtual JsonConverter GetConverter (Type type) {
			for (int i=0;i<converters.Count;i++)
				if (converters[i].CanConvert (type))
					return converters[i];
			
			return null;
		}
		
		public virtual void AddTypeConverter (JsonConverter converter) {
			converters.Add (converter);
		}
		
		#endregion Methods
	}
}
