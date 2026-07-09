using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTitle : MonoBehaviour
{
    [SerializeField] Save save;
    public void OnClick()
    {
        save.doSave();
        FadeManager.Instance.LoadSceneWithFade("TitleScene");
    }
}
