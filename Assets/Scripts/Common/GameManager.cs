using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //テスト
    public string testString = "ステステ";

    //選択肢ボタンを生成する親オブジェクト
    public Transform choiseContent;

    //ゲーム画面に色々表示するcanvas
    public Canvas fieldCanvas;
    //フェードインアウトの時に使う
    public CanvasGroup fadeCanvasGroup;
    //背景を管理するスクリプト
    public BackgroundManager backgroundManager;
    //キャラクターの動きを管理するスクリプト
    public CharactorViewManager charactorViewManager;

    //テキストファイルから読み込んだストーリが何行目かを指す
    public static int storyIndex { get; set; }

    //病みメータ
    public static int illMeter { get; set; }

    //親愛度
    public static int loveMeter { get; set; }

    //コマンド実行状態
    public static bool commandExecuting { get; set; }
    
    //トーク中
    public static bool talking { get; set; }

    //キャラの初期位置
    public static Vector2 initialPosition { get; } = new Vector2(0, -700);
}
