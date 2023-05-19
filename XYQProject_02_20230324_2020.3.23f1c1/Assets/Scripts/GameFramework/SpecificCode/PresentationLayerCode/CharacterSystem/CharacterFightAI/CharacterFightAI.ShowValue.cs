using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
//*****************************************
//创建人： Trigger 
//功能说明：人物战斗AI
//***************************************** 

/// <summary>人物战斗AI</summary>
public partial class CharacterFightAI : MonoBehaviour,IController
{


    #region 显示数值状态


    /// <summary>
    /// 显示跟血量变化相关的内容
    /// </summary>
    public void ShowHPValueChange(int changeValue)
    {
        characterFightValueState.ShowHPValueChange(changeValue);
    }


    /// <summary>
    /// 显示跟蓝耗变化相关的内容
    /// </summary>
    public void ShowMPValueChange(int changeValue)
    {
        characterFightValueState.ShowMPValueChange(changeValue);
    }
    #endregion
}






