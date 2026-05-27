using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    [SerializeField] private float fadeTime = 1f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        fadeCanvasGroup.alpha = 1f;
    }

    public void startFade()
    {
        // フェードイン
        fadeCanvasGroup.DOFade(0f, fadeTime);

        // 操作可能
        fadeCanvasGroup.blocksRaycasts = false;
    }

    public void LoadSceneWithFade(string sceneName)
    {
        // フェード中は操作禁止
        fadeCanvasGroup.blocksRaycasts = true;

        // フェードアウト
        fadeCanvasGroup.DOFade(1f, fadeTime)
            .OnComplete(() =>
            {
                // シーン切り替え
                SceneManager.LoadScene(sceneName);

                // フェードイン
                fadeCanvasGroup.DOFade(0f, fadeTime)
                    .OnComplete(() =>
                    {
                        // 操作再開
                        fadeCanvasGroup.blocksRaycasts = false;
                    });
            });
    }
}