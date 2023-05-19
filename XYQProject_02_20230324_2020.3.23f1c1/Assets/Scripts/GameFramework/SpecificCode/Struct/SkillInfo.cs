using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：技能信息
//***************************************** 

/// <summary>技能信息</summary>
public struct SkillInfo
{
    //公共
    public int ID;
    public string name;
    /// <summary>路径名</summary>
    public string pathName;
    /// <summary>门派名</summary>
    public string sectName;
    public SkillType skillType;
    public string description;
    /// <summary>技能触发的特殊效果编号</summary>
    public int specialEffectNum;


    //技能消耗
    /// <summary>技能消耗类型</summary>
    public DecreaseType decreaseType;
    /// <summary>消耗值1</summary>
    public int decreaseValue1;
    /// <summary>消耗值2</summary>
    public int decreaseValue2;


    //对目标作用值
    /// <summary>对目标作用值技能消耗类型</summary>
    public DecreaseType targetDecreaseType;
    /// <summary>对目标作用值消耗值1</summary>
    public int skillValue1;
    /// <summary>对目标作用值消耗值2</summary>
    public int skillValue2;
    public float delayHitTime;
    /// <summary>对目标作用值作用数量</summary>
    public int targetNum;
}





