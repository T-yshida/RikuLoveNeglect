using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public string lastTime;
    public int illMeter;
    public int loveMeter;
    public bool isDepression;
    public bool isPm;
    public int volume;
    public bool isNotice;
    public List<SFlags> specialFlags;
    public List<Ending> endingFlags;
}