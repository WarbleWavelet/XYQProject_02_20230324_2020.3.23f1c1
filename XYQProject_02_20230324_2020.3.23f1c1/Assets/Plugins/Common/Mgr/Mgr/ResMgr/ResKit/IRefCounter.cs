/****************************************************
    文件：IRefCounter.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/5 20:45:14
	功能：
*****************************************************/


/// <summary>引用计数器接口</summary>
public interface IRefCounter
{
    /// <summary>引用次数</summary>
    int RefCount { get; }

    /// <summary>持有</summary>
    void Retain(object refOwner = null);

    void Release(object refOwner = null);
}



