/****************************************************
    文件：Test.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/9 20:9:32
	功能： 测试脚本
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Test : MonoBehaviour, IController
{
    #region 属性

    #endregion

    #region 生命

    /// <summary>首次载入</summary>
    void Awake()
    {

    }


    /// <summary>Go激活</summary>
    void OnEnable()
    {

    }

    /// <summary>首次载入且Go激活</summary>
    void Start()
    {
       // Test1();
    }




    /// <summary>固定更新</summary>
    void FixedUpdate()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  //快捷键，方便测试
        {
            EnterOrExitFightMode(true);
        }

        if (Input.GetKeyDown(KeyCode.R))  //快捷键，方便测试
        {
            EnterOrExitFightMode(false);
        }

        if (Input.GetKeyDown(KeyCode.T))  //快捷键，方便测试
        {
            this.GetSystem<IFightSystem>().PlayerAI.transform.localPosition = Vector3.zero;

            for (int i = 0; i <this.GetSystem<IFightSystem>().EnemyAIList.Count ; i++)
            {
                CharacterFightAI ai = this.GetSystem<IFightSystem>().EnemyAIList[i];
                ai.transform.localPosition = Vector3.zero;
                this.GetSystem<IFightSystem>().EnemyInitPosTrans[i] = ai.transform;
            }  
        }
        //TestUpdate1();




    }



    private void EnterOrExitFightMode(bool _bool)
    {
        this.GetSystem<ISceneSystem>().EnterOrExitFightMode(_bool);//SceneSystem不行
    }

    /// <summary>延迟更新。适用于跟随逻辑</summary>
    void LateUpdae()
    {

    }

    /// <summary> 组件重设为默认值时（只用于编辑状态）</summary>
    void Reset()
    {

    }


    /// <summary>当对象设置为不可用时</summary>
    void OnDisable()
    {

    }


    /// <summary>组件销毁时调用</summary>
    void OnDestroy()
    {

    }
    #endregion

    #region 系统

    #endregion

    #region 辅助


    private void TestUpdate1()
    {
        if (this.GetSystem<IFightSystem>().PlayerAI != null)
        {
            //print("initPos" + this.GetSystem<IFightSystem>().PlayerAI.initPos);
            Transform t = this.GetSystem<IFightSystem>().PlayerAI.transform;
            print("localPos" + t.localPosition);
           // print("destination" + this.GetSystem<IFightSystem>().PlayerAI.GetComponent<NavMeshAgent>().destination);
        }

        
    }

    /// <summary>测试Vector3拓展</summary>
    private void Test1()
    {
        Vector3 v = new Vector3(1f, 1f, 1f);

        print("v  " + v);
        v.SetX(999);
        print("v  X" + v);
        v.SetY(999);
        print("v  Y" + v);
        v.SetZ(999);
        print("v  Z" + v);
    }
    #endregion

}



