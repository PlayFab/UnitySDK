#if UNITY_WSA && UNITY_WP8
#define NETFX_CORE
#endif

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PlayFab
{
    public static class WsaReflectionExtensions
    {
#if !NETFX_CORE
        public static Delegate CreateDelegate(this MethodInfo methodInfo, Type delegateType, object instance)
        {
            return Delegate.CreateDelegate(delegateType, instance, methodInfo);
        }
        public static Type GetTypeInfo(this Type type)
        {
            return type;
        }
        public static Type AsType(this Type type)
        {
            return type;
        }
        public static string GetDelegateName(this Delegate delegateInstance)
        {
            return delegateInstance.Method.Name;
        }
#else
        public static bool IsInstanceOfType(this Type type, object obj)
        {
            return obj != null && type.GetTypeInfo().IsAssignableFrom(obj.GetType().GetTypeInfo());
        }
        public static string GetDelegateName(this Delegate delegateInstance)
        {
            return delegateInstance.ToString();
        }
        public static MethodInfo GetMethod(this Type type, string methodName)
        {
            return type.GetTypeInfo().GetDeclaredMethod(methodName);
        }
        public static IEnumerable<FieldInfo> GetFields(this TypeInfo typeInfo)
        {
            return typeInfo.DeclaredFields;
        }
        public static TypeInfo GetTypeInfo(this TypeInfo typeInfo)
        {
            return typeInfo;
        }
        public static IEnumerable<ConstructorInfo> GetConstructors(this TypeInfo typeInfo)
        {
            return typeInfo.DeclaredConstructors;
        }
        public static IEnumerable<MethodInfo> GetMethods(this TypeInfo typeInfo, BindingFlags ignored)
        {
            return typeInfo.DeclaredMethods;
        }
        public static IEnumerable<TypeInfo> GetTypes(this Assembly assembly)
        {
            return assembly.DefinedTypes;
        }
#endif
    }
}
