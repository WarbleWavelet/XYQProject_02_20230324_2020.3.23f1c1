using UnityEngine;


/// <summary>
/// 创建人：Trigger <para />
/// 命令名称：结束当前行动AI自身的回合<para />
/// 参数：是否重置行动码<para />
/// </summary>
public struct EndCurrentTurnCommand : ICommand
{
    IFightSystem sys;
    public void Execute(object obj)
    {
        bool ifResetActCode = obj == null ? false : true;
         sys = this.GetSystem<IFightSystem>();

        if ( IsAOESkill() )
        {
            for (int i = 0; i < sys.CurTarAIList.Count; i++)
            {
                if ( sys.CurTarAIList[i].characterState == CharacterState.DEAD 
                     && sys.DieCnt > 0)
                {
                    this.SendCommnd<ResetCurrentAIState>( ifResetActCode );
                    return;
                }
            }
        }
        this.SendCommnd<ResetCurrentAIState>( ifResetActCode );
        this.SendCommnd<ToNextCharacterActCommand>();
    }


    /// <summary>是不是范围技能</summary>
    bool IsAOESkill()
    {
        return sys.CurAI.actCode == ActCode.SKILL
            && sys.CurAI.actObj.skillInfo.skillType == SkillType.REMOTEAOE;
    }
}
