using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//エンディング後リセットできる変数をリセットする
public class EndReset : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Reset()
    {
        GameManager.illMeter = 0;
        GameManager.loveMeter = 0;
        GameManager.isDepression = false;
        GameManager.isPm = false;
        GameManager.copySEndFlag = Instantiate(gameManager.sEndFlag);
        GameManager.commandExecuting = false;
    }
}
