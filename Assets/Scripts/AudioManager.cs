// Author: Injae Cho
// Contributor(s): 

using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sfxArray;

    void Awake()
    {
        foreach (Sound s in sfxArray)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sfxArray, sound => sound.name == name);
        s.source.Play();
    }
}
