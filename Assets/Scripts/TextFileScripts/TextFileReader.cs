using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class TextFileReader : MonoBehaviour
{
    Command[] commands = new Command[9];
    TextFileSplitter splitter = new TextFileSplitter();
    [SerializeField] GameObject talkPanel;
    [SerializeField] Talk talkScript;
    //コマンド一覧
    private void Awake()
    {
        commands[0] = new Select();
        commands[1] = new ValueChange();
        commands[2] = new FadeIn();
        commands[3] = new FadeOut();
        commands[4] = new CharArt();
        commands[5] = new Background();
        commands[6] = new End();
        commands[7] = new SpecialFlag();
        commands[8] = new BGM();
    }

    public IEnumerator fileReader(TextAsset text)
    {
        string[] story = splitter.splitTextFile(text);
        for (;GameManager.storyIndex < story.Length; GameManager.storyIndex++) 
        {
            Debug.Log("storyIndex：" + GameManager.storyIndex);
            string line = story[GameManager.storyIndex];
            Debug.Log(line);
            if (line.Equals("end"))
            {
                /*
                 * 
                 * 
                 * 
                 * 終わりの処理を書く
                 * 
                 * 
                 * 
                 * 
                */
                FadeManager.Instance.LoadSceneWithFade("GameScene");
                Debug.Log("終わりです。");
            }

            if (line.Equals("}"))
            {
                Debug.Log("選択肢の終わり");
                GameManager.commandExecuting = true;
                commandSelector("選択肢", "}", story);
                yield return new WaitWhile(() => GameManager.commandExecuting);
                continue;
            }

            if (line.IndexOf("<") == 0)
            {
                var colonIndex = line.IndexOf(':');
                var endIndex = line.IndexOf('>');

                // コマンド名
                string command = line.Substring(1, colonIndex - 1);

                // コマンド内容
                string commandContent = line.Substring(
                    colonIndex + 1,
                    endIndex - colonIndex - 1
                );

                GameManager.commandExecuting = true;

                commandSelector(command, commandContent, story);

                if (command.Equals("エンド"))
                {
                    break;
                }

                yield return new WaitWhile(() => GameManager.commandExecuting);
                continue;
            }

            //ナレーション
            if (line.IndexOf("N") == 0)
            {
                talkPanel.SetActive(true);
                talkScript.callTalk("", line.Substring(1));

            }
            else
            {
                var brackets = line.IndexOf('「');
                Debug.Log(brackets);
                if (brackets <= 0)
                {
                    continue;
                }
                var talker = line.Substring(0, brackets);
                var talk = line.Substring(brackets + 1, line.Length - (brackets + 2));

                Debug.Log("話者：" + talker + "　内容：" + talk);
                talkPanel.SetActive(true);
                talkScript.callTalk(talker, talk);
            }

            GameManager.talking = true;
            yield return new WaitWhile(() => GameManager.talking);
        }

        GameManager.storyIndex = 0;
        yield return null;
    }

    void commandSelector(string command, string commandContent, string[] story)
    {
        talkPanel.SetActive(false);
        switch (command) 
        {
            case "選択肢":
                commands[0].useCommand(commandContent, story);
                break;
            case "値変化":
                commands[1].useCommand(commandContent, story);
                break;
            case "フェードイン":
                commands[2].useCommand(commandContent, story);
                break;
            case "フェードアウト":
                commands[3].useCommand(commandContent, story);
                break;
            case "立ち絵":
                commands[4].useCommand(commandContent, story);
                break;
            case "背景":
                commands[5].useCommand(commandContent, story);
                break;
            case "エンド":
                commands[6].useCommand(commandContent, story);
                break;
            case "特殊フラグ":
                commands[7].useCommand(commandContent, story);
                break;
            case "音楽":
                commands[8].useCommand(commandContent, story);
                break;
        }

    }
}
