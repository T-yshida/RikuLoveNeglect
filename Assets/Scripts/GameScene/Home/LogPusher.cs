using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class LogPusher : MonoBehaviour
{
    //’©‚ÌŠÔ@800•ª‚©‚ç1159•ª
    //’‹‚ÌŠÔ@1200•ª‚©‚ç1759•ª
    //”Ó‚ÌŠÔ@1800•ª‚©‚ç2359•ª
    //[–é‚ÌŠÔ‚Íæ‚ç‚È‚¢


    [SerializeField] GameObject logObj;
    [SerializeField] Transform content;
    LogString LogString;
    int[][] randIdx;

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
    }

    public void LogPush(int Quantity, DateTime lastTime, DateTime thisTime)
    {
        //ƒVƒƒƒbƒtƒ‹
        for(int i = 0;i < randIdx.Length; i++)
        {
            GameManager.Shuffle(randIdx[i]);
        }

        //lastTime‚ªthisTime‚É’Ç‚¢‚Â‚­‚Ü‚ÅŒJ‚è•Ô‚³‚¹‚éB
        //‚»‚ÌŠÔ‚Ì’©’‹”Ó‚Íif•¶‚Å [–é‚ÌŠÔ‘Ñ‚Í–³‹B
        LogObject logScript;
        int randLogTextIdx = 0;

        int TimeSlot = 0;
        //ŠÔ‚ª’©‚ÌŠÔ‘Ñ(800•ª`1159•ª)‚©
        if (lastTime.TimeOfDay >= new TimeSpan(8, 0, 0) && lastTime.TimeOfDay >= new TimeSpan(11, 59, 0))
        {
            TimeSlot = 0;
        }
        //ŠÔ‚ª’‹‚ÌŠÔ‘Ñ(1200•ª`1759•ª)‚©
        else if (lastTime.TimeOfDay >= new TimeSpan(12, 0, 0) && lastTime.TimeOfDay >= new TimeSpan(17, 59, 0))
        {
            TimeSlot = 1;
        }
        //ŠÔ‚ª”Ó‚ÌŠÔ‘Ñ(1800•ª`2359•ª)‚©
        else if (lastTime.TimeOfDay >= new TimeSpan(18, 0, 0) && lastTime.TimeOfDay >= new TimeSpan(23, 59, 0))
        {
            TimeSlot = 2;
        }
        int TimeSlotCopy = TimeSlot;

        while (lastTime < thisTime)
        {
            //ŠÔ‚ª’©‚ÌŠÔ‘Ñ(800•ª`1159•ª)‚©
            if (lastTime.TimeOfDay >= new TimeSpan(8, 0, 0) && lastTime.TimeOfDay >= new TimeSpan(11, 59, 0))
            {
                TimeSlotCopy = 0;
            }
            //ŠÔ‚ª’‹‚ÌŠÔ‘Ñ(1200•ª`1759•ª)‚©
            else if (lastTime.TimeOfDay >= new TimeSpan(12, 0, 0) && lastTime.TimeOfDay >= new TimeSpan(17, 59, 0))
            {
                TimeSlotCopy = 1;
            }
            //ŠÔ‚ª”Ó‚ÌŠÔ‘Ñ(1800•ª`2359•ª)‚©
            else if (lastTime.TimeOfDay >= new TimeSpan(18, 0, 0) && lastTime.TimeOfDay >= new TimeSpan(23, 59, 0))
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
            //ƒ‰ƒ“ƒ_ƒ€‚ÈŠÔ‚ğo‚·
            TimeSpan randomTime = new TimeSpan(
                lastTime.Hour,
                UnityEngine.Random.Range(0, 60),
                0
            );
            logScript.setTimeText(randomTime);

            logScript.setLogText(LogString.Logs[TimeSlot][randLogTextIdx]);

            if(TimeSlot != TimeSlotCopy)
            {
                TimeSlot = TimeSlotCopy;

            }
            lastTime = lastTime.AddHours(1);
        }
        
    }
}

class LogString
{
    //’©’‹”Ó‚Å•ªŠ„‚·‚é
    public string[][] Logs =
    {
        new string[] 
        {
            "",
            ""
        },
        new string[] 
        {
            ""
        },
        new string[] 
        { 
            ""
        }
    };
    
    
}
