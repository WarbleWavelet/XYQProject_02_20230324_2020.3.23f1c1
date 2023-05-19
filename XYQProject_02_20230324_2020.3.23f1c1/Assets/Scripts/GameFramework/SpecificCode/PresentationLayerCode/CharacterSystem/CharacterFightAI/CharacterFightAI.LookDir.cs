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


    #region 看向


    /// <summary>
    /// 获取当前AI的目标位置
    /// </summary>
    /// <returns></returns>
    public Vector3 GetCurAITarPos()
    {
        if (toAI)//攻击者
        {
            return toAI.GetTarPosTrans( toAI.transform.position - transform.position).position;
        }
        else//被攻击者
        {
            return GetTarPosTrans( -this.GetSystem<IFightSystem>().CurAI.curLookDir).position;
        }
    }


    #region 得到攻击对手的方向


    /// <summary>
    /// 获取行动者的行动目标点
    /// </summary>
    /// <param name="getDir">攻击者看向方向</param>
    /// <returns></returns>
    public Transform GetTarPosTrans(Vector2 getDir)
    {
         return GetTarPosTrans1( getDir);
       // return  GetSelfAtkDrirByEnemyAtcDir(getDir);
    }

    /// <summary>方式1</summary>
    public Transform GetTarPosTrans1(Vector2 getDir)
    {
        Transform trans;
        if (getDir.x > 0)
        {
            //(1,1)
            if (getDir.y > 0)//攻击者看向右上，攻击位置为被攻击者左下
            {
                trans = tarPosTranses[3];
            }
            //(1,-1)
            else//攻击者看向右下，攻击位置为被攻击者左上
            {
                trans = tarPosTranses[2];
            }
        }
        else
        {
            //(-1,1)
            if (getDir.y > 0)//攻击者看向左上，攻击位置为被攻击者右下
            {
                trans = tarPosTranses[0];
            }
            //(-1,-1)
            else//攻击者看向左下，攻击位置为被攻击者右上
            {
                trans = tarPosTranses[1];
            }
        }
        return trans;
    }


    #region 方式2


    /// <summary>
    /// 方式2
    /// 通过对手攻击方向知道自己要进攻的方向
    /// 求第几象限</summary>
    Transform GetSelfAtkDrirByEnemyAtcDir(Vector2 enemyAtcDir)
    {
        switch (GetQuadrant(enemyAtcDir))
        {
            case 0: return tarPosTranses[3];
            case 1: return tarPosTranses[2];
            case 2: return tarPosTranses[1];
            case 3: return tarPosTranses[0];
            default: throw new System.Exception("异常");

        }
    }

    /// <summary>哪个象限</summary>
    int GetQuadrant(Vector2 enemyAtcDir)
    {
        if (enemyAtcDir.x > 0 && enemyAtcDir.y > 0) return 0;
        if (enemyAtcDir.x < 0 && enemyAtcDir.y > 0) return 1;
        if (enemyAtcDir.x < 0 && enemyAtcDir.y < 0) return 2;
        if (enemyAtcDir.x > 0 && enemyAtcDir.y < 0) return 3;
         throw new System.Exception("异常");
    }
    #endregion


    #endregion

    /// <summary>
    /// 设置当前看向方向
    /// </summary>
    public void SetCurLookDir(Vector3 atrPos = default, bool ifReset = false)
    {
        if (ifReset)
        {
            curLookDir = initLookDir;
        }
        else
        {
            Vector3 ld;
            if (atrPos == default)
            {
                //被攻击者
                ld = -this.GetSystem<IFightSystem>().CurAI.curLookDir;
            }
            else
            {
                //攻击者
                ld = atrPos - transform.position;
            }
            if (ld.magnitude <= 0.2f)
            {
                return;
            }
            int x = ld.x > 0 ? 1 : -1;
            int y = ld.y > 0 ? 1 : -1;
            curLookDir = new Vector2( x, y);
        }

    }
    #endregion

}






