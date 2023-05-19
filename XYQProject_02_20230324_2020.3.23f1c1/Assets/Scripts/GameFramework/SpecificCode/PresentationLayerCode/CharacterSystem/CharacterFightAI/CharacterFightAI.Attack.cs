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
    /// 增加技能攻击的次数并判断是否移动
    /// </summary>
    public bool SetSkillAttackCntAndJudgeIfMoveAction()
    {
        return attackFightBehaviour.SetSkillAtkCntAndJudgeIfMoveAction();
       
    }


    /// <summary>
    /// 攻击行为  攻击声音，动画
    /// </summary>
    public void AttackBehaviour()
    {
        attackFightBehaviour.AttackBehaviour();
    }


    /// <summary>
    /// 攻击目标
    /// </summary>
    public void AttackTarget()
    {
        attackFightBehaviour.AttackTarget();
    }


    /// <summary>
    /// 销毁当前的debuff
    /// </summary>
    public void DestoryDebuff()
    {
        if (characterState == CharacterState.NORMAL)
        {
            attackFightBehaviour.DestoryDebuff();
        }        
    }

}






