using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：人物受击与死亡行为
//***************************************** 

/// <summary>人物受击与死亡行为</summary>
public class HitAndDieFightBehaviour : CharacterFightAIBehaviour
{

    public override void Init()
    {
        base.Init();    
    }
    /// <summary> 受击行为 </summary>
    public void HitBehaviour(bool canDodge = true, bool canDefend = true)
    {
        navMeshAgent.isStopped = true;
        
        if (Random.Range(0, 3) >= 2 && canDodge)//闪避
        {
            fromAI.DodgeBehaviour();//闪避成功
            return;
        }
        
        if (fromAI.actCode == ActCode.DEFEND && canDefend)//防御
        {
            fromAI.DefendBehaviour();
            return;
        }
        //受击
        Hitted();
    }


    void Hitted()
    { 
        int costHp = Random.Range(60,120);
        fromAI.ShowHPValueChange(-costHp);
        fromAI.SetCurLookDir();
        characterAtrCtrl.PlayHitAtn();
        this.SendCommnd<CreateHitEffectCommand>();
        JudgeIfDie();    
    }


    /// <summary> 判断是否死亡 </summary>
    public void JudgeIfDie()
    {
        if (fromAI.curHP <= 0)
        {
            //死亡
            characterAtrCtrl.PlayDieAtn();
            Time.timeScale = 0.3f;
            Vector3 tarPos = fromAI.GetTarPosTrans(fromAI.curLookDir).position;
            transform.DoMove( tarPos, 0.2f)
               .SetOnComplete(
                () =>
                {
                    navMeshAgent.isStopped = false;
                    navMeshAgent.speed = 15f;
                }
            );
        }
        else
        {
            //受击
            fromAI.ToDenfendPos(0.2f);
        }
    }


    /// <summary> 死亡行为 </summary>
    public void DieBehaviour()
    {
        this.SendCommnd<CharacterDieCommand>();
        fromAI.characterState = CharacterState.DEAD;
        fromAI.SetMovingState(false);        
        //主要目的是为了放横扫一类的技能没有在原始
        //，要回去
        fromAI.ResetState();       
    }
}
