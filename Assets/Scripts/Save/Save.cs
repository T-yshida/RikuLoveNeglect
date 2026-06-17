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

        save.specialFlags = gameManager.sEndFlag.SFlags
            .Select(x => new FlagSaveData
            {
                place = x.place,
                flags = x.flags.Select(f => f.flag.ToArray()).ToList()
            })
            .ToList();
    }
}
