using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtonUISet : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image thisImage;
    [SerializeField] Text text;

    private void Start()
    {
        int ran = Random.Range(0, sprites.Length);
        thisImage.sprite = sprites[ran];
        if(ran == 2)
        {
            text.color = Color.white;
        }
    }
}
