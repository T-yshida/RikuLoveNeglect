using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Command))]
#endif


public class ValueChange : Command
{
    public override void useCommand(string commandContent, string[] story)
    {
        string[] contents = commandContent.Split('/');
        string varName = contents[0];
        string value = contents[1];

        switch (varName) 
        {
            case "病みメータ":
                GameManager.illMeter += int.Parse(value);
                break;
            case "親愛度":
                GameManager.loveMeter += int.Parse(value);
                break;
            default:
                Debug.Log("誤字か、変数がありません");
                break;
        }

        GameManager.commandExecuting = false;

    }
}
