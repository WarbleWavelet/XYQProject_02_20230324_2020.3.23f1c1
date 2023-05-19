using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：架构抽象基类
//***************************************** 
public abstract class Architecture<T> : IArchitecture where T : new()
{
    private IOCContainer iocContainer = new IOCContainer();

    private GameEventSystem gameEventSystem = new GameEventSystem();

    public Architecture() { Init(); }

    protected abstract void Init();

    /// <summary>
    /// 注册系统
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <param name="instance"></param>
    public void RegistSystem<U>(U instance) where U : ISystem
    {
        iocContainer.Register<U>(instance);
    }
    /// <summary>
    /// 注册模型模块
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <param name="instance"></param>
    public void RegistModel<U>(U instance) where U : IModel
    {
        iocContainer.Register<U>(instance);
    }
    /// <summary>
    /// 注册工具
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="instance"></param>
    public void RegistUtility<U>(U instance)
    {
        iocContainer.Register<U>(instance);
    }
    /// <summary>
    /// 获取系统层对象
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <returns></returns>
    public U GetSystem<U>() where U : class, ISystem
    {
        return iocContainer.Get<U>();
    }
    /// <summary>
    /// 获取模型层对象
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <returns></returns>
    public U GetModel<U>() where U : class, IModel
    {
        return iocContainer.Get<U>();
    }
    /// <summary>
    /// 获取工具层对象
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <returns></returns>
    public U GetUtility<U>() where U : class, IUtility
    {
        return iocContainer.Get<U>();
    }
    /// <summary>
    /// 发送命令
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <param name="dataObj">参数</param>
    public void SendCommand<U>(object dataObj) where U : ICommand, new()
    {
        var command = new U();
        command.Execute(dataObj);
    }
    /// <summary>
    /// 发送事件
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <param name="dataObj"></param>
    public void SendEvent<U>(object dataObj) where U : new()
    {
        gameEventSystem.Send<U>(dataObj);
    }
    /// <summary>
    /// 注册事件
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <param name="onEvent"></param>
    /// <returns></returns>
    public IUnRegister RegistEvent<U>(Action<object> onEvent) where U : new()
    {
        return gameEventSystem.Regist<U>(onEvent);
    }
    /// <summary>
    /// 注销事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="onEvent"></param>
    public void UnRegistEvent<U>(Action<object> onEvent) where U : new()
    {
        gameEventSystem.UnRegist<U>(onEvent);
    }
}
