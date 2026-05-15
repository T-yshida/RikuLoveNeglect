using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Command))]
#endif

public class CharArt : Command
{
    public override void useCommand(string commandContent, string[] story)
    {
        
    }
}
