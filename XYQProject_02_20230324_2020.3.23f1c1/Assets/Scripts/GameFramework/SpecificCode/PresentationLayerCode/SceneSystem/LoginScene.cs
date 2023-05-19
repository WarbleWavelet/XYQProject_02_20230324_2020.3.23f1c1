using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>������Ϸ����ı����ֻ�������ʦͽ���ˣ�</summary>

public class LoginScene : MonoBehaviour
{
    /// <summary>es������</summary>
    public Transform[] bgTranses;
    /// <summary>es������</summary>
    public Vector3[] targetPoses;
    public ExtendTweenMethods.Tween[] tweens;

    /// <summary>DoMove �õ� GameStartInstance��MonoBehaviour��StartCoroutine������˳�򿿺�</summary>
    public void Init()
    {

        InitBgTranses();
        InitTargetPoses();
        tweens = new ExtendTweenMethods.Tween[2];
        tweens[0]= bgTranses[0].DoMove(this,targetPoses[1],50,100);
        tweens[1] = bgTranses[1].DoMove(this, targetPoses[1],25, 1).SetOnComplete(() =>        
        {
            //���������ͼһֱ������ȥ
            bgTranses[1].position = targetPoses[0];
            bgTranses[1].DoMove(this, targetPoses[1], 50, 100);
        });
        //
        InitButtons();
    }




    #region ����

    private void InitButtons()
    {
        Transform canvasTrans = transform.FindTop("Canvas");
        Button EnterBtn = canvasTrans.GetButtonDeep("EnterBtn", LoadGame);
        Button ExitBtn = canvasTrans.GetButtonDeep("ExitBtn", ExitGame);
    }


    void InitBgTranses()
    {
        Transform bgTrans = transform.FindTop( GameObjectName.BgTrans );
        bgTranses = new Transform[4];//ʵ�ʹ�5�������һ������գ������ȥ
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
