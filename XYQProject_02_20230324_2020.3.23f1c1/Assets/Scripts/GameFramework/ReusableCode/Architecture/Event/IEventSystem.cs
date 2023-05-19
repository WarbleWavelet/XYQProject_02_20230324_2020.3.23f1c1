using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//*****************************************
//创建人： Trigger 
//功能说明：事件系统接口
//***************************************** 
public interface IEventSystem
{
    /// <summary>
    /// 发送事件
    /// </summary>
    /// <typeparam name="T">事件类型</typeparam>
    /// <param name="obj">事件参数</param>
    void Send<T>(object obj) where T : new();
    /// <summary>
    /// 注册事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="onEvent"></param>
    /// <returns></returns>
    IUnRegister Regist<T>(Action<object> onEvent);
    /// <summary>
    /// 注销事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="onEvent"></param>
    void UnRegist<T>(Action<object> onEvent);
}
