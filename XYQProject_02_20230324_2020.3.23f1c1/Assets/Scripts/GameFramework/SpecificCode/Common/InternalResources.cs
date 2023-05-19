/****************************************************

	文件：
	作者：WWS
	日期：2022/10/31 15:25:09
	功能：追要对Unity的Componetn组件的拓展方法(this大法)
        静态类不能有实例构造器。
        静态类不能有任何实例成员。
        静态类不能使用abstract或sealed修饰符。 
        静态类默认继承自System.Object根类，不能显式指定任何其他基类。

        Resources是sealed类

 *****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Object= UnityEngine.Object;



/// <summary>
/// 有的只属于这个工程好用，所以partial分权 .
/// 但是分不了，命名空间不同，只认最近的
/// </summary>
public static  partial   class InternalResources
{

  

    public static GameObject GetSkillEffect(SkillInfo skillInfo) 
    {
        return ExtendResources.Get<GameObject>(
            string.Format("Prefabs/Skills/{0}/{1}" , skillInfo.sectName, skillInfo.pathName)
        ) ;

    }

    public static GameObject GetRecoverEffect(string recoverEffectName)
    {
        return ExtendResources.Get<GameObject>("Prefabs/" + recoverEffectName);

    }



    public static AudioClip GetAudioClip(string soundName)
    {

        AudioClip ac = ExtendResources.Get<AudioClip>( "AudioClips/"+soundName);
        if (ac)
        {
            return ac;
        }

        Debug.Log("没有路径为：" + "AudioClips/" + soundName + "音频资源");
        return null;
    }

}
