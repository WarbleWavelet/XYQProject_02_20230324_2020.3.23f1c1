/****************************************************
  文件：ResourceEditor.ResourceCollection.cs
  作者：lenovo
  邮箱: 
  日期：2022/11/20 4:1:12
  功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.ResourceTools
{
    internal sealed partial class ResourceEditor : EditorWindow
    {
        private sealed class Selection_ActiveObject
        {
            [MenuItem("Game Framework/Resource Tools/定位到ResourceEditor.cs", false, 41)]
            private static void Active()
            {
                Common.Selection_ActiveObject("Assets/Plugins/UnityGameFramework/Scripts/Editor/ResourceEditor/ResourceEditor.cs");
            }

            [MenuItem("Game Framework/Resource Tools/定位到ResourceCollection.xml", false, 41)]
            private static void Active1()
            {
                Common.Selection_ActiveObject("Assets/GameMain/Configs/ResourceCollection.xml");
            }
        }
       
    }

}
