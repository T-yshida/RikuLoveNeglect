using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextFileSelecter : MonoBehaviour
{
    [SerializeField] TextFileReader reader;
    [SerializeField] public List<textFile> textFiles = new List<textFile>();
}


[System.Serializable]
public class textFile
{
    public GameManager.place place;
    public List<textFileContent> textFileContents;
}

[System.Serializable]
public class textFileContent
{
    public enum ContentType
    {
        NORMAL,
        DEPRESSION,
        HIILLNESS,
        PM
    }
    public ContentType contentType;
    public List<TextAsset> textFiles = new List<TextAsset>();
}
