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
    public class UnityEngineCanvasWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.Canvas), L, translator, 0, 0, 19, 14);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "renderMode", _g_get_renderMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isRootCanvas", _g_get_isRootCanvas);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "worldCamera", _g_get_worldCamera);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "pixelRect", _g_get_pixelRect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "scaleFactor", _g_get_scaleFactor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "referencePixelsPerUnit", _g_get_referencePixelsPerUnit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "overridePixelPerfect", _g_get_overridePixelPerfect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "pixelPerfect", _g_get_pixelPerfect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "planeDistance", _g_get_planeDistance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "renderOrder", _g_get_renderOrder);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "overrideSorting", _g_get_overrideSorting);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "sortingOrder", _g_get_sortingOrder);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "targetDisplay", _g_get_targetDisplay);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "normalizedSortingGridSize", _g_get_normalizedSortingGridSize);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "sortingLayerID", _g_get_sortingLayerID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "cachedSortingLayerValue", _g_get_cachedSortingLayerValue);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "additionalShaderChannels", _g_get_additionalShaderChannels);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "sortingLayerName", _g_get_sortingLayerName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "rootCanvas", _g_get_rootCanvas);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "renderMode", _s_set_renderMode);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "worldCamera", _s_set_worldCamera);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "scaleFactor", _s_set_scaleFactor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "referencePixelsPerUnit", _s_set_referencePixelsPerUnit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "overridePixelPerfect", _s_set_overridePixelPerfect);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "pixelPerfect", _s_set_pixelPerfect);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "planeDistance", _s_set_planeDistance);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "overrideSorting", _s_set_overrideSorting);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "sortingOrder", _s_set_sortingOrder);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "targetDisplay", _s_set_targetDisplay);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "normalizedSortingGridSize", _s_set_normalizedSortingGridSize);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "sortingLayerID", _s_set_sortingLayerID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "additionalShaderChannels", _s_set_additionalShaderChannels);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "sortingLayerName", _s_set_sortingLayerName);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.Canvas), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.Canvas), L, __CreateInstance, 5, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDefaultCanvasMaterial", _m_GetDefaultCanvasMaterial_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetETC1SupportedCanvasMaterial", _m_GetETC1SupportedCanvasMaterial_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ForceUpdateCanvases", _m_ForceUpdateCanvases_xlua_st_);
            
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "willRenderCanvases", _e_willRenderCanvases);
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.Canvas));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.Canvas), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.Canvas __cl_gen_ret = new UnityEngine.Canvas();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Canvas constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDefaultCanvasMaterial_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        UnityEngine.Material __cl_gen_ret = UnityEngine.Canvas.GetDefaultCanvasMaterial(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetETC1SupportedCanvasMaterial_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        UnityEngine.Material __cl_gen_ret = UnityEngine.Canvas.GetETC1SupportedCanvasMaterial(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceUpdateCanvases_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    UnityEngine.Canvas.ForceUpdateCanvases(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_renderMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.renderMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isRootCanvas(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isRootCanvas);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_worldCamera(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.worldCamera);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pixelRect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.pixelRect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scaleFactor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.scaleFactor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_referencePixelsPerUnit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.referencePixelsPerUnit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_overridePixelPerfect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.overridePixelPerfect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pixelPerfect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.pixelPerfect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_planeDistance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.planeDistance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_renderOrder(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.renderOrder);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_overrideSorting(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.overrideSorting);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sortingOrder(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.sortingOrder);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_targetDisplay(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.targetDisplay);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_normalizedSortingGridSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.normalizedSortingGridSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sortingLayerID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.sortingLayerID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cachedSortingLayerValue(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.cachedSortingLayerValue);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_additionalShaderChannels(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.additionalShaderChannels);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sortingLayerName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.sortingLayerName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rootCanvas(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.rootCanvas);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_renderMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                UnityEngine.RenderMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.renderMode = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_worldCamera(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.worldCamera = (UnityEngine.Camera)translator.GetObject(L, 2, typeof(UnityEngine.Camera));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scaleFactor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.scaleFactor = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_referencePixelsPerUnit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.referencePixelsPerUnit = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_overridePixelPerfect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.overridePixelPerfect = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pixelPerfect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.pixelPerfect = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_planeDistance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.planeDistance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_overrideSorting(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.overrideSorting = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sortingOrder(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sortingOrder = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_targetDisplay(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.targetDisplay = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_normalizedSortingGridSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.normalizedSortingGridSize = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sortingLayerID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sortingLayerID = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_additionalShaderChannels(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                UnityEngine.AdditionalCanvasShaderChannels __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.additionalShaderChannels = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sortingLayerName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Canvas __cl_gen_to_be_invoked = (UnityEngine.Canvas)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sortingLayerName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_willRenderCanvases(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			int __gen_param_count = LuaAPI.lua_gettop(L);
            try {
                UnityEngine.Canvas.WillRenderCanvases __gen_delegate = translator.GetDelegate<UnityEngine.Canvas.WillRenderCanvases>(L, 2);
                if (__gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#2 need UnityEngine.Canvas.WillRenderCanvases!");
                }
                
				
				if (__gen_param_count == 2 && LuaAPI.lua_tostring(L, 1) == "+") {
					UnityEngine.Canvas.willRenderCanvases += __gen_delegate;
					return 0;
				} 
				
				
				if (__gen_param_count == 2 && LuaAPI.lua_tostring(L, 1) == "-") {
					UnityEngine.Canvas.willRenderCanvases -= __gen_delegate;
					return 0;
				} 
				
			} catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
			return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Canvas.willRenderCanvases!");
        }
        
    }
}
