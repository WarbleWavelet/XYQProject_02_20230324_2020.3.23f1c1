/****************************************************
    文件：ExtendComponent.Transform.RectTransform.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/4 16:2:51
	功能：
*****************************************************/

using UnityEngine;

public static partial class ExtendComponent
{
    #region RectTransform

    public static RectTransform Rect(this Transform trans)
    {
        return trans.GetComponent<RectTransform>();
    }

    public static RectTransform Rect(this GameObject go)
    {
        return go.GetComponent<RectTransform>();
    }
    public static void Reset(this RectTransform rect)
    {
        rect.localPosition = Vector3.zero;
        rect.anchoredPosition = Vector3.zero;
        rect.sizeDelta = Vector3.zero;
    }
    #endregion
}