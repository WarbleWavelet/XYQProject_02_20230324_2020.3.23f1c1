/****************************************************
    文件：UIMgr.cs
	作者：lenovo
    邮箱: 
    日期：2023/3/27 14:19:2
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 

public class UIMgr : MonoBehaviour
{
    #region 字段

    CameraCapture cameraCapture;
    FightUIManager fightUIManager;
    ItemUIManager itemUIManager;
    SkillUIManager skillUIManager;



    #endregion

    #region 生命

    /// <summary>需要StartArchitecture.Instance;</summary>
    public void Init()
    {
      //  cameraCapture = transform.GetComponentDeep<CameraCapture>("RawImage_CaptureCamera");
        cameraCapture = transform.FindChildDeep("RawImage_CaptureCamera").GetComponent<CameraCapture>();
        fightUIManager=transform.FindChildDeep("Emp_FightUI").GetComponent<FightUIManager>();
        itemUIManager=transform.FindChildDeep("Emp_ItemUI").GetComponent<ItemUIManager>();
        skillUIManager=transform.FindChildDeep("Emp_SkillUI").GetComponent<SkillUIManager>();

        cameraCapture.Init();
        fightUIManager.Init();
        itemUIManager.Init();
        skillUIManager.Init();
    }


    #endregion 
}
