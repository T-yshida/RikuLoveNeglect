using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] public List<background> backgrounds = new List<background>();
    public int oldIndex = -1;

    public void BGChanger(string name)
    {
        //Šù‚É•\Ž¦‚µ‚Ä‚ ‚é”wŒi‚ª‚ ‚éê‡‚Í”ñ•\Ž¦‚É‚·‚é
        if(oldIndex != -1)
        {
            backgrounds[oldIndex].image.SetActive(false);
        }
        var bg = backgrounds.FirstOrDefault(x => x.name == name);
        bg.image.SetActive(true);
        oldIndex = backgrounds.FindIndex(x => x.name == name);
    }
}

[System.Serializable]
public class background 
{
    public string name;
    public GameObject image;
}

