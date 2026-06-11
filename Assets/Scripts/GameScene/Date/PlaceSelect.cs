using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlaceSelect : MonoBehaviour
{
    string moveSceneName = "NovelScene";
    
    public void selectPlace(string place)
    {
        GameManager.datePlace = (GameManager.place)Enum.Parse(typeof(GameManager.place), place);
        FadeManager.Instance.LoadSceneWithFade(moveSceneName);
    }
}
