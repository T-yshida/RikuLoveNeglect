using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EndingObject : ScriptableObject
{
    [SerializeField] public List<Ending> ending;

    public bool[] ToArray()
    {
        bool[] retArray = new bool[GameManager.endCount];
        int arrayIndex = 0;
        foreach(Ending end in ending)
        {
            for(int i = 0;i < end.endingContents.Count; i++)
            {
                retArray[arrayIndex] = end.endingContents[i].end;
                arrayIndex++;
            }
        }
        return retArray;
    }
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
