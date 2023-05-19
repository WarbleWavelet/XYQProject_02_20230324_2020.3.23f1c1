/****************************************************
    文件：MsgDispatcher.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/3 23:1:2
	功能：QF的
*****************************************************/

using System.Collections.Generic;
using System;
using UnityEngine;


/// <summary>消息分发器</summary>
public class MsgDispatcher : MonoBehaviour
{
    static Dictionary<string, Action<object>> mRegisteredMsgs = new Dictionary<string, Action<object>>();

    #region 辅助
    /// <summary>注册</summary>
    public static void Register(string msgName, Action<object> onMsgReceived)
    {
        if (!mRegisteredMsgs.ContainsKey(msgName))
        {
            mRegisteredMsgs.Add(msgName, _ => { });
        }

        mRegisteredMsgs[msgName] += onMsgReceived;
    }


    /// <summary>发送</summary>
    public static void Send(string msgName, object data)
    {
        if (mRegisteredMsgs.ContainsKey(msgName))
        {
            mRegisteredMsgs[msgName](data);
        }
    }


    /// <summary>注销 msgName 的所有Action</summary>
    public static void UnRegisterAll(string msgName)
    {
        mRegisteredMsgs.Remove(msgName);
    }


    /// <summary>注销 msgName 的 onMsgReceived</summary>
    public static void UnRegister(string msgName, Action<object> onMsgReceived)
    {
        if (mRegisteredMsgs.ContainsKey(msgName))
        {
            mRegisteredMsgs[msgName] -= onMsgReceived;
        }
    }
    #endregion

}