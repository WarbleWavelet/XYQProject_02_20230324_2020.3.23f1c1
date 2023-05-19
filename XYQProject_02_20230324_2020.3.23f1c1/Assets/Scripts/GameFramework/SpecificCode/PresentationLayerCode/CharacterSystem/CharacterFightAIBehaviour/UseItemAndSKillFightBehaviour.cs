using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：使用物品与技能的战斗行为
//***************************************** 

/// <summary>使用物品与技能的战斗行为</summary>
public class UseItemAndSKillFightBehaviour : CharacterFightAIBehaviour
{
    public override void Init()
    {
        base.Init();    
    }

    /// <summary>使用物品或者技能后的事件</summary>
    public void UseSkillOrItemAction()
    {
        if (fromAI.actCode == ActCode.USEITEM)//使用物品
        {
            switch (fromAI.actObj.itemID)
            {
                case 0:
                    InstantiateRecoverEffect(ResourcesName.Prefab.RecoverHPEffect);
                    break;
                case 1:
                    InstantiateRecoverEffect(ResourcesName.Prefab.RecoverMPEffect);
                    break;
                default:
                    break;
            }
            // TODO Delay
            this.Delay(DelayUseItem, 1.083f);
        }
        else if (fromAI.actCode == ActCode.SKILL)//使用技能
        {
            string soundName = ExtendPath.GetSkillPath(fromAI.actObj);
            AudioSourceManager.Instance.PlaySound( soundName );
            this.SendCommnd<CreateSkillEffectCommand>();
            // TODO Delay
            this.Delay(DelayUseSKill, fromAI.actObj.skillInfo.delayHitTime);
        }
    }





    #region 辅助


    /// <summary>使用物品或者使用技能行为</summary>
    public void UseItemOrUseRemoteSkillBehaviour()
    {
        AudioSourceManager.Instance.PlaySoundCharacter("UseSkillOrItem", gameObject.name);
        fromAI.SetCurLookDir(Vector3.zero, true);
        characterAtrCtrl.PlaySkillAtn();
    }


    /// <summary>延时使用物品，Invoke</summary>
    public void DelayUseItem()
    {
        switch (fromAI.actObj.itemID)
        {
            case 0:
                AudioSourceManager.Instance.PlaySoundCharacter( "RecoverHP");
                fromAI.ShowHPValueChange( Random.Range(80, 200) );
                break;
            case 1:
                AudioSourceManager.Instance.PlaySoundCharacter("RecoverMP");
                fromAI.ShowMPValueChange( Random.Range(150, 220) );
                break;
            default:
                break;
        }
        Invoke("DelayEndCurrentTurn", 0.7f);
    }



    /// <summary>延时对敌人造成伤害</summary>
    public void DelayUseSKill()
    {
        int cost = -fromAI.actObj.skillInfo.decreaseValue1;
        switch (fromAI.actObj.skillInfo.ID)
        {
            case 1:
            case 2:
            case 3:
                { 
                    this.SendCommnd<DelayHitTargetCommand>(
                        new DelayHitTargetCommandParams()
                        { 
                            canDefend = false, 
                            canDodge = false 
                        }
                    );                
                }
                break;
            case 4:
                { 
                    fromAI.ShowMPValueChange( cost );
                    this.SendCommnd<DelaySowTargetCommand>();                
                }
                break;
            case 5:
                { 
                    fromAI.toAI.ShowHPValueChange( Random.Range(150,260) );
                    fromAI.ShowMPValueChange( cost );                
                } break;
            default: break;
        }
        Invoke("DelayEndCurrentTurn", 0.7f);

    }


    private void DelayEndCurrentTurn()
    {
         this.SendCommnd<EndCurrentTurnCommand>();
    }


    /// <summary>实例恢复的特效</summary>
    void InstantiateRecoverEffect(string recoverEffectName)
    {
        Instantiate(InternalResources.GetRecoverEffect(recoverEffectName) 
            ,characterAtrCtrl.transform.position
            ,Quaternion.identity
        ); 
    }
    #endregion


}
