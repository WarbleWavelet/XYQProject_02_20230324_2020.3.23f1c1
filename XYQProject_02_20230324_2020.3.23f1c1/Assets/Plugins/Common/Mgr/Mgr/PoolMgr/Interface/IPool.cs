/****************************************************
    文件：IPool.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/4 2:5:30
	功能：
*****************************************************/

using UnityEngine;

public interface IPool<T>
{

    /// <summary>分配</summary>
    T Allocate();


    /// <summary>回收</summary>
    bool Recycle(T obj);
}