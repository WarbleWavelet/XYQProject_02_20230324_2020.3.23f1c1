using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：XYQ游戏架构
//***************************************** 
public class XYQArchitecture : Architecture<XYQArchitecture>
{
    protected override void Init()
    {          


        RegistSystem<ISystem>(new UISystem());
        RegistSystem<ISkillSystem>(new SkillSystem());
        RegistSystem<IFightSystem>(new FightSystem());
        RegistSystem<ISceneSystem>(new SceneSystem());

        RegistModel<IPlayerDataModel>(new PlayerDataModel());
        RegistModel<ISkillDataModel>(new SkillDataModel());
        RegistModel<ICharacterDataModel>(new CharacterDataModel());
    }
}
