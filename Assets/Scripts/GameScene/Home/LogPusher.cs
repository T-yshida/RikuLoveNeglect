using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class LogPusher : MonoBehaviour
{
    //朝の時間　8時00分から11時59分
    //昼の時間　12時00分から17時59分
    //晩の時間　18時00分から23時59分
    //深夜の時間は取らない

    [SerializeField] GameObject logObj;
    [SerializeField] Transform content;
    LogString LogString = new LogString();
    int[][] randIdx;
    const int QUANTITY = 16;

    private void Start()
    {
        randIdx = new int[3][];

        for(int i = 0; i < randIdx.Length; i++)
        {
            randIdx[i] = new int[LogString.Logs.Length];
            for(int j = 0;j < randIdx[i].Length; j++)
            {
                randIdx[i][j] = j;
            }
        }

        LogPush(GameManager.lastTime, DateTime.Now);
    }

    public void LogPush(DateTime lastTime, DateTime thisTime)
    {
        int cnt = 0;

        //シャッフル
        for(int i = 0;i < randIdx.Length; i++)
        {
            GameManager.Shuffle(randIdx[i]);
        }

        //lastTimeがthisTimeに追いつくまで繰り返させる。
        //その間の朝昼晩はif文で 深夜の時間帯は無視。
        LogObject logScript;
        int randLogTextIdx = 0;

        int TimeSlot = 0;
        //時間が朝の時間帯(8時00分～11時59分)か
        if (lastTime.TimeOfDay >= new TimeSpan(8, 0, 0) && lastTime.TimeOfDay <= new TimeSpan(11, 59, 0))
        {
            TimeSlot = 0;
        }
        //時間が昼の時間帯(12時00分～17時59分)か
        else if (lastTime.TimeOfDay >= new TimeSpan(12, 0, 0) && lastTime.TimeOfDay <= new TimeSpan(17, 59, 0))
        {
            TimeSlot = 1;
        }
        //時間が晩の時間帯(18時00分～23時59分)か
        else if (lastTime.TimeOfDay >= new TimeSpan(18, 0, 0) && lastTime.TimeOfDay <= new TimeSpan(23, 59, 0))
        {
            TimeSlot = 2;
        }
        int TimeSlotCopy = TimeSlot;

        while (lastTime < thisTime && cnt < QUANTITY)
        {
            //時間が朝の時間帯(8時00分～11時59分)か
            if (lastTime.TimeOfDay >= new TimeSpan(8, 0, 0) && lastTime.TimeOfDay <= new TimeSpan(11, 59, 0))
            {
                TimeSlotCopy = 0;
            }
            //時間が昼の時間帯(12時00分～17時59分)か
            else if (lastTime.TimeOfDay >= new TimeSpan(12, 0, 0) && lastTime.TimeOfDay <= new TimeSpan(17, 59, 0))
            {
                TimeSlotCopy = 1;
            }
            //時間が晩の時間帯(18時00分～23時59分)か
            else if (lastTime.TimeOfDay >= new TimeSpan(18, 0, 0) && lastTime.TimeOfDay <= new TimeSpan(23, 59, 0))
            {
                TimeSlotCopy = 2;
            }
            else
            {
                lastTime = lastTime.AddHours(1);
                continue;
            }

            GameObject obj = Instantiate(logObj, content);

            logScript = obj.GetComponent<LogObject>();
            //ランダムな時間を出す
            TimeSpan randomTime = new TimeSpan(
                lastTime.Hour,
                UnityEngine.Random.Range(0, 60),
                0
            );
            logScript.setTimeText(randomTime);

            logScript.setLogText(LogString.Logs[TimeSlotCopy][randLogTextIdx]);

            //時間帯の変わり目
            if(TimeSlot != TimeSlotCopy)
            {
                TimeSlot = TimeSlotCopy;
                randLogTextIdx = 0;
            }
            lastTime = lastTime.AddHours(1);
            randLogTextIdx++;
            cnt++;
        }
        
    }
}

class LogString
{
    //朝昼晩で分割する
    public string[][] Logs =
    {
        //朝の時間帯
        new string[] 
        {
            "ソファでウトウトしているようだ",
            "落ち着かない様子でスマホを見ている",
            "一度目を覚ましたようだが、また眠ってしまった",
            "冷蔵庫を開けて、朝ごはんを探している",
            "ソファでぼんやりしている",
            "リビングを軽く片付けている",
            "スマホを触りながら、君の帰りを気にしている",
            "君がいつ帰ってくるのか、時計を何度も確認している"

        },
        //昼の時間帯
        new string[] 
        {
            "ソファに寝転がってネットを眺めている",
            "一人でゲームをして暇を潰している",
            "動画を見ながら、のんびり過ごしている",
            "昼ごはんを食べ終えて、そのままソファでくつろいでいる",
            "部屋の掃除を始めたようだ",
            "君と一緒に遊んでいたゲームを、一人で少し進めている",
            "することがなくなったのか、ソファで昼寝をしている",
            "スマホを開いては閉じてを繰り返している",
            "君に連絡しようか迷っているようだ"
        },
        //晩の時間帯
        new string[] 
        {
            "外で音がするたび、そちらを気にしている",
            "眠そうにしているが、まだ寝るつもりはないようだ",
            "ソファに座ってテレビを眺めている",
            "お風呂を済ませて、くつろいでいる",
            "夕食の準備を始めている",
            "スマホを眺めながら君を待っている",
            "君の帰りを待っていたようだが、ソファで眠ってしまった",
            "君の分の夕食も作って待っている",
        }
    };
    
    
}
