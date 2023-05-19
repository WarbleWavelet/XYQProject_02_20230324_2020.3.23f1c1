/****************************************************
    文件：MonoBehaviourMsg.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/3 22:56:5
	功能：
*****************************************************/

using System.Collections.Generic;
using System;
using UnityEngine;


/// <summary>带有简单消息分发器的MonoBehaviour</summary>
public abstract partial  class MonoBehaviourMsg : MonoBehaviour 
{


    #region MsgDispatcher


    List<MsgRecord> mMsgRecorder = new List<MsgRecord>();

    #region 生命


    protected abstract void OnBeforeDestroy();


    private void OnDestroy()
    {
        OnBeforeDestroy();

        foreach (var msgRecord in mMsgRecorder)
        {
            MsgDispatcher.UnRegister(msgRecord.Name, msgRecord.OnMsgReceived);
            msgRecord.Recycle();
        }

        mMsgRecorder.Clear();
    }
    #endregion


    #region 辅助


    public void RegisterMsg(string msgName, Action<object> onMsgReceived)
    {
        MsgDispatcher.Register(msgName, onMsgReceived);
        mMsgRecorder.Add(MsgRecord.Allocate(msgName, onMsgReceived));
    }

    public void SendMsg(string msgName, object data)
    {
        MsgDispatcher.Send(msgName, data);
    }

    public void UnRegisterMsg(string msgName)
    {
        var selectedRecords = mMsgRecorder.FindAll(record => record.Name == msgName);

        selectedRecords.ForEach(record =>
        {
            MsgDispatcher.UnRegister(record.Name, record.OnMsgReceived);
            mMsgRecorder.Remove(record);

            record.Recycle();
        });

        selectedRecords.Clear();
    }

    public void UnRegisterMsg(string msgName, Action<object> onMsgReceived)
    {
        var selectedRecords = mMsgRecorder.FindAll(
            record => record.Name == msgName && record.OnMsgReceived == onMsgReceived
        );

        selectedRecords.ForEach(record =>
        {
            MsgDispatcher.UnRegister(record.Name, record.OnMsgReceived);
            mMsgRecorder.Remove(record);

            record.Recycle();
        });


        selectedRecords.Clear();
    }
    #endregion


    #endregion



    #region 内部类 MsgRecord


    class MsgRecord
    {
        private MsgRecord() { }
        static Stack<MsgRecord> mMsgRecordPool = new Stack<MsgRecord>();
        //
        public string Name;
        public Action<object> OnMsgReceived;

        /// <summary>分配</summary>
        public static MsgRecord Allocate(string msgName, Action<object> onMsgReceived)
        {
            var retRecord = mMsgRecordPool.Count > 0 ? mMsgRecordPool.Pop() : new MsgRecord();
            retRecord.Name = msgName;
            retRecord.OnMsgReceived = onMsgReceived;

            return retRecord;
        }


        /// <summary>回收</summary>
        public void Recycle()
        {
            Name = null;
            OnMsgReceived = null;
            mMsgRecordPool.Push(this);
        }


    }
    #endregion
}