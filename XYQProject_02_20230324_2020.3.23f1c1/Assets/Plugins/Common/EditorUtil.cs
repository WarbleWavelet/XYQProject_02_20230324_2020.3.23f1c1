/****************************************************
    文件：EditorUtil.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/3 21:22:40
	功能：Unity编辑器
*****************************************************/

using UnityEditor;
using UnityEngine;

public static partial class EditorUtil
{
    public static void OpenInFolder(string folderPath)
    {
        Application.OpenURL("file:///" + folderPath);
    }




    /// <summary>Is editor currently in play mode?</summary>
    public static bool IsPlayMode()
    {
        return UnityEditor.EditorApplication.isPlaying;
    }


    /// <summary>MenuItem等进入PlayMode<，运行时随便调用退出PlayMode</summary>
    public static void SwitchPlayMode()
    {
        EditorApplication.isPlaying = !EditorApplication.isPlaying;
    }


}