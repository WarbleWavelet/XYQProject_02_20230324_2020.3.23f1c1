using System.Reflection;
using System;
//*****************************************
//创建人： Trigger 
//功能说明：单例模板（实例化单例对象）
//***************************************** 
public class Singleton<T> where T:class,ISingleton
{
    private static T mInstance;
    public static T Instance
    {
        get
        {
            if (mInstance==null)
            {
                var ctors= typeof(T).GetConstructors(BindingFlags.Instance|BindingFlags.NonPublic);
                var ctor = Array.Find(ctors,c=>c.GetParameters().Length==0);
                if (ctor==null)
                {
                    throw new Exception("没有找到非公共构造函数"+typeof(T));
                }
                mInstance= ctor.Invoke(null) as T;
            }

            return mInstance;
        }
    }
}
