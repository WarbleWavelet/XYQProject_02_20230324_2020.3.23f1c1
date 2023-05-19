using UnityEngine;
/// <summary>
/// 创建人：Trigger<para/> 
/// 命令名称：重置当前AI的状态<para/> 
/// 参数:是否重置行动码<para/> 
/// </summary>
public struct ResetCurrentAIState : ICommand
{
    public void Execute(object obj)
    {
        this.GetSystem<IFightSystem>().CurAI.ResetState( (bool)obj );
    }
}
