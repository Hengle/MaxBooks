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
    public class UnityEngineTimeWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.Time), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(UnityEngine.Time), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.Time), L, __CreateInstance, 1, 18, 5);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.Time));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "time", _g_get_time);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "timeSinceLevelLoad", _g_get_timeSinceLevelLoad);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "deltaTime", _g_get_deltaTime);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "fixedTime", _g_get_fixedTime);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "unscaledTime", _g_get_unscaledTime);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "fixedUnscaledTime", _g_get_fixedUnscaledTime);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "unscaledDeltaTime", _g_get_unscaledDeltaTime);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "fixedUnscaledDeltaTime", _g_get_fixedUnscaledDeltaTime);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "fixedDeltaTime", _g_get_fixedDeltaTime);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "maximumDeltaTime", _g_get_maximumDeltaTime);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "smoothDeltaTime", _g_get_smoothDeltaTime);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "maximumParticleDeltaTime", _g_get_maximumParticleDeltaTime);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "timeScale", _g_get_timeScale);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "frameCount", _g_get_frameCount);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "renderedFrameCount", _g_get_renderedFrameCount);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "realtimeSinceStartup", _g_get_realtimeSinceStartup);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "captureFramerate", _g_get_captureFramerate);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "inFixedTimeStep", _g_get_inFixedTimeStep);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "fixedDeltaTime", _s_set_fixedDeltaTime);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "maximumDeltaTime", _s_set_maximumDeltaTime);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "maximumParticleDeltaTime", _s_set_maximumParticleDeltaTime);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "timeScale", _s_set_timeScale);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "captureFramerate", _s_set_captureFramerate);
            
			XUtils.EndClassRegister(typeof(UnityEngine.Time), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.Time __cl_gen_ret = new UnityEngine.Time();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Time constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_time(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.time);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_timeSinceLevelLoad(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.timeSinceLevelLoad);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_deltaTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.deltaTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fixedTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.fixedTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_unscaledTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.unscaledTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fixedUnscaledTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.fixedUnscaledTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_unscaledDeltaTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.unscaledDeltaTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fixedUnscaledDeltaTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.fixedUnscaledDeltaTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fixedDeltaTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.fixedDeltaTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maximumDeltaTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.maximumDeltaTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_smoothDeltaTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.smoothDeltaTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maximumParticleDeltaTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.maximumParticleDeltaTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_timeScale(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.timeScale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_frameCount(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, UnityEngine.Time.frameCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_renderedFrameCount(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, UnityEngine.Time.renderedFrameCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_realtimeSinceStartup(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushnumber(L, UnityEngine.Time.realtimeSinceStartup);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_captureFramerate(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, UnityEngine.Time.captureFramerate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_inFixedTimeStep(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, UnityEngine.Time.inFixedTimeStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fixedDeltaTime(RealStatePtr L)
        {
            
            try {
			    UnityEngine.Time.fixedDeltaTime = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maximumDeltaTime(RealStatePtr L)
        {
            
            try {
			    UnityEngine.Time.maximumDeltaTime = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maximumParticleDeltaTime(RealStatePtr L)
        {
            
            try {
			    UnityEngine.Time.maximumParticleDeltaTime = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_timeScale(RealStatePtr L)
        {
            
            try {
			    UnityEngine.Time.timeScale = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_captureFramerate(RealStatePtr L)
        {
            
            try {
			    UnityEngine.Time.captureFramerate = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
