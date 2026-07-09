using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;

public class AwakeNamed : MonoBehaviour
{
    [SerializeField] InputField input;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject childObj;

    private void Awake()
    {
        if (!GameManager.isFirstPlay)
        {
            childObj.SetActive(true);
        }
    }

    public void OnDecision()
    {
        GameManager.isFirstPlay = true;
        gameManager.SetName(input.text);
        doFade();
    }

    async void doFade()
    {
        await FadeManager.Instance.FadeCanvasGroup.DOFade(1, 1f).AsyncWaitForCompletion();
        await Task.Delay(500);
        childObj.SetActive(false);
        await FadeManager.Instance.FadeCanvasGroup.DOFade(0, 1f).AsyncWaitForCompletion();
    }
}
