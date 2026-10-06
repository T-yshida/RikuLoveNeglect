using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private TextMeshProUGUI talkingText;

    [TextArea]
    [SerializeField] private string message;

    [SerializeField] private float interval = 0.05f;

    private bool isTyping;
    private Coroutine typingCoroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 文字送り中ならスキップ
            if (isTyping)
            {
                SkipText();
            }
            else
            {
                GameManager.talking = false;
            }
        }
    }

    public void callTalk(string name, string talkMessage)
    {
        //テキストボックス上の名前を変える
        nameText.text = name == "彼女"
            ? GameManager.gfName
            : name;

        //内容に{$name}が含まれていた場合、彼女の名前に置き換える。
        message = talkMessage.Replace("{$name}", GameManager.gfName);

        // 以前の文字送りが残っていたら停止
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        isTyping = true;

        talkingText.text = message;
        talkingText.maxVisibleCharacters = 0;

        // TMPに実際の文字数を計算させる
        talkingText.ForceMeshUpdate();
        int characterCount = talkingText.textInfo.characterCount;

        for (int i = 0; i <= characterCount; i++)
        {
            talkingText.maxVisibleCharacters = i;
            yield return new WaitForSeconds(interval);
        }

        isTyping = false;
        typingCoroutine = null;
    }

    private void SkipText()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        talkingText.maxVisibleCharacters = int.MaxValue;
        isTyping = false;
    }
}