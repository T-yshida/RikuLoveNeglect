using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipList : MonoBehaviour
{
    [SerializeField] public List<SongList> clipList;

    public void audioPlay(string songName)
    {
        AudioClip clip = clipList.Find(x => x.songName.Equals(songName)).audio;
        AudioManager.Instance.PlayBGM(clip);
    }
}

[System.Serializable]
public class SongList 
{
    [SerializeField] public string songName;
    [SerializeField] public AudioClip audio;
}

