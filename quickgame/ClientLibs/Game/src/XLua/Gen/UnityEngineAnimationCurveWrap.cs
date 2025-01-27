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
    public class UnityEngineAnimationCurveWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.AnimationCurve), L, translator, 0, 5, 4, 3);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Evaluate", _m_Evaluate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddKey", _m_AddKey);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MoveKey", _m_MoveKey);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveKey", _m_RemoveKey);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SmoothTangents", _m_SmoothTangents);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "keys", _g_get_keys);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "length", _g_get_length);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "preWrapMode", _g_get_preWrapMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "postWrapMode", _g_get_postWrapMode);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "keys", _s_set_keys);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "preWrapMode", _s_set_preWrapMode);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "postWrapMode", _s_set_postWrapMode);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.AnimationCurve), L, translator, __CSIndexer, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.AnimationCurve), L, __CreateInstance, 4, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Constant", _m_Constant_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Linear", _m_Linear_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "EaseInOut", _m_EaseInOut_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.AnimationCurve));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.AnimationCurve), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) >= 1 && (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || translator.Assignable<UnityEngine.Keyframe>(L, 2)))
				{
					UnityEngine.Keyframe[] keys = translator.GetParams<UnityEngine.Keyframe>(L, 2);
					
					UnityEngine.AnimationCurve __cl_gen_ret = new UnityEngine.AnimationCurve(keys);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.AnimationCurve __cl_gen_ret = new UnityEngine.AnimationCurve();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.AnimationCurve constructor!");
            
        }
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __CSIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				
				if (translator.Assignable<UnityEngine.AnimationCurve>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					
					UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
					int index = LuaAPI.xlua_tointeger(L, 2);
					LuaAPI.lua_pushboolean(L, true);
					translator.Push(L, __cl_gen_to_be_invoked[index]);
					return 2;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
			
            LuaAPI.lua_pushboolean(L, false);
			return 1;
        }
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Evaluate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float time = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        float __cl_gen_ret = __cl_gen_to_be_invoked.Evaluate( time );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddKey(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    float time = (float)LuaAPI.lua_tonumber(L, 2);
                    float value = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.AddKey( time, value );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Keyframe>(L, 2)) 
                {
                    UnityEngine.Keyframe key;translator.Get(L, 2, out key);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.AddKey( key );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.AnimationCurve.AddKey!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveKey(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.Keyframe key;translator.Get(L, 3, out key);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.MoveKey( index, key );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveKey(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveKey( index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SmoothTangents(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    float weight = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.SmoothTangents( index, weight );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Constant_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    float timeStart = (float)LuaAPI.lua_tonumber(L, 1);
                    float timeEnd = (float)LuaAPI.lua_tonumber(L, 2);
                    float value = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        UnityEngine.AnimationCurve __cl_gen_ret = UnityEngine.AnimationCurve.Constant( timeStart, timeEnd, value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Linear_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    float timeStart = (float)LuaAPI.lua_tonumber(L, 1);
                    float valueStart = (float)LuaAPI.lua_tonumber(L, 2);
                    float timeEnd = (float)LuaAPI.lua_tonumber(L, 3);
                    float valueEnd = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        UnityEngine.AnimationCurve __cl_gen_ret = UnityEngine.AnimationCurve.Linear( timeStart, valueStart, timeEnd, valueEnd );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EaseInOut_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    float timeStart = (float)LuaAPI.lua_tonumber(L, 1);
                    float valueStart = (float)LuaAPI.lua_tonumber(L, 2);
                    float timeEnd = (float)LuaAPI.lua_tonumber(L, 3);
                    float valueEnd = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        UnityEngine.AnimationCurve __cl_gen_ret = UnityEngine.AnimationCurve.EaseInOut( timeStart, valueStart, timeEnd, valueEnd );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_keys(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.keys);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_length(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.length);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_preWrapMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.preWrapMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_postWrapMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.postWrapMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_keys(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.keys = (UnityEngine.Keyframe[])translator.GetObject(L, 2, typeof(UnityEngine.Keyframe[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_preWrapMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
                UnityEngine.WrapMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.preWrapMode = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_postWrapMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.AnimationCurve __cl_gen_to_be_invoked = (UnityEngine.AnimationCurve)translator.FastGetCSObj(L, 1);
                UnityEngine.WrapMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.postWrapMode = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
