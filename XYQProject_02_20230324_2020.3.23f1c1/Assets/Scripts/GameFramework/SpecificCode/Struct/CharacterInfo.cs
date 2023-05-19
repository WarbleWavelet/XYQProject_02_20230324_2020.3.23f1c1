using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：人物信息
//***************************************** 

/// <summary>人物信息</summary>
public struct CharacterInfo
{
    public int ID;
    public string name;
    public string pathName;
    public string[] ableToJoinSects;
    public string description;
    public WeaponType[] canUseWeaponsType;
}



