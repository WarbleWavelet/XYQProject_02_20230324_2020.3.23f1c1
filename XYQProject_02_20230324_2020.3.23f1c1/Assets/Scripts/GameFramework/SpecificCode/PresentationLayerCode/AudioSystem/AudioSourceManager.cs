using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : Singleton<AudioSourceManager>,ISingleton
{
    private AudioSource audioSource;

    private AudioSourceManager(){ }


    #region 生命


    public ISingleton Init()
    {
        audioSource = new GameObject(GameObjectName.AudioSourceManager).AddComponent<AudioSource>();
        PlayMusic("Normal", true);
        return this;
    }

    public void OnEnable()
    {
        
    }

    public void OnDisable()
    {

    }

    public void Update()
    {
        
    }
    #endregion


    #region 辅助


    public void PlayMusic(string musicName,bool loop=true)
    {
        audioSource.loop = loop;
        audioSource.clip = Resources.Load<AudioClip>("AudioClips/"+musicName);
        audioSource.Play();
    }


    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="soundName"></param>
    public void PlaySound(string soundName)
    {
        AudioClip ac = InternalResources.GetAudioClip(soundName);
        if (ac)
        {
            audioSource.PlayOneShot(ac);
        }
    }


    /// <summary>
    /// 播放人物音效
    /// </summary>
    public void PlaySoundCharacter(string soundName,string characterName=ResourcesName.AudioClip.Common)
    {
        string path= ResourcesName.AudioClip.GetCharacterAudioClipPath(characterName, soundName);
        AudioClip ac = ExtendResources.Get<AudioClip>(path);
        if (ac)//有人物特定音效
        {
            audioSource.PlayOneShot(ac);
        }
        else //没有人物特定音效
        {
            path = ResourcesName.AudioClip.GetCharacterAudioClipPath(ResourcesName.AudioClip.Common, soundName);
            ac=ExtendResources.Get<AudioClip>(path);
            audioSource.PlayOneShot(ac);
        }
    }
    #endregion







}
