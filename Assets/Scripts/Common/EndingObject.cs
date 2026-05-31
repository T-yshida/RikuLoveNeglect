using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EndingObject : ScriptableObject
{
    [SerializeField] public List<Ending> ending;
}

[System.Serializable]
public class Ending
{
    [SerializeField] public GameManager.place place;
    [SerializeField] public List<EndingContent> endingContents; 
}

[System.Serializable]
public class EndingContent 
{
    [SerializeField] public string description;
    [SerializeField] public bool end;
}
