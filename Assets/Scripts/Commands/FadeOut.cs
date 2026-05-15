using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;
using System.Threading.Tasks;

#if UNITY_EDITOR
[CustomEditor(typeof(Command))]
#endif

public class FadeOut : Command
{
    GameManager gameManager;

    public FadeOut()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //フェードアウト
    public override void useCommand(string commandContent, string[] story)
    {
        _ = wait(commandContent);
    }

    async Task wait(string commandContent)
    {
        gameManager.fadeCanvasGroup.DOFade(0, float.Parse(commandContent));
        await gameManager.fadeCanvasGroup.DOFade(0, float.Parse(commandContent)).AsyncWaitForCompletion();
        GameManager.commandExecuting = false;
    }
}
