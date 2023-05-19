using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//�����ˣ� Trigger 
//����˵�����������ģ��(ģ�Ͳ�)
//***************************************** 
public class PlayerDataModel : IPlayerDataModel
{   
    public BindableProperty<int> MaxHP { get; } = new BindableProperty<int> {Value=0};

    public BindableProperty<int> CurHP{ get; } = new BindableProperty<int> { Value = 0 };

    public BindableProperty<int> CurMaxHP{ get; } = new BindableProperty<int> { Value = 0 };

    public BindableProperty<int> MaxMP { get; } = new BindableProperty<int> { Value = 0 };

    public BindableProperty<int> CurMP { get; } = new BindableProperty<int> { Value = 0 };

    public PlayerDataModel() { Init(); }

    private List<int> playerSKillList = new List<int>();

    public void Init()
    {
        MaxHP.Value = CurHP.Value = CurMaxHP.Value = 2000;
        MaxMP.Value = CurMP.Value = 1000;
    }

    public List<int> GetPlayerSkillList()
    {
        return playerSKillList;
    }
}
