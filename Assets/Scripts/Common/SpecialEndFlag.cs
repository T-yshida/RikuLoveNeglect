using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
}
