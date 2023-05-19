using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//*****************************************
//创建人： Trigger 
//功能说明：启动框架的启动器（启动入口）
//***************************************** 


/// <summary>启动框架的启动器（启动入口）</summary>
public class StartArchitecture : Singleton<StartArchitecture>, ISingleton
{


    #region 字属生命


    private StartArchitecture() { Init(); }
    private IArchitecture gameArchitecture;


    public ISingleton Init()
    {
        return this;
    }


    public void OnEnable()
    {
        
    }

    public void Update()
    {
        
    }

    public void OnDisable()
    {
        
    }
    #endregion  



    /// <summary>
    /// 实例化并设置不同项目的架构
    /// </summary>
    public void SetGameArchitecture(IArchitecture architecture)
    {
        gameArchitecture = architecture;
    }


    /// <summary>                      
    /// 获取架构实例（只能由特定对象获取，否则会报异常）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="getterObj"></param>
    /// <returns></returns>
    public IArchitecture GetArchitecture<T>(T getterObj)
    {
        if (typeof(T)==typeof(IBelongToArchitecture))
        {
            return gameArchitecture;
        }
        else
        {
            throw new Exception(getterObj.GetType().ToString()+"类型的对象不能获取架构实例");
        }
    }


}
