using System;
using Object = UnityEngine.Object;


    public enum ResState
    {
        Waiting,
        Loading,
        Loaded,
    }

public abstract class Res : SimpleRC
{


    #region ×ÖÊý¹¹Ôì


    private ResState mState;

    public Object Asset { get; protected set; }

    public string Name { get; protected set; }

    private string mAssetPath;
    protected abstract void OnReleaseRes();
    private event Action<Res> mOnLoadedEvent;    
    
    public ResState State
    {
        get { return mState; }
        protected set
        {
            mState = value;

            if (mState == ResState.Loaded)
            {
                if (mOnLoadedEvent != null)
                {
                    mOnLoadedEvent.Invoke(this);
                }
            }
        }
    }
    #endregion


    #region ¸¨Öú


    public abstract bool LoadSync();

    public abstract void LoadAsync();



    protected override void OnZeroRef()
    {
        OnReleaseRes();
    }



    public void RegisterOnLoadedEvent(Action<Res> onLoaded)
    {
        mOnLoadedEvent += onLoaded;
    }

    public void UnRegisterOnLoadedEvent(Action<Res> onLoaded)
    {
        mOnLoadedEvent -= onLoaded;
    }
    #endregion


}