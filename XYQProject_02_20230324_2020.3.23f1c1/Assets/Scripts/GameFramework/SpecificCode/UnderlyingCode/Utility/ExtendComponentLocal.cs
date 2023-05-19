using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public static class ExtendComponentLocal
{
    public static void InitComponent<T>(this CharacterFightAIBehaviour ai,int id) where T : CharacterFightAIBehaviour
    {
        GameObject  go = EditorUtility.InstanceIDToObject(id) as GameObject;
        ai = go.AddComponent<T>();
        ai.Init();
    }
}
