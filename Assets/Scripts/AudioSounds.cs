using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSounds : MonoBehaviour
{
    AudioSource Audio;

    public static AudioSounds instance;


    private void Awake()
    {
        instance = this;
        Audio = GetComponent<AudioSource>();
    }

    public void AudioPlayOneShot(AudioClip audio, float vol)
    {
        Audio.PlayOneShot(audio,vol);
    
    }
}
