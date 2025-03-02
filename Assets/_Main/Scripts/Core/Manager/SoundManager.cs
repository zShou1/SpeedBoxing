using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private SoundDataSO _soundDataSO;
    [SerializeField] private GameObject oneShotPrefab;
    
    public bool IsSoundOn
    {
        get => _isSoundOnCached;
        set
        {
            _isSoundOnCached = value;
            PlayerPrefs.SetInt(Constants.SoundKey, value ? 1 : 0);
            PlayerPrefs.Save();
            if (!IsSoundOn)
            {
                BGSoundManager.Instance.StopBackgroundSound();
            }
            else
            {
                BGSoundManager.Instance.PlayBackgroundSound();
            }
        }
    }
    private bool _isSoundOnCached;
    
    private Dictionary<Sound, AudioClip> _soundDict;
    
    private Dictionary<Sound, AudioSource> activeSoundSources = new Dictionary<Sound, AudioSource>();

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad();
        InitSoundData();
    }

    private void Start()
    {
        _isSoundOnCached = PlayerPrefs.GetInt(Constants.SoundKey, 1) == 1;
    }
    
    private void InitSoundData()
    {
        if (_soundDataSO == null)
        {
            _soundDataSO = Resources.Load<SoundDataSO>("SoundDataTable");
            if (_soundDataSO == null)
            {
                Debug.LogError("Không tìm thấy SoundDataTable trong folder Resources!");
                return;
            }
        }

        _soundDict = new Dictionary<Sound, AudioClip>();
        foreach (var soundItem in _soundDataSO.soundAudioClipList)
        {
            if (soundItem.audioClip == null)
            {
                Debug.LogWarning($"AudioClip cho sound {soundItem.sound} là null.");
            }
            else
            {
                _soundDict[soundItem.sound] = soundItem.audioClip;
            }
        }
    }

    public void PlaySound(Sound sound, Vector3 position)
    {
        if (!IsSoundOn)
            return;

        AudioClip clip = GetAudioClip(sound);
        if (!clip) return;
    
        Transform soundSpawn = ObjectPutter.Instance.PutObject(SpawnerType.Sound);
        soundSpawn.name = "Sound_" + sound;
        soundSpawn.transform.position = position;
        
        if (!soundSpawn.TryGetComponent(out AudioSource source))
        {
            source = soundSpawn.gameObject.AddComponent<AudioSource>();
        }

        source.clip = clip;
        source.spatialBlend = 1f;
        source.rolloffMode = AudioRolloffMode.Linear;
        source.maxDistance = 100f;
        source.dopplerLevel = 0f;
        source.Play();
        activeSoundSources[sound] = source;
        StartCoroutine(BackToPool(soundSpawn.gameObject,sound, clip.length));
    }
    
    public void PlaySound2D(Sound sound)
    {
        if (!IsSoundOn)
            return;

        AudioClip clip = GetAudioClip(sound);
        if (!clip) return;
    
        Transform soundSpawn = ObjectPutter.Instance.PutObject(SpawnerType.Sound);
        soundSpawn.name = "Sound2D_" + sound;
        
        if (!soundSpawn.TryGetComponent(out AudioSource source))
        {
            source = soundSpawn.gameObject.AddComponent<AudioSource>();
        }

        source.clip = clip;
        source.spatialBlend = 0;
        source.rolloffMode = AudioRolloffMode.Linear;
        source.Play();
        activeSoundSources[sound] = source;
        StartCoroutine(BackToPool(soundSpawn.gameObject,sound, clip.length));
    }
    
    public void StopSound(Sound sound)
    {
        if (activeSoundSources.TryGetValue(sound, out AudioSource source))
        {
            if (source != null)
            {
                source.Stop();
            }
            activeSoundSources.Remove(sound);
        }
    }

    private IEnumerator BackToPool(GameObject soundGo,Sound sound,float time)
    {
        yield return new WaitForSeconds(time);
        soundGo.SetActive(false);
        activeSoundSources.Remove(sound, out AudioSource source);
    }
    /*public void PlaySoundOneShot(Sound sound, Vector3 position)
    {
        if (!IsSoundOn)
            return;

        AudioClip clip = GetAudioClip(sound);
        if (clip == null) return;

        GameObject go;
        if (oneShotPrefab != null)
        {
            go = Instantiate(oneShotPrefab, position, Quaternion.identity);
        }
        else
        {
            go = new GameObject("OneShotSound_" + sound.ToString());
            go.transform.position = position;
            go.AddComponent<AudioSource>();
        }
        AudioSource source = go.GetComponent<AudioSource>();
        source.clip = clip;
        source.PlayOneShot(clip);
        Destroy(go, clip.length);
    }*/
    
    private AudioClip GetAudioClip(Sound sound)
    {
        if (_soundDict != null && _soundDict.TryGetValue(sound, out AudioClip clip))
        {
            return clip;
        }
        /*Debug.LogWarning($"Không tìm thấy AudioClip cho sound: {sound}");*/
        return null;
    }
}