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
    public class UnityEngineRendererWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.Renderer), L, translator, 0, 3, 25, 20);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetPropertyBlock", _m_SetPropertyBlock);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPropertyBlock", _m_GetPropertyBlock);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetClosestReflectionProbes", _m_GetClosestReflectionProbes);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "bounds", _g_get_bounds);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "enabled", _g_get_enabled);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isVisible", _g_get_isVisible);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "shadowCastingMode", _g_get_shadowCastingMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "receiveShadows", _g_get_receiveShadows);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "motionVectorGenerationMode", _g_get_motionVectorGenerationMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "lightProbeUsage", _g_get_lightProbeUsage);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "reflectionProbeUsage", _g_get_reflectionProbeUsage);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "sortingLayerName", _g_get_sortingLayerName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "sortingLayerID", _g_get_sortingLayerID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "sortingOrder", _g_get_sortingOrder);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "allowOcclusionWhenDynamic", _g_get_allowOcclusionWhenDynamic);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isPartOfStaticBatch", _g_get_isPartOfStaticBatch);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "worldToLocalMatrix", _g_get_worldToLocalMatrix);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "localToWorldMatrix", _g_get_localToWorldMatrix);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "lightProbeProxyVolumeOverride", _g_get_lightProbeProxyVolumeOverride);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "probeAnchor", _g_get_probeAnchor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "lightmapIndex", _g_get_lightmapIndex);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "realtimeLightmapIndex", _g_get_realtimeLightmapIndex);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "lightmapScaleOffset", _g_get_lightmapScaleOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "realtimeLightmapScaleOffset", _g_get_realtimeLightmapScaleOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "material", _g_get_material);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "sharedMaterial", _g_get_sharedMaterial);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "materials", _g_get_materials);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "sharedMaterials", _g_get_sharedMaterials);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "enabled", _s_set_enabled);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "shadowCastingMode", _s_set_shadowCastingMode);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "receiveShadows", _s_set_receiveShadows);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "motionVectorGenerationMode", _s_set_motionVectorGenerationMode);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "lightProbeUsage", _s_set_lightProbeUsage);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "reflectionProbeUsage", _s_set_reflectionProbeUsage);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "sortingLayerName", _s_set_sortingLayerName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "sortingLayerID", _s_set_sortingLayerID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "sortingOrder", _s_set_sortingOrder);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "allowOcclusionWhenDynamic", _s_set_allowOcclusionWhenDynamic);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "lightProbeProxyVolumeOverride", _s_set_lightProbeProxyVolumeOverride);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "probeAnchor", _s_set_probeAnchor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "lightmapIndex", _s_set_lightmapIndex);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "realtimeLightmapIndex", _s_set_realtimeLightmapIndex);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "lightmapScaleOffset", _s_set_lightmapScaleOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "realtimeLightmapScaleOffset", _s_set_realtimeLightmapScaleOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "material", _s_set_material);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "sharedMaterial", _s_set_sharedMaterial);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "materials", _s_set_materials);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "sharedMaterials", _s_set_sharedMaterials);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.Renderer), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.Renderer), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.Renderer));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.Renderer), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.Renderer __cl_gen_ret = new UnityEngine.Renderer();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Renderer constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPropertyBlock(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.MaterialPropertyBlock properties = (UnityEngine.MaterialPropertyBlock)translator.GetObject(L, 2, typeof(UnityEngine.MaterialPropertyBlock));
                    
                    __cl_gen_to_be_invoked.SetPropertyBlock( properties );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPropertyBlock(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.MaterialPropertyBlock dest = (UnityEngine.MaterialPropertyBlock)translator.GetObject(L, 2, typeof(UnityEngine.MaterialPropertyBlock));
                    
                    __cl_gen_to_be_invoked.GetPropertyBlock( dest );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetClosestReflectionProbes(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.List<UnityEngine.Rendering.ReflectionProbeBlendInfo> result = (System.Collections.Generic.List<UnityEngine.Rendering.ReflectionProbeBlendInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Rendering.ReflectionProbeBlendInfo>));
                    
                    __cl_gen_to_be_invoked.GetClosestReflectionProbes( result );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bounds(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineBounds(L, __cl_gen_to_be_invoked.bounds);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enabled(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.enabled);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isVisible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isVisible);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowCastingMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.shadowCastingMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_receiveShadows(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.receiveShadows);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_motionVectorGenerationMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.motionVectorGenerationMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lightProbeUsage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.lightProbeUsage);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_reflectionProbeUsage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.reflectionProbeUsage);
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
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.sortingLayerName);
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
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.sortingLayerID);
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
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.sortingOrder);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_allowOcclusionWhenDynamic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.allowOcclusionWhenDynamic);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isPartOfStaticBatch(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isPartOfStaticBatch);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_worldToLocalMatrix(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.worldToLocalMatrix);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localToWorldMatrix(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.localToWorldMatrix);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lightProbeProxyVolumeOverride(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.lightProbeProxyVolumeOverride);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_probeAnchor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.probeAnchor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lightmapIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.lightmapIndex);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_realtimeLightmapIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.realtimeLightmapIndex);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lightmapScaleOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector4(L, __cl_gen_to_be_invoked.lightmapScaleOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_realtimeLightmapScaleOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector4(L, __cl_gen_to_be_invoked.realtimeLightmapScaleOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_material(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.material);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sharedMaterial(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.sharedMaterial);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_materials(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.materials);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sharedMaterials(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.sharedMaterials);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enabled(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.enabled = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowCastingMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                UnityEngine.Rendering.ShadowCastingMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.shadowCastingMode = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_receiveShadows(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.receiveShadows = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_motionVectorGenerationMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                UnityEngine.MotionVectorGenerationMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.motionVectorGenerationMode = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lightProbeUsage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                UnityEngine.Rendering.LightProbeUsage __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.lightProbeUsage = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_reflectionProbeUsage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                UnityEngine.Rendering.ReflectionProbeUsage __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.reflectionProbeUsage = __cl_gen_value;
            
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
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sortingLayerName = LuaAPI.lua_tostring(L, 2);
            
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
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sortingLayerID = LuaAPI.xlua_tointeger(L, 2);
            
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
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sortingOrder = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_allowOcclusionWhenDynamic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.allowOcclusionWhenDynamic = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lightProbeProxyVolumeOverride(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.lightProbeProxyVolumeOverride = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_probeAnchor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.probeAnchor = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lightmapIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.lightmapIndex = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_realtimeLightmapIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.realtimeLightmapIndex = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lightmapScaleOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector4 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.lightmapScaleOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_realtimeLightmapScaleOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector4 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.realtimeLightmapScaleOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_material(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.material = (UnityEngine.Material)translator.GetObject(L, 2, typeof(UnityEngine.Material));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sharedMaterial(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sharedMaterial = (UnityEngine.Material)translator.GetObject(L, 2, typeof(UnityEngine.Material));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_materials(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.materials = (UnityEngine.Material[])translator.GetObject(L, 2, typeof(UnityEngine.Material[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sharedMaterials(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Renderer __cl_gen_to_be_invoked = (UnityEngine.Renderer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sharedMaterials = (UnityEngine.Material[])translator.GetObject(L, 2, typeof(UnityEngine.Material[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
