using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：游戏入口实例，初始化并管理所有的管理者，提供mono方法
//***************************************** 

/// <summary>游戏入口实例，初始化并管理所有的管理者，提供mono方法</summary>
public class GameStartInstance : MonoBehaviour
{

    private List<ISingleton> singletonsList;
    //
    private StartArchitecture startArchitectureInstance;
    public bool startArchitecture;
    [Header("LoginScene中可以为空。FightNavMesh上的节点来赋值")]

    public FightLogicController fightLogicController;
    [SerializeField] UIMgr UIMgr;



    #region 单例
    private static GameStartInstance _instance;      
    public static GameStartInstance Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameStartInstance();
            }
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
    #endregion


    #region 生命


    private void Awake()
    {
        #region 这部分进入游戏才有的，但是进入游戏前调用到它。但是原版老师都混一起了
        ExtendResources.Init();
        startArchitecture = true;

        if (startArchitecture)
        {
            startArchitectureInstance = StartArchitecture.Instance;
            singletonsList = new List<ISingleton>()
            {
                AudioSourceManager.Instance.Init(),
            };
            startArchitectureInstance.SetGameArchitecture(new XYQArchitecture());
            //
            _instance = this;
            //
            UIMgr = GetComponentInChildren<UIMgr>();
            UIMgr.Init();
            //
            fightLogicController = gameObject
                .FindTop(GameObjectName.FightNavMesh)
                .GetComponent<FightLogicController>();
            //
            DontDestroyOnLoad(gameObject);
        }
        #endregion

    }

    void Update()
    {
        if (!startArchitecture)
        {
            return;
        }

        for (int i = 0; i < singletonsList.Count; i++)
        {
            singletonsList[i].Update();
        }
    }


    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    #endregion









}
