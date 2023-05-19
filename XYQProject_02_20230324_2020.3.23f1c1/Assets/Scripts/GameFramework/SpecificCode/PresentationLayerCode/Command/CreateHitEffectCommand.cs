using System;
using UnityEngine;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：
/// 参数:
/// </summary>
public struct CreateHitEffectCommand : ICommand
{
    IFightSystem sys;
    public void Execute(object obj)
    {
        sys = this.GetSystem<IFightSystem>();
        AudioSourceManager.Instance.PlaySoundCharacter("Hit", sys.CurAI.toAI.name);
        if (sys.CurAI.actCode != ActCode.SKILL)//普通攻击
        {
            GameObject.Instantiate(
                ExtendResources.Get<GameObject>(ResourcesName.Prefab.AttackEffect),
                sys.CurAI.toAI.transform.position + new Vector3(0, 0.3f, 0.5f),
                Quaternion.identity
            );
        }
        else  //近战技能攻击
        {
            if (sys.CurAI.actObj.skillInfo.skillType == SkillType.MELEE)
            {
                string path = GetHitEffectPath( );
                GameObject.Instantiate( 
                    ExtendResources.Get<GameObject>(path),
                    sys.CurAI.toAI.transform.position + new Vector3(0, 0.3f, 0) ,
                    Quaternion.identity
                );
            }                                                  
        }



    }

    /// <summary>Assets/Resources/Prefabs/Skills下的特效</summary>
    string GetHitEffectPath()
    {
        int skillID = sys.CurAI.actObj.skillInfo.ID;
        SkillInfo skillInfo = this.GetModel<ISkillDataModel>().GetSkillInfo(skillID);
        string path =  string.Format("Prefabs/Skills/{0}/{1}", 
            skillInfo.sectName,
            skillInfo.pathName
        );

        return path;
    }
}
