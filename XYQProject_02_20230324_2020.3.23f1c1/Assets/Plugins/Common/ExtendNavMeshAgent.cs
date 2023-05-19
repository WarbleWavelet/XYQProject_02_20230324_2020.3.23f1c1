/****************************************************
    文件：ExtendNavMeshAgent.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/16 10:43:52
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public static    class ExtendNavMeshAgent 
{

    /// <summary>用来查引用的。Move被用掉了</summary>
    public  static void Translate(this NavMeshAgent navMeshAgent, Vector3 v)
    {
        navMeshAgent.SetDestination(v);
    }

    public static void Translate(this NavMeshAgent navMeshAgent, Transform t)
    {
        navMeshAgent.SetDestination(t.position);
    }

}




