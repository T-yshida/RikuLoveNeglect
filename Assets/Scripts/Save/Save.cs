using System.IO;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class Save : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public void doSave()
    {
        SaveData save = new SaveData();

        save.specialFlags = GameManager.copySEndFlag.SFlags;
        save.endingFlags = gameManager.endingObject.ending;

        save.illMeter = GameManager.illMeter;
        save.loveMeter = GameManager.loveMeter;
        save.isDepression = GameManager.isDepression;
        save.isPm = GameManager.isPm;
        save.volume = GameManager.volume;
        save.isNotice = GameManager.isNotice;

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
