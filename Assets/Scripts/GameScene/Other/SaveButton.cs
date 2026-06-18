using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Toggle toggle;

    private void OnEnable()
    {
        toggle.isOn = GameManager.isNotice;
    }

    public void OnClick()
    {
        GameManager.volume = (int)slider.value;
        GameManager.isNotice = toggle.isOn;

        AudioListener.volume = GameManager.volume / 100f;

        Debug.Log(AudioListener.volume);
    }
}
