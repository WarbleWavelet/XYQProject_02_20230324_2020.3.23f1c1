using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//*****************************************
//创建人： Trigger 
//功能说明：技能系统接口
//***************************************** 

/// <summary>技能系统接口</summary> 
public interface ISkillSystem : ISystem
{
    /// <summary>
    /// 玩家是否正在使用技能选择目标
    /// </summary>
    bool UsingSkill { set; get; }

    int CurSkillID { set; get; }
}
