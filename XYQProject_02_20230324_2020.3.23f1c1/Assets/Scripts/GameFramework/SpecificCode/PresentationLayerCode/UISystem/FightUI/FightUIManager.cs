using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//*****************************************
//创建人： Trigger 
//功能说明：战斗UI管理
//***************************************** 

/// <summary>战斗UI管理</summary>
public class FightUIManager : MonoBehaviour,IController
{
    private Button defendCommandBtn;
    private Button skillCommandBtn;
    private Button useItemCommandBtn;
    private GameObject fightCommandPanelGo;

    public void Init()
    {
        gameObject.Show();
        fightCommandPanelGo =   transform.FindChildDeep( "Emp_FightCommand").gameObject;
        fightCommandPanelGo.Show();
        skillCommandBtn =       transform.FindChildDeep( "Btn_Skill").GetComponent<Button>();
        useItemCommandBtn =     transform.FindChildDeep( "Btn_UseItem").GetComponent<Button>();
        defendCommandBtn =      transform.FindChildDeep( "Btn_Defend").GetComponent<Button>();

        //
        skillCommandBtn.onClick.AddListener(ClickSkillBtn);
        useItemCommandBtn.onClick.AddListener(ClickUseItemBtn);
        defendCommandBtn.onClick.AddListener(ClickDefendBtn);

        //
        this.RegistEvent<OpenOrCloseFightCommandPanelEvent>(OpenOrCloseFightCommandPanel);
        fightCommandPanelGo.Hide();
    }


    #region 辅助


    /// <summary>
    /// 使用技能指令按钮事件
    /// </summary>
    private void ClickSkillBtn()
    {
        this.SendEvent<OpenOrCloseSkillPanelEvent>(true);
    }


    /// <summary>
    /// 使用物品指令按钮事件
    /// </summary>
    public void ClickUseItemBtn()
    {
        this.SendCommnd<CloseAllFightUIPanelCommand>();
        this.SendEvent<OpenOrCloseFightBagPanelEvent>(true);
    }


    /// <summary>
    /// 防御指令按钮事件
    /// </summary>
    public void ClickDefendBtn()
    {
        this.SendCommnd<CloseAllFightUIPanelCommand>();
        this.SendCommnd<SetCharacterActCodeCommand>
        (
            new SetCharacterActCodeCommandParams()
            {
                actCode=ActCode.DEFEND
            }
        );
    }


    /// <summary>
    /// 关闭或开启战斗指令面板
    /// </summary>
    /// <param name="obj"></param>
    private void OpenOrCloseFightCommandPanel(object obj)
    {
        fightCommandPanelGo.SetActive((bool)obj);
    }


    #endregion

}
