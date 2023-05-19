using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：技能系统
//***************************************** 
public class SkillSystem : ISkillSystem
{
    public bool UsingSkill { get; set; }

    public int CurSkillID { set; get; }

    public SkillSystem() { Init(); }

    public void Init()
    {
        
    }
}
