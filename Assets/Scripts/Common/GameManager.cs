using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;


[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    //テスト
    public string testString = "ステステ";

    //選択肢ボタンを生成する親オブジェクト
    public Transform choiseContent;

    //ゲーム画面に色々表示するcanvas
    public Canvas fieldCanvas;
    //背景を管理するスクリプト
    public BackgroundManager backgroundManager;
    //キャラクターの動きを管理するスクリプト
    public CharactorViewManager charactorViewManager;
    //エンディング管理
    public EndingObject endingObject;
    //特殊エンディングフラグ
    public SpecialEndFlag sEndFlag;
    //特殊エンディングフラグのコピー。↑のやつをリセットさせるため
    public static SpecialEndFlag copySEndFlag;
    //エンディング行った後、変数たちをリセットする
    public EndReset endReset;
    //BGMのリスト
    public AudioClipList audioClipList;
    //セーブ
    public Save save;
    //ロード
    public Load load;

    //テキストファイルから読み込んだストーリが何行目かを指す
    public static int storyIndex { get; set; }

    //病みメータ
    public static int illMeter { get; set; }

    //鬱モード
    public static bool isDepression { get; set; }

    //pm
    public static bool isPm { get; set; }

    //親愛度
    public static int loveMeter { get; set; }

    //コマンド実行状態
    public static bool commandExecuting { get; set; }
    
    //トーク中
    public static bool talking { get; set; }

    //音声ボリューム
    public static int volume { get; set; } = 100;

    //通知
    public static bool isNotice {  get; set; }

    //キャラの初期位置
    public static Vector2 initialPosition { get; } = new Vector2(0, -700);

    //デート場所を保持
    public static place datePlace { get; set; }

    //エンド数
    public static int endCount { get; } = 14;

    //場所を表すenum
    public enum place 
    {
        SHOPPING,
        THEMEPARK,
        HOME,
        KAIKATU,
        SEA,
        CAFE,
        FOREST,
        SHRINE,
        AQUA
    }

    private void Awake()
    {
        copySEndFlag = Instantiate(sEndFlag);
    }

    public static void loveMeterPlus(int plus)
    {
        loveMeter += plus;
    }

    //plusがマイナスになる可能性がある
    //メータ上げ下げは全部ここ
    public static void illMeterPlus(int plus)
    {
        if (illMeter + plus < 0)
        {
            illMeter = 0;
        }
        else if(illMeter + plus > 100)
        {
            illMeter += 100;
        }
        else
        {
            illMeter += plus;
        }
    }
}
