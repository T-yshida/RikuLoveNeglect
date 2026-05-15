using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SplitterTest : MonoBehaviour
{
    [SerializeField] TextAsset splitterText;
    TextFileSplitter splitterFileSplitter = new TextFileSplitter();

    private void Start()
    {
        string[] contents = splitterFileSplitter.splitTextFile(splitterText);

        foreach (string line in contents)
        {
            Debug.Log(line);
        }
    }
}
