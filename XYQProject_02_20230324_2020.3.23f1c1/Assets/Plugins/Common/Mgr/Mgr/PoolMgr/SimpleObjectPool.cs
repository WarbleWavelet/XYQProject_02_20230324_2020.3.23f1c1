/****************************************************
    文件：SimpleObjectPool.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/4 2:10:39
	功能：
*****************************************************/

using System;
using UnityEngine;

public class SimpleObjectPool<T> : Pool<T>
{
    Action<T> mResetMethod;

    public SimpleObjectPool(Func<T> factroyMethod, Action<T> resetMethod = null, int initCount = 0)
    {
        mFactory = new CustomObjectFactroy<T>(factroyMethod);
        mResetMethod = resetMethod;

        for (var i = 0; i < initCount; i++)
        {
            mCacheStack.Push(mFactory.Create());
        }
    }


    #region 重现


    public override bool Recycle(T obj)
    {
        if (mResetMethod != null)
        {
            mResetMethod(obj);
        }

        mCacheStack.Push(obj);

        return true;
    }
    #endregion
}
