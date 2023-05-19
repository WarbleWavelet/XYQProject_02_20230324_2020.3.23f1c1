using UnityEngine;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：延时对敌人造成伤害
/// 参数:参数类型DelayHitTargetCommandParams
/// </summary>
public struct DelayHitTargetCommand : ICommand
{
    public void Execute(object obj)
    {
        IFightSystem sys = this.GetSystem<IFightSystem>();
        DelayHitTargetCommandParams para = (DelayHitTargetCommandParams)obj;

        if ( sys.CurAI.actCode==ActCode.SKILL 
             && sys.CurAI.actObj.skillInfo.skillType == SkillType.REMOTEAOE)
        {
            for (int i = 0; i < sys.CurTarAIList.Count; i++)
            {
                sys.CurTarAIList[i].HitBehaviour( para );
            }
        }
        else
        {
            sys.CurAI.toAI.HitBehaviour( para );
        }
    }
}

