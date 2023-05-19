/****************************************************
    文件：GetFightNavMeshGo.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/19 5:36:53
	功能：获得这个初始不激活的根节点FightNavMesh
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 

public class SetFightNavMeshGoCommand : ICommand
{
    public void Execute(object obj)
    {
        GameObject go = obj as GameObject;
       // this.GetSystem<ISceneSystem>().FightModeGo = go;
    }
}




