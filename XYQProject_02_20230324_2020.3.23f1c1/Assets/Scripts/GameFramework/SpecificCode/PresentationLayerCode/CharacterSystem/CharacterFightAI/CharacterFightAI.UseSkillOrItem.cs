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


    #region 使用物品或技能
    /// <summary>
    /// 使用物品或者技能后的事件
    /// </summary>
    public void UseSkillOrItemAction()
    {
        useItemAndSkillFightBehaviour.UseSkillOrItemAction();
    }
    #endregion




}






