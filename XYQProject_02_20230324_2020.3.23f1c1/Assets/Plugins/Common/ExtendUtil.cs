/****************************************************
    文件：ExtendUtil.cs
	作者：lenovo
    邮箱: 
    日期：2022/11/3 8:32:19
	功能：通用拓展
*****************************************************/

using UnityEngine;

public static class ExtendUtil 
{
    /// <summary>
    ///  取枚举表述的值
    ///  TrimNAme都是用SubString，所以本体是不变的
    /// </summary>
    /// <param name="path"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string TrimName(this string path, TrimNameType type)
    {
        switch (type)
        {
            case TrimNameType.SlashAfter:
                {
                    return path.Substring(path.LastIndexOf('/') + 1);//sdcvghasvdj/gdhsag/a.prefab => a.prefab
                }
            //break;             
            case TrimNameType.SlashPre:
                {
                    return path.Substring(0, path.LastIndexOf('/'));//sdcvghasvdj/gdhsag/a.prefab =>sdcvghasvdj/gdhsag
                }
            //break;
            case TrimNameType.SlashAndPoint:
                {
                    string name = path.Substring(path.LastIndexOf('/') + 1);// plane.unity3d
                    name = name.Substring(0, name.LastIndexOf('.'));// plane
                    return name;
                }
            case TrimNameType.PointPre:
                {
                    string name = path.Substring(0, path.LastIndexOf('.'));// plane.unity3d=> plane
                    return name;
                }
            case TrimNameType.PointAfter:
                {
                    string name = path.Substring(path.LastIndexOf('.') + 1);// plane.unity3d=> unity3d
                    return name;
                }
            case TrimNameType.BracketsAfter:
                {
                    string name = path.Substring(0, path.LastIndexOf('('));//Andy(Clone)=>Andy
                    return name;
                }
            case TrimNameType.SpacingAfter:
                {
                    string name = path.Substring(path.LastIndexOf('.') + 1);// plane.unity3d=> unity3d
                    return name;
                }
            case TrimNameType.PointPre_SpacingAfter:
                {
                    int start = path.IndexOf('.');
                    int end = path.IndexOf(' ');
                    string left = path.Substring(0,start);
                    string right = path.Substring(end+1);
                    return left +"."+ right;
                }
            default:
                {
                    return path;
                }
        }
    }
}