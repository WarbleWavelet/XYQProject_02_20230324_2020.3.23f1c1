using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：
//***************************************** 


/// <summary> Change MP</summary>
public struct ChangePlayerMPCommand : ICommand
{
    /// <summary>
    /// 修改玩家蓝量
    /// </summary>
    /// <param name="obj">改变值(int)</param>
    public void Execute(object obj)
    {
        this.GetModel<IPlayerDataModel>().CurMP.Value += (int)obj;
    }
}
