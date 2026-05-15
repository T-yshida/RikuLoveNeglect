using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public int choiseNumber;
    public string[] storyCopy;

    public void selectButton()
    {
        Debug.Log(choiseNumber + " が押された");
        for (; GameManager.storyIndex < storyCopy.Length; GameManager.storyIndex++)
        {
            if (storyCopy[GameManager.storyIndex].Contains("<選択肢"))
            {
                Debug.Log("コマンド 選択肢：" + storyCopy[GameManager.storyIndex]);
                string num = storyCopy[GameManager.storyIndex].Substring(
                    storyCopy[GameManager.storyIndex].IndexOf(":") + 1
                    ).Replace(">", "");
                Debug.Log("num : " + num);
                var cNumber = int.Parse(num);
                if (choiseNumber == cNumber)
                {
                    Debug.Log("選択肢　ここまで進む：" + GameManager.storyIndex);
                    break;
                }
            }
        }
        GameManager.commandExecuting = false;
    }
}
