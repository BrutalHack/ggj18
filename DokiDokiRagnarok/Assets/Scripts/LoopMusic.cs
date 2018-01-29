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

    private AudioSource _audioSource;

    public bool Persistent = false;

    private MusicList _nowPlaying = MusicList.None;
    private Coroutine _currentCoroutine;

    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.volume = Volume;

        if (Persistent)
        {
            DontDestroyOnLoad(this.gameObject);
        }

        PlayMusic(PlayOnStart);
    }

    private IEnumerator PlayMusicCoroutine(AudioClip clip, AudioClip loop)
    {
        if (clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
            yield return new WaitForSeconds(_audioSource.clip.length);
        }

        if (loop)
        {
            _audioSource.loop = true;
            _audioSource.clip = loop;
            _audioSource.Play();
        }
    }

    private void PlayMusic(MusicList song)
    {
        if (_nowPlaying == song)
        {
            return;
        }

        AudioClip clip = null;
        AudioClip loop = null;
        switch (song)
        {
            case MusicList.Loki:
                clip = Loki;
                loop = LokiLoop;
                break;
            case MusicList.Odin:
                clip = Odin;
                loop = OdinLoop;
                break;
            case MusicList.Music:
                clip = Music;
                loop = Loop;
                break;
            case MusicList.None:
                return;
        }

        _audioSource.Stop();
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(PlayMusicCoroutine(clip, loop));
        _nowPlaying = song;
    }

    public void PlayLoki()
    {
        PlayMusic(MusicList.Loki);
    }

    public void PlayOdin()
    {
        PlayMusic(MusicList.Odin);
    }

    public void PlayMainTheme()
    {
        PlayMusic(MusicList.Music);
    }
}