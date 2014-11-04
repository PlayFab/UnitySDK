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
using System.Collections.Generic;

#if WINDOWS_STORE
using TP = System.Reflection.TypeInfo;
#else
using TP = System.Type;
#endif

namespace PlayFab.Serialization.JsonFx
{
	/// <summary>
	/// Represents a proxy method for serialization of types which do not implement IJsonSerializable
	/// </summary>
	/// <typeparam name="T">the type for this proxy</typeparam>
	/// <param name="writer">the JsonWriter to serialize to</param>
	/// <param name="value">the value to serialize</param>
	public delegate void WriteDelegate<T>(JsonWriter writer, T value);

	/// <summary>
	/// Controls the serialization settings for JsonWriter
	/// </summary>
	public class JsonWriterSettings
	{
		#region Fields

		private WriteDelegate<DateTime> dateTimeSerializer;
		private int maxDepth = 25;
		private string newLine = Environment.NewLine;
		private bool prettyPrint;
		private string tab = "\t";
		private string typeHintName;
		private bool useXmlSerializationAttributes;
		private bool writeNulls = false;

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
		/// 
		/// When an object is first encountered, it will be serialized, just as usual,
		/// but when it is encountered again, it will be replaced with an object only
		/// containing a "@ref" field specifying that this is identical to object number
		/// [value] that was serialized. This number is zero indexed.
		/// 
		/// Arrays can unfortunately not be deserialized to the same object if they are
		/// referenced in multiple places since the contents of the array needs to be deserialized
		/// before the actual array is created.
		/// 
		/// Make sure you also enable cyclic reference handling in the reader settings.
		/// </remarks>
		/// <value>
		/// <c>true</c> if handle cyclic references; otherwise, <c>false</c>.
		/// </value>
		public bool HandleCyclicReferences {get; set;}

		/// <summary>
		/// Gets and sets the property name used for type hinting.
		/// </summary>
		public virtual string TypeHintName
		{
			get { return this.typeHintName; }
			set { this.typeHintName = value; }
		}

		/// <summary>
		/// Gets and sets if JSON will be formatted for human reading.
		/// </summary>
		public virtual bool PrettyPrint
		{
			get { return this.prettyPrint; }
			set { this.prettyPrint = value; }
		}

		/// <summary>
		/// Gets and sets the string to use for indentation
		/// </summary>
		public virtual string Tab
		{
			get { return this.tab; }
			set { this.tab = value; }
		}

		/// <summary>
		/// Gets and sets the line terminator string
		/// </summary>
		public virtual string NewLine
		{
			get { return this.newLine; }
			set { this.newLine = value; }
		}

		/// <summary>
		/// Gets and sets the maximum depth to be serialized.
		/// </summary>
		public virtual int MaxDepth
		{
			get { return this.maxDepth; }
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("MaxDepth must be a positive integer as it controls the maximum nesting level of serialized objects.");
				}
				this.maxDepth = value;
			}
		}

		/// <summary>
		/// Write null values to json objects
		/// </summary>
		public virtual bool WriteNulls
		{
			get { return this.writeNulls; }
			set { this.writeNulls = value; }
		}

		/// <summary>
		/// Gets and sets if should use XmlSerialization Attributes.
		/// </summary>
		/// <remarks>
		/// Respects XmlIgnoreAttribute, ...
		/// </remarks>
		public virtual bool UseXmlSerializationAttributes
		{
			get { return this.useXmlSerializationAttributes; }
			set { this.useXmlSerializationAttributes = value; }
		}

		/// <summary>
		/// Gets and sets a proxy formatter to use for DateTime serialization
		/// </summary>
		public virtual WriteDelegate<DateTime> DateTimeSerializer
		{
			get { return this.dateTimeSerializer; }
			set { this.dateTimeSerializer = value; }
		}
		
		/** Enables more debugging messages.
		 * E.g about why some members are not serialized.
		 * The number of debugging messages are in no way exhaustive
		 */
		public virtual bool DebugMode { get; set; }
		
		protected List<JsonConverter> converters = new List<JsonConverter>();
		
		/** Returns the converter for the specified type */
		public virtual JsonConverter GetConverter (Type type) {
			for (int i=0;i<converters.Count;i++)
				if (converters[i].CanConvert (type))
					return converters[i];
			
			return null;
		}
		
		/** Adds a converter to use to serialize otherwise non-serializable types.
		 * Good if you do not have the source and it throws error when trying to serialize it.
		 * For example the Unity3D Vector3 can be serialized using a special converter
		 */
		public virtual void AddTypeConverter (JsonConverter converter) {
			converters.Add (converter);
		}
		#endregion Properties
	}
	
	public abstract class JsonConverter {
		
		/** Test if this converter can convert the specified type */
		public abstract bool CanConvert (Type t);
		
		public void Write (JsonWriter writer, Type type, object value) {
			Dictionary<string,object> dict = WriteJson (type,value);
			writer.Write (dict);
		}
		
		public object Read (JsonReader reader, Type type, Dictionary<string,object> value) {
			return ReadJson (type, value);
		}
		
		public float CastFloat (object o) {
			if (o==null)return 0.0F;
			try {
				return System.Convert.ToSingle(o);
			} catch(System.Exception e) {
				throw new JsonDeserializationException ("Cannot cast object to float. Expected float, got "+o.GetType(),e,0);
			}
		}
		
		public double CastDouble (object o) {
			if (o==null)return 0.0;
			try {
				return System.Convert.ToDouble(o);
			} catch(System.Exception e) {
				throw new JsonDeserializationException ("Cannot cast object to double. Expected double, got "+o.GetType(),e,0);
			}
		}
		
		public abstract Dictionary<string,object> WriteJson (Type type, object value);
		public abstract object ReadJson (Type type, Dictionary<string,object> value);
	}
	
}