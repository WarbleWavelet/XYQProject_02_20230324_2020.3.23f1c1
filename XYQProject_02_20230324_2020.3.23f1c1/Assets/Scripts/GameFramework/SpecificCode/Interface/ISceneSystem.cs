using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//*****************************************
//创建人： Trigger 
//功能说明：场景系统接口
//***************************************** 


/// <summary>场景系统接口</summary>
public interface ISceneSystem : ISystem
{
    /// <summary>
    /// 获取不同模式下的场景游戏物体
    /// </summary>
    /// <param name="isFightGo"></param>
    /// <returns></returns>
    GameObject NormalModeGo { get; }

    /// <summary>因为初始不激活，SetFightNavMeshGoCommand赋值</summary>
    GameObject FightModeGo { get; }


    /// <summary>
    /// 获取非战斗模式下的人物寻路AI
    /// </summary>
    /// <returns></returns>
    CharacterNormalAI PlayerNormalAI { get; }


    /// <summary>
    /// 设置或获取进入战斗计时器
    /// </summary>
    float EnterFightTimer { set; get; }


    /// <summary>
    /// 是否可以进入战斗
    /// </summary>
    bool CanEnterFight { set; get; }



    #region 辅助



    /// <summary>
    /// 设置正式进入战斗或非战斗状态
    /// </summary>
    void EnterOrExitFightMode(bool enter);


    /// <summary>
    /// 判断是否进入战斗
    /// </summary>
    /// <returns></returns>
    void JudgeEnterTheFight();



    /// <summary>
    /// 退出游戏
    /// </summary>
    void ExitGame();

    #endregion


}
