using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTitle : MonoBehaviour
{
    public void OnClick()
    {
        FadeManager.Instance.LoadSceneWithFade("TitleScene");
    }
}
