/****************************************************

	文件：
	作者：WWS
	日期：2022/10/31 15:25:09
	功能：数学有关


*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using GameObject = UnityEngine.GameObject;




public static partial  class MathFunc
{
    /// <summary>小于 percent 的概率 </summary>
    public static bool Percent(int percent)
    {
        return UnityEngine.Random.Range(0, 100) < percent;
    }


    /// <summary>返回驻足内的随机数</summary>
    public static T GetRandomValueFrom<T>(params T[] values)
    {
        return values[UnityEngine.Random.Range(0, values.Length)];
    }

}
