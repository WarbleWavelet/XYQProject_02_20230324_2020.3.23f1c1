/****************************************************
    文件：MainMgr.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/4 1:28:9
	功能：
*****************************************************/

using UnityEngine;

public abstract class MainMgr : MonoBehaviour
{
    public EnviromentMode Mode;

    private static EnviromentMode mSharedMode;
    private static bool mModeSetted = false;

    void Start()
    {
        if (!mModeSetted)
        {
            mSharedMode = Mode;
            mModeSetted = true;
        }

        switch (mSharedMode)
        {
            case EnviromentMode.Developing:
                LaunchInDevelopingMode();
                break;
            case EnviromentMode.Test:
                LaunchInTestMode();
                break;
            case EnviromentMode.Production:
                LaunchInProductionMode();
                break;
        }
    }

    protected abstract void LaunchInDevelopingMode();
    protected abstract void LaunchInTestMode();
    protected abstract void LaunchInProductionMode();
}