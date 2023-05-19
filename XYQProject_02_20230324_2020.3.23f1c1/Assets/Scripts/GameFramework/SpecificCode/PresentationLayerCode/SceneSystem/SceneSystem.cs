using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：场景系统
//***************************************** 
public class SceneSystem : ISceneSystem
{


    #region 字属
    /// <summary>世界场景</summary>
    public GameObject NormalModeGo { private set; get; }


    /// <summary>战斗场景</summary>
    public GameObject FightModeGo { set; get; }

    /// <summary>世界场景中的玩家</summary>
    public CharacterNormalAI PlayerNormalAI { private set; get; }

    public float EnterFightTimer { set; get; }

    public bool CanEnterFight { set; get; }

    public SceneSystem() { Init(); }
    #endregion




    #region 生命


    public void Init()
    {
        EnterFightTimer = Time.time;
        CanEnterFight = true;
        EnterCurScene();
        PlayMusic(ResourcesName.AudioClip.DongHaiWan);
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>时间概率遇敌</summary>
    public void JudgeEnterTheFight()
    {

        //
        if (Time.time - EnterFightTimer >= 8)
        {
            if (Random.Range(0, 5) >= 1)
            {
                EnterOrExitFightMode(true); //进入战斗
            }
            else
            {
                SetEnterFightState(true);//重新计时
            }
        }
    }
    #endregion




    #region 辅助

    public void EnterCurScene()
    {
        GameObject gameStart = GameObject.Find(GameObjectName.GameStart);//随便找个及节点
        NormalModeGo = gameStart.FindTop(GameObjectName.NormalNavMesh);//初始激活，能找到
        FightModeGo = gameStart.FindTop(GameObjectName.FightNavMesh);

        PlayerNormalAI = NormalModeGo.GetComponentInChildren<CharacterNormalAI>();

    }


    public void EnterOrExitFightMode(bool enter)
    {
        if (enter)
        {
            this.SendEvent<CaptrueCameraAndSetMaterialValueEvent>();
            PlayMusic( ResourcesName.AudioClip.FightBG + Random.Range(1, 4));
        }
        else
        {
            PlayMusic(ResourcesName.AudioClip.DongHaiWan);
        }
        NormalModeGo.SetActive(!enter);
        FightModeGo.SetActive(enter);
        SetEnterFightState(!enter);
        EnterFightTimer = Time.time;
        CanEnterFight = !enter;
        //
        // FightModePosFunc01();//二选一种方式
        FightModePosFunc02();
        //
        this.SendEvent<OpenOrCloseFightCommandPanelEvent>(enter);
    }

    private void FightModePosFunc02()
    {
        Vector3 pos = Camera.main.transform.position;
        FightModeGo.transform.position = pos.SetZ(0f);
    }

    private void FightModePosFunc01()
    {
        Vector3 pos = Camera.main.transform.position;
        pos.z = 0;
        FightModeGo.transform.position = pos;
    }




    /// <summary>
    /// 设置是否可以进入战斗的状态
    /// </summary>
    /// <param name="state"></param>
    public void SetEnterFightState(bool state)
    {
        CanEnterFight = state;
        EnterFightTimer = Time.time;
    }





    void PlayMusic(string audioName)
    {
        AudioSourceManager.Instance.PlayMusic(audioName);
    }
    #endregion





}
