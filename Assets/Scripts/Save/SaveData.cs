using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public bool isFirstPlay;
    public string seasonTime;
    public Season.season season;
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