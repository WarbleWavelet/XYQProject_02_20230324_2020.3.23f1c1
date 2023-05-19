/****************************************************
    文件：ScreenUtil.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/3 21:26:36
	功能：
*****************************************************/

using UnityEngine;

public static partial class ScreenUtil
{
  public  static void MenuClicked()
    {
        Debug.Log( IsPadResolution() ? "是 Pad" : "不是 Pad");
        Debug.Log( IsPhoneResolution() ? "是 Phone" : "不是 Phone");
        Debug.Log( IsPhone15Resolution() ? "是 4s" : "不是 4s");
        Debug.Log( IsiPhoneXResolution() ? "是 iphonex" : "不是 iphonex");
    }

    public static float GetAspectRatio()
    {
        var isLandscape = Screen.width > Screen.height;
        return isLandscape ? (float)Screen.width / Screen.height : (float)Screen.height / Screen.width;
    }

    public static bool IsPadResolution()
    {
        return InAspectRange(4.0f / 3);
    }

    public static bool IsPhoneResolution()
    {
        return InAspectRange(16.0f / 9);
    }

    public static bool IsPhone15Resolution()
    {
        return InAspectRange(3.0f / 2);
    }

    public static bool IsiPhoneXResolution()
    {
        return InAspectRange(2436.0f / 1125);
    }

    public static bool InAspectRange(float dstAspectRatio)
    {
        var aspect = GetAspectRatio();
        return aspect > (dstAspectRatio - 0.05) && aspect < (dstAspectRatio + 0.05);
    }
}