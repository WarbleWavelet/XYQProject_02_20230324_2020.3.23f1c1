/****************************************************

	文件：
	作者：WWS
	日期：2022/10/31 15:25:09
	功能：追要对Unity的Componetn组件的拓展方法(this大法)


*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;




public static class ExtendReflection
{


	/// <summary>
	/// 得到在类前面用以下的方式用Type的所有类，达到预制体路径与脚本的绑定<para />
	/// [BindPrefab(DefinePath_AirCombat.PREFAB_DIALOG,Constants_AirCombat.BIND_PREFAB_PRIORITY_VIEW)]
	/// </summary>
	public static Type[] GetTypes(this Type type)//type=typeof(T)
    {
		Assembly assembly = Assembly.GetAssembly(type);
		Type[] types= assembly.GetExportedTypes();
		return types;
    }
}
