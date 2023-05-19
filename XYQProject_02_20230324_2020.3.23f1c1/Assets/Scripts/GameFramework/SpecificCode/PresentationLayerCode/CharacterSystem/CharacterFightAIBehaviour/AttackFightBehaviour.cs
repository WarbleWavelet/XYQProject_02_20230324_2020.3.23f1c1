using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//*****************************************
//创建人： Trigger 
//功能说明：人物战斗攻击行为
//***************************************** 

/// <summary>人物战斗攻击行为</summary>
public class AttackFightBehaviour : CharacterFightAIBehaviour
{


    public GameObject debuffGo;
    /// <summary>攻击次数（技能使用）</summary>
    public int atkCnt;
    /// <summary>当前攻击次数</summary>
    public int curAtkCnt;
    public Vector3 atkTarPos;



    #region 生命


    public override void Init()
    {
        base.Init();
    }
    #endregion



    #region 辅助





    /// <summary>
    /// 攻击行为
    /// </summary>
    public void AttackBehaviour()
    {
        AudioSourceManager.Instance.PlaySoundCharacter(ResourcesName.AudioClip.Attack, gameObject.name);
        characterAtrCtrl.PlayAttackAtn();
    }


    /// <summary>
    /// 攻击目标
    /// </summary>
    public void AttackTarget()
    {
        if (fromAI.actCode == ActCode.SKILL)//技能
        {
            fromAI.ShowHPValueChange( -Random.Range(1, 20) );//扣血
            if (curAtkCnt == 2)//最高次数2连击？
            {
                fromAI.characterState = CharacterState.REST;//休息
                CreateAttackDebuff();//加debuff
            }
            fromAI.toAI.HitBehaviour(false); //不闪避受击
        }                              
        else                                                 
        {
            fromAI.toAI.HitBehaviour();
        }
    }


    /// <summary>
    /// 生成横扫debuff特效
    /// </summary>
    private void CreateAttackDebuff()
    {
        debuffGo = Instantiate( ExtendResources.Get<GameObject>(ResourcesName.Prefab.HengSaoDebuff)
            , transform );
        debuffGo.transform.localPosition = Vector3.zero;
    }


    /// <summary>
    /// 销毁当前的debuff
    /// </summary>
    public void DestoryDebuff()
    {
        if (debuffGo!=null)
        {
            Destroy(debuffGo);
            debuffGo = null;
        }
    }


    /// <summary>
    /// 增加技能攻击的次数并判断是否移动
    /// </summary>
    public bool SetSkillAtkCntAndJudgeIfMoveAction()
    {
        curAtkCnt++;
        return curAtkCnt < atkCnt;
    }



    /// <summary>
    /// 设置当前回合的攻击次数
    /// </summary>
    public void SetAtkCnt(int num)
    {
        atkCnt = num;
    }


    /// <summary>
    /// 重置攻击状态
    /// </summary>
    public void ResetAtkState()
    {
        if ( Vector3.Distance( transform.position, fromAI.initPos ) > 0.2f) //复位
        {
            if (atkCnt != 0)   
            {
                fromAI.characterState = CharacterState.REST;
                CreateAttackDebuff();
            }
            fromAI.SetMoveAction();
        }
        curAtkCnt  = 0;
        atkCnt = 0;
    }
    #endregion

}
