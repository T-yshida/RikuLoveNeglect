using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Text volumeText;

    private void OnEnable()
    {
        volumeSlider.value = GameManager.volume;
        volumeText.text = $"音量 {GameManager.volume}";
    }

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

        // 初期値反映
        ChangeVolume(volumeSlider.value);
    }

    private void ChangeVolume(float value)
    {
        // 0～100で表示
        int volume = Mathf.RoundToInt(value);

        volumeText.text = $"音量 {volume}";

        // 実際の音量変更は保存ボタンで行う
    }
}