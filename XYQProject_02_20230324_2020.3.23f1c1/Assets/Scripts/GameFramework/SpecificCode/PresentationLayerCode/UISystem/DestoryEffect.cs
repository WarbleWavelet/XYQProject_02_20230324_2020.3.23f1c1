using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//*****************************************
//创建人： Trigger 
//功能说明：销毁特效
//***************************************** 

/// <summary>销毁特效</summary>
public class DestoryEffect : MonoBehaviour
{
    public float destoryTime;

    void Start()
    {
        Destroy(gameObject,destoryTime);
    }

    void Update()
    {

    } 
}
