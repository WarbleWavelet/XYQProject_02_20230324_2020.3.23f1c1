using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//*****************************************
//创建人： Trigger 
//功能说明：物品UI管理
//***************************************** 
public class ItemUIManager : MonoBehaviour,IController
{
    private GameObject fightBagPanelGo;
    private Button[] useItemBtns;

    public void Init()
    {
        gameObject.Show();
        useItemBtns = new Button[2];
        fightBagPanelGo = transform.FindChildDeep( "Panel_FightBag").gameObject;
        useItemBtns[0] =  transform.FindChildDeep( "Btn_RecoverHP").GetComponent<Button>();
        useItemBtns[1] =  transform.FindChildDeep( "Btn_RecoverMP").GetComponent<Button>();
        useItemBtns[0].onClick.AddListener(() => { ClickItem(0); });
        useItemBtns[1].onClick.AddListener(() => { ClickItem(1); });
        this.RegistEvent<OpenOrCloseFightBagPanelEvent>(OpenOrCloseFightBagPanel);

        fightBagPanelGo.Hide();
    }

    /// <summary>
    /// 使用物品
    /// </summary>
    private void ClickItem(int itID)
    {
        this.SendCommnd<CloseAllFightUIPanelCommand>();
        this.SendCommnd<SetCharacterActCodeCommand>(new SetCharacterActCodeCommandParams()
        {
            actCode = ActCode.USEITEM,
            actObj = new ActObj()
            {
                itemID = itID
            }
        }); ;
    }

    private void OpenOrCloseFightBagPanel(object obj)
    {
        fightBagPanelGo.SetActive((bool)obj);
    }
}
