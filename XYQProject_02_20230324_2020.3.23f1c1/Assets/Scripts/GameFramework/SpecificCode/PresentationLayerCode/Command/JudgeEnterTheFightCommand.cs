using UnityEngine;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：
/// 参数:
/// </summary>
public struct JudgeEnterTheFightCommand : ICommand
{
    public void Execute(object obj)
    {
        this.GetSystem<ISceneSystem>().JudgeEnterTheFight();
    }
}
