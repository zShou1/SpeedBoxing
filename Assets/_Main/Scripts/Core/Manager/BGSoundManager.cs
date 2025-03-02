using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundManager : Singleton<BGSoundManager>
{
    [SerializeField] private AudioClip backgroundClip; // Gán AudioClip nhạc nền từ Inspector
    private AudioSource bgAudioSource;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad();
        Init();
    }
    
    private void Init()
    {
        if(!TryGetComponent(out bgAudioSource))
        {
            bgAudioSource = gameObject.AddComponent<AudioSource>();
        }
        bgAudioSource.clip = backgroundClip;
        bgAudioSource.loop = true;
        bgAudioSource.spatialBlend = 0f;
        bgAudioSource.playOnAwake = false;
        /*if(SoundManager.Instance.IsSoundOn)
        {
            PlayBackgroundSound();
        }
        else
        {
            StopBackgroundSound();
        }*/
    }
    public void PlayBackgroundSound()
    {
        if (bgAudioSource && !bgAudioSource.isPlaying)
        {
            bgAudioSource.Play();
        }
    }

    public void StopBackgroundSound()
    {
        if (bgAudioSource && bgAudioSource.isPlaying)
        {
            bgAudioSource.Stop();
        }
    }
}