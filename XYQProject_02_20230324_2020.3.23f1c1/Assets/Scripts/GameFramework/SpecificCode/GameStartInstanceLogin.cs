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
public class GameStartInstanceLogin : MonoBehaviour
{


    [SerializeField] LoginScene LoginScene;

    #region 单例
    private static GameStartInstanceLogin _instance;      
    public static GameStartInstanceLogin Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameStartInstanceLogin();
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
      //  _instance = this;
        LoginScene = GetComponentInChildren<LoginScene>();
        LoginScene.Init();
    }

    void Update()
    {

    }


    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    #endregion









}
