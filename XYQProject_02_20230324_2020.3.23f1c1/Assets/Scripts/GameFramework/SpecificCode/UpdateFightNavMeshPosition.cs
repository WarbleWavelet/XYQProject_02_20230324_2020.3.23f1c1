/****************************************************
    文件：UpdateFightNavMeshPosition.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/9 21:5:35
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class UpdateFightNavMeshPosition : MonoBehaviour, IController
{
    #region 属性


    Vector3 initPos;
    CharacterNormalAI playerNormalAI;
    #endregion

    #region 生命


    /// <summary>首次载入且Go激活</summary>
    void Start()
    {
         initPos = transform.position;
        playerNormalAI = transform.FindTop(GameObjectName.NormalNavMesh).GetComponent<CharacterNormalAI>();

    }

    /// <summary>固定更新</summary>


    void Update()
    {
       // transform.position = initPos + playerNormalAI.offsetVec;
    }

    #endregion  

    #region 辅助

    #endregion
}



