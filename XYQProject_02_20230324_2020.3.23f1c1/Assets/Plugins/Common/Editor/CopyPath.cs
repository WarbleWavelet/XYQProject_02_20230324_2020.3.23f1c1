/****************************************************
    文件：CopyPath.cs
	作者：lenovo
    邮箱: 
    日期：2022/9/17 17:33:13
	功能：
*****************************************************/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;



public class FindPath
{

#if UNITY_EDITOR
public static List<string> filelist = new List<string>();
    public static List<string> deallist = new List<string>();
    public static string filepath;

    // Use this for initialization
   [MenuItem("GameObject/Copy Path %1", priority = 0)]
    public static void GetPath()
    {
        clearmemory();
        recursiveFind(Selection.activeGameObject.gameObject);

        printinScreen();
        clearmemory();
    }

    public static void recursiveFind(GameObject go)
    {
        if (go != null)
        {
            filelist.Add(go.name);
            if (go.transform.parent != null)
            {
                recursiveFind(go.transform.parent.gameObject);
            }
        }
    }


    public static void clearmemory()
    {
        filelist.Clear();
        deallist.Clear();
    }

    public static void printinScreen()
    {

        for (int i = filelist.Count - 1; i >= 0; i--)
        {
            string str = filelist[i];
            if (i != 0)
            {
                str = str + "/";
            }
            deallist.Add(str);
        }
        string showstr = "";
        foreach (var list in deallist)
        {
            showstr += list;

        }
        Debug.Log(showstr);

        //text copy to shear plate
        TextEditor te = new TextEditor();
        te.text = showstr;
        te.SelectAll();
        te.Copy();


    }
#endif

    

}

