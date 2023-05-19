using UnityEngine;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：减少死亡计数值
/// 参数:
/// </summary>
public struct DecreaseDieCountCommand : ICommand
{
    public void Execute(object obj)
    {
        IFightSystem sys = this.GetSystem<IFightSystem>();
        if (sys.DieCnt>0)
        {
            sys.DieCnt--;
        }
    }
}
