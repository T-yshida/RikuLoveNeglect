using System.IO;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System;

public class Save : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public void doSave()
    {
        SaveData save = new SaveData();

        save.specialFlags = GameManager.copySEndFlag.SFlags;
        save.endingFlags = gameManager.endingObject.ending;

        save.season = GameManager.nowSeason;
        save.seasonTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        save.lastTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        save.illMeter = GameManager.illMeter;
        save.loveMeter = GameManager.loveMeter;
        save.isDepression = GameManager.isDepression;
        save.isPm = GameManager.isPm;
        save.volume = GameManager.volume;
        save.isNotice = GameManager.isNotice;
        save.isFirstPlay = true;

        if ((DateTime.Now - GameManager.seasonTime).TotalDays >= 7)
        {
            save.season = (Season.season)(((int)GameManager.nowSeason + 1) % System.Enum.GetValues(typeof(Season.season)).Length);
            save.seasonTime = DateTime.Now.ToString("O");
        }

        //以下　セーブに必要なモノたち
        string json = JsonUtility.ToJson(save, true);

        string path = Path.Combine(
            Application.persistentDataPath,
            "save.json");

        File.WriteAllText(path, json);
    }

    private void OnApplicationQuit()
    {
        doSave();
    }
}
