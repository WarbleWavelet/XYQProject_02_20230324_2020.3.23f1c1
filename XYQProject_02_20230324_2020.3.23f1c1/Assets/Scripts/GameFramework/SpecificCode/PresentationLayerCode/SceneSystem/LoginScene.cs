using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>进入游戏界面的背景轮换（不是师徒四人）</summary>

public class LoginScene : MonoBehaviour
{
    /// <summary>es当复数</summary>
    public Transform[] bgTranses;
    /// <summary>es当复数</summary>
    public Vector3[] targetPoses;
    public ExtendTweenMethods.Tween[] tweens;

    /// <summary>DoMove 用到 GameStartInstance的MonoBehaviour的StartCoroutine，所以顺序靠后</summary>
    public void Init()
    {

        InitBgTranses();
        InitTargetPoses();
        tweens = new ExtendTweenMethods.Tween[2];
        tweens[0]= bgTranses[0].DoMove(this,targetPoses[1],50,100);
        tweens[1] = bgTranses[1].DoMove(this, targetPoses[1],25, 1).SetOnComplete(() =>        
        {
            //最左边两张图一直换来换去
            bgTranses[1].position = targetPoses[0];
            bgTranses[1].DoMove(this, targetPoses[1], 50, 100);
        });
        //
        InitButtons();
    }




    #region 辅助

    private void InitButtons()
    {
        Transform canvasTrans = transform.FindTop("Canvas");
        Button EnterBtn = canvasTrans.GetButtonDeep("EnterBtn", LoadGame);
        Button ExitBtn = canvasTrans.GetButtonDeep("ExitBtn", ExitGame);
    }


    void InitBgTranses()
    {
        Transform bgTrans = transform.FindTop( GameObjectName.BgTrans );
        bgTranses = new Transform[4];//实际挂5个，最后一个是天空，不算进去
        for (int i = 0; i < bgTranses.Length; i++)
        {
            bgTranses[i] = bgTrans.GetChild(i);
        }    
    }


    void InitTargetPoses()
    { 
        targetPoses = new Vector3[bgTranses.Length];
        for (int i = 0; i < bgTranses.Length-1; i++)
        {
            targetPoses[i] = bgTranses[i + 1].position;
        }
        targetPoses[0] = bgTranses[0].position;    
    }



    public void LoadGame()
    {
        for (int i = 0; i < tweens.Length; i++)
        {
            tweens[i].Kill();
        }
        SceneManager.LoadScene(1);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion

}
