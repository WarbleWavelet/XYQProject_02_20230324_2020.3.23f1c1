using UnityEngine;

public class Constants
{
    public const float Demo01_Offset = 10f;

    public const string Canvas = "Cnavas";

	#region Input


	public const string Mouse_X = "Mouse X";
	public const string Mouse_ScrollWheel = "Mouse ScrollWheel";
	#endregion


	#region Mgr      
	/// <summary>类对象池默认最大 Pool_MaxCnt </summary>
	public const int ClassObjectPool_MAXCNT = 500;
    public const int ClassObjectPool_AsyncLoadResPara_MAXCNT = 50;
    public const int ClassObjectPool_AsyncLoadResCallBack_MAXCNT = 100;
    public const int ClassObjectPool_RESOBJ_MAXCNT = 1000;

    /// <summary>卡着异步加载资源的最长时间</summary>
    public const int MAXASYNCLOADRESTIME = 200000;

    public const string FixPre = "";
    public const string FixSur_ResObject_m_Go = "(Recycle)";
    public const string FixSur_InstaniateGameObject = "(Clone)";


    //ResourceMgr
    public const int MaxCacheCnt = 500;

    #endregion




    #region 打安卓包
    public const string Android_keyaliasPass = "realframe";
    public const string Android_keystorePass = "realframe";
    /// <summary>密钥文件的名字</summary>
    public const string Android_keyaliasName = "android.keystore";
    /// <summary>keytool -list -keystore realframe.keystore  里面的名字</summary>
    public static string Android_keystoreName = Application.dataPath.Replace("Assets", "realframe.keystore");
    public static string Android_applicationIdentifierFix = "com.TTT.";

   

    #endregion


    #region AES加密
      public const string PrivateKey = "WWS";
    #endregion  

}


