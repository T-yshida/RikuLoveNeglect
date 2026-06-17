using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public List<FlagSaveData> specialFlags;
}

[System.Serializable]
public class FlagSaveData
{
    public GameManager.place place;
    public List<bool[]> flags;
}