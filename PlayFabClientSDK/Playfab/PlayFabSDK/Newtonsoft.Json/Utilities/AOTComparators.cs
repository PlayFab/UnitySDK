
using System.Collections.Generic;
using System;

namespace Newtonsoft.Json.Utilities
{
	public interface StringKeyMaker<T>
	{
		string MakeStringKey(T obj);
	}

	public class TypeKeyMaker : StringKeyMaker<Type>
	{
		public static string MakeKey(Type t)
		{
			return t != null ? (t.Assembly.FullName + ":"+t.FullName) : "null";
		}

		public string MakeStringKey(Type t)
		{
			return t != null ? (t.Assembly.FullName + ":"+t.FullName) : "null";
		}
	}
	
}