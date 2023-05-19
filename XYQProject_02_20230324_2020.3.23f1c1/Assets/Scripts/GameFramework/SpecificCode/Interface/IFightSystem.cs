using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：战斗系统接口
//***************************************** 

/// <summary>战斗系统接口</summary>
public interface IFightSystem : ISystem
{
    /// <summary>是否进入当前回合</summary>
    bool EnterCurRound { get; set; }
    /// <summary>正在执行当前阶段的逻辑</summary>
    bool IsPerformingLogic { get; set; }
    /// <summary>当前阶段死亡的敌人数量</summary>
    int DieCnt { get; set; }
    /// <summary>当前回合行动的人物索引</summary>
    int CurActIdx { get; set; }
    /// <summary>当前回合行动的人物</summary>
    CharacterFightAI CurAI { get; set; }
    /// <summary>当前战斗中所有人物AI的列表</summary>
    List<CharacterFightAI> CurActAILst { get; set; }
    /// <summary>当前所有敌人的引用</summary>
    List<CharacterFightAI> EnemyAIList{ get; set; }
    /// <summary>当前目标AI列表</summary>
    List<CharacterFightAI> CurTarAIList { get; set; }
    /// <summary>玩家AI</summary>
    CharacterFightAI PlayerAI { get; set; }
    /// <summary>人物预制体</summary>
    CharacterFightAI CharacterPrefab { get; }
    /// <summary>玩家初始位置</summary>
    Transform PlayerInitPosTrans { get; }
    /// <summary>敌人的初始位置</summary>
    Transform[] EnemyInitPosTrans { get; }
    /// <summary>玩家的死亡移动开始路径</summary>
    Transform[] PlayerDieStartMovePath { get; }
    /// <summary>玩家的死亡移动结束路径</summary>
    Transform[] PlayerDieEndMovePath { get; }
    /// <summary>敌人的死亡移动开始路径</summary>
    Transform[] EnemyDieStartMovePath { get; }
    /// <summary>敌人的死亡移动结束路径</summary>
    Transform[] EnemyDieEndMovePath { get; }
    /// <summary>玩家目标</summary>
    CharacterFightAI PlayerTarAI { set; get; }
}
