using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;
using System.Threading.Tasks;

public class SkinshipFadeInOut : MonoBehaviour
{
    public async void doFade(CanvasGroup cg)
    {
        await cg.DOFade(1, 1f).AsyncWaitForCompletion();
        await Task.Delay(500);
        await cg.DOFade(0, 1f).AsyncWaitForCompletion();
    }

}
