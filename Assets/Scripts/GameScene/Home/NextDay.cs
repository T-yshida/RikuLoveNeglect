using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class NextDay : MonoBehaviour
{
    public void nextToDay()
    {
        GameManager.numberOfDays++;
        GameManager.restDate = 2;
        GameManager.isSkinship = true;


        doFade();
    }

    public async void doFade()
    {
        await FadeManager.Instance.FadeCanvasGroup.DOFade(1, 1f).AsyncWaitForCompletion();
        await Task.Delay(500);
        await FadeManager.Instance.FadeCanvasGroup.DOFade(0, 1f).AsyncWaitForCompletion();
    }
}
