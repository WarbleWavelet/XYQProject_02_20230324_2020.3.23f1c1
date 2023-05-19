using UnityEngine;


/// <summary>
/// 开始执行当前回合的战斗逻辑
/// </summary>
public struct PerformLogicCommand : ICommand
{
    public void Execute(object obj)
    {
        IFightSystem sys = this.GetSystem<IFightSystem>();
        sys.IsPerformingLogic = false;
        sys.EnterCurRound = true;
        this.GetSystem<ISkillSystem>().UsingSkill = false;
        this.SendCommnd<CloseAllFightUIPanelCommand>();
    }
}

