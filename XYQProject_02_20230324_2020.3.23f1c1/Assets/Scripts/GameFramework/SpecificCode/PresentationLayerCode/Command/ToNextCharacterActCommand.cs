using UnityEngine;


/// <summary>
/// 创建人：Trigger<para/>  
/// 命令名称：轮到下一个人物执行行为逻辑<para/> 
/// 参数:是否重置行动码<para/> 
/// </summary>
public struct ToNextCharacterActCommand : ICommand
{
    public void Execute(object obj = null)
    {
        IFightSystem sys = this.GetSystem<IFightSystem>();
        if (sys.DieCnt<= 0)
        {
            sys.IsPerformingLogic= false;
            sys.EnterCurRound= true;
            sys.DieCnt= 0;
            sys.CurActIdx++;
        }
    }
}
