using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine.UI;

public class NextDay : MonoBehaviour
{
    [SerializeField] Text dayText;

    private void OnEnable()
    {
        dayText.text = GameManager.numberOfDays.ToString();
    }
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
        dayText.text = GameManager.numberOfDays.ToString();
        await Task.Delay(500);
        await FadeManager.Instance.FadeCanvasGroup.DOFade(0, 1f).AsyncWaitForCompletion();
        
    }
}
