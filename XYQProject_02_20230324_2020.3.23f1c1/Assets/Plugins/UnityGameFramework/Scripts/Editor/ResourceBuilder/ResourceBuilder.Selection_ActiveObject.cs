/****************************************************
  文件：ResourceBuilder1.cs
  作者：lenovo
  邮箱: 
  日期：2022/11/20 5:55:23
  功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.ResourceTools
{
    internal sealed partial class ResourceBuilder : EditorWindow
    {
        private sealed class Selection_ActiveObject
        {

            [MenuItem("Game Framework/Resource Tools/定位到ResourceBuilder.cs", false, 40)]
            private static void Active()
            {
                Common.Selection_ActiveObject("Assets/Plugins/UnityGameFramework/Scripts/Editor/ResourceBuilder/ResourceBuilder.cs");
            }

            [MenuItem("Game Framework/Resource Tools/定位到VersionInfo.cs", false, 40)]
            private static void Active1()
            {
                Common.Selection_ActiveObject("Assets/GameMain/Scripts/Definition/DataStruct/VersionInfo.cs");
            }

            [MenuItem("Game Framework/Resource Tools/定位到VersionInfo.txt", false, 40)]
            private static void Active2()
            {
                Common.Selection_ActiveObject("Assets/GameMain/Configs/BuildInfo.txt");
            }
        }
    }
}