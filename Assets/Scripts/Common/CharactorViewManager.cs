using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            currentView.Fade(0);
            GameManager.commandExecuting = false;
            return;
        }
        else
        {
            currentView.SetSprite(sts[2]);
            currentView.Fade(1);
        }
        GameManager.commandExecuting = false;
    }

    void MoveScale(string[] sts)
    {
        //CharactorViewManagerのMoveとScale呼ぶ
    }

    void changeArt(string[] sts)
    {
        currentView.SetSprite(sts[2]);
        GameManager.commandExecuting = false;
    }
}
