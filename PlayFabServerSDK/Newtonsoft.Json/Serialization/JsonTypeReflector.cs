#region License
// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using Newtonsoft.Json.Utilities;
using Newtonsoft.Json.Utilities.LinqBridge;
using System.Runtime.Serialization;

namespace Newtonsoft.Json.Serialization
{
    internal static class JsonTypeReflector
    {
        private static bool? _fullyTrusted;

        public const string IdPropertyName = "$id";
        public const string RefPropertyName = "$ref";
        public const string TypePropertyName = "$type";
        public const string ValuePropertyName = "$value";
        public const string ArrayValuesPropertyName = "$values";

        public const string ShouldSerializePrefix = "ShouldSerialize";
        public const string SpecifiedPostfix = "Specified";

        private static readonly ThreadSafeStore<Type, Func<object[], JsonConverter>> JsonConverterCreatorCache = 
			new ThreadSafeStore<Type, Func<object[], JsonConverter>>(GetJsonConverterCreator, new TypeKeyMaker());

        public static T GetCachedAttribute<T>(object attributeProvider) where T : Attribute
        {
            return CachedAttributeGetter<T>.GetAttribute(attributeProvider);
        }

        public static MemberSerialization GetObjectMemberSerialization(Type objectType, bool ignoreSerializableAttribute)
        {
            JsonObjectAttribute objectAttribute = GetCachedAttribute<JsonObjectAttribute>(objectType);
            if (objectAttribute != null)
                return objectAttribute.MemberSerialization;

            if (!ignoreSerializableAttribute)
            {
                SerializableAttribute serializableAttribute = GetCachedAttribute<SerializableAttribute>(objectType);
                if (serializableAttribute != null)
                    return MemberSerialization.Fields;
            }

            // the default
            return MemberSerialization.OptOut;
        }

        public static JsonConverter GetJsonConverter(object attributeProvider)
        {
            JsonConverterAttribute converterAttribute = GetCachedAttribute<JsonConverterAttribute>(attributeProvider);

            if (converterAttribute != null)
            {
                Func<object[], JsonConverter> creator = JsonConverterCreatorCache.Get(converterAttribute.ConverterType);
                if (creator != null)
                    return creator(converterAttribute.ConverterParameters);
            }

            return null;
        }

        /// <summary>
        /// Lookup and create an instance of the JsonConverter type described by the argument.
        /// </summary>
        /// <param name="converterType">The JsonConverter type to create.</param>
        /// <param name="converterArgs">Optional arguments to pass to an initializing constructor of the JsonConverter.
        /// If null, the default constructor is used.</param>
        public static JsonConverter CreateJsonConverterInstance(Type converterType, object[] converterArgs)
        {
            Func<object[], JsonConverter> converterCreator = JsonConverterCreatorCache.Get(converterType);
            return converterCreator(converterArgs);
        }

        /// <summary>
        /// Create a factory function that can be used to create instances of a JsonConverter described by the 
        /// argument type.  The returned function can then be used to either invoke the converter's default ctor, or any 
        /// parameterized constructors by way of an object array.
        /// </summary>
        private static Func<object[], JsonConverter> GetJsonConverterCreator(Type converterType)
        {
            Func<object> defaultConstructor = (ReflectionUtils.HasDefaultConstructor(converterType, false))
                ? ReflectionDelegateFactory.CreateDefaultConstructor<object>(converterType)
                : null;

            return (parameters) =>
            {
                try
                {
                    if (parameters != null)
                    {
                        ObjectConstructor<object> parameterizedConstructor = null;
                        Type[] paramTypes = parameters.Select(param => param.GetType()).ToArray();
                        ConstructorInfo parameterizedConstructorInfo = converterType.GetConstructor(paramTypes);

                        if (null != parameterizedConstructorInfo)
                        {
                            parameterizedConstructor = ReflectionDelegateFactory.CreateParametrizedConstructor(parameterizedConstructorInfo);
                            return (JsonConverter)parameterizedConstructor(parameters);
                        }
                        else 
                        {
                            throw new JsonException("No matching parameterized constructor found for '{0}'.".FormatWith(CultureInfo.InvariantCulture, converterType));
                        }                        
                    }

                    if (defaultConstructor == null)
                        throw new JsonException("No parameterless constructor defined for '{0}'.".FormatWith(CultureInfo.InvariantCulture, converterType));

                    return (JsonConverter)defaultConstructor();
                }
                catch (Exception ex)
                {
                    throw new JsonException("Error creating '{0}'.".FormatWith(CultureInfo.InvariantCulture, converterType), ex);
                }
            };
        }

        public static TypeConverter GetTypeConverter(Type type)
        {
            return TypeDescriptor.GetConverter(type);
        }


        private static T GetAttribute<T>(Type type) where T : Attribute
        {
            T attribute;

            attribute = ReflectionUtils.GetAttribute<T>(type, true);
            if (attribute != null)
                return attribute;

            foreach (Type typeInterface in type.GetInterfaces())
            {
                attribute = ReflectionUtils.GetAttribute<T>(typeInterface, true);
                if (attribute != null)
                    return attribute;
            }

            return null;
        }

        private static T GetAttribute<T>(MemberInfo memberInfo) where T : Attribute
        {
            T attribute;

            attribute = ReflectionUtils.GetAttribute<T>(memberInfo, true);
            if (attribute != null)
                return attribute;

            if (memberInfo.DeclaringType != null)
            {
                foreach (Type typeInterface in memberInfo.DeclaringType.GetInterfaces())
                {
                    MemberInfo interfaceTypeMemberInfo = ReflectionUtils.GetMemberInfoFromType(typeInterface, memberInfo);

                    if (interfaceTypeMemberInfo != null)
                    {
                        attribute = ReflectionUtils.GetAttribute<T>(interfaceTypeMemberInfo, true);
                        if (attribute != null)
                            return attribute;
                    }
                }
            }

            return null;
        }

        public static T GetAttribute<T>(object provider) where T : Attribute
        {
            Type type = provider as Type;
            if (type != null)
                return GetAttribute<T>(type);

            MemberInfo memberInfo = provider as MemberInfo;
            if (memberInfo != null)
                return GetAttribute<T>(memberInfo);

            return ReflectionUtils.GetAttribute<T>(provider, true);
        }

#if DEBUG
        internal static void SetFullyTrusted(bool fullyTrusted)
        {
            _fullyTrusted = fullyTrusted;
        }


#endif

        public static bool FullyTrusted
        {
            get
            {
                if (_fullyTrusted == null)
                {
                    try
                    {
                        new SecurityPermission(PermissionState.Unrestricted).Demand();
                        _fullyTrusted = true;
                    }
                    catch (Exception)
                    {
                        _fullyTrusted = false;
                    }
                }

                return _fullyTrusted.Value;
            }
        }

        public static ReflectionDelegateFactory ReflectionDelegateFactory
        {
            get
            {

                return LateBoundReflectionDelegateFactory.Instance;

            }
        }
    }
}