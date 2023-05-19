using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//*****************************************
//创建人： Trigger 
//功能说明：事件注销者(目的是方便注册后的事件储存并进行后续的注销)
//***************************************** 
public class UnEventRegistration<T> : IUnRegister
{
    public IEventSystem eventSystem { get; set; }
    public Action<object> OnEvent { get; set; }

    public void UnRegist()
    {
        eventSystem.UnRegist<T>(OnEvent);
        eventSystem = null;
        OnEvent = null;
    }
}
