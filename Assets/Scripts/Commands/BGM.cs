using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;

#if UNITY_EDITOR
[CustomEditor(typeof(Command))]
#endif
public class BGM : Command
{
    GameManager gameManager;
    public BGM()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public override void useCommand(string commandContent, string[] story)
    {
        switch (commandContent) 
        {
            case "STOP":
                gameManager.audioClipList.audioStop();
                break;
            case "PARSE":
                gameManager.audioClipList.audioParse();
                break;
            case "REPLAY":
                gameManager.audioClipList.audioReplay();
                break;
            default:
                gameManager.audioClipList.audioPlay(commandContent);
                break;
        }
        GameManager.commandExecuting = false;
    }
}
