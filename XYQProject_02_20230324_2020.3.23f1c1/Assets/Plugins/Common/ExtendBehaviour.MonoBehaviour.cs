/****************************************************
    文件：MonoBehaviourUtil.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/3 21:37:46
	功能：
*****************************************************/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public static partial class ExtendBehaviour
{
    #region Delay
    /// <summary> seconds 时间后执行 onFinished </summary>
    public static void Delay(this MonoBehaviour monoBehaviour, float seconds, Action onFinished)
    {
        monoBehaviour.StartCoroutine(DelayCoroutine(seconds, onFinished));
    }

    private static IEnumerator DelayCoroutine( float seconds, Action onFinished)
    {
        yield return new WaitForSeconds(seconds);
        onFinished();
    }


    /// <summary>假设这里的脚本是B，A来调用B时，action是应该在A还是B</summary>
    public static void Delay(this MonoBehaviour monoBehaviour, System.Action action, float seconds)
    {

        //  string actionName = action.ToString() ;//这种直接给类型System.Action
        string actionName = action.Method.ToString() ;  //Void XXX()
        actionName = actionName.Substring(5) ; //XXX()
        actionName = actionName.Replace("()","") ; //XXX

        //Debug.LogFormat("actionName=={0}", actionName);
        try
        {
             monoBehaviour.Invoke( actionName, seconds);
        }
        catch (Exception)   
        {
            throw new System.Exception("Delay异常");
        }
      
    }
    #endregion
}