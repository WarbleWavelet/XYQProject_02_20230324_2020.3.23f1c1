/****************************************************
    文件：ExtendComponent.Behaviour.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/4 15:57:15
	功能：
*****************************************************/

using UnityEngine;

public static partial class ExtendComponent
{
    public static void Enabled(this Behaviour behaviour)
    {
        behaviour.enabled = true;
    }

    public static void Disabled(this Behaviour behaviour)
    {
        behaviour.enabled = false;
    }


}