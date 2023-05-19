/****************************************************
    文件：IObjectFactory.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/4 2:6:58
	功能：
*****************************************************/

using UnityEngine;


/// <summary>对象工厂</summary>
public interface IObjectFactory<T>
{
    T Create();
}