using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Command))]
#endif

public class Select : Command
{
    string[] storyCopy;
    GameManager gameManager;
    GameObject buttonPrefab;
    List<GameObject> buttonCurrent = new List<GameObject>();

    public Select()
    {
         gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
         buttonPrefab = Resources.Load<GameObject>("SelectButton");
    }

    //ボタンを選択肢の分だけ出す処理
    public override void useCommand(string commandContent, string[] story)
    {
        storyCopy = story;
        if (commandContent.Equals("}"))
        {
            while (!storyCopy[GameManager.storyIndex].Equals("<選択肢:end>"))
            {
                GameManager.storyIndex++;
            }
            GameManager.commandExecuting = false;
            return;
        }
        GameManager.storyIndex++;
        string[] selectContext = commandContent.Split("/");
        for (int i = 0;i < selectContext.Length;i++)
        {
            createButton(selectContext[i], i + 1);
        }
    }

    void createButton(string text, int choiseNumber)
    {
        GameObject buttonObj = Object.Instantiate(buttonPrefab, gameManager.choiseContent);

        buttonCurrent.Add(buttonObj);

        Text label = buttonObj.GetComponentInChildren<Text>();
        label.text = text;

        Button button = buttonObj.GetComponent<Button>();

        int localChoiceNumber = choiseNumber;

        //選択肢ボタンが押された時の処理
        //GameManager.storyIndexを選択肢の分進める
        button.onClick.AddListener(() =>
        {
            Debug.Log(text + " が押された");
            for(;GameManager.storyIndex < storyCopy.Length; GameManager.storyIndex++)
            {
                if (storyCopy[GameManager.storyIndex].Contains("<選択肢"))
                {
                    Debug.Log("コマンド 選択肢：" + storyCopy[GameManager.storyIndex]);
                    string num = storyCopy[GameManager.storyIndex].Substring(
                        storyCopy[GameManager.storyIndex].IndexOf(":") + 1
                        ).Replace(">{", "");
                    Debug.Log("num : " + num);
                    var cNumber = int.Parse(num);
                    if(localChoiceNumber == cNumber)
                    {
                        Debug.Log("選択肢　ここまで進む：" + GameManager.storyIndex);
                        break;
                    }
                }
            }

            GameManager.commandExecuting = false;
            foreach(GameObject btn in buttonCurrent)
            {
                Object.Destroy(btn);
            }

            buttonCurrent.Clear();
        });
    }
}
