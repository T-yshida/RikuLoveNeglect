using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using DG.Tweening;
using System.Threading.Tasks;

#if UNITY_EDITOR
[CustomEditor(typeof(Command))]
#endif

public class FadeIn : Command
{
    GameManager gameManager;

    public FadeIn()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //フェードイン
    public override void useCommand(string commandContent, string[] story)
    {
        _ = wait(commandContent);
    }

    async Task wait(string commandContent)
    {
        gameManager.fadeCanvasGroup.DOFade(1, float.Parse(commandContent));
        await gameManager.fadeCanvasGroup.DOFade(1, float.Parse(commandContent)).AsyncWaitForCompletion();
        GameManager.commandExecuting = false;
    }
}
