using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：人物数据模型
//***************************************** 

/// <summary>人物数据模型</summary>
public class CharacterDataModel : ICharacterDataModel
{
    private Dictionary<int, CharacterInfo> characterInfoDict;
    private Dictionary<string, CharacterInfo> characterInfoStrDict;

    public CharacterDataModel() { Init(); }


    public void Init()
    {
        characterInfoDict=InitCharacterInfoDict();
        characterInfoStrDict=InitCharacterInfoStrDict(characterInfoDict);
    }


    #region 辅助


    public CharacterInfo GetCharacterInfo(int id)
    {
        if (characterInfoDict.ContainsKey(id))
        {
            return characterInfoDict[id];
        }
        else
        {
            throw new System.Exception("不存在ID为" + id + "的人物");
        }
    }


    public CharacterInfo GetCharacterInfo(string name)
    {
        if (characterInfoStrDict.ContainsKey(name))
        {
            return characterInfoStrDict[name];
        }
        else
        {
            throw new System.Exception("不存在名称为" + name + "的人物");
        }
    }



    Dictionary<int, CharacterInfo> InitCharacterInfoDict()
    {
        Dictionary<int, CharacterInfo> characterInfoDict = new Dictionary<int, CharacterInfo>()
        {
            { 
                1,
                new CharacterInfo()
                {
                    ID=1,
                    name="剑侠客",
                    pathName="JianXiaKe"
                } 
            },
            { 
                2,
                new CharacterInfo()
                {
                    ID=2,
                    name="骨精灵",
                    pathName="GuJingLing" 
                }
            },
            { 
                3,
                new CharacterInfo()
                {
                    ID=3,
                    name="大海龟",
                    pathName="DaHaiGui"
                } 
            },
            { 
                4,
                new CharacterInfo()
                {
                    ID=4,
                    name="巨蛙",
                    pathName="JuWa" 
                } 
            },
            { 
                5,
                new CharacterInfo()
                {
                    ID=5,
                    name="海毛虫",
                    pathName="HaiMaoChong" 
                } 
            }
        };
         return characterInfoDict;
    }

    Dictionary<string, CharacterInfo> InitCharacterInfoStrDict(Dictionary<int, CharacterInfo> characterInfoDict)
    {
        Dictionary<string, CharacterInfo>  characterInfoStrDict = new Dictionary<string, CharacterInfo>();
        foreach (var item in characterInfoDict)
        {
            characterInfoStrDict.Add(item.Value.name, item.Value);
        }
        return characterInfoStrDict;
    }
    #endregion

}
