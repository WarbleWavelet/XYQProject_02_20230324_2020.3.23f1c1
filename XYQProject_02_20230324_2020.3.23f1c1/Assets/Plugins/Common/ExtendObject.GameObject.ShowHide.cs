/****************************************************
    文件：ExtendComponent.ShowHide.cs
	作者：lenovo
    邮箱: 
    日期：2023/4/22 15:32:47
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 

public static partial class ExtendObject 
{

	/// <summary>
	/// 重名只能用路径区别
	/// 不激活找不到
	/// </summary>	
	public static GameObject FindExtensions(this GameObject gameObject,string tag)
	{ 
		 return GameObject.Find(tag);
	}

    /// <summary>
    /// 不激活找不到
    /// </summary>	
    public static GameObject FindGameObjectWithTagExtensions(this GameObject gameObject, string tag)
    {
        return GameObject.FindGameObjectWithTag(tag);
    }

    #region Show、Hide



    public static void Show(this GameObject gameObject)
	{
		gameObject.SetActive(true);
	}

	public static void Hide(this GameObject gameObject)
	{
		gameObject.SetActive(false);
	}

	public static void Show(this Transform transform)
	{
		transform.gameObject.SetActive(true);
	}

	public static void Hide(this Transform transform)
	{
		transform.gameObject.SetActive(false);
	}

	public static void Show(this MonoBehaviour monoBehaviour)
	{
		monoBehaviour.gameObject.SetActive(true);
	}

	public static void Hide(this MonoBehaviour monoBehaviour)
	{
		monoBehaviour.gameObject.SetActive(false);
	}
	public static void Show(this Behaviour behaviour)
	{
		behaviour.gameObject.SetActive(true);
	}

	public static void Hide(this Behaviour behaviour)
	{
		behaviour.gameObject.SetActive(false);
	}
    #endregion


    #region SetActive

    public static void SetActive(this Transform trans, bool state)
    {
        trans.gameObject.SetActive(state);
    }

    public static void SetActive(this Behaviour behaviour, bool state)
    {
        behaviour.gameObject.SetActive(state);
    }

    public static void SetActive(this MonoBehaviour monoBehaviour, bool state)
    {
        monoBehaviour.gameObject.SetActive(state);
    }
    #endregion


}



