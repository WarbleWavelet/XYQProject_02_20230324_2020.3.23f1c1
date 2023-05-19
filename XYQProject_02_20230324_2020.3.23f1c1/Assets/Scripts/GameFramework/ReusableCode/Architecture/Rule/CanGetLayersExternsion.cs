using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：可以获取某些层的拓展方法
//***************************************** 
public static class CanGetLayersExternsion 
{
    public static T GetModel<T>(this ICanGetModle self) where T:class,IModel
    {
        return StartArchitecture.Instance.GetArchitecture<IBelongToArchitecture>(self).GetModel<T>();
    }

    public static T GetSystem<T>(this ICanGetSystem self) where T : class, ISystem
    {
        return StartArchitecture.Instance.GetArchitecture<IBelongToArchitecture>(self).GetSystem<T>();
    }

    public static T GetUtility<T>(this ICanGetUtility self) where T : class, IUtility
    {
        return StartArchitecture.Instance.GetArchitecture<IBelongToArchitecture>(self).GetUtility<T>();
    }  
}
