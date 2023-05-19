/****************************************************
    文件：GUIUtlt.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/3 21:18:56
	功能：
*****************************************************/

using UnityEngine;

public static partial class GUIUtil 
{

    /// <summary>将str下乳当前电脑的复制内存，相当于Ctrl+V</summary>
    public static void CopyText(string str)
    { 
         GUIUtility.systemCopyBuffer = str;
    }
}