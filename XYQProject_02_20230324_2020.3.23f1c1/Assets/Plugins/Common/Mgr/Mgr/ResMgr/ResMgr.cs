/****************************************************
    文件：ResMgr.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/5 0:22:2
	功能：
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
 

    public class ResMgr : MonoSingleton<ResMgr>
    {

    #region 字属构造



    public List<Res> SharedLoadedReses = new List<Res>();

#if UNITY_EDITOR
        private const string kSimulationMode = "simulation mode";

        private static int mSimulationMode = -1;
        public static bool SimulationMode
        {
            get
            {
                if (mSimulationMode == -1)
                {
                    mSimulationMode = UnityEditor.EditorPrefs.GetInt(kSimulationMode, 1);
                }

                return mSimulationMode != 0;
            }
            set
            {
                mSimulationMode = value ? 1 : 0;
                UnityEditor.EditorPrefs.SetInt(kSimulationMode, mSimulationMode);
            }
        }
#endif

        public static bool IsSimulationModeLogic
        {
            get
            {
#if UNITY_EDITOR
                return SimulationMode;
#endif
                return false;
            }
        }



    #endregion


#if UNITY_EDITOR
        private void OnGUI()
        {
            if (Input.GetKey(KeyCode.F1))
            {
                GUILayout.BeginVertical("box");

                SharedLoadedReses.ForEach(loadedRes =>
                {
                    GUILayout.Label(string.Format("Name:{0} RefCount:{1} State:{2}", loadedRes.Name,
                        loadedRes.RefCount, loadedRes.State));
                });

                GUILayout.EndVertical();
            }
        }
#endif
    }




