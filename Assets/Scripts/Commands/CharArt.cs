using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;

#if UNITY_EDITOR
[CustomEditor(typeof(Command))]
#endif

public class CharArt : Command
{
    GameManager gameManager;
    public CharArt()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //パースだけを行う
    public override void useCommand(string commandContent, string[] story)
    {
        gameManager.charactorViewManager.charactorSelect(commandContent.Split('/'));
    }
}
