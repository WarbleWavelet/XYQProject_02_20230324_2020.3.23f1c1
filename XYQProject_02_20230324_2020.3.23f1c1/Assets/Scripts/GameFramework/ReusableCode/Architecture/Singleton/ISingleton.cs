using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：单例基本功能接口，可以更方便管理与维护
//***************************************** 


/// <summary>单例基本功能接口，可以更方便管理与维护</summary>
public interface ISingleton
{
    /// <summary>
    /// 单例实例化
    /// </summary>
    ISingleton Init();


    /// <summary>
    /// 单例每次被唤醒时需要调用的方法
    /// </summary>
    void OnEnable();


    /// <summary>
    /// 单例每一帧需要调用的方法
    /// </summary>
    void Update();


    /// <summary>
    /// 单例每次被唤醒时需要调用的方法
    /// </summary>
    void OnDisable();
}
