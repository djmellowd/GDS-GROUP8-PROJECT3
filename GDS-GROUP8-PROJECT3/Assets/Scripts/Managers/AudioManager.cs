﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : Singleton
{
    [SerializeField] AudioMixer mainMixer;
    public Sound[] sounds;

   private  void Awake()
    {
        MakeSingleton();
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.valume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.mixerGroup;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
      mainMixer.SetFloat("Volume", PlayerPrefs.GetFloat("volumeMain"));
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Nie ma takiego dźwięku jak: " + name);
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Nie ma takiego dźwięku jak: " + name);
            return;
        }
        s.source.Stop();
    }
    public void StopLoop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Nie ma takiego dźwięku jak: " + name);
            return;
        }
        s.source.loop = false;
    }
    public void StartLoop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Nie ma takiego dźwięku jak: " + name);
            return;
        }
        s.source.loop = true;
    }
}
