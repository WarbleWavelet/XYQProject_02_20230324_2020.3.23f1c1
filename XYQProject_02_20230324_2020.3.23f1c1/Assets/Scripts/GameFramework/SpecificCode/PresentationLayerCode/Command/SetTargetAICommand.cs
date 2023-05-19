using UnityEngine;
/// <summary>
/// 创建人：Trigger<para/> 
/// 命令名称：设置当前玩家的目标<para/>
/// 参数:CharacterFightAI<para/>
/// </summary>
public struct SetTargetAICommand : ICommand
{
    public void Execute(object obj)
    {
        this.GetSystem<IFightSystem>().PlayerAI.toAI = (CharacterFightAI)obj;
    }
}
