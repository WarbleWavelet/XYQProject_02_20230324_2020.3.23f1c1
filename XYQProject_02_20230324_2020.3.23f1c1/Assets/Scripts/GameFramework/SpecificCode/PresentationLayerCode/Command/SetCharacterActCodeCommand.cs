using UnityEngine;
/// <summary>
/// 创建人：Trigger<para/> 
/// 命令名称：设置当前人物的行为码<para/>
/// 参数:SetCharacterActCodeCommandParams <para/>
/// </summary>
public struct SetCharacterActCodeCommand : ICommand
{
    public void Execute(object obj)
    {
        SetCharacterActCodeCommandParams para = (SetCharacterActCodeCommandParams)obj;
        this.GetSystem<IFightSystem>().PlayerAI.SetActCodeAndActObj(para.actCode, para.actObj);
        this.SendCommnd<PerformLogicCommand>();
    }
}




