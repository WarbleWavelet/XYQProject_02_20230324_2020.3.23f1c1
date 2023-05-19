/****************************************************
    文件：EditorUtil.Exporter.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/4 22:19:20
	功能：
*****************************************************/

using System.IO;
using System;
using UnityEditor;
using UnityEngine;

public static partial class EditorUtil
{
#if UNITY_EDITOR
    public static void ExportPackage(string assetPathName, string fileName)
    {
        AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
    }

    public static void CallMenuItem(string menuName)
    {
        EditorApplication.ExecuteMenuItem(menuName);
    }
#endif


    private static string GeneratePackageName()
    {
        return "QFramework_" + DateTime.Now.ToString("yyyyMMddHHMM");///注意年小写的yyyy
    }

    [MenuItem("QFramework/Framework/Editor/导出 UnityPackage（自定义） %e", false, 1)]
    static void MenuClicked()
    {
        EditorUtil.ExportPackage("Assets/QFramework", EditorUtil.GeneratePackageName() + ".unitypackage");
        EditorUtil.OpenInFolder(Path.Combine(Application.dataPath, "../"));
    }
}