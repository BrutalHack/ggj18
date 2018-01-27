using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoopMusic : MonoBehaviour
{

    public enum WhatToPlay { Music, Loki, Odin }
    public WhatToPlay PlayOnStart;
    public AudioClip Music;
    public AudioClip Loop;

    public AudioClip Loki;
    public AudioClip LokiLoop;

    public AudioClip Odin;
    public AudioClip OdinLoop;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();


        if (PlayOnStart == WhatToPlay.Loki)
        {
            StartCoroutine(playMusic(Loki, LokiLoop));
        }
        else if (PlayOnStart == WhatToPlay.Odin)
        {
            StartCoroutine(playMusic(Odin, OdinLoop));
        }
        else
        {
            StartCoroutine(playMusic(Music, Loop));
        }
    }

    IEnumerator playMusic(AudioClip clip, AudioClip loop)
    {
        audioSource.clip = clip;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        if (loop != null)
        {
            audioSource.loop = true;
            audioSource.clip = loop;
            audioSource.Play();
        }
    }

    public void PlayLoki()
    {
        audioSource.Stop();
        playMusic(Loki, LokiLoop);
    }

    public void PlayOdin()
    {
        audioSource.Stop();
        playMusic(Odin, OdinLoop);
    }
}
