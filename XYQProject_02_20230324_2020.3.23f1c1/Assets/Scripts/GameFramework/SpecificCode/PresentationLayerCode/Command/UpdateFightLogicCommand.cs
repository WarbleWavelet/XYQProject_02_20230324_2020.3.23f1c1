using UnityEngine;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：更新战斗逻辑命令
/// 参数:
/// </summary>
public struct UpdateFightLogicCommand : ICommand
{
    IFightSystem sys;
    public void Execute(object obj)
    {
        sys = this.GetSystem<IFightSystem>();
        if ( sys.EnterCurRound )
        {
            if ( !sys.IsPerformingLogic )
            {
                if ( IsEndRound() )
                {
                    PerformingEndRoundLogic();
                    return;
                }


                sys.CurAI = sys.CurActAILst[sys.CurActIdx];
                //执行当前阶段敌人逻辑
                if (!sys.CurAI.isPlayer)
                {
                    this.SendCommnd<RandomEnemyActCommand>();
                }
                else
                {
                    sys.PlayerAI.toAI = sys.PlayerTarAI;
                }
                sys.IsPerformingLogic = true;
                sys.CurAI.PerformLogic();
            }
        }
    }



    #region 辅助


    /// <summary>所有人物在当前回合都已行动</summary>
    bool IsEndRound()
    {
        return sys.CurActIdx >= sys.CurActAILst.Count;
    }



    /// <summary>执行结束当前回合的逻辑</summary> 
    void PerformingEndRoundLogic()
    {
        this.SendCommnd<ResetFightLogicStateCommand>();
        this.SendEvent<OpenOrCloseFightCommandPanelEvent>(true);
        for (int i = 0; i < sys.CurActAILst.Count; i++)
        {
            sys.CurActAILst[i].DestoryDebuff();
        }
    }
    #endregion


}
