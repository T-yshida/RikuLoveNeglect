using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

#if UNITY_EDITOR
[CustomEditor(typeof(Command))]
#endif

public class SpecialFlag : Command
{
    GameManager gameManager;

    public SpecialFlag()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public override void useCommand(string commandContent, string[] story)
    {
        string[] contents = commandContent.Split('/');
        var place = (GameManager.place)Enum.Parse(typeof(GameManager.place), contents[0]);
        var index = int.Parse(contents[1]);

        GameManager.copySEndFlag.SFlags[(int)place]
            .flags[index]
            .Set();

        GameManager.commandExecuting = false;
    }
}
