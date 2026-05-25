using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTalkManager : MonoBehaviour
{
    [SerializeField] public List<TalkContent> talkContent = new List<TalkContent>();
}

[System.Serializable]

public class TalkContent 
{
    public string contentType;
    public List<string> contents = new List<string>();
}

