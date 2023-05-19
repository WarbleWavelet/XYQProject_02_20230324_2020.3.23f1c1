using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//*****************************************
//创建人： Trigger 
//功能说明：玩家各种属性条的显示管理
//***************************************** 
public class PlayerSlidersManager : MonoBehaviour, IController
{
    private Slider hpSlider;
    private Slider mpSlider;


    void Awake()
    {
        hpSlider = transform.FindChildDeep( "Slider_PlayerHP").GetComponent<Slider>();
        mpSlider = transform.FindChildDeep( "Slider_PlayerMP").GetComponent<Slider>();        
    }

    private void Start()
    {
        this.GetModel<IPlayerDataModel>().CurHP.RegisterOnValueChanged(v => SetHPSliderValue(v));
        this.GetModel<IPlayerDataModel>().CurMP.RegisterOnValueChanged(v => SetMPSliderValue(v));
    }

    /// <summary>
    /// 显示头像旁边的血量值
    /// </summary>
    public void SetHPSliderValue(int value)
    {
        //当前血量小于等于上限
        float currentHP=0;
        IPlayerDataModel ipd = this.GetModel<IPlayerDataModel>();
        if (ipd.CurHP.Value<= ipd.CurMaxHP.Value)
        {
            currentHP = ipd.CurHP.Value;
        }
        else
        {
            currentHP = ipd.CurMaxHP.Value;
        }
        hpSlider.value = currentHP / ipd.MaxHP.Value;
    }
    /// <summary>
    /// 显示头像旁边的蓝量值
    /// </summary>
    /// <param name="value"></param>
    public void SetMPSliderValue(float value)
    {
        IPlayerDataModel ipd = this.GetModel<IPlayerDataModel>();
        mpSlider.value = (float)ipd.CurMP.Value/ipd.MaxMP.Value;
    }
}
