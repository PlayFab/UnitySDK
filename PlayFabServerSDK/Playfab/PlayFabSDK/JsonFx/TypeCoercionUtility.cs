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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

#if WINDOWS_STORE
using TP = System.Reflection.TypeInfo;
#else
using TP = System.Type;
#endif

namespace PlayFab.Serialization.JsonFx
{
	/// <summary>
	/// Utility for forcing conversion between types
	/// </summary>
	internal class TypeCoercionUtility
	{
		#region Constants

		private const string ErrorNullValueType = "{0} does not accept null as a value";
		private const string ErrorDefaultCtor = "Only objects with default constructors can be deserialized. ({0})";
		private const string ErrorCannotInstantiate = "Interfaces, Abstract classes, and unsupported ValueTypes cannot be deserialized. ({0})";

		#endregion Constants

		#region Fields

		private Dictionary<Type, Dictionary<string, MemberInfo>> memberMapCache;
		private bool allowNullValueTypes = true;

		#endregion Fields

		#region Properties

		private Dictionary<Type, Dictionary<string, MemberInfo>> MemberMapCache
		{
			get
			{
				if (this.memberMapCache == null)
				{
					// instantiate space for cache
					this.memberMapCache = new Dictionary<Type, Dictionary<string, MemberInfo>>();
				}
				return this.memberMapCache;
			}
		}

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
			get { return this.allowNullValueTypes; }
			set { this.allowNullValueTypes = value; }
		}

		#endregion Properties

		#region Object Methods

		/// <summary>
		/// If a Type Hint is present then this method attempts to
		/// use it and move any previously parsed data over.
		/// </summary>
		/// <param name="result">the previous result</param>
		/// <param name="typeInfo">the type info string to use</param>
		/// <param name="objectType">reference to the objectType</param>
		/// <param name="memberMap">reference to the memberMap</param>
		/// <returns></returns>
		internal object ProcessTypeHint(
			IDictionary result,
			string typeInfo,
			out Type objectType,
			out Dictionary<string, MemberInfo> memberMap)
		{
			if (String.IsNullOrEmpty(typeInfo))
			{
				objectType = null;
				memberMap = null;
				return result;
			}

			Type hintedType = Type.GetType(typeInfo, false);
			if (hintedType == null)
			{
				objectType = null;
				memberMap = null;
				return result;
			}

			objectType = hintedType;
			return this.CoerceType(hintedType, result, out memberMap);
		}

		internal Object InstantiateObject(Type objectType, out Dictionary<string, MemberInfo> memberMap)
		{
			if (objectType.IsInterface || objectType.IsAbstract || objectType.IsValueType)
			{
				throw new JsonTypeCoercionException(
					String.Format(TypeCoercionUtility.ErrorCannotInstantiate, objectType.FullName));
			}

			ConstructorInfo ctor = objectType.GetConstructor(Type.EmptyTypes);
			if (ctor == null)
			{
				throw new JsonTypeCoercionException(
					String.Format(TypeCoercionUtility.ErrorDefaultCtor, objectType.FullName));
			}
			Object result;
			try
			{
				// always try-catch Invoke() to expose real exception
				result = ctor.Invoke(null);
			}
			catch (TargetInvocationException ex)
			{
				if (ex.InnerException != null)
				{
					throw new JsonTypeCoercionException(ex.InnerException.Message, ex.InnerException);
				}
				throw new JsonTypeCoercionException("Error instantiating " + objectType.FullName, ex);
			}

			memberMap = GetMemberMap (objectType);
			
			return result;
		}
		
		/** Returns a member map if suitable for the object type.
		 * Dictionary types will make this method return null
		 */
		public Dictionary<string, MemberInfo> GetMemberMap (Type objectType) {
			// don't incurr the cost of member map for dictionaries
			if (typeof(IDictionary).IsAssignableFrom(objectType))
			{
				return null;
			}
			else
			{
				return this.CreateMemberMap(objectType);
			}
		}
		
		/** Creates a member map for the type */
		private Dictionary<string, MemberInfo> CreateMemberMap(Type objectType)
		{

			Dictionary<string, MemberInfo> memberMap;

			if (this.MemberMapCache.TryGetValue(objectType, out memberMap))
			{
				// map was stored in cache
				return memberMap;
			}

			// create a new map
			memberMap = new Dictionary<string, MemberInfo>();

			// load properties into property map
			PropertyInfo[] properties = objectType.GetProperties( BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance );
			foreach (PropertyInfo info in properties)
			{
				if (!info.CanRead || !info.CanWrite)
				{
					continue;
				}

				if (JsonIgnoreAttribute.IsJsonIgnore(info))
				{
					continue;
				}

				string jsonName = JsonNameAttribute.GetJsonName(info);
				if (String.IsNullOrEmpty(jsonName))
				{
					memberMap[info.Name] = info;
				}
				else
				{
					memberMap[jsonName] = info;
				}
			}

			// load public fields into property map
			FieldInfo[] fields = objectType.GetFields( BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance );
			foreach (FieldInfo info in fields)
			{
				if (!info.IsPublic && info.GetCustomAttributes(typeof(JsonMemberAttribute),true).Length == 0)
				{
					continue;
				}

				if (JsonIgnoreAttribute.IsJsonIgnore(info))
				{
					continue;
				}

				string jsonName = JsonNameAttribute.GetJsonName(info);
				if (String.IsNullOrEmpty(jsonName))
				{
					memberMap[info.Name] = info;
				}
				else
				{
					memberMap[jsonName] = info;
				}
			}

			// store in cache for repeated usage
			this.MemberMapCache[objectType] = memberMap;

			return memberMap;
		}

		internal static Type GetMemberInfo(
			Dictionary<string, MemberInfo> memberMap,
			string memberName,
			out MemberInfo memberInfo)
		{

			if (memberMap != null &&
				memberMap.TryGetValue(memberName, out memberInfo))
			{
				// Check properties for object member
				//memberInfo = memberMap[memberName];

				if (memberInfo is PropertyInfo)
				{
					// maps to public property
					return ((PropertyInfo)memberInfo).PropertyType;
				}
				else if (memberInfo is FieldInfo)
				{
					// maps to public field
					return ((FieldInfo)memberInfo).FieldType;
				}
			}

			memberInfo = null;
			return null;
		}

		/// <summary>
		/// Helper method to set value of either property or field
		/// </summary>
		/// <param name="result"></param>
		/// <param name="memberType"></param>
		/// <param name="memberInfo"></param>
		/// <param name="value"></param>
		internal void SetMemberValue(Object result, Type memberType, MemberInfo memberInfo, object value)
		{
			if (memberInfo is PropertyInfo)
			{
				// set value of public property
				((PropertyInfo)memberInfo).SetValue(
					result,
					this.CoerceType(memberType, value),
					null);
			}
			else if (memberInfo is FieldInfo)
			{
				// set value of public field
				((FieldInfo)memberInfo).SetValue(
					result,
					this.CoerceType(memberType, value));
			}

			// all other values are ignored
		}

		#endregion Object Methods

		#region Type Methods

		internal object CoerceType(Type targetType, object value)
		{
			bool isNullable = TypeCoercionUtility.IsNullable(targetType);
			if (value == null)
			{
				if (!allowNullValueTypes &&
					targetType.IsValueType &&
					!isNullable)
				{
					throw new JsonTypeCoercionException(String.Format(TypeCoercionUtility.ErrorNullValueType, targetType.FullName));
				}
				return value;
			}

			if (isNullable)
			{
				// nullable types have a real underlying struct
				Type[] genericArgs = targetType.GetGenericArguments();
				if (genericArgs.Length == 1)
				{
					targetType = genericArgs[0];
				}
			}

			Type actualType = value.GetType();
			if (targetType.IsAssignableFrom(actualType))
			{
				return value;
			}

			if (targetType.IsEnum)
			{
				if (value is String)
				{
					if (!Enum.IsDefined(targetType, value))
					{
						// if isn't a defined value perhaps it is the JsonName
						foreach (FieldInfo field in targetType.GetFields())
						{
							string jsonName = JsonNameAttribute.GetJsonName(field);
							if (((string)value).Equals(jsonName))
							{
								value = field.Name;
								break;
							}
						}
					}

					return Enum.Parse(targetType, (string)value);
				}
				else
				{
					value = this.CoerceType(Enum.GetUnderlyingType(targetType), value);
					return Enum.ToObject(targetType, value);
				}
			}

			if (value is IDictionary)
			{
				Dictionary<string, MemberInfo> memberMap;
				return this.CoerceType(targetType, (IDictionary)value, out memberMap);
			}

			if (typeof(IEnumerable).IsAssignableFrom(targetType) &&
				typeof(IEnumerable).IsAssignableFrom(actualType))
			{
				return this.CoerceList(targetType, actualType, (IEnumerable)value);
			}

			if (value is String)
			{
				if (targetType == typeof(DateTime))
				{
					DateTime date;
					if (DateTime.TryParse(
						(string)value,
						DateTimeFormatInfo.InvariantInfo,
						DateTimeStyles.RoundtripKind | DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.NoCurrentDateDefault,
						out date))
					{
						return date;
					}
				}
				else if (targetType == typeof(Guid))
				{
					// try-catch is pointless since will throw upon generic conversion
					return new Guid((string)value);
				}
				else if (targetType == typeof(Char))
				{
					if (((string)value).Length == 1)
					{
						return ((string)value)[0];
					}
				}
				else if (targetType == typeof(Uri))
				{
					Uri uri;
					if (Uri.TryCreate((string)value, UriKind.RelativeOrAbsolute, out uri))
					{
						return uri;
					}
				}
				else if (targetType == typeof(Version))
				{
					// try-catch is pointless since will throw upon generic conversion
					return new Version((string)value);
				}
			}
			else if (targetType == typeof(TimeSpan))
			{
				return new TimeSpan((long)this.CoerceType(typeof(Int64), value));
			}

#if !WINPHONE_8
			TypeConverter converter = TypeDescriptor.GetConverter(targetType);
			if (converter.CanConvertFrom(actualType))
			{
				return converter.ConvertFrom(value);
			}

			converter = TypeDescriptor.GetConverter(actualType);
			if (converter.CanConvertTo(targetType))
			{
				return converter.ConvertTo(value, targetType);
			}
#endif

			try
			{
				// fall back to basics
				return Convert.ChangeType(value, targetType);
			}
			catch (Exception ex)
			{
				throw new JsonTypeCoercionException(
					String.Format("Error converting {0} to {1}", value.GetType().FullName, targetType.FullName), ex);
			}
		}

		private object CoerceType(Type targetType, IDictionary value, out Dictionary<string, MemberInfo> memberMap)
		{
			object newValue = this.InstantiateObject(targetType, out memberMap);
			if (memberMap != null)
			{
				// copy any values into new object
				foreach (object key in value.Keys)
				{
					MemberInfo memberInfo;
					Type memberType = TypeCoercionUtility.GetMemberInfo(memberMap, key as String, out memberInfo);
					this.SetMemberValue(newValue, memberType, memberInfo, value[key]);
				}
			}
			return newValue;
		}

		private object CoerceList(Type targetType, Type arrayType, IEnumerable value)
		{
			if (targetType.IsArray)
			{
				return this.CoerceArray(targetType.GetElementType(), value);
			}

			// targetType serializes as a JSON array but is not an array
			// assume is an ICollection / IEnumerable with AddRange, Add,
			// or custom Constructor with which we can populate it

			// many ICollection types take an IEnumerable or ICollection
			// as a constructor argument.  look through constructors for
			// a compatible match.
			ConstructorInfo[] ctors = targetType.GetConstructors();
			ConstructorInfo defaultCtor = null;
			foreach (ConstructorInfo ctor in ctors)
			{
				ParameterInfo[] paramList = ctor.GetParameters();
				if (paramList.Length == 0)
				{
					// save for in case cannot find closer match
					defaultCtor = ctor;
					continue;
				}

				if (paramList.Length == 1 &&
					paramList[0].ParameterType.IsAssignableFrom(arrayType))
				{
					try
					{
						// invoke first constructor that can take this value as an argument
						return ctor.Invoke(
								new object[] { value }
							);
					}
					catch
					{
						// there might exist a better match
						continue;
					}
				}
			}

			if (defaultCtor == null)
			{
				throw new JsonTypeCoercionException(
					String.Format(TypeCoercionUtility.ErrorDefaultCtor, targetType.FullName));
			}
			object collection;
			try
			{
				// always try-catch Invoke() to expose real exception
				collection = defaultCtor.Invoke(null);
			}
			catch (TargetInvocationException ex)
			{
				if (ex.InnerException != null)
				{
					throw new JsonTypeCoercionException(ex.InnerException.Message, ex.InnerException);
				}
				throw new JsonTypeCoercionException("Error instantiating " + targetType.FullName, ex);
			}

			// many ICollection types have an AddRange method
			// which adds all items at once
			MethodInfo method = targetType.GetMethod("AddRange");
			ParameterInfo[] parameters = (method == null) ?
					null : method.GetParameters();
			Type paramType = (parameters == null || parameters.Length != 1) ?
					null : parameters[0].ParameterType;
			if (paramType != null &&
				paramType.IsAssignableFrom(arrayType))
			{
				try
				{
					// always try-catch Invoke() to expose real exception
					// add all members in one method
					method.Invoke(
						collection,
						new object[] { value });
				}
				catch (TargetInvocationException ex)
				{
					if (ex.InnerException != null)
					{
						throw new JsonTypeCoercionException(ex.InnerException.Message, ex.InnerException);
					}
					throw new JsonTypeCoercionException("Error calling AddRange on " + targetType.FullName, ex);
				}
				return collection;
			}
			else
			{
				// many ICollection types have an Add method
				// which adds items one at a time
				method = targetType.GetMethod("Add");
				parameters = (method == null) ?
						null : method.GetParameters();
				paramType = (parameters == null || parameters.Length != 1) ?
						null : parameters[0].ParameterType;
				if (paramType != null)
				{
					// loop through adding items to collection
					foreach (object item in value)
					{
						try
						{
							// always try-catch Invoke() to expose real exception
							method.Invoke(
								collection,
								new object[] {
								this.CoerceType(paramType, item)
							});
						}
						catch (TargetInvocationException ex)
						{
							if (ex.InnerException != null)
							{
								throw new JsonTypeCoercionException(ex.InnerException.Message, ex.InnerException);
							}
							throw new JsonTypeCoercionException("Error calling Add on " + targetType.FullName, ex);
						}
					}
					return collection;
				}
			}

			try
			{
				// fall back to basics
				return Convert.ChangeType(value, targetType);
			}
			catch (Exception ex)
			{
				throw new JsonTypeCoercionException(String.Format("Error converting {0} to {1}", value.GetType().FullName, targetType.FullName), ex);
			}
		}

		private Array CoerceArray(Type elementType, IEnumerable value)
		{
			//ArrayList target = new ArrayList();
			
			int count = 0;
			IEnumerator enumerator = value.GetEnumerator ();
			while (enumerator.MoveNext())
			{
				count++;
			}
			Array arr = Array.CreateInstance (elementType, count);

			int i=0;
			foreach (object item in value)
			{
				//target.Add(this.CoerceType(elementType, item));
				arr.SetValue ( this.CoerceType(elementType, item), i );
				i++;
			}

			return arr;//target.ToArray(elementType);
		}

		private static bool IsNullable(Type type)
		{
			return type.IsGenericType && (typeof(Nullable<>) == type.GetGenericTypeDefinition());
		}

		#endregion Type Methods
	}
}
