using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> backgrounds = new List<GameObject>();
    public int oldIndex = -1;

    public void BGChanger(string name)
    {
        int idx = int.Parse(name);
        //Šù‚É•\¦‚µ‚Ä‚ ‚é”wŒi‚ª‚ ‚éê‡‚Í”ñ•\¦‚É‚·‚é
        if(oldIndex != -1)
        {
            backgrounds[oldIndex].SetActive(false);
        }
        backgrounds[idx].SetActive(true);
        oldIndex = idx;
    }

    public void BGRandomChanger()
    {
        if(oldIndex != -1)
        {
            backgrounds[oldIndex].SetActive(false);
        }
        var bgIdx = Random.Range(0, backgrounds.Count);
        backgrounds[bgIdx].SetActive(true);
        oldIndex = bgIdx;
    }
}

