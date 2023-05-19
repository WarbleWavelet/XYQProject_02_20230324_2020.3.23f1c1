using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>修改玩家血量</summary>
public struct ChangePlayerHPCommand : ICommand
{
    /// <summary>
    /// 修改玩家血量
    /// </summary>
    /// <param name="obj">改变值(int)</param>
    public void Execute(object obj)
    {
        this.GetModel<IPlayerDataModel>().CurHP.Value += (int)obj;
    }
}
