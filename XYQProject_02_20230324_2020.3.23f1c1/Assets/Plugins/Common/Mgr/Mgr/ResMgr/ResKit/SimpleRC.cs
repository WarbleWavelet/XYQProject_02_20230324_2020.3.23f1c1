/// <summary>��������</summary>
public class SimpleRC : IRefCounter
{
    public int RefCount { get; private set; }


    /// <summary>����</summary>
    public void Retain(object refOwner = null)
    {
        RefCount++;
    }


    /// <summary>�ͷ�</summary>
    public void Release(object refOwner = null)
    {
        RefCount--;

        if (RefCount == 0)
        {
            OnZeroRef();
        }
    }

    /// <summary>û������ʱ</summary>
    protected virtual void OnZeroRef()
    {

    }

}