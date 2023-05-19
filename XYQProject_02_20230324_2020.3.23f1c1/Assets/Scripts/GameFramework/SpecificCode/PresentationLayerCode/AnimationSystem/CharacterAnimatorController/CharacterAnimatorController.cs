using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：控制人物动画切换
//***************************************** 

/// <summary>控制人物动画切换，受CharacterFightAI调用</summary>
public partial class CharacterAnimatorController : MonoBehaviour
{

    private Animator atr;
    public bool isMoving;
    /// <summary>CharacterNormalAI没用到、CharacterFightAI用到，来赋值。但是不同</summary>
    public CharacterFightAI  fromAI;


    public void Init()
    {
        //Animator的父节点可能是 CharacterFightAI 或者 CharacterNormalAI
        if (GetComponent<Animator>() == null)
        {
            throw new System.Exception("异常:"+transform.parent.name);
        }
        atr = GetComponent<Animator>();
        //
        if ( GetComponentInParent<CharacterFightAI>() != null) // CharacterNormalAI也挂CharacterAnimatorController
        {
            fromAI = GetComponentInParent<CharacterFightAI>();
        }             

       //

        if (fromAI!=null)
        {
            string path =  ResourcesName.OverrideController.CharacterPath(fromAI.characterInfo.pathName); 
            atr.runtimeAnimatorController = ExtendResources.Get<RuntimeAnimatorController>(path);
        } 
    }


    #region 辅助


    #region 动画事件


    /// <summary>挂在Timeline时间轴上的帧的时间</summary>
    private void AttackAnimationEvent()
    {
        fromAI.AttackTarget();
    }


    /// <summary>挂在Timeline时间轴上的帧的时间</summary>
    private void UseSkillOrItemAnimationEvent()
    {
        fromAI.UseSkillOrItemAction();
    }
    #endregion



    /// <summary>
    /// 播放位移动画
    /// </summary>
    /// <param name="curPos">当前位置</param>
    /// <param name="navPos">导航点</param>
    /// <param name="tarPos">最终目标点</param>
    public void PlayLocomotionAtn(Vector3 curPos, Vector3 navPos, Vector3 tarPos)
    {
        Vector3 lookDir = navPos - curPos;
        if (lookDir.magnitude <= 0.0001f)
        {
            lookDir = tarPos - curPos;
        }


        if (Vector3.Distance(curPos, tarPos) > 0.3f)
        {
            atr.SetFloat(AnimatorPara.LookX, lookDir.normalized.x);
            atr.SetFloat(AnimatorPara.LookY, lookDir.normalized.y);
            atr.SetBool(AnimatorPara.MoveState, true);
            isMoving = true;
        }
        else if (Vector3.Distance(curPos, tarPos) < 0.15f)
        {
            atr.SetBool(AnimatorPara.MoveState, false);
            isMoving = false;
        }
    }





    public void PlayDieAtn()
    {
        atr.SetBool(AnimatorPara.Die, true);
    }

    public void PlayMoveAtn(float moveValue)
    {
        SetLookDir(fromAI.curLookDir);
        atr.SetInteger(AnimatorPara.MoveValue, 1);
    }

    public void PlayIdleAtn()
    {
        SetLookDir(fromAI.curLookDir);
        atr.SetInteger(AnimatorPara.MoveValue, 0);
    }

    public void PlayAttackAtn()
    {
        SetLookDir(fromAI.curLookDir);
        atr.SetTrigger(AnimatorPara.Attack);
    }

    public void PlaySkillAtn()
    {
        SetLookDir(fromAI.curLookDir);
        atr.SetTrigger(AnimatorPara.Skill);
    }

    public void PlayDefendAtn()
    {
        SetLookDir(fromAI.curLookDir);
        atr.SetTrigger(AnimatorPara.Defend);
    }
    public void SetLookDir(Vector2 lookDir)
    {
        atr.SetFloat(AnimatorPara.LookDirX, lookDir.x);
        atr.SetFloat(AnimatorPara.LookDirY, lookDir.y);
    }


    public void PlayHitAtn()
    {
        SetLookDir(fromAI.curLookDir);
        atr.SetTrigger(AnimatorPara.Hit);
    }



    #endregion
}
