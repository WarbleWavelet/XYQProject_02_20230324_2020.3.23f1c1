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

/// <summary>人物战斗AI 混乱</summary>
public partial class CharacterFightAI : MonoBehaviour,IController
{



    #region 混乱


    /// <summary>
    /// 混乱移动
    /// </summary>
    public void DoChaosMoveTween()
    {
        if (chaosTween != null)
        {
            return;
        }
        DoChaosMove();
    }



    private void DoChaosMove()
    {
        chaosTween = atrTrans
            .DoMove(GetChaosMoveTarget(), 0.05f) //左摇
            .SetOnComplete
            (
                () =>
                {
                    chaosTween = atrTrans
                        .DoMove(GetRendererInitPos(), 0.05f) //右晃
                        .SetOnComplete(DoChaosMove);
                }
            );
    }


    private Vector3 GetChaosMoveTarget()
    {
        Vector3 startPos = GetRendererInitPos();
        Vector2 randomPos = Random.insideUnitCircle * 0.1f;
        return startPos + new Vector3(randomPos.x, randomPos.y, startPos.z);
    }


    private Vector3 GetRendererInitPos()
    {
        return transform.TransformPoint( new Vector3(0, 0.3f, 0) );
    }
    #endregion
}






