using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;
using DG.Tweening;
using System.Threading.Tasks;

#if UNITY_EDITOR
[CustomEditor(typeof(Command))]
#endif

//エンディング達成したら呼ぶ
public class End : Command
{
    GameManager gameManager;

    public End()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public override void useCommand(string commandContent, string[] story)
    {
        string[] contents = commandContent.Split('/');
        GameManager.place pName = (GameManager.place)Enum.Parse(typeof(GameManager.place), contents[0]);
        int index = int.Parse(contents[1]);

        gameManager.endingObject.ending[(int)pName].endingContents[index].end = true;
        _ = wait();
    }

    async Task wait()
    {
        FadeManager.Instance.FadeCanvasGroup.DOFade(1, 4f);
        await FadeManager.Instance.FadeCanvasGroup.DOFade(1, 4f).AsyncWaitForCompletion();
        gameManager.endReset.Reset();
        FadeManager.Instance.LoadSceneWithFade("TitleScene");
    }
}
