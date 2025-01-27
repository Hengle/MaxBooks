﻿#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class SystemTypeWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(System.Type), L, translator, 0, 37, 55, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Equals", _m_Equals);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetType", _m_GetType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsSubclassOf", _m_IsSubclassOf);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FindInterfaces", _m_FindInterfaces);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetInterface", _m_GetInterface);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetInterfaceMap", _m_GetInterfaceMap);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetInterfaces", _m_GetInterfaces);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsAssignableFrom", _m_IsAssignableFrom);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInstanceOfType", _m_IsInstanceOfType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetArrayRank", _m_GetArrayRank);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetElementType", _m_GetElementType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetEvent", _m_GetEvent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetEvents", _m_GetEvents);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetField", _m_GetField);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFields", _m_GetFields);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetHashCode", _m_GetHashCode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMember", _m_GetMember);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMembers", _m_GetMembers);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMethod", _m_GetMethod);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMethods", _m_GetMethods);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNestedType", _m_GetNestedType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNestedTypes", _m_GetNestedTypes);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetProperties", _m_GetProperties);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetProperty", _m_GetProperty);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetConstructor", _m_GetConstructor);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetConstructors", _m_GetConstructors);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetDefaultMembers", _m_GetDefaultMembers);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FindMembers", _m_FindMembers);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InvokeMember", _m_InvokeMember);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToString", _m_ToString);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGenericArguments", _m_GetGenericArguments);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGenericTypeDefinition", _m_GetGenericTypeDefinition);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MakeGenericType", _m_MakeGenericType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGenericParameterConstraints", _m_GetGenericParameterConstraints);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MakeArrayType", _m_MakeArrayType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MakeByRefType", _m_MakeByRefType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MakePointerType", _m_MakePointerType);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Assembly", _g_get_Assembly);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AssemblyQualifiedName", _g_get_AssemblyQualifiedName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Attributes", _g_get_Attributes);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BaseType", _g_get_BaseType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeclaringType", _g_get_DeclaringType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FullName", _g_get_FullName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GUID", _g_get_GUID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HasElementType", _g_get_HasElementType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsAbstract", _g_get_IsAbstract);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsAnsiClass", _g_get_IsAnsiClass);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsArray", _g_get_IsArray);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsAutoClass", _g_get_IsAutoClass);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsAutoLayout", _g_get_IsAutoLayout);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsByRef", _g_get_IsByRef);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsClass", _g_get_IsClass);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsCOMObject", _g_get_IsCOMObject);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsContextful", _g_get_IsContextful);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsEnum", _g_get_IsEnum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsExplicitLayout", _g_get_IsExplicitLayout);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsImport", _g_get_IsImport);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsInterface", _g_get_IsInterface);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsLayoutSequential", _g_get_IsLayoutSequential);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsMarshalByRef", _g_get_IsMarshalByRef);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNestedAssembly", _g_get_IsNestedAssembly);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNestedFamANDAssem", _g_get_IsNestedFamANDAssem);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNestedFamily", _g_get_IsNestedFamily);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNestedFamORAssem", _g_get_IsNestedFamORAssem);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNestedPrivate", _g_get_IsNestedPrivate);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNestedPublic", _g_get_IsNestedPublic);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNotPublic", _g_get_IsNotPublic);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPointer", _g_get_IsPointer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPrimitive", _g_get_IsPrimitive);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPublic", _g_get_IsPublic);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsSealed", _g_get_IsSealed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsSerializable", _g_get_IsSerializable);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsSpecialName", _g_get_IsSpecialName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsUnicodeClass", _g_get_IsUnicodeClass);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsValueType", _g_get_IsValueType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MemberType", _g_get_MemberType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Module", _g_get_Module);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Namespace", _g_get_Namespace);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ReflectedType", _g_get_ReflectedType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TypeHandle", _g_get_TypeHandle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TypeInitializer", _g_get_TypeInitializer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UnderlyingSystemType", _g_get_UnderlyingSystemType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ContainsGenericParameters", _g_get_ContainsGenericParameters);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsGenericTypeDefinition", _g_get_IsGenericTypeDefinition);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsGenericType", _g_get_IsGenericType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsGenericParameter", _g_get_IsGenericParameter);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsNested", _g_get_IsNested);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsVisible", _g_get_IsVisible);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GenericParameterPosition", _g_get_GenericParameterPosition);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GenericParameterAttributes", _g_get_GenericParameterAttributes);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeclaringMethod", _g_get_DeclaringMethod);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StructLayoutAttribute", _g_get_StructLayoutAttribute);
            
			
			XUtils.EndObjectRegister(typeof(System.Type), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(System.Type), L, __CreateInstance, 14, 1, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetType", _m_GetType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTypeArray", _m_GetTypeArray_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTypeCode", _m_GetTypeCode_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTypeFromCLSID", _m_GetTypeFromCLSID_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTypeFromHandle", _m_GetTypeFromHandle_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTypeFromProgID", _m_GetTypeFromProgID_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTypeHandle", _m_GetTypeHandle_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReflectionOnlyGetType", _m_ReflectionOnlyGetType_xlua_st_);
            
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "Delimiter", System.Type.Delimiter);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "EmptyTypes", System.Type.EmptyTypes);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FilterAttribute", System.Type.FilterAttribute);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FilterName", System.Type.FilterName);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "FilterNameIgnoreCase", System.Type.FilterNameIgnoreCase);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(System.Type));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "DefaultBinder", _g_get_DefaultBinder);
            
			
			XUtils.EndClassRegister(typeof(System.Type), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "System.Type does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Equals(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object o = translator.GetObject(L, 2, typeof(object));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Equals( o );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 2)) 
                {
                    System.Type o = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Equals( o );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.Equals!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string typeName = LuaAPI.lua_tostring(L, 1);
                    
                        System.Type __cl_gen_ret = System.Type.GetType( typeName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    string typeName = LuaAPI.lua_tostring(L, 1);
                    bool throwOnError = LuaAPI.lua_toboolean(L, 2);
                    
                        System.Type __cl_gen_ret = System.Type.GetType( typeName, throwOnError );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string typeName = LuaAPI.lua_tostring(L, 1);
                    bool throwOnError = LuaAPI.lua_toboolean(L, 2);
                    bool ignoreCase = LuaAPI.lua_toboolean(L, 3);
                    
                        System.Type __cl_gen_ret = System.Type.GetType( typeName, throwOnError, ignoreCase );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetType!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTypeArray_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    object[] args = (object[])translator.GetObject(L, 1, typeof(object[]));
                    
                        System.Type[] __cl_gen_ret = System.Type.GetTypeArray( args );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTypeCode_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Type type = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    
                        System.TypeCode __cl_gen_ret = System.Type.GetTypeCode( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTypeFromCLSID_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& translator.Assignable<System.Guid>(L, 1)) 
                {
                    System.Guid clsid;translator.Get(L, 1, out clsid);
                    
                        System.Type __cl_gen_ret = System.Type.GetTypeFromCLSID( clsid );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Guid>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    System.Guid clsid;translator.Get(L, 1, out clsid);
                    bool throwOnError = LuaAPI.lua_toboolean(L, 2);
                    
                        System.Type __cl_gen_ret = System.Type.GetTypeFromCLSID( clsid, throwOnError );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Guid>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Guid clsid;translator.Get(L, 1, out clsid);
                    string server = LuaAPI.lua_tostring(L, 2);
                    
                        System.Type __cl_gen_ret = System.Type.GetTypeFromCLSID( clsid, server );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<System.Guid>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    System.Guid clsid;translator.Get(L, 1, out clsid);
                    string server = LuaAPI.lua_tostring(L, 2);
                    bool throwOnError = LuaAPI.lua_toboolean(L, 3);
                    
                        System.Type __cl_gen_ret = System.Type.GetTypeFromCLSID( clsid, server, throwOnError );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetTypeFromCLSID!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTypeFromHandle_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.RuntimeTypeHandle handle;translator.Get(L, 1, out handle);
                    
                        System.Type __cl_gen_ret = System.Type.GetTypeFromHandle( handle );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTypeFromProgID_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string progID = LuaAPI.lua_tostring(L, 1);
                    
                        System.Type __cl_gen_ret = System.Type.GetTypeFromProgID( progID );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    string progID = LuaAPI.lua_tostring(L, 1);
                    bool throwOnError = LuaAPI.lua_toboolean(L, 2);
                    
                        System.Type __cl_gen_ret = System.Type.GetTypeFromProgID( progID, throwOnError );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string progID = LuaAPI.lua_tostring(L, 1);
                    string server = LuaAPI.lua_tostring(L, 2);
                    
                        System.Type __cl_gen_ret = System.Type.GetTypeFromProgID( progID, server );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string progID = LuaAPI.lua_tostring(L, 1);
                    string server = LuaAPI.lua_tostring(L, 2);
                    bool throwOnError = LuaAPI.lua_toboolean(L, 3);
                    
                        System.Type __cl_gen_ret = System.Type.GetTypeFromProgID( progID, server, throwOnError );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetTypeFromProgID!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTypeHandle_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    object o = translator.GetObject(L, 1, typeof(object));
                    
                        System.RuntimeTypeHandle __cl_gen_ret = System.Type.GetTypeHandle( o );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Type __cl_gen_ret = __cl_gen_to_be_invoked.GetType(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSubclassOf(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Type c = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsSubclassOf( c );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindInterfaces(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Reflection.TypeFilter filter = translator.GetDelegate<System.Reflection.TypeFilter>(L, 2);
                    object filterCriteria = translator.GetObject(L, 3, typeof(object));
                    
                        System.Type[] __cl_gen_ret = __cl_gen_to_be_invoked.FindInterfaces( filter, filterCriteria );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInterface(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        System.Type __cl_gen_ret = __cl_gen_to_be_invoked.GetInterface( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    bool ignoreCase = LuaAPI.lua_toboolean(L, 3);
                    
                        System.Type __cl_gen_ret = __cl_gen_to_be_invoked.GetInterface( name, ignoreCase );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetInterface!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInterfaceMap(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Type interfaceType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        System.Reflection.InterfaceMapping __cl_gen_ret = __cl_gen_to_be_invoked.GetInterfaceMap( interfaceType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInterfaces(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Type[] __cl_gen_ret = __cl_gen_to_be_invoked.GetInterfaces(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsAssignableFrom(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Type c = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsAssignableFrom( c );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInstanceOfType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object o = translator.GetObject(L, 2, typeof(object));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInstanceOfType( o );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetArrayRank(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetArrayRank(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetElementType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Type __cl_gen_ret = __cl_gen_to_be_invoked.GetElementType(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEvent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        System.Reflection.EventInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetEvent( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.BindingFlags>(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 3, out bindingAttr);
                    
                        System.Reflection.EventInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetEvent( name, bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetEvent!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEvents(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        System.Reflection.EventInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetEvents(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Reflection.BindingFlags>(L, 2)) 
                {
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 2, out bindingAttr);
                    
                        System.Reflection.EventInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetEvents( bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetEvents!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetField(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        System.Reflection.FieldInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetField( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.BindingFlags>(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 3, out bindingAttr);
                    
                        System.Reflection.FieldInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetField( name, bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetField!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFields(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        System.Reflection.FieldInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetFields(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Reflection.BindingFlags>(L, 2)) 
                {
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 2, out bindingAttr);
                    
                        System.Reflection.FieldInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetFields( bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetFields!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHashCode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetHashCode(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMember(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        System.Reflection.MemberInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetMember( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.BindingFlags>(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 3, out bindingAttr);
                    
                        System.Reflection.MemberInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetMember( name, bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.MemberTypes>(L, 3)&& translator.Assignable<System.Reflection.BindingFlags>(L, 4)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.MemberTypes type;translator.Get(L, 3, out type);
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 4, out bindingAttr);
                    
                        System.Reflection.MemberInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetMember( name, type, bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetMember!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMembers(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        System.Reflection.MemberInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetMembers(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Reflection.BindingFlags>(L, 2)) 
                {
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 2, out bindingAttr);
                    
                        System.Reflection.MemberInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetMembers( bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetMembers!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMethod(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        System.Reflection.MethodInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetMethod( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.BindingFlags>(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 3, out bindingAttr);
                    
                        System.Reflection.MethodInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetMethod( name, bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Type[]>(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Type[] types = (System.Type[])translator.GetObject(L, 3, typeof(System.Type[]));
                    
                        System.Reflection.MethodInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetMethod( name, types );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Type[]>(L, 3)&& translator.Assignable<System.Reflection.ParameterModifier[]>(L, 4)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Type[] types = (System.Type[])translator.GetObject(L, 3, typeof(System.Type[]));
                    System.Reflection.ParameterModifier[] modifiers = (System.Reflection.ParameterModifier[])translator.GetObject(L, 4, typeof(System.Reflection.ParameterModifier[]));
                    
                        System.Reflection.MethodInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetMethod( name, types, modifiers );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.BindingFlags>(L, 3)&& translator.Assignable<System.Reflection.Binder>(L, 4)&& translator.Assignable<System.Type[]>(L, 5)&& translator.Assignable<System.Reflection.ParameterModifier[]>(L, 6)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 3, out bindingAttr);
                    System.Reflection.Binder binder = (System.Reflection.Binder)translator.GetObject(L, 4, typeof(System.Reflection.Binder));
                    System.Type[] types = (System.Type[])translator.GetObject(L, 5, typeof(System.Type[]));
                    System.Reflection.ParameterModifier[] modifiers = (System.Reflection.ParameterModifier[])translator.GetObject(L, 6, typeof(System.Reflection.ParameterModifier[]));
                    
                        System.Reflection.MethodInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetMethod( name, bindingAttr, binder, types, modifiers );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.BindingFlags>(L, 3)&& translator.Assignable<System.Reflection.Binder>(L, 4)&& translator.Assignable<System.Reflection.CallingConventions>(L, 5)&& translator.Assignable<System.Type[]>(L, 6)&& translator.Assignable<System.Reflection.ParameterModifier[]>(L, 7)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 3, out bindingAttr);
                    System.Reflection.Binder binder = (System.Reflection.Binder)translator.GetObject(L, 4, typeof(System.Reflection.Binder));
                    System.Reflection.CallingConventions callConvention;translator.Get(L, 5, out callConvention);
                    System.Type[] types = (System.Type[])translator.GetObject(L, 6, typeof(System.Type[]));
                    System.Reflection.ParameterModifier[] modifiers = (System.Reflection.ParameterModifier[])translator.GetObject(L, 7, typeof(System.Reflection.ParameterModifier[]));
                    
                        System.Reflection.MethodInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetMethod( name, bindingAttr, binder, callConvention, types, modifiers );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetMethod!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMethods(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        System.Reflection.MethodInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetMethods(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Reflection.BindingFlags>(L, 2)) 
                {
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 2, out bindingAttr);
                    
                        System.Reflection.MethodInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetMethods( bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetMethods!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNestedType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        System.Type __cl_gen_ret = __cl_gen_to_be_invoked.GetNestedType( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.BindingFlags>(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 3, out bindingAttr);
                    
                        System.Type __cl_gen_ret = __cl_gen_to_be_invoked.GetNestedType( name, bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetNestedType!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNestedTypes(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        System.Type[] __cl_gen_ret = __cl_gen_to_be_invoked.GetNestedTypes(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Reflection.BindingFlags>(L, 2)) 
                {
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 2, out bindingAttr);
                    
                        System.Type[] __cl_gen_ret = __cl_gen_to_be_invoked.GetNestedTypes( bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetNestedTypes!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetProperties(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        System.Reflection.PropertyInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetProperties(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Reflection.BindingFlags>(L, 2)) 
                {
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 2, out bindingAttr);
                    
                        System.Reflection.PropertyInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetProperties( bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetProperties!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetProperty(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        System.Reflection.PropertyInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetProperty( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.BindingFlags>(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 3, out bindingAttr);
                    
                        System.Reflection.PropertyInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetProperty( name, bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Type>(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Type returnType = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    
                        System.Reflection.PropertyInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetProperty( name, returnType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Type[]>(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Type[] types = (System.Type[])translator.GetObject(L, 3, typeof(System.Type[]));
                    
                        System.Reflection.PropertyInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetProperty( name, types );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Type>(L, 3)&& translator.Assignable<System.Type[]>(L, 4)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Type returnType = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    System.Type[] types = (System.Type[])translator.GetObject(L, 4, typeof(System.Type[]));
                    
                        System.Reflection.PropertyInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetProperty( name, returnType, types );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Type>(L, 3)&& translator.Assignable<System.Type[]>(L, 4)&& translator.Assignable<System.Reflection.ParameterModifier[]>(L, 5)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Type returnType = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    System.Type[] types = (System.Type[])translator.GetObject(L, 4, typeof(System.Type[]));
                    System.Reflection.ParameterModifier[] modifiers = (System.Reflection.ParameterModifier[])translator.GetObject(L, 5, typeof(System.Reflection.ParameterModifier[]));
                    
                        System.Reflection.PropertyInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetProperty( name, returnType, types, modifiers );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.BindingFlags>(L, 3)&& translator.Assignable<System.Reflection.Binder>(L, 4)&& translator.Assignable<System.Type>(L, 5)&& translator.Assignable<System.Type[]>(L, 6)&& translator.Assignable<System.Reflection.ParameterModifier[]>(L, 7)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 3, out bindingAttr);
                    System.Reflection.Binder binder = (System.Reflection.Binder)translator.GetObject(L, 4, typeof(System.Reflection.Binder));
                    System.Type returnType = (System.Type)translator.GetObject(L, 5, typeof(System.Type));
                    System.Type[] types = (System.Type[])translator.GetObject(L, 6, typeof(System.Type[]));
                    System.Reflection.ParameterModifier[] modifiers = (System.Reflection.ParameterModifier[])translator.GetObject(L, 7, typeof(System.Reflection.ParameterModifier[]));
                    
                        System.Reflection.PropertyInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetProperty( name, bindingAttr, binder, returnType, types, modifiers );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetProperty!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetConstructor(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Type[]>(L, 2)) 
                {
                    System.Type[] types = (System.Type[])translator.GetObject(L, 2, typeof(System.Type[]));
                    
                        System.Reflection.ConstructorInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetConstructor( types );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& translator.Assignable<System.Reflection.BindingFlags>(L, 2)&& translator.Assignable<System.Reflection.Binder>(L, 3)&& translator.Assignable<System.Type[]>(L, 4)&& translator.Assignable<System.Reflection.ParameterModifier[]>(L, 5)) 
                {
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 2, out bindingAttr);
                    System.Reflection.Binder binder = (System.Reflection.Binder)translator.GetObject(L, 3, typeof(System.Reflection.Binder));
                    System.Type[] types = (System.Type[])translator.GetObject(L, 4, typeof(System.Type[]));
                    System.Reflection.ParameterModifier[] modifiers = (System.Reflection.ParameterModifier[])translator.GetObject(L, 5, typeof(System.Reflection.ParameterModifier[]));
                    
                        System.Reflection.ConstructorInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetConstructor( bindingAttr, binder, types, modifiers );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& translator.Assignable<System.Reflection.BindingFlags>(L, 2)&& translator.Assignable<System.Reflection.Binder>(L, 3)&& translator.Assignable<System.Reflection.CallingConventions>(L, 4)&& translator.Assignable<System.Type[]>(L, 5)&& translator.Assignable<System.Reflection.ParameterModifier[]>(L, 6)) 
                {
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 2, out bindingAttr);
                    System.Reflection.Binder binder = (System.Reflection.Binder)translator.GetObject(L, 3, typeof(System.Reflection.Binder));
                    System.Reflection.CallingConventions callConvention;translator.Get(L, 4, out callConvention);
                    System.Type[] types = (System.Type[])translator.GetObject(L, 5, typeof(System.Type[]));
                    System.Reflection.ParameterModifier[] modifiers = (System.Reflection.ParameterModifier[])translator.GetObject(L, 6, typeof(System.Reflection.ParameterModifier[]));
                    
                        System.Reflection.ConstructorInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetConstructor( bindingAttr, binder, callConvention, types, modifiers );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetConstructor!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetConstructors(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        System.Reflection.ConstructorInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetConstructors(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Reflection.BindingFlags>(L, 2)) 
                {
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 2, out bindingAttr);
                    
                        System.Reflection.ConstructorInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetConstructors( bindingAttr );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.GetConstructors!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDefaultMembers(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Reflection.MemberInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.GetDefaultMembers(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindMembers(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Reflection.MemberTypes memberType;translator.Get(L, 2, out memberType);
                    System.Reflection.BindingFlags bindingAttr;translator.Get(L, 3, out bindingAttr);
                    System.Reflection.MemberFilter filter = translator.GetDelegate<System.Reflection.MemberFilter>(L, 4);
                    object filterCriteria = translator.GetObject(L, 5, typeof(object));
                    
                        System.Reflection.MemberInfo[] __cl_gen_ret = __cl_gen_to_be_invoked.FindMembers( memberType, bindingAttr, filter, filterCriteria );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InvokeMember(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 6&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.BindingFlags>(L, 3)&& translator.Assignable<System.Reflection.Binder>(L, 4)&& translator.Assignable<object>(L, 5)&& translator.Assignable<object[]>(L, 6)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.BindingFlags invokeAttr;translator.Get(L, 3, out invokeAttr);
                    System.Reflection.Binder binder = (System.Reflection.Binder)translator.GetObject(L, 4, typeof(System.Reflection.Binder));
                    object target = translator.GetObject(L, 5, typeof(object));
                    object[] args = (object[])translator.GetObject(L, 6, typeof(object[]));
                    
                        object __cl_gen_ret = __cl_gen_to_be_invoked.InvokeMember( name, invokeAttr, binder, target, args );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.BindingFlags>(L, 3)&& translator.Assignable<System.Reflection.Binder>(L, 4)&& translator.Assignable<object>(L, 5)&& translator.Assignable<object[]>(L, 6)&& translator.Assignable<System.Globalization.CultureInfo>(L, 7)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.BindingFlags invokeAttr;translator.Get(L, 3, out invokeAttr);
                    System.Reflection.Binder binder = (System.Reflection.Binder)translator.GetObject(L, 4, typeof(System.Reflection.Binder));
                    object target = translator.GetObject(L, 5, typeof(object));
                    object[] args = (object[])translator.GetObject(L, 6, typeof(object[]));
                    System.Globalization.CultureInfo culture = (System.Globalization.CultureInfo)translator.GetObject(L, 7, typeof(System.Globalization.CultureInfo));
                    
                        object __cl_gen_ret = __cl_gen_to_be_invoked.InvokeMember( name, invokeAttr, binder, target, args, culture );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 9&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Reflection.BindingFlags>(L, 3)&& translator.Assignable<System.Reflection.Binder>(L, 4)&& translator.Assignable<object>(L, 5)&& translator.Assignable<object[]>(L, 6)&& translator.Assignable<System.Reflection.ParameterModifier[]>(L, 7)&& translator.Assignable<System.Globalization.CultureInfo>(L, 8)&& translator.Assignable<string[]>(L, 9)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Reflection.BindingFlags invokeAttr;translator.Get(L, 3, out invokeAttr);
                    System.Reflection.Binder binder = (System.Reflection.Binder)translator.GetObject(L, 4, typeof(System.Reflection.Binder));
                    object target = translator.GetObject(L, 5, typeof(object));
                    object[] args = (object[])translator.GetObject(L, 6, typeof(object[]));
                    System.Reflection.ParameterModifier[] modifiers = (System.Reflection.ParameterModifier[])translator.GetObject(L, 7, typeof(System.Reflection.ParameterModifier[]));
                    System.Globalization.CultureInfo culture = (System.Globalization.CultureInfo)translator.GetObject(L, 8, typeof(System.Globalization.CultureInfo));
                    string[] namedParameters = (string[])translator.GetObject(L, 9, typeof(string[]));
                    
                        object __cl_gen_ret = __cl_gen_to_be_invoked.InvokeMember( name, invokeAttr, binder, target, args, modifiers, culture, namedParameters );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.InvokeMember!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGenericArguments(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Type[] __cl_gen_ret = __cl_gen_to_be_invoked.GetGenericArguments(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGenericTypeDefinition(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Type __cl_gen_ret = __cl_gen_to_be_invoked.GetGenericTypeDefinition(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MakeGenericType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Type[] typeArguments = translator.GetParams<System.Type>(L, 2);
                    
                        System.Type __cl_gen_ret = __cl_gen_to_be_invoked.MakeGenericType( typeArguments );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGenericParameterConstraints(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Type[] __cl_gen_ret = __cl_gen_to_be_invoked.GetGenericParameterConstraints(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MakeArrayType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        System.Type __cl_gen_ret = __cl_gen_to_be_invoked.MakeArrayType(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int rank = LuaAPI.xlua_tointeger(L, 2);
                    
                        System.Type __cl_gen_ret = __cl_gen_to_be_invoked.MakeArrayType( rank );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Type.MakeArrayType!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MakeByRefType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Type __cl_gen_ret = __cl_gen_to_be_invoked.MakeByRefType(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MakePointerType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Type __cl_gen_ret = __cl_gen_to_be_invoked.MakePointerType(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReflectionOnlyGetType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string typeName = LuaAPI.lua_tostring(L, 1);
                    bool throwIfNotFound = LuaAPI.lua_toboolean(L, 2);
                    bool ignoreCase = LuaAPI.lua_toboolean(L, 3);
                    
                        System.Type __cl_gen_ret = System.Type.ReflectionOnlyGetType( typeName, throwIfNotFound, ignoreCase );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Assembly(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Assembly);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AssemblyQualifiedName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.AssemblyQualifiedName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Attributes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Attributes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BaseType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeclaringType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DeclaringType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultBinder(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, System.Type.DefaultBinder);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FullName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.FullName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GUID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.GUID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HasElementType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.HasElementType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAbstract(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsAbstract);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAnsiClass(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsAnsiClass);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAutoClass(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsAutoClass);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAutoLayout(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsAutoLayout);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsByRef(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsByRef);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsClass(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsClass);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCOMObject(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsCOMObject);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsContextful(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsContextful);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsEnum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsEnum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsExplicitLayout(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsExplicitLayout);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsImport(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsImport);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsInterface(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsInterface);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsLayoutSequential(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsLayoutSequential);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsMarshalByRef(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsMarshalByRef);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNestedAssembly(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNestedAssembly);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNestedFamANDAssem(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNestedFamANDAssem);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNestedFamily(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNestedFamily);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNestedFamORAssem(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNestedFamORAssem);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNestedPrivate(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNestedPrivate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNestedPublic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNestedPublic);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNotPublic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNotPublic);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPointer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPointer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPrimitive(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPrimitive);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPublic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPublic);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsSealed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsSealed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsSerializable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsSerializable);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsSpecialName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsSpecialName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsUnicodeClass(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsUnicodeClass);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsValueType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsValueType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MemberType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MemberType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Module(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Module);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Namespace(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Namespace);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReflectedType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ReflectedType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TypeHandle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.TypeHandle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TypeInitializer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.TypeInitializer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnderlyingSystemType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UnderlyingSystemType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ContainsGenericParameters(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ContainsGenericParameters);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsGenericTypeDefinition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsGenericTypeDefinition);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsGenericType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsGenericType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsGenericParameter(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsGenericParameter);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsNested(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsNested);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsVisible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsVisible);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GenericParameterPosition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.GenericParameterPosition);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GenericParameterAttributes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.GenericParameterAttributes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeclaringMethod(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.DeclaringMethod);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StructLayoutAttribute(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Type __cl_gen_to_be_invoked = (System.Type)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.StructLayoutAttribute);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
