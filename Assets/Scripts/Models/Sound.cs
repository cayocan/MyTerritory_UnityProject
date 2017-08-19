using UnityEngine;
using System.Collections;

[System.Serializable]
public class Sound
{
    public string soundName;
    [Header("True => Music || False => FBX")]
    public bool soundType;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
    [Range(-3, 3)]
    public float pitch = 1;
    public bool loop = false;
    [HideInInspector]
    public AudioSource source;
}
