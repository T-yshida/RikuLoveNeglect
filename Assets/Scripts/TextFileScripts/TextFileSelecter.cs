using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TextFileSelecter : MonoBehaviour
{
    [SerializeField] TextFileReader reader;
    [SerializeField] SpecialEndFlag specialEndFlag;
    [SerializeField] public List<textFile> textFiles = new List<textFile>();
    [SerializeField] AnimationCurve probabilityCurve;

    void Start()
    {
        //GameManager.illMeter = 0;
        Debug.Log(GameManager.datePlace);
        float rate = probabilityCurve.Evaluate(GameManager.illMeter);
        bool result = Random.value < rate;
        if (result)
        {
            endFileSelector();
        }
        else
        {
            normalFileSelecter();
        }
        
    }

    public void normalFileSelecter()
    {
        var textfile = textFiles[(int)GameManager.datePlace];

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
            int result = candidates[UnityEngine.Random.Range(0, candidates.Count - 1)];

            switch (result)
            {
                //病みメ高い
                case 1:
                    Debug.Log("1の処理");
                    tmpAsset = textfile.textFileContents[(int)textFileContent.ContentType.HIILLNESS].textFiles;
                    ta = tmpAsset[UnityEngine.Random.Range(0,tmpAsset.Count - 1)];
                    break;
                //鬱
                case 2:
                    Debug.Log("2の処理");
                    tmpAsset = textfile.textFileContents[(int)textFileContent.ContentType.DEPRESSION].textFiles;
                    ta = tmpAsset[UnityEngine.Random.Range(0, tmpAsset.Count - 1)];
                    break;
                //pm
                case 3:
                    Debug.Log("3の処理");
                    tmpAsset = textfile.textFileContents[(int)textFileContent.ContentType.PM].textFiles;
                    ta = tmpAsset[UnityEngine.Random.Range(0, tmpAsset.Count - 1)];
                    break;
            }
        }
        else
        {
            tmpAsset = textfile.textFileContents[(int)textFileContent.ContentType.NORMAL].textFiles;
            ta = tmpAsset[UnityEngine.Random.Range(0, tmpAsset.Count - 1)];
        }

        StartCoroutine(reader.fileReader(ta));
    }

    public void endFileSelector()
    {
        TextAsset ta = null;
        var textfile = textFiles[(int)GameManager.datePlace];
        var spEnd = specialEndFlag.SFlags[(int)GameManager.datePlace];
        if(spEnd != null)
        {
            var spEndFlag = spEnd.flags.Where(x => x.allFlag());
            //スペシャルフラグがある場合
            if (spEndFlag.Count() > 0)
            {
                ta = textfile.specialEnd[Random.Range(0, spEndFlag.Count() - 1)];
                StartCoroutine(reader.fileReader(ta));
                return;
            }
        }

        //ノーマルバットエンド
        if(textfile.normalEnd.Count > 0)
        {
            ta = textfile.normalEnd[Random.Range(0, textfile.normalEnd.Count - 1)];
            StartCoroutine(reader.fileReader(ta));
            return;
        }

        //エンディングがない所だったら
        normalFileSelecter();
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
