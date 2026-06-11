using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    [SerializeField] private Text fadeText;
    [SerializeField] private float fadeTime = 1f;

    public static FadeManager Instance { get; private set; }
    public CanvasGroup FadeCanvasGroup => fadeCanvasGroup;
    public Text FadeText => fadeText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void startFade()
    {
        // フェードイン
        FadeCanvasGroup.DOFade(0f, fadeTime);

        // 操作可能
        FadeCanvasGroup.blocksRaycasts = false;
    }

    public void LoadSceneWithFade(string sceneName)
    {
        // フェード中は操作禁止
        FadeCanvasGroup.blocksRaycasts = true;

        // フェードアウト
        FadeCanvasGroup.DOFade(1f, fadeTime)
            .OnComplete(() =>
            {
                // シーン切り替え
                SceneManager.LoadScene(sceneName);

                // フェードイン
                FadeCanvasGroup.DOFade(0f, fadeTime)
                    .OnComplete(() =>
                    {
                        // 操作再開
                        FadeCanvasGroup.blocksRaycasts = false;
                    });
            });
    }
}