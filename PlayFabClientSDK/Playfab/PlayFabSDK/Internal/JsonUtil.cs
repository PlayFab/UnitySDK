

using System.Collections.Generic;
using System;
using System.Globalization;

namespace PlayFab.Internal
{
	public abstract class PlayFabModelBase
	{
		public abstract void Deserialize (Dictionary<string,object> json);
	}

	public class JsonUtil
	{
		public static DataType Get<DataType>(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				return (DataType)value;
			}
			return default(DataType);
		}

		public static DataType GetObject<DataType>(Dictionary<string,object> json, string name) where DataType : PlayFabModelBase, new()
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				Dictionary<string,object> objDict = (Dictionary<string,object>)value;
				DataType result = new DataType();
				result.Deserialize(objDict);
				return result;
			}
			return null;
		}

		public static List<DataType> GetObjectList<DataType>(Dictionary<string,object> json, string name) where DataType : PlayFabModelBase, new()
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				object[] objArray = (object[])value;
				List<DataType> list = new List<DataType>();
				
				for(int i=0;i<objArray.Length; i++)
				{
					Dictionary<string,object> objDict = (Dictionary<string,object>)objArray[i];
					DataType obj = new DataType();
					obj.Deserialize(objDict);
					list.Add (obj);
				}
				
				return list;
			}
			return null;
		}

		public static Dictionary<string, DataType> GetObjectDictionary<DataType>(Dictionary<string,object> json, string name) where DataType : PlayFabModelBase, new()
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				Dictionary<string,object> containerDict = (Dictionary<string,object>)value;
				Dictionary<string, DataType> dict = new Dictionary<string, DataType>();
				
				foreach(string key in containerDict.Keys)
				{
					Dictionary<string,object> objDict = (Dictionary<string,object>)containerDict[key];
					DataType obj = new DataType();
					obj.Deserialize(objDict);
					dict.Add (key, obj);
				}
				
				return dict;
			}
			return null;
		}

		public static DateTime? GetDateTime(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				DateTime date;
				if (DateTime.TryParse((string)value,
				                      DateTimeFormatInfo.InvariantInfo,
				                      DateTimeStyles.RoundtripKind | DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.NoCurrentDateDefault,
				                      out date))
				{
					return date;
				}
			}
			return null;
		}

		public static Nullable<DataType> GetEnum<DataType>(Dictionary<string,object> json, string name) where DataType : struct, IConvertible
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				string strEnum = (string)value;
				DataType result = (DataType)Enum.Parse(typeof(DataType), strEnum);
				return result;
			}
			return null;
		}

		public static List<DataType> GetList<DataType>(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				object[] objArray = (object[])value;
				List<DataType> list = new List<DataType>();

				for(int i=0;i<objArray.Length; i++)
				{
					list.Add ((DataType)objArray[i]);
				}
				
				return list;
			}
			return null;
		}
		
		public static List<DataType> GetListEnum<DataType>(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				object[] objArray = (object[])value;
				List<DataType> list = new List<DataType>();
				
				for(int i=0;i<objArray.Length; i++)
				{
					list.Add ((DataType)Enum.Parse(typeof(DataType), (string)objArray[i]));
				}
				
				return list;
			}
			return null;
		}


		public static List<Int16> GetListInt16(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				object[] objArray = (object[])value;
				List<Int16> list = new List<Int16>();
				
				for(int i=0;i<objArray.Length; i++)
				{
					list.Add ((Int16)(double)objArray[i]);
				}
				
				return list;
			}
			return null;
		}

		public static List<UInt16> GetListUInt16(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				object[] objArray = (object[])value;
				List<UInt16> list = new List<UInt16>();
				
				for(int i=0;i<objArray.Length; i++)
				{
					list.Add ((UInt16)(double)objArray[i]);
				}
				
				return list;
			}
			return null;
		}

		public static List<Int32> GetListInt32(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				object[] objArray = (object[])value;
				List<Int32> list = new List<Int32>();
				
				for(int i=0;i<objArray.Length; i++)
				{
					list.Add ((Int32)(double)objArray[i]);
				}
				
				return list;
			}
			return null;
		}
		
		public static List<UInt32> GetListUInt32(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				object[] objArray = (object[])value;
				List<UInt32> list = new List<UInt32>();
				
				for(int i=0;i<objArray.Length; i++)
				{
					list.Add ((UInt32)(double)objArray[i]);
				}
				
				return list;
			}
			return null;
		}

		
		public static List<Int64> GetListInt64(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				object[] objArray = (object[])value;
				List<Int64> list = new List<Int64>();
				
				for(int i=0;i<objArray.Length; i++)
				{
					list.Add ((Int64)(double)objArray[i]);
				}
				
				return list;
			}
			return null;
		}
		
		public static List<UInt64> GetListUInt64(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				object[] objArray = (object[])value;
				List<UInt64> list = new List<UInt64>();
				
				for(int i=0;i<objArray.Length; i++)
				{
					list.Add ((UInt64)(double)objArray[i]);
				}
				
				return list;
			}
			return null;
		}

		public static List<float> GetListFloat(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				object[] objArray = (object[])value;
				List<float> list = new List<float>();
				
				for(int i=0;i<objArray.Length; i++)
				{
					list.Add ((float)(double)objArray[i]);
				}
				
				return list;
			}
			return null;
		}
		
		public static List<double> GetListDouble(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				object[] objArray = (object[])value;
				List<double> list = new List<double>();
				
				for(int i=0;i<objArray.Length; i++)
				{
					list.Add ((double)objArray[i]);
				}
				
				return list;
			}
			return null;
		}

		public static Dictionary<string, DataType> GetDictionary<DataType>(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				Dictionary<string,object> containerDict = (Dictionary<string,object>)value;
				Dictionary<string, DataType> dict = new Dictionary<string, DataType>();
				
				foreach(string key in containerDict.Keys)
				{
					dict.Add (key, (DataType)containerDict[key]);
				}
				
				return dict;
			}
			return null;
		}

		public static Dictionary<string, Int16> GetDictionaryInt16(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				Dictionary<string,object> containerDict = (Dictionary<string,object>)value;
				Dictionary<string, Int16> dict = new Dictionary<string, Int16>();
				
				foreach(string key in containerDict.Keys)
				{
					dict.Add (key, (Int16)(double)containerDict[key]);
				}
				
				return dict;
			}
			return null;
		}

		public static Dictionary<string, UInt16> GetDictionaryUInt16(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				Dictionary<string,object> containerDict = (Dictionary<string,object>)value;
				Dictionary<string, UInt16> dict = new Dictionary<string, UInt16>();
				
				foreach(string key in containerDict.Keys)
				{
					dict.Add (key, (UInt16)(double)containerDict[key]);
				}
				
				return dict;
			}
			return null;
		}

		public static Dictionary<string, Int32> GetDictionaryInt32(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				Dictionary<string,object> containerDict = (Dictionary<string,object>)value;
				Dictionary<string, Int32> dict = new Dictionary<string, Int32>();
				
				foreach(string key in containerDict.Keys)
				{
					dict.Add (key, (Int32)(double)containerDict[key]);
				}
				
				return dict;
			}
			return null;
		}
		
		public static Dictionary<string, UInt32> GetDictionaryUInt32(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				Dictionary<string,object> containerDict = (Dictionary<string,object>)value;
				Dictionary<string, UInt32> dict = new Dictionary<string, UInt32>();
				
				foreach(string key in containerDict.Keys)
				{
					dict.Add (key, (UInt32)(double)containerDict[key]);
				}
				
				return dict;
			}
			return null;
		}

		public static Dictionary<string, Int64> GetDictionaryInt64(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				Dictionary<string,object> containerDict = (Dictionary<string,object>)value;
				Dictionary<string, Int64> dict = new Dictionary<string, Int64>();
				
				foreach(string key in containerDict.Keys)
				{
					dict.Add (key, (Int64)(double)containerDict[key]);
				}
				
				return dict;
			}
			return null;
		}
		
		public static Dictionary<string, UInt64> GetDictionaryUInt64(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				Dictionary<string,object> containerDict = (Dictionary<string,object>)value;
				Dictionary<string, UInt64> dict = new Dictionary<string, UInt64>();
				
				foreach(string key in containerDict.Keys)
				{
					dict.Add (key, (UInt64)(double)containerDict[key]);
				}
				
				return dict;
			}
			return null;
		}

		public static Dictionary<string, float> GetDictionaryFloat(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				Dictionary<string,object> containerDict = (Dictionary<string,object>)value;
				Dictionary<string, float> dict = new Dictionary<string, float>();
				
				foreach(string key in containerDict.Keys)
				{
					dict.Add (key, (float)(double)containerDict[key]);
				}
				
				return dict;
			}
			return null;
		}
		
		public static Dictionary<string, double> GetDictionaryDouble(Dictionary<string,object> json, string name)
		{
			object value;
			if (json.TryGetValue(name, out value))
			{
				if(value == null)
					return null;
				
				Dictionary<string,object> containerDict = (Dictionary<string,object>)value;
				Dictionary<string, double> dict = new Dictionary<string, double>();
				
				foreach(string key in containerDict.Keys)
				{
					dict.Add (key, (double)containerDict[key]);
				}
				
				return dict;
			}
			return null;
		}
	}
}

