using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogObject : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] Text logText;

    public void setTimeText(TimeSpan timeSpan)
    {
        string time = timeSpan.ToString(@"hh\:mm");
        timeText.text = time;
    }

    public void setLogText(string logText)
    {
        this.logText.text = logText;
    }
}
