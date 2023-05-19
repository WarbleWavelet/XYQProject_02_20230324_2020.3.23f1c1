using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：玩家数据模型
//***************************************** 

/// <summary>玩家数据模型</summary>
public interface IPlayerDataModel : IModel
{
    BindableProperty<int> MaxHP { get; }
    BindableProperty<int> CurHP { get; }
    BindableProperty<int> CurMaxHP { get; }
    BindableProperty<int> MaxMP { get; }
    BindableProperty<int> CurMP{ get; }
    /// <summary>玩家已学技能</summary>
    List<int> GetPlayerSkillList();
}
