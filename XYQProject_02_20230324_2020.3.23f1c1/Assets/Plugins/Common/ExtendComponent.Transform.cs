/****************************************************
    文件：ExtendComponent.Transform.cs
	作者：lenovo
    邮箱: 
    日期：2023/4/22 15:36:3
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 

public static partial class ExtendComponent
{


    #region Identity


    public static void Identity(this MonoBehaviour monoBehaviour)
	{
		monoBehaviour.transform.Identity();
	}

	public static void Identity(this Transform transform)
	{
		transform.localPosition = Vector3.zero;
		transform.localScale = Vector3.one;
		transform.localRotation = Quaternion.identity;
	}
    #endregion




    #region SetLocal


    public static void SetLocalPosX(this Transform transform, float x)
	{
		var localPos = transform.localPosition;
		localPos.x = x;
		transform.localPosition = localPos;
	}

	public static void SetLocalPosY(this Transform transform, float y)
	{
		var localPos = transform.localPosition;
		localPos.y = y;
		transform.localPosition = localPos;
	}

	public static void SetLocalPosZ(this Transform transform, float z)
	{
		var localPos = transform.localPosition;
		localPos.z = z;
		transform.localPosition = localPos;
	}

	public static void SetLocalPosXY(this Transform transform, float x, float y)
	{
		var localPos = transform.localPosition;
		localPos.x = x;
		localPos.y = y;
		transform.localPosition = localPos;
	}

	public static void SetLocalPosXZ(this Transform transform, float x, float z)
	{
		var localPos = transform.localPosition;
		localPos.x = x;
		localPos.z = z;
		transform.localPosition = localPos;
	}

	public static void SetLocalPosYZ(this Transform transform, float y, float z)
	{
		var localPos = transform.localPosition;
		localPos.y = y;
		localPos.z = z;
		transform.localPosition = transform.localPosition;
	}
    #endregion


    public static void AddChild(this Transform parentTrans, Transform childTrans)
    {
        childTrans.SetParent(parentTrans);
    }

    #region Transform


    /// <summary>
    /// 不管激不激活都能找到
    /// 多谢这个主要为了注释，防止遗忘
    /// </summary>
    public static Transform FindExtensions(this Transform t, string tarPath)
    {
        return t.Find(tarPath);
    }


    /// <summary>
    /// 场景中根节点
    /// 不激活也可以找到</summary>
    public static Transform FindTop(this Transform t, string tarName)
    {
        GameObject[] gos = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject go in gos)
        {
            if (go.name == tarName)
            {
                return go.transform;
            }
        }
        return null;
    }

    public static void SetActive(this Transform t, bool state)
    {
        if (t.gameObject == null)
        {
            Debug.LogErrorFormat("{0}未找到GameObject组件", t.name);
            return;
        }
        t.gameObject.SetActive(state);
    }

    /// <summary>
    /// 找到 自身 下的 所有子节点  children
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="children"></param>
    /// <returns></returns>
    public static Transform[] GetChildren(this Transform parent, out Transform[] children)
    {

        children = new Transform[parent.childCount];
        for (int i = 0; i < parent.childCount; i++)
        {
            children[i] = parent.GetChild(i);
        }

        return children;
    }


   



    public static List<GameObject> GetChildrenLst(this GameObject go)
    {
        Transform parent = go.transform;
        if (parent.childCount <= 0)
        {
            Debug.LogError("没有子节点");
            return null;
        }

        List<GameObject> lst = new List<GameObject>();
        for (int i = 0; i < parent.childCount; i++)
        {
            lst.Add(parent.GetChild(i).gameObject);
        }

        return lst;
    }

    public static List<Transform> GetChildrenLst(this Transform parent)
    {
        if (parent.childCount <= 0)
        {
            Debug.LogError("没有子节点");
            return null;
        }

        List<Transform> lst = new List<Transform>();
        for (int i = 0; i < parent.childCount; i++)
        {
            lst.Add(parent.GetChild(i));
        }

        return lst;
    }


    /// <summary>
    ///  找到 自身 的 叫 parentName的子节点 下的所有子节点 children 
    /// </summary>
    /// <param name="t"></param>
    /// <param name="parentName"></param>
    /// <param name="children"></param>
    /// <returns></returns>
    public static Transform[] GetChildrenDeep(this Transform t, string parentName, out Transform[] children)
    {
        Transform parent = t.FindChildDeep(parentName);
        children = new Transform[parent.childCount];
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = parent.GetChild(i);
        }

        return children;
    }


    public static T AddComponent<T>(this Transform t, string path) where T : Component
    {
        return t.Find(path).gameObject.AddComponent<T>();
    }

    public static void Reset(this Transform t)
    {
        t.localPosition = Vector3.zero;
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
    }

    public static Transform FindOrNew(this Transform t, string path)
    {
        Transform tar = t.Find(path);
        if (tar == null)
        {
            GameObject go = new GameObject();
            go.name = path;
            go.transform.Reset();


            return go.transform;
        }

        return null;
    }


    /// <summary>
    /// 深度查找子对象transform引用
    /// </summary>
    /// <param name="root">父对象</param>
    /// <param name="childName">具体查找的子对象名称</param>
    /// <returns></returns>
    public static Transform FindChildDeep(this Transform root, string childName)
    {
        Transform result = null;
        result = root.Find(childName);
        if (!result)
        {
            foreach (Transform item in root)
            {
                result = FindChildDeep(item, childName);
                if (result != null)
                {
                    return result;
                }
            }
        }
        return result;
    }

    public static GameObject FindChildDeep(this GameObject go, string childName)
    {
        Transform result = null;
        Transform root = go.transform;
        result = root.Find(childName);
        if (!result)
        {
            foreach (Transform item in root)
            {
                result = FindChildDeep(item, childName);
                if (result != null)
                {
                    return result.gameObject;
                }
            }
        }
        return result.gameObject;
    }
    #endregion


}



