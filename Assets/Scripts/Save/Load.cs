using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Load : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void Awake()
    {
        doLoad();
    }

    public void doLoad()
    {
        SaveData data = null;

        string path = Path.Combine(
            Application.persistentDataPath,
            "save.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
        }

        //以上　ロードに必要なコード
        //以下　ロードした物を変数にセットしていく
        if(data != null)
        {
            GameManager.copySEndFlag.SFlags = data.specialFlags;
            gameManager.endingObject.ending = data.endingFlags;

            GameManager.lastTime     = DateTime.Parse(data.lastTime);
            GameManager.illMeter     = data.illMeter;
            GameManager.loveMeter    = data.loveMeter;
            GameManager.isDepression = data.isDepression;
            GameManager.isPm         = data.isPm;
            GameManager.volume       = data.volume;
            GameManager.isNotice     = data.isNotice;
        }
        
    }
}
