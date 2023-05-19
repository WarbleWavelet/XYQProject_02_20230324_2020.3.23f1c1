/****************************************************
    文件：ExtendList.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/18 21:59:8
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;
 

public static class ExtendList
{

    /// <summary>按_property（）排序该list</summary>
    public static List<object> Order(this List<object> list,object _property)
    {
        list = list.OrderByDescending(orderPara => _property).ToList(); //按速度安排角色先后行动
        return list;
        //    sys.CurActAILst = sys.CurActAILst.OrderByDescending(p => p.actRate).ToList(); 
    }

}




