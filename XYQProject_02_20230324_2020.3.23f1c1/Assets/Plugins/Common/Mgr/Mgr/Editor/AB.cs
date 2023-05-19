/****************************************************
    文件：AB.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/6 9:41:45
	功能：AB包
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;
 

public static class AB 
{

    /// <summary>打包</summary>
    public static void Build(
        string outputPath
    )
    {
        BuildPipeline.BuildAssetBundles
        (
            outputPath,
            assetBundleOptions:BuildAssetBundleOptions.ChunkBasedCompression,
            targetPlatform: EditorUserBuildSettings.activeBuildTarget
        );
        AssetDatabase.Refresh();
    }

}




