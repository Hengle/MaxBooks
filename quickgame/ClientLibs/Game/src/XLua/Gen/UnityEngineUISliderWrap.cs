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
    public class UnityEngineUISliderWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Slider), L, translator, 0, 12, 9, 9);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Rebuild", _m_Rebuild);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LayoutComplete", _m_LayoutComplete);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GraphicUpdateComplete", _m_GraphicUpdateComplete);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerDown", _m_OnPointerDown);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnDrag", _m_OnDrag);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnMove", _m_OnMove);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FindSelectableOnLeft", _m_FindSelectableOnLeft);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FindSelectableOnRight", _m_FindSelectableOnRight);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FindSelectableOnUp", _m_FindSelectableOnUp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FindSelectableOnDown", _m_FindSelectableOnDown);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnInitializePotentialDrag", _m_OnInitializePotentialDrag);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetDirection", _m_SetDirection);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "fillRect", _g_get_fillRect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "handleRect", _g_get_handleRect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "direction", _g_get_direction);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "minValue", _g_get_minValue);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "maxValue", _g_get_maxValue);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "wholeNumbers", _g_get_wholeNumbers);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "value", _g_get_value);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "normalizedValue", _g_get_normalizedValue);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "onValueChanged", _g_get_onValueChanged);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "fillRect", _s_set_fillRect);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "handleRect", _s_set_handleRect);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "direction", _s_set_direction);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "minValue", _s_set_minValue);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "maxValue", _s_set_maxValue);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "wholeNumbers", _s_set_wholeNumbers);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "value", _s_set_value);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "normalizedValue", _s_set_normalizedValue);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "onValueChanged", _s_set_onValueChanged);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Slider), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.UI.Slider), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Slider));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.UI.Slider), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.UI.Slider does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Rebuild(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.UI.CanvasUpdate executing;translator.Get(L, 2, out executing);
                    
                    __cl_gen_to_be_invoked.Rebuild( executing );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LayoutComplete(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.LayoutComplete(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GraphicUpdateComplete(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.GraphicUpdateComplete(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPointerDown(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnPointerDown( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDrag(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnDrag( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnMove(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.AxisEventData eventData = (UnityEngine.EventSystems.AxisEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.AxisEventData));
                    
                    __cl_gen_to_be_invoked.OnMove( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindSelectableOnLeft(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.UI.Selectable __cl_gen_ret = __cl_gen_to_be_invoked.FindSelectableOnLeft(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindSelectableOnRight(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.UI.Selectable __cl_gen_ret = __cl_gen_to_be_invoked.FindSelectableOnRight(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindSelectableOnUp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.UI.Selectable __cl_gen_ret = __cl_gen_to_be_invoked.FindSelectableOnUp(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindSelectableOnDown(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.UI.Selectable __cl_gen_ret = __cl_gen_to_be_invoked.FindSelectableOnDown(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnInitializePotentialDrag(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnInitializePotentialDrag( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDirection(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.UI.Slider.Direction direction;translator.Get(L, 2, out direction);
                    bool includeRectLayouts = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.SetDirection( direction, includeRectLayouts );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fillRect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.fillRect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_handleRect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.handleRect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_direction(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineUISliderDirection(L, __cl_gen_to_be_invoked.direction);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_minValue(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.minValue);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxValue(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.maxValue);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_wholeNumbers(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.wholeNumbers);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_value(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.value);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_normalizedValue(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.normalizedValue);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onValueChanged(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onValueChanged);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fillRect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.fillRect = (UnityEngine.RectTransform)translator.GetObject(L, 2, typeof(UnityEngine.RectTransform));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_handleRect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.handleRect = (UnityEngine.RectTransform)translator.GetObject(L, 2, typeof(UnityEngine.RectTransform));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_direction(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                UnityEngine.UI.Slider.Direction __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.direction = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_minValue(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.minValue = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxValue(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.maxValue = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_wholeNumbers(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.wholeNumbers = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_value(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.value = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_normalizedValue(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.normalizedValue = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onValueChanged(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Slider __cl_gen_to_be_invoked = (UnityEngine.UI.Slider)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onValueChanged = (UnityEngine.UI.Slider.SliderEvent)translator.GetObject(L, 2, typeof(UnityEngine.UI.Slider.SliderEvent));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
