using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CauseList : MonoBehaviour
{
    [SerializeField] Button rightButton;
    [SerializeField] Button leftButton;
    [SerializeField] GameObject[] causePanels;
    [SerializeField] List<causeList> lists = new List<causeList>();

    //４つずつ足したり引いたりする
    int index = 0;

    private void OnEnable()
    {
        index = 0;
        leftButton.interactable = false;

        for (int i = 0; i < 4; i++)
        {
            var image = causePanels[i].GetComponentInChildren<Image>();
            var text = causePanels[i].GetComponentInChildren<Text>();

            image.sprite = lists[i].image;
            text.text = lists[i].description;
        }
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
        if (index + 4 >= lists.Count)
        {
            rightButton.interactable = false;
            for (int i = index; i < lists.Count; i++)
            {
                causePanels[i % 4].SetActive(true);
                var image = causePanels[i % 4].GetComponentInChildren<Image>();
                var text = causePanels[i % 4].GetComponentInChildren<Text>();

                image.sprite = lists[i].image;
                text.text = lists[i].description;
            }
        }
        else
        {
            index += 4;
            for(int i = index;i < index + 4; i++)
            {
                causePanels[i % 4].SetActive(true);
                var image = causePanels[i % 4].GetComponentInChildren<Image>();
                var text = causePanels[i % 4].GetComponentInChildren<Text>();

                image.sprite = lists[i].image;
                text.text = lists[i].description;
            }
        }
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
        if (index - 4 <= 0)
        {
            rightButton.interactable = false;
            index = 0;
            for (int i = 0; i < 4; i++)
            {
                causePanels[i % 4].SetActive(false);
                var image = causePanels[i].GetComponentInChildren<Image>();
                var text = causePanels[i].GetComponentInChildren<Text>();

                image.sprite = lists[i].image;
                text.text = lists[i].description;
            }
        }
        else
        {
            index -= 4;
            for (int i = index; i < index + 4; i++)
            {
                causePanels[i % 4].SetActive(false);
                var image = causePanels[i % 4].GetComponentInChildren<Image>();
                var text = causePanels[i % 4].GetComponentInChildren<Text>();

                image.sprite = lists[i].image;
                text.text = lists[i].description;
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
