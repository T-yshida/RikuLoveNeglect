using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Text volumeText;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

        // èâä˙ílîΩâf
        ChangeVolume(volumeSlider.value);
    }

    private void ChangeVolume(float value)
    {
        // 0Å`100Ç≈ï\é¶
        int volume = Mathf.RoundToInt(value);

        volumeText.text = $"âπó  {volume}";

        // é¿ç€ÇÃâπó ïœçX
        AudioListener.volume = volume / 100f;
    }
}