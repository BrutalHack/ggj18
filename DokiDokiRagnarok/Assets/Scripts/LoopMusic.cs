using System.Collections;
using UnityEngine;

public class LoopMusic : MonoBehaviour
{
    public enum MusicList
    {
        Music,
        Loki,
        Odin,
        None
    }

    public float Volume = 0.25f;

    public MusicList PlayOnStart;
    public AudioClip Music;
    public AudioClip Loop;

    public AudioClip Loki;
    public AudioClip LokiLoop;

    public AudioClip Odin;
    public AudioClip OdinLoop;

    private AudioSource audioSource;

    public bool Persistent = false;

    private MusicList nowPlaying = MusicList.None;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = Volume;

        if (Persistent)
        {
            DontDestroyOnLoad(this.gameObject);
        }

        if (PlayOnStart == MusicList.Loki)
        {
            StartCoroutine(playMusic(Loki, LokiLoop));
        }
        else if (PlayOnStart == MusicList.Odin)
        {
            StartCoroutine(playMusic(Odin, OdinLoop));
        }
        else if (PlayOnStart == MusicList.Music)
        {
            StartCoroutine(playMusic(Music, Loop));
        }
    }

    IEnumerator playMusic(AudioClip clip, AudioClip loop)
    {
        if (clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }

        if (loop)
        {
            audioSource.loop = true;
            audioSource.clip = loop;
            audioSource.Play();
        }
    }

    public void PlayLoki()
    {
        if (Loki && LokiLoop && nowPlaying != MusicList.Loki)
        {
            audioSource.Stop();
            StartCoroutine(playMusic(Loki, LokiLoop));
            nowPlaying = MusicList.Loki;
        }
    }

    public void PlayOdin()
    {
        if (Odin && OdinLoop && nowPlaying != MusicList.Odin)
        {
            audioSource.Stop();
            StartCoroutine(playMusic(Odin, OdinLoop));
            nowPlaying = MusicList.Odin;
        }
    }

    public void PlayMainTheme()
    {
        if (Music && Loop && nowPlaying != MusicList.Music)
        {
            audioSource.Stop();
            StartCoroutine(playMusic(Music, Loop));
            nowPlaying = MusicList.Music;
        }
    }
}