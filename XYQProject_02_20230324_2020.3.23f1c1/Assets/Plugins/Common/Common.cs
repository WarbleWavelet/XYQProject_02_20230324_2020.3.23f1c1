using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public static class Common
{

    #region 对比
    /// <summary>"abc".CompareTo("aca")返回-1 </summary>
    public static int Compare_CompareTo(string a,string b)
    {
        return a.CompareTo(b);
    }



    /// <summary>
    /// 值类型，引用类型
    /// </summary>
    public static bool Compare_Equals(object a, object b)
    {
        return a.Equals(b);

    }
    /// <summary> ==,值类型；所以当对比的是值类型，却用一用类型object a=1;object b=1; =>a==b出问题</summary>
    public static bool Compare_TwoEqual(object a,object b)
    {
        return a == b;

    }


    #endregion

    #region Enum enum 枚举


    public static void Enum_Foreach<T>()
    {
        foreach (T p in Enum.GetValues(typeof(T)))
        {
            Debug.Log(p);
        }
    }


    private enum Property
    {
        attack = 0,
        fireRate,
        life,
        COUNT //遍历枚举用到
    }
    private static void Enum_Foreach(Property _enum)
    {
        for (Property i = 0; i < Property.COUNT; i++)
        {
            Debug.Log(i.ToString());
        }
    }
    #endregion  

    #region Type


    public static string Type_Name<T>()
    {
        return typeof(T).Name;
    }

    public static TypeConverter Type_Converter_Get(Type type)
    {
      return  TypeDescriptor.GetConverter(type);
    }


    public static TypeConverter Type_Converter_Get<T>()
    {
        Type type = typeof(T);
        return TypeDescriptor.GetConverter(type);
    }
    #endregion

    #region Find


    /// <summary>全局搜索，耗性能</summary>
    public static GameObject  Find(this  GameObject go,  string goName)
    {
        //  return  GameObject.Find(goName); 
        return go.transform.Find(goName).gameObject;
    }

    /// <summary>搜索子树 </summary>
    public static Transform Find(this Transform t, string path)
    {
        return t.Find(path);  //局部搜索
    }

    #endregion

    #region Canvas快捷操作


    public static Transform Canvas_Get()
    {
        Transform canvas= GameObject.FindGameObjectWithTag(Tags.Canvas).transform;
        if (canvas == null)
        {
            canvas = UnityEngine.Object.FindObjectOfType<Canvas>().transform;
        }

        return canvas;
    }
    public static Text Canvas_Text_Get()
    {

        GameObject canvas = GameObject.FindGameObjectWithTag(Tags.Canvas);
        return canvas.transform.Find( GameObjectName.Text).GetComponent<Text>();
    }

    public static Button Canvas_Button_AddListener(Action action)
    {

        return Canvas_Button_AddListener(GameObjectName.Button,  action);
    }

    public static Button Canvas_Button_AddListener(string btnName, Action action)
    {

        GameObject canvas = GameObject.FindGameObjectWithTag( Tags.Canvas );
        Button button = canvas.transform.Find(btnName).GetComponent<Button>();
        button.onClick.AddListener(() => action());
        return button;
    }

    public static Button Button_AddListener(Button button,Action action)
    {

        button.onClick.AddListener(() => action());
        return button;
    }

    #endregion


    #region 枚举 布尔

    /// <summary>
    /// 字符串转枚举
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_string"></param>
    /// <returns></returns>
    public static T String2Enum<T>(string _string)
    {
        if (_string == null) return default(T);
        return (T)Enum.Parse(typeof(T), _string);
    }

    public static object String2Enum<T>(string _string, bool _bool = true)
    {
        if (_string == null) return null;
        return (T)Enum.Parse(typeof(T), _string, _bool);
    }


    /// <summary>
    /// 字符串转布尔
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_string"></param>
    /// <returns></returns>
    public static bool String2Bool(string _string)
    {
        return _string == "true" ? true : false;
    }


    public static bool Try_String2Bool(string _string)
    {
        bool _bool;
        bool.TryParse(_string, out _bool);
        return _bool;
    }

    #endregion


    #region FileStream
    /// <summary>
    /// 读取前length，byte[]转string
    /// </summary>
    /// <param name="fs"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string FileStream_Read(FileStream fs, int length)
    {
        byte[] buffer = new byte[length];
        fs.Read(buffer, 0, buffer.Length);
        string str = Encoding.UTF8.GetString(buffer);

        return str;
    }


    public static string FileStream_Read(FileStream fs, ref byte[] buffer)
    {
        fs.Read(buffer, 0, buffer.Length);
        string str = Encoding.UTF8.GetString(buffer);

        return str;
    }


    /// <summary>
    /// 从开始索引start读取到结束索引end
    /// </summary>
    /// <param name="fs"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public static byte[] FileStream_Read(FileStream fs, long start, long end)
    {
        byte[] buffer = new byte[end - start];//内容
        fs.Read(buffer, 0, Convert.ToInt32(end - start));
        fs.Seek(0, SeekOrigin.Begin);
        fs.SetLength(0);

        return buffer;



    }





    public static byte[] FileStream_Read(FileStream fs)
    {
        fs.Seek(0, SeekOrigin.Begin);       //读完 seek回去，保持原始状态
        byte[] buffer = new byte[fs.Length];
        fs.Read(buffer, 0, Convert.ToInt32(fs.Length));     //获取所有
        fs.Seek(0, SeekOrigin.Begin);                       //移动到开头
        fs.SetLength(0);                                    //清空

        return buffer;


    }
    /// <summary>
    /// fs写入 str  .fs会返回出去（）但因为是using，所以不能用返回值，ref out
    /// </summary>
    public static void FileStream_Write(FileStream fs, string str)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(str);
        fs.Write(buffer, 0, buffer.Length);

    }


    public static void FileStream_Write(FileStream fs, byte[] buffer)
    {
        fs.Write(buffer, 0, buffer.Length);

    }




    public static void FileStream_Write(FileStream fs, byte[] buffer, int start, int end)
    {
        fs.Write(buffer, start, end);

    }

    public static void FileStream_Read(FileStream fs, byte[] buffer, int start, long end)
    {
        fs.Read(buffer, start, Convert.ToInt32(end));

    }

    #endregion




    #region File FileInfo StreamWriter     




    /// <summary>
    /// 新建并且向filePath写入fileContent（StreamWriter）
    /// </summary>
    /// <param name="filePath">全写，包括文件名和后缀</param>
    /// <param name="fileContent"></param>
    public static void File_Create_Write(string filePath, string fileContent)
    {
        FileInfo fi = new FileInfo(filePath);
        StreamWriter sw = fi.CreateText();
        sw.WriteLine(fileContent);

        sw.Close();
        sw.Dispose();
    }

    /// <summary>
    /// 新建并且向filePath写入bytes（Stream）
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="bytes"></param>
    public static void File_Create_Write(string filePath, byte[] bytes)
    {
        File_Delete(filePath);
        //
        FileInfo fi = new FileInfo(filePath);
        Stream stream = fi.Create();

        stream.Write(bytes, 0, bytes.Length);
        stream.Close();

        stream.Dispose();
    }



    public static void AB_Clear(string path)
    {
        if (Folder_Exits(path) == false)
        {

            Debug.LogErrorFormat("该路径不存在：{0}", path);
            return;
        }

        DirectoryInfo di = new DirectoryInfo(path);  //搜索该文件夹
        FileInfo[] fiArr = di.GetFiles("*", SearchOption.AllDirectories);

        for (int i = 0; i < fiArr.Length; i++)//全删除
        {
            string fileFullName = fiArr[i].FullName;    // A/B/c.xxx

            if (File.Exists(fileFullName))
            {
                File.Delete(fileFullName);//删除本身
            }
            if (File.Exists(fileFullName + ".manifest"))
            {
                File.Delete(fileFullName + ".manifest");//删除他的manifest
            }

        }

    }

    public static void File_Move(string from, string to)
    {
        File.Move(from, to);
    }

    /// <summary>
    /// 移动+加后缀
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="suffix"></param>
    public static void File_Move_Suffix(string from, string suffix)
    {
        File.Move(from, from + suffix);
    }




    /// <summary>
    /// 文件夹拷贝
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    public static void File_Copy(string from, string to)
    {


        try //递归拷贝
        {
            //取路径
            Common.Folder_New(to);
            string toPath = Path.Combine(to, Path.GetFileName(from));// A/   B/b  =>  A/b
            toPath = Common.TrimName(toPath, TrimNameType.SlashPre);//去掉StreamingAssets
            if (File.Exists(from) == true)
            {
                toPath += Path.DirectorySeparatorChar;// Path.DirectorySeparatorChar: '\'
            }

            //取文件
            Common.Folder_New(toPath);

            string[] fileArr = Directory.GetFileSystemEntries(from);
            //赋值
            foreach (string file in fileArr)
            {
                if (file.EndsWith(".meta") == true)
                {
                    continue;
                }
                if (Directory.Exists(file) == true)
                {
                    File_Copy(file, toPath);  //文件夹拷贝
                }
                else
                {

                    File.Copy(file, toPath + "/" + Path.GetFileName(file), true);//文件拷贝  ,文件夹和文件名
                }
            }

        }
        catch (Exception)
        {

            Debug.LogErrorFormat("无法复制：{0} => {1}", from, to);
        }
    }


    /// <summary>
    /// 删除文件夹下的所有文件,递归删除
    /// </summary>
    public static void Folder_Clear_Recursive(string path)
    {
        try
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileSystemInfo[] fsiArr = di.GetFileSystemInfos();

            foreach (var fsi in fsiArr)
            {
                if (fsi is DirectoryInfo)
                {
                    DirectoryInfo _di = new DirectoryInfo(fsi.FullName);
                    _di.Delete(true);
                }
                else
                {
                    File.Delete(fsi.FullName);
                }
            }

        }
        catch (Exception)
        {

            throw;
        }
    }

    /// <summary>
    /// 删除文件夹下的所有文件,除了后缀是lst的任一个 ,不递归删除
    /// </summary>
    public static void Folder_ClearWithout_NotRecursive(string path, params string[] lst)
    {
        try
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileSystemInfo[] fsiArr = di.GetFiles("*", SearchOption.AllDirectories);

            foreach (var fsi in fsiArr)
            {
                if (EndsWith(path, lst))
                {
                    continue;
                }

                File.Delete(fsi.FullName);
            }

        }
        catch (Exception)
        {

            throw;
        }
    }



    /// <summary>
    /// 到path下删除后缀名为suffix
    /// </summary>
    /// <param name="abPath"></param>
    /// <param name="sufffix"></param>
    public static void Folder_Delete(string path, string sufffix)//m_AB_OutterPath
    {
        FileInfo[] fis = Common.Folder_GetAllFileInfo(path);
        foreach (FileInfo item in fis)
        {
            if (item.FullName.EndsWith(sufffix))
            {
                Common.File_Delete(item.FullName);
            }
        }

    }

    public static FileInfo[] Folder_GetAllFileInfo(string path)
    {
        DirectoryInfo directory = new DirectoryInfo(path);
        FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);

        return files;

    }


    /// <summary>
    /// 存在文件夹（带/也可以）
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool Folder_Exits(string path)
    {
        return Directory.Exists(path);
    }


    /// <summary>文件夹有就好，没有就创建</summary>
    public static void Folder_New(string path)
    {
        if (Directory.Exists(path) == false) //输出path
        {
            Directory.CreateDirectory(path);
        }
    }
    #endregion



    #region File


    public static void File_Rename(string sourceName, string destName, string path)
    {
        string destPath = path.Replace(sourceName, destName);
        if (Common.File_Exits(destPath))
        {
            Debug.LogError("当前文件名称已存在");
        }
        else
        {
            Common.File_Move(path, destPath);
        }
    }

    /// <summary>
    /// 存在文件
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool File_Exits(string path)
    {
        return File.Exists(path);
    }

    /// <summary>
    /// 删除该文件
    /// </summary>
    /// <param name="path"></param>
    public static void File_Delete(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }



    public static string File_Name_Suffix(string path)
    {
        return Path.GetExtension(path);
    }



    public static string File_Name_WithoutSuffix(string path)
    {
        return Path.GetFileNameWithoutExtension(path);
    }
    #endregion


    #region Guid
    /// <summary>异步的Guid，为了可以取消该异步</summary> 
    static long m_asyncGuid = 0;
    /// <summary>异步的Guid，为了可以取消该异步</summary>
    public static long CreateGuid()
    {
        return m_asyncGuid++;
    }
    #endregion



    #region Log

    /// <summary>这种不理想，各种系统命名</summary>
    public static void Log(object obj)
    {
        Debug.Log(obj.GetType().ToString() + "." + new System.Diagnostics.StackTrace().GetFrame(0).GetMethod().ToString());//类名.方法名
    }

    /// <summary>
    ///  本来想在ILRunTime案例中使用，但是跨域时打印不满意，都是系统函数
    /// </summary>
    /// <param name="frame"> 1:第一层，也就是当前类；2:第二层，也就是调用类；3:第三层，多层调用类；n：以此类推</param>
    /// <returns></returns>
    public static string Log_ClassFunction(int frame = 1)
    {
        StackTrace trace = new StackTrace();
        var sb = new StringBuilder();

        Type type = trace.GetFrame(frame).GetMethod().DeclaringType;// GetFrame()获取是哪个类来调用的
        string method = trace.GetFrame(frame).GetMethod().ToString();// 获取是类中的那个方法调用的

        if (type != null)
        {
            sb.Append(type);
        }

        if (method != null)
        {
            sb.Append(".");
            sb.Append(method);
        }

       // Debug.LogFormat("{0}（命名空间.类.方法，frame={1}）", sb, frame);//未修改前
        string str = sb.ToString().TrimName(TrimNameType.PointPre_SpacingAfter); //
        Debug.LogFormat("{0}（命名空间.类.方法，frame={1}）", str, frame);
        return str;
    }

    public static string Log_ClassFunction(string content,int frame = 1)
    {
        StackTrace trace = new StackTrace();
        var sb = new StringBuilder();

        Type type = trace.GetFrame(frame).GetMethod().DeclaringType;// GetFrame()获取是哪个类来调用的
        string method = trace.GetFrame(frame).GetMethod().ToString();// 获取是类中的那个方法调用的

        if (type != null)
        {
            sb.Append(type);
        }

        if (method != null)
        {
            sb.Append(".");
            sb.Append(method);
        }

        // Debug.LogFormat("{0}（命名空间.类.方法，frame={1}）", sb, frame);//未修改前
        string str = sb.ToString().TrimName(TrimNameType.PointPre_SpacingAfter); //
        Debug.LogFormat("{0}（命名空间.类.方法，frame={1}）", str, frame);
        return str;
    }

    public static string Log_NamespaceClassFunction(string content,int frame = 1)
    {
        StackTrace trace = new StackTrace();
        var sb = new StringBuilder();

        Type type = trace.GetFrame(frame).GetMethod().DeclaringType;// GetFrame()获取是哪个类来调用的
        string nameSpace = trace.GetFrame(frame).GetMethod().DeclaringType.Namespace;// GetFrame()获取是哪个类来调用的
        string method = trace.GetFrame(frame).GetMethod().ToString();// 获取是类中的那个方法调用的

        if (nameSpace != null)
        {
            sb.Append(nameSpace);
        }
        if (type != null)
        {
            sb.Append(".");
            sb.Append(type);
        }

        if (method != null)
        {
            sb.Append(".");
            sb.Append(method);
        }

        Debug.LogFormat("{0}{1}（命名空间.类.方法，frame={1}）", sb,content, frame);

        return sb.ToString();
    }
    public static string Log_NamespaceClassFunction(int frame = 1)
    {
        StackTrace trace = new StackTrace();
        var sb = new StringBuilder();

        Type type = trace.GetFrame(frame).GetMethod().DeclaringType;// GetFrame()获取是哪个类来调用的
        string nameSpace = trace.GetFrame(frame).GetMethod().DeclaringType.Namespace;// GetFrame()获取是哪个类来调用的
        string method = trace.GetFrame(frame).GetMethod().ToString();// 获取是类中的那个方法调用的

         if(nameSpace!=null)
{
            sb.Append(nameSpace);
        }
        if (type != null)
        {
            sb.Append(".");
            sb.Append(type);
        }

        if (method != null)
        {
            sb.Append(".");
            sb.Append(method);
        }

        Debug.LogFormat("{0}（命名空间.类.方法，frame={1}）",sb,  frame);

        return sb.ToString();
    }
    #endregion


    #region 字符串处理


    /// <summary>
    ///  取枚举表述的值<para />
    ///  懒得改以前的<para />
    /// </summary>
    /// <param name="path"></param>
    /// <param name="type"></param>
    /// <returns></returns>

    [Obsolete("已过时，建议使用=>ExtendUtil.TrimName(string path, TrimNameType type)")]
    public static string TrimName(string path, TrimNameType type)
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
                    string name = path.Substring( path.LastIndexOf('.')+1);// plane.unity3d=> unity3d
                    return name;
                }
            case TrimNameType.BracketsAfter:
                { 
                    string name=path.Substring(0, path.LastIndexOf('(') );//Andy(Clone)=>Andy
                    return name;
                }
            case TrimNameType.SpacingAfter:
                {
                    string name = path.Substring(path.LastIndexOf('.') + 1);// plane.unity3d=> unity3d
                    return name;
                }
            default:
                {
                    return path;
                }
        }


    }



    public static bool NotEndsWith(string str, params string[] lst)
    {
        foreach (var item in lst)
        {
            if (str.EndsWith(item))
            {
                return false;
            }
        }

        return true;
    }


    public static bool EndsWith(string str, params string[] lst)
    {
        foreach (var item in lst)
        {
            if (str.EndsWith(item))
            {
                return true;
            }
        }

        return false;
    }


    /// <summary>
    /// 去除所有空格
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string TrimAllSpace(string val)
    {
        return val.Trim().Replace(" ", "");
    }
    #endregion




    #region 辅助
    /// <summary>
    /// AB加载，实例时Shader丢失，修复该问题
    /// </summary>
    /// <param name="go"></param>
    public static void FixShader(GameObject go, string shaderName)
    {
        MeshRenderer[] mr = go.GetComponentsInChildren<MeshRenderer>();
        List<Material> lst = new List<Material>();
        for (int i = 0; i < mr.Length; i++)
        {
            lst.AddRange(mr[i].materials);
        }
        SkinnedMeshRenderer[] smr = go.GetComponentsInChildren<SkinnedMeshRenderer>();
        for (int i = 0; i < smr.Length; i++)
        {
            lst.AddRange(smr[i].materials);
        }

        for (int i = 0; i < lst.Count; i++)
        {
            lst[i].shader = Shader.Find(shaderName);
        }
    }
    #endregion


    public static void PlayBGMusic(AudioSource source, AudioClip clip)

    {

        source.clip = clip;
        source.Play();

    }


    public static void BindBtn( Button btn, Action action)
    {
        btn.onClick.AddListener(() =>
        {
            action();

        });
    }








    #region 转格式
    /// <summary>
    /// 为了可视化
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public static void Class2Xml<T>(T cfg, string outputPath)
    {
        if (File.Exists(outputPath))
        {
            File.Delete(outputPath);
        }
        FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
        XmlSerializer xml = new XmlSerializer(cfg.GetType());
        xml.Serialize(sw, cfg);
        sw.Close();
        fs.Close();


    }


    /// <summary>
    /// 将类对象cfg转Bin，放在path下
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public static void Class2Bin<T>(T cfg, string path)
    {
        FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        fs.Seek(0, SeekOrigin.Begin);//清空
        fs.SetLength(0);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, cfg);
        fs.Close();


    }
    #endregion






    #region  App   网络

    public static bool IsAndroidOrIOS()
    {

        return Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android;
    }


    /// <summary>
    /// 网络状态
    /// </summary>
    /// <returns></returns>
    public static NetworkStatusType NetworkStatus()
    {

        switch (Application.internetReachability)
        {
            case NetworkReachability.ReachableViaCarrierDataNetwork:
                {
                    return NetworkStatusType.Traffic;
                }

            case NetworkReachability.ReachableViaLocalAreaNetwork:

                {
                    return NetworkStatusType.Wifi;
                }
            case NetworkReachability.NotReachable:
            default:
                {
                    return NetworkStatusType.NotReachable;
                }
        }
    }


    #endregion


    #region BuildTarget
    public static string BuildTarget = "StandaloneWindows64";
    public static void SetBuildTarget(string str)
    {
        BuildTarget = str;
    }
    #endregion



 




    public static void Refresh()
    {
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }

	/// <summary>
	/// 名字形象
	/// </summary>
	/// <param name="path"></param>
	public static void ShootAt(string path)
	{
#if UNITY_EDITOR
		Selection_ActiveObject(path);
#endif
	}


	public static void Selection_ActiveObject(string path)
    {
#if UNITY_EDITOR
        Selection.activeObject = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);//"Assets/Config/ABCfg.asset";
#endif
    }

    public static void Selection_OpenPath(string path)
    {
#if UNITY_EDITOR
        Selection.activeObject = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);//"Assets/Config/ABCfg.asset";
#endif
    }



    #region Timer Time DateTime


    public static long Time_Now()
    {
        return System.DateTime.Now.Ticks; 
    }

        /// <summary>
        /// action执行的时间。秒 毫微 纳
        /// </summary>
        /// <param name="action"></param>
    public static void Time_During(Action action,TimeUnit timeUnit=TimeUnit.nSeconds)
    {
        long curTime = System.DateTime.Now.Ticks;
        action();
        long during = System.DateTime.Now.Ticks - curTime;

        switch (timeUnit)
        {
            case TimeUnit.Seconds: Debug.LogFormat("运行时间：{0}秒", (during / 1000000000.0f).ToString("0.00")); break;
            case TimeUnit.mSeconds: Debug.LogFormat("运行时间：{0}毫秒", (during / 1000000.0f).ToString("0.00")); break;
            case TimeUnit.uSeconds: Debug.LogFormat("运行时间：{0}微秒", (during / 1000.0f).ToString("0.00")); break;
            case TimeUnit.nSeconds: Debug.LogFormat("运行时间：{0}纳秒", (during).ToString("0.00")); break;
            case TimeUnit.pSeconds: Debug.LogFormat("运行时间：{0}皮秒", (during * 1000.0f).ToString("0.00")); break;
            default:  break;
        }
    }


    /// <summary>
    ///  C#自带的异步   <para />
    ///  每过awaitTime，就会问距离timer过了多久<para />
    ///  如果超过time，isActing==false（没有正在执行action） ，就执行action<para />
    ///  bug 问题是需要异步内部改变isActing需要被返回，但又不被允许
    /// </summary>
    /// <param name="timer"></param>
    /// <param name="time"></param>
    /// <param name="isActing"></param>
    /// <param name="action"></param>
    /// <param name="awaitTime"></param>
    public static async void Timer(DateTime timer, float time, bool isActing, Action action, float awaitTime = 1f)
    {
        while (true)
        {
            await Task.Delay(TimeSpan.FromSeconds(awaitTime)); //等1秒
            var during = (timer - DateTime.Now).Seconds; //时长
            if (during >= time && !isActing)//防止Pool正在销毁，事件叠加卡帧
            {
                isActing = true;
                action();
                /** action
                    while (条件)//不用这么多
                    {
                        await Task.Delay(100);//0.01s，大约一帧销毁一个
                    }
                    isActing = false;
                **/
            }
        }
    }
    #endregion



    #region Reflection


    /// <summary>
    /// 获取程序集下的类
    /// 热更DLL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="classPath"></param>
    /// <returns></returns>
    public static Type Reflection_Class_Get(string typeName)
    {
        return Type.GetType(typeName);
    }

    /// <summary>
    /// 热更DLL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Type Reflection_Class_Get<T>()
    {
        return typeof(T);
    }

    /// <summary>
    /// 热更DLL当中，可以直接通过Activator来创建实例
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public static object Reflection_Object_Get(string typeName)
    {
        Type t = Type.GetType(typeName);//或者typeof(TypeName)

        return Activator.CreateInstance(t);
       // return Activator.CreateInstance<TypeName>();//也行
    }

    /// <summary>
    /// 获取有这个类的程序集
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Assembly Reflection_Assembly_Get<T>() 
    { 
         return Assembly.GetAssembly(typeof(T));
    }





    /// <summary>
    /// 通过反射调用方法
    /// 在热更DLL当中，通过反射调用方法跟通常C#用法没有任何区别
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public static void Reflection_Invoke<T>(string methodName)
    {
        Type type = typeof(T);

        object instance = Activator.CreateInstance(type);
        MethodInfo mi = type.GetMethod(methodName);

        mi.Invoke(instance, null);
    }


    #endregion



    #region Resources


    /// <summary>
    /// 加载并且实例了一个预制体
    /// </summary>
    /// <param name="type"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static GameObject Resources_LoadPrefab(string path,Transform parent=null)//type=typeof(T)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab == null)
        {
            Debug.LogErrorFormat("加载不到预制体，路径：Resources/{0}",path);    
        }
        GameObject go = GameObject.Instantiate(prefab);
        if (parent != null)
        {
            go.SetParent(parent);
        }
        return go;
    }
    #endregion

}



#region 枚举

public enum TrimNameType
{
    None,
    /// <summary>A/B/C.prefab => C.prefab</summary>
    SlashAfter,
    /// <summary>A/B/C.prefab => A/B</summary>
    SlashPre,
    /// <summary>A/B/C.prefab => C</summary>
    SlashAndPoint,
    /// <summary>C.prefab => C</summary>
    PointPre,
    /// <summary>A.Void B() => A</summary>
    PointAfter,
    /// <summary>A(B) => A</summary>
    BracketsAfter  ,
    SpacingPre,
    /// <summary>A.Void B() => B()</summary>
    SpacingAfter,
    /// <summary>A.Void B() => A.B()</summary>
    PointPre_SpacingAfter
}


/// <summary>
///网络状态
/// </summary>
public enum NetworkStatusType
{
    NotReachable,
    Traffic,
    Wifi

}

/// <summary>
/// 时间单位 s(秒),ms(毫秒),μs(微秒),ns(纳秒),ps(皮秒) 
/// </summary>
public enum TimeUnit
{
    /// <summary> 秒 </summary>
    Seconds,
    /// <summary> 毫秒 </summary>
    mSeconds,
    /// <summary> 微秒 </summary>
    uSeconds,
    /// <summary> 纳秒 </summary>
    nSeconds,
    /// <summary> 皮秒 </summary>
    pSeconds ,
    /// <summary> 1帧（0.016777.....7s） </summary>
    pFrame
}




#endregion

