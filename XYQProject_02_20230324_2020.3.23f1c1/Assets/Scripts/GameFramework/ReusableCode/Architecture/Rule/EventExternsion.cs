using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//*****************************************
//创建人： Trigger 
//功能说明：事件系统的支持扩展
//***************************************** 


/// <summary>事件系统的支持扩展</summary>
public static class EventExternsion
{


    public static void SendEvent<T>(this ICanSendEvent self, object dataObj=null) where T : new()
    {
        GetArchitecture(self).SendEvent<T>(dataObj);
    }


    public static IUnRegister RegistEvent<T>(this ICanRegistAndUnRegistEvent self, Action<object> onEvent) where T : new()
    {
        return GetArchitecture(self).RegistEvent<T>(onEvent);
    }


    public static void UnRegistEvent<T>(this ICanRegistAndUnRegistEvent self, Action<object> onEvent) where T : new()
    {
        GetArchitecture(self).UnRegistEvent<T>(onEvent);
    }

    private static IArchitecture GetArchitecture(IBelongToArchitecture self)
    {
        return StartArchitecture.Instance.GetArchitecture<IBelongToArchitecture>(self);
    }


}
