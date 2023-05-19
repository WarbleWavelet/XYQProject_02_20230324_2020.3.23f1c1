using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;
using System.Text.RegularExpressions;
//*****************************************
//创建人： Trigger 
//功能说明： 创建脚本窗口
//***************************************** 
public class CreateScriptWindow : EditorWindow
{
    const string EVENTTEMPLATE_PATH = "Assets/Editor/EventTemplateScript.txt";//模板路径 
    const string COMMANDTEMPLATE_PATH = "Assets/Editor/CommandTemplateScript.txt";//模板路径

    [MenuItem("Assets/Create/C# Event Script(Command)")]
    static void AssetsCreate()
    {
        CreateScriptWindow window = (CreateScriptWindow)GetWindow(typeof(CreateScriptWindow), false, "创建C#");
        window.Show(true);
    }
    string _scriptName;
    string _description;
    void OnGUI()
    {
        string selectDirPath = GetPath();
        //如果选中的是文件夹,则正常拼接新建脚本路径
        if (Directory.Exists(selectDirPath))
        {
            _scriptName = EditorGUILayout.TextField("脚本名:", _scriptName);
            string path = selectDirPath + "/" + _scriptName + ".cs";
            EditorGUILayout.LabelField("路径:", path);
            EditorGUILayout.Space();
            if (GUILayout.Button("创建事件", GUILayout.Height(40)))
            {
                //命名规则校验
                if (!CheckScriptName(_scriptName))
                {
                    ShowNotification(new GUIContent("请输入正确的脚本名!"));
                }
                //查重校验
                else if (CheckRepeat(selectDirPath))
                {
                    ShowNotification(new GUIContent("当前文件夹下已经有同名脚本!"));
                }
                //生成脚本
                else
                {
                    string content = File.ReadAllText(EVENTTEMPLATE_PATH);//从模板文件中读取内容
                    content = content.Replace("MyEvent", _scriptName); //替换脚本名
                    File.WriteAllText(path, content, Encoding.UTF8);//将修改后的内容写入新的脚本
                    AssetDatabase.Refresh();//马上刷新,方便在Project中直接看到新生成的脚本
                    ShowNotification(new GUIContent("Success!"));
                }
            }
            if (GUILayout.Button("创建命令", GUILayout.Height(40)))
            {
                //命名规则校验
                if (!CheckScriptName(_scriptName))
                {
                    ShowNotification(new GUIContent("请输入正确的脚本名!"));
                }
                //查重校验
                else if (CheckRepeat(selectDirPath))
                {
                    ShowNotification(new GUIContent("当前文件夹下已经有同名脚本!"));
                }
                //生成脚本
                else
                {
                    string content = File.ReadAllText(COMMANDTEMPLATE_PATH);//从模板文件中读取内容
                    content = content.Replace("MyCommand", _scriptName); //替换脚本名
                    File.WriteAllText(path, content, Encoding.UTF8);//将修改后的内容写入新的脚本
                    AssetDatabase.Refresh();//马上刷新,方便在Project中直接看到新生成的脚本
                    ShowNotification(new GUIContent("Success!"));
                }
            }
        }
        else
        {
            EditorGUILayout.LabelField("请在Project面板中选择将要放置脚本的文件夹.");
        }
    }

    /// <summary>
    /// 校验脚本名(只能包含数字,字母,下划线且必须以字母或下划线开头)
    /// </summary>
    /// <param name="scriptName"></param>
    /// <returns></returns>
    bool CheckScriptName(string scriptName)
    {
        Regex regex = new Regex("^[a-zA-Z_][a-zA-Z0-9_]*$");
        return regex.IsMatch(scriptName);
    }

    /// <summary>
    /// 当前文件夹下脚本名重复效验
    /// </summary>
    /// <param name="selectDirPath"></param>
    /// <returns></returns>
    bool CheckRepeat(string selectDirPath)
    {
        DirectoryInfo dir = new DirectoryInfo(selectDirPath);
        FileInfo[] files = dir.GetFiles();
        string scriptName = _scriptName + ".cs";
        for (int i = 0; i < files.Length; i++)
        {
            if (files[i].Name == scriptName)
            {
                return true;
            }
        }

        return false;

    }

    //鼠标选中发生变化时调用
    private void OnSelectionChange()
    {
        //重绘窗口,刷新显示
        Repaint();
    }
    /// <summary>
    /// 获取路径,如果选中文件夹以选中文件夹为主,没有选中文件夹以鼠标右键点击所在文件夹为主
    /// </summary>
    /// <returns></returns>
    private string GetPath()
    {
        string assetPath = null;
        if (assetPath == null || assetPath == "")
            assetPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
        return assetPath;
    }
}

