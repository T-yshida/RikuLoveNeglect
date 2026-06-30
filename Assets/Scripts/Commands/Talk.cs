using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Talk : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text nameText;
    [SerializeField] TextMeshProUGUI talkingText;

    [TextArea]
    [SerializeField] private string message;

    [SerializeField] private float interval = 0.05f;

    private bool isTyping = false;

    void Update()
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
        nameText.text = name;
        message = talkMessage.Replace("{$name}", GameManager.gfName);

        StartCoroutine(TypeText());
    }

    public IEnumerator TypeText()
    {
        isTyping = true;

        talkingText.text = message;
        talkingText.maxVisibleCharacters = 0;

        for (int i = 0; i <= message.Length; i++)
        {
            talkingText.maxVisibleCharacters = i;
            yield return new WaitForSeconds(interval);
        }

        isTyping = false;
    }

    void SkipText()
    {
        StopCoroutine(TypeText());

        talkingText.maxVisibleCharacters = message.Length;

        isTyping = false;
    }
}
