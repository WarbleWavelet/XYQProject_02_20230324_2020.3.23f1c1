using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//*****************************************
//创建人： Trigger 
//功能说明：可以发送命令的拓展方法
//***************************************** 

/// <summary>可以发送命令的拓展方法</summary>
public static class CanSendCommandExternsion
{
    public static void SendCommnd<T>(this ICanSendCommand self,object obj=null) where T:ICommand,new()
    {
        StartArchitecture.Instance.GetArchitecture<IBelongToArchitecture>(self).SendCommand<T>(obj);
    }
}
