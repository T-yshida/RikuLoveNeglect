using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

/*
 * content要素番号
 * 0:コマンド
 * 1:キャラ名
 * 2:立ち絵名or移動先位置
 * 3:初期位置orサイズ
 * 4:初期サイズor秒数
 * 
 * 立ち絵名 enumとあわせる
 */
public class CharactorViewManager : MonoBehaviour
{
    //CharPanelにアタッチ
    public CharactorView[] charactorViews;
    //動かすキャラクター
    CharactorView currentView;

    public void charactorSelect(string[] content)
    {
        currentView = charactorViews.FirstOrDefault(x => x.charId.Equals(content[1]));
        switch (content[0])
        {
            case "出場":
                Fade(content);
                break;
            case "退場":
                Fade(content);
                break;
            case "移動":
                MoveScale(content);
                break;
            case "立ち絵変更":
                changeArt(content);
                break;
            default:
                Debug.Log("誤字");
                break;
        }
    }

    void Fade(string[] sts)
    {
        if (sts[0].Equals("退場"))
        {
            currentView.Fade(0, 0.3f);
            GameManager.commandExecuting = false;
            return;
        }
        else
        {
            //ポジションx,yを分割する処理
            var vect = sts[3].Split(',');
            var x = int.Parse(vect[0]);
            var y = int.Parse(vect[1]);

            //スケールをfloat変換する
            var scale = float.Parse(sts[4]);

            //これの分　加算する
            currentView.Move(new Vector2(x, y), 0);
            //これの分　掛ける
            currentView.Scale(scale, 0);

            currentView.SetSprite(charEnumSelect(sts[2]));
            currentView.Fade(1, 0.3f);
            
        }
        GameManager.commandExecuting = false;
    }

    void MoveScale(string[] sts)
    {
        //ポジションx,yを分割する処理
        var vect = sts[2].Split(',');
        var x = int.Parse(vect[0]);
        var y = int.Parse(vect[1]);

        //スケールをfloat変換する
        var scale = float.Parse(sts[3]);
        //秒数をfloat変換する
        var sec = float.Parse(sts[4]);
        //これの分　加算する
        currentView.Move(new Vector2(x, y), sec);
        //これの分　掛ける
        currentView.Scale(scale, sec);
        GameManager.commandExecuting = false;
    }

    void changeArt(string[] sts)
    {
        currentView.SetSprite(charEnumSelect(sts[2]));
        GameManager.commandExecuting = false;
    }

    //キャラごとにEnumが違うため、ここにて検索をかける
    int charEnumSelect(string face)
    {
        int idx = 0;
        switch (currentView.charId) {
            case "kanojo":
                var kanojoFace = (CharKanojo.imageTypeKanojo)Enum.Parse(typeof(CharKanojo.imageTypeKanojo), face);
                idx = (int)kanojoFace;
                break;
            case "homekanojo":
                var homeKanojoFace = (CharHomeKanojo.imageTypeHomeKanojo)Enum.Parse(typeof(CharHomeKanojo.imageTypeHomeKanojo), face);
                idx = (int)homeKanojoFace;
                break;
            case "inari":
                var inariFace = (CharInari.imageTypeInari)Enum.Parse(typeof(CharInari.imageTypeInari), face);
                idx = (int)inariFace;
                break;
        }

        return idx;
    }
}
