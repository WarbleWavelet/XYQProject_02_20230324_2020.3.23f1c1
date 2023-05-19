/****************************************************
    文件：EXtendVector3.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/16 10:51:58
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 

public static partial class ExtendVector3 
{


    #region Set 不加ref不行


    public static Vector3 SetX(ref this Vector3 v, float value)
    {
        Vector3 pos = v;
        v = new Vector3(value, pos.y,pos.z);
        return v;
    }


    public static Vector3 SetY( ref this Vector3 v, float value)
    {
        Vector3 pos = v;
        v = new Vector3(pos.x, value, pos.z);
        return v;
    }


    public static Vector3 SetZ(ref this Vector3 v, float value)
    {
        Vector3 pos = v;
        v = new Vector3(pos.x, pos.y, value);
        return v;
    }

    /// <summary>ref直接动v的内存</summary>
    public static Vector3 Mult(ref this Vector3 v, float x, float y, float z)
    {
        v.x *= x;
        v.y *= y;
        v.z *= z;

        return v;
    }

    #endregion


}




