using UnityEditor;
using UnityEngine;


public class DefinePath
{
    /// <summary>工程跟目录</summary>
    public static string ProjectPath = Application.dataPath.Replace("Assets", "");
    //public static string ProjectPath = Common.TrimName(Application.dataPath, TrimNameType.SlashAfter) ;
    public static string RealFramePath = Application.dataPath + "/" + DefinePath.RealFrameName + "/";
    public const string RealFrameName = "RealFrame"; //Top文件夹
    public const string m_RealFrameEditor = "Assets/RealFrame/Editor/RealFrameEditor.cs";

    //   /"+DefinePath.RealFrame+"

    #region Demo
    public static string Demo01_Bytes_Attack = "Assets/" + DefinePath.RealFrameName + "/StreamingAssets/attack";

    public const string Demo01_Prefab_Attack = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/Attack.prefab";
    public static string Demo02_Xml = RealFramePath + "Scenes/02 Class2Xml/Demo02_test.xml";
    public static string Demo03_WriteBytes = RealFramePath + "Scenes/03 Class2Bin/Demo03_test.bytes";
    public const string Demo03_ReadBytes = "Assets/" + DefinePath.RealFrameName + "/Scenes/03 Class2Bin/Demo03_test.bytes";
    public const string Demo04_Asset = "Assets/" + DefinePath.RealFrameName + "/Scenes/04 ReadAsset/TestAssets.asset";
    public const string Demo04_Prefab_Attack = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/Attack.prefab";
    public const string Demo05_Prefab_Attack = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/Attack.prefab";
    #endregion

    //

    #region 拓展
    public const string MenuItem_AB = "AB/";
    public const string MenuItem_ILR = "ILR/"; //ILRuntime

    public const string MenuItem_App = "App/";
    public const string MenuItem_Offline = "离线数据/";
    public const string MenuItem_FormatTool = "数据转换/";
    public const string MenuItem_RealFrame = "RealFrame配置/";
    public const string MenuItem_Jenkins = "Jenkins/";
    public const int MenuItem_FormatTool_StartIdx = 0;
    public const string Assets_MyAssets = "My Assets/";      
    
    
    
    public const int MenuItem_Index_AB_Encrypt = 120;
    public const int MenuItem_Index_AB_ABHotfix = 100;
    public const int MenuItem_Index_AB_ILRuntime = 140;
    #endregion



    #region 资源
    public const string Shader_BengHuai = "Custom/benghuai";


    public static string Demo05_Xml_AssetBundleConfig = RealFramePath + "AssetBundleConfig.xml";//XML可视化，随便删
    public static string Demo05_Bin_AssetBundleConfig = "Assets/" + DefinePath.RealFrameName + "/GameData/Data/ABData/AssetBundleConfig.bytes";
    public static string Demo05_AB_assetbundleconfig = "Assets/" + DefinePath.RealFrameName + "/StreamingAssets/assetbundleconfig";
    public const string Demo07_MP3_SenLin = "Assets/" + DefinePath.RealFrameName + "/GameData/Sounds/senlin.mp3";
    public const string Demo08_MP3_SenLin = "Assets/" + DefinePath.RealFrameName + "/GameData/Sounds/senlin.mp3";
    public const string Demo09_MP3_SenLin = "Assets/" + DefinePath.RealFrameName + "/GameData/Sounds/senlin.mp3";
    public const string Demo10_Prefab_Attack = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/Attack.prefab";
    public const string Demo11_Prefab_Attack = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/Attack.prefab";
    public const string Demo14_MP3_SenLin = "Assets/" + DefinePath.RealFrameName + "/GameData/Sounds/senlin.mp3";
    public const string Demo14_Images_PathPreFixed = "Assets/" + DefinePath.RealFrameName + "/GameData/Images/";
    public const string Demo16_Images_PathPreFixed = "Assets/" + DefinePath.RealFrameName + "/GameData/Images/";


 

    #endregion




    #region ScriptObject
    public const string ABCfgSOPath = "Assets/" + DefinePath.RealFrameName + "/Config/ABCfg.asset";
    public const string RealFrameCfgSOPath = "Assets/" + DefinePath.RealFrameName + "/Config/RealFrameCfg.asset";
    #endregion

    #region 打包相关



    //public static string OutputABOutterPath =  Application.dataPath + "/../AssetBundle/";//放到外面，不生成meta   ,失败

    public static string OutputXml = RealFramePath + "AssetBundleConfig.xml";//XML可视化，随便删
    public static string OutputBytes = RealFramePath + "AssetBundleConfig.bytes";//bytes，与下面简单的路径不同
    //public static string OutputAB = RealFramePath + "StreamingAssets/assetbundleconfig"; //bytes路径的AB包路径
    public static string assetbundleconfig_Inner = RealFramePath + "StreamingAssets/"+ Common.BuildTarget + "/assetbundleconfig"; //bytes路径的AB包路径
    public static string Path_AB_Inner = RealFramePath + "StreamingAssets/"+ Common.BuildTarget + "/"; 
    public static string assetbundleconfig_Outter = ProjectPath+"AssetBundle/assetbundleconfig"; //bytes路径的AB包路径
    public static string assetbundleconfig_Hotfix = @"C:\Users\lenovo\AppData\LocalLow\DefaultCompany\RealFrame_Test\DownLoad\assetbundleconfig"; //bytes路径的AB包路径

    public static string abCfg_Path = "Assets/" + DefinePath.RealFrameName + "/GameData/Data/ABData/"; //bytes
    public const string abCfg_Name = "assetbundleconfig"; //bytes
    public static string abCfg_Bytes = "Assets/" + DefinePath.RealFrameName + "/GameData/Data/ABData/AssetBundleConfig.bytes"; //bytes


    public static string AppBuildPath = Application.dataPath + "/../BuildTarget/";
    // public static string AppBuildPath_Andriod = Application.dataPath + "/../BuildTarget/Android/"; 
    public static string AppBuildPath_Andriod = DefinePath.ProjectPath + "BuildTarget/Android/";
    public static string AppBuildPath_IOS = Application.dataPath + "/../BuildTarget/IOS/";
    public static string AppBuildPath_Windows = Application.dataPath + "/../BuildTarget/Windows/";

    public static string ABBuildPath_Andriod = Application.dataPath + "/../AssetBundle/Android/";
    public static string ABBuildPath_IOS = Application.dataPath + "/../AssetBundle/IOS/";
    public static string ABBuildPath_Windows = Application.dataPath + "/../AssetBundle/Windows/";



    public static string OutputAB_InnerPath = RealFramePath + "StreamingAssets/";//打包时总包名是平台名
    public static string OutputAB_OutterPath = ProjectPath + "AssetBundle/";//Assets的上一级
    public static string ABMD5_InnerPath = RealFramePath + "Resources/";
    public static string ABMD5_OutterPath = ProjectPath + "Version/";//Assets的上一级
    #endregion

    //ab.LoadAssets                     assetbundleconfig                
    //AssetBundle.LoadFromFile          Application.streamingAssetsPath + "/assetbundleconfig


    #region 配置相关
    //public static string Cfg_MonsterData =Application.dataPath + "/GameData/Data/Bin/MonsterData.bytes";
    //public static string Cfg_BuffData = Application.dataPath + "/GameData/Data/Bin/BuffData.bytes";      
    public const string Cfg_MonsterData_Inner = "Assets/" + DefinePath.RealFrameName + "/GameData/Data/Bin/MonsterData.bytes";
    public const string Cfg_BuffData = "Assets/" + DefinePath.RealFrameName + "/GameData/Data/Bin/BuffData.bytes";
    public const string Cfg_BuffData2 = "Assets/" + DefinePath.RealFrameName + "/GameData/Data/Bin/BuffData2.bytes";
    public const string Cfg_UIPrefabPath = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/";
    #endregion



    #region 热更 解密（解压）
    public static string Hot_OutterPath = Application.dataPath + "/../Hot/" ;
    public static string LocalPath_DownLoad = Application.persistentDataPath + "/DownLoad/" ;
    public static string LocalPath_Origin = Application.persistentDataPath + "/Origin/" ;
    #endregion



    #region ILRuntime
    public const string Path_HotFixDll_Txt = "Assets/" + DefinePath.RealFrameName + "/GameData/Data/HotFix/HotFix.dll.txt";
    public const string Path_HotFixDll = "Assets/" + DefinePath.RealFrameName + "/GameData/Data/HotFix/HotFix.dll";
    public const string Path_HotFixPdb_Txt = "Assets/" + DefinePath.RealFrameName + "/GameData/Data/HotFix/HotFix.pdb.txt";
    public const string Path_HotFixPdb = "Assets/" + DefinePath.RealFrameName + "/GameData/Data/HotFix/HotFix.pdb";
    public const string Path_HotFix = "Assets/" + DefinePath.RealFrameName + "/GameData/Data/HotFix/";
    public const string Path_Generated = "Assets/" + DefinePath.RealFrameName + "/Scripts/Mgr/ILRuntimeMgr/ILRuntime/ILRuntime/Generated";//最后不加/
    public const string Path_Generated_CLRBindings = "Assets/" + DefinePath.RealFrameName + "/Scripts/Mgr/ILRuntimeMgr/ILRuntime/ILRuntime/Generated/CLRBindings.cs";//最后不加/
    public const string m_Path_ILRuntimeCLRBinding = "Assets/" + DefinePath.RealFrameName + "/Scripts/Mgr/ILRuntimeMgr/ILRuntime/ILRuntime/Adapters/Editor/ILRuntimeCLRBinding.cs";
    public const string m_Path_ILRuntimeMgr = "Assets/" + DefinePath.RealFrameName + "/Scripts/Mgr/ILRuntimeMgr/ILRuntimeMgr.cs";
    public const string m_HotFix_NamespaceClass = "Demo16";


    #endregion

    public const string Scene_Empty = "Empty14";


	public const string MenuItem_AVG = "AVG/";




}


#region Demo
public class DefinePath_Demo13
{
    private const string PanelPath = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/UGUI/Panel/Demo13/";
    public const string MenuPanel = PanelPath + "Demo13MenuPanel.prefab";
}

public class DefinePath_Demo14
{
    public const string Scene_Menu = "Menu14";
    public const string Scene_Start = "Start14";

    //
    private const string PanelPath = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/UGUI/Panel/Demo14/";
    private const string PanelPath1 = "Assets/" + DefinePath.RealFrameName + "/GameData/UGUI/";
    public const string Prefab_LoadPanel = PanelPath + "Demo14LoadPanel.prefab";
    public const string Prefab_MenuPanel = PanelPath + "Demo14MenuPanel.prefab";
    public const string Prefab_Attack = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/Attack.prefab";
    public const string MP3_SenLin = "Assets/" + DefinePath.RealFrameName + "/GameData/Sounds/senlin.mp3";

}

public class DefinePath_Demo15
{
    //界面名称


    //场景名称
    public const string Scene_Menu = "Menu15";
    public const string Scene_Start = "Start15";

   

    public const string MENUSOUND = "Assets/GameData/Sounds/menusound.mp3";    //临时音乐资源
    public const string Prefab_Attack = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/Attack.prefab";
    private const string PanelPath = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/UGUI/Panel/Demo15/";



    public const string Prefab_CommonConfirm = PanelPath + "CommonConfirm.prefab";
    public const string CommonConfirm =  "CommonConfirm";
    public const string Prefab_HotfixPanel = PanelPath + "HotfixPanel.prefab";
    public const string Prefab_LoadPanel = PanelPath + "LoadPanel.prefab";
    public const string Prefab_MenuPanel = PanelPath + "MenuPanel.prefab";
    public const string Hotfix = "HotfixPanel.prefab";
    public const string Images_PathPreFixed = "Assets/" + DefinePath.RealFrameName + "/GameData/Images/";
}

public class DefinePath_Demo16
{
    public const string Scene_Menu = "Menu16";
    public const string Scene_Start = "Start16";
    //
    private const string PanelPath = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/UGUI/Panel/Demo16/";
    private const string PanelPath1 = "Assets/" + DefinePath.RealFrameName + "/GameData/UGUI/";
    public const string Prefab_LoadPanel = PanelPath + "Demo16LoadPanel.prefab";
    public const string Prefab_MenuPanel = PanelPath + "Demo16MenuPanel.prefab";
    public const string Prefab_Attack = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/Attack.prefab";
    public const string MP3_SenLin = "Assets/" + DefinePath.RealFrameName + "/GameData/Sounds/senlin.mp3";

}
#endregion




#region OfflineData
public class DefinePath_OfflineData
{

    public const string m_Type = "t:prefab";
    public const string m_Path = "Assets/" + DefinePath.RealFrameName + "/GameData/OfflineData/UIOfflineData";


}
public class DefinePath_UIOfflineData
{

    public const string m_Type = "t:prefab";
    public const string m_Path = "Assets/" + DefinePath.RealFrameName + "/GameData/Prefabs/UGUI/Panel";
}


public class DefinePath_ParticleOfflineData
{

    public const string m_Type = "t:prefab";
    public const string m_Path = "Assets/" + DefinePath.RealFrameName + "/GameData/OfflineData/ParticleOfflineData";
}
#endregion


