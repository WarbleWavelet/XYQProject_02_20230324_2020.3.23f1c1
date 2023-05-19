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


    #region 闪避与防御
    /// <summary>
    /// 闪避行为
    /// </summary>
    public void DodgeBehaviour()
    {
        defendAndDodgeFightBehaviour.DodgeBehaviour();
    }


    /// <summary>
    /// 防御行为
    /// </summary>
    public void DefendBehaviour()
    {
        defendAndDodgeFightBehaviour.DefendBehaviour();
    }


    /// <summary>
    /// 移动到防御位置并返回
    /// </summary>
    /// <param name="animationTime">动画时间</param>
    /// <param name="callBack">需要在动画完成后进行的额外回调</param>
    public void ToDenfendPos(float animationTime, UnityAction callBack = null)
    {
        defendAndDodgeFightBehaviour.ToDenfendPos(animationTime, callBack);
    }
    #endregion


}






