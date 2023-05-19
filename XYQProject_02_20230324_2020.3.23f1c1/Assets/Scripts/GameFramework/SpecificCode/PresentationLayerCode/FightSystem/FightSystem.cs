using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：战斗系统
//***************************************** 
public class FightSystem : IFightSystem
{


    #region 字属 构造


    public bool EnterCurRound { get; set; }
    public bool IsPerformingLogic { get; set; }
    public int DieCnt { get; set; }
    public int CurActIdx { get; set; }
    public CharacterFightAI CurAI { get; set; }
    public List<CharacterFightAI> CurActAILst { get; set; } = new List<CharacterFightAI>();
    public List<CharacterFightAI> EnemyAIList { get; set; } = new List<CharacterFightAI>();
    public List<CharacterFightAI> CurTarAIList { get; set; } = new List<CharacterFightAI>();
    public CharacterFightAI PlayerAI { get; set; }
    /// <summary>玩家目标</summary>
    public CharacterFightAI PlayerTarAI { set; get; }
    public CharacterFightAI CharacterPrefab { set; get; }


    #region 位置相关


    /// <summary>进入战斗玩家初始位置</summary>
    public Transform PlayerInitPosTrans{ set; get; }

    /// <summary>进入战斗敌人初始位置</summary>

    private Transform[] enemyInitPosTrans = new Transform[10];
    /// <summary>用的是Transform，因为位置有变化</summary>
    public Transform[] EnemyInitPosTrans { get { return enemyInitPosTrans; } }
    //

    private Transform[] playerDieStartMovePath = new Transform[5];
    public Transform[] PlayerDieStartMovePath { get { return playerDieStartMovePath; } }

    private Transform[] playerDieEndMovePath = new Transform[5];
    public Transform[] PlayerDieEndMovePath { get { return playerDieEndMovePath; } }

    private Transform[] enemyDieStartMovePath = new Transform[5];
    public Transform[] EnemyDieStartMovePath { get { return enemyDieStartMovePath; } }

    private Transform[] enemyDieEndMovePath = new Transform[5];
    public Transform[] EnemyDieEndMovePath { get { return enemyDieEndMovePath; } }
    #endregion  


    public FightSystem()
    {
        Init();
    }
    #endregion



    #region 辅助


    public void Init()
    {
       // Init1();
        Init2();
    }



     void Init2()
    {
        CharacterPrefab = ExtendResources.Get<GameObject>(GameObjectPath.Prefab_CharacterFight).GetComponent<CharacterFightAI>();
        //  Transform tf = GameObject.Find(GameObjectName.FightNavMesh).transform;     
        //上面的方法找不到就用这种方法
        //FindTop需要transform，但是这里没有，所以随便找个Camera.main
        Transform tf = Camera.main.transform.FindTop(GameObjectName.FightNavMesh); 
        PlayerInitPosTrans = tf.FindChildDeep(GameObjectName.PlayerPos);
        tf.GetChildrenDeep(GameObjectName.EnemyPos, out enemyInitPosTrans);
        tf.GetChildrenDeep(GameObjectName.PlayerDieStartMovePath, out playerDieStartMovePath);
        tf.GetChildrenDeep(GameObjectName.PlayerDieEndMovePath, out playerDieEndMovePath);
        tf.GetChildrenDeep(GameObjectName.EnemyDieStartMovePath, out enemyDieStartMovePath);
        tf.GetChildrenDeep(GameObjectName.EnemyDieEndMovePath, out enemyDieEndMovePath);
    }

    /// <summary>原版的初始化</summary>

    void Init1()
    {
        CharacterPrefab  = ExtendResources.Get<GameObject>(ResourcesName.Prefab.CharacterFight).GetComponent<CharacterFightAI>();
        Transform tf = GameObject.Find(GameObjectName.FightNavMesh).transform;
        PlayerInitPosTrans = tf.Find(GameObjectName.PlayerPos);
        GetPositionsTrans(tf, "EnemyPos", ref enemyInitPosTrans);
        GetPositionsTrans(tf, "PlayerDieStartMovePath", ref playerDieStartMovePath);
        GetPositionsTrans(tf, "PlayerDieEndMovePath", ref playerDieEndMovePath);
        GetPositionsTrans(tf, "EnemyDieStartMovePath", ref enemyDieStartMovePath);
        GetPositionsTrans(tf, "EnemyDieEndMovePath", ref enemyDieEndMovePath);
    }  
    
    
    [Obsolete("用拓展 public static Transform[] GetChildrenDeep(this Transform t, string parentName,  out Transform[] children)\r\n")]
    private void GetPositionsTrans(Transform deepFindRoot,string rootTransName,ref Transform[] targetsTrans)
    {
        Transform rootTrans = deepFindRoot.FindChildDeep( rootTransName);
        targetsTrans = new Transform[rootTrans.childCount];
        for (int i = 0; i < targetsTrans.Length; i++)
        {
            targetsTrans[i] = rootTrans.GetChild(i);
        }
    }
    #endregion  





}
