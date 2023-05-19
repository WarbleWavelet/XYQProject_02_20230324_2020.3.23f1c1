using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//*****************************************
//创建人： Trigger 
//功能说明：人物信息数据模型接口
//***************************************** 


/// <summary>人物信息数据模型接口</summary>
public interface ICharacterDataModel:IModel
{
    /// <summary>抽象方法</summary>
    CharacterInfo GetCharacterInfo(int id);
    /// <summary>抽象方法</summary>
    CharacterInfo GetCharacterInfo(string name);
}
