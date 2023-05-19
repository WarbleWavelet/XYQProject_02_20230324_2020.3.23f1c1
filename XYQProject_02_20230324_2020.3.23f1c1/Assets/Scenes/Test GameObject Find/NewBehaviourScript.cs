/****************************************************
    文件：NewBehaviourScript.cs
	作者：lenovo
    邮箱: 
    日期：2023/4/6 13:45:50
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Demo202304061345
{
    public class NewBehaviourScript : MonoBehaviour
    {
        public GameObject A;
        public GameObject B;


        void Start()
        {
            A = GameObject.Find("A");
            B = GameObject.Find("B");
            A = gameObject.FindGlobal("A");
        }
    }
}