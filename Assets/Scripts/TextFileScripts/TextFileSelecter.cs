using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class TextFileSelecter : MonoBehaviour
{
    [SerializeField] TextFileReader reader;
    [SerializeField] public List<textFile> textFiles = new List<textFile>();

    private void Start()
    {
        fileSelecter();
    }

    public void fileSelecter()
    {
        var textfile = textFiles.FirstOrDefault(x => x.place == GameManager.datePlace);

        List<int> candidates = new List<int>();
        List<TextAsset> tmpAsset = new List<TextAsset>();
        TextAsset ta = null;

        ////病みメータ高い
        if (GameManager.illMeter >= 60) candidates.Add(1);
        ////鬱モード
        if (GameManager.isDepression) candidates.Add(2);
        ////pmモード
        if (GameManager.isPm) candidates.Add(3);

        if (candidates.Count > 0)
        {
            int result = candidates[UnityEngine.Random.Range(0, candidates.Count)];

            switch (result)
            {
                //病みメ高い
                case 1:
                    Debug.Log("1の処理");
                    tmpAsset = textfile.textFileContents.FirstOrDefault(x => x.contentType == textFileContent.ContentType.HIILLNESS).textFiles;
                    ta = tmpAsset[UnityEngine.Random.Range(0,tmpAsset.Count)];
                    break;
                //鬱
                case 2:
                    Debug.Log("2の処理");
                    tmpAsset = textfile.textFileContents.FirstOrDefault(x => x.contentType == textFileContent.ContentType.DEPRESSION).textFiles;
                    ta = tmpAsset[UnityEngine.Random.Range(0, tmpAsset.Count)];
                    break;
                //pm
                case 3:
                    Debug.Log("3の処理");
                    tmpAsset = textfile.textFileContents.FirstOrDefault(x => x.contentType == textFileContent.ContentType.PM).textFiles;
                    ta = tmpAsset[UnityEngine.Random.Range(0, tmpAsset.Count)];
                    break;
            }
        }
        else
        {
            tmpAsset = textfile.textFileContents.FirstOrDefault(x => x.contentType == textFileContent.ContentType.NORMAL).textFiles;
            ta = tmpAsset[UnityEngine.Random.Range(0, tmpAsset.Count)];
        }

        reader.fileReader(ta);
    }
}


[System.Serializable]
public class textFile
{
    public GameManager.place place;
    public List<textFileContent> textFileContents;
    public List<TextAsset> normalEnd = new List<TextAsset>();
    public List<TextAsset> specialEnd = new List<TextAsset>();
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
