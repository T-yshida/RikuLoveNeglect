using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CauseList : MonoBehaviour
{
    [SerializeField] Button rightButton;
    [SerializeField] Button leftButton;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] causePanels;
    [SerializeField] List<causeList> lists = new List<causeList>();

    bool[] endingBool;
    //４つずつ足したり引いたりする
    int index = 4;
    const int PANELCOUNT = 4;

    private void Awake()
    {
        endingBool = gameManager.endingObject.ToArray();
        Debug.Log(endingBool[0]);
    }

    private void OnEnable()
    {
        index = PANELCOUNT;
        leftButton.interactable = false;
        NextPage(0, PANELCOUNT);
    }

    public void RightButton()
    {
        for(int i = 0;i < causePanels.Length; i++)
        {
            causePanels[i].SetActive(false);
        }

        //左端だった場合
        if (!leftButton.interactable)
        {
            leftButton.interactable = true;
        }

        //リストを超えた場合の処理
        if (index + PANELCOUNT >= lists.Count)
        {
            index += PANELCOUNT;
            rightButton.interactable = false;
            NextPage(index - PANELCOUNT, lists.Count);

            Debug.Log("RightButton : if");
        }
        else
        {
            index += PANELCOUNT;
            NextPage(index - PANELCOUNT, index);

            Debug.Log("RightButton : else");
        }
        Debug.Log(index);
    }

    public void LeftButton()
    {
        for (int i = 0; i < causePanels.Length; i++)
        {
            causePanels[i].SetActive(false);
        }

        //右端
        if (!rightButton.interactable)
        {
            rightButton.interactable = true;
        }

        //リストゼロの時の処理
        if (index - PANELCOUNT <= PANELCOUNT)
        {
            leftButton.interactable = false;
            index = PANELCOUNT;
            //0～3を表示するためnextを使う
            NextPage(0, PANELCOUNT);
            
            Debug.Log("LeftButton : if");
        }
        else
        {
            index -= PANELCOUNT;
            PrevPage(index, index - PANELCOUNT);

            Debug.Log("LeftButton : else");
        }
        Debug.Log(index);
    }


    private void NextPage(int initial, int end)
    {
        for (int i = initial; i < end; i++)
        {
            causePanels[i % PANELCOUNT].SetActive(true);
            var image = causePanels[i % PANELCOUNT].GetComponentInChildren<Image>();
            var text = causePanels[i % PANELCOUNT].GetComponentInChildren<Text>();

            if (endingBool[i])
            {
                image.sprite = lists[i].image;
                text.text = lists[i].description;
            }
            else
            {
                text.text = "未達";
            }
        }
    }

    private void PrevPage(int initial, int end)
    {
        for (int i = initial; i >= end; i--)
        {
            causePanels[i % PANELCOUNT].SetActive(true);
            var image = causePanels[i % PANELCOUNT].GetComponentInChildren<Image>();
            var text = causePanels[i % PANELCOUNT].GetComponentInChildren<Text>();

            if (endingBool[i])
            {
                image.sprite = lists[i].image;
                text.text = lists[i].description;
            }
            else
            {
                text.text = "未達";
            }
        }
    }
}

[System.Serializable]
public class causeList
{
    [SerializeField] public Sprite image;
    [SerializeField] public string description;
}
