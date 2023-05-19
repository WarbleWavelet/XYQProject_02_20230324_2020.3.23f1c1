using UnityEngine;


/// <summary>
/// 重置战斗逻辑中的状态值
/// </summary>
public struct ResetFightLogicStateCommand : ICommand
{
    public void Execute(object obj)
    {
        IFightSystem sys = this.GetSystem<IFightSystem>();
        sys.CurActIdx = 0;
        sys.EnterCurRound = false;
        sys.IsPerformingLogic = false;
    }
}
