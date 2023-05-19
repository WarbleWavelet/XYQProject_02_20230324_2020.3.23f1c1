using UnityEngine;
/// <summary>
/// 创建人：Trigger<para/> 
/// 命令名称：设置玩家目标AI<para/> 
/// 参数:CharacterFightAI<para/> 
/// </summary>
public struct SetPlayerTargetAICommand : ICommand
{
    public void Execute( object obj )
    {
        this.GetSystem<IFightSystem>().PlayerTarAI = (CharacterFightAI)obj;
    }
}
