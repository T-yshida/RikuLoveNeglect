using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

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

        gameManager.endingObject.ending.Find(x => x.place == pName).endingContents[index].end = true;
        gameManager.endReset.Reset();

        GameManager.commandExecuting = false;
    }
}
