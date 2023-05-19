/****************************************************
    文件：AudioMgr.cs
	作者：lenovo
    邮箱: 
    日期：2023/5/4 1:44:21
	功能：
*****************************************************/

using UnityEngine;

public class AudioMgr : MonoSingleton<AudioMgr>
{

    #region 字属


    private AudioListener mAudioListener;
    private AudioSource mAudioSource;
    #endregion



    #region 辅助


    /// <summary>要有一个</summary>
    void CheckAudioListener()
    {
        if (!mAudioListener)
        {
            mAudioListener = FindObjectOfType<AudioListener>();
        }

        if (!mAudioListener)
        {
            mAudioListener = gameObject.AddComponent<AudioListener>();
        }
    }




    #region Music


    /// <summary>音乐</summary>
    public void PlayMusic(string musicName, bool loop)
    {
        CheckAudioListener();

        if (!mAudioSource)
        {
            mAudioSource = gameObject.AddComponent<AudioSource>();
        }

        var coinClip = Resources.Load<AudioClip>(musicName);

        mAudioSource.clip = coinClip;
        mAudioSource.loop = loop;
        mAudioSource.Play();
    }

    public void StopMusic()
    {
        mAudioSource.Stop();
    }

    public void PauseMusic()
    {
        mAudioSource.Pause();
    }

    /// <summary>从Pause重启</summary>
    public void ResumeMusic()
    {
        mAudioSource.UnPause();
    }

    public void MusicOff()
    {
        mAudioSource.Pause();
        mAudioSource.mute = true;
    }
    public void MusicOn()
    {
        mAudioSource.UnPause();
        mAudioSource.mute = false;
    }
    #endregion



    #region Sound


    public void PlaySound(string soundName)
    {
        CheckAudioListener();

        var coinClip = Resources.Load<AudioClip>(soundName);
        var audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = coinClip;
        audioSource.Play();
    }


    public void SoundOff()
    {
        var audioSources = GetComponents<AudioSource>();

        foreach (var audioSource in audioSources)
        {
            if (audioSource != mAudioSource)
            {
                audioSource.Pause();
                audioSource.mute = true;
            }
        }
    }



    public void SoundOn()
    {
        var audioSources = GetComponents<AudioSource>();

        foreach (var audioSource in audioSources)
        {
            if (audioSource != mAudioSource)
            {
                audioSource.UnPause();
                audioSource.mute = false;
            }
        }
    }
    #endregion




    #endregion

}
