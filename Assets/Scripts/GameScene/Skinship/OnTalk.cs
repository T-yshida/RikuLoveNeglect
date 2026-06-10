using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OnTalk : MonoBehaviour
{
    //index 1 がpmになるよ
    [SerializeField] TalkContList[] talkCont = new TalkContList[2];
    [SerializeField] CanvasGroup talkPanel;
    [SerializeField] Text text;

    public void Talk(TouchManager.Point point)
    {
        CancelInvoke();
        string[] content;
        //pmモードとノーマルで話す内容変わる
        if (GameManager.isPm)
        {
            content = talkCont[1].talkList.FirstOrDefault(x => x.point == point).talkContent;
        }
        else
        {
            content = talkCont[0].talkList.FirstOrDefault(x => x.point == point).talkContent;
        }

        text.text = content[Random.Range(0, content.Length)];

        talkPanel.alpha = 1.0f;

        Invoke("fadeTalkPanel",3.5f);
    }

    void fadeTalkPanel()
    {
        talkPanel.DOFade(0, 0.3f);
    }
}


[System.Serializable]
public class TalkContList 
{
    [SerializeField] public TalkCont[] talkList = new TalkCont[2];
}

[System.Serializable]
public class TalkCont 
{
    [SerializeField] public TouchManager.Point point;
    [SerializeField] public string[] talkContent;
}
