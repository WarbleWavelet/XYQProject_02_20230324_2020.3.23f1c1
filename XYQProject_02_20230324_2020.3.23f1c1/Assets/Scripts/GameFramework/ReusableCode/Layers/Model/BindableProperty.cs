using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//*****************************************
//创建人： Trigger 
//功能说明：属性值发生变化时可自动触发事件
//***************************************** 


/// <summary>属性值发生变化时可自动触发事件</summary>
public class BindableProperty<T> where T:IEquatable<T>
{
    private T mValue;
    public T Value
    {
        get => mValue;
        set
        {
            if (!mValue.Equals(value))
            {
                mValue = value;
                mOnValueChanged?.Invoke(value);//有变化就触发
            }
        }
    }

    private Action<T> mOnValueChanged = (v) => { };


    public void RegisterOnValueChanged(Action<T> onValueChanged)
    {
        mOnValueChanged += onValueChanged;
    }


    public void UnRegisterOnValueChanged(Action<T> onValueChanged)
    {
        mOnValueChanged -= onValueChanged;
    }
}
