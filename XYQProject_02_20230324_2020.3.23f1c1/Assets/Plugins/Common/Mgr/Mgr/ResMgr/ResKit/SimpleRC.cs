/// <summary>简单引用类</summary>
public class SimpleRC : IRefCounter
{
    public int RefCount { get; private set; }


    /// <summary>持有</summary>
    public void Retain(object refOwner = null)
    {
        RefCount++;
    }


    /// <summary>释放</summary>
    public void Release(object refOwner = null)
    {
        RefCount--;

        if (RefCount == 0)
        {
            OnZeroRef();
        }
    }

    /// <summary>没有引用时</summary>
    protected virtual void OnZeroRef()
    {

    }

}