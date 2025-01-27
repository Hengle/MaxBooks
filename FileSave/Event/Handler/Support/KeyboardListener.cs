﻿// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class KeyboardListener : BaseListener {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 侦听按键键值
        internal KeyCode Key { get; set; }

        // 事件侦听函数
        internal Action<KeyCode , KeyboardEventType> Listener { get; set; }

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 派发事件 ( 重写 )
        internal override void Dispatch( params object[] args ) => Listener.Invoke( (KeyCode)args[0] , (KeyboardEventType)args[1] );

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //
