using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlaceSelect : MonoBehaviour
{
    string moveSceneName = "NovelScene";

    [SerializeField] private GameObject _parent;
    
    public void selectPlace(string place)
    {
        GameManager.restDate--;

        GameManager.datePlace = (GameManager.place)Enum.Parse(typeof(GameManager.place), place);
        FadeManager.Instance.LoadSceneWithFade(moveSceneName);
    }

    void canDate()
    {
        var children = GetChildren(_parent);
        for (var i = 0; i < children.Length; i++)
        {
            var button = children[i].GetComponent<Button>();
            //デート回数が残り0だった場合はボタンを押せなくする
            if (GameManager.restDate <= 0)
            {
                button.interactable = false;
            }
            //デート回数が残り0ではない場合ボタンを押せるようにする
            else
            {
                button.interactable = true;
            }
        }
    }

    private GameObject[] GetChildren(GameObject parent)
    {
        // 親オブジェクトのTransformを取得
        var parentTransform = parent.transform;

        // 子オブジェクトを格納する配列作成
        var children = new GameObject[parentTransform.childCount];

        // 0～個数-1までの子を順番に配列に格納
        for (var i = 0; i < children.Length; ++i)
        {
            // Transformからゲームオブジェクトを取得して格納
            children[i] = parentTransform.GetChild(i).gameObject;
        }

        // 子オブジェクトが格納された配列
        return children;
    }
}
