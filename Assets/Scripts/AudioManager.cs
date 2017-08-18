using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager instance;
	
	void AudioManagerSetup()
    {
        foreach (Sound sound in instance.soundList)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.audioClip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public AudioSource GetAudioSource(string _soundName)
    {
        Sound sound;

        sound = Array.Find(instance.soundList, _sound => _sound.soundName == _soundName);

        if (sound == null)
        {
            Debug.LogWarning(_soundName + " não foi encontrado na lista de sons!");
            return null;
        }

        return sound.source;
    }

    public void PlaySound(string _soundName)
    {
        try
        {
            GetAudioSource(_soundName).Play();
        }
        catch (System.Exception)
        {
            Debug.LogError(_soundName + " não pode ser tocado pois não esta contido na lista de sons!");
        }
    }

    public void MuteSoundByType(bool _type)//True for Music and False for FX
    {
        foreach (Sound sound in soundList)
        {
            if (sound.soundType == _type)
            {
                sound.source.mute = !sound.source.mute;
            }
        }
    }
}
