using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：事件系统
//***************************************** 
public class GameEventSystem : IEventSystem
{
    private Dictionary<Type, IEventRegistration> eventRegistrationsDict = new Dictionary<Type, IEventRegistration>();
    public IUnRegister Regist<T>(Action<object> onEvent)
    {
        var type = typeof(T);
        IEventRegistration eventRegistration;
        if (eventRegistrationsDict.TryGetValue(type,out eventRegistration))
        {
            throw new Exception(typeof(T)+"该事件已注册");
        }
        else
        {
            eventRegistration = new EventRegistration()
            {
                OnEvent = onEvent
            };
            eventRegistrationsDict.Add(type,eventRegistration);
        }
        return new UnEventRegistration<T>()
        {
            OnEvent = onEvent,
            eventSystem = this
        };
    }

    public void Send<T>(object obj) where T : new()
    {
        IEventRegistration eventRegistration;
        if (eventRegistrationsDict.TryGetValue(typeof(T), out eventRegistration))
        {
            (eventRegistration as EventRegistration)?.OnEvent.Invoke(obj);
        }
    }

    public void UnRegist<T>(Action<object> onEvent)
    {
        IEventRegistration eventRegistration;
        if (eventRegistrationsDict.TryGetValue(typeof(T), out eventRegistration))
        {
            (eventRegistration as EventRegistration).OnEvent -= onEvent;
        }
    }
}
