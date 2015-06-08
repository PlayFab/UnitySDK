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
using System.Reflection;
using Newtonsoft.Json.Utilities.LinqBridge;

namespace Newtonsoft.Json.Utilities
{
    internal static class TypeExtensions
    {

        public static MethodInfo Method(this Delegate d)
        {
            return d.Method;
        }

        public static MemberTypes MemberType(this MemberInfo memberInfo)
        {
            return memberInfo.MemberType;
        }

        public static bool ContainsGenericParameters(this Type type)
        {
            return type.ContainsGenericParameters;
        }

        public static bool IsInterface(this Type type)
        {
            return type.IsInterface;
        }

        public static bool IsGenericType(this Type type)
        {
            return type.IsGenericType;
        }

        public static bool IsGenericTypeDefinition(this Type type)
        {
            return type.IsGenericTypeDefinition;
        }

        public static Type BaseType(this Type type)
        {
            return type.BaseType;
        }

        public static Assembly Assembly(this Type type)
        {
            return type.Assembly;
        }

        public static bool IsEnum(this Type type)
        {
            return type.IsEnum;
        }

        public static bool IsClass(this Type type)
        {
            return type.IsClass;
        }

        public static bool IsSealed(this Type type)
        {
            return type.IsSealed;
        }


        public static bool IsAbstract(this Type type)
        {
            return type.IsAbstract;
        }

        public static bool IsVisible(this Type type)
        {
            return type.IsVisible;
        }

        public static bool IsValueType(this Type type)
        {
            return type.IsValueType;
        }

        public static bool AssignableToTypeName(this Type type, string fullTypeName, out Type match)
        {
            Type current = type;

            while (current != null)
            {
                if (string.Equals(current.FullName, fullTypeName, StringComparison.Ordinal))
                {
                    match = current;
                    return true;
                }

                current = current.BaseType();
            }

            foreach (Type i in type.GetInterfaces())
            {
                if (string.Equals(i.Name, fullTypeName, StringComparison.Ordinal))
                {
                    match = type;
                    return true;
                }
            }

            match = null;
            return false;
        }

        public static bool AssignableToTypeName(this Type type, string fullTypeName)
        {
            Type match;
            return type.AssignableToTypeName(fullTypeName, out match);
        }
    }
}