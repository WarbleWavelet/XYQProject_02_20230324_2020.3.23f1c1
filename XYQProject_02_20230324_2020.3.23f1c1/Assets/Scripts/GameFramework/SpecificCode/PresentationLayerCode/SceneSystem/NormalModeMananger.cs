using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：游戏管理（判断是否进入战斗）
//***************************************** 


/// <summary>游戏管理（判断是否进入战斗）</summary>
public class NormalModeMananger :MonoBehaviour,IController
{

    private void Update()
    {
        this.SendCommnd<JudgeEnterTheFightCommand>();
    }
}
