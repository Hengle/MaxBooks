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
    public class UnityEngineApplicationWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.Application), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(UnityEngine.Application), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.Application), L, __CreateInstance, 19, 29, 3);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Quit", _m_Quit_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CancelQuit", _m_CancelQuit_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Unload", _m_Unload_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStreamProgressForLevel", _m_GetStreamProgressForLevel_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CanStreamedLevelBeLoaded", _m_CanStreamedLevelBeLoaded_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBuildTags", _m_GetBuildTags_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SetBuildTags", _m_SetBuildTags_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "HasProLicense", _m_HasProLicense_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "RequestAdvertisingIdentifierAsync", _m_RequestAdvertisingIdentifierAsync_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "OpenURL", _m_OpenURL_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetStackTraceLogType", _m_GetStackTraceLogType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SetStackTraceLogType", _m_SetStackTraceLogType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "RequestUserAuthorization", _m_RequestUserAuthorization_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "HasUserAuthorization", _m_HasUserAuthorization_xlua_st_);
            
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "lowMemory", _e_lowMemory);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "logMessageReceived", _e_logMessageReceived);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "logMessageReceivedThreaded", _e_logMessageReceivedThreaded);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "onBeforeRender", _e_onBeforeRender);
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.Application));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "streamedBytes", _g_get_streamedBytes);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "isPlaying", _g_get_isPlaying);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "isFocused", _g_get_isFocused);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "isEditor", _g_get_isEditor);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "platform", _g_get_platform);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "buildGUID", _g_get_buildGUID);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "isMobilePlatform", _g_get_isMobilePlatform);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "isConsolePlatform", _g_get_isConsolePlatform);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "runInBackground", _g_get_runInBackground);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "dataPath", _g_get_dataPath);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "streamingAssetsPath", _g_get_streamingAssetsPath);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "persistentDataPath", _g_get_persistentDataPath);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "temporaryCachePath", _g_get_temporaryCachePath);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "absoluteURL", _g_get_absoluteURL);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "unityVersion", _g_get_unityVersion);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "version", _g_get_version);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "installerName", _g_get_installerName);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "identifier", _g_get_identifier);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "installMode", _g_get_installMode);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "sandboxType", _g_get_sandboxType);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "productName", _g_get_productName);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "companyName", _g_get_companyName);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "cloudProjectId", _g_get_cloudProjectId);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "targetFrameRate", _g_get_targetFrameRate);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "systemLanguage", _g_get_systemLanguage);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "backgroundLoadingPriority", _g_get_backgroundLoadingPriority);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "internetReachability", _g_get_internetReachability);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "genuine", _g_get_genuine);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "genuineCheckAvailable", _g_get_genuineCheckAvailable);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "runInBackground", _s_set_runInBackground);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "targetFrameRate", _s_set_targetFrameRate);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "backgroundLoadingPriority", _s_set_backgroundLoadingPriority);
            
			XUtils.EndClassRegister(typeof(UnityEngine.Application), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.Application __cl_gen_ret = new UnityEngine.Application();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Application constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Quit_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    UnityEngine.Application.Quit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CancelQuit_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    UnityEngine.Application.CancelQuit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unload_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    UnityEngine.Application.Unload(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStreamProgressForLevel_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int levelIndex = LuaAPI.xlua_tointeger(L, 1);
                    
                        float __cl_gen_ret = UnityEngine.Application.GetStreamProgressForLevel( levelIndex );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string levelName = LuaAPI.lua_tostring(L, 1);
                    
                        float __cl_gen_ret = UnityEngine.Application.GetStreamProgressForLevel( levelName );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Application.GetStreamProgressForLevel!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanStreamedLevelBeLoaded_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int levelIndex = LuaAPI.xlua_tointeger(L, 1);
                    
                        bool __cl_gen_ret = UnityEngine.Application.CanStreamedLevelBeLoaded( levelIndex );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string levelName = LuaAPI.lua_tostring(L, 1);
                    
                        bool __cl_gen_ret = UnityEngine.Application.CanStreamedLevelBeLoaded( levelName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Application.CanStreamedLevelBeLoaded!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBuildTags_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        string[] __cl_gen_ret = UnityEngine.Application.GetBuildTags(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBuildTags_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string[] buildTags = (string[])translator.GetObject(L, 1, typeof(string[]));
                    
                    UnityEngine.Application.SetBuildTags( buildTags );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasProLicense_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = UnityEngine.Application.HasProLicense(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RequestAdvertisingIdentifierAsync_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Application.AdvertisingIdentifierCallback delegateMethod = translator.GetDelegate<UnityEngine.Application.AdvertisingIdentifierCallback>(L, 1);
                    
                        bool __cl_gen_ret = UnityEngine.Application.RequestAdvertisingIdentifierAsync( delegateMethod );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenURL_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 1);
                    
                    UnityEngine.Application.OpenURL( url );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStackTraceLogType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.LogType logType;translator.Get(L, 1, out logType);
                    
                        UnityEngine.StackTraceLogType __cl_gen_ret = UnityEngine.Application.GetStackTraceLogType( logType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetStackTraceLogType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.LogType logType;translator.Get(L, 1, out logType);
                    UnityEngine.StackTraceLogType stackTraceType;translator.Get(L, 2, out stackTraceType);
                    
                    UnityEngine.Application.SetStackTraceLogType( logType, stackTraceType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RequestUserAuthorization_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.UserAuthorization mode;translator.Get(L, 1, out mode);
                    
                        UnityEngine.AsyncOperation __cl_gen_ret = UnityEngine.Application.RequestUserAuthorization( mode );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasUserAuthorization_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.UserAuthorization mode;translator.Get(L, 1, out mode);
                    
                        bool __cl_gen_ret = UnityEngine.Application.HasUserAuthorization( mode );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_streamedBytes(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, UnityEngine.Application.streamedBytes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isPlaying(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, UnityEngine.Application.isPlaying);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isFocused(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, UnityEngine.Application.isFocused);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isEditor(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, UnityEngine.Application.isEditor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_platform(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.PushUnityEngineRuntimePlatform(L, UnityEngine.Application.platform);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_buildGUID(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.buildGUID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isMobilePlatform(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, UnityEngine.Application.isMobilePlatform);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isConsolePlatform(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, UnityEngine.Application.isConsolePlatform);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_runInBackground(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, UnityEngine.Application.runInBackground);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dataPath(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.dataPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_streamingAssetsPath(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.streamingAssetsPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_persistentDataPath(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.persistentDataPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_temporaryCachePath(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.temporaryCachePath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_absoluteURL(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.absoluteURL);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_unityVersion(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.unityVersion);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_version(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.version);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_installerName(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.installerName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_identifier(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.identifier);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_installMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, UnityEngine.Application.installMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sandboxType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, UnityEngine.Application.sandboxType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_productName(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.productName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_companyName(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.companyName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cloudProjectId(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, UnityEngine.Application.cloudProjectId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_targetFrameRate(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, UnityEngine.Application.targetFrameRate);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_systemLanguage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, UnityEngine.Application.systemLanguage);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_backgroundLoadingPriority(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, UnityEngine.Application.backgroundLoadingPriority);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_internetReachability(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, UnityEngine.Application.internetReachability);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_genuine(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, UnityEngine.Application.genuine);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_genuineCheckAvailable(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, UnityEngine.Application.genuineCheckAvailable);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_runInBackground(RealStatePtr L)
        {
            
            try {
			    UnityEngine.Application.runInBackground = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_targetFrameRate(RealStatePtr L)
        {
            
            try {
			    UnityEngine.Application.targetFrameRate = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_backgroundLoadingPriority(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			UnityEngine.ThreadPriority __cl_gen_value;translator.Get(L, 1, out __cl_gen_value);
				UnityEngine.Application.backgroundLoadingPriority = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_lowMemory(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			int __gen_param_count = LuaAPI.lua_gettop(L);
            try {
                UnityEngine.Application.LowMemoryCallback __gen_delegate = translator.GetDelegate<UnityEngine.Application.LowMemoryCallback>(L, 2);
                if (__gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#2 need UnityEngine.Application.LowMemoryCallback!");
                }
                
				
				if (__gen_param_count == 2 && LuaAPI.lua_tostring(L, 1) == "+") {
					UnityEngine.Application.lowMemory += __gen_delegate;
					return 0;
				} 
				
				
				if (__gen_param_count == 2 && LuaAPI.lua_tostring(L, 1) == "-") {
					UnityEngine.Application.lowMemory -= __gen_delegate;
					return 0;
				} 
				
			} catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
			return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Application.lowMemory!");
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_logMessageReceived(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			int __gen_param_count = LuaAPI.lua_gettop(L);
            try {
                UnityEngine.Application.LogCallback __gen_delegate = translator.GetDelegate<UnityEngine.Application.LogCallback>(L, 2);
                if (__gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#2 need UnityEngine.Application.LogCallback!");
                }
                
				
				if (__gen_param_count == 2 && LuaAPI.lua_tostring(L, 1) == "+") {
					UnityEngine.Application.logMessageReceived += __gen_delegate;
					return 0;
				} 
				
				
				if (__gen_param_count == 2 && LuaAPI.lua_tostring(L, 1) == "-") {
					UnityEngine.Application.logMessageReceived -= __gen_delegate;
					return 0;
				} 
				
			} catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
			return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Application.logMessageReceived!");
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_logMessageReceivedThreaded(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			int __gen_param_count = LuaAPI.lua_gettop(L);
            try {
                UnityEngine.Application.LogCallback __gen_delegate = translator.GetDelegate<UnityEngine.Application.LogCallback>(L, 2);
                if (__gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#2 need UnityEngine.Application.LogCallback!");
                }
                
				
				if (__gen_param_count == 2 && LuaAPI.lua_tostring(L, 1) == "+") {
					UnityEngine.Application.logMessageReceivedThreaded += __gen_delegate;
					return 0;
				} 
				
				
				if (__gen_param_count == 2 && LuaAPI.lua_tostring(L, 1) == "-") {
					UnityEngine.Application.logMessageReceivedThreaded -= __gen_delegate;
					return 0;
				} 
				
			} catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
			return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Application.logMessageReceivedThreaded!");
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_onBeforeRender(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			int __gen_param_count = LuaAPI.lua_gettop(L);
            try {
                UnityEngine.Events.UnityAction __gen_delegate = translator.GetDelegate<UnityEngine.Events.UnityAction>(L, 2);
                if (__gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#2 need UnityEngine.Events.UnityAction!");
                }
                
				
				if (__gen_param_count == 2 && LuaAPI.lua_tostring(L, 1) == "+") {
					UnityEngine.Application.onBeforeRender += __gen_delegate;
					return 0;
				} 
				
				
				if (__gen_param_count == 2 && LuaAPI.lua_tostring(L, 1) == "-") {
					UnityEngine.Application.onBeforeRender -= __gen_delegate;
					return 0;
				} 
				
			} catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
			return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Application.onBeforeRender!");
        }
        
    }
}
