using UnityEngine;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：延时反间目标
/// 参数:
/// </summary>
public struct DelaySowTargetCommand : ICommand
{
    public void Execute(object obj)
    {
        IFightSystem sys = this.GetSystem<IFightSystem>();
        sys.CurAI.toAI.characterState = CharacterState.CHAOS;
        sys.CurAI.toAI.DoChaosMoveTween();
    }
}
