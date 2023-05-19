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


    #region 移动


    /// <summary>
    /// 设置死亡移动路径
    /// </summary>
    /// <param name="startPath"></param>
    /// <param name="endPath"></param>
    public void SetDieMovePath(Transform[] startPath, Transform[] endPath)
    {
        moveFightBehaviour.SetDieMovePath(startPath, endPath);
    }


    /// <summary>
    /// 设置当前移动状态
    /// </summary>
    public void SetMovingState(bool state)
    {
        moveFightBehaviour.SetMovingState(state);
    }


    /// <summary>
    /// 设置攻击指令执行前的行为（目标点，是朝目标点移动还是返回初始位置）
    /// </summary>
    /// <param name="moveAct">true进攻，false返回</param>
    /// <param name="attackPos"></param>
    public void SetMoveAction(bool moveAct = false, Vector3 attackPos = default)
    {
        moveFightBehaviour.SetMoveAction(moveAct, attackPos);
    }


    /// <summary>
    /// 释放技能造成的移动事件
    /// </summary>
    public void SetSkillMoveAction()
    {
        moveFightBehaviour.SetSkillMoveAction();
    }
    #endregion
}






