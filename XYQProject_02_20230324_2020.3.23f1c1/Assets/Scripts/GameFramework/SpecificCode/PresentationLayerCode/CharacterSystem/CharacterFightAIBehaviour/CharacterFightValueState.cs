using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：人物战斗状态数据显示
//***************************************** 

/// <summary>人物战斗状态数据显示</summary>
public class CharacterFightValueState : CharacterFightAIBehaviour
{


    private CharacterCanvas characterCanvas;



    #region 生命


  public override  void Init()
    {
        base.Init();
        characterCanvas = GetComponentInChildren<CharacterCanvas>();
        if (fromAI.isPlayer)
        {
            fromAI.HP = PlayerData().CurMaxHP.Value;
            fromAI.curHP = PlayerData().CurHP.Value;
            fromAI.MP = PlayerData().MaxMP.Value;
            fromAI.curMP = PlayerData().CurMP.Value;
        }
        else
        {
            characterCanvas.HideSlider();
        }
        fromAI.curHP = fromAI.HP;
        //
        string characterName = GetCharacterInfo(fromAI.characterInfo).name;
        characterCanvas.SetCharacterName( characterName );

    }
    #endregion




    #region 辅助

    /// <summary>
    /// 方便找bug，不然报错在接口，不清晰
    /// </summary>
    CharacterInfo GetCharacterInfo(CharacterInfo characterInfo )
    {
        if (characterInfo.ID <= 0)
        {
            throw new System.Exception("ID异常："+characterInfo.ID);
        }
        return this.GetModel<ICharacterDataModel>().GetCharacterInfo(characterInfo.ID);
    }


    /// <summary>
    /// 显示跟血量变化相关的内容
    /// </summary>
    public void ShowHPValueChange(int changeValue)
    {
        NumCanvas numCanvas = Instantiate(
            ExtendResources.Get<GameObject>( ResourcesName.Prefab.CharacterNumCanvas),
            spriteRenderer.Position(),
            Quaternion.identity
        ).GetComponent<NumCanvas>();
        numCanvas.ShowNum(changeValue);
        //
        fromAI.curHP += changeValue;
        if (fromAI.curHP >= fromAI.HP)
        {
            fromAI.curHP = fromAI.HP;
        }
        
        if (fromAI.isPlayer)
        {
            characterCanvas.SetHPSliderValue((float)fromAI.curHP / fromAI.HP);
            this.SendCommnd<ChangePlayerHPCommand>(changeValue);
        }
    }

    /// <summary>
    /// 显示跟蓝耗变化相关的内容
    /// </summary>
    public void ShowMPValueChange(int changeValue)
    {
        fromAI.curMP += changeValue;
        if (fromAI.curMP >= fromAI.MP)
        {
            fromAI.curMP = fromAI.MP;
        }
        if (fromAI.isPlayer)
        {
            this.SendCommnd<ChangePlayerMPCommand>(changeValue);
        }
    }

    IPlayerDataModel PlayerData()
    {
        return this.GetModel<IPlayerDataModel>();
    }
    #endregion


}
