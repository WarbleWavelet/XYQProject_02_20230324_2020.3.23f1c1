/************************************************************
    文件: ScriptsInfoRecoder.cs
	作者: Plane
    邮箱: 1785275942@qq.com
    日期: 2013/10/13 12:01
	功能: 记录脚本信息
*************************************************************/

using System;
using System.IO;


#if UNITY_EDITOR
public class ScriptsInfoRecoder : UnityEditor.AssetModificationProcessor {
    private static void OnWillCreateAsset(string path) {
        path = path.Replace(".meta", "");
        if (path.EndsWith(".cs")) {
            string str = File.ReadAllText(path);
            str = str.Replace("#CreateAuthor#", Environment.UserName).Replace(
                              "#CreateTime#", string.Concat(DateTime.Now.Year, "/", DateTime.Now.Month, "/",
                                DateTime.Now.Day, " ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second));
            File.WriteAllText(path, str);
        }
    }
}

/**
 *  D:\Program Files\Unity\Hub\Editor\2017.3.0f3\Editor\Data\Resources\ScriptTemplates

/****************************************************
  文件：#SCRIPTNAME#.cs
  作者：#CreateAuthor#
  邮箱: 
  日期：#CreateTime#
  功能：
*****************************************************/
//**/
#endif

