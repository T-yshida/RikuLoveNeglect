using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HomeTalkManager : MonoBehaviour
{
    [SerializeField] CanvasGroup talkPanel;
    [SerializeField] Text talkText;
    [SerializeField] CharactorView kanojoView;
    [SerializeField] public List<TalkContent> talkContent = new List<TalkContent>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // UIの上なら無視
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            CancelInvoke();
            homeTalk();

            Debug.Log("ゲーム画面タッチ");
        }
    }

    public void homeTalk()
    {
        List<int> candidates = new List<int>();
        List<string> con = new List<string>();
        List<GameManager.imageTypeKanojo> imgs = new List<GameManager.imageTypeKanojo>();

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
                    //トーク内容
                    con = talkContent[(int)TalkContent.ContentType.HIILLNESS].contents;
                    //表情
                    imgs = talkContent[(int)TalkContent.ContentType.HIILLNESS].imageType;
                    break;
                //鬱
                case 2:
                    Debug.Log("2の処理");
                    //トーク内容
                    con = talkContent[(int)TalkContent.ContentType.DEPRESSION].contents;
                    //表情
                    imgs = talkContent[(int)TalkContent.ContentType.DEPRESSION].imageType;
                    break;
                //pm
                case 3:
                    Debug.Log("3の処理");
                    //トーク内容
                    con = talkContent[(int)TalkContent.ContentType.PM].contents;
                    //表情
                    imgs = talkContent[(int)TalkContent.ContentType.PM].imageType;
                    break;
            }
        }
        else
        {
            //通常
            Debug.Log("4");
            con = talkContent[(int)TalkContent.ContentType.NORMAL].contents;
            //表情
            imgs = talkContent[(int)TalkContent.ContentType.NORMAL].imageType;
        }

        talkText.text = con[UnityEngine.Random.Range(0, con.Count)];
        kanojoView.SetSprite(imgs[UnityEngine.Random.Range(0, imgs.Count)]);
        //トークパネル表示
        talkPanel.alpha = 1;
        //五秒後トークパネル消す
        Invoke("fadeTalkPanel", 5.0f);
    }

    void fadeTalkPanel()
    {
        talkPanel.DOFade(0,0.3f);
    }
}

[System.Serializable]

public class TalkContent
{
    public enum ContentType 
    {
        NORMAL,
        DEPRESSION,
        HIILLNESS,
        PM
    }

    public ContentType contentType;
    public List<GameManager.imageTypeKanojo> imageType = new List<GameManager.imageTypeKanojo>();
    public List<string> contents = new List<string>();
}

