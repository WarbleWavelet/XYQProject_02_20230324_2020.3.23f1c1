/****************************************************
    文件：CustomObjectFactroy.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/4 2:11:50
	功能：
*****************************************************/

using System;
using UnityEngine;

public class CustomObjectFactroy<T> : IObjectFactory<T>
{


    #region 字属构造


    private Func<T> mFactroyMethod;

    public CustomObjectFactroy(Func<T> factroyMethod)
    {
        mFactroyMethod = factroyMethod;
    }
    #endregion



    #region 重现
    public T Create()
    {
        return mFactroyMethod();
    }
    #endregion

}