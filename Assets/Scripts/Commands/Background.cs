using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Command))]
#endif

public class Background : Command
{
    GameManager gameManager;
    public Background()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //バックグラウンド
    public override void useCommand(string commandContent, string[] story)
    {
        gameManager.backgroundManager.BGChanger(commandContent);
        GameManager.commandExecuting = false;
    }
}
