using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

[CreateAssetMenu]
public class SpecialEndFlag : ScriptableObject
{
    [SerializeField] public List<SFlags> SFlags = new List<SFlags>();
    
}

[System.Serializable]
public class SFlags
{
    [SerializeField] public GameManager.place place;
    [SerializeField] public List<Flags> flags;
}

[System.Serializable]
public class Flags
{
    [SerializeField] public string description;
    [SerializeField] public bool[] flag;

    public void Set()
    {
        int cnt = 0;
        while (true)
        {
            if(cnt < flag.Length)
            {
                if (flag[cnt] == false)
                {
                    flag[cnt] = true;
                    break;
                }
                cnt++;
            }
            else
            {
                break;
            }
        }
    }

    public bool allFlag()
    {
        return flag.All(x => x);
    }
}
