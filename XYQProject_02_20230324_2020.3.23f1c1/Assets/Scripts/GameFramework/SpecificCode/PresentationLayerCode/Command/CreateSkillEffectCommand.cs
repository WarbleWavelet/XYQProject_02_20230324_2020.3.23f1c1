using UnityEditor.Experimental.GraphView;
using UnityEngine;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：当前行动AI对目标使用技能后生成的特效
/// 参数:
/// </summary>
public struct CreateSkillEffectCommand : ICommand
{
    IFightSystem sys;
    public void Execute(object obj)
    {
        sys = this.GetSystem<IFightSystem>();
        SkillInfo skillInfo = sys.CurAI.actObj.skillInfo;
        //
        if (skillInfo.skillType == SkillType.REMOTESINGLE)
        {
            InstantiateSkill( sys.CurAI.toAI, skillInfo);
        }
        else
        {
            this.SendCommnd<GetAttackTargetsCommand>(sys.CurAI.AOENUM);
            //按人数扣MP也是少见
            int costMp = skillInfo.decreaseValue1 * sys.CurTarAIList.Count;
            sys.CurAI.ShowMPValueChange(-costMp);
            for (int i = 0; i < sys.CurTarAIList.Count; i++)
            {
                InstantiateSkill( sys.CurTarAIList[i], skillInfo);
            }
        }
    }

    GameObject InstantiateSkill( CharacterFightAI ai,SkillInfo skillInfo)
    {
        GameObject go= GameObject.Instantiate(
            InternalResources.GetSkillEffect(skillInfo ), 
            ai.atrTrans.position, 
            Quaternion.identity
        );
        return go;
    }

}
