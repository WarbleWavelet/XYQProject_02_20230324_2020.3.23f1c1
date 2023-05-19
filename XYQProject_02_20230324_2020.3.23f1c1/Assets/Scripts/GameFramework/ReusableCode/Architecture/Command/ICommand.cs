using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：命令可以访问所有层级
//***************************************** 

/// <summary>命令可以访问所有层级</summary>
public interface ICommand:ICanGetModle,ICanGetSystem,ICanGetUtility,ICanSendEvent,ICanSendCommand
{
    public void Execute(object dataObj);
}
