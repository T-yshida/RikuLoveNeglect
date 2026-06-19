using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource seSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayBGM(AudioClip clip)
    {
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void ParseBGM()
    {
        bgmSource.Pause();
    }

    public void RestartBGM()
    {
        if(bgmSource.clip != null)
        {
            bgmSource.Play();
        }
    }

    public void PlaySE(AudioClip clip)
    {
        seSource.PlayOneShot(clip);
    }
}