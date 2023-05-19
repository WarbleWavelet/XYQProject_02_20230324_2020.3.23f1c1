using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：技能数据模型
//***************************************** 

/// <summary>技能数据模型</summary>
public class SkillDataModel : ISkillDataModel
{


    #region 字属


    /// <summary>skill的json字典</summary>
    private Dictionary<int, SkillInfo> skillInfoDict;
    /// <summary>name对应技能的字典</summary>
    private Dictionary<string, SkillInfo> skillInfoStrDict;
    #endregion


    public SkillDataModel() { Init(); }

    public void Init()
    {
        skillInfoDict = InitSkillInfoDict();
        skillInfoStrDict = InitSkillInfoStrDict( skillInfoDict );
    }

    #region 辅助


    public SkillInfo GetSkillInfo(int id)
    {
        if (skillInfoDict.ContainsKey(id))
        {
            return skillInfoDict[id];
        }
        else
        {
            throw new System.Exception("不存在ID为" + id + "的技能");
        }
    }

    public SkillInfo GetSKillInfo(string name)
    {
        if (skillInfoStrDict.ContainsKey(name))
        {
            return skillInfoStrDict[name];
        }
        else
        {
            throw new System.Exception("不存在名称为" + name + "的技能");
        }
    }


    Dictionary<int, SkillInfo> InitSkillInfoDict()
    {
        Dictionary<int, SkillInfo> skillInfoDict = new Dictionary<int, SkillInfo>()
        {
            {
                1,
                new SkillInfo()
                {
                    ID=1,
                    name="横扫千军",
                    sectName="DaTangGuanFu",
                    pathName="HengSaoQianJun",
                    skillType=SkillType.MELEE,
                    delayHitTime=1.667f,
                    decreaseValue1=100
                }
            },
            {
                2,
                new SkillInfo()
                {
                    ID=2,
                    name="唧唧歪歪",
                    sectName="HuaShengSi",
                    pathName="JiJiWaiWai",
                    skillType=SkillType.REMOTEAOE,
                    delayHitTime=1f,
                    decreaseValue1=30
                }
            },
            {
                3,
                new SkillInfo()
                {
                    ID=3,
                    name="水攻",
                    sectName="Pet",
                    pathName="ShuiGong",
                    skillType=SkillType.REMOTESINGLE,
                    delayHitTime=1f,
                    decreaseValue1=65
                }
            },
            {
                4,
                new SkillInfo()
                {
                    ID=4,
                    name="反间之计",
                    sectName="DaTangGuanFu",
                    pathName="FanJianZhiJi",
                    skillType=SkillType.REMOTESINGLE,
                    delayHitTime=1f,
                    decreaseValue1=100
                }
            },
            {
                5,
                new SkillInfo()
                {
                    ID=5,
                    name="化瘀",
                    sectName="HuaShengSi",
                    pathName="HuaYu",
                    skillType=SkillType.REMOTESINGLE,
                    delayHitTime=1f,
                    decreaseValue1=30
                }
            },
        };

        return skillInfoDict;
    }

    Dictionary<string, SkillInfo> InitSkillInfoStrDict(Dictionary<int, SkillInfo> skillInfoDict)
    {
        Dictionary<string, SkillInfo>  skillInfoStrDict = new Dictionary<string, SkillInfo>();
        foreach (var item in skillInfoDict)
        {
            skillInfoStrDict.Add(item.Value.name, item.Value);
        }

        return skillInfoStrDict;
    }
    #endregion



}
