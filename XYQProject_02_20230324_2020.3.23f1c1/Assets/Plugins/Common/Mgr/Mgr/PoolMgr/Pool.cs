/****************************************************
    文件：Pool.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/4 2:8:29
	功能：
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : IPool<T>
{


    #region 字属


    protected Stack<T> mCacheStack = new Stack<T>();

    protected IObjectFactory<T> mFactory;

    /// <summary>
    /// Gets the current count.
    /// </summary>
    /// <value>The current count.</value>
    public int CurCount
    {
        get { return mCacheStack.Count; }
    }
    #endregion



    #region 重写实现
    /// <summary>分配，拿出来</summary>
    public T Allocate()
    {
        return mCacheStack.Count > 0 ? mCacheStack.Pop() : mFactory.Create();
    }


    /// <summary>回收，拿回来</summary>
    public abstract bool Recycle(T obj);
    #endregion

}