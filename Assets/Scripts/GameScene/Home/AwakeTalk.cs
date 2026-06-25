using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AwakeTalk : MonoBehaviour
{
    [SerializeField] CanvasGroup talkPanel;
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.lastTime != DateTime.MinValue && GameManager.firstTalkFlag)
        {
            GameManager.firstTalkFlag = false;
            TimeSpan diffTime = DateTime.Now - GameManager.lastTime;
            string fomatText = FormatTimeSpan(diffTime);

            text.text = "‹v‚µ‚Ô‚èA" + fomatText + "‚Ô‚è‚¾‚Ë";
            talkPanel.alpha = 1.0f;
            Invoke("fadeTalkPanel", 5.0f);
        }
    }

    void fadeTalkPanel()
    {
        talkPanel.DOFade(0, 0.3f);
    }

    string FormatTimeSpan(TimeSpan ts)
    {
        StringBuilder sb = new StringBuilder();

        if (ts.Days > 0)
            sb.Append($"{ts.Days}“ú");

        if (ts.Hours > 0)
            sb.Append($"{ts.Hours}ŠÔ");

        if (ts.Minutes > 0)
            sb.Append($"{ts.Minutes}•ª");

        if (ts.Seconds > 0)
            sb.Append($"{ts.Seconds}•b");

        // ‘S•”0‚¾‚Á‚½ê‡
        if (sb.Length == 0)
            sb.Append("0•b");

        return sb.ToString();
    }
}
