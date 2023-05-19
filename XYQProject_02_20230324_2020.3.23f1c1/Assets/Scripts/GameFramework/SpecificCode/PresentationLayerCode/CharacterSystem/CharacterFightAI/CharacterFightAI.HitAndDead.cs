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

    /// <summary>
    /// 受击行为
    /// </summary>
    public void HitBehaviour(DelayHitTargetCommandParams para)
    {
        HitBehaviour(para.canDodge, para.canDefend);
    }


    /// <summary>
    /// 受击行为
    /// </summary>
    public void HitBehaviour(bool canDodge = true, bool canDefend = true)
    {
        hitAndDieFightBehaviour.HitBehaviour(canDodge, canDefend);
    }





    /// <summary>
    /// 死亡行为
    /// </summary>
    public void DieBehaviour()
    {
        hitAndDieFightBehaviour.DieBehaviour();
    }


    /// <summary>
    /// 判断是否死亡
    /// </summary>
    public void JudgeIfDie()
    {
        hitAndDieFightBehaviour.JudgeIfDie();
    }
}






