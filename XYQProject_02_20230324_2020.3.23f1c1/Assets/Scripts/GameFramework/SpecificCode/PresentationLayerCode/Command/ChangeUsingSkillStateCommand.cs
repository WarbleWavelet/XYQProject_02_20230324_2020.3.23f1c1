/// <summary>
/// 修改战斗中玩家是否正在使用技能选择目标的状态
/// 参数:bool
/// </summary>
public struct ChangeUsingSkillStateCommand : ICommand
{
    public void Execute(object dataObj)
    {
        this.GetSystem<ISkillSystem>().UsingSkill = (bool)dataObj;
    }
}
