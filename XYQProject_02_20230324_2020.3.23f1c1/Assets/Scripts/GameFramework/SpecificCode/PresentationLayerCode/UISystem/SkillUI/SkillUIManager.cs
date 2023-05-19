using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//*****************************************
//创建人： Trigger 
//功能说明：技能UI管理
//***************************************** 


/// <summary>技能UI管理</summary>
public class SkillUIManager : MonoBehaviour,IController
{
    private Button[] skillBtns;

    public void Init()
    {
        gameObject.Show();
        skillBtns = new Button[4];
        skillBtns[0] = transform.GetButtonDeep( "Btn_SkillHengSaoQianJun");
        skillBtns[1] = transform.GetButtonDeep( "Btn_SkillJiJiWaiWai");
        skillBtns[2] = transform.GetButtonDeep( "Btn_SkillFanJianZhiJi");
        skillBtns[3] = transform.GetButtonDeep( "Btn_SkillHuaYu");
        //
        skillBtns[0].onClick.AddListener(() => { ClickSkill(1); });
        skillBtns[1].onClick.AddListener(() => { ClickSkill(2); });
        skillBtns[2].onClick.AddListener(() => { ClickSkill(4); });
        skillBtns[3].onClick.AddListener(() => { ClickSkill(5); });
        //
        this.RegistEvent<OpenOrCloseSkillPanelEvent>(OpenOrCloseSkillPanel);
        this.RegistEvent<CancelUsingSkillEvent>(CancelUsingSkill);
        gameObject.Hide();      
    }


    #region 辅助


    /// <summary>
    /// 点击某个技能
    /// </summary>
    /// <param name="skillID"></param>
    public void ClickSkill(int skillID)
    {
        this.SendCommnd<ChangeUsingSkillStateCommand>(true);
        this.SendCommnd<ChangeCurSkillIDCommand>(skillID);
        this.SendCommnd<CloseAllFightUIPanelCommand>();
    }


    /// <summary>
    /// 打开或者关闭战斗中的技能面板
    /// </summary>
    /// <param name="obj">开关</param>
    private void OpenOrCloseSkillPanel(object obj)
    {
        bool open = (bool)obj;
        if (open)
        {
            for (int i = 0; i < this.GetModel<IPlayerDataModel>().GetPlayerSkillList().Count - 1; i++)
            {
                int cur = this.GetModel<IPlayerDataModel>().CurMP.Value;
                int skillID = this.GetModel<IPlayerDataModel>().GetPlayerSkillList()[i];
                int cost = this.GetModel<ISkillDataModel>().GetSkillInfo(skillID).decreaseValue1;
                skillBtns[i].interactable = cur >= cost ;
            }
        }
        gameObject.SetActive(open);
    }


    /// <summary>
    /// 取消技能使用
    /// </summary>
    /// <param name="obj"></param>
    private void CancelUsingSkill(object obj)
    {
        if (this.GetSystem<ISkillSystem>().UsingSkill)
        {
            this.SendCommnd<ChangeUsingSkillStateCommand>(false);
            this.SendEvent<OpenOrCloseFightCommandPanelEvent>(true);
        }
    }
    #endregion


}
