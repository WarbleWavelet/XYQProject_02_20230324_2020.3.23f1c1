using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//*****************************************
//创建人： Trigger 
//功能说明：
//*****************************************


/// <summary>
/// 关闭所有战斗UI面板
/// </summary>
public struct CloseAllFightUIPanelCommand : ICommand
{
    public void Execute(object obj)
    {
        this.SendEvent<OpenOrCloseFightCommandPanelEvent>(false);
        this.SendEvent<OpenOrCloseSkillPanelEvent>(false);
        this.SendEvent<OpenOrCloseFightBagPanelEvent>(false);
    }
}
