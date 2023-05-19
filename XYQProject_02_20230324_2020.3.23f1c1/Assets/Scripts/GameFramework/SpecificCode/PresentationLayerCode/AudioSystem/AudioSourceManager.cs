using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : Singleton<AudioSourceManager>,ISingleton
{
    private AudioSource audioSource;

    private AudioSourceManager(){ }


    #region ����


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


    #region ����


    public void PlayMusic(string musicName,bool loop=true)
    {
        audioSource.loop = loop;
        audioSource.clip = Resources.Load<AudioClip>("AudioClips/"+musicName);
        audioSource.Play();
    }


    /// <summary>
    /// ������Ч
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
    /// ����������Ч
    /// </summary>
    public void PlaySoundCharacter(string soundName,string characterName=ResourcesName.AudioClip.Common)
    {
        string path= ResourcesName.AudioClip.GetCharacterAudioClipPath(characterName, soundName);
        AudioClip ac = ExtendResources.Get<AudioClip>(path);
        if (ac)//�������ض���Ч
        {
            audioSource.PlayOneShot(ac);
        }
        else //û�������ض���Ч
        {
            path = ResourcesName.AudioClip.GetCharacterAudioClipPath(ResourcesName.AudioClip.Common, soundName);
            ac=ExtendResources.Get<AudioClip>(path);
            audioSource.PlayOneShot(ac);
        }
    }
    #endregion







}
