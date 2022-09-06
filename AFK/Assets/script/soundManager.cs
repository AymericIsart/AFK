using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public sound[] sounds;

    private void Awake()
    {
        foreach (sound s in sounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();

            source.clip = s.clip;
            source.pitch = s.pitch;
            source.volume = s.volume;
            source.loop = s.loop;
            s.source = source;
        }
    }

    public void playSound(string name)
    {
        sound s = findSound(name);
        if (s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.LogError(name + " not found in sounds");
        }
    }

    public void stopSound(string name)
    {
        sound s = findSound(name);
        if (s != null)
        {
            s.source.Stop();
        }
        else
        {
            Debug.LogError(name + " not found in sounds");
        }
    }

    public void stopAll()
    {
        foreach (sound s in sounds)
        {
            s.source.Stop();
        }
    }

    public sound findSound(string name)
    {
        return Array.Find(sounds, sound => sound.name == name);
    }
}