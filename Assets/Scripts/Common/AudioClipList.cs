using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipList : MonoBehaviour
{
    [SerializeField] public List<SongList> clipList;

    public void audioPlay(string songIdx)
    {
        int idx = int.Parse(songIdx);
        AudioClip clip = clipList[idx].audio;
        AudioManager.Instance.PlayBGM(clip);
    }

    public void audioStop()
    {
        AudioManager.Instance.StopBGM();
    }

    public void audioParse()
    {
        AudioManager.Instance.ParseBGM();
    }

    public void audioReplay()
    {
        AudioManager.Instance.RestartBGM();
    }
}

[System.Serializable]
public class SongList 
{
    [SerializeField] public string songName;
    [SerializeField] public AudioClip audio;
}

