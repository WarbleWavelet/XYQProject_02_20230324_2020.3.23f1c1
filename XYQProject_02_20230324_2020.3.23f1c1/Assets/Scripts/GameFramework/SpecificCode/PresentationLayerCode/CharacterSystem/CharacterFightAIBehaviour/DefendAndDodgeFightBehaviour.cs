using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//*****************************************
//创建人： Trigger 
//功能说明：人物AI的防御与闪避行为
//***************************************** 

/// <summary>人物AI的防御与闪避行为</summary>
public class DefendAndDodgeFightBehaviour : CharacterFightAIBehaviour
{
    private GameObject dodgeEffectGo;

    public override void Init()
    {
        base.Init();
        ParticleSystem particleSystem = spriteRenderer.GetComponentInChildren<ParticleSystem>();
        dodgeEffectGo = particleSystem.gameObject;
        particleSystem.textureSheetAnimation.SetSprite(0, 
            ExtendResources.Get<Sprite>( 
                ResourcesName.Texture2D.GetCharacterFightIdlePath(gameObject.name)
            )
        );
    }



    #region 辅助


    /// <summary>
    /// 防御行为                                     
    /// </summary>
    public void DefendBehaviour()
    {
        AudioSourceManager.Instance.PlaySoundCharacter( ResourcesName.AudioClip.Defend
            ,gameObject.name
        );
        Instantiate( ExtendResources.Get<GameObject>(ResourcesName.Prefab.DefendEffect) 
            ,spriteRenderer.transform
        );
        int random = Random.Range(20, 50);
        fromAI.ShowHPValueChange(-random);
        fromAI.SetCurLookDir();
        characterAtrCtrl.PlayDefendAtn();
        fromAI.JudgeIfDie();
    }


    /// <summary>
    /// 移动到防御位置并返回
    /// </summary>
    /// <param name="animationTime">动画时间</param>
    /// <param name="callBack">需要在动画完成后进行的额外回调</param>
    public void ToDenfendPos(float animationTime, UnityAction callBack = null)
    {
        transform.DoMove(fromAI.GetCurAITarPos(), animationTime)
            .SetOnComplete(
            () =>
            {
                transform.DoMove(fromAI.initPos, animationTime).SetOnComplete
                (
                    () =>
                    {
                        navMeshAgent.isStopped = false;
                        if (callBack != null)
                        {
                            callBack();
                        }
                    }
                );
            }
            );
    }


    /// <summary>
    /// 闪避行为
    /// </summary>
    public void DodgeBehaviour()
    {
        //添加特效
        dodgeEffectGo.Show();
        ToDenfendPos(
            0.15f,
            () => 
            { 
                dodgeEffectGo.Hide();
            }
        );
    }
    #endregion

}
