using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：技能信息数据模型接口
//***************************************** 

/// <summary>技能信息数据模型接口</summary>
public interface ISkillDataModel:IModel
{
    SkillInfo GetSkillInfo(int id);
    SkillInfo GetSKillInfo(string name);
}
