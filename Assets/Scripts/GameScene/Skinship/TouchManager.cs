using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class TouchManager : MonoBehaviour
{
    [SerializeField] OnTalk onTalk;
    [SerializeField] SkinshipFadeInOut fade;

    [SerializeField] GameObject fadeObj;
    [SerializeField] Text text;

    [SerializeField] GameObject[] backGroups;

    private int touchCount;
    private int desCount;
    private int healCount;
    private CanvasGroup canvas;

    public enum Point 
    {
        DESIRE,
        HEAL
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        touchCount = 5;
        desCount = 0;
        healCount = 0;
    }

    public void OnTouch(Point tPoint)
    {
        onTalk.Talk(tPoint);
        Debug.Log(tPoint);
        touchCount--;
        switch (tPoint)
        {
            case Point.DESIRE:
                desCount++;
                break;
            case Point.HEAL:
                healCount++; 
                break;
        }

        if(touchCount == 0)
        {
            canvas = backGroups.FirstOrDefault(x => x.activeSelf == true).GetComponent<CanvasGroup>();
            canvas.blocksRaycasts = false;
            CancelInvoke();
            if(desCount > healCount)
            {
                //マグ
                //いくつか足す
                //pmモードの時は病みメup
                if (GameManager.isPm)
                {
                    GameManager.illMeterPlus(Random.Range(10, 15));
                }
                else
                {
                    //鬱モードの時は上がり幅下がる
                    GameManager.loveMeterPlus(GameManager.isDepression ? Random.Range(5, 15) : Random.Range(15, 30));
                    Debug.Log("loveMeter : " + GameManager.loveMeter);
                }
                text.text = "まぐわった…";
                fade.doFade(fadeObj.GetComponent<CanvasGroup>());
            }
            else if(desCount < healCount)
            {
                //イヤし
                //いくつか引く
                GameManager.illMeterPlus(Random.Range(-1, -5));
                Debug.Log("illMeter : " + GameManager.illMeter);
                //30%の確率で鬱モード解除
                if (GameManager.isDepression)
                {
                    GameManager.isDepression = Random.Range(0, 100) <= 30 ? false : true;
                }
                text.text = "癒された…";
                fade.doFade(fadeObj.GetComponent<CanvasGroup>());
            }
            Reset();
            Invoke("textClear", 3f); ;
        }
    }

    void textClear()
    {
        text.text = "";
        canvas.blocksRaycasts = true;
    }
}
