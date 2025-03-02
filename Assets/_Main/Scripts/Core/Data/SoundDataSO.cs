using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundDataTable", menuName = "Create SoundDataTable")]
[Serializable]
public class SoundDataSO : ScriptableObject
{
    [SerializeField]
    public List<SoundAudioClip> soundAudioClipList = new List<SoundAudioClip>();
}