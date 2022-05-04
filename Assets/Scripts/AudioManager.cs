using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    [HideInInspector]
    public int difficulty = 0;
    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            Play("Theme");
            return;
        }
        s.source.Play();
    }

    public void Stop()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    public void StopAndPlay()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "level" + difficulty.ToString());
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
        Play("Theme");
    }

    public void PlayTheme()
    {
        Invoke("Play", 0.4f);
    }
    public void Play()
    {
        Play("Theme");
    }
}
