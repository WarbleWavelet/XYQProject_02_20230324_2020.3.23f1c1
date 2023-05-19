using UnityEngine;


/// <summary>
/// 修改战斗中玩家即将要使用的技能ID
/// </summary>
public struct ChangeCurSkillIDCommand : ICommand
{
    public void Execute(object obj)
    {
        this.GetSystem<ISkillSystem>().CurSkillID = (int)obj;
    }
}
