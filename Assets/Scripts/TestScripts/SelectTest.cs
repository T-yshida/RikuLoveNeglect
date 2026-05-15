using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SelectTest : MonoBehaviour
{
    [SerializeField] TextAsset textAsset;
    [SerializeField] TextFileReader textFileReader;

    private void Start()
    {
        StartCoroutine(textFileReader.fileReader(textAsset));
    }
}
