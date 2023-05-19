/****************************************************
    文件：LevelMgr.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/4 2:16:55
	功能：
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMgr : MonoBehaviour 
{

    #region 字属
    private static List<string> mLevelNames;
    public static int Index { get; set; }
    #endregion




    #region 生命

    /// <summary>初始场景名</summary>
    public static void Init(List<string> levelNames)
    {
        mLevelNames = levelNames;
        Index = 0;
    }
    #endregion




    #region 辅助

    /// <summary>加载内部的索引Index的Scene</summary>
    public static void LoadCurrent()
    {
        SceneManager.LoadScene(mLevelNames[Index]);
    }


    /// <summary>索引Index++，加载Scene</summary>
    public static void LoadNext()
    {
        Index++;

        if (Index >= mLevelNames.Count)
        {
            Index = 0;
        }

        SceneManager.LoadScene(mLevelNames[Index]);
    }
    #endregion

}