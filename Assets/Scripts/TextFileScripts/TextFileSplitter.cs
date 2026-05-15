using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextFileSplitter
{
    public string[] splitTextFile(TextAsset textFile)
    {
        if (textFile != null)
        {
            string[] splits = textFile.text.Split('\n');
            return splits;
        }

        return null;
    }
}
